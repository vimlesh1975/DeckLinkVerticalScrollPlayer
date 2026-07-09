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
        pnlSidebar = New Panel()
        chkTransparentBg = New CheckBox()
        chkEnableKeyer = New CheckBox()
        lblAlignment = New Label()
        cmbAlignment = New ComboBox()
        lblLineSpacing = New Label()
        numLineSpacing = New NumericUpDown()
        lblSpeedVal = New Label()
        btnLoadFile = New Button()
        lblScrollText = New Label()
        txtScrollText = New TextBox()
        btnStop = New Button()
        btnPause = New Button()
        btnStart = New Button()
        btnBgColor = New Button()
        btnTextColor = New Button()
        btnFont = New Button()
        lblTextStyle = New Label()
        tbSpeed = New TrackBar()
        lblSpeed = New Label()
        cmbMode = New ComboBox()
        lblMode = New Label()
        cmbDevice = New ComboBox()
        lblDevice = New Label()
        lblTitle = New Label()
        pnlPreview = New Panel()
        lblStatus = New Label()
        lblPreviewTitle = New Label()
        picPreview = New PictureBox()
        pnlSidebar.SuspendLayout()
        CType(tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(numLineSpacing, System.ComponentModel.ISupportInitialize).BeginInit()
        pnlPreview.SuspendLayout()
        CType(picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'pnlSidebar
        '
        pnlSidebar.BackColor = Color.FromArgb(30, 30, 30)
        pnlSidebar.Controls.Add(chkEnableKeyer)
        pnlSidebar.Controls.Add(lblLineSpacing)
        pnlSidebar.Controls.Add(numLineSpacing)
        pnlSidebar.Controls.Add(lblAlignment)
        pnlSidebar.Controls.Add(cmbAlignment)
        pnlSidebar.Controls.Add(chkTransparentBg)
        pnlSidebar.Controls.Add(lblSpeedVal)
        pnlSidebar.Controls.Add(btnLoadFile)
        pnlSidebar.Controls.Add(lblScrollText)
        pnlSidebar.Controls.Add(txtScrollText)
        pnlSidebar.Controls.Add(btnStop)
        pnlSidebar.Controls.Add(btnPause)
        pnlSidebar.Controls.Add(btnStart)
        pnlSidebar.Controls.Add(btnBgColor)
        pnlSidebar.Controls.Add(btnTextColor)
        pnlSidebar.Controls.Add(btnFont)
        pnlSidebar.Controls.Add(lblTextStyle)
        pnlSidebar.Controls.Add(tbSpeed)
        pnlSidebar.Controls.Add(lblSpeed)
        pnlSidebar.Controls.Add(cmbMode)
        pnlSidebar.Controls.Add(lblMode)
        pnlSidebar.Controls.Add(cmbDevice)
        pnlSidebar.Controls.Add(lblDevice)
        pnlSidebar.Controls.Add(lblTitle)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(350, 729)
        pnlSidebar.TabIndex = 0
        '
        'lblSpeedVal
        '
        lblSpeedVal.AutoSize = True
        lblSpeedVal.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        lblSpeedVal.ForeColor = Color.FromArgb(200, 200, 200)
        lblSpeedVal.Location = New Point(300, 255)
        lblSpeedVal.Name = "lblSpeedVal"
        lblSpeedVal.Size = New Size(35, 17)
        lblSpeedVal.TabIndex = 16
        lblSpeedVal.Text = "2 px"
        '
        'btnLoadFile
        '
        btnLoadFile.BackColor = Color.FromArgb(60, 60, 60)
        btnLoadFile.FlatAppearance.BorderSize = 0
        btnLoadFile.FlatStyle = FlatStyle.Flat
        btnLoadFile.Font = New Font("Segoe UI", 9.0F)
        btnLoadFile.ForeColor = Color.White
        btnLoadFile.Location = New Point(20, 515)
        btnLoadFile.Name = "btnLoadFile"
        btnLoadFile.Size = New Size(310, 30)
        btnLoadFile.TabIndex = 15
        btnLoadFile.Text = "Load Text File..."
        btnLoadFile.UseVisualStyleBackColor = False
        '
        'lblScrollText
        '
        lblScrollText.AutoSize = True
        lblScrollText.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblScrollText.ForeColor = Color.FromArgb(150, 150, 150)
        lblScrollText.Location = New Point(20, 555)
        lblScrollText.Name = "lblScrollText"
        lblScrollText.Size = New Size(81, 15)
        lblScrollText.TabIndex = 14
        lblScrollText.Text = "CREDITS TEXT"
        '
        'txtScrollText
        '
        txtScrollText.BackColor = Color.FromArgb(20, 20, 20)
        txtScrollText.BorderStyle = BorderStyle.FixedSingle
        txtScrollText.Font = New Font("Consolas", 10.0F)
        txtScrollText.ForeColor = Color.White
        txtScrollText.Location = New Point(20, 575)
        txtScrollText.Multiline = True
        txtScrollText.Name = "txtScrollText"
        txtScrollText.ScrollBars = ScrollBars.Vertical
        txtScrollText.Size = New Size(310, 130)
        txtScrollText.TabIndex = 13
        txtScrollText.Text = "CAST" & vbCrLf & "Director - John Doe" & vbCrLf & "Producer - Jane Smith" & vbCrLf & "Screenplay - Bob Johnson" & vbCrLf & vbCrLf & "STARRING" & vbCrLf & "Hero - Alice Brown" & vbCrLf & "Villain - Charlie Green" & vbCrLf & vbCrLf & "CREW" & vbCrLf & "Cinematography - Dave White" & vbCrLf & "Editing - Eva Black" & vbCrLf & vbCrLf & "Thank you for watching!"
        '
        'btnStop
        '
        btnStop.Location = New Point(235, 460)
        btnStop.Name = "btnStop"
        btnStop.Size = New Size(95, 45)
        btnStop.TabIndex = 12
        btnStop.Text = "STOP"
        btnStop.UseVisualStyleBackColor = False
        '
        'btnPause
        '
        btnPause.BackColor = Color.FromArgb(70, 70, 70)
        btnPause.FlatAppearance.BorderSize = 0
        btnPause.FlatStyle = FlatStyle.Flat
        btnPause.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnPause.ForeColor = Color.White
        btnPause.Location = New Point(125, 460)
        btnPause.Name = "btnPause"
        btnPause.Size = New Size(100, 45)
        btnPause.TabIndex = 17
        btnPause.Text = "PAUSE"
        btnPause.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        btnStart.BackColor = Color.FromArgb(40, 150, 80)
        btnStart.FlatAppearance.BorderSize = 0
        btnStart.FlatStyle = FlatStyle.Flat
        btnStart.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnStart.ForeColor = Color.White
        btnStart.Location = New Point(20, 460)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(95, 45)
        btnStart.TabIndex = 11
        btnStart.Text = "START"
        btnStart.UseVisualStyleBackColor = False
        '
        'chkTransparentBg
        '
        chkTransparentBg.AutoSize = True
        chkTransparentBg.Font = New Font("Segoe UI", 9.0F)
        chkTransparentBg.ForeColor = Color.White
        chkTransparentBg.Location = New Point(20, 428)
        chkTransparentBg.Name = "chkTransparentBg"
        chkTransparentBg.Size = New Size(160, 19)
        chkTransparentBg.TabIndex = 18
        chkTransparentBg.Text = "Transparent Background"
        chkTransparentBg.UseVisualStyleBackColor = True
        '
        'lblAlignment
        '
        lblAlignment.AutoSize = True
        lblAlignment.Font = New Font("Segoe UI", 9.0F)
        lblAlignment.ForeColor = Color.FromArgb(150, 150, 150)
        lblAlignment.Location = New Point(180, 428)
        lblAlignment.Name = "lblAlignment"
        lblAlignment.Size = New Size(41, 15)
        lblAlignment.TabIndex = 19
        lblAlignment.Text = "Align:"
        '
        'cmbAlignment
        '
        cmbAlignment.BackColor = Color.FromArgb(45, 45, 45)
        cmbAlignment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAlignment.FlatStyle = FlatStyle.Flat
        cmbAlignment.Font = New Font("Segoe UI", 8.5F)
        cmbAlignment.ForeColor = Color.White
        cmbAlignment.FormattingEnabled = True
        cmbAlignment.Items.AddRange(New Object() {"Left", "Center", "Right"})
        cmbAlignment.Location = New Point(225, 425)
        cmbAlignment.Name = "cmbAlignment"
        cmbAlignment.Size = New Size(105, 21)
        cmbAlignment.TabIndex = 20
        '
        'lblLineSpacing
        '
        lblLineSpacing.AutoSize = True
        lblLineSpacing.Font = New Font("Segoe UI", 9.0F)
        lblLineSpacing.ForeColor = Color.FromArgb(150, 150, 150)
        lblLineSpacing.Location = New Point(20, 395)
        lblLineSpacing.Name = "lblLineSpacing"
        lblLineSpacing.Size = New Size(77, 15)
        lblLineSpacing.TabIndex = 21
        lblLineSpacing.Text = "Line Spacing:"
        '
        'numLineSpacing
        '
        numLineSpacing.BackColor = Color.FromArgb(45, 45, 45)
        numLineSpacing.BorderStyle = BorderStyle.FixedSingle
        numLineSpacing.DecimalPlaces = 1
        numLineSpacing.Font = New Font("Segoe UI", 9.0F)
        numLineSpacing.ForeColor = Color.White
        numLineSpacing.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        numLineSpacing.Location = New Point(125, 392)
        numLineSpacing.Maximum = New Decimal(New Integer() {50, 0, 0, 65536})
        numLineSpacing.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        numLineSpacing.Name = "numLineSpacing"
        numLineSpacing.Size = New Size(65, 23)
        numLineSpacing.TabIndex = 22
        numLineSpacing.Value = New Decimal(New Integer() {13, 0, 0, 65536})
        '
        'chkEnableKeyer
        '
        chkEnableKeyer.AutoSize = True
        chkEnableKeyer.Font = New Font("Segoe UI", 9.0F)
        chkEnableKeyer.ForeColor = Color.White
        chkEnableKeyer.Location = New Point(200, 395)
        chkEnableKeyer.Name = "chkEnableKeyer"
        chkEnableKeyer.Size = New Size(100, 19)
        chkEnableKeyer.TabIndex = 23
        chkEnableKeyer.Text = "Fill/Key Output"
        chkEnableKeyer.UseVisualStyleBackColor = True
        '
        'btnBgColor
        '
        btnBgColor.BackColor = Color.FromArgb(50, 50, 50)
        btnBgColor.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100)
        btnBgColor.FlatStyle = FlatStyle.Flat
        btnBgColor.Font = New Font("Segoe UI", 8.5F)
        btnBgColor.ForeColor = Color.White
        btnBgColor.Location = New Point(230, 360)
        btnBgColor.Name = "btnBgColor"
        btnBgColor.Size = New Size(100, 30)
        btnBgColor.TabIndex = 10
        btnBgColor.Text = "Background..."
        btnBgColor.UseVisualStyleBackColor = False
        '
        'btnTextColor
        '
        btnTextColor.BackColor = Color.FromArgb(50, 50, 50)
        btnTextColor.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100)
        btnTextColor.FlatStyle = FlatStyle.Flat
        btnTextColor.Font = New Font("Segoe UI", 8.5F)
        btnTextColor.ForeColor = Color.White
        btnTextColor.Location = New Point(125, 360)
        btnTextColor.Name = "btnTextColor"
        btnTextColor.Size = New Size(100, 30)
        btnTextColor.TabIndex = 9
        btnTextColor.Text = "Text Color..."
        btnTextColor.UseVisualStyleBackColor = False
        '
        'btnFont
        '
        btnFont.BackColor = Color.FromArgb(50, 50, 50)
        btnFont.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100)
        btnFont.FlatStyle = FlatStyle.Flat
        btnFont.Font = New Font("Segoe UI", 8.5F)
        btnFont.ForeColor = Color.White
        btnFont.Location = New Point(20, 360)
        btnFont.Name = "btnFont"
        btnFont.Size = New Size(100, 30)
        btnFont.TabIndex = 8
        btnFont.Text = "Font Select..."
        btnFont.UseVisualStyleBackColor = False
        '
        'lblTextStyle
        '
        lblTextStyle.AutoSize = True
        lblTextStyle.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblTextStyle.ForeColor = Color.FromArgb(150, 150, 150)
        lblTextStyle.Location = New Point(20, 340)
        lblTextStyle.Name = "lblTextStyle"
        lblTextStyle.Size = New Size(125, 15)
        lblTextStyle.TabIndex = 7
        lblTextStyle.Text = "FONT AND COLORING"
        '
        'tbSpeed
        '
        tbSpeed.Location = New Point(20, 275)
        tbSpeed.Maximum = 20
        tbSpeed.Minimum = 1
        tbSpeed.Name = "tbSpeed"
        tbSpeed.Size = New Size(310, 45)
        tbSpeed.TabIndex = 6
        tbSpeed.Value = 2
        '
        'lblSpeed
        '
        lblSpeed.AutoSize = True
        lblSpeed.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblSpeed.ForeColor = Color.FromArgb(150, 150, 150)
        lblSpeed.Location = New Point(20, 255)
        lblSpeed.Name = "lblSpeed"
        lblSpeed.Size = New Size(171, 15)
        lblSpeed.TabIndex = 5
        lblSpeed.Text = "SCROLL SPEED (Pixels / Frame)"
        '
        'cmbMode
        '
        cmbMode.BackColor = Color.FromArgb(45, 45, 45)
        cmbMode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMode.FlatStyle = FlatStyle.Flat
        cmbMode.Font = New Font("Segoe UI", 9.5F)
        cmbMode.ForeColor = Color.White
        cmbMode.FormattingEnabled = True
        cmbMode.Location = New Point(20, 205)
        cmbMode.Name = "cmbMode"
        cmbMode.Size = New Size(310, 25)
        cmbMode.TabIndex = 4
        '
        'lblMode
        '
        lblMode.AutoSize = True
        lblMode.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblMode.ForeColor = Color.FromArgb(150, 150, 150)
        lblMode.Location = New Point(20, 185)
        lblMode.Name = "lblMode"
        lblMode.Size = New Size(111, 15)
        lblMode.TabIndex = 3
        lblMode.Text = "OUTPUT FORMAT"
        '
        'cmbDevice
        '
        cmbDevice.BackColor = Color.FromArgb(45, 45, 45)
        cmbDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDevice.FlatStyle = FlatStyle.Flat
        cmbDevice.Font = New Font("Segoe UI", 9.5F)
        cmbDevice.ForeColor = Color.White
        cmbDevice.FormattingEnabled = True
        cmbDevice.Location = New Point(20, 135)
        cmbDevice.Name = "cmbDevice"
        cmbDevice.Size = New Size(310, 25)
        cmbDevice.TabIndex = 2
        '
        'lblDevice
        '
        lblDevice.AutoSize = True
        lblDevice.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblDevice.ForeColor = Color.FromArgb(150, 150, 150)
        lblDevice.Location = New Point(20, 115)
        lblDevice.Name = "lblDevice"
        lblDevice.Size = New Size(106, 15)
        lblDevice.TabIndex = 1
        lblDevice.Text = "DECKLINK DEVICE"
        '
        'lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 25)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(297, 30)
        lblTitle.TabIndex = 0
        lblTitle.Text = "DeckLink Scroll Broadcast"
        '
        'pnlPreview
        '
        pnlPreview.BackColor = Color.FromArgb(20, 20, 20)
        pnlPreview.Controls.Add(lblStatus)
        pnlPreview.Controls.Add(lblPreviewTitle)
        pnlPreview.Controls.Add(picPreview)
        pnlPreview.Dock = DockStyle.Fill
        pnlPreview.Location = New Point(350, 0)
        pnlPreview.Name = "pnlPreview"
        pnlPreview.Size = New Size(994, 729)
        pnlPreview.TabIndex = 1
        '
        'lblStatus
        '
        lblStatus.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStatus.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        lblStatus.ForeColor = Color.Gold
        lblStatus.Location = New Point(30, 680)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(934, 25)
        lblStatus.TabIndex = 2
        lblStatus.Text = "Status: Ready"
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblPreviewTitle
        '
        lblPreviewTitle.AutoSize = True
        lblPreviewTitle.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        lblPreviewTitle.ForeColor = Color.FromArgb(150, 150, 150)
        lblPreviewTitle.Location = New Point(30, 25)
        lblPreviewTitle.Name = "lblPreviewTitle"
        lblPreviewTitle.Size = New Size(205, 19)
        lblPreviewTitle.TabIndex = 1
        lblPreviewTitle.Text = "LIVE TRANSMISSION PREVIEW"
        '
        'picPreview
        '
        picPreview.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        picPreview.BackColor = Color.Black
        picPreview.BorderStyle = BorderStyle.FixedSingle
        picPreview.Location = New Point(32, 80)
        picPreview.Name = "picPreview"
        picPreview.Size = New Size(592, 333)
        picPreview.SizeMode = PictureBoxSizeMode.Zoom
        picPreview.TabIndex = 0
        picPreview.TabStop = False
        '
        'Form1
        '
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(28, 28, 28)
        ClientSize = New Size(1007, 758)
        Controls.Add(pnlPreview)
        Controls.Add(pnlSidebar)
        ForeColor = Color.White
        MinimumSize = New Size(1007, 758)
        MaximumSize = New Size(1007, 758)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "DeckLink Vertical Scroll Player"
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        CType(tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(numLineSpacing, System.ComponentModel.ISupportInitialize).EndInit()
        pnlPreview.ResumeLayout(False)
        pnlPreview.PerformLayout()
        CType(picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblDevice As Label
    Friend WithEvents cmbDevice As ComboBox
    Friend WithEvents cmbMode As ComboBox
    Friend WithEvents lblMode As Label
    Friend WithEvents lblSpeed As Label
    Friend WithEvents tbSpeed As TrackBar
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
    Friend WithEvents lblPreviewTitle As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblSpeedVal As Label
    Friend WithEvents chkTransparentBg As CheckBox
    Friend WithEvents lblAlignment As Label
    Friend WithEvents cmbAlignment As ComboBox
    Friend WithEvents lblLineSpacing As Label
    Friend WithEvents numLineSpacing As NumericUpDown
    Friend WithEvents chkEnableKeyer As CheckBox
End Class
