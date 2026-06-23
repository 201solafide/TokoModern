Imports Npgsql


Public Class FormKasir
    'MEMBUAT NOMOR NOTA OTOMATIS (FORMAT : NOTA-yyMMdd-00001)

    '==================================================================
    '====================== FRONT END LOGIC =============================
    '==================================================================

    Sub BuatNotaOtomatis()
        Try
            OpenKoneksi()
            Dim tanggal As String = DateTime.Now.ToString("yyyyMMdd") 'KONDISI INI MENYIMPAN TANGGAL:STRING ke variabel tanggal

            'query untuk mencari nota terbaru hari ini
            Dim queryNota As String = "SELECT no_nota from penjualan where no_nota LIKE 'NOTA-" & tanggal & "-%' ORDER BY no_nota DESC LIMIT 1"
            cmd = New NpgsqlCommand(queryNota, koneksi)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                ' JIKA sudah ada nota hari ini, ambil 4 angka terakhir lalu tambah 1
                Dim notaTerakhir As String = dr("no_nota").ToString()
                Dim AngkaTerakhir As Integer = Convert.ToInt32(notaTerakhir.Substring(14, 4))
                Dim AngkaBaru As Integer = AngkaTerakhir + 1
                txtNota.Text = "NOTA-" & tanggal & "-" & AngkaBaru.ToString("D4") 'D5 memaksa format angkat 4 digit

            Else
                txtNota.Text = "NOTA-" & tanggal & "-0001" 'KONDISI JIKA BELUM ADA NOTA HARI INI, dimulaid ari 00001

            End If

        Catch ex As Exception
            MsgBox("Gagal membuat nota otomatis, DETAIL : " & ex.Message, MsgBoxStyle.Critical)

        Finally
            CloseKoneksi()

        End Try
    End Sub

    'MENGHITUNG TOTAL BELANJA DI GRID VIEW

    Sub HitungGrandTotal()
        Dim total As Decimal = 0 'MENYIMPAN NILAI JUMLAH 



        'MELAKLUKAN LOOPING UNTUK SETIAP BARIS DI GRIDVIEW
        For i As Integer = 0 To dgvKeranjang.Rows.Count - 1
            'melewatkan baris kosong baru jika ada
            If dgvKeranjang.Rows(i).IsNewRow Then Continue For
            total += Convert.ToDecimal(dgvKeranjang.Rows(i).Cells("colSubTotal").Value)

        Next

        'TAMPILKAN HASIL KE LABEL GRAND TOTAL DENGAN FORMAT UANG RUPIAH
        lblGrandTotal.Text = "Rp." & total.ToString("N0")

    End Sub


    Public stokBarang As Integer = 0 'inisiasi variabel yang menyimpan stok barang

    'KONDISI SAAT FORM KASIR TERBUKA
    Private Sub FormKasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuatNotaOtomatis()
        dgvKeranjang.AllowUserToAddRows = False ' Menghapus baris otomasti dibawah paling grid
    End Sub


    '===============================
    'EVENT : KLIK ENTER UNTUK MENCARI KODE BARANG
    '===============================
    Private Sub txtCariKode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariKode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCariKode.Text = "" Then Exit Sub

            Try
                OpenKoneksi()
                Dim queryCariKode As String = "SELECT nama_barang, harga_jual, stok FROM barang where kode_barang = @kode"

                cmd = New NpgsqlCommand(queryCariKode, koneksi)
                cmd.Parameters.AddWithValue("@kode", txtCariKode.Text)
                dr = cmd.ExecuteReader() 'UNTUK MEMBACA KODE BARANG YANG DIMAUSKKAN DI GRID VIEW tersedia ada di database

                If dr.Read() Then
                    'CEK STOK BARANG TERLEBIH DAHULU SEBELUM DIJUAL
                    Dim stokGudang As Integer = Convert.ToInt32(dr("stok")) 'VARIABEL MENYIMPAN DATA STOK dari parameter stok di tableNYA (SI BARANG)
                    stokBarang = stokGudang 'untuk menitipkan data dari table db ke variabel global/public


                    If stokGudang <= 0 Then
                        MsgBox("Maaf stok barang habis")
                        txtCariKode.Clear()
                        Exit Sub
                    End If

                    'KONDISI JIKA BARANG DITEMUKAN (LOGIKA ELSE/LOGIKA LAIN DARI IF DI
                    txtNamaBarang.Text = dr("nama_barang").ToString()
                    txtHarga.Text = dr("harga_jual").ToString()
                    txtJumlah.Focus() 'PINDAHKAN KURSOR KE JUMLAH BELI OTOMATIS
                Else
                    MsgBox("Kode barang tidak terdaftar di sistem", MsgBoxStyle.Critical)
                    txtCariKode.Clear()
                End If
            Catch ex As Exception
                MsgBox("Error pencarian, DETAIL" & ex.Message, MsgBoxStyle.Critical)

            Finally
                CloseKoneksi()
            End Try
        End If
    End Sub

    'KONDISI JIKA TOMBOL TAMBAH di klik
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If txtNamaBarang.Text = "" Then
            MsgBox("Cari barangnya dulu:")
            Exit Sub
        End If
        'OR LIKE
        'If txtNamaBarang.Text = "" Then msgBox("Carai Barangnya dulu:") : Exit sub

        'HITUNG subtotal untuk barang (harga x jumlah)
        Dim hargaAsli As Decimal = Convert.ToDecimal(txtHarga.Text)
        Dim jumlahBaru As Integer = Convert.ToInt32(txtJumlah.Text)
        Dim jumlahLama As Integer = 0
        Dim hargaNet As Decimal
        Dim subtotal As Decimal

        'LOGIC JIKA PROMOSI BARANG
        Dim diskonPromosi As Decimal = ClassPromosiDiskon.CekStatusPromosi(txtCariKode.Text)

        If diskonPromosi > 0 Then
            Dim potongan As Decimal = hargaAsli * (diskonPromosi / 100)
            hargaNet = hargaAsli - potongan

            'txtHarga.Text = hargaNet.ToString("N2", New System.Globalization.CultureInfo("id-ID")) 'INPUT data hargaNet di grid

        Else
            hargaNet = hargaAsli
        End If

        Dim cekKodeBarangGrid As Boolean = False
        Dim posisiBaris As Integer = -1
        Dim totalYangDiminta As Integer = 0

        For i As Integer = 0 To dgvKeranjang.Rows.Count - 1
            If dgvKeranjang.Rows(i).IsNewRow Then Continue For

            Dim kodeBarang As String = dgvKeranjang.Rows(i).Cells("colKode").Value.ToString


            'BANDINGKAN variabel kodeBarang yang menyimpan data kodeBarang di grid dengan variabel txtCariKode represetnasi text yang mencari kode data di form input
            If kodeBarang = txtCariKode.Text Then
                cekKodeBarangGrid = True
                posisiBaris = i 'Mengambil nilai index untuk setiap baris grid
                jumlahLama = Convert.ToInt32(dgvKeranjang.Rows(posisiBaris).Cells("colJumlah").Value)
                Exit For

            End If
        Next

        'SETELAH PENGECEKKAN KONDISI LOOPING
        'variabel posisi baris saat ini sudah menyimpan value index (posisi baris)
        If cekKodeBarangGrid = True Then
            totalYangDiminta = jumlahLama + jumlahBaru
        Else
            totalYangDiminta = jumlahBaru
        End If

        ' 2. VALIDASI STOK TERLEBIH DAHULU (Paling Aman)
        If totalYangDiminta > stokBarang Then
            ' Jika tidak cukup, langsung tolak di sini. Grid tidak akan diganggu/dihapus
            MsgBox("Transaksi ditolak, stok di gudang tersisa " & stokBarang & " pcs, sedangkan total yang diminta " & totalYangDiminta & " pcs", MsgBoxStyle.Exclamation, "Stok tidak cukup")
            Exit Sub
        End If

        ' 3. JIKA STOK AMAN, BARU UPDATE ATAU TAMBAH BARIS KE GRID
        If cekKodeBarangGrid = True Then
            Dim subtotalBaru = hargaNet * totalYangDiminta ' Gunakan totalYangDiminta yang sudah valid

            dgvKeranjang.Rows(posisiBaris).Cells("colJumlah").Value = totalYangDiminta
            dgvKeranjang.Rows(posisiBaris).Cells("colSubTotal").Value = subtotalBaru
        Else
            subtotal = hargaNet * jumlahBaru
            dgvKeranjang.Rows.Add(txtCariKode.Text, txtNamaBarang.Text, hargaAsli, jumlahBaru, subtotal)
        End If
        'MASUKKAN DATA ke jumlah

        'HITUNG ULANG GRAND TOTAL BELANJAAN
        HitungGrandTotal()

        'BERSIHKAN KOTAK PENCARIAN agar kasir dapat scan produk kembali
        txtCariKode.Clear()
        txtNamaBarang.Clear()
        txtHarga.Text = "0"
        txtJumlah.Text = "0"
        txtCariKode.Focus()

    End Sub

    Private Sub txtJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlah.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Jika benar bukan angka, batalkan inputan tersebut agar tidak muncul di TextBox
            e.Handled = True
        End If
    End Sub



    'KONDISI UNTUK MENGIRIM DAN MENYIMPAN DATA TRANSAKSI DENGAN DATABASET TRANSACTION
    Private Sub btnSimpanTransaksi_Click(sender As Object, e As EventArgs) Handles btnSimpanTransaksi.Click
        'CEK DAN VALIDASI PRODUK ADA DI LIST GRID KERANJANG
        If dgvKeranjang.Rows.Count <= 0 Then
            MsgBox("Keranjang masih kosong, Lakukan transaksi penginputan data barang terlebih dahulu")
            Exit Sub
        End If

        'Validasi INFPUTAN PEMBAYARAN
        Dim teksInputBayar As String = lblGrandTotal.Text
        Dim teksTotalBersih As String = teksInputBayar.Replace("Rp.", "").Replace(".", "").Trim()
        Dim grandTotalBersih As String = Convert.ToDecimal(teksTotalBersih)
        Dim uangBayar As Decimal = Convert.ToDecimal(txtBayar.Text.Trim())


        ' Trik membersihkan karakter titik/koma yang mungkin diketik user sebagai pemisah ribuan
        Dim teksBayarBersih As String = txtBayar.Text.Replace(".", "").Replace(",", "").Trim()

        ' PROSES TRYPARSE: Mencoba konversi string ke desimal dengan aman
        If Not Decimal.TryParse(teksBayarBersih, uangBayar) Then
            MsgBox("Format uang yang Anda masukkan salah! Harap masukkan angka saja (Contoh: 50000).", MsgBoxStyle.Critical, "Format Salah")
            txtBayar.Focus()
            Exit Sub
        End If

        If uangBayar < grandTotalBersih Then
            MsgBox("Maaf, Uang pembayaran tidak cukup", MsgBoxStyle.Critical, "Pembayaran ditolak")

            Exit Sub
        End If

        'SETELAH MENGINPUT DATA UANG PEMBAYARAN, SELANJUTNYA HITUNG
        Dim uangKembalian As Decimal = uangBayar - grandTotalBersih
        lblKembali.Text = "Rp." & uangKembalian.ToString("N0", New System.Globalization.CultureInfo("id-ID"))
        'lblGrandTotal.Text = "Rp." & total.ToString("N0")

        '==================================================================
        '====================== BACK END LOGIC =============================
        '==================================================================
        OpenKoneksi()
        Dim transaksi As NpgsqlTransaction = Nothing

        Try
            ' 1. AKTIFKAN TRANSAKSI
            transaksi = koneksi.BeginTransaction()

            ' 2. EKSEKUSI MASTER (Wajib Berhasil Pertama Kali)
            Dim queryMaster As String = "INSERT INTO penjualan (no_nota, total_bayar) VALUES (@nota, @harga)"
            Using cmdMaster As New NpgsqlCommand(queryMaster, koneksi, transaksi)
                cmdMaster.Parameters.AddWithValue("@nota", txtNota.Text.Trim())
                cmdMaster.Parameters.AddWithValue("@harga", Convert.ToDecimal(grandTotalBersih))
                cmdMaster.ExecuteNonQuery() ' Menembak tabel penjualan
            End Using

            ' 3. PREPARASI QUERY DETAIL
            Dim queryDetail As String = "INSERT INTO detail_penjualan (no_nota, kode_barang, jumlah_beli, subtotal) VALUES (@nota, @kode, @jumlah, @sub)"
            Dim queryPotongStok As String = "UPDATE barang SET stok = stok - @jumlah WHERE kode_barang = @kode"

            ' 4. PERULANGAN DETAIL & POTONG STOK
            For i As Integer = 0 To dgvKeranjang.Rows.Count - 1
                Dim kodeBarang As String = dgvKeranjang.Rows(i).Cells("colKode").Value.ToString().Trim()
                Dim jumlahBeli As Integer = Convert.ToInt32(dgvKeranjang.Rows(i).Cells("colJumlah").Value)
                Dim subtotal As Decimal = Convert.ToDecimal(dgvKeranjang.Rows(i).Cells("colSubTotal").Value)

                ' Eksekusi Detail Penjualan
                Using cmdDetail As New NpgsqlCommand(queryDetail, koneksi, transaksi)
                    cmdDetail.Parameters.AddWithValue("@nota", txtNota.Text.Trim())
                    cmdDetail.Parameters.AddWithValue("@kode", kodeBarang)
                    cmdDetail.Parameters.AddWithValue("@jumlah", jumlahBeli)
                    cmdDetail.Parameters.AddWithValue("@sub", subtotal)
                    cmdDetail.ExecuteNonQuery()
                End Using

                ' Eksekusi Potong Stok di Gudang
                Using cmdPotongStok As New NpgsqlCommand(queryPotongStok, koneksi, transaksi)
                    cmdPotongStok.Parameters.AddWithValue("@jumlah", jumlahBeli)
                    cmdPotongStok.Parameters.AddWithValue("@kode", kodeBarang)
                    cmdPotongStok.ExecuteNonQuery()
                End Using
            Next

            ' 5. JIKA SEMUA LANXAR, COMMIT PERMANEN
            transaksi.Commit()
            MsgBox("Transaksi " & txtNota.Text & " Sukses disimpan!! Kembalian: Rp" & uangKembalian.ToString("N0"), MsgBoxStyle.Information, "Transaksi Sukses")

            ' RESET POS KASIR
            dgvKeranjang.Rows.Clear()
            lblGrandTotal.Text = "Rp.0"
            txtBayar.Text = "0"
            BuatNotaOtomatis()
            txtCariKode.Focus()

        Catch ex As Exception
            ' PERBAIKAN: Melakukan Rollback hanya jika transaksi AKTIF (IsNot Nothing)
            If transaksi IsNot Nothing Then
                transaksi.Rollback()
            End If

            ' Menampilkan pesan eror asli yang spesifik dari PostgreSQL
            MsgBox("Transaksi gagal total dan dibatalkan oleh sistem! Detail Error: " & ex.Message, MsgBoxStyle.Critical, "Sistem Rollback")
        Finally
            CloseKoneksi()
        End Try

    End Sub

    Private Sub txtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBayar.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Jika yang ditekan bukan angka, batalkan inputan tersebut
            e.Handled = True
        End If
    End Sub

End Class