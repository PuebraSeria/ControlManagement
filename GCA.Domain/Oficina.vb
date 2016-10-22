Public Class Oficina
  'Declaración de variables
  Private tc_CodigoValue As String
  Private tc_NombreValue As String
  
  'Método constructor sin parámetros
  Public Sub New()
    Me.tc_CodigoValue = ""
    Me.tc_NombreValue = ""
  End Sub
  
  'Método constructor con parámetros
  Public Sub New(codigo As String, nombre As String)
    Me.tc_CodigoValue = codigo
    Me.tc_NombreValue = nombre
  End Sub
  
  ' Métodos propiedad Código
  Public Property Codigo() As String
    Get
      Return Me.tc_CodigoValue
    End Get
    
    Set
      Me.tc_CodigoValue = Value
    End Set
  End Property

    ' Métodos propiedad Nombre
    Public Property Nombre() As String
        Get
            Return Me.tc_NombreValue
        End Get

        Set
            Me.tc_NombreValue = Value
        End Set
    End Property
End Class
