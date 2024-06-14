Imports System.IO
Imports Langhorst_Ordner_Monitor.WD
Imports Langhorst_Ordner_Monitor.WD.WatchFolder

Public Class Form1
    Private PfadListe As New List(Of String)
    Private PfadDatei As String

    Friend Sub UpdateStatusLabel(v As String)
        Throw New NotImplementedException()
    End Sub


    Private Sub WatchDirectory_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Get the current user's name

        Dim currentUser As String = Environment.UserName

        ' Set the file path to be in the user's local application data directory with username
        Dim localAppData As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim programDirectory As String = Path.Combine(localAppData, "Ordner Ueberwachung")
        PfadDatei = Path.Combine(programDirectory, $"{currentUser}_PfadListe.txt")

        ' Ensure the directory exists
        If Not Directory.Exists(programDirectory) Then
            Directory.CreateDirectory(programDirectory)
        End If

        ' Lade die Pfade beim Starten der Anwendung
        LadePfade()
        UpdatePathListBox()

        ' Starte die Überwachung für alle gespeicherten Pfade
        StarteUeberwachungFuerGespeichertePfade()
    End Sub

    ' Überschreiben der FormClosing-Methode
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        ' Verhindern, dass das Formular geschlossen wird, wenn der Benutzer das Fenster schließt
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True ' Verhindert das Schließen des Formulars
            Me.Hide() ' Versteckt das Formular
            NotifyIcon2.Visible = True ' Zeigt das NotifyIcon im System-Tray an
        Else
            MyBase.OnFormClosing(e)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim selectedPath As String = FolderBrowserDialog1.SelectedPath
            If Not PfadListe.Contains(selectedPath) Then
                PfadListe.Add(selectedPath)
                UpdatePathListBox()
                SpeicherePfade()
                WD.WatchFolder.StartWatching(selectedPath, Me) ' Startet die Überwachung des ausgewählten Pfades und übergibt die Hauptform
            Else
                MessageBox.Show("Der Pfad wird bereits überwacht.")
            End If
        End If
    End Sub

    Private Sub UpdatePathListBox()
        ListBox1.Items.Clear()
        For Each pfad In PfadListe
            ListBox1.Items.Add(pfad)
        Next
    End Sub

    Private Sub SpeicherePfade()
        File.WriteAllLines(PfadDatei, PfadListe)
    End Sub

    Private Sub LadePfade()
        If File.Exists(PfadDatei) Then
            PfadListe = File.ReadAllLines(PfadDatei).ToList()
        End If
    End Sub

    Private Sub ListBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = ListBox1.IndexFromPoint(e.Location)
            If index <> ListBox.NoMatches Then
                ListBox1.SelectedIndex = index
                ContextMenuStrip1.Show(ListBox1, e.Location)
            End If
        End If
    End Sub

    Private Sub EntfernenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntfernenToolStripMenuItem.Click
        Dim selectedIndex As Integer = ListBox1.SelectedIndex
        If selectedIndex <> -1 Then
            Dim selectedPath As String = PfadListe(selectedIndex)
            PfadListe.RemoveAt(selectedIndex)
            UpdatePathListBox()
            SpeicherePfade()
            WatchFolder.StopWatching() ' Corrected call without passing parameters
        End If
    End Sub


    Private Sub StarteUeberwachungFuerGespeichertePfade()
        For Each path In PfadListe
            WatchFolder.StartWatching(path, Me)
        Next
    End Sub

    Private Sub NotifyIcon2_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon2.DoubleClick
        ' Stellt das Formular wieder her, wenn der Benutzer auf das NotifyIcon doppelklickt
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon2.Visible = False ' Versteckt das NotifyIcon, wenn das Formular sichtbar ist
    End Sub

End Class