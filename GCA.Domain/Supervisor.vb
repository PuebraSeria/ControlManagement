Public Class Supervisor
    Inherits Usuario

    Public Sub New()
        MyBase.New()


    End Sub

    Public Sub New(codigo As String, contraseña As String, dni As Integer, nombre As String, primerApellido As String, segundoApellido As String, email As String)
        MyBase.New(codigo, contraseña, dni, nombre, primerApellido, segundoApellido, email)

    End Sub

End Class
