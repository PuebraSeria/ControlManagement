Imports CGA.DataAccess
Imports GCA.Domain

Public Class PeriodoBusiness
    Private periodoDA As PeriodoDA

    'Método constructor
    Public Sub New(connection As String)
        Me.periodoDA = New PeriodoDA(connection)
    End Sub

    Public Function obtenerPeriodos() As DataSet
        Return periodoDA.obtenerPeriodos()
    End Function

    Public Function obtenerPeriodoCodigo(id As Integer) As Periodo
        Return periodoDA.obtenerPeriodoCodigo(id)
    End Function
End Class
