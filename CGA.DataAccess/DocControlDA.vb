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
        cmdControl.Parameters.Add(New SqlParameter("@periocidad", control.Periocidad_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", control.FechaInicio_DocControl))

        cmdControl.Connection.Open()
        Dim respuesta As Integer = cmdControl.ExecuteNonQuery()
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
        cmdControl.Parameters.Add(New SqlParameter("@periocidad", control.Periocidad_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", control.FechaInicio_DocControl))

        cmdControl.Connection.Open()
        Dim respuesta As Integer = cmdControl.ExecuteNonQuery()
        cmdControl.Connection.Close()


        Return respuesta

    End Function


    Public Function eliminarControl(codigo As Integer) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_EliminarDocControl"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigo", codigo))

        cmdControl.Connection.Open()
        Dim respuesta As Integer = cmdControl.ExecuteNonQuery()
        cmdControl.Connection.Close()


        Return respuesta

    End Function




End Class
