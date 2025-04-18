Imports System.Data.OleDb
Public Class Form6
    Dim Conn As OleDbConnection
    Dim cmd As New OleDb.OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim LokasiDB As String
    Dim dateset As String


    Sub Koneksi()
        LokasiDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bbs.accdb;User ID=admin"
        Conn = New OleDbConnection(LokasiDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
  
    Sub hapus()
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dateset = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        If Not Conn.State = ConnectionState.Open Then
            Conn.Open()
        End If

        cmd.Connection = Conn

        cmd.CommandText = "INSERT INTO t_booking( nama, nomor_tlp, tanggal) VALUES('" & Me.TextBox4.Text & "','" & Me.TextBox5.Text & "','" & Me.dateset & "')"

        cmd.ExecuteNonQuery()

        Conn.Close()
        hapus()

    End Sub

End Class