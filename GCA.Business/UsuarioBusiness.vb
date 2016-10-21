Imports CGA.DataAccess
Imports GCA.Domain

Public Class UsuarioBusiness
    Private m_conexionString As String
    Private m_UsuarioDA As UsuarioDa

    Public Sub New(conn As String)
        Me.ConexionString = conn
        Me.UsuarioDA = New UsuarioDa(Me.ConexionString)
    End Sub

    Public Function insertarUsuario(usuario As Usuario) As Integer
        Return Me.UsuarioDA.insertarUsuario(usuario)
    End Function

    Public Function actualizarUsuario(usuario As Usuario) As Integer
        Return Me.UsuarioDA.actualizarUsuario(usuario)
    End Function

    Public Function eliminarUsuario(codigo As String) As Integer
        Return Me.UsuarioDA.eliminarCliente(codigo)

    End Function

    Public Function obtenerUsuarioCodigo(codigo As String) As Usuario
        Return Me.UsuarioDA.obtenerUsuarioCodigo(codigo)

    End Function


    Public Property ConexionString() As String
        Get
            Return m_conexionString
        End Get

        Set
            m_conexionString = Value
        End Set
    End Property

    Public Property UsuarioDA() As UsuarioDa
        Get
            Return m_UsuarioDA
        End Get

        Set
            m_UsuarioDA = Value
        End Set
    End Property
End Class
