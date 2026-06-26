Public Class ClassPromosiDiskon
    Public Shared Function CekStatusPromosi(KodeBarang As String) As Decimal
        'Dim listKodeBarang() As String = {"T2E001", "T2D002", "T2D001", "BRG001", "BRG002"}
        Dim listKodeBarangPromosi() As String = {"R2E003", "R2E004", "R2E005", "R2D005", "R2D006", "R2D007", "R2D008", "R2D009", "R2D010", "ELK002", "ELK003", "ELK004", "FSH001", "FSH002", "FSH003", "FSH004" &
        "FSH008", "FSH009", "FSH010", "BRG001"}


        For j = 0 To listKodeBarangPromosi.Length - 1
            If listKodeBarangPromosi(j) = KodeBarang Then 'MENGECEK KODE BARANG SESUAI DENGAN LIST KODEBARANGPROMOSI
                If KodeBarang = "ELK002" Then
                    Return 10.4
                End If

                Return 5.3
            End If

        Next
    End Function

    'Dim hargaAsli As Decimal = Convert.ToDecimal(txtHarga.Text)
    'Dim jumlahBaru As Integer = Convert.ToInt32(txtJumlah.Text)

    Public Shared Function HargaDiskon(hargaAsli As Decimal, diskonPromosi As Decimal)
        Dim potonganHarga = hargaAsli * (diskonPromosi / 100)
        Dim hargaNet As Decimal = hargaAsli - potonganHarga

        Return hargaNet
    End Function
End Class
