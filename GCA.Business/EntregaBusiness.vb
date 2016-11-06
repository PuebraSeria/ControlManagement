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
        Return Me.obtenerUltimaEntregaControlOficina(codOficina, codControl)
    End Function

End Class
