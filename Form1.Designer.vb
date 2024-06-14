<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        NotifyIcon1 = New NotifyIcon(components)
        NotifyIcon2 = New NotifyIcon(components)
        Button1 = New Button()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        ListBox1 = New ListBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        EntfernenToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.Text = "NotifyIcon1"
        NotifyIcon1.Visible = True
        ' 
        ' NotifyIcon2
        ' 
        NotifyIcon2.Text = "NotifyIcon2"
        NotifyIcon2.Visible = True
        ' 
        ' Button1
        ' 
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.Location = New Point(12, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(211, 73)
        Button1.TabIndex = 0
        Button1.Text = "Add Folder"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(12, 111)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(776, 94)
        ListBox1.TabIndex = 1
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {EntfernenToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(181, 48)
        ' 
        ' EntfernenToolStripMenuItem
        ' 
        EntfernenToolStripMenuItem.Name = "EntfernenToolStripMenuItem"
        EntfernenToolStripMenuItem.Size = New Size(180, 22)
        EntfernenToolStripMenuItem.Text = "Entfernen"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ListBox1)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents NotifyIcon2 As NotifyIcon
    Friend WithEvents Button1 As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EntfernenToolStripMenuItem As ToolStripMenuItem

End Class
