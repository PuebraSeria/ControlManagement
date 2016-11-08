
Imports CGA.DataAccess
Imports GCA.Domain

Public Class DocControlBusiness


    Private connString As String
    Private control As DocControlDA


    Public Sub New(conn As String)
        Me.connString = conn
        Me.control = New DocControlDA(Me.connString)
    End Sub

    Public Function crearControl(control As DocControl) As Integer

        Return Me.control.crearControl(control)

    End Function

    Public Function actualizarControl(control As DocControl) As Integer

        Return Me.control.actualizarControl(control)

    End Function

    Public Function eliminarControl(codigo As String) As Integer

        Return Me.control.eliminarControl(codigo)

    End Function

    Public Function existeControl(codigo As String) As Integer
        Return Me.control.existeControl(codigo)
    End Function

    Public Function obtenerControles() As DataSet
        Return Me.control.obtenerControles()
    End Function

    Public Function obtenerInformacionControlesAsignados() As String
        Return Me.control.obtenerInformacionControlesAsignados()
    End Function

    ''' <summary>
    ''' Funcion que permite identificar en cual porcentaje está el control
    ''' </summary>
    ''' <param name="diferencia_dias">resta de fechas</param>
    ''' <param name="total_dias">cantidad de días que se le asignaron al control</param>
    ''' <returns>Un entero indicando el porcentaje actual:
    ''' 0: 0%,verde
    ''' 1: 75%, amarillo
    ''' 2: 90%, anaranjado
    ''' 3: 100%, rojo
    ''' 4:+100%, morado</returns>
    Public Function obtenerCantidadPorcentaje(diferencia_dias As Integer, total_dias As Integer) As Integer
        Dim porcentaje As Integer = 0
        If diferencia_dias <= (total_dias * 0.25) Then
            porcentaje = 0
        ElseIf diferencia_dias <= (total_dias * 0.75) Then
            porcentaje = 1
        ElseIf diferencia_dias <= (total_dias * 0.9) Then
            porcentaje = 2
        ElseIf diferencia_dias = total_dias Then
            porcentaje = 3
        ElseIf diferencia_dias > total_dias Then
            porcentaje = 4
        ElseIf diferencia_dias > (total_dias * 0.9) Then
            porcentaje = 2
        End If
        Return porcentaje
    End Function

    ''' <summary>
    ''' Funcion que obtiene la cantidad de controles que se encuentran en un determinado porcentaje
    ''' </summary>
    ''' <param name="informacion">string con dos parametros fechaAsignacion y Cantidad de días,
    ''' se concatena de la siguinete manera 01/01/2016,90;02/04/2016,60;... (,) para cada atributo (;) cada control</param>
    ''' <returns></returns>
    Public Function obtenerPorcentajeFecha(informacion As String) As String

        'Se obtiene el periodo actual del año
        Dim fechaActual As DateTime = DateTime.Now
        Dim fechaInicio As DateTime
        Dim ts As TimeSpan
        Dim periodo As Integer
        Dim diferencia_dias As Integer
        Dim mesInicioPeriodo As Integer = 0, mesFinalPeriodo As Integer = 0
        Dim cantDias As Integer
        Dim mesActual As Integer = DateTime.Now.Month
        Dim annoActual As Integer = DateTime.Now.Year
        Dim porcentajeActual As Integer = 0
        Dim infor As [String]() = informacion.Split(";"c)
        Dim fechaEntrega As DateTime

        For i As Integer = 0 To infor.Length - 1
            Dim parametros As [String]() = infor(i).Split(","c)
            If parametros(0).Length > 2 Then
                Dim partesFecha As [String]() = parametros(0).Split("-"c)
                cantDias = Int32.Parse(parametros(1))

                ''si es mensual en adelante 
                If cantDias >= 30 And cantDias < 360 Then
                    Dim cantMeses As Integer = cantDias / 30
                    Dim cantPeriodos As Integer = 12 / cantMeses
                    periodo = cantMeses
                    ''se obtiene el periodo
                    While periodo < mesActual
                        periodo += cantMeses
                    End While
                    'periodo actual
                    periodo /= cantMeses

                    'Obtengo el mes inicio y final del periodo actual
                    mesFinalPeriodo = (periodo * cantMeses)
                    mesInicioPeriodo = (mesFinalPeriodo - (cantMeses - 1))

                    'mes de asignacion < mesInicioPeriodo
                    If Int32.Parse(partesFecha(1)) >= mesInicioPeriodo AndAlso Int32.Parse(partesFecha(1)) <= mesFinalPeriodo Then
                        fechaInicio = New DateTime(annoActual, mesInicioPeriodo, 1)
                        fechaEntrega = DateAdd(DateInterval.Month, 1, fechaInicio)
                        ts = fechaActual - fechaInicio
                        diferencia_dias = ts.Days
                        If diferencia_dias > cantDias Then
                            diferencia_dias = cantDias
                        End If
                    Else
                        Dim fecha_Asignacion As New DateTime(Int32.Parse(partesFecha(2)), Int32.Parse(partesFecha(1)), Int32.Parse(partesFecha(0)))
                        ts = fechaActual - fecha_Asignacion
                        diferencia_dias = ts.Days
                    End If
                    ''se obtiene en cual porcentaje está
                    porcentajeActual = obtenerCantidadPorcentaje(diferencia_dias, cantDias)

                    ''si es por días o semanales
                ElseIf cantDias < 30 Then
                    fechaInicio = New DateTime(Int32.Parse(partesFecha(2)), Int32.Parse(partesFecha(1)), Int32.Parse(partesFecha(0)))
                    Dim fechaFinalPeriodo As New System.DateTime(Int32.Parse(partesFecha(2)), Int32.Parse(partesFecha(1)), Int32.Parse(partesFecha(0)))
                    fechaFinalPeriodo = fechaFinalPeriodo.AddDays(cantDias)
                    fechaEntrega = fechaFinalPeriodo
                    Dim rangoFecha As Integer = fechaFinalPeriodo.Day - fechaActual.Day
                    If fechaFinalPeriodo.Month = fechaActual.Month AndAlso rangoFecha > 0 Then
                        ts = fechaActual - fechaInicio
                        diferencia_dias = ts.Days
                    Else
                        ts = fechaActual - fechaFinalPeriodo
                        diferencia_dias = ts.Days + cantDias
                    End If
                    ''se obtiene en cual porcentaje está
                    porcentajeActual = obtenerCantidadPorcentaje(diferencia_dias, cantDias)

                    ''Si es por años
                ElseIf cantDias > 360 Then
                    Dim cantAnnos As Integer = cantDias / 360
                    Dim annAsignacion As Integer = Int32.Parse(partesFecha(2))
                    Dim annoFin As Integer = annAsignacion + (cantAnnos - 1)
                    If (annoFin > annAsignacion) Then
                        Dim fecha_Asignacion As New DateTime(annAsignacion, 1, 1)
                        fechaEntrega = DateAdd(DateInterval.Year, 1, fecha_Asignacion)
                        ts = fechaActual - fecha_Asignacion
                    Else
                        Dim fecha_Asignacion As New DateTime(annoFin, 1, 1)
                        fechaEntrega = DateAdd(DateInterval.Year, 1, fecha_Asignacion)
                        ts = fechaActual - fecha_Asignacion
                    End If
                    diferencia_dias = ts.Days
                    ''se obtiene en cual porcentaje está
                    porcentajeActual = obtenerCantidadPorcentaje(diferencia_dias, cantDias)
                End If
            End If
        Next

        Dim informacionRetornar As String = porcentajeActual & ";" & fechaEntrega

        Return informacionRetornar
    End Function
End Class
