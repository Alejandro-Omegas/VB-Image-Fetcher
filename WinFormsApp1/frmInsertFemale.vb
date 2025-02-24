Imports System.Net.Http
Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks

Public Class frmInsertFemale
#Region "Events"
    Private Async Sub btnInsertFemale_Click(sender As Object, e As EventArgs) Handles btnInsertFemale.Click
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

#Region "Insertion"
        btnInsertFemale.Enabled = False 'to avoid user clicking multiple times

        If FemaleDataProvider.InsertFemale(txtName.Text, txtImageURL.Text) Then
            MessageBox.Show("Female inserted")
            CleanFields()
            frmFemales.LoadCbxFemales()
        End If

        btnInsertFemale.Enabled = True
#End Region
    End Sub
#End Region

#Region "Procedures & Functions"
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
#End Region
End Class