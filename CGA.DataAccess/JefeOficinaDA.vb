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
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
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

        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
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
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
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

    Public Function existeJefeOficina(codigo As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ExisteJefeOficina"
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
End Class
