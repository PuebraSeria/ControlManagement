Imports System.Data.SqlClient
Imports GCA.Domain



Public Class DocControlDA


    Private connectionString As String
    Private cantidadIncio As Integer = 0, cantidad75 As Integer = 0,
        cantidad90 As Integer = 0, cantidad100 As Integer = 0, cantidadM100 As Integer = 0

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub


    Public Function crearControl(control As DocControl) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_InsertarDocControl"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigo", control.Codigo_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@nombre", control.Nombre_DocControl))
        If (Not String.IsNullOrEmpty(control.FechaFinal_DocControl) Or Not String.IsNullOrEmpty(control.FechaInicio_DocControl)) Then
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", control.FechaInicio_DocControl))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", control.FechaFinal_DocControl))
        Else
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", DirectCast(DBNull.Value, Object)))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", DirectCast(DBNull.Value, Object)))
        End If
        If (control.Periocidad_DocControl.Id = -1) Then
            cmdControl.Parameters.Add(New SqlParameter("@periocidad", DirectCast(DBNull.Value, Object)))
        Else
            cmdControl.Parameters.Add(New SqlParameter("@periocidad", control.Periocidad_DocControl.Id))
        End If
        Dim parameter As New SqlParameter("@estado", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        cmdControl.Parameters.Add(parameter)
        cmdControl.Connection.Open()
        cmdControl.ExecuteNonQuery()

        Dim respuesta As Integer = Int32.Parse(cmdControl.Parameters("@estado").Value.ToString())
        cmdControl.Connection.Close()


        Return respuesta

    End Function


    Public Function actualizarControl(control As DocControl) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_ActualizarDocControl"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigo", control.Codigo_DocControl))
        cmdControl.Parameters.Add(New SqlParameter("@nombre", control.Nombre_DocControl))
        If (Not String.IsNullOrEmpty(control.FechaFinal_DocControl) Or Not String.IsNullOrEmpty(control.FechaInicio_DocControl)) Then
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", control.FechaInicio_DocControl))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", control.FechaFinal_DocControl))
        Else
            cmdControl.Parameters.Add(New SqlParameter("@fechaInicio", DirectCast(DBNull.Value, Object)))
            cmdControl.Parameters.Add(New SqlParameter("@fechaFinal", DirectCast(DBNull.Value, Object)))
        End If
        If (control.Periocidad_DocControl.Id = -1) Then
            cmdControl.Parameters.Add(New SqlParameter("@periocidad", DirectCast(DBNull.Value, Object)))
        Else
            cmdControl.Parameters.Add(New SqlParameter("@periocidad", control.Periocidad_DocControl.Id))
        End If
        Dim parameter As New SqlParameter("@estado", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        cmdControl.Parameters.Add(parameter)
        cmdControl.Connection.Open()
        cmdControl.ExecuteNonQuery()


        Dim respuesta As Integer = Int32.Parse(cmdControl.Parameters("@estado").Value.ToString())
        cmdControl.Connection.Close()


        Return respuesta

    End Function


    Public Function eliminarControl(codigo As Integer) As Integer

        Dim conn As New SqlConnection(Me.connectionString)

        Dim sqlProcedimientoAlmacenado As String = "PA_EliminarDocControl"
        Dim cmdControl As New SqlCommand(sqlProcedimientoAlmacenado, conn)

        cmdControl.CommandType = CommandType.StoredProcedure

        cmdControl.Parameters.Add(New SqlParameter("@codigo", codigo))
        Dim parameter As New SqlParameter("@estado", SqlDbType.Int)
        parameter.Direction = ParameterDirection.Output
        cmdControl.Parameters.Add(parameter)
        cmdControl.Connection.Open()
        cmdControl.ExecuteNonQuery()


        Dim respuesta As Integer = Int32.Parse(cmdControl.Parameters("@estado").Value.ToString())
        cmdControl.Connection.Close()


        Return respuesta

    End Function

    Public Function existeControl(codigo As String) As Integer
        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim sqlStoredProcedure As String = "PA_ExisteControl"
        Dim cmd As New SqlCommand(sqlStoredProcedure, sqlConn)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add(New SqlParameter("@codigo", codigo))
        Dim parameterCode As New SqlParameter("@estado", SqlDbType.Int)
        parameterCode.Direction = ParameterDirection.Output
        cmd.Parameters.Add(parameterCode)

        cmd.Connection.Open()
        cmd.ExecuteNonQuery()


        Dim respuesta As Integer = Int32.Parse(cmd.Parameters("@estado").Value.ToString())

        cmd.Connection.Close()

        Return respuesta
    End Function

    Public Function obtenerControles() As DataSet

        Dim sqlConn As New SqlConnection(Me.connectionString)

        Dim query As String = "select TC_Codigo_DocControl,TC_Nombre_DocControl,	TN_Periocidad_DocControl,
         TC_Nombre_Periodo,	TF_FechaInicio_DocControl,TF_FechaFinal_DocControl from TDocControl Left Join TPeriodo On TN_Periocidad_DocControl = TN_Id_Periodo "

        Dim sqlAdpater As New SqlDataAdapter()
        sqlAdpater.SelectCommand = New SqlCommand()
        sqlAdpater.SelectCommand.CommandText = query
        sqlAdpater.SelectCommand.Connection = sqlConn

        Dim dsControles As New DataSet()

        sqlAdpater.Fill(dsControles)

        sqlAdpater.SelectCommand.Connection.Close()

        Return dsControles
    End Function


    Public Function obtenerInformacionControlesAsignados() As String

        Dim sqlConn As New SqlConnection(Me.connectionString)
        sqlConn.Open()
        Dim cmd As New SqlCommand("PA_InforEstadoControles", sqlConn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim objReader As SqlDataReader = cmd.ExecuteReader()
        Dim infor As String = ""
        While objReader.Read()
            Dim fecha As String = objReader.GetDateTime(0).ToString("dd-MM-yyyy")
            infor += fecha & "," & objReader("CantDias") & ";"
        End While
        sqlConn.Close()
        Return obtenerCantidadPorcentajes(infor)
    End Function




    ''' <summary>
    ''' Funcion que permite identificar en cual porcentaje está el control
    ''' </summary>
    ''' <param name="diferencia_dias">resta de fechas</param>
    ''' <param name="total_dias">cantidad de días que se le asignaron al control</param>
    Public Sub obtenerCantidadesSegunPorcentaje(diferencia_dias As Integer, total_dias As Integer)
        If diferencia_dias <= (total_dias * 0.25) Then
            cantidadIncio += 1
        ElseIf diferencia_dias <= (total_dias * 0.75) Then
            cantidad75 += 1
        ElseIf diferencia_dias <= (total_dias * 0.9) Then
            cantidad90 += 1
        ElseIf diferencia_dias = total_dias Then
            cantidad100 += 1
        ElseIf diferencia_dias > total_dias Then
            cantidadM100 += 1
        ElseIf diferencia_dias > (total_dias * 0.9) Then
            cantidad90 += 1
        End If
    End Sub

    ''' <summary>
    ''' Funcion que obtiene la cantidad de controles que se encuentran en un determinado porcentaje
    ''' </summary>
    ''' <param name="informacion">string con dos parametros fechaAsignacion y Cantidad de días,
    ''' se concatena de la siguinete manera 01/01/2016,90;02/04/2016,60;... (,) para cada atributo (;) cada control</param>
    ''' <returns></returns>
    Public Function obtenerCantidadPorcentajes(informacion As String) As String

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
        Dim infor As [String]() = informacion.Split(";"c)
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
                        ts = fechaActual - fechaInicio
                        diferencia_dias = ts.Days
                        If diferencia_dias > cantDias Then
                            diferencia_dias = cantDias
                        End If
                    ElseIf cantDias > 30 Then
                        Dim fecha_Asignacion As New DateTime(Int32.Parse(partesFecha(2)), Int32.Parse(partesFecha(1)), Int32.Parse(partesFecha(0)))
                        ts = fechaActual - fecha_Asignacion
                        diferencia_dias = ts.Days
                    Else
                        Dim fecha_Asignacion As New DateTime(Int32.Parse(partesFecha(2)), Int32.Parse(partesFecha(1)), 1)
                        ts = fechaActual - fecha_Asignacion
                        diferencia_dias = ts.Days
                    End If


                    ''se obtiene en cual porcentaje está
                    obtenerCantidadesSegunPorcentaje(diferencia_dias, cantDias)
                    ''si es por días o semanales
                ElseIf cantDias < 30 Then
                    fechaInicio = New DateTime(Int32.Parse(partesFecha(2)), Int32.Parse(partesFecha(1)), Int32.Parse(partesFecha(0)))
                    Dim fechaFinalPeriodo As New System.DateTime(Int32.Parse(partesFecha(2)), Int32.Parse(partesFecha(1)), Int32.Parse(partesFecha(0)))
                    fechaFinalPeriodo = fechaFinalPeriodo.AddDays(cantDias)
                    Dim rangoFecha As Integer = fechaFinalPeriodo.Day - fechaActual.Day
                    If fechaFinalPeriodo.Month = fechaActual.Month AndAlso rangoFecha > 0 Then
                        ts = fechaActual - fechaInicio
                        diferencia_dias = ts.Days
                    Else
                        ts = fechaActual - fechaFinalPeriodo
                        diferencia_dias = ts.Days + cantDias
                    End If
                    ''se obtiene en cual porcentaje está
                    obtenerCantidadesSegunPorcentaje(diferencia_dias, cantDias)
                    ''Si es por años
                ElseIf cantDias > 360 Then
                    Dim cantAnnos As Integer = cantDias / 360
                    Dim annAsignacion As Integer = Int32.Parse(partesFecha(2))
                    Dim annoFin As Integer = annAsignacion + (cantAnnos - 1)
                    If (annoFin > annAsignacion) Then
                        Dim fecha_Asignacion As New DateTime(annAsignacion, 1, 1)
                        ts = fechaActual - fecha_Asignacion
                    Else
                        Dim fecha_Asignacion As New DateTime(annoFin, 1, 1)
                        ts = fechaActual - fecha_Asignacion
                    End If
                    diferencia_dias = ts.Days
                    ''se obtiene en cual porcentaje está
                    obtenerCantidadesSegunPorcentaje(diferencia_dias, cantDias)
                End If
            End If
        Next

        Dim informacionRetornar As String = "Asignados recientes," & cantidadIncio & ";Estado 75%," & cantidad75 & ";Estado 90%," & cantidad90 & ";Estado 100%," & cantidad100 & ";Estado +100%," & cantidadM100

        Return informacionRetornar


    End Function





End Class
