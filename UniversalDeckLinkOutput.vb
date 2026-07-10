Imports System.Runtime.InteropServices
Imports DeckLinkAPI

Public Interface IUniversalDeckLinkOutput
    Sub GetDisplayModeIterator(ByRef modeIterator As IDeckLinkDisplayModeIterator)
    Sub EnableVideoOutput(displayMode As _BMDDisplayMode, outputFlags As _BMDVideoOutputFlags)
    Sub DisableVideoOutput()
    Sub CreateVideoFrame(width As Integer, height As Integer, rowBytes As Integer, pixelFormat As _BMDPixelFormat, flags As _BMDFrameFlags, ByRef outFrame As IDeckLinkMutableVideoFrame)
    Sub DisplayVideoFrameSync(videoFrame As IDeckLinkVideoFrame)
    ReadOnly Property RawObject As Object
End Interface

Public Class UniversalDeckLinkOutput
    Implements IUniversalDeckLinkOutput

    Private ReadOnly m_rawObject As Object
    Private ReadOnly m_version As Integer

    ' Internal typed references
    Private m_outLatest As IDeckLinkOutput
    Private m_out15_3_1 As IDeckLinkOutput_v15_3_1
    Private m_out14_2_1 As IDeckLinkOutput_v14_2_1
    Private m_out11_4 As IDeckLinkOutput_v11_4
    Private m_out10_11 As IDeckLinkOutput_v10_11

    Private Sub New(rawObject As Object, version As Integer)
        m_rawObject = rawObject
        m_version = version

        If version = 0 Then m_outLatest = DirectCast(rawObject, IDeckLinkOutput)
        If version = 15 Then m_out15_3_1 = DirectCast(rawObject, IDeckLinkOutput_v15_3_1)
        If version = 14 Then m_out14_2_1 = DirectCast(rawObject, IDeckLinkOutput_v14_2_1)
        If version = 11 Then m_out11_4 = DirectCast(rawObject, IDeckLinkOutput_v11_4)
        If version = 10 Then m_out10_11 = DirectCast(rawObject, IDeckLinkOutput_v10_11)
    End Sub

    Public Shared Function Create(device As IDeckLink) As IUniversalDeckLinkOutput
        If device Is Nothing Then Return Nothing

        Try
            Dim outLatest As IDeckLinkOutput = CType(device, IDeckLinkOutput)
            Console.WriteLine("UniversalDeckLinkOutput: Selected version 0 (Latest)")
            Return New UniversalDeckLinkOutput(outLatest, 0)
        Catch
        End Try

        Try
            Dim out15 As IDeckLinkOutput_v15_3_1 = CType(device, IDeckLinkOutput_v15_3_1)
            Console.WriteLine("UniversalDeckLinkOutput: Selected version 15.3.1")
            Return New UniversalDeckLinkOutput(out15, 15)
        Catch
        End Try

        Try
            Dim out14 As IDeckLinkOutput_v14_2_1 = CType(device, IDeckLinkOutput_v14_2_1)
            Return New UniversalDeckLinkOutput(out14, 14)
        Catch
        End Try

        Try
            Dim out11 As IDeckLinkOutput_v11_4 = CType(device, IDeckLinkOutput_v11_4)
            Return New UniversalDeckLinkOutput(out11, 11)
        Catch
        End Try

        Try
            Dim out10 As IDeckLinkOutput_v10_11 = CType(device, IDeckLinkOutput_v10_11)
            Return New UniversalDeckLinkOutput(out10, 10)
        Catch
        End Try

        ' If all fail, the device truly doesn't support video output, or the driver is way too old.
        Return Nothing
    End Function

    Public ReadOnly Property RawObject As Object Implements IUniversalDeckLinkOutput.RawObject
        Get
            Return m_rawObject
        End Get
    End Property

    Public Sub GetDisplayModeIterator(ByRef modeIterator As IDeckLinkDisplayModeIterator) Implements IUniversalDeckLinkOutput.GetDisplayModeIterator
        If m_version = 0 Then m_outLatest.GetDisplayModeIterator(modeIterator)
        If m_version = 15 Then m_out15_3_1.GetDisplayModeIterator(modeIterator)
        If m_version = 14 Then m_out14_2_1.GetDisplayModeIterator(modeIterator)
        If m_version = 11 Then m_out11_4.GetDisplayModeIterator(modeIterator)
        If m_version = 10 Then m_out10_11.GetDisplayModeIterator(modeIterator)
    End Sub

    Public Sub EnableVideoOutput(displayMode As _BMDDisplayMode, outputFlags As _BMDVideoOutputFlags) Implements IUniversalDeckLinkOutput.EnableVideoOutput
        If m_version = 0 Then m_outLatest.EnableVideoOutput(displayMode, outputFlags)
        If m_version = 15 Then m_out15_3_1.EnableVideoOutput(displayMode, outputFlags)
        If m_version = 14 Then m_out14_2_1.EnableVideoOutput(displayMode, outputFlags)
        If m_version = 11 Then m_out11_4.EnableVideoOutput(displayMode, outputFlags)
        If m_version = 10 Then m_out10_11.EnableVideoOutput(displayMode, outputFlags)
    End Sub

    Public Sub DisableVideoOutput() Implements IUniversalDeckLinkOutput.DisableVideoOutput
        If m_version = 0 Then m_outLatest.DisableVideoOutput()
        If m_version = 15 Then m_out15_3_1.DisableVideoOutput()
        If m_version = 14 Then m_out14_2_1.DisableVideoOutput()
        If m_version = 11 Then m_out11_4.DisableVideoOutput()
        If m_version = 10 Then m_out10_11.DisableVideoOutput()
    End Sub

    Public Sub CreateVideoFrame(width As Integer, height As Integer, rowBytes As Integer, pixelFormat As _BMDPixelFormat, flags As _BMDFrameFlags, ByRef outFrame As IDeckLinkMutableVideoFrame) Implements IUniversalDeckLinkOutput.CreateVideoFrame
        If m_version = 0 Then m_outLatest.CreateVideoFrame(width, height, rowBytes, pixelFormat, flags, outFrame)
        If m_version = 15 Then m_out15_3_1.CreateVideoFrame(width, height, rowBytes, pixelFormat, flags, outFrame)
        If m_version = 14 Then m_out14_2_1.CreateVideoFrame(width, height, rowBytes, pixelFormat, flags, outFrame)
        If m_version = 11 Then m_out11_4.CreateVideoFrame(width, height, rowBytes, pixelFormat, flags, outFrame)
        If m_version = 10 Then m_out10_11.CreateVideoFrame(width, height, rowBytes, pixelFormat, flags, outFrame)
    End Sub

    Public Sub DisplayVideoFrameSync(videoFrame As IDeckLinkVideoFrame) Implements IUniversalDeckLinkOutput.DisplayVideoFrameSync
        If m_version = 0 Then m_outLatest.DisplayVideoFrameSync(videoFrame)
        If m_version = 15 Then m_out15_3_1.DisplayVideoFrameSync(videoFrame)
        If m_version = 14 Then m_out14_2_1.DisplayVideoFrameSync(videoFrame)
        If m_version = 11 Then m_out11_4.DisplayVideoFrameSync(videoFrame)
        If m_version = 10 Then m_out10_11.DisplayVideoFrameSync(videoFrame)
    End Sub
End Class
