Imports System.Data.SqlClient
Imports GCA.Domain



Public Class DocControlDA


    Private connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub


    Public Function crearControl(control As DocControl) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_InsertarDocControl"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigo", control.Codigo_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@nombre", control.Nombre_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@periocidad", control.Periocidad_DocControl.Id))
        If (Not String.IsNullOrEmpty(control.FechaFinal_DocControl) Or Not String.IsNullOrEmpty(control.FechaInicio_DocControl)) Then
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", control.FechaInicio_DocControl))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", control.FechaFinal_DocControl))
        Else
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", DirectCast(DBNull.Value, Object)))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", DirectCast(DBNull.Value, Object)))
        End If
        Dim parameter As New SqlParameter("@estado", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        cmdControl.Parameters.Add(parameter)
        cmdControl.Connection.Open()
        cmdControl.ExecuteNonQuery()

        Dim respuesta As Integer = Int32.Parse(cmdControl.Parameters("@estado").Value.ToString())
        cmdControl.Connection.Close()


        Return respuesta

    End Function


    Public Function actualizarControl(control As DocControl) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_ActualizarDocControl"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigo", control.Codigo_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@nombre", control.Nombre_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@periocidad", control.Periocidad_DocControl.Id))
        If (Not String.IsNullOrEmpty(control.FechaFinal_DocControl) Or Not String.IsNullOrEmpty(control.FechaInicio_DocControl)) Then
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", control.FechaInicio_DocControl))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", control.FechaFinal_DocControl))
        Else
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", DirectCast(DBNull.Value, Object)))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", DirectCast(DBNull.Value, Object)))
        End If
        Dim parameter As New SqlParameter("@estado", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        cmdControl.Parameters.Add(parameter)
        cmdControl.Connection.Open()
        cmdControl.ExecuteNonQuery()


        Dim respuesta As Integer = Int32.Parse(cmdControl.Parameters("@estado").Value.ToString())
        cmdControl.Connection.Close()


        Return respuesta

    End Function


    Public Function eliminarControl(codigo As Integer) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_EliminarDocControl"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigo", codigo))
        Dim parameter As New SqlParameter("@estado", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        cmdControl.Parameters.Add(parameter)
        cmdControl.Connection.Open()
        cmdControl.ExecuteNonQuery()


        Dim respuesta As Integer = Int32.Parse(cmdControl.Parameters("@estado").Value.ToString())
        cmdControl.Connection.Close()


        Return respuesta

    End Function

    Public Function existeControl(codigo As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ExisteControl"
        Dim cmd As New SqlCommand(sqlStoredProcedure, sqlConn)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add(New SqlParameter("@codigo", codigo))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmd.Parameters.Add(parameterCode)

        cmd.Connection.Open()
        cmd.ExecuteNonQuery()


        Dim respuesta As Integer = Int32.Parse(cmd.Parameters("@estado").Value.ToString())

        cmd.Connection.Close()

        Return respuesta
    End Function

    Public Function obtenerControles() As DataSet

        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "select TC_Codigo_DocControl,TC_Nombre_DocControl,	TN_Periocidad_DocControl,
         TC_Nombre_Periodo,	TF_FechaInicio_DocControl,TF_FechaFinal_DocControl from TDocControl Inner Join TPeriodo On TN_Periocidad_DocControl = TN_Id_Periodo "

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsControles As New DataSet()

        sqlAdpater.Fill(dsControles)

        sqlAdpater.SelectCommand.Connection.Close()

        Return dsControles
    End Function
End Class
