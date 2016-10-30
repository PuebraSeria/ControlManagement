Imports System.Data.SqlClient
Imports GCA.Domain


Public Class EntregaDA


    Private connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub


    Public Function crearEntrega(entrega As Entrega) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_Realizar_Entrega"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigoC", entrega.Codigo_Control))
        cmdControl.Parameters.Add(New SqlParameter("@codigoO", entrega.Codigo_Oficina))
        cmdControl.Parameters.Add(New SqlParameter("@adjunto", entrega.Adjunto))
        cmdControl.Parameters.Add(New SqlParameter("@periodo", entrega.Periodo_Entrega))

        cmdControl.Connection.Open()
        Dim respuesta As Integer = cmdControl.ExecuteNonQuery()
        cmdControl.Connection.Close()


        Return respuesta

    End Function

End Class
