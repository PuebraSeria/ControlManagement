Public Class Usuario
    Protected u_codigo As String
    Protected u_contraseña As String
    Protected u_dni As Integer
    Protected u_nombre As String
    Protected u_primerApellido As String
    Protected u_segundoApellido As String
    Protected u_email As String



    Public Sub New()
        Me.u_codigo = ""
        Me.u_contraseña = ""
        Me.u_dni = 0
        Me.u_nombre = ""
        Me.u_primerApellido = ""
        Me.u_segundoApellido = ""
        Me.u_email = ""

    End Sub

    Public Sub New(codigo As String, contraseña As String, dni As Integer, nombre As String, primerApellido As String, segundoApellido As String, email As String)
        Me.u_codigo = codigo
        Me.u_contraseña = contraseña
        Me.u_dni = dni
        Me.u_nombre = nombre
        Me.u_primerApellido = primerApellido
        Me.u_segundoApellido = segundoApellido
        Me.u_email = email

    End Sub


    Public Property Codigo() As Integer
        Get
            Return u_codigo

        End Get

        Set
            u_codigo = Value
        End Set
    End Property

    Public Property Contraseña() As String
        Get
            Return u_contraseña
        End Get

        Set
            u_contraseña = Value
        End Set
    End Property

    Public Property DNI() As String
        Get
            Return u_dni

        End Get

        Set
            u_dni = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return u_nombre
        End Get

        Set
            u_nombre = Value
        End Set
    End Property

    Public Property PrimerApellido() As String
        Get
            Return u_primerApellido

        End Get

        Set
            u_primerApellido = Value
        End Set
    End Property

    Public Property SegundoApellido() As String
        Get
            Return u_segundoApellido
        End Get

        Set
            u_segundoApellido = Value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return u_email
        End Get

        Set
            u_email = Value
        End Set
    End Property


End Class
