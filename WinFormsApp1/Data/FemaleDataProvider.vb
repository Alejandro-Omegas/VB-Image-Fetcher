Imports System.Net
Imports MySql.Data.MySqlClient

Public Class FemaleDataProvider
#Region "Fields"
    Private Shared _listFemales As List(Of FemaleEntity)
#End Region

#Region "Properties"
    Public Shared Property ListFemales As List(Of FemaleEntity)
        Get
            Return _listFemales
        End Get
        Set(value As List(Of FemaleEntity))
            _listFemales = value
        End Set
    End Property
#End Region

#Region "Constructor"
    'singleton / no other instance allowed
    Private Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Shared Function GetAllFemales() As List(Of FemaleEntity)
        'Note: DO NOT declare the list INSIDE the Try block, or it will return a null list
        Dim listFemales As New List(Of FemaleEntity)()

        Try
            Dim query = "select id, name from " & Globals.MySQL_DB ' & Globals.MySQL_DB 'table name is the same as DB name

            Using conn As New MySqlConnection(Globals.ConnectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim female As New FemaleEntity() With {
                                .Id = Convert.ToInt32(reader("id")),
                                .Name = reader("name").ToString()
                            }
                            listFemales.Add(female)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to fetch data from database: " & ex.Message)
        End Try

        Return listFemales
    End Function

    Public Shared Function GetImageURL(ByVal id As Integer) As String
        Dim conn As New MySqlConnection(Globals.ConnectionString)

        Try
            conn.Open()
            Dim query = "select imageURL from " & Globals.MySQL_DB & " where id=@id"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@id", id)

            Return cmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("Failed to fetch image: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Shared Sub DeleteFemale(ByVal id As Integer)
        Try
            Using conn As New MySqlConnection(Globals.ConnectionString)
                conn.Open()
                Dim query = "delete from " & Globals.MySQL_DB & " where id=@id"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Record deleted")
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to delete row: " & ex.Message)
        End Try
    End Sub

    Public Shared Function InsertFemale(ByVal name As String, ByVal imageURL As String) As Boolean
        Try
            Dim query = "insert into " & Globals.MySQL_DB & " (name, imageURL) values (@name, @imageURL)"
            Using conn As New MySqlConnection(Globals.ConnectionString)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@imageURL", imageURL)
                    conn.Open()
                    cmd.ExecuteNonQuery()

                    conn.Close()
                    Return True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to insert row: " & ex.Message)
            Return False
        End Try
    End Function
#End Region
End Class
