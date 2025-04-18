Imports System.Data.OleDb
Public Class Form5
    Dim Conn As OleDbConnection
    Dim cmd As New OleDb.OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim LokasiDB As String
    Dim dateset As String
    Dim test As OleDbDataReader


    Sub Koneksi()
        LokasiDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bbs.accdb;User ID=admin"
        Conn = New OleDbConnection(LokasiDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
    
    Sub hapus()
        'TextBox4.Text = ""
        'TextBox5.Text = ""
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Koneksi()
        Dim cmb As OleDbCommand = New OleDbCommand("Select * from t_model", Conn)
        test = cmb.ExecuteReader
        While test.Read()
            ComboBox1.Items.Add(test("nama_model"))
        End While
        Conn.Close()

        Koneksi()
        cmb = New OleDbCommand("Select * from t_pegawai", Conn)
        test = cmb.ExecuteReader
        While test.Read()
            ComboBox2.Items.Add(test("nama_pegawai"))
        End While
        Conn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        dateset = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        If Not Conn.State = ConnectionState.Open Then
            Conn.Open()
        End If

        cmd.Connection = Conn

        cmd.CommandText = "INSERT INTO t_transaksi(nama, tanggal, model, penyukur, harga) VALUES('" & Me.TextBox4.Text & "','" & Me.dateset & "','" & Me.ComboBox1.SelectedItem & "','" & Me.ComboBox2.SelectedItem & "','" & Me.TextBox3.Text & "')"

        cmd.ExecuteNonQuery()

        Conn.Close()
        hapus()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Koneksi()
        Dim cmb = New OleDbCommand("Select harga from t_model Where nama_model = '" & ComboBox1.SelectedItem & "'", Conn)
        test = cmb.ExecuteReader
        While test.Read()
            TextBox3.Text = test("harga")
        End While
        Conn.Close()
    End Sub
End Class