Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient
Imports System.Net

Public Class frmFemales
    'change these three values for your user, pass and DB name.
    'if you add the environment variables with the project open, you might need to restart Visual Studio so it can fetch teh variables properly
    Dim MySQL_User As String = Environment.GetEnvironmentVariable("MySQL_User")
    Dim MySQL_Pass As String = Environment.GetEnvironmentVariable("MySQL_Pass")
    Dim MySQL_DB As String = Environment.GetEnvironmentVariable("MySQL_DB")
    Dim connectionString As String = "server=localhost;userid=" & MySQL_User & ";password=" & MySQL_Pass & ";database=" & MySQL_DB

    Private Sub btnClickme_Click(sender As Object, e As EventArgs) Handles btnClickme.Click
        btnClickme.Enabled = False 'to avoid user clicking multiple times
        Dim conn As New MySqlConnection(connectionString)

        Try
            conn.Open()
            Dim query = "select imageURL from " & MySQL_DB & " where id=@id"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@id", cbxFemales.SelectedValue)

            Dim result As Object = cmd.ExecuteScalar()

            If result IsNot Nothing Then

                Dim webClient As New WebClient()
                Dim imgFemale As Image
                Dim imageStream As IO.Stream = webClient.OpenRead(result.ToString)

                imgFemale = Image.FromStream(imageStream)

                Dim scale As Double = BASE_SCALE / imgFemale.Height
                imgFemale = New Bitmap(imgFemale, CInt(imgFemale.Width * scale), CInt(imgFemale.Height * scale))

                pbxFemale.Image = imgFemale
                pbxFemale.SizeMode = PictureBoxSizeMode.StretchImage
                pbxFemale.Width = imgFemale.Width
                pbxFemale.Height = imgFemale.Height

                imageStream.Close()
            Else
                MessageBox.Show("Data not found")
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to fetch image: " & ex.Message)
        Finally
            conn.Close()
            btnClickme.Enabled = True
        End Try
    End Sub

    Private Sub frmFemales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCbxFemales()
    End Sub

    Public Sub LoadCbxFemales()
        Dim conn As New MySqlConnection(connectionString)

        Try
            conn.Open()
            Dim query = "select id, name from " & MySQL_DB
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            adapter.Fill(dt)

            cbxFemales.DataSource = dt
            cbxFemales.DisplayMember = "name"
            cbxFemales.ValueMember = "id"
        Catch ex As Exception
            MessageBox.Show("Failed to fetch data and fill the combobox: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is frmInsertFemale Then
                OpenForm.BringToFront()
                Return
            End If
        Next

        Dim frmInsert As New frmInsertFemale()
        frmInsert.Show()
    End Sub

    Private Sub btnDeleteFemale_Click(sender As Object, e As EventArgs) Handles btnDeleteFemale.Click
        If cbxFemales.SelectedValue Is Nothing Then
            MessageBox.Show("No value selected")
            Return
        End If

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Dim query = "delete from " & MySQL_DB & " where id=@id"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", cbxFemales.SelectedValue)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record deleted")
                LoadCbxFemales()
            Catch ex As Exception
                MessageBox.Show("Failed to delete record: " & ex.Message)
            End Try
        End Using
    End Sub
End Class
