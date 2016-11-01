Imports System.Data.SqlClient
Imports GCA.Domain

Public Class PeriodoDA

    'Declaración de variables globales
    Private connection As String

    'Método constructor
    Public Sub New(connection As String)
        Me.connection = connection
    End Sub

    Public Function obtenerPeriodos() As DataSet

        Dim sqlConn As New SqlConnection(Me.connection)

        Dim query As String = "select * from TPeriodo "

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsPeriodo As New DataSet()

        sqlAdpater.Fill(dsPeriodo, "TPeriodo")

        sqlAdpater.SelectCommand.Connection.Close()

        Return dsPeriodo
    End Function

    Public Function obtenerPeriodoCodigo(id As Integer) As Periodo
        Dim sqlConn As New SqlConnection(Me.connection)

        Dim query As String = "select * from TPeriodo where TN_Id_Periodo = '" + id + "'"

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsPeriodo As New DataSet()

        sqlAdpater.Fill(dsPeriodo, "TPeriodo")

        sqlAdpater.SelectCommand.Connection.Close()

        Dim dataRowCollection As DataRowCollection = dsPeriodo.Tables("TPeriodo").Rows
        Dim periodo As Periodo = New Periodo()


        For Each currentRow As DataRow In dataRowCollection
            periodo.Id = currentRow("TN_Id_Periodo").ToString()
            periodo.Nombre = currentRow("TC_Nombre_Periodo").ToString()

        Next
        Return periodo
    End Function


End Class
