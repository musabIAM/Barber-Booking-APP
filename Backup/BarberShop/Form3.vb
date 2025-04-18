Imports System.Data.OleDb
Public Class Form3
    Dim Conn As OleDbConnection
    Dim cmd As New OleDb.OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim LokasiDB As String

    Sub Koneksi()
        LokasiDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bbs.accdb;User ID=admin"
        Conn = New OleDbConnection(LokasiDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
    Sub tam()

        Koneksi()
        da = New OleDbDataAdapter("Select * from t_member", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "t_member")
        DataGridView1.DataSource = (ds.Tables("t_member"))
        Conn.Close()

    End Sub
    Sub hapus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tam()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not Conn.State = ConnectionState.Open Then
            Conn.Open()
        End If

        cmd.Connection = Conn

        cmd.CommandText = "INSERT INTO t_member VALUES('" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "','" & Me.TextBox3.Text & "')"

        cmd.ExecuteNonQuery()

        Conn.Close()
        tam()
        hapus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Tambah As String = "Update t_member Set nama_member = '" & TextBox2.Text & "', no_telp = '" & TextBox3.Text & "' WHERE id_member = " & TextBox1.Text & ""

        Try
            Using Conn As New OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=bbs.accdb")
                Using cmd As New OleDbCommand(Tambah, Conn)
                    Conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Berhasil Diubah", MsgBoxStyle.Information, "Perhatian")
                    tam()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        hapus()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim Tambah As String = "DELETE FROM t_member WHERE id_member = " & TextBox1.Text & ""

        Try
            Using Conn As New OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=bbs.accdb")
                Using cmd As New OleDbCommand(Tambah, Conn)
                    Conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information, "Perhatian")
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        tam()
        hapus()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class