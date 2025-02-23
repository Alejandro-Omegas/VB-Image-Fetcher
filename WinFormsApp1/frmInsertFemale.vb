Imports System.Net.Http
Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks

Public Class frmInsertFemale
    'change these three values for your user, pass and DB name.
    'if you add the environment variables with the project open, you might need to restart Visual Studio so it can fetch teh variables properly
    Dim MySQL_User As String = Environment.GetEnvironmentVariable("MySQL_User")
    Dim MySQL_Pass As String = Environment.GetEnvironmentVariable("MySQL_Pass")
    Dim MySQL_DB As String = Environment.GetEnvironmentVariable("MySQL_DB")
    Dim connectionString As String = "server=localhost;userid=" & MySQL_User & ";password=" & MySQL_Pass & ";database=" & MySQL_DB

    Private Async Sub btnInsertFemale_Click(sender As Object, e As EventArgs) Handles btnInsertFemale.Click
        btnInsertFemale.Enabled = False 'to avoid user clicking multiple times
#Region "Guard conditionals"
        If txtName.Text = "" Then
            MessageBox.Show("Please enter a name")
            Return
        End If

        If txtImageURL.Text = "" Then
            MessageBox.Show("Please enter an image URL")
            Return
        End If

        If Not Uri.IsWellFormedUriString(txtImageURL.Text, UriKind.Absolute) Then
            MessageBox.Show("Please enter a valid URL")
            Return
        End If

        Dim isImage = Await CheckImageURLIsImage(txtImageURL.Text)

        If Not isImage Then
            MessageBox.Show("URL is not from an image")
            Return
        End If
#End Region

        'If all checks are OK, we insert
        Try
            Dim query = "insert into " & MySQL_DB & " (name, imageURL) values (@name, @imageURL)"
            Using conn As New MySqlConnection(Me.connectionString)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@imageURL", txtImageURL.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    CleanFields()
                    conn.Close()
                    MessageBox.Show("Female inserted")
                    frmFemales.LoadCbxFemales()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to insert row: " & ex.Message)
            Return
        End Try

        btnInsertFemale.Enabled = True
    End Sub

    Private Async Function CheckImageURLIsImage(url As String) As Task(Of Boolean)
        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.SendAsync(New HttpRequestMessage(HttpMethod.Head, url))

                If response.IsSuccessStatusCode Then
                    Dim contentType As String = response.Content.Headers.ContentType?.MediaType

                    If Not String.IsNullOrEmpty(contentType) AndAlso contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) Then
                        Return True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Failed to check is URL is from an image: " & ex.Message)
            End Try
        End Using

        Return False
    End Function

    Private Sub CleanFields()
        txtName.Text = ""
        txtImageURL.Text = ""
    End Sub
End Class