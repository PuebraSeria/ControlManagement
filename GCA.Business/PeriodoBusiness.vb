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

    Public Function insertarPeriodo(periodo As Periodo) As Integer
        Return periodoDA.insertarPeriodo(periodo)
    End Function

    Public Function actualizarPeriodo(periodo As Periodo) As Integer
        Return periodoDA.actualizarPeriodo(periodo)
    End Function

    Public Function eliminarPeriodo(id As Integer) As Integer
        Return periodoDA.eliminarPeriodo(id)
    End Function

    Public Function existePeriodo(id As Integer) As Integer
        Return periodoDA.existePeriodo(id)
    End Function
End Class
