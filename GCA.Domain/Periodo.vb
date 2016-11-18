Public Class Periodo
    'Declaración de variables
    Private tn_Id_Periodo As Integer
    Private tc_Nombre_Periodo As String
    Private tn_Dias_Periodo As Integer

    'Método constructor sin parámetros
    Public Sub New()
        Me.tn_Id_Periodo = 0
        Me.tc_Nombre_Periodo = ""
        Me.tn_Dias_Periodo = 0
    End Sub

    'Método constructor con parámetros
    Public Sub New(id As Integer, nombre As String, dias As Integer)
        Me.tn_Id_Periodo = id
        Me.tc_Nombre_Periodo = nombre
        Me.tn_Dias_Periodo = dias
    End Sub

    ' Métodos propiedad Código
    Public Property Id() As Integer
        Get
            Return Me.tn_Id_Periodo
        End Get

        Set
            Me.tn_Id_Periodo = Value
        End Set
    End Property

    ' Métodos propiedad Nombre
    Public Property Nombre() As String
        Get
            Return Me.tc_Nombre_Periodo
        End Get

        Set
            Me.tc_Nombre_Periodo = Value
        End Set
    End Property

    ' Métodos propiedad Nombre
    Public Property Dias() As Integer
        Get
            Return Me.tn_Dias_Periodo
        End Get

        Set
            Me.tn_Dias_Periodo = Value
        End Set
    End Property
End Class
