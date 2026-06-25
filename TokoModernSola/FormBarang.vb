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
            Dim baris As DataGridViewRow = DgvBarang.Rows(e.RowIndex) 'Kode ini untuk membuat objek baris yang diklik oleh user

            'Menarik data dari setiap kolom di baris yang diklik untuk disimpan di setiap txt input 
            TxtKode.Text = baris.Cells("Kode Barang").Value.ToString()
            TxtBarang.Text = baris.Cells("Nama Barang").Value.ToString()
            TxtStok.Text = baris.Cells("Stok Barang").Value.ToString()
            TxtHarga.Text = baris.Cells("Harga Barang").Value.ToString()

            Dim hargaAsli As Decimal = Convert.ToDecimal(baris.Cells("Harga Barang").Value)
            TxtHarga.Text = hargaAsli.ToString("N2", New System.Globalization.CultureInfo("id-ID"))


            'TAMBAHKAN LOGIC CONDITION jika ada promo di kode barang
            Dim diskonPersen As Decimal = ClassPromosiDiskon.CekStatusPromosi(TxtKode.Text)
            If diskonPersen > 0 Then
                'KONDISI JIKA ADA PROMOSI
                txtPromosi.Visible = True ' Menampilkan text promosi
                txtHargaNet.Visible = True 'Menampilkan text harga net

                'isi datanya bersiat enable | TIDAK DAPAT DIUBAH
                txtPromosi.Enabled = False
                txtPromosi.Text = diskonPersen.ToString() & "%"

                'HITUNG HARGA NET
                Dim potongan As Decimal = hargaAsli * (diskonPersen / 100)
                Dim hargaNet As Decimal = hargaAsli - potongan

                txtHargaNet.Enabled = False
                txtHargaNet.Text = hargaNet.ToString("N2", New System.Globalization.CultureInfo("id-ID"))

            Else
                txtPromosi.Enabled = False
                txtHargaNet.Enabled = False

                txtPromosi.Text = ""
                txtHargaNet.Text = ""
            End If

            'KUNCI KODE BARANG ITU PRIMARY KEY (TIDAK DAPAT DIUBAH)
            TxtKode.Enabled = False

        End If
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles BtnUbah.Click
        'VALIDASI TERLEBIH DAHULU, USER SUDAH MEMILIH BARIS YANG AKAN DI EDIT
        If TxtKode.Text = "" Then 'LOGIKA ini mengecek txtKode dalam keadaan kosong
            MsgBox("Pilih terlebih dahulu data barang yang ingin diubah melalui tabel!!")

        Else 'KONDISIKA JIKA txtKode TIDAK dalam keadaan kosong
            Try
                OpenKoneksi() 'buka koneksi ke db terlebih dahulu

                'ATUR QUERY UNTUK UPDATE
                Dim queryUpdate As String = "UPDATE barang set nama_barang = @nama, stok = @stok, harga_jual = @harga WHERE kode_barang = @kode"
                ' INI MENGUBAH DATA UNTUK SETIAP PARAMETER TABLE DATABASE
                ' @nama, @stok, @harga, @kode merupakan parameter yang menyimpan data sementara
                ' JADI LOGIC NYA, query akan menjalankan perubahan data untuk parameter nama_barang yang disimpan di paramater @nama dan parameter seterusnya

                cmd = New NpgsqlCommand(queryUpdate, koneksi)

                cmd.Parameters.AddWithValue("@nama", TxtBarang.Text)
                cmd.Parameters.AddWithValue("@stok", Convert.ToInt32(TxtStok.Text))
                cmd.Parameters.AddWithValue("@harga", Convert.ToDecimal(TxtHarga.Text))
                cmd.Parameters.AddWithValue("@kode", TxtKode.Text)

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

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        BersihkanForm()

    End Sub


End Class
