Public Class Usuario
    Protected m_codigo As String
    Protected m_contraseña As String
    Protected m_dni As Integer
    Protected m_nombre As String
    Protected m_primerApellido As String
    Protected m_segundoApellido As String
    Protected m_email As String
    Protected m_esSupervisor As Boolean
    Protected m_oficina As Oficina



    Public Sub New()
        Me.m_codigo = ""
        Me.m_contraseña = ""
        Me.m_dni = 0
        Me.m_nombre = ""
        Me.m_primerApellido = ""
        Me.m_segundoApellido = ""
        Me.m_email = ""
        Me.m_esSupervisor = False
        Me.m_oficina = New Oficina()

    End Sub

    Public Sub New(codigo As String, contraseña As String, dni As Integer, nombre As String, primerApellido As String, segundoApellido As String, email As String, esSupervisor As Boolean,
                   oficina As Oficina)
        Me.m_codigo = codigo
        Me.m_contraseña = contraseña
        Me.m_dni = dni
        Me.m_nombre = nombre
        Me.m_primerApellido = primerApellido
        Me.m_segundoApellido = segundoApellido
        Me.m_email = email
        Me.m_esSupervisor = esSupervisor
        Me.m_oficina = oficina

    End Sub


    Public Property Codigo() As Integer
        Get
            Return m_codigo

        End Get

        Set
            m_codigo = Value
        End Set
    End Property

    Public Property Contraseña() As String
        Get
            Return m_contraseña
        End Get

        Set
            m_contraseña = Value
        End Set
    End Property

    Public Property DNI() As String
        Get
            Return m_dni

        End Get

        Set
            m_dni = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return m_nombre
        End Get

        Set
            m_nombre = Value
        End Set
    End Property

    Public Property PrimerApellido() As String
        Get
            Return m_primerApellido

        End Get

        Set
            m_primerApellido = Value
        End Set
    End Property

    Public Property SegundoApellido() As String
        Get
            Return m_segundoApellido
        End Get

        Set
            m_segundoApellido = Value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return m_email
        End Get

        Set
            m_email = Value
        End Set
    End Property

    Public Property EsSupervisor() As Boolean
        Get
            Return m_esSupervisor
        End Get

        Set
            m_esSupervisor = Value
        End Set
    End Property

    Public Property Oficina() As Oficina
        Get
            Return m_oficina
        End Get

        Set
            m_oficina = Value
        End Set
    End Property


End Class
