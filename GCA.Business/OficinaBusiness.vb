'Importaciones necesarias
Imports CGA.DataAccess
Imports GCA.Domain

Public Class OficinaBusiness
    'Declaración de variables globales
    Private connection As String
    Private oficinaDA As OficinaDA

    'Método constructor
    Public Sub New(connection As String)
        Me.oficinaDA = New OficinaDA(connection)
    End Sub

    ' Método que nos permite insertar oficina
    Public Function insertarOficina(oficina As Oficina) As Integer
        Return Me.oficinaDA.insertarOficina(oficina)
    End Function

    'Método que nos permite actualizar una oficina
    Public Function actualizarOficina(oficina As Oficina) As Integer
        Return Me.oficinaDA.insertarOficina(oficina)
    End Function

    'Función que nos permtie eliminar oficinas
    Public Function eliminarOficina(codigo As Integer) As Integer
        Return Me.oficinaDA.eliminarOficina(codigo)
    End Function

    'Función que le asigna controles a una oficina
    Public Function asignarControl(codigoControl As Integer, codigoOficina As Integer, elimina As Integer) As Integer
        Return Me.oficinaDA.asignarControl(codigoControl, codigoOficina, elimina)
    End Function
End Class
