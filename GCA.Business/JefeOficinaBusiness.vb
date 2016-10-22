Imports CGA.DataAccess
Imports GCA.Domain

Public Class JefeOficinaBusiness
    Private m_conexionString As String
    Private m_JefeOficinaDA As JefeOficinaDA

    Public Sub New(conn As String)
        Me.ConexionString = conn
        Me.m_JefeOficinaDA = New JefeOficinaDA(Me.ConexionString)
    End Sub

    Public Function insertarJefeOficina(jefe As JefeOficina) As Integer
        Return Me.JefeOficinaDA.insertarJefeOficina(jefe)
    End Function

    Public Function actualizarUsuario(jefe As JefeOficina) As Integer
        Return Me.JefeOficinaDA.actualizarJefeOficina(jefe)
    End Function

    Public Function eliminarJefeOficina(codigo As String) As Integer
        Return Me.JefeOficinaDA.eliminarJefeOficina(codigo)

    End Function

    Public Function obtenerJefeOficinaCodigo(codigo As String) As JefeOficina
        Return Me.JefeOficinaDA.obtenerJefeOficinaCodigo(codigo)

    End Function


    Public Property ConexionString() As String
        Get
            Return m_conexionString
        End Get

        Set
            m_conexionString = Value
        End Set
    End Property

    Public Property JefeOficinaDA() As JefeOficinaDA
        Get
            Return m_JefeOficinaDA
        End Get

        Set
            m_JefeOficinaDA = Value
        End Set
    End Property
End Class
