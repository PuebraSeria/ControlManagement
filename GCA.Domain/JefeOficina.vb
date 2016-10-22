Public Class JefeOficina
    Inherits Usuario

    Protected jo_oficina As Oficina



    Public Sub New()
        MyBase.New()
        Me.jo_oficina = New Oficina()

    End Sub

    Public Sub New(codigo As String, contraseña As String, dni As Integer, nombre As String, primerApellido As String, segundoApellido As String, email As String, oficina As Oficina)
        MyBase.New(codigo, contraseña, dni, nombre, primerApellido, segundoApellido, email)
        Me.jo_oficina = oficina
    End Sub


    Public Property Oficina() As Oficina
        Get
            Return jo_oficina

        End Get

        Set
            jo_oficina = Value
        End Set
    End Property

End Class
