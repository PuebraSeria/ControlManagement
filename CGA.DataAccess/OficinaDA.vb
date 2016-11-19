'Importaciones necesarias
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports GCA.Domain

Public Class OficinaDA
    'Declaración de variables globales
    Private connection As String

    'Método constructor
    Public Sub New(connection As String)
        Me.connection = connection
    End Sub

    ' Método que nos permite insertar oficina
    Public Function insertarOficina(oficina As Oficina) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_InsertarOficina"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@codigo", oficina.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@nombre", oficina.Nombre))

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

    'Método que nos permite actualizar una oficina
    Public Function actualizarOficina(oficina As Oficina) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_ActualizarOficina"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@codigo", oficina.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@nombre", oficina.Nombre))

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

    'Función que nos permtie eliminar oficinas
    Public Function eliminarOficina(codigo As String) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_EliminarOficina"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@codigo", codigo))

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
    'Función que le asigna controles a una oficina
    Public Function asignarControl(codigoControl As String, codigoOficina As String, fecha As String) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_AsignarOficina_Control"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@codigoC", codigoControl))
        cmdInsert.Parameters.Add(New SqlParameter("@codigoO", codigoOficina))
        cmdInsert.Parameters.Add(New SqlParameter("@fecha", fecha))

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

    Public Function desvincularControl(codigoControl As String, codigoOficina As String) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_DesvincularOficina_Control"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@codigoC", codigoControl))
        cmdInsert.Parameters.Add(New SqlParameter("@codigoO", codigoOficina))

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


    Public Function obtenerOficinaCodigo(codigo As String) As Oficina
        Dim sqlConn As New SqlConnection(Me.connection)

        Dim query As String = "select * from TOficina where TC_Codigo_Oficina = '" + codigo + "'"

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsOficina As New DataSet()

        sqlAdpater.Fill(dsOficina, "TOficina")

        sqlAdpater.SelectCommand.Connection.Close()

        Dim dataRowCollection As DataRowCollection = dsOficina.Tables("TOficina").Rows
        Dim oficina As Oficina = New Oficina()


        For Each currentRow As DataRow In dataRowCollection
            oficina.Codigo = currentRow("TC_Codigo_Oficina").ToString()
            oficina.Nombre = currentRow("TC_Nombre_Oficina").ToString()

        Next
        Return oficina
    End Function

    Public Function obtenerOficinas() As DataSet

        Dim sqlConn As New SqlConnection(Me.connection)

        Dim query As String = "select * from TOficina order by(TC_Nombre_Oficina) ASC "

        Dim sqlAdpaterBank As New SqlDataAdapter()
        sqlAdpaterBank.SelectCommand = New SqlCommand()
        sqlAdpaterBank.SelectCommand.CommandText = query
        sqlAdpaterBank.SelectCommand.Connection = sqlConn

        Dim dsBrand As New DataSet()

        sqlAdpaterBank.Fill(dsBrand, "TOficina")

        sqlAdpaterBank.SelectCommand.Connection.Close()

        Return dsBrand
    End Function
    ''' <summary>
    ''' Función que nos permite obtener los controles asignados a una oficina
    ''' </summary>
    ''' <param name="codOficina">Corresponde al código de la oficina</param>
    ''' <returns>DataSet: Que contiene la información de los controles asignados</returns>
    Public Function obtenerControlesOficina(codOficina As String) As DataSet

        Dim sqlConn As New SqlConnection(Me.connection)

        Dim query As String = "select TC_Codigo_DocControl, TC_Nombre_DocControl, TN_Periocidad_DocControl, TF_FechaInicio_DocControl,
                                TF_FechaFinal_DocControl,TF_FechaAsigna_Ofn_X_DocCtrl from TDocControl inner join TOfn_X_DocCtrl on
                                TDocControl.TC_Codigo_DocControl = TOfn_X_DocCtrl.TC_CodDocControl_Ofn_X_DocCtrl
                                where TOfn_X_DocCtrl.TC_CodOficina_Ofn_X_DocCtrl = '" + codOficina + "'"

        Dim sqlAdpaterBank As New SqlDataAdapter()
        sqlAdpaterBank.SelectCommand = New SqlCommand()
        sqlAdpaterBank.SelectCommand.CommandText = query
        sqlAdpaterBank.SelectCommand.Connection = sqlConn

        Dim dsControl As New DataSet()

        sqlAdpaterBank.Fill(dsControl)
        sqlAdpaterBank.SelectCommand.Connection.Close()

        Return dsControl
    End Function

    Public Function obtenerFechaAsignacionControl(idOficina As String, idControl As String) As String
        Dim sqlConn As New SqlConnection(Me.connection)

        Dim query As String = " select TF_FechaAsigna_Ofn_X_DocCtrl from TOfn_X_DocCtrl where " +
                                "TC_CodOficina_Ofn_X_DocCtrl = '" + idOficina + "' And TC_CodDocControl_Ofn_X_DocCtrl = '" + idControl + "'"

        Dim sqlAdpaterBank As New SqlDataAdapter()
        sqlAdpaterBank.SelectCommand = New SqlCommand()
        sqlAdpaterBank.SelectCommand.CommandText = query
        sqlAdpaterBank.SelectCommand.Connection = sqlConn

        Dim dsFecha As New DataSet()

        sqlAdpaterBank.Fill(dsFecha)

        sqlAdpaterBank.SelectCommand.Connection.Close()

        Dim fechaAsignacion As String = ""

        Dim dataRowCollection As DataRowCollection = dsFecha.Tables(0).Rows
        For Each currentRow As DataRow In dataRowCollection
            fechaAsignacion = currentRow(0).ToString()
        Next

        Dim dateA As Date = CDate(fechaAsignacion)
        fechaAsignacion = dateA.ToString("dd-MM-yyyy")

        Return fechaAsignacion

    End Function

    Public Function existeOficina(codigo As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connection)

        Dim sqlStoredProcedure As String = "PA_ExisteOficina"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, sqlConn)

        cmdInsert.CommandType = CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@codigo", codigo))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

    Public Function ActualizarFechaOficinaAsignacion(fechaAsignacion As String, codOficina As String,
                                                     codDoc As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connection)

        Dim sqlStoredProcedure As String = "PA_ActualizarFechaAsigna"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, sqlConn)

        cmdInsert.CommandType = CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@codigoOficina", codOficina))
        cmdInsert.Parameters.Add(New SqlParameter("@nuevaFecha", fechaAsignacion))
        cmdInsert.Parameters.Add(New SqlParameter("@codigoDoc", codDoc))
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