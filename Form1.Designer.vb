<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        pnlSidebar = New Panel()
        lblLineSpacing = New Label()
        numLineSpacing = New NumericUpDown()
        lblAlignment = New Label()
        cmbAlignment = New ComboBox()
        chkTransparentBg = New CheckBox()
        chkHorizontal = New CheckBox()
        chkEnableKeyer = New CheckBox()
        btnBgColor = New Button()
        btnTextColor = New Button()
        btnFont = New Button()
        lblTextStyle = New Label()
        txtScrollText = New TextBox()
        lblScrollText = New Label()
        btnLoadFile = New Button()
        numSpeed = New NumericUpDown()
        lblSpeed = New Label()
        cmbMode = New ComboBox()
        lblMode = New Label()
        cmbDevice = New ComboBox()
        lblDevice = New Label()
        btnStop = New Button()
        btnPause = New Button()
        btnStart = New Button()
        pnlPreview = New Panel()
        lblStatus = New Label()
        picPreview = New PictureBox()
        pnlSidebar.SuspendLayout()
        CType(numLineSpacing, ComponentModel.ISupportInitialize).BeginInit()
        CType(numSpeed, ComponentModel.ISupportInitialize).BeginInit()
        pnlPreview.SuspendLayout()
        CType(picPreview, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        pnlSidebar.Controls.Add(lblLineSpacing)
        pnlSidebar.Controls.Add(numLineSpacing)
        pnlSidebar.Controls.Add(lblAlignment)
        pnlSidebar.Controls.Add(cmbAlignment)
        pnlSidebar.Controls.Add(chkTransparentBg)
        pnlSidebar.Controls.Add(chkHorizontal)
        pnlSidebar.Controls.Add(chkEnableKeyer)
        pnlSidebar.Controls.Add(btnBgColor)
        pnlSidebar.Controls.Add(btnTextColor)
        pnlSidebar.Controls.Add(btnFont)
        pnlSidebar.Controls.Add(lblTextStyle)
        pnlSidebar.Controls.Add(txtScrollText)
        pnlSidebar.Controls.Add(lblScrollText)
        pnlSidebar.Controls.Add(btnLoadFile)
        pnlSidebar.Controls.Add(numSpeed)
        pnlSidebar.Controls.Add(lblSpeed)
        pnlSidebar.Controls.Add(cmbMode)
        pnlSidebar.Controls.Add(lblMode)
        pnlSidebar.Controls.Add(cmbDevice)
        pnlSidebar.Controls.Add(lblDevice)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(350, 490)
        pnlSidebar.TabIndex = 0
        ' 
        ' lblLineSpacing
        ' 
        lblLineSpacing.AutoSize = True
        lblLineSpacing.Font = New Font("Segoe UI", 9.0F)
        lblLineSpacing.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        lblLineSpacing.Location = New Point(175, 105)
        lblLineSpacing.Name = "lblLineSpacing"
        lblLineSpacing.Size = New Size(77, 15)
        lblLineSpacing.TabIndex = 21
        lblLineSpacing.Text = "Line Spacing:"
        ' 
        ' numLineSpacing
        ' 
        numLineSpacing.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        numLineSpacing.BorderStyle = BorderStyle.FixedSingle
        numLineSpacing.DecimalPlaces = 1
        numLineSpacing.Font = New Font("Segoe UI", 9.0F)
        numLineSpacing.ForeColor = Color.White
        numLineSpacing.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        numLineSpacing.Location = New Point(260, 103)
        numLineSpacing.Maximum = New Decimal(New Integer() {50, 0, 0, 65536})
        numLineSpacing.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        numLineSpacing.Name = "numLineSpacing"
        numLineSpacing.Size = New Size(60, 23)
        numLineSpacing.TabIndex = 22
        numLineSpacing.Value = New Decimal(New Integer() {13, 0, 0, 65536})
        ' 
        ' lblAlignment
        ' 
        lblAlignment.AutoSize = True
        lblAlignment.Font = New Font("Segoe UI", 9.0F)
        lblAlignment.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        lblAlignment.Location = New Point(185, 216)
        lblAlignment.Name = "lblAlignment"
        lblAlignment.Size = New Size(38, 15)
        lblAlignment.TabIndex = 19
        lblAlignment.Text = "Align:"
        ' 
        ' cmbAlignment
        ' 
        cmbAlignment.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        cmbAlignment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAlignment.FlatStyle = FlatStyle.Flat
        cmbAlignment.Font = New Font("Segoe UI", 8.5F)
        cmbAlignment.ForeColor = Color.White
        cmbAlignment.FormattingEnabled = True
        cmbAlignment.Items.AddRange(New Object() {"Left", "Center", "Right"})
        cmbAlignment.Location = New Point(225, 213)
        cmbAlignment.Name = "cmbAlignment"
        cmbAlignment.Size = New Size(105, 21)
        cmbAlignment.TabIndex = 20
        ' 
        ' chkTransparentBg
        ' 
        chkTransparentBg.AutoSize = True
        chkTransparentBg.Font = New Font("Segoe UI", 9.0F)
        chkTransparentBg.ForeColor = Color.White
        chkTransparentBg.Location = New Point(20, 215)
        chkTransparentBg.Name = "chkTransparentBg"
        chkTransparentBg.Size = New Size(155, 19)
        chkTransparentBg.TabIndex = 18
        chkTransparentBg.Text = "Transparent Background"
        chkTransparentBg.UseVisualStyleBackColor = True
        ' 
        ' chkHorizontal
        ' 
        chkHorizontal.AutoSize = True
        chkHorizontal.Font = New Font("Segoe UI", 9.0F)
        chkHorizontal.ForeColor = Color.White
        chkHorizontal.Location = New Point(20, 240)
        chkHorizontal.Name = "chkHorizontal"
        chkHorizontal.Size = New Size(115, 19)
        chkHorizontal.TabIndex = 24
        chkHorizontal.Text = "Horizontal Scroll"
        chkHorizontal.UseVisualStyleBackColor = True
        ' 
        ' chkEnableKeyer
        ' 
        chkEnableKeyer.AutoSize = True
        chkEnableKeyer.Font = New Font("Segoe UI", 9.0F)
        chkEnableKeyer.ForeColor = Color.White
        chkEnableKeyer.Location = New Point(180, 240)
        chkEnableKeyer.Name = "chkEnableKeyer"
        chkEnableKeyer.Size = New Size(150, 19)
        chkEnableKeyer.TabIndex = 25
        chkEnableKeyer.Text = "Hardware Keying"
        chkEnableKeyer.UseVisualStyleBackColor = True
        ' 
        ' btnBgColor
        ' 
        btnBgColor.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        btnBgColor.FlatAppearance.BorderColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        btnBgColor.FlatStyle = FlatStyle.Flat
        btnBgColor.Font = New Font("Segoe UI", 8.5F)
        btnBgColor.ForeColor = Color.White
        btnBgColor.Location = New Point(230, 165)
        btnBgColor.Name = "btnBgColor"
        btnBgColor.Size = New Size(100, 30)
        btnBgColor.TabIndex = 10
        btnBgColor.Text = "Background..."
        btnBgColor.UseVisualStyleBackColor = False
        ' 
        ' btnTextColor
        ' 
        btnTextColor.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        btnTextColor.FlatAppearance.BorderColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        btnTextColor.FlatStyle = FlatStyle.Flat
        btnTextColor.Font = New Font("Segoe UI", 8.5F)
        btnTextColor.ForeColor = Color.White
        btnTextColor.Location = New Point(125, 165)
        btnTextColor.Name = "btnTextColor"
        btnTextColor.Size = New Size(100, 30)
        btnTextColor.TabIndex = 9
        btnTextColor.Text = "Text Color..."
        btnTextColor.UseVisualStyleBackColor = False
        ' 
        ' btnFont
        ' 
        btnFont.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        btnFont.FlatAppearance.BorderColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        btnFont.FlatStyle = FlatStyle.Flat
        btnFont.Font = New Font("Segoe UI", 8.5F)
        btnFont.ForeColor = Color.White
        btnFont.Location = New Point(20, 165)
        btnFont.Name = "btnFont"
        btnFont.Size = New Size(100, 30)
        btnFont.TabIndex = 8
        btnFont.Text = "Font Select..."
        btnFont.UseVisualStyleBackColor = False
        ' 
        ' lblTextStyle
        ' 
        lblTextStyle.AutoSize = True
        lblTextStyle.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblTextStyle.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        lblTextStyle.Location = New Point(20, 145)
        lblTextStyle.Name = "lblTextStyle"
        lblTextStyle.Size = New Size(129, 15)
        lblTextStyle.TabIndex = 7
        lblTextStyle.Text = "FONT AND COLORING"
        ' 
        ' txtScrollText
        ' 
        txtScrollText.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        txtScrollText.BorderStyle = BorderStyle.FixedSingle
        txtScrollText.Font = New Font("Consolas", 10.0F)
        txtScrollText.ForeColor = Color.White
        txtScrollText.Location = New Point(20, 350)
        txtScrollText.Multiline = True
        txtScrollText.Name = "txtScrollText"
        txtScrollText.ScrollBars = ScrollBars.Vertical
        txtScrollText.Size = New Size(310, 130)
        txtScrollText.TabIndex = 13
        txtScrollText.Text = resources.GetString("txtScrollText.Text")
        ' 
        ' lblScrollText
        ' 
        lblScrollText.AutoSize = True
        lblScrollText.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblScrollText.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        lblScrollText.Location = New Point(20, 330)
        lblScrollText.Name = "lblScrollText"
        lblScrollText.Size = New Size(84, 15)
        lblScrollText.TabIndex = 14
        lblScrollText.Text = "CREDITS TEXT"
        ' 
        ' btnLoadFile
        ' 
        btnLoadFile.BackColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        btnLoadFile.FlatAppearance.BorderSize = 0
        btnLoadFile.FlatStyle = FlatStyle.Flat
        btnLoadFile.Font = New Font("Segoe UI", 9.0F)
        btnLoadFile.ForeColor = Color.White
        btnLoadFile.Location = New Point(20, 290)
        btnLoadFile.Name = "btnLoadFile"
        btnLoadFile.Size = New Size(310, 30)
        btnLoadFile.TabIndex = 15
        btnLoadFile.Text = "Load Text File..."
        btnLoadFile.UseVisualStyleBackColor = False
        ' 
        ' numSpeed
        ' 
        numSpeed.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        numSpeed.BorderStyle = BorderStyle.FixedSingle
        numSpeed.Font = New Font("Segoe UI", 9.0F)
        numSpeed.ForeColor = Color.White
        numSpeed.Location = New Point(100, 103)
        numSpeed.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        numSpeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numSpeed.Name = "numSpeed"
        numSpeed.Size = New Size(60, 23)
        numSpeed.TabIndex = 6
        numSpeed.Value = New Decimal(New Integer() {2, 0, 0, 0})
        ' 
        ' lblSpeed
        ' 
        lblSpeed.AutoSize = True
        lblSpeed.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblSpeed.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        lblSpeed.Location = New Point(20, 105)
        lblSpeed.Name = "lblSpeed"
        lblSpeed.Size = New Size(76, 15)
        lblSpeed.TabIndex = 5
        lblSpeed.Text = "Scroll Speed:"
        ' 
        ' cmbMode
        ' 
        cmbMode.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        cmbMode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMode.FlatStyle = FlatStyle.Flat
        cmbMode.Font = New Font("Segoe UI", 9.5F)
        cmbMode.ForeColor = Color.White
        cmbMode.FormattingEnabled = True
        cmbMode.Location = New Point(140, 60)
        cmbMode.Name = "cmbMode"
        cmbMode.Size = New Size(190, 25)
        cmbMode.TabIndex = 4
        ' 
        ' lblMode
        ' 
        lblMode.AutoSize = True
        lblMode.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblMode.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        lblMode.Location = New Point(20, 65)
        lblMode.Name = "lblMode"
        lblMode.Size = New Size(103, 15)
        lblMode.TabIndex = 3
        lblMode.Text = "OUTPUT FORMAT"
        ' 
        ' cmbDevice
        ' 
        cmbDevice.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        cmbDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDevice.FlatStyle = FlatStyle.Flat
        cmbDevice.Font = New Font("Segoe UI", 9.5F)
        cmbDevice.ForeColor = Color.White
        cmbDevice.FormattingEnabled = True
        cmbDevice.Location = New Point(140, 20)
        cmbDevice.Name = "cmbDevice"
        cmbDevice.Size = New Size(190, 25)
        cmbDevice.TabIndex = 2
        ' 
        ' lblDevice
        ' 
        lblDevice.AutoSize = True
        lblDevice.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblDevice.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        lblDevice.Location = New Point(20, 25)
        lblDevice.Name = "lblDevice"
        lblDevice.Size = New Size(105, 15)
        lblDevice.TabIndex = 1
        lblDevice.Text = "DECKLINK DEVICE"
        ' 
        ' btnStop
        ' 
        btnStop.Location = New Point(398, 375)
        btnStop.Name = "btnStop"
        btnStop.Size = New Size(95, 45)
        btnStop.TabIndex = 12
        btnStop.Text = "STOP"
        btnStop.UseVisualStyleBackColor = False
        ' 
        ' btnPause
        ' 
        btnPause.BackColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        btnPause.FlatAppearance.BorderSize = 0
        btnPause.FlatStyle = FlatStyle.Flat
        btnPause.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnPause.ForeColor = Color.White
        btnPause.Location = New Point(278, 375)
        btnPause.Name = "btnPause"
        btnPause.Size = New Size(100, 45)
        btnPause.TabIndex = 17
        btnPause.Text = "PAUSE"
        btnPause.UseVisualStyleBackColor = False
        ' 
        ' btnStart
        ' 
        btnStart.BackColor = Color.FromArgb(CByte(40), CByte(150), CByte(80))
        btnStart.FlatAppearance.BorderSize = 0
        btnStart.FlatStyle = FlatStyle.Flat
        btnStart.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnStart.ForeColor = Color.White
        btnStart.Location = New Point(163, 375)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(95, 45)
        btnStart.TabIndex = 11
        btnStart.Text = "START"
        btnStart.UseVisualStyleBackColor = False
        ' 
        ' pnlPreview
        ' 
        pnlPreview.BackColor = Color.FromArgb(CByte(20), CByte(20), CByte(20))
        pnlPreview.Controls.Add(btnStart)
        pnlPreview.Controls.Add(btnPause)
        pnlPreview.Controls.Add(btnStop)
        pnlPreview.Controls.Add(lblStatus)
        pnlPreview.Controls.Add(picPreview)
        pnlPreview.Dock = DockStyle.Fill
        pnlPreview.Location = New Point(350, 0)
        pnlPreview.Name = "pnlPreview"
        pnlPreview.Size = New Size(641, 470)
        pnlPreview.TabIndex = 1
        ' 
        ' lblStatus
        ' 
        lblStatus.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblStatus.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        lblStatus.ForeColor = Color.Gold
        lblStatus.Location = New Point(32, 437)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(592, 25)
        lblStatus.TabIndex = 2
        lblStatus.Text = "Status: Ready"
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picPreview
        ' 
        picPreview.BackColor = Color.Black
        picPreview.BorderStyle = BorderStyle.FixedSingle
        picPreview.Location = New Point(32, 20)
        picPreview.Name = "picPreview"
        picPreview.Size = New Size(592, 333)
        picPreview.SizeMode = PictureBoxSizeMode.Zoom
        picPreview.TabIndex = 0
        picPreview.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(28), CByte(28), CByte(28))
        ClientSize = New Size(991, 470)
        Controls.Add(pnlPreview)
        Controls.Add(pnlSidebar)
        ForeColor = Color.White
        MaximumSize = New Size(1007, 550)
        MinimumSize = New Size(1007, 550)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "DeckLink Vertical Scroll Player"
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        CType(numLineSpacing, ComponentModel.ISupportInitialize).EndInit()
        CType(numSpeed, ComponentModel.ISupportInitialize).EndInit()
        pnlPreview.ResumeLayout(False)
        CType(picPreview, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblDevice As Label
    Friend WithEvents cmbDevice As ComboBox
    Friend WithEvents cmbMode As ComboBox
    Friend WithEvents lblMode As Label
    Friend WithEvents lblSpeed As Label
    Friend WithEvents numSpeed As NumericUpDown
    Friend WithEvents lblTextStyle As Label
    Friend WithEvents btnFont As Button
    Friend WithEvents btnTextColor As Button
    Friend WithEvents btnBgColor As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents btnPause As Button
    Friend WithEvents txtScrollText As TextBox
    Friend WithEvents lblScrollText As Label
    Friend WithEvents btnLoadFile As Button
    Friend WithEvents pnlPreview As Panel
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents lblStatus As Label

    Friend WithEvents chkTransparentBg As CheckBox
    Friend WithEvents lblAlignment As Label
    Friend WithEvents cmbAlignment As ComboBox
    Friend WithEvents lblLineSpacing As Label
    Friend WithEvents numLineSpacing As NumericUpDown
    Friend WithEvents chkHorizontal As CheckBox
    Friend WithEvents chkEnableKeyer As CheckBox
End Class
'
