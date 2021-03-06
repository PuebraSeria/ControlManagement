﻿Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports GCA.Domain

Public Class SupervisorDA
    Private connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Function insertarSupervisor(supervisor As Supervisor) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_InsertarSupervisor"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)

        cmdInsert.CommandType = CommandType.StoredProcedure


        cmdInsert.Parameters.Add(New SqlParameter("@codigo", supervisor.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@dni", supervisor.DNI))
        cmdInsert.Parameters.Add(New SqlParameter("@contrasenna", supervisor.Contraseña))
        cmdInsert.Parameters.Add(New SqlParameter("@nombre", supervisor.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido1", supervisor.PrimerApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido2", supervisor.SegundoApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@email", supervisor.Email))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

    Public Function actualizarSupervisor(supervisor As Supervisor) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ActualizarSupervisor"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)

        cmdInsert.CommandType = CommandType.StoredProcedure


        cmdInsert.Parameters.Add(New SqlParameter("@codigo", supervisor.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@dni", supervisor.DNI))
        cmdInsert.Parameters.Add(New SqlParameter("@contrasenna", supervisor.Contraseña))
        cmdInsert.Parameters.Add(New SqlParameter("@nombre", supervisor.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido1", supervisor.PrimerApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido2", supervisor.SegundoApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@email", supervisor.Email))

        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

    Public Function eliminarSupervisor(codigo As String) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_EliminarSupervisor"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)

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


    Public Function obtenerSupervisorCodigo(codigo As String) As Supervisor
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "select * from TSupervisor where TC_Codigo_Supervisor = '" + codigo + "'"

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsSupervisor As New DataSet()

        sqlAdpater.Fill(dsSupervisor, "TSupervisor")

        sqlAdpater.SelectCommand.Connection.Close()

        Dim dataRowCollection As DataRowCollection = dsSupervisor.Tables("TSupervisor").Rows
        Dim supervisor As Supervisor = New Supervisor()


        For Each currentRow As DataRow In dataRowCollection
            supervisor.Codigo = currentRow("TC_Codigo_Supervisor").ToString()
            supervisor.DNI = currentRow("TC_DNI_Supervisor").ToString()
            supervisor.Contraseña = currentRow("TC_Contrasenna_Supervisor").ToString()
            supervisor.PrimerApellido = currentRow("TC_PrimerApellido_Supervisor").ToString()
            supervisor.SegundoApellido = currentRow("TC_SegundoApellido_Supervisor").ToString()
            supervisor.Email = currentRow("TC_Email_Supervisor").ToString()

        Next
        Return supervisor
    End Function
    ''' <summary>
    ''' Función que nos permite saber si existe o no un supervisor
    ''' </summary>
    ''' <param name="codigo">Corresponde al código del supervisor</param>
    ''' <param name="contrasenna">Corresponde a la contraseña del supervisor</param>
    ''' <returns>Integer: 0 si no existe y un 1 si existe</returns>
    Public Function existeSupervisor(codigo As String, contrasenna As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ExisteSupervisor"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, sqlConn)

        cmdInsert.CommandType = CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@codigo", codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@contrasenna", contrasenna))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

    Public Function existeSupervisorV(codigo As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ExisteSupervisorV"
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


    Public Function obtenerSupervisores() As DataSet

        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "SELECT * From TSupervisor"

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsSupervisor As New DataSet()

        sqlAdpater.Fill(dsSupervisor)

        sqlAdpater.SelectCommand.Connection.Close()

        Return dsSupervisor
    End Function

End Class

