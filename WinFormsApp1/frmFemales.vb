Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient
Imports System.Net
Imports Mysqlx.XDevAPI.Common

Public Class frmFemales
#Region "Events"
    Private Sub frmFemales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCbxFemales()
    End Sub

    Private Sub btnClickme_Click(sender As Object, e As EventArgs) Handles btnClickme.Click
        If cbxFemales.SelectedValue >= 0 Then
            btnClickme.Enabled = False 'to avoid user clicking multiple times

            Dim imageURL As String = FemaleDataProvider.GetImageURL(cbxFemales.SelectedValue)

            If imageURL IsNot Nothing Then
                Try
                    Dim webClient As New WebClient()
                    Dim imgFemale As Image
                    Dim imageStream As IO.Stream = webClient.OpenRead(imageURL)

                    imgFemale = Image.FromStream(imageStream)

                    Dim scale As Double = Globals.BaseScale / imgFemale.Height
                    imgFemale = New Bitmap(imgFemale, CInt(imgFemale.Width * scale), CInt(imgFemale.Height * scale))

                    pbxFemale.Image = imgFemale
                    pbxFemale.SizeMode = PictureBoxSizeMode.StretchImage
                    pbxFemale.Width = imgFemale.Width
                    pbxFemale.Height = imgFemale.Height

                    imageStream.Close()
                Catch ex As Exception
                    MessageBox.Show("Failed to fetch image: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Data not found")
            End If

            btnClickme.Enabled = True
        Else
            MessageBox.Show("No value selected")
            Return
        End If
    End Sub

    Private Sub btnDeleteFemale_Click(sender As Object, e As EventArgs) Handles btnDeleteFemale.Click
        If cbxFemales.SelectedValue >= 0 Then
            btnClickme.Enabled = False 'to avoid user clicking multiple times

            FemaleDataProvider.DeleteFemale(cbxFemales.SelectedValue)
            LoadCbxFemales()

            btnClickme.Enabled = True
        Else
            MessageBox.Show("No value selected")
            Return
        End If
    End Sub

    'this is the button to open the insert image form
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
#End Region

#Region "Procedures & Functions"
    Public Sub LoadCbxFemales()
        Dim listFemales As List(Of FemaleEntity) = FemaleDataProvider.GetAllFemales()

        If listFemales IsNot Nothing Then
            cbxFemales.DataSource = listFemales
            cbxFemales.DisplayMember = "Name"
            cbxFemales.ValueMember = "Id"
            btnClickme.Enabled = True
            btnDeleteFemale.Enabled = True
        Else
            btnClickme.Enabled = False
            btnDeleteFemale.Enabled = False
        End If
    End Sub
#End Region
End Class
