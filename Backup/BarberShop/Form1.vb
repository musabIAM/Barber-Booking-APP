Public Class Form1



    Private Sub ModelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModelToolStripMenuItem.Click

        Form2.Show()
        Form2.MdiParent = Me
        Form3.Hide()
        Form4.Hide()
        Form5.Hide()
        Form6.Hide()
        index.Hide()

    End Sub

    Private Sub MemberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemberToolStripMenuItem.Click

        Form3.Show()
        Form2.Hide()
        Form3.MdiParent = Me
        Form4.Hide()
        Form5.Hide()
        Form6.Hide()
        index.Hide()
    End Sub

    Private Sub PegawaiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegawaiToolStripMenuItem.Click

        Form4.Show()
        Form3.Hide()
        Form2.Hide()
        Form4.MdiParent = Me
        Form5.Hide()
        Form6.Hide()
        index.Hide()
    End Sub

    Private Sub TransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiToolStripMenuItem.Click

        Form5.Show()
        Form3.Hide()
        Form4.Hide()
        Form2.Hide()
        Form5.MdiParent = Me
        Form6.Hide()
        index.Hide()
    End Sub

    Private Sub BookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookingToolStripMenuItem.Click

        Form6.Show()
        Form3.Hide()
        Form4.Hide()
        Form5.Hide()
        Form2.Hide()
        Form6.MdiParent = Me
        index.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If index.log = True Then
            MenuStrip1.Visible = True
        Else
            index.Show()
            index.MdiParent = Me
        End If
    End Sub

End Class
