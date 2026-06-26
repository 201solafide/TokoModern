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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNavBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNavPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNavLaporan = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DgvBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KodeBarang
        '
        Me.KodeBarang.AutoSize = True
        Me.KodeBarang.Location = New System.Drawing.Point(111, 42)
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.Size = New System.Drawing.Size(91, 17)
        Me.KodeBarang.TabIndex = 0
        Me.KodeBarang.Text = "Kode Barang"
        '
        'NamaBarang
        '
        Me.NamaBarang.AutoSize = True
        Me.NamaBarang.Location = New System.Drawing.Point(111, 84)
        Me.NamaBarang.Name = "NamaBarang"
        Me.NamaBarang.Size = New System.Drawing.Size(95, 17)
        Me.NamaBarang.TabIndex = 1
        Me.NamaBarang.Text = "Nama Barang"
        '
        'StokAwal
        '
        Me.StokAwal.AutoSize = True
        Me.StokAwal.Location = New System.Drawing.Point(111, 126)
        Me.StokAwal.Name = "StokAwal"
        Me.StokAwal.Size = New System.Drawing.Size(69, 17)
        Me.StokAwal.TabIndex = 2
        Me.StokAwal.Text = "Stok Awal"
        '
        'HargaJual
        '
        Me.HargaJual.AutoSize = True
        Me.HargaJual.Location = New System.Drawing.Point(111, 174)
        Me.HargaJual.Name = "HargaJual"
        Me.HargaJual.Size = New System.Drawing.Size(77, 17)
        Me.HargaJual.TabIndex = 3
        Me.HargaJual.Text = "Harga Jual"
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(102, 235)
        Me.BtnSimpan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(139, 32)
        Me.BtnSimpan.TabIndex = 4
        Me.BtnSimpan.Text = "Simpan Data"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'TxtKode
        '
        Me.TxtKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtKode.Location = New System.Drawing.Point(263, 42)
        Me.TxtKode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtKode.Name = "TxtKode"
        Me.TxtKode.Size = New System.Drawing.Size(229, 22)
        Me.TxtKode.TabIndex = 5
        '
        'TxtBarang
        '
        Me.TxtBarang.Location = New System.Drawing.Point(263, 82)
        Me.TxtBarang.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtBarang.Name = "TxtBarang"
        Me.TxtBarang.Size = New System.Drawing.Size(229, 22)
        Me.TxtBarang.TabIndex = 6
        '
        'TxtStok
        '
        Me.TxtStok.Location = New System.Drawing.Point(263, 126)
        Me.TxtStok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtStok.Name = "TxtStok"
        Me.TxtStok.Size = New System.Drawing.Size(229, 22)
        Me.TxtStok.TabIndex = 7
        '
        'TxtHarga
        '
        Me.TxtHarga.Location = New System.Drawing.Point(263, 174)
        Me.TxtHarga.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Size = New System.Drawing.Size(229, 22)
        Me.TxtHarga.TabIndex = 8
        '
        'DgvBarang
        '
        Me.DgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBarang.Location = New System.Drawing.Point(102, 293)
        Me.DgvBarang.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvBarang.Name = "DgvBarang"
        Me.DgvBarang.RowHeadersWidth = 62
        Me.DgvBarang.RowTemplate.Height = 28
        Me.DgvBarang.Size = New System.Drawing.Size(834, 216)
        Me.DgvBarang.TabIndex = 9
        '
        'BtnUbah
        '
        Me.BtnUbah.Location = New System.Drawing.Point(275, 235)
        Me.BtnUbah.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(164, 32)
        Me.BtnUbah.TabIndex = 10
        Me.BtnUbah.Text = " Ubah Data"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(474, 235)
        Me.BtnHapus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(169, 32)
        Me.BtnHapus.TabIndex = 11
        Me.BtnHapus.Text = "Hapus Data"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnRefresh
        '
        Me.BtnRefresh.ImageIndex = 0
        Me.BtnRefresh.ImageList = Me.ImageList1
        Me.BtnRefresh.Location = New System.Drawing.Point(660, 235)
        Me.BtnRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(39, 32)
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
        Me.txtPromosi.Location = New System.Drawing.Point(263, 200)
        Me.txtPromosi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPromosi.Name = "txtPromosi"
        Me.txtPromosi.Size = New System.Drawing.Size(84, 22)
        Me.txtPromosi.TabIndex = 13
        '
        'txtHargaNet
        '
        Me.txtHargaNet.Location = New System.Drawing.Point(364, 200)
        Me.txtHargaNet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHargaNet.Name = "txtHargaNet"
        Me.txtHargaNet.Size = New System.Drawing.Size(128, 22)
        Me.txtHargaNet.TabIndex = 14
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNavBarang, Me.btnNavPos, Me.btnNavLaporan})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(940, 28)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNavBarang
        '
        Me.btnNavBarang.Name = "btnNavBarang"
        Me.btnNavBarang.Size = New System.Drawing.Size(70, 24)
        Me.btnNavBarang.Text = "Barang"
        '
        'btnNavPos
        '
        Me.btnNavPos.Name = "btnNavPos"
        Me.btnNavPos.Size = New System.Drawing.Size(81, 24)
        Me.btnNavPos.Text = "Pos Kasir"
        '
        'btnNavLaporan
        '
        Me.btnNavLaporan.Name = "btnNavLaporan"
        Me.btnNavLaporan.Size = New System.Drawing.Size(77, 24)
        Me.btnNavLaporan.Text = "Laporan"
        '
        'FormBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 514)
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
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manajemen Inventaris Gudang"
        CType(Me.DgvBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNavBarang As ToolStripMenuItem
    Friend WithEvents btnNavPos As ToolStripMenuItem
    Friend WithEvents btnNavLaporan As ToolStripMenuItem
End Class
