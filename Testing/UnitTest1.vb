Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports GCA.Domain
Imports CGA.DataAccess
Imports GCA.Business

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        'Dim oficina As New GCA.Domain.Oficina
        'oficina = New Oficina
        'oficina.Codigo = "1223"
        'oficina.Nombre = "Oficina de prueba"
        'Console.WriteLine(oficina.Codigo + " - " + oficina.Nombre)

        'Dim da As New OficinaDA("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        'Dim f As String = da.obtenerFechaAsignacionControl("1", "1")

        'Dim da As New OficinaDA("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        'Dim ds As DataSet = da.obtenerControlesOficina("1")

        'Dim dataRowCollection As DataRowCollection = ds.Tables(0).Rows
        'For Each currentRow As DataRow In dataRowCollection
        '    Dim pd As New GCA.Domain.DocControl(currentRow(0).ToString(), currentRow(1).ToString(), New Periodo(),
        '                                        currentRow(3).ToString(), currentRow(4).ToString())
        '    Console.WriteLine(pd.ToString())
        'Next
        'Console.ReadLine()
        Dim control As New GCA.Business.DocControlBusiness("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        Dim valores = control.obtenerPorcentajeFecha("18-11-2016,90").Split(";")
        Console.WriteLine(valores(1))
    End Sub

End Class