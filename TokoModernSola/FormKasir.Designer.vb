<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKasir
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKasir))
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.txtCariKode = New System.Windows.Forms.TextBox()
        Me.txtNamaBarang = New System.Windows.Forms.TextBox()
        Me.txtHarga = New System.Windows.Forms.TextBox()
        Me.txtJumlah = New System.Windows.Forms.TextBox()
        Me.btnTambah = New System.Windows.Forms.Button()
        Me.dgvKeranjang = New System.Windows.Forms.DataGridView()
        Me.txtBayar = New System.Windows.Forms.TextBox()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.lblKembali = New System.Windows.Forms.Label()
        Me.btnSimpanTransaksi = New System.Windows.Forms.Button()
        Me.btnEditKeranjang = New System.Windows.Forms.Button()
        Me.ImgTrashEdit = New System.Windows.Forms.ImageList(Me.components)
        Me.btnHapusKeranjang = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNavBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNavPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNavLaporan = New System.Windows.Forms.ToolStripMenuItem()
        Me.colKode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colJumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvKeranjang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNota
        '
        Me.txtNota.Enabled = False
        Me.txtNota.Location = New System.Drawing.Point(9, 81)
        Me.txtNota.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(285, 59)
        Me.txtNota.TabIndex = 0
        '
        'txtCariKode
        '
        Me.txtCariKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCariKode.Font = New System.Drawing.Font("MV Boli", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCariKode.Location = New System.Drawing.Point(9, 159)
        Me.txtCariKode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCariKode.Multiline = True
        Me.txtCariKode.Name = "txtCariKode"
        Me.txtCariKode.Size = New System.Drawing.Size(176, 92)
        Me.txtCariKode.TabIndex = 1
        '
        'txtNamaBarang
        '
        Me.txtNamaBarang.Enabled = False
        Me.txtNamaBarang.Font = New System.Drawing.Font("MV Boli", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaBarang.Location = New System.Drawing.Point(9, 300)
        Me.txtNamaBarang.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNamaBarang.Multiline = True
        Me.txtNamaBarang.Name = "txtNamaBarang"
        Me.txtNamaBarang.Size = New System.Drawing.Size(284, 83)
        Me.txtNamaBarang.TabIndex = 2
        '
        'txtHarga
        '
        Me.txtHarga.Enabled = False
        Me.txtHarga.Font = New System.Drawing.Font("MV Boli", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarga.Location = New System.Drawing.Point(9, 410)
        Me.txtHarga.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHarga.Multiline = True
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(285, 83)
        Me.txtHarga.TabIndex = 3
        '
        'txtJumlah
        '
        Me.txtJumlah.Font = New System.Drawing.Font("MV Boli", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJumlah.Location = New System.Drawing.Point(217, 159)
        Me.txtJumlah.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtJumlah.Multiline = True
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Size = New System.Drawing.Size(76, 92)
        Me.txtJumlah.TabIndex = 4
        '
        'btnTambah
        '
        Me.btnTambah.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnTambah.Font = New System.Drawing.Font("MV Boli", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTambah.Location = New System.Drawing.Point(74, 548)
        Me.btnTambah.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(220, 124)
        Me.btnTambah.TabIndex = 5
        Me.btnTambah.Text = "Tambah ke Keranjang"
        Me.btnTambah.UseVisualStyleBackColor = False
        '
        'dgvKeranjang
        '
        Me.dgvKeranjang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKeranjang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colKode, Me.colNama, Me.colHarga, Me.colJumlah, Me.colSubTotal})
        Me.dgvKeranjang.Location = New System.Drawing.Point(309, 81)
        Me.dgvKeranjang.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvKeranjang.Name = "dgvKeranjang"
        Me.dgvKeranjang.RowHeadersWidth = 62
        Me.dgvKeranjang.RowTemplate.Height = 28
        Me.dgvKeranjang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKeranjang.Size = New System.Drawing.Size(789, 770)
        Me.dgvKeranjang.TabIndex = 6
        '
        'txtBayar
        '
        Me.txtBayar.Font = New System.Drawing.Font("MV Boli", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBayar.Location = New System.Drawing.Point(1113, 238)
        Me.txtBayar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBayar.Multiline = True
        Me.txtBayar.Name = "txtBayar"
        Me.txtBayar.Size = New System.Drawing.Size(359, 92)
        Me.txtBayar.TabIndex = 7
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("MV Boli", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.Location = New System.Drawing.Point(1105, 170)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(103, 45)
        Me.lblGrandTotal.TabIndex = 8
        Me.lblGrandTotal.Text = "Rp.0"
        '
        'lblKembali
        '
        Me.lblKembali.AutoSize = True
        Me.lblKembali.Font = New System.Drawing.Font("MV Boli", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKembali.Location = New System.Drawing.Point(1105, 349)
        Me.lblKembali.Name = "lblKembali"
        Me.lblKembali.Size = New System.Drawing.Size(99, 45)
        Me.lblKembali.TabIndex = 9
        Me.lblKembali.Text = "Rp.0"
        '
        'btnSimpanTransaksi
        '
        Me.btnSimpanTransaksi.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnSimpanTransaksi.Font = New System.Drawing.Font("MV Boli", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSimpanTransaksi.Location = New System.Drawing.Point(1113, 415)
        Me.btnSimpanTransaksi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSimpanTransaksi.Name = "btnSimpanTransaksi"
        Me.btnSimpanTransaksi.Size = New System.Drawing.Size(253, 59)
        Me.btnSimpanTransaksi.TabIndex = 10
        Me.btnSimpanTransaksi.Text = "Cetak Nota"
        Me.btnSimpanTransaksi.UseVisualStyleBackColor = False
        '
        'btnEditKeranjang
        '
        Me.btnEditKeranjang.ImageIndex = 1
        Me.btnEditKeranjang.ImageList = Me.ImgTrashEdit
        Me.btnEditKeranjang.Location = New System.Drawing.Point(1108, 81)
        Me.btnEditKeranjang.Name = "btnEditKeranjang"
        Me.btnEditKeranjang.Size = New System.Drawing.Size(39, 35)
        Me.btnEditKeranjang.TabIndex = 11
        Me.btnEditKeranjang.UseVisualStyleBackColor = True
        '
        'ImgTrashEdit
        '
        Me.ImgTrashEdit.ImageStream = CType(resources.GetObject("ImgTrashEdit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgTrashEdit.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgTrashEdit.Images.SetKeyName(0, "trash.png")
        Me.ImgTrashEdit.Images.SetKeyName(1, "edit.png")
        '
        'btnHapusKeranjang
        '
        Me.btnHapusKeranjang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHapusKeranjang.ImageIndex = 0
        Me.btnHapusKeranjang.ImageList = Me.ImgTrashEdit
        Me.btnHapusKeranjang.Location = New System.Drawing.Point(1153, 81)
        Me.btnHapusKeranjang.Name = "btnHapusKeranjang"
        Me.btnHapusKeranjang.Size = New System.Drawing.Size(42, 35)
        Me.btnHapusKeranjang.TabIndex = 12
        Me.btnHapusKeranjang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHapusKeranjang.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNavBarang, Me.btnNavPos, Me.btnNavLaporan})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1478, 28)
        Me.MenuStrip1.TabIndex = 13
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
        'colKode
        '
        Me.colKode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colKode.Frozen = True
        Me.colKode.HeaderText = "Kode Barang"
        Me.colKode.MinimumWidth = 30
        Me.colKode.Name = "colKode"
        Me.colKode.Width = 120
        '
        'colNama
        '
        Me.colNama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNama.HeaderText = "Nama Barang"
        Me.colNama.MinimumWidth = 30
        Me.colNama.Name = "colNama"
        '
        'colHarga
        '
        Me.colHarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colHarga.HeaderText = "Harga Barang"
        Me.colHarga.MinimumWidth = 30
        Me.colHarga.Name = "colHarga"
        Me.colHarga.Width = 126
        '
        'colJumlah
        '
        Me.colJumlah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colJumlah.HeaderText = "Jumlah"
        Me.colJumlah.MinimumWidth = 30
        Me.colJumlah.Name = "colJumlah"
        Me.colJumlah.Width = 82
        '
        'colSubTotal
        '
        Me.colSubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSubTotal.HeaderText = "SubTotal"
        Me.colSubTotal.MinimumWidth = 30
        Me.colSubTotal.Name = "colSubTotal"
        '
        'FormKasir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1478, 909)
        Me.Controls.Add(Me.btnHapusKeranjang)
        Me.Controls.Add(Me.btnEditKeranjang)
        Me.Controls.Add(Me.btnSimpanTransaksi)
        Me.Controls.Add(Me.lblKembali)
        Me.Controls.Add(Me.lblGrandTotal)
        Me.Controls.Add(Me.txtBayar)
        Me.Controls.Add(Me.dgvKeranjang)
        Me.Controls.Add(Me.btnTambah)
        Me.Controls.Add(Me.txtJumlah)
        Me.Controls.Add(Me.txtHarga)
        Me.Controls.Add(Me.txtNamaBarang)
        Me.Controls.Add(Me.txtCariKode)
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormKasir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Point Of Sales Cashier V1.0"
        CType(Me.dgvKeranjang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNota As TextBox
    Friend WithEvents txtCariKode As TextBox
    Friend WithEvents txtNamaBarang As TextBox
    Friend WithEvents txtHarga As TextBox
    Friend WithEvents txtJumlah As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents dgvKeranjang As DataGridView
    Friend WithEvents txtBayar As TextBox
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents lblKembali As Label
    Friend WithEvents btnSimpanTransaksi As Button
    Friend WithEvents btnEditKeranjang As Button
    Friend WithEvents ImgTrashEdit As ImageList
    Friend WithEvents btnHapusKeranjang As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNavBarang As ToolStripMenuItem
    Friend WithEvents btnNavPos As ToolStripMenuItem
    Friend WithEvents btnNavLaporan As ToolStripMenuItem
    Friend WithEvents colKode As DataGridViewTextBoxColumn
    Friend WithEvents colNama As DataGridViewTextBoxColumn
    Friend WithEvents colHarga As DataGridViewTextBoxColumn
    Friend WithEvents colJumlah As DataGridViewTextBoxColumn
    Friend WithEvents colSubTotal As DataGridViewTextBoxColumn
End Class
