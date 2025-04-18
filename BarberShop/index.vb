Public Class index
    Public log As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "Admin" Or TextBox1.Text = "admin" And TextBox1.Text = "Admin" Or TextBox1.Text = "admin" Then
            log = True
            Me.Hide()
            Form1.MenuStrip1.Visible = True
        Else
            MsgBox("Username Atau Passwor salah")
            log = False
        End If
    End Sub
End Class