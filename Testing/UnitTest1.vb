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

        Dim eb As New EntregaDA("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        Dim ds As DataSet = eb.obtenerCantidadControlesEntregasCadaOficiaCadaDocControl

        Dim dataRowCollection As DataRowCollection = ds.Tables(0).Rows
        For Each currentRow As DataRow In dataRowCollection
            Console.WriteLine((currentRow(0).ToString()) + " - " + (currentRow(1).ToString) + " - " + currentRow(2).ToString)
        Next
        Console.ReadLine()

        'Dim fechaFinalPeriodo As Date = CDate("05-11-2016")
        'fechaFinalPeriodo.AddDays(7)
        'Dim str As String = fechaFinalPeriodo.ToString()

        'Dim today As System.DateTime
        'Dim answer As System.DateTime

        'today = New System.DateTime(2016, 11, 5)
        'answer = today.AddDays(7)

        'Dim od As OficinaDA = New OficinaDA("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        'Dim out As Integer = od.ActualizarFechaOficinaAsignacion("2016-12-01", "1", "3")

        'Dim oficina As New GCA.Domain.Oficina
        'oficina = New Oficina
        'oficina.Codigo = "7"
        'oficina.Nombre = "Oficina de r"
        'Console.Write(da.actualizarOficina(oficina))
        'Dim control As New GCA.Business.DocControlBusiness("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        'Dim periodoBusiness As New GCA.Business.PeriodoBusiness("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        'Dim periodo = periodoBusiness.obtenerPeriodoCodigo(3)
        'Console.WriteLine(periodo.Dias)
        'Console.Write(control.obtenerPorcentajeFecha("01-11-2016,30"))

        'Dim entrega As New GCA.Business.EntregaBusiness("Data Source=163.178.107.130;Initial Catalog=GCA;Persist Security Info=True;User ID=sqlserver;Password=saucr.12")
        'Dim informacion = entrega.obtenerUltimaEntregaControlOficina("1", "3")

        'For Each fila As DataRow In informacion.Tables(0).Rows()
        '    Console.WriteLine(DatePart(DateInterval.Year, Date.Parse(fila(1))))
        'Next
    End Sub

End Class