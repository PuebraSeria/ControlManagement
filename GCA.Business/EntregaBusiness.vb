Imports GCA.Domain
Imports CGA.DataAccess

Public Class EntregaBusiness

    Private connString As String
    Private entrega As EntregaDA

    Public Sub New(conn As String)
        Me.connString = conn
        Me.entrega = New EntregaDA(Me.connString)
    End Sub

    Public Function crearEntrega(entrega As Entrega) As Integer
        Return Me.entrega.crearEntrega(entrega)
    End Function

    Public Function obtenerUltimaEntregaControlOficina(codOficina As String, codControl As String) As DataSet
        Return Me.entrega.obtenerUltimaEntregaControlOficina(codOficina, codControl)
    End Function

    Public Function obtenerCantidadControlesEntregados() As DataSet
        Return Me.entrega.obtenerCantidadControlesEntregados()
    End Function

    Public Function obtenerCantidadControlesEntregadosCadaOficina() As DataSet
        Return Me.entrega.obtenerCantidadControlesEntregadosCadaOficina()
    End Function

    Public Function obtenerCantidadControlesEntregasCadaOficiaCadaDocControl() As DataSet
        Return Me.entrega.obtenerCantidadControlesEntregasCadaOficiaCadaDocControl()
    End Function

    Public Function obtenerControlesEntregadosRangoFechas(fechaInicio As String, fechaFinal As String) As DataSet
        Return Me.obtenerControlesEntregadosRangoFechas(fechaInicio, fechaFinal)
    End Function

End Class
