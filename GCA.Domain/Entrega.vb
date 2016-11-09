Public Class Entrega


    Protected tc_CodOficina_TEntrega As String
    Protected tc_CodDocControl_TEntrega As String
    Protected tf_FechaEntrega_TEntrega As String
    Protected tc_Adjunto_TEntrega As String
    Protected tn_Periodo_TEntrega As String


    Public Sub New()
        Me.tc_CodOficina_TEntrega = ""
        Me.tc_CodDocControl_TEntrega = ""
        Me.tf_FechaEntrega_TEntrega = ""
        Me.tc_Adjunto_TEntrega = ""
        Me.tn_Periodo_TEntrega = ""


    End Sub

    Public Sub New(codigo_oficina As String, codigo_control As String, adjunto As String, periodo As String)
        Me.tc_CodOficina_TEntrega = codigo_oficina
        Me.tc_CodDocControl_TEntrega = codigo_control
        Me.tc_Adjunto_TEntrega = adjunto
        Me.tn_Periodo_TEntrega = periodo


    End Sub



    Public Property Adjunto() As String
        Get
            Return tc_Adjunto_TEntrega
        End Get

        Set
            tc_Adjunto_TEntrega = Value
        End Set
    End Property


    Public Property Fecha_Entrega() As String
        Get
            Return tf_FechaEntrega_TEntrega
        End Get

        Set
            tf_FechaEntrega_TEntrega = Value
        End Set
    End Property


    Public Property Codigo_Oficina() As String
        Get
            Return tc_CodOficina_TEntrega
        End Get

        Set
            tc_CodOficina_TEntrega = Value
        End Set
    End Property

    Public Property Codigo_Control() As String
        Get
            Return tc_CodDocControl_TEntrega

        End Get

        Set
            tc_CodDocControl_TEntrega = Value
        End Set
    End Property

    Public Property Periodo_Entrega() As String
        Get
            Return tn_Periodo_TEntrega

        End Get

        Set
            tn_Periodo_TEntrega = Value
        End Set
    End Property

End Class
