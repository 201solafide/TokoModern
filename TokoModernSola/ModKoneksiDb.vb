Imports Npgsql

Module ModKoneksiDb

    'DEKLARASI VARIABEL GLOBAL UNTUK AKSES KONEKSI DB
    Public koneksi As NpgsqlConnection
    Public cmd As NpgsqlCommand
    Public da As NpgsqlDataAdapter
    Public dr As NpgsqlDataReader
    Public ds As DataSet

    Public Sub OpenKoneksi()
        ' asign variabel yang menyimpan alamat dari db postgre
        Dim alamatDb As String = "Host=192.168.249.193;Port=5432;User Id=simckl;Password=simckl;Database=simckl"

        Try
            If koneksi Is Nothing Then
                koneksi = New NpgsqlConnection(alamatDb) 'kode ini bertujuan untuk membuat instansiasi baru jika objek koneksi masih kosong (db belum ada

            End If

            If koneksi.State = ConnectionState.Closed Then 'Kondisi jika gerbang db tertutup, maka diperintah untuk dibuka
                koneksi.Open()

            End If

        Catch ex As Exception
            MsgBox("Koneksi database gagal: " & ex.Message, MsgBoxStyle.Critical, "Error sistem")
        End Try
    End Sub

    Public Sub CloseKoneksi()
        Try
            If koneksi.State = ConnectionState.Open Then
                koneksi.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub


End Module
