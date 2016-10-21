Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports GCA.Domain

Public Class UsuarioDa
    Private connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Function insertarUsuario(usuario As Usuario) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_InsertarUsuario"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)

        cmdInsert.CommandType = CommandType.StoredProcedure


        cmdInsert.Parameters.Add(New SqlParameter("@TC_Codigo_Usuario", usuario.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_DNI_Usuario", usuario.DNI))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_Contraseña_Usuario", usuario.Contraseña))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_Nombre_Usuario", usuario.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_PrimerApellido_Usuario", usuario.PrimerApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_SegundoApellido_Usuario", usuario.SegundoApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@TB_EsSupervisor_Usuario", usuario.EsSupervisor))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_Email_Usuario", usuario.Email))
        'cmdInsert.Parameters.Add(New SqlParameter("@TC_CodOficina_Usuario", usuario.Oficina))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@idClient").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

    Public Function actualizarUsuario(usuario As Usuario) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ActualizarUsuario"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)

        cmdInsert.CommandType = CommandType.StoredProcedure


        cmdInsert.Parameters.Add(New SqlParameter("@TC_Codigo_Usuario", usuario.Codigo))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_DNI_Usuario", usuario.DNI))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_Contraseña_Usuario", usuario.Contraseña))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_Nombre_Usuario", usuario.Nombre))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_PrimerApellido_Usuario", usuario.PrimerApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_SegundoApellido_Usuario", usuario.SegundoApellido))
        cmdInsert.Parameters.Add(New SqlParameter("@TB_EsSupervisor_Usuario", usuario.EsSupervisor))
        cmdInsert.Parameters.Add(New SqlParameter("@TC_Email_Usuario", usuario.Email))
        'cmdInsert.Parameters.Add(New SqlParameter("@TC_CodOficina_Usuario", usuario.Oficina))

        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Bit)
        parameterCode.Direction = ParameterDirection.Output
        cmdInsert.Parameters.Add(parameterCode)

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()


        Dim answer As Integer = Int32.Parse(cmdInsert.Parameters("@estado").Value.ToString())

        cmdInsert.Connection.Close()

        Return answer
    End Function

    Public Function eliminarCliente(codigo As Integer) As Integer
        Dim connection As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_EliminarUsuario"
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


    Public Function obtenerUsuarioCodigo(codigo As String) As Usuario
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "select * from TUsuario where TC_Codigo_Usuario = '" + codigo + "'"

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsUsuario As New DataSet()

        sqlAdpater.Fill(dsUsuario, "TUsuario")

        sqlAdpater.SelectCommand.Connection.Close()

        Dim dataRowCollection As DataRowCollection = dsUsuario.Tables("TUsuario").Rows
        Dim usuario As Usuario = New Usuario()

        For Each currentRow As DataRow In dataRowCollection
            usuario.Codigo = currentRow("TC_Codigo_Usuario").ToString()
            usuario.DNI = currentRow("TC_DNI_Usuario").ToString()
            usuario.Contraseña = currentRow("TC_Contraseña_Usuario").ToString()
            usuario.PrimerApellido = currentRow("TC_PrimerApellido_Usuario").ToString()
            usuario.SegundoApellido = currentRow("TC_SegundoApellido_Usuario").ToString()
            usuario.EsSupervisor = currentRow("TB_EsSupervisor_Usuario").ToString()
            usuario.Email = currentRow("TC_Email_Usuario").ToString()
            'usuario.Oficina = currentRow("TC_CodOficina_Usuario").ToString()
        Next

        Return usuario
    End Function
End Class
