Friend Module Program

    <STAThread()>
    Friend Sub Main(args As String())
        Try
            Application.SetHighDpiMode(HighDpiMode.SystemAware)
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1)
        Catch ex As Exception
            Try
                Dim logPath As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash_log.txt")
                System.IO.File.WriteAllText(logPath, "CRASH ON STARTUP: " & ex.ToString())
            Catch
            End Try
        End Try
    End Sub

End Module
