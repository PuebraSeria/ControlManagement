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
End Class
