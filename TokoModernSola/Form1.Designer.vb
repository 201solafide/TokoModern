<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBarang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBarang))
        Me.KodeBarang = New System.Windows.Forms.Label()
        Me.NamaBarang = New System.Windows.Forms.Label()
        Me.StokAwal = New System.Windows.Forms.Label()
        Me.HargaJual = New System.Windows.Forms.Label()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.TxtKode = New System.Windows.Forms.TextBox()
        Me.TxtBarang = New System.Windows.Forms.TextBox()
        Me.TxtStok = New System.Windows.Forms.TextBox()
        Me.TxtHarga = New System.Windows.Forms.TextBox()
        Me.DgvBarang = New System.Windows.Forms.DataGridView()
        Me.BtnUbah = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtPromosi = New System.Windows.Forms.TextBox()
        Me.txtHargaNet = New System.Windows.Forms.TextBox()
        CType(Me.DgvBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KodeBarang
        '
        Me.KodeBarang.AutoSize = True
        Me.KodeBarang.Location = New System.Drawing.Point(125, 52)
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.Size = New System.Drawing.Size(102, 20)
        Me.KodeBarang.TabIndex = 0
        Me.KodeBarang.Text = "Kode Barang"
        '
        'NamaBarang
        '
        Me.NamaBarang.AutoSize = True
        Me.NamaBarang.Location = New System.Drawing.Point(125, 105)
        Me.NamaBarang.Name = "NamaBarang"
        Me.NamaBarang.Size = New System.Drawing.Size(107, 20)
        Me.NamaBarang.TabIndex = 1
        Me.NamaBarang.Text = "Nama Barang"
        '
        'StokAwal
        '
        Me.StokAwal.AutoSize = True
        Me.StokAwal.Location = New System.Drawing.Point(125, 158)
        Me.StokAwal.Name = "StokAwal"
        Me.StokAwal.Size = New System.Drawing.Size(80, 20)
        Me.StokAwal.TabIndex = 2
        Me.StokAwal.Text = "Stok Awal"
        '
        'HargaJual
        '
        Me.HargaJual.AutoSize = True
        Me.HargaJual.Location = New System.Drawing.Point(125, 217)
        Me.HargaJual.Name = "HargaJual"
        Me.HargaJual.Size = New System.Drawing.Size(86, 20)
        Me.HargaJual.TabIndex = 3
        Me.HargaJual.Text = "Harga Jual"
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(115, 294)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(156, 40)
        Me.BtnSimpan.TabIndex = 4
        Me.BtnSimpan.Text = "Simpan Data"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'TxtKode
        '
        Me.TxtKode.Location = New System.Drawing.Point(296, 52)
        Me.TxtKode.Name = "TxtKode"
        Me.TxtKode.Size = New System.Drawing.Size(257, 26)
        Me.TxtKode.TabIndex = 5
        '
        'TxtBarang
        '
        Me.TxtBarang.Location = New System.Drawing.Point(296, 102)
        Me.TxtBarang.Name = "TxtBarang"
        Me.TxtBarang.Size = New System.Drawing.Size(257, 26)
        Me.TxtBarang.TabIndex = 6
        '
        'TxtStok
        '
        Me.TxtStok.Location = New System.Drawing.Point(296, 158)
        Me.TxtStok.Name = "TxtStok"
        Me.TxtStok.Size = New System.Drawing.Size(257, 26)
        Me.TxtStok.TabIndex = 7
        '
        'TxtHarga
        '
        Me.TxtHarga.Location = New System.Drawing.Point(296, 217)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Size = New System.Drawing.Size(257, 26)
        Me.TxtHarga.TabIndex = 8
        '
        'DgvBarang
        '
        Me.DgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBarang.Location = New System.Drawing.Point(115, 366)
        Me.DgvBarang.Name = "DgvBarang"
        Me.DgvBarang.RowHeadersWidth = 62
        Me.DgvBarang.RowTemplate.Height = 28
        Me.DgvBarang.Size = New System.Drawing.Size(938, 270)
        Me.DgvBarang.TabIndex = 9
        '
        'BtnUbah
        '
        Me.BtnUbah.Location = New System.Drawing.Point(309, 294)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(185, 40)
        Me.BtnUbah.TabIndex = 10
        Me.BtnUbah.Text = " Ubah Data"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(533, 294)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(190, 40)
        Me.BtnHapus.TabIndex = 11
        Me.BtnHapus.Text = "Hapus Data"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnRefresh
        '
        Me.BtnRefresh.ImageIndex = 0
        Me.BtnRefresh.ImageList = Me.ImageList1
        Me.BtnRefresh.Location = New System.Drawing.Point(742, 294)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(44, 40)
        Me.BtnRefresh.TabIndex = 12
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "—Pngtree—reload vector icon_4015267.png")
        '
        'txtPromosi
        '
        Me.txtPromosi.Location = New System.Drawing.Point(296, 250)
        Me.txtPromosi.Name = "txtPromosi"
        Me.txtPromosi.Size = New System.Drawing.Size(94, 26)
        Me.txtPromosi.TabIndex = 13
        '
        'txtHargaNet
        '
        Me.txtHargaNet.Location = New System.Drawing.Point(409, 250)
        Me.txtHargaNet.Name = "txtHargaNet"
        Me.txtHargaNet.Size = New System.Drawing.Size(144, 26)
        Me.txtHargaNet.TabIndex = 14
        '
        'FormBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 642)
        Me.Controls.Add(Me.txtHargaNet)
        Me.Controls.Add(Me.txtPromosi)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.BtnUbah)
        Me.Controls.Add(Me.DgvBarang)
        Me.Controls.Add(Me.TxtHarga)
        Me.Controls.Add(Me.TxtStok)
        Me.Controls.Add(Me.TxtBarang)
        Me.Controls.Add(Me.TxtKode)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.HargaJual)
        Me.Controls.Add(Me.StokAwal)
        Me.Controls.Add(Me.NamaBarang)
        Me.Controls.Add(Me.KodeBarang)
        Me.Name = "FormBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manajemen Inventaris Gudang"
        CType(Me.DgvBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KodeBarang As Label
    Friend WithEvents NamaBarang As Label
    Friend WithEvents StokAwal As Label
    Friend WithEvents HargaJual As Label
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents TxtKode As TextBox
    Friend WithEvents TxtBarang As TextBox
    Friend WithEvents TxtStok As TextBox
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents DgvBarang As DataGridView
    Friend WithEvents BtnUbah As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents txtPromosi As TextBox
    Friend WithEvents txtHargaNet As TextBox
End Class
