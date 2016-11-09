Imports System.Data.SqlClient
Imports GCA.Domain

Public Class PeriodoDA

    'Declaración de variables globales
    Private connection As String

    'Método constructor
    Public Sub New(connection As String)
        Me.connection = connection
    End Sub

    Public Function insertarPeriodo(periodo As Periodo) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_InsertarPeriodo"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe

        cmdInsert.Parameters.Add(New SqlParameter("@nombre", periodo.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@dias", periodo.Dias))

        'Variables que retorna
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        'Insertamos en la base
        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()

        'Guardamos la variable que retorna
        Dim respuesta As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        'Cerramos la conexión
        cmdInsert.Connection.Close()

        Return respuesta
    End Function

    'Método que nos permite actualizar un periodo
    Public Function actualizarPeriodo(periodo As Periodo) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_ActualizarPeriodo"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@id", periodo.Id))
        cmdInsert.Parameters.Add(New SqlParameter("@nombre", periodo.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@dias", periodo.Dias))

        'Variables que retorna
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        'Insertamos en la base
        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()

        'Guardamos la variable que retorna
        Dim respuesta As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        'Cerramos la conexión
        cmdInsert.Connection.Close()

        Return respuesta
    End Function

    'Función que nos permtie eliminar periodo
    Public Function eliminarPeriodo(id As Integer) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_EliminarPeriodo"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@id", id))

        'Variables que retorna
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        'Insertamos en la base
        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()

        'Guardamos la variable que retorna
        Dim respuesta As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        'Cerramos la conexión
        cmdInsert.Connection.Close()

        Return respuesta
    End Function

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

    ''' <summary>
    ''' Función que nos pertmite obtener el periodo según el ID
    ''' </summary>
    ''' <param name="id">Corresponde al id que tiene el período</param>
    ''' <returns>Periodo</returns>
    Public Function obtenerPeriodoCodigo(id As Integer) As Periodo
        Dim sqlConn As New SqlConnection(Me.connection)

        Dim query As String = "select * from TPeriodo where TN_Id_Periodo = " + id.ToString

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
            periodo.Dias = Int32.Parse(currentRow("TN_Dias_Periodo").ToString())
        Next
        Return periodo
    End Function

    Public Function existePeriodo(id As Integer) As Integer
        Dim sqlConn As New SqlConnection(Me.connection)

        Dim sqlStoredProcedure As String = "PA_ExistePeriodo"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, sqlConn)

        cmdInsert.CommandType = CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@id", id))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

End Class
