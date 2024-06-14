Imports System.IO
Imports System.Windows.Forms

Namespace WD
    Public Class WatchFolder
        Private Shared mainForm As Form
        Private Shared watcher As FileSystemWatcher
        Private Shared NotifyIcon1 As NotifyIcon

        ' Public method to start watching a directory
        Public Shared Sub StartWatching(path As String, form As Form)
            mainForm = form

            ' Initialize the FileSystemWatcher
            watcher = New FileSystemWatcher()
            watcher.Path = path
            watcher.NotifyFilter = NotifyFilters.LastWrite Or NotifyFilters.FileName
            watcher.IncludeSubdirectories = True
            watcher.EnableRaisingEvents = True

            ' Initialize NotifyIcon1
            NotifyIcon1 = New NotifyIcon()
            NotifyIcon1.Icon = SystemIcons.Application
            NotifyIcon1.Visible = True

            ' Add event handlers
            AddHandler watcher.Created, AddressOf OnChanged
            'AddHandler watcher.Changed, AddressOf OnChanged
            'AddHandler watcher.Deleted, AddressOf OnChanged
            'AddHandler watcher.Renamed, AddressOf OnRenamed
            'AddHandler watcher.Error, AddressOf OnError
        End Sub

        ' Public method to stop watching a directory
        Public Shared Sub StopWatching()
            If watcher IsNot Nothing Then
                watcher.EnableRaisingEvents = False
                RemoveHandler watcher.Created, AddressOf OnChanged
                RemoveHandler watcher.Changed, AddressOf OnChanged
                RemoveHandler watcher.Deleted, AddressOf OnChanged
                RemoveHandler watcher.Renamed, AddressOf OnRenamed
                RemoveHandler watcher.Error, AddressOf OnError
                watcher.Dispose()
                watcher = Nothing
                NotifyIcon1.Visible = False
                NotifyIcon1.Dispose()
                ShowMessage("Überwachung gestoppt.")
            End If
        End Sub

        Private Shared Sub OnChanged(sender As Object, e As FileSystemEventArgs)
            If e.ChangeType = WatcherChangeTypes.Created Then
                'ShowMessage($"Erstellt: {e.FullPath}")
                NotifyIcon1.ShowBalloonTip(5000, "Neue Datei", $"Im Verzeichnis: {e.FullPath}", ToolTipIcon.Info)
            ElseIf e.ChangeType = WatcherChangeTypes.Changed Then
                'ShowMessage($"Geändert: {e.FullPath}")
                NotifyIcon1.ShowBalloonTip(5000, "Datei geändert", $"Im Verzeichnis: {e.FullPath}", ToolTipIcon.Info)
            ElseIf e.ChangeType = WatcherChangeTypes.Deleted Then
                'ShowMessage($"Gelöscht: {e.FullPath}")
            End If
        End Sub

        Private Shared Sub OnRenamed(sender As Object, e As RenamedEventArgs)
            'ShowMessage($"Umbenannt: {e.OldFullPath} zu {e.FullPath}")
        End Sub

        Private Shared Sub OnError(sender As Object, e As ErrorEventArgs)
            Dim ex As Exception = e.GetException()
            PrintException(ex)
        End Sub

        Private Shared Sub PrintException(ex As Exception)
            If ex IsNot Nothing Then
                'ShowMessage($"Fehler: {ex.Message}{Environment.NewLine}Stacktrace:{Environment.NewLine}{ex.StackTrace}")
                PrintException(ex.InnerException)
            End If
        End Sub

        ' Helper method to show message box on the UI thread
        Private Shared Sub ShowMessage(message As String)
            If mainForm IsNot Nothing AndAlso Not mainForm.IsDisposed Then
                If mainForm.InvokeRequired Then
                    mainForm.Invoke(Sub() MessageBox.Show(mainForm, message))
                Else
                    MessageBox.Show(mainForm, message)
                End If
            End If
        End Sub
    End Class
End Namespace