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
        Return Me.oficinaDA.actualizarOficina(oficina)
    End Function

    'Función que nos permtie eliminar oficinas
    Public Function eliminarOficina(codigo As String) As Integer
        Return Me.oficinaDA.eliminarOficina(codigo)
    End Function

    'Función que le asigna controles a una oficina
    Public Function asignarControl(codigoControl As String, codigoOficina As String, fecha As String) As Integer
        Return Me.oficinaDA.asignarControl(codigoControl, codigoOficina, fecha)
    End Function

    'Función que le desvincula controles a una oficina
    Public Function desvincularControl(codigoControl As String, codigoOficina As String) As Integer
        Return Me.oficinaDA.desvincularControl(codigoControl, codigoOficina)
    End Function
    'Función que retorna una oficina según en código dado 
    Public Function obtenerOficinaCodigo(codigo As String) As Oficina
        Return Me.oficinaDA.obtenerOficinaCodigo(codigo)
    End Function

    Public Function obtenerOficinas() As DataSet
        Return Me.oficinaDA.obtenerOficinas()
    End Function

    Public Function obtenerControlesOficina(codOficina As String) As DataSet
        Return Me.oficinaDA.obtenerControlesOficina(codOficina)
    End Function

    Public Function existeOficina(codigo As String) As Integer
        Return Me.oficinaDA.existeOficina(codigo)
    End Function

End Class