Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports GCA.Domain

Public Class JefeOficinaDA
    Private connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Function insertarJefeOficina(jefe As JefeOficina) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_InsertarJefeOficina"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)

        cmdInsert.CommandType = CommandType.StoredProcedure


        cmdInsert.Parameters.Add(New SqlParameter("@codigo", jefe.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@dni", jefe.DNI))
        cmdInsert.Parameters.Add(New SqlParameter("@contrasenna", jefe.Contraseña))
        cmdInsert.Parameters.Add(New SqlParameter("@nombre", jefe.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido1", jefe.PrimerApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido2", jefe.SegundoApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@email", jefe.Email))
        cmdInsert.Parameters.Add(New SqlParameter("@codOficina", jefe.Oficina.Codigo))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim respuesta As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return respuesta
    End Function

    Public Function actualizarJefeOficina(jefe As JefeOficina) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ActualizarJefeOficina"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)

        cmdInsert.CommandType = CommandType.StoredProcedure


        cmdInsert.Parameters.Add(New SqlParameter("@codigo", jefe.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@dni", jefe.DNI))
        cmdInsert.Parameters.Add(New SqlParameter("@contrasenna", jefe.Contraseña))
        cmdInsert.Parameters.Add(New SqlParameter("@nombre", jefe.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido1", jefe.PrimerApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@apellido2", jefe.SegundoApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@email", jefe.Email))
        cmdInsert.Parameters.Add(New SqlParameter("@codOficina", jefe.Oficina.Codigo))

        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

    Public Function eliminarJefeOficina(codigo As String) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_EliminarJefeOficina"
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


    Public Function obtenerJefeOficinaCodigo(codigo As String) As Usuario
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "select * from TJefeOficina where TC_Codigo_JefeOficina = '" + codigo + "'"

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsJefeOficina As New DataSet()

        sqlAdpater.Fill(dsJefeOficina, "TJefeOficina")

        sqlAdpater.SelectCommand.Connection.Close()

        Dim dataRowCollection As DataRowCollection = dsJefeOficina.Tables("TJefeOficina").Rows
        Dim jefe As JefeOficina = New JefeOficina()


        For Each currentRow As DataRow In dataRowCollection
            jefe.Codigo = currentRow("TC_Codigo_Usuario").ToString()
            jefe.DNI = currentRow("TC_DNI_Usuario").ToString()
            jefe.Contraseña = currentRow("TC_Contraseña_Usuario").ToString()
            jefe.PrimerApellido = currentRow("TC_PrimerApellido_Usuario").ToString()
            jefe.SegundoApellido = currentRow("TC_SegundoApellido_Usuario").ToString()
            jefe.Email = currentRow("TC_Email_Usuario").ToString()

            Dim ofDA As OficinaDA = New OficinaDA(Me.connectionString)
            jefe.Oficina = ofDA.obtenerOficinaCodigo(currentRow("TC_CodOficina_JefeOficina").ToString())
        Next
        Return jefe
    End Function
    ''' <summary>
    ''' Función que nos permite saber si existe o no un jefe de oficina.
    ''' </summary>
    ''' <param name="codigo">Corresponde al código del jefe de oficina</param>
    ''' <param name="contrasenna">Corresponde a la contraseña del jefe de oficina</param>
    ''' <returns>Integer: 1 si existe y un 0 si no existe</returns>
    Public Function existeJefeOficina(codigo As String, contrasenna As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ExisteJefeOficina"
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

    Public Function existeJefeOficinaV(codigo As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ExisteJefeOficinaV"
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

    Public Function obtenerJefes() As DataSet

        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "SELECT TC_Codigo_JefeOficina, TC_DNI_JefeOficina, TC_Contrasenna_JefeOficina, TC_PrimerApellido_JefeOficina, TC_Nombre_JefeOficina, 
        TC_SegundoApellido_JefeOficina, TC_Email_JefeOficina, TC_Nombre_Oficina,TC_CodOficina_JefeOficina FROM TJefeOficina INNER JOIN  TOficina ON TC_CodOficina_JefeOficina =  TC_Codigo_Oficina "

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsJefes As New DataSet()

        sqlAdpater.Fill(dsJefes)

        sqlAdpater.SelectCommand.Connection.Close()

        Return dsJefes
    End Function

End Class
