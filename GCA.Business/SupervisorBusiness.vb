Imports CGA.DataAccess
Imports GCA.Domain

Public Class SupervisorBusiness
    Private m_conexionString As String
    Private m_SupervisorDA As SupervisorDA

    Public Sub New(conn As String)
        Me.ConexionString = conn
        Me.m_SupervisorDA = New SupervisorDA(Me.ConexionString)
    End Sub

    Public Function insertarSupervisor(supervisor As Supervisor) As Integer
        Return Me.SupervisorDA.insertarSupervisor(supervisor)
    End Function

    Public Function actualizarSupervisor(supervisor As Supervisor) As Integer
        Return Me.SupervisorDA.actualizarSupervisor(supervisor)
    End Function

    Public Function eliminarSupervisor(codigo As String) As Integer
        Return Me.SupervisorDA.eliminarSupervisor(codigo)

    End Function

    Public Function obtenerSupervisorCodigo(codigo As String) As Supervisor
        Return Me.SupervisorDA.obtenerSupervisorCodigo(codigo)

    End Function

    Public Function existeSupervisor(codigo As String) As Integer
        Return Me.SupervisorDA.existeSupervisor(codigo)
    End Function


    Public Property ConexionString() As String
        Get
            Return m_conexionString
        End Get

        Set
            m_conexionString = Value
        End Set
    End Property

    Public Property SupervisorDA() As SupervisorDA
        Get
            Return m_SupervisorDA
        End Get

        Set
            m_SupervisorDA = Value
        End Set
    End Property
End Class
