Public Class Globals
#Region "MySQL Constants"
    'change these three values for your user, pass and DB name.
    'if you add the environment variables with the project open, you might need to restart Visual Studio so it can fetch teh variables properly
    Private Shared ReadOnly _MySQL_User As String = Environment.GetEnvironmentVariable("MySQL_User")
    Private Shared ReadOnly _MySQL_Pass As String = Environment.GetEnvironmentVariable("MySQL_Pass")
    Private Shared ReadOnly _MySQL_DB As String = Environment.GetEnvironmentVariable("MySQL_DB")
    Private Shared ReadOnly _connectionString As String = "server=localhost;userid=" & _MySQL_User & ";password=" & _MySQL_Pass & ";database=" & _MySQL_DB
#End Region

    Private Shared ReadOnly _baseScale As Integer = 550

#Region "Properties"
    Public Shared ReadOnly Property MySQL_DB As String
        Get
            Return _MySQL_DB
        End Get
    End Property

    Public Shared ReadOnly Property ConnectionString As String
        Get
            Return _connectionString
        End Get
    End Property

    Public Shared ReadOnly Property BaseScale As Integer
        Get
            Return _baseScale
        End Get
    End Property
#End Region

#Region "Constructor"
    'singleton / no other instance allowed
    Private Sub New()
    End Sub
#End Region
End Class
