Public Class DocControl
    Protected tc_Codigo_DocControl As String
    Protected tc_Nombre_DocControl As String
    Protected tn_Periocidad_DocControl As Integer
    Protected tf_FechaInicio_DocControl As String
    

    Public Sub New()
        Me.tc_Codigo_DocControl = ""
        Me.tc_Nombre_DocControl = ""
        Me.tn_Periocidad_DocControl = 0
        Me.tf_FechaInicio_DocControl = ""
       
    End Sub

    Public Sub New(codigo As String, nombre As String, cantidad As Integer, fecha_inicio As String)
        Me.tc_Codigo_DocControl = codigo
        Me.tc_Nombre_DocControl = nombre
        Me.tn_Periocidad_DocControl = cantidad
        Me.tf_FechaInicio_DocControl = fehca_inicio      
    End Sub


    Public Property tn_Periocidad_DocControl() As Integer
        Get
            Return tn_Periocidad_DocControl

        End Get

        Set
            tn_Periocidad_DocControl = Value
        End Set
    End Property

    Public Property tc_Codigo_DocControl() As String
        Get
            Return tc_Codigo_DocControl
        End Get

        Set
            tc_Codigo_DocControl = Value
        End Set
    End Property

    Public Property tc_Nombre_DocControl() As String
        Get
            Return tc_Nombre_DocControl

        End Get

        Set
            tc_Nombre_DocControl = Value
        End Set
    End Property

    Public Property tf_FechaInicio_DocControl() As String
        Get
            Return tf_FechaInicio_DocControl
        End Get

        Set
            tf_FechaInicio_DocControl = Value
        End Set
    End Property

End Class
