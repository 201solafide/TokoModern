Imports Npgsql
Imports System.IO 'import library untuk fungsi streamWriter (Menulis file teks)



Public Class FormLaporan
    '=============================
    'TAMPILKAN DAFTAR NOTA
    '=============================

    Sub TampilkanNotaMaster()
        Try
            OpenKoneksi() 'koneksi ke database

            'mengambil riwayat nota, urut dari yang paling baru dibuat
            Dim queryNota As String = "SELECT no_nota AS ""No Nota"", tanggal_transaksi AS ""Tanggal Transaksi"", total_bayar AS ""Total Belanja"" FROM penjualan ORDER BY tanggal_transaksi DESC"

            da = New NpgsqlDataAdapter(queryNota, koneksi) 'Menarik data melalui queryNota diatas
            ds = New DataSet() 'Membuat inisiasi dataset virtual
            da.Fill(ds, "master_nota") 'Mengirimkan data yang ditarik ke tabel virtual master_nota

            dgvMaster.DataSource = ds.Tables("master_nota") 'Datagridview akan menarik data dari master_nota ditampilkan di ui

            dgvMaster.Columns("No Nota").Width = 120
            dgvMaster.Columns("No Nota").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvMaster.Columns("No Nota").Frozen = False
            dgvMaster.Columns("Tanggal Transaksi").Width = 120
            dgvMaster.Columns("Tanggal Transaksi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvMaster.Columns("Tanggal Transaksi").Frozen = False
            dgvMaster.Columns("Total Belanja").Width = 120
            dgvMaster.Columns("Total Belanja").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvMaster.Columns("Total Belanja").Frozen = False

        Catch ex As Exception
            MsgBox("Gagal menarik dan memuat nota master : " & ex.Message, MsgBoxStyle.Critical)

        Finally
            CloseKoneksi() 'tutup koneksi database
        End Try


    End Sub

    Private Sub btnCetakText_Click(sender As Object, e As EventArgs) Handles btnCetakText.Click

    End Sub

    '==================
    'FORMAT LAPORAN PERTAMA KALI DIBUKA
    Private Sub FormLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilkanNotaMaster()

        dgvMaster.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Bisa juga melalui setting propertie dari datagrid nya

    End Sub


    '======================
    'KONDISI JIKA USER MENGKLIK CELL TERTENTU
    Private Sub dgvMaster_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaster.CellClick

        If e.RowIndex >= 0 Then
            Dim noNota As String = dgvMaster.Rows(e.RowIndex).Cells("No Nota").Value.ToString()
            'variabel noNota akan menyimpan value dari kolom "No Nota" di tabel yang diklik barisnya

            Try
                OpenKoneksi() 'Koneksi database

                Dim queryDetail As String = "SELECT dp.no_nota AS ""Nota"", " &
                                            "dp.kode_barang AS ""Kode Barang"", " &
                                            "b.harga_jual AS ""Harga Jual"", " & ' <-- LOGIKA: Diubah dari b.harga_jual ke dp.harga_jual
                                            "dp.jumlah_beli AS ""Jumlah Beli"", " &
                                            "p.total_bayar AS ""Total Bayar"", " &
                                            "dp.subtotal AS ""Sub Total"", " &
                                            "p.tanggal_transaksi AS ""Tanggal Transaksi"" " &
                                            "FROM penjualan p " &
                                            "INNER JOIN detail_penjualan dp ON p.no_nota = dp.no_nota " &
                                            "INNER JOIN barang b ON dp.kode_barang = b.kode_barang " & ' <-- Tetap join barang jika butuh kolom nama_barang nantinya
                                            "WHERE dp.no_nota = @nota"


                cmd = New NpgsqlCommand(queryDetail, koneksi)
                cmd.Parameters.AddWithValue("@nota", noNota)

                da = New NpgsqlDataAdapter(cmd)
                Dim dsDetail As New DataSet()
                da.Fill(dsDetail, "detail_nota")

                dgvDetail.DataSource = dsDetail.Tables("detail_nota")

                dgvDetail.Columns("Nota").Width = 80
                dgvDetail.Columns("Nota").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dgvDetail.Columns("Nota").Frozen = False
                dgvDetail.Columns("Kode Barang").Width = 120
                dgvDetail.Columns("Kode Barang").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgvDetail.Columns("Kode Barang").Frozen = False
                dgvDetail.Columns("Harga Jual").Width = 120
                dgvDetail.Columns("Harga Jual").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgvDetail.Columns("Harga Jual").Frozen = False
                dgvDetail.Columns("Jumlah Beli").Width = 120
                dgvDetail.Columns("Jumlah Beli").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgvDetail.Columns("Jumlah Beli").Frozen = False
                dgvDetail.Columns("Total Bayar").Width = 120
                dgvDetail.Columns("Total Bayar").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgvDetail.Columns("Total Bayar").Frozen = False
                dgvDetail.Columns("Sub Total").Width = 120
                dgvDetail.Columns("Sub Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgvDetail.Columns("Sub Total").Frozen = False
                dgvDetail.Columns("Tanggal Transaksi").Width = 120
                dgvDetail.Columns("Tanggal Transaksi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                dgvDetail.Columns("Tanggal Transaksi").Frozen = False
                'dgvDetail.Columns("Sub Total").Width = 120
                'dgvDetail.Columns("Sub Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'dgvDetail.Columns("Sub Total").Frozen = False
                'dgvDetail.Columns("Sub Total").Width = 120
                'dgvDetail.Columns("Sub Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'dgvDetail.Columns("Sub Total").Frozen = False

            Catch ex As Exception
                MsgBox("Gagal memuat data detail nota: " & ex.Message, MsgBoxStyle.Exclamation)

            Finally
                CloseKoneksi()
            End Try
        End If
    End Sub

    Public Sub RefreshDetailLaporan()
        ' KODE DATABASE ANDA DI SINI
        ' Contoh: Tarik data transaksi terbaru dari database untuk memperbarui laporan
        ' DataGridViewLaporan.DataSource = AmbilDataTransaksiTerbaru()
        TampilkanNotaMaster()
    End Sub


    Private Sub btnNavBarang_Click(sender As Object, e As EventArgs) Handles btnNavBarang.Click
        FormBarang.Show()
        Me.Hide()
    End Sub

    Private Sub btnNavPos_Click(sender As Object, e As EventArgs) Handles btnNavPos.Click
        FormKasir.Show()
        Me.Hide()
    End Sub

    Private Sub btnNavLaporan_Click(sender As Object, e As EventArgs) Handles btnNavLaporan.Click
        Me.Hide()
    End Sub

    Private Sub FormLaporan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub FormLaporan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RefreshDetailLaporan()
    End Sub
End Class