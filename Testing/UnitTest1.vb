Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports GCA.Domain

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim oficina As New GCA.Domain.Oficina
        oficina = New Oficina
        oficina.Codigo = "1223"
        oficina.Nombre = "Oficina de prueba"
        Console.WriteLine(oficina.Codigo + " - " + oficina.Nombre)
    End Sub

End Class