Public Class Periodo
    'Declaración de variables
    Private tn_Id_Periodo As Integer
    Private tc_Nombre_Periodo As String

    'Método constructor sin parámetros
    Public Sub New()
        Me.tn_Id_Periodo = 0
        Me.tc_Nombre_Periodo = ""
    End Sub

    'Método constructor con parámetros
    Public Sub New(id As Integer, nombre As String)
        Me.tn_Id_Periodo = id
        Me.tc_Nombre_Periodo = nombre
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
End Class
