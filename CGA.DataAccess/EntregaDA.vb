'Importaciones necesarias
Imports System.Data.SqlClient
Imports GCA.Domain


Public Class EntregaDA

    'Declaración de variables globales
    Private connectionString As String
    ''' <summary>
    ''' Función constructora
    ''' </summary>
    ''' <param name="connectionString"></param>
    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub
    ''' <summary>
    ''' Función que nos permite crear una entrega
    ''' </summary>
    ''' <param name="entrega">Corresponde al objeto entrega que recibimos</param>
    ''' <returns></returns>
    Public Function crearEntrega(entrega As Entrega) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_Realizar_Entrega"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigoC", entrega.Codigo_Control))
        cmdControl.Parameters.Add(New SqlParameter("@codigoO", entrega.Codigo_Oficina))
        cmdControl.Parameters.Add(New SqlParameter("@adjunto", entrega.Adjunto))
        cmdControl.Parameters.Add(New SqlParameter("@periodo", entrega.Periodo_Entrega))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdControl.Parameters.Add(parameterCode)

        cmdControl.Connection.Open()
        Dim respuesta As Integer = cmdControl.ExecuteNonQuery()
        cmdControl.Connection.Close()


        Return respuesta

    End Function
    ''' <summary>
    ''' Función que nos permite obtener las entregas realizadas por control y oficina
    ''' </summary>
    ''' <param name="codOficina">Corresponde al código de oficina por el cuál vamos a buscar</param>
    ''' <param name="codControl">Corresponde al código de control por el cuál vamos a buscar</param>
    ''' <returns></returns>
    Public Function obtenerUltimaEntregaControlOficina(codOficina As String, codControl As String) As DataSet

        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "select TN_Periodo_TEntrega,TF_FechaEntrega_TEntrega from TEntrega where TC_CodOficina_TEntrega = " + codOficina +
                                "AND TC_CodDocControl_TEntrega =" + codControl + "order by TF_FechaEntrega_TEntrega DESC"

        Dim sqlAdpaterBank As New SqlDataAdapter()
        sqlAdpaterBank.SelectCommand = New SqlCommand()
        sqlAdpaterBank.SelectCommand.CommandText = query
        sqlAdpaterBank.SelectCommand.Connection = sqlConn

        Dim dsControl As New DataSet()

        sqlAdpaterBank.Fill(dsControl)

        sqlAdpaterBank.SelectCommand.Connection.Close()

        Return dsControl
    End Function

End Class
