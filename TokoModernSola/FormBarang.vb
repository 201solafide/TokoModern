Imports Npgsql

Public Class FormBarang
    ' fungsi memanggil tampilan ata dari postgresql

    Sub TampilkanData()
        Try
            'dimulai buka koneksi ke db terlebih dahulu
            OpenKoneksi()

            Dim query As String = "SELECT kode_barang As ""Kode Barang"", nama_barang As ""Nama Barang"", stok As ""Stok Barang"", harga_jual As ""Harga Barang"" FROM barang ORDER BY kode_barang ASC"

            da = New NpgsqlDataAdapter(query, koneksi) 'perintah ini untuk menjembatani proess menarik data dari query diatas melalui koneksi yang aktif

            'ds sebagai memori virtual di Ram komputer yang menampung tabel bayangan
            ds = New DataSet()

            'da.fill akan mengirimkan data yang ditarik ke ds (memori tabel bayangan sementara)
            da.Fill(ds, "barang")

            DgvBarang.DataSource = ds.Tables("barang") 'datagridview di ui ditarik untuk menampilkan data

            DgvBarang.Columns("Kode Barang").Width = 120
            DgvBarang.Columns("Kode Barang").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvBarang.Columns("Kode Barang").Frozen = True
            DgvBarang.Columns("Nama Barang").Width = 120
            DgvBarang.Columns("Nama Barang").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DgvBarang.Columns("Nama Barang").Frozen = False
            DgvBarang.Columns("Stok Barang").Width = 120
            DgvBarang.Columns("Stok Barang").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DgvBarang.Columns("Stok Barang").Frozen = False
            DgvBarang.Columns("Harga Barang").Width = 120
            DgvBarang.Columns("Harga Barang").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DgvBarang.Columns("Harga Barang").Frozen = False


        Catch ex As Exception
            MsgBox("Gagal memuat data kedalam tabel" & ex.Message, MsgBoxStyle.Critical)

        Finally
            'Always close koneksi db
            CloseKoneksi()
        End Try
    End Sub

    ' Menyiapan fungsi logic untuk membersihkan form inputan
    Sub BersihkanForm()
        TxtKode.Clear()
        TxtBarang.Clear()
        TxtHarga.Text = "0"
        TxtStok.Text = "0"
        txtPromosi.Clear()
        txtHargaNet.Clear()

        txtPromosi.Enabled = True
        txtHargaNet.Enabled = True
        TxtKode.Enabled = True
        TxtKode.Focus() 'KOndisi untuk cursor
    End Sub


    'SELANJUTNYA MENGATUR LOGIC TAMPILAN UI PERTAMA KALI
    Private Sub FormBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilkanData() 'UNTUK MENAMPILKAN DATA
        BersihkanForm() 'UNTUK BERSIHKAN FORM INPUT
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        'VALIDASI FORM INPUT TERINPUT SEMUA 
        If TxtKode.Text = "" Or TxtBarang.Text = "" Or TxtHarga.Text = "" Or TxtStok.Text = "" Then
            MsgBox("Lengkapi Kode dan data barang terlebih dahulu", MsgBoxStyle.Exclamation, "validasi gagal")

        Else
            'LOGIC UNTUK PROSES PERUBAHAN DATA DI DB
            Try
                OpenKoneksi()

                ' query untuk simpan data ke db
                Dim QuerySimpanData As String = "INSERT INTO barang (kode_barang, nama_barang, stok, harga_jual) VALUES (@kode, @nama, @stok, @harga)"

                cmd = New NpgsqlCommand(QuerySimpanData, koneksi)

                cmd.Parameters.AddWithValue("@kode", TxtKode.Text)
                cmd.Parameters.AddWithValue("@nama", TxtBarang.Text)
                cmd.Parameters.AddWithValue("@stok", Convert.ToInt32(TxtStok.Text))
                cmd.Parameters.AddWithValue("@harga", Convert.ToInt32(TxtHarga.Text))

                cmd.ExecuteNonQuery()

                MsgBox("Data barang baru berhasil ditambahkan ", MsgBoxStyle.Information, "Sukses")


                'REFRESH PAGE DENGAN MENAMPILKAN DATA BARU
                TampilkanData()
                BersihkanForm()

            Catch ex As Exception
                MsgBox("Gagal menambah data, pastikan kode barang tidak kembar, DETAIL: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                CloseKoneksi()

            End Try
        End If
    End Sub

    'LOGIKA KETIKA BARIS DI DATA GRID DI KLIK AKAN MEMUNCULKAN DI KOTAK INPUT
    Private Sub dgvBarang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvBarang.CellClick
        ' Validasi baris yang diklik bukan header
        If e.RowIndex >= 0 Then
            Dim baris As DataGridViewRow = DgvBarang.Rows(e.RowIndex) ' Membuat objek baris yang diklik

            ' 1. TARIK DATA UTAMA KE TEXTBOX (Kode & Nama)
            TxtKode.Text = baris.Cells("Kode Barang").Value.ToString()
            TxtBarang.Text = baris.Cells("Nama Barang").Value.ToString()

            ' 2. AMBIL NILAI MURNI DARI GRID SEBAGAI STRING (Antisipasi format desimal .00 atau ,00 dari database)
            Dim teksStok As String = baris.Cells("Stok Barang").Value.ToString().Trim()
            Dim teksHarga As String = baris.Cells("Harga Barang").Value.ToString().Trim()

            ' 3. LOGIKA POTONG DESIMAL (.00 ATAU ,00) LANGSUNG DARI DATA GRID
            If teksStok.Contains(".") Then teksStok = teksStok.Split("."c)(0)
            If teksHarga.Contains(".") Then teksHarga = teksHarga.Split("."c)(0)

            If teksStok.Contains(",") Then teksStok = teksStok.Split("."c)(0)
            If teksHarga.Contains(",") Then teksHarga = teksHarga.Split(","c)(0)

            ' 4. MASUKKAN HASIL BERSIH ANGKA MURNI KE TEXTBOX INPUT
            TxtStok.Text = teksStok
            TxtHarga.Text = teksHarga

            ' 5. UBAH KE TIPE DESIMAL UNTUK KEPERLUAN HITUNG DISKON (Aman karena sudah pasti angka murni)
            Dim hargaAsli As Decimal = 0
            Decimal.TryParse(teksHarga, hargaAsli)
            Dim diskonPersen As Decimal = ClassPromosiDiskon.CekStatusPromosi(TxtKode.Text)

            ' 6. LOGIC CONDITION JIKA ADA PROMO DI KODE BARANG
            If diskonPersen > 0 Then
                ' KONDISI JIKA ADA PROMOSI
                txtPromosi.Visible = True
                txtHargaNet.Visible = True

                txtPromosi.Enabled = False
                txtPromosi.Text = diskonPersen.ToString() & "%"

                ' HITUNG HARGA NET
                Dim hargaNet As Decimal = ClassPromosiDiskon.HargaDiskon(hargaAsli, diskonPersen)

                txtHargaNet.Enabled = False
                txtHargaNet.Text = Math.Truncate(hargaNet).ToString() ' Tampilkan angka murni tanpa desimal
            Else
                ' KONDISI JIKA TIDAK ADA PROMOSI
                txtPromosi.Enabled = False
                txtHargaNet.Enabled = False

                txtPromosi.Text = ""
                txtHargaNet.Text = ""
            End If

            ' KUNCI KODE BARANG KARENA PRIMARY KEY (TIDAK DAPAT DIUBAH SAAT EDIT)
            TxtKode.Enabled = False

        End If
    End Sub


    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        'VALIDASI TERLEBIH DAHULU, USER SUDAH MEMILIH BARIS YANG AKAN DI EDIT
        If TxtKode.Text = "" Then 'LOGIKA ini mengecek txtKode dalam keadaan kosong
            MsgBox("Pilih terlebih dahulu data barang yang ingin diubah melalui tabel!!")

        Else 'KONDISIKA JIKA txtKode TIDAK dalam keadaan kosong

            ' BERSIHKAN FORMAT DATA YANG DITARIK DATA GRID
            Dim bersihStok As Integer = TxtStok.Text.Replace(".", "").Trim()
            Dim bersihHarga As Integer = TxtHarga.Text.Replace(".", "").Trim()

            Dim nilaiStok As Integer
            Dim nilaiHarga As Decimal
            ' Jika konversi gagal, program tidak akan crash, melainkan memunculkan pesan peringatan
            If Not Integer.TryParse(bersihStok, nilaiStok) Then
                MsgBox("Format angka pada kolom STOK salah!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Not Decimal.TryParse(bersihHarga, nilaiHarga) Then
                MsgBox("Format angka pada kolom HARGA salah!", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Try
                OpenKoneksi() 'buka koneksi ke db terlebih dahulu

                'ATUR QUERY UNTUK UPDATE
                Dim queryUpdate As String = "UPDATE barang set nama_barang = @nama, stok = @stok, harga_jual = @harga WHERE kode_barang = @kode"
                ' INI MENGUBAH DATA UNTUK SETIAP PARAMETER TABLE DATABASE
                ' @nama, @stok, @harga, @kode merupakan parameter yang menyimpan data sementara
                ' JADI LOGIC NYA, query akan menjalankan perubahan data untuk parameter nama_barang yang disimpan di paramater @nama dan parameter seterusnya

                cmd = New NpgsqlCommand(queryUpdate, koneksi)

                cmd.Parameters.AddWithValue("@kode", TxtKode.Text)
                cmd.Parameters.AddWithValue("@nama", TxtBarang.Text)
                cmd.Parameters.AddWithValue("@kode", nilaiStok)
                'cmd.Parameters.AddWithValue("@stok", Convert.ToInt32(TxtStok.Text)) 'diganti dengan variabel yang menyimpan nilai konveri integer
                cmd.Parameters.AddWithValue("@harga", nilaiHarga)
                'cmd.Parameters.AddWithValue("@harga", Convert.ToDecimal(TxtHarga.Text)) 'diganti dengan variabel yagn menyimpan nilai konversi decimal 

                cmd.ExecuteNonQuery() 'PERINTAH EKSEKUSI QUERY DI DATABASE

                MsgBox("Data berhasil diubah", MsgBoxStyle.Information, "Sukses")


                'SETELAH PROSES PERUBAHAN SELESAI, SELANJUTNY REFRESH TAMPILAN DATA 
                TampilkanData()
                BersihkanForm()


                'BUKA KEMBALI AKSES FORM KODE BARANG UNTUK INPUT DATA BARU
                TxtKode.Enabled = True

            Catch ex As Exception
                MsgBox("Gagal ubah data, DETAIL: " & ex.Message, MsgBoxStyle.Critical)

            Finally
                CloseKoneksi() 'SELALU TUTUP KONEKSI KE DB
            End Try
        End If

    End Sub


    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        'ALUR LOGIKA NYA SAMA SEPERTI BTN EDIT DIATAS
        'CEK TERLEBIH DAHULU BARIS YANG DIKLIK
        If TxtKode.Text = "" Then
            MsgBox("Pilih terlebih dahulu datanya")

        Else
            Dim konfirmasi As DialogResult = MsgBox("Apakah Anda yakin ingin menghapus barang [" & TxtBarang.Text & "] dari gudang secara permanen?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi Hapus")

            If konfirmasi = DialogResult.Yes Then

                Try
                    'BUKA KONEKSI KE DATABASE
                    OpenKoneksi()

                    'ATUR VARIABEL menyimpan query
                    Dim queryHapus As String = "DELETE FROM barang where kode_barang = @kode"

                    cmd = New NpgsqlCommand(queryHapus, koneksi)

                    cmd.Parameters.AddWithValue("@kode", TxtKode.Text)

                    cmd.ExecuteNonQuery() 'EKSEKUSI QUERY DI DB

                    MsgBox("Data berhasil dihapus", MsgBoxStyle.Information, "Sukses")

                    'SETELAH PROSES HAPUS, Refresh DATA
                    TampilkanData()
                    BersihkanForm()

                    TxtKode.Enabled = True
                Catch ex As Exception
                    MsgBox("Gagal menghapus data " & ex.Message, MsgBoxStyle.Critical)

                Finally
                    CloseKoneksi()
                End Try

            End If

        End If
    End Sub

    Public Sub RefreshStokBarang()
        ' KODE DATABASE ANDA DI SINI
        ' Contoh: Tarik data stok terbaru dari database, lalu masukkan ke DataGridView
        ' DataGridView1.DataSource = AmbilDataStokTerbaru()
        TampilkanData()

    End Sub


    Private Sub btnNavBarang_Click(sender As Object, e As EventArgs) Handles btnNavBarang.Click

        Me.Hide()
    End Sub

    Private Sub btnNavPos_Click(sender As Object, e As EventArgs) Handles btnNavPos.Click
        FormKasir.Show()
        Me.Hide()
    End Sub

    Private Sub btnNavLaporan_Click(sender As Object, e As EventArgs) Handles btnNavLaporan.Click
        FormLaporan.Show()
        Me.Hide()
    End Sub

    Private Sub FormBarang_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub FormBarang_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RefreshStokBarang()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        BersihkanForm()
    End Sub

    Private Sub TxtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtHarga.KeyPress
        'HANYA MENGINZIKAN ANGKA (0-9) DAN BACKSCPACE(CHR(8))
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True 'TOLAK INPUTAN SELAIN ANGKA
        End If
    End Sub
End Class
