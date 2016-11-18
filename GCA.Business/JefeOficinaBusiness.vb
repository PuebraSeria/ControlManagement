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

    Public Function actualizarJefeOficina(jefe As JefeOficina) As Integer
        Return Me.JefeOficinaDA.actualizarJefeOficina(jefe)
    End Function

    Public Function eliminarJefeOficina(codigo As String) As Integer
        Return Me.JefeOficinaDA.eliminarJefeOficina(codigo)

    End Function

    Public Function obtenerJefeOficinaCodigo(codigo As String) As JefeOficina
        Return Me.JefeOficinaDA.obtenerJefeOficinaCodigo(codigo)

    End Function
    ''' <summary>
    ''' Función que nos permite mandar los valores ingresados a la capa de acceso a bases de datos
    ''' para saber si el jefe de oficina existe o no
    ''' </summary>
    ''' <param name="codigo">Corresponde al código del jefe de oficina</param>
    ''' <param name="contrasenna">Corresponde a la contraseña del jefe de oficina</param>
    ''' <returns>Integer: 0 si no existe y un 1 si existe</returns>
    Public Function existeJefeOficina(codigo As String, contrasenna As String) As Integer
        Return Me.JefeOficinaDA.existeJefeOficina(codigo, contrasenna)
    End Function

    Public Function existeJefeOficinaV(codigo As String) As Integer
        Return Me.JefeOficinaDA.existeJefeOficinaV(codigo)
    End Function

    Public Function obtenerJefes() As DataSet
        Return Me.JefeOficinaDA.obtenerJefes()
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
