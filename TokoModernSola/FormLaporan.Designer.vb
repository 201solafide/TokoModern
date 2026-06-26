<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaporan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLaporan))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvMaster = New System.Windows.Forms.DataGridView()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCetakText = New System.Windows.Forms.Button()
        Me.imgPrint = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNavBarang = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNavPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNavLaporan = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MV Boli", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(97, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(405, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Riwayat Nota Penjualan"
        '
        'dgvMaster
        '
        Me.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaster.Location = New System.Drawing.Point(105, 121)
        Me.dgvMaster.Name = "dgvMaster"
        Me.dgvMaster.ReadOnly = True
        Me.dgvMaster.RowHeadersWidth = 51
        Me.dgvMaster.RowTemplate.Height = 24
        Me.dgvMaster.Size = New System.Drawing.Size(1184, 284)
        Me.dgvMaster.TabIndex = 1
        '
        'dgvDetail
        '
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(105, 483)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersWidth = 51
        Me.dgvDetail.RowTemplate.Height = 24
        Me.dgvDetail.Size = New System.Drawing.Size(1184, 296)
        Me.dgvDetail.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MV Boli", 20.0!)
        Me.Label2.Location = New System.Drawing.Point(97, 426)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(426, 45)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Detail Barang Yang Dibeli"
        '
        'btnCetakText
        '
        Me.btnCetakText.ImageIndex = 0
        Me.btnCetakText.ImageList = Me.imgPrint
        Me.btnCetakText.Location = New System.Drawing.Point(1359, 12)
        Me.btnCetakText.Name = "btnCetakText"
        Me.btnCetakText.Size = New System.Drawing.Size(75, 71)
        Me.btnCetakText.TabIndex = 4
        Me.btnCetakText.UseVisualStyleBackColor = True
        '
        'imgPrint
        '
        Me.imgPrint.ImageStream = CType(resources.GetObject("imgPrint.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgPrint.TransparentColor = System.Drawing.Color.Transparent
        Me.imgPrint.Images.SetKeyName(0, "printer.png")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNavBarang, Me.btnNavPos, Me.btnNavLaporan})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1460, 28)
        Me.MenuStrip1.TabIndex = 5
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
        'FormLaporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1460, 770)
        Me.Controls.Add(Me.btnCetakText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.dgvMaster)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormLaporan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan & Riwayat Transaksi Penjualan"
        CType(Me.dgvMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvMaster As DataGridView
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCetakText As Button
    Friend WithEvents imgPrint As ImageList
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnNavBarang As ToolStripMenuItem
    Friend WithEvents btnNavPos As ToolStripMenuItem
    Friend WithEvents btnNavLaporan As ToolStripMenuItem
End Class
