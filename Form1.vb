Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text.Json
Imports DeckLinkAPI

Public Class Form1
    ' DLL Import for fast memory copy
    Private Declare Sub CopyMemory Lib "kernel32.dll" Alias "RtlMoveMemory" (ByVal dest As IntPtr, ByVal src As IntPtr, ByVal size As IntPtr)

    ' DeckLink fields
    Private m_deckLinkIterator As CDeckLinkIteratorClass
    Private m_deckLinkList As New List(Of IDeckLink)
    Private m_selectedDevice As IDeckLink
    Private m_selectedOutput As IDeckLinkOutput
    Private m_displayModes As New List(Of IDeckLinkDisplayMode)
    Private m_selectedMode As IDeckLinkDisplayMode
    Private m_selectedDeviceIndex As Integer = -1
    Private m_selectedModeIndex As Integer = -1

    ' Rendering & state fields
    Private m_isSimulationMode As Boolean = True
    Private m_isRunning As Boolean = False
    Private m_isPaused As Boolean = False
    Private m_renderThread As Thread
    Private m_isInitializing As Boolean = True
    
    Private m_previewWidth As Integer = 1920
    Private m_previewHeight As Integer = 1080
    Private m_frameRate As Double = 30.0
    Private m_frameIntervalMs As Double = 33.33

    ' Style & scroll content fields
    Private m_textColor As Color = Color.White
    Private m_bgColor As Color = Color.Black
    Private m_isBgTransparent As Boolean = False
    Private m_textAlignment As StringAlignment = StringAlignment.Center
    Private m_lineSpacing As Double = 1.3
    Private m_enableKeyer As Boolean = True
    Private m_font As Font = New Font("Segoe UI", 36.0F, FontStyle.Regular)
    Private m_scrollSpeed As Integer = 2
    Private m_scrollText As String = ""
    Private m_scrollProgress As Double = 0.0
    Private m_textLines As String() = {}
    Private m_isHorizontal As Boolean = False
    Private m_horizontalText As String = ""
    Private m_horizontalTextWidth As Single = 0.0F

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_isSimulationMode = True
        Log("--- Application Startup ---")
        
        ' Initialize DeckLink API Iterator
        Try
            m_deckLinkIterator = New CDeckLinkIteratorClass()
            Log("CDeckLinkIteratorClass instantiated successfully.")
        Catch ex As Exception
            Log("Error instantiating CDeckLinkIteratorClass (DeckLink drivers may not be installed): " & ex.ToString())
            m_deckLinkIterator = Nothing
        End Try

        If m_deckLinkIterator Is Nothing Then
            lblStatus.Text = "Status: DeckLink drivers not found. Running in Simulation Mode (Preview only)."
            lblStatus.ForeColor = Color.Gold
            cmbDevice.Items.Add("Simulation (No Hardware)")
            cmbDevice.SelectedIndex = 0
        Else
            ' Populate devices
            Try
                Dim deckLink As IDeckLink = Nothing
                m_deckLinkIterator.Next(deckLink)
                While deckLink IsNot Nothing
                    m_deckLinkList.Add(deckLink)
                    Dim displayName As String = ""
                    deckLink.GetDisplayName(displayName)
                    cmbDevice.Items.Add(displayName)
                    m_deckLinkIterator.Next(deckLink)
                End While
            Catch ex As Exception
                lblStatus.Text = "Status: Error enumerating DeckLink devices: " & ex.Message
                lblStatus.ForeColor = Color.Red
            End Try

            If cmbDevice.Items.Count = 0 Then
                lblStatus.Text = "Status: No DeckLink hardware found. Running in Simulation Mode."
                lblStatus.ForeColor = Color.Gold
                cmbDevice.Items.Add("Simulation (No Hardware)")
                cmbDevice.SelectedIndex = 0
            Else
                ' Hardware exists, select the first device
                cmbDevice.SelectedIndex = 0
            End If
        End If

        ' Disable Stop and Pause buttons at start
        btnStop.Enabled = False
        btnPause.Enabled = False
        cmbAlignment.SelectedIndex = 1 ' Center by default
        LoadSettings()
        m_isInitializing = False
        Log("Application initialized successfully. Simulation mode = " & m_isSimulationMode.ToString())

    End Sub

    Private Sub cmbDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDevice.SelectedIndexChanged
        ' Release previous COM references
        If m_selectedOutput IsNot Nothing Then
            Marshal.ReleaseComObject(m_selectedOutput)
            m_selectedOutput = Nothing
        End If
        If m_selectedDevice IsNot Nothing Then
            Marshal.ReleaseComObject(m_selectedDevice)
            m_selectedDevice = Nothing
        End If

        cmbMode.Items.Clear()
        m_displayModes.Clear()

        Dim selectedText As String = cmbDevice.SelectedItem.ToString()
        If selectedText = "Simulation (No Hardware)" Then
            m_isSimulationMode = True
            cmbMode.Items.Add("1080p 30fps (Simulation)")
            cmbMode.Items.Add("1080p 60fps (Simulation)")
            cmbMode.SelectedIndex = 0
            lblStatus.Text = "Status: Simulation Mode active"
            lblStatus.ForeColor = Color.Gold
        Else
            m_isSimulationMode = False
            Dim devIndex As Integer = cmbDevice.SelectedIndex
            If devIndex >= 0 AndAlso devIndex < m_deckLinkList.Count Then
                m_selectedDevice = m_deckLinkList(devIndex)
                
                ' Marshal.AddRef is handled implicitly by casting
                m_selectedOutput = TryCast(m_selectedDevice, IDeckLinkOutput)
                
                If m_selectedOutput Is Nothing Then
                    lblStatus.Text = "Status: Selected device does not support video output."
                    lblStatus.ForeColor = Color.Red
                    m_isSimulationMode = True
                    cmbMode.Items.Add("1080p 30fps (Simulation)")
                    cmbMode.SelectedIndex = 0
                Else
                    ' Query supported display modes
                    Try
                        Dim modeIterator As IDeckLinkDisplayModeIterator = Nothing
                        m_selectedOutput.GetDisplayModeIterator(modeIterator)
                        
                        If modeIterator IsNot Nothing Then
                            Dim mode As IDeckLinkDisplayMode = Nothing
                            modeIterator.Next(mode)
                            While mode IsNot Nothing
                                m_displayModes.Add(mode)
                                Dim modeName As String = ""
                                mode.GetName(modeName)
                                cmbMode.Items.Add(modeName)
                                modeIterator.Next(mode)
                            End While
                            
                            Marshal.ReleaseComObject(modeIterator)
                        End If
                    Catch ex As Exception
                        lblStatus.Text = "Status: Failed to retrieve display modes: " & ex.Message
                        lblStatus.ForeColor = Color.Red
                    End Try

                    If cmbMode.Items.Count > 0 Then
                        cmbMode.SelectedIndex = 0
                        lblStatus.Text = "Status: DeckLink device loaded"
                        lblStatus.ForeColor = Color.LightGreen
                    Else
                        lblStatus.Text = "Status: Selected device returned no display modes."
                        lblStatus.ForeColor = Color.Red
                        m_isSimulationMode = True
                        cmbMode.Items.Add("1080p 30fps (Simulation)")
                        cmbMode.SelectedIndex = 0
                    End If
                End If
            End If
        End If
        Log("Device Selection Index Changed: " & cmbDevice.SelectedItem.ToString())
        SaveSettings()
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
        If m_isSimulationMode Then
            m_previewWidth = 1920
            m_previewHeight = 1080
            If cmbMode.SelectedIndex = 1 Then
                m_frameRate = 60.0
                m_frameIntervalMs = 1000.0 / 60.0
            Else
                m_frameRate = 30.0
                m_frameIntervalMs = 1000.0 / 30.0
            End If
        Else
            Dim modeIndex As Integer = cmbMode.SelectedIndex
            If modeIndex >= 0 AndAlso modeIndex < m_displayModes.Count Then
                m_selectedMode = m_displayModes(modeIndex)
                m_previewWidth = m_selectedMode.GetWidth()
                m_previewHeight = m_selectedMode.GetHeight()
                
                Dim frameDuration As Long = 0
                Dim timeScale As Long = 0
                m_selectedMode.GetFrameRate(frameDuration, timeScale)
                
                If timeScale > 0 AndAlso frameDuration > 0 Then
                    m_frameRate = timeScale / frameDuration
                    m_frameIntervalMs = (frameDuration * 1000.0) / timeScale
                Else
                    m_frameRate = 30.0
                    m_frameIntervalMs = 33.33
                End If
            End If
        End If
        Log("Mode Selection Index Changed: " & cmbMode.SelectedItem.ToString() & $" (Width={m_previewWidth}, Height={m_previewHeight}, FPS={m_frameRate})")
        SaveSettings()
    End Sub

    Private Sub btnFont_Click(sender As Object, e As EventArgs) Handles btnFont.Click
        Using fd As New FontDialog()
            fd.Font = m_font
            If fd.ShowDialog() = DialogResult.OK Then
                m_font = fd.Font
                SaveSettings()
            End If
        End Using
    End Sub

    Private Sub btnTextColor_Click(sender As Object, e As EventArgs) Handles btnTextColor.Click
        Using cd As New ColorDialog()
            cd.Color = m_textColor
            If cd.ShowDialog() = DialogResult.OK Then
                m_textColor = cd.Color
                SaveSettings()
            End If
        End Using
    End Sub

    Private Sub btnBgColor_Click(sender As Object, e As EventArgs) Handles btnBgColor.Click
        Using cd As New ColorDialog()
            cd.Color = m_bgColor
            If cd.ShowDialog() = DialogResult.OK Then
                m_bgColor = cd.Color
                SaveSettings()
            End If
        End Using
    End Sub

    Private Sub btnLoadFile_Click(sender As Object, e As EventArgs) Handles btnLoadFile.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim fileText As String = File.ReadAllText(ofd.FileName)
                    txtScrollText.Text = fileText.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                    SaveSettings()
                Catch ex As Exception
                    MessageBox.Show("Error loading file: " & ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub numSpeed_ValueChanged(sender As Object, e As EventArgs) Handles numSpeed.ValueChanged
        m_scrollSpeed = CType(numSpeed.Value, Integer)
        SaveSettings()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If m_isRunning Then Return

        m_scrollText = txtScrollText.Text
        m_textLines = m_scrollText.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)
        m_isHorizontal = chkHorizontal.Checked
        If m_isHorizontal Then
            m_horizontalText = m_scrollText.Replace(vbCrLf, "   ").Replace(vbCr, "   ").Replace(vbLf, "   ")
            While m_horizontalText.Contains("    ")
                m_horizontalText = m_horizontalText.Replace("    ", "   ")
            End While
        End If
        m_scrollProgress = 0.0
        m_scrollSpeed = CType(numSpeed.Value, Integer)
        m_selectedDeviceIndex = cmbDevice.SelectedIndex
        m_selectedModeIndex = cmbMode.SelectedIndex
        Log($"Start Playback requested. DeviceIdx={m_selectedDeviceIndex}, ModeIdx={m_selectedModeIndex}, Speed={m_scrollSpeed} px/frame, Text Length={m_scrollText.Length} chars.")
        SaveSettings()

        If m_isSimulationMode Then
            UpdateStatusSafe("Status: Running Simulation Mode (Preview only)...")
        Else
            UpdateStatusSafe("Status: Broadcasting via DeckLink...")
        End If

        m_isBgTransparent = chkTransparentBg.Checked
        m_isRunning = True
        m_isPaused = False
        btnPause.Text = "PAUSE"
        btnPause.BackColor = Color.FromArgb(70, 70, 70)
        btnPause.Enabled = True
        btnStart.Enabled = False
        btnStop.Enabled = True
        cmbDevice.Enabled = False
        cmbMode.Enabled = False
        btnLoadFile.Enabled = False
        txtScrollText.Enabled = False

        ' Create MTA thread for rendering
        m_renderThread = New Thread(AddressOf RenderLoop)
        m_renderThread.SetApartmentState(ApartmentState.MTA)
        m_renderThread.IsBackground = True
        m_renderThread.Start()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopPlayback()
    End Sub

    Private Sub chkTransparentBg_CheckedChanged(sender As Object, e As EventArgs) Handles chkTransparentBg.CheckedChanged
        m_isBgTransparent = chkTransparentBg.Checked
        SaveSettings()
    End Sub

    Private Sub chkHorizontal_CheckedChanged(sender As Object, e As EventArgs) Handles chkHorizontal.CheckedChanged
        m_isHorizontal = chkHorizontal.Checked
        SaveSettings()
    End Sub

    Private Sub cmbAlignment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAlignment.SelectedIndexChanged
        Select Case cmbAlignment.SelectedIndex
            Case 0 ' Left
                m_textAlignment = StringAlignment.Near
            Case 1 ' Center
                m_textAlignment = StringAlignment.Center
            Case 2 ' Right
                m_textAlignment = StringAlignment.Far
            Case Else
                m_textAlignment = StringAlignment.Center
        End Select
        SaveSettings()
    End Sub

    Private Sub numLineSpacing_ValueChanged(sender As Object, e As EventArgs) Handles numLineSpacing.ValueChanged
        m_lineSpacing = CType(numLineSpacing.Value, Double)
        SaveSettings()
    End Sub



    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If Not m_isRunning Then Return

        m_isPaused = Not m_isPaused
        If m_isPaused Then
            btnPause.Text = "RESUME"
            btnPause.BackColor = Color.FromArgb(40, 80, 150)
            Log("Playback Paused.")
            UpdateStatusSafe("Status: Paused")
        Else
            btnPause.Text = "PAUSE"
            btnPause.BackColor = Color.FromArgb(70, 70, 70)
            Log("Playback Resumed.")
            UpdateStatusSafe("Status: Broadcasting via DeckLink...")
        End If
    End Sub

    Private Sub StopPlayback()
        If Not m_isRunning Then Return

        Log("Stopping Playback...")
        m_isRunning = False

        ' Join rendering thread
        If m_renderThread IsNot Nothing AndAlso m_renderThread.IsAlive Then
            Log("Waiting for rendering thread to join...")
            m_renderThread.Join(2500)
            Log("Rendering thread stopped.")
        End If

        m_isPaused = False
        btnPause.Text = "PAUSE"
        btnPause.BackColor = Color.FromArgb(70, 70, 70)
        btnPause.Enabled = False
        btnStart.Enabled = True
        btnStop.Enabled = False
        cmbDevice.Enabled = True
        cmbMode.Enabled = True
        btnLoadFile.Enabled = True
        txtScrollText.Enabled = True
        UpdateStatusSafe("Status: Stopped")
    End Sub

    Private Sub RenderLoop()
        ' Initialize COM objects on this background MTA thread to prevent cross-apartment marshaling (InvalidCastException)
        Dim deckLinkIterator As CDeckLinkIteratorClass = Nothing
        Dim localDevice As IDeckLink = Nothing
        Dim localOutput As IDeckLinkOutput = Nothing
        Dim localMode As IDeckLinkDisplayMode = Nothing

        Try
            deckLinkIterator = New CDeckLinkIteratorClass()
            Dim currentIdx As Integer = 0
            Dim foundDevice As IDeckLink = Nothing
            deckLinkIterator.Next(foundDevice)
            
            While foundDevice IsNot Nothing
                If currentIdx = m_selectedDeviceIndex Then
                    localDevice = foundDevice
                    Exit While
                Else
                    Marshal.ReleaseComObject(foundDevice)
                End If
                currentIdx += 1
                deckLinkIterator.Next(foundDevice)
            End While

            If localDevice Is Nothing Then
                Log("Error: Selected device index not found on background thread.")
                Return
            End If

            localOutput = TryCast(localDevice, IDeckLinkOutput)
            If localOutput Is Nothing Then
                Log("Error: Selected device does not support output on background thread.")
                Return
            End If

            ' Find display mode
            Dim modeIterator As IDeckLinkDisplayModeIterator = Nothing
            localOutput.GetDisplayModeIterator(modeIterator)
            If modeIterator IsNot Nothing Then
                Dim mode As IDeckLinkDisplayMode = Nothing
                modeIterator.Next(mode)
                Dim modeIdx As Integer = 0
                While mode IsNot Nothing
                    If modeIdx = m_selectedModeIndex Then
                        localMode = mode
                        Exit While
                    Else
                        Marshal.ReleaseComObject(mode)
                    End If
                    modeIdx += 1
                    modeIterator.Next(mode)
                End While
                Marshal.ReleaseComObject(modeIterator)
            End If

            If localMode Is Nothing Then
                Log("Error: Selected display mode not found on background thread.")
                Return
            End If

            ' Enable Video Output
            Dim displayModeVal As _BMDDisplayMode = localMode.GetDisplayMode()
            Log("Enabling DeckLink Video Output on background thread for mode: " & displayModeVal.ToString())
            localOutput.EnableVideoOutput(displayModeVal, _BMDVideoOutputFlags.bmdVideoOutputFlagDefault)
            Log("DeckLink Video Output Enabled successfully on background thread.")

            ' Enable hardware keying if selected
            If m_enableKeyer Then
                Dim keyer As IDeckLinkKeyer = TryCast(localOutput, IDeckLinkKeyer)
                If keyer IsNot Nothing Then
                    Log("Enabling DeckLink Hardware Keyer (External Keying)...")
                    Try
                        keyer.Enable(1) ' 1 = External Fill/Key output
                        keyer.SetLevel(255) ' Fully opaque key
                        Log("DeckLink Hardware Keyer Enabled successfully.")
                    Catch ex As Exception
                        Log("Warning: Failed to enable hardware keyer: " & ex.Message)
                    End Try
                Else
                    Log("Warning: DeckLink device does not support hardware keying.")
                End If
            End If

        Catch ex As Exception
            Log("Error during background thread COM setup: " & ex.ToString())
            If localMode IsNot Nothing Then Marshal.ReleaseComObject(localMode)
            If localOutput IsNot Nothing Then Marshal.ReleaseComObject(localOutput)
            If localDevice IsNot Nothing Then Marshal.ReleaseComObject(localDevice)
            If deckLinkIterator IsNot Nothing Then Marshal.ReleaseComObject(deckLinkIterator)
            Return
        End Try

        ' Main loop
        Dim stopwatch As New Stopwatch()
        stopwatch.Start()

        While m_isRunning
            Dim startTimeMs As Double = stopwatch.Elapsed.TotalMilliseconds
            
            RenderFrame(localOutput)

            ' Wait for next frame timing using high-precision spin wait
            While stopwatch.Elapsed.TotalMilliseconds - startTimeMs < m_frameIntervalMs
                Thread.SpinWait(10)
            End While
        End While

        ' Clean up output and COM
        Try
            Log("Disabling DeckLink Video Output on background thread...")
            If m_enableKeyer Then
                Dim keyer As IDeckLinkKeyer = TryCast(localOutput, IDeckLinkKeyer)
                If keyer IsNot Nothing Then
                    keyer.Disable()
                    Log("DeckLink Hardware Keyer Disabled.")
                End If
            End If
            localOutput.DisableVideoOutput()
            Log("DeckLink Video Output Disabled successfully on background thread.")
        Catch ex As Exception
            Log("Error disabling DeckLink Video Output on background thread: " & ex.ToString())
        End Try

        ' Release references
        If localMode IsNot Nothing Then Marshal.ReleaseComObject(localMode)
        If localOutput IsNot Nothing Then Marshal.ReleaseComObject(localOutput)
        If localDevice IsNot Nothing Then Marshal.ReleaseComObject(localDevice)
        If deckLinkIterator IsNot Nothing Then Marshal.ReleaseComObject(deckLinkIterator)
    End Sub

    Private Sub RenderFrame(ByVal localOutput As IDeckLinkOutput)
        Dim bmp As New Bitmap(m_previewWidth, m_previewHeight, PixelFormat.Format32bppArgb)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

            If m_isHorizontal Then
                ' Horizontal Ticker Loop
                If m_horizontalTextWidth <= 0 Then
                    m_horizontalTextWidth = g.MeasureString(m_horizontalText, m_font).Width
                End If

                Dim barHeight As Single = m_font.GetHeight() + 40.0F
                Dim yPos As Single = m_previewHeight - barHeight

                ' Draw continuous background strip for horizontal scrolling
                Using bgBrush As New SolidBrush(m_bgColor)
                    g.FillRectangle(bgBrush, 0, yPos, m_previewWidth, barHeight)
                End Using

                Using textBrush As New SolidBrush(m_textColor)
                    ' Right-to-Left scrolling logic
                    Dim xPos As Single = CType(m_previewWidth - m_scrollProgress, Single)

                    ' Looping condition: if the string has fully scrolled past the left edge
                    If xPos < -m_horizontalTextWidth Then
                        m_scrollProgress = 0.0 ' Wrap around
                        xPos = m_previewWidth
                    End If

                    ' Draw primary string
                    g.DrawString(m_horizontalText, m_font, textBrush, xPos, yPos + 20.0F)
                    
                    ' To ensure continuous looping visually, we can draw a secondary trailing string if the primary is exiting left
                    ' and there is space on the right (Optional: often a ticker just starts over).
                End Using
            Else
                ' Vertical Scrolling
                Dim lineHeight As Integer = CInt(Math.Ceiling(m_font.GetHeight() * m_lineSpacing))
                If lineHeight <= 0 Then lineHeight = 40
                
                Dim totalTextHeight As Integer = m_textLines.Length * lineHeight
                If m_scrollProgress > (m_previewHeight + totalTextHeight) Then
                    Me.BeginInvoke(Sub() StopPlayback())
                    Return
                End If

                If m_isBgTransparent Then
                    g.Clear(Color.Transparent)
                Else
                    Using bgBrush As New SolidBrush(m_bgColor)
                        g.FillRectangle(bgBrush, 0, 0, m_previewWidth, m_previewHeight)
                    End Using
                End If

                Using textBrush As New SolidBrush(m_textColor)
                    Using sf As New StringFormat()
                        sf.Alignment = m_textAlignment
                        sf.LineAlignment = StringAlignment.Center

                        For i As Integer = 0 To m_textLines.Length - 1
                            Dim lineY As Single = CType((m_previewHeight - m_scrollProgress) + (i * lineHeight), Single)
                            
                            If lineY + lineHeight > 0 AndAlso lineY < m_previewHeight Then
                                Dim layoutRect As New RectangleF(100.0F, lineY, CType(m_previewWidth - 200.0F, Single), CType(lineHeight, Single))
                                g.DrawString(m_textLines(i), m_font, textBrush, layoutRect, sf)
                            End If
                        Next
                    End Using
                End Using
            End If
        End Using

        ' Clone for local UI preview to avoid thread conflicts
        Dim previewBmp As Bitmap = CType(bmp.Clone(), Bitmap)
        Me.BeginInvoke(Sub()
                           Dim oldBmp As Image = picPreview.Image
                           picPreview.Image = previewBmp
                           If oldBmp IsNot Nothing Then
                               oldBmp.Dispose()
                           End If
                       End Sub)

        ' Output to DeckLink hardware card
        If Not m_isSimulationMode AndAlso localOutput IsNot Nothing Then
            Try
                Dim videoFrameSrc As IDeckLinkMutableVideoFrame = Nothing
                localOutput.CreateVideoFrame(m_previewWidth, m_previewHeight, m_previewWidth * 4, _BMDPixelFormat.bmdFormat8BitBGRA, _BMDFrameFlags.bmdFrameFlagDefault, videoFrameSrc)
                
                Dim videoFrameYUV As IDeckLinkMutableVideoFrame = Nothing
                Dim rowBytesYUV As Integer = m_previewWidth * 2
                localOutput.CreateVideoFrame(m_previewWidth, m_previewHeight, rowBytesYUV, _BMDPixelFormat.bmdFormat8BitYUV, _BMDFrameFlags.bmdFrameFlagDefault, videoFrameYUV)

                If videoFrameSrc IsNot Nothing AndAlso videoFrameYUV IsNot Nothing Then
                    Dim rect As New Rectangle(0, 0, m_previewWidth, m_previewHeight)
                    Dim bmpData As BitmapData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
                    
                    Dim videoBuffer As IDeckLinkVideoBuffer = TryCast(videoFrameSrc, IDeckLinkVideoBuffer)
                    If videoBuffer IsNot Nothing Then
                        videoBuffer.StartAccess(_BMDBufferAccessFlags.bmdBufferAccessWrite)
                        Dim deckLinkBuffer As IntPtr = IntPtr.Zero
                        videoBuffer.GetBytes(deckLinkBuffer)
                        
                        Dim totalSize As Integer = m_previewWidth * m_previewHeight * 4
                        CopyMemory(deckLinkBuffer, bmpData.Scan0, CType(totalSize, IntPtr))
                        
                        videoBuffer.EndAccess(_BMDBufferAccessFlags.bmdBufferAccessWrite)
                    End If
                    bmp.UnlockBits(bmpData)

                    If m_enableKeyer Then
                        ' Output BGRA frame directly (retains alpha channel for hardware keyer)
                        localOutput.DisplayVideoFrameSync(videoFrameSrc)
                    Else
                        ' Convert BGRA frame to YUV frame
                        Dim converter As New CDeckLinkVideoConversionClass()
                        converter.ConvertFrame(videoFrameSrc, videoFrameYUV)
                        
                        ' Output YUV frame to the DeckLink card
                        localOutput.DisplayVideoFrameSync(videoFrameYUV)
                        
                        Marshal.ReleaseComObject(converter)
                    End If
                End If

                If videoFrameSrc IsNot Nothing Then Marshal.ReleaseComObject(videoFrameSrc)
                If videoFrameYUV IsNot Nothing Then Marshal.ReleaseComObject(videoFrameYUV)
            Catch ex As Exception
                Log("Output Error during RenderFrame: " & ex.ToString())
                UpdateStatusSafe("Output Error: " & ex.Message)
            End Try
        End If

        ' Dispose render resources
        bmp.Dispose()

        ' Increment scroll coordinate only if not paused
        If Not m_isPaused Then
            m_scrollProgress += m_scrollSpeed
        End If
    End Sub

    Private Sub UpdateStatusSafe(status As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(Sub() lblStatus.Text = status)
        Else
            lblStatus.Text = status
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Log("Form Closing. Saving settings and stopping playback.")
        SaveSettings()
        StopPlayback()

        ' Clean up COM objects
        If m_selectedOutput IsNot Nothing Then
            Marshal.ReleaseComObject(m_selectedOutput)
            m_selectedOutput = Nothing
        End If
        If m_selectedDevice IsNot Nothing Then
            Marshal.ReleaseComObject(m_selectedDevice)
            m_selectedDevice = Nothing
        End If

        For Each dev In m_deckLinkList
            If dev IsNot Nothing Then
                Marshal.ReleaseComObject(dev)
            End If
        Next
        m_deckLinkList.Clear()

        If m_deckLinkIterator IsNot Nothing Then
            Marshal.ReleaseComObject(m_deckLinkIterator)
            m_deckLinkIterator = Nothing
        End If
    End Sub

    Private Sub LoadSettings()
        Try
            Dim path As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json")
            If Not File.Exists(path) Then Return

            Dim json As String = File.ReadAllText(path)
            Dim options As New JsonSerializerOptions()
            options.PropertyNameCaseInsensitive = True
            Dim settings As AppSettings = JsonSerializer.Deserialize(Of AppSettings)(json, options)

            If settings IsNot Nothing Then
                m_textColor = Color.FromArgb(settings.TextColorArgb)
                m_bgColor = Color.FromArgb(settings.BgColorArgb)
                Try
                    m_font = New Font(settings.FontName, settings.FontSize, CType(settings.FontStyle, FontStyle))
                Catch
                    m_font = New Font("Segoe UI", 36.0F, FontStyle.Regular)
                End Try
                
                numSpeed.Value = Math.Clamp(settings.ScrollSpeed, numSpeed.Minimum, numSpeed.Maximum)
                m_scrollSpeed = CType(numSpeed.Value, Integer)
                
                Dim loadedText As String = If(String.IsNullOrEmpty(settings.ScrollText), GetDefaultCredits(), settings.ScrollText)
                txtScrollText.Text = loadedText.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
                
                chkTransparentBg.Checked = settings.TransparentBg
                m_isBgTransparent = settings.TransparentBg
                chkHorizontal.Checked = settings.HorizontalScroll
                m_isHorizontal = settings.HorizontalScroll
                
                If settings.TextAlignment >= 0 AndAlso settings.TextAlignment <= 2 Then
                    cmbAlignment.SelectedIndex = settings.TextAlignment
                Else
                    cmbAlignment.SelectedIndex = 1 ' Center
                End If

                If settings.LineSpacing >= 0.5F AndAlso settings.LineSpacing <= 5.0F Then
                    numLineSpacing.Value = CType(settings.LineSpacing, Decimal)
                    m_lineSpacing = settings.LineSpacing
                Else
                    numLineSpacing.Value = 1.3D
                    m_lineSpacing = 1.3
                End If

                m_enableKeyer = True ' Always enable keyer by default

                ' Try to match selected device
                If cmbDevice.Items.Contains(settings.SelectedDeviceName) Then
                    cmbDevice.SelectedItem = settings.SelectedDeviceName
                End If

                ' Try to match selected mode
                If cmbMode.Items.Contains(settings.SelectedModeName) Then
                    cmbMode.SelectedItem = settings.SelectedModeName
                End If
            End If
        Catch ex As Exception
            ' Fail silently
        End Try
    End Sub

    Private Sub SaveSettings()
        If m_isInitializing Then Return
        Try
            Dim settings As New AppSettings()
            
            If cmbDevice.SelectedItem IsNot Nothing Then
                settings.SelectedDeviceName = cmbDevice.SelectedItem.ToString()
            End If
            If cmbMode.SelectedItem IsNot Nothing Then
                settings.SelectedModeName = cmbMode.SelectedItem.ToString()
            End If
            
            settings.ScrollSpeed = CType(numSpeed.Value, Integer)
            settings.FontName = m_font.Name
            settings.FontSize = m_font.Size
            settings.FontStyle = CInt(m_font.Style)
            settings.TextColorArgb = m_textColor.ToArgb()
            settings.BgColorArgb = m_bgColor.ToArgb()
            settings.ScrollText = txtScrollText.Text
            settings.TransparentBg = chkTransparentBg.Checked
            settings.HorizontalScroll = chkHorizontal.Checked
            settings.TextAlignment = cmbAlignment.SelectedIndex
            settings.LineSpacing = CType(numLineSpacing.Value, Single)
            settings.EnableKeyer = m_enableKeyer

            Dim path As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json")
            Dim json As String = JsonSerializer.Serialize(settings)
            File.WriteAllText(path, json)
        Catch ex As Exception
            ' Fail silently
        End Try
    End Sub

    Private Function GetDefaultCredits() As String
        Return String.Join(vbCrLf, New String() {
            "Overall In-charge",
            "MUKESH SHARMA",
            "",
            "Producers",
            "Ravi Deep",
            "Sandeep Sood",
            "",
            "Assistant in Production",
            "Vijay Bhingarde",
            "Yohan Samuel",
            "Falgun Limbachiye",
            "Priti Sawant",
            "",
            "Presenters",
            "Milind Wagle",
            "Akshay Maurya",
            "Mona Pahuja",
            "Charu Priya",
            "",
            "Commentator (Marathi)",
            "Prasanna Sant",
            "",
            "Show Co-ordinators",
            "Shrikala Hattangady",
            "Prajyoti Manda",
            "Sandhya Pujari",
            "Santoshi Pawar",
            "",
            "Audio-Video Clips",
            "Vishwajit Walunje",
            "Amit Agarkar",
            "Yogesh Chavan",
            "Shivaji Gangawane",
            "",
            "Editors",
            "Mrutyunjay Wadhwane",
            "Siddhesh Chindarkar",
            "Bhushan Gandhi",
            "",
            "Graphics and Captions",
            "Vimlesh Kumar",
            "Sachin Binaram",
            "",
            "Acknowledgements",
            "MIT Group of Institution, Pune",
            "",
            "Director of Photography",
            "R.N. S. Reddy",
            "",
            "Camera",
            "Pradeep Chakravorthy",
            "N. Venkata Raman",
            "Vijay Sharma",
            "Chindananda Murthy",
            "Sridhar Raj  Urs",
            "Arun Wilson",
            "B.M. Rajshekar",
            "Venkata Raghavan",
            "K.S. Ravidra",
            "Maruti Rao",
            "",
            "Jib Cameramen",
            "Bhagesh Sharma",
            "Pankaj Sharma",
            "Deepak Jhadavkar",
            "",
            "Video Asst.",
            "Nirmal Sahoo",
            "Sushant Bansode",
            "",
            "ENG Teams",
            "VM",
            "V.R. Kulkarni",
            "",
            "CCU",
            "Rajendra Deshmukh",
            "Shankar Renuse",
            "Vilas Nanijkar",
            "",
            "Audio",
            "Jayesh Wavhal (OB Van)",
            "Sadanand Pednekar(Stadium/Commmentator)",
            "",
            "EVS",
            "Vijay Hadap",
            "Peter Mahindraraj",
            "",
            "VTR",
            "Manoj Shelake",
            "",
            "OB Maintenance",
            "Nitin Patravale",
            "",
            "Technicians",
            "Dinesh Kolhatkar",
            "L V Gavade",
            "",
            "Helpers",
            "Shailesh Waghdhare",
            "Prakash Kharade",
            "",
            "Technical Director",
            "V. Muppudathi",
            "",
            "Producers",
            "Vidut Shah",
            "Ashwani Kumar",
            "Sanjay Karnik",
            "Pradeep Chakraworthy",
            "Sridhar Raj urs",
            "",
            "Sound",
            "Hemant Ramarao",
            "",
            "Lighting Asstt.",
            "Sanjay",
            "Sripad",
            "Shashi",
            "",
            "Drivers",
            "Iqbal Sangrar",
            "Dilip Girase",
            "Kishor Pawaskar",
            "Prakash Surve",
            "Narayan Shetty",
            "Mayur Kadam",
            "Sanjay Gabaji",
            "Nandkumar Mistry",
            "",
            "First Draw",
            "Thailand v/s Egypt",
            "Japan v/ Korea",
            "Indonesia V/s Srilanka",
            "Vietnam v/s Hongkong",
            "India-(Nirma) v/s Russian",
            "Malaysia v/s India (VJTI)",
            "Egypt v/s Fiji",
            "Korea V/s Mongolia",
            "Srilanka v/s Nepal",
            "Honkong v/s Bangladesh",
            "Russia v/s Iran",
            "Indai VJTI v/s Kazakhstan",
            "Fiji v/s Thailand",
            "Mongolia v/s Japan",
            "Nepal V/s Indonesia",
            "Bangladesh v/s vietnam",
            "Iran v/s India (Nirma)",
            "kazakhstan V/s Malaysia",
            "",
            "Bangladesh",
            "Chittagong University of Engineering and Technology",
            "",
            "Egypt",
            "Helwan University",
            "",
            "Fiji",
            "University of the South Pacific",
            "",
            "Hong Kong",
            "Hong Kong University of Science and Technology",
            "",
            "India",
            "Nirma University",
            "Veermata Jijabai Technological Institute",
            "",
            "Indonesia",
            "Institut Teknologi Sepuluh Nopember",
            "",
            "Iran",
            "Bahonar University",
            "",
            "Japan",
            "Nagoya Institute of Technology",
            "",
            "Kazakhstan",
            "International IT University",
            "",
            "Rep of Korea",
            "Kwangwoon University",
            "",
            "Malaysia",
            "Universiti Teknologi Malaysia",
            "",
            "Mongolia",
            "Mongolian University of Science and Technology",
            "",
            "Nepal",
            "Tribhuvan University (IOE)",
            "",
            "Russia",
            "Don State Technical University",
            "",
            "Sri Lanka",
            "University of Peradeniya",
            "",
            "Thailand",
            "Dhurakijpundit University",
            "",
            "Vietnam",
            "Lac Hong University"
        })
    End Function

    Private Sub Log(message As String)
        Try
            Dim logPath As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt")
            Dim logMessage As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {message}{Environment.NewLine}"
            File.AppendAllText(logPath, logMessage)
        Catch
            ' Fail silently
        End Try
    End Sub
End Class

Public Class AppSettings
    Public Property SelectedDeviceName As String = ""
    Public Property SelectedModeName As String = ""
    Public Property ScrollSpeed As Integer = 2
    Public Property FontName As String = "Segoe UI"
    Public Property FontSize As Single = 36.0F
    Public Property FontStyle As Integer = 0
    Public Property TextColorArgb As Integer = -1
    Public Property BgColorArgb As Integer = -16777216
    Public Property ScrollText As String = ""
    Public Property TransparentBg As Boolean = False
    Public Property HorizontalScroll As Boolean = False
    Public Property TextAlignment As Integer = 1
    Public Property LineSpacing As Single = 1.3F
    Public Property EnableKeyer As Boolean = False
End Class
