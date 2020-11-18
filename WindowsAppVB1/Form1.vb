Public Class Form1
    Private Sub DemoHelloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DemoHelloToolStripMenuItem.Click
        Dim frm As New DemoHelloForm
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
        frm.Text = "DemoHelloForm"
    End Sub
End Class
