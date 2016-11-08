
Imports CGA.DataAccess
Imports GCA.Domain

Public Class DocControlBusiness


    Private connString As String
    Private control As DocControlDA


    Public Sub New(conn As String)
        Me.connString = conn
        Me.control = New DocControlDA(Me.connString)
    End Sub

    Public Function crearControl(control As DocControl) As Integer

        Return Me.control.crearControl(control)

    End Function

    Public Function actualizarControl(control As DocControl) As Integer

        Return Me.control.actualizarControl(control)

    End Function

    Public Function eliminarControl(codigo As String) As Integer

        Return Me.control.eliminarControl(codigo)

    End Function

    Public Function existeControl(codigo As String) As Integer
        Return Me.control.existeControl(codigo)
    End Function

    Public Function obtenerControles() As DataSet
        Return Me.control.obtenerControles()
    End Function

    Public Function obtenerInformacionControlesAsignados() As String
        Return Me.control.obtenerInformacionControlesAsignados()
    End Function

End Class
