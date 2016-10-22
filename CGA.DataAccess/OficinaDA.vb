﻿'Importaciones necesarias
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
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
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
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
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
    Public Function eliminarOficina(codigo As Integer) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_EliminarOficina"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@codigo", codigo))

        'Variables que retorna
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
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
    Public Function asignarControl(codigoControl As Integer, codigoOficina As Integer, elimina As Integer) As Integer
        Dim connectionSQL As New SqlConnection(Me.connection)
        Dim sqlStoredProcedure As String = "PA_AsignarOficina_Control"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connectionSQL)

        cmdInsert.CommandType = CommandType.StoredProcedure

        'Variables que recibe
        cmdInsert.Parameters.Add(New SqlParameter("@codigoC", codigoControl))
        cmdInsert.Parameters.Add(New SqlParameter("@codigoO", codigoOficina))
        cmdInsert.Parameters.Add(New SqlParameter("@elimina", elimina))

        'Variables que retorna
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
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
End Class