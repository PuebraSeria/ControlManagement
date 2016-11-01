Public Class DocControl
    Protected tc_Codigo_DocControl As String
    Protected tc_Nombre_DocControl As String
    Protected tn_Periocidad_DocControl As Periodo
    Protected tf_FechaInicio_DocControl As String
    Protected tf_FechaFinal_DocControl As String


    Public Sub New()
        Me.tc_Codigo_DocControl = ""
        Me.tc_Nombre_DocControl = ""
        Me.tn_Periocidad_DocControl = New Periodo()
        Me.tf_FechaInicio_DocControl = ""
        Me.tf_FechaFinal_DocControl = ""

    End Sub

    Public Sub New(codigo As String, nombre As String, periodo As Periodo, fecha_inicio As String, fecha_final As String)
        Me.tc_Codigo_DocControl = codigo
        Me.tc_Nombre_DocControl = nombre
        Me.tn_Periocidad_DocControl = periodo
        Me.tf_FechaInicio_DocControl = fecha_inicio
        Me.tf_FechaFinal_DocControl = fecha_final
    End Sub


    Public Property Periocidad_DocControl() As Periodo
        Get
            Return tn_Periocidad_DocControl

        End Get

        Set
            tn_Periocidad_DocControl = Value
        End Set
    End Property

    Public Property Codigo_DocControl() As String
        Get
            Return tc_Codigo_DocControl
        End Get

        Set
            tc_Codigo_DocControl = Value
        End Set
    End Property

    Public Property Nombre_DocControl() As String
        Get
            Return tc_Nombre_DocControl

        End Get

        Set
            tc_Nombre_DocControl = Value
        End Set
    End Property

    Public Property FechaInicio_DocControl() As String
        Get
            Return tf_FechaInicio_DocControl
        End Get

        Set
            tf_FechaInicio_DocControl = Value
        End Set
    End Property

    Public Property FechaFinal_DocControl() As String
        Get
            Return tf_FechaFinal_DocControl
        End Get

        Set
            tf_FechaFinal_DocControl = Value
        End Set
    End Property
End Class
