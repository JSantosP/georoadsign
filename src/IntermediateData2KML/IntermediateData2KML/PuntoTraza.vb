'GeoRoadSign - Visualizador de señalización 3D
'Copyright (C) 2010  Javier Santos Paniego
'web: http://georoadsign.sourceforge.net/


'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or 
'(at your option) any later version.

'This program is distributed in the hope that it will be useful, 
'but WITHOUT ANY WARRANTY; without even the implied warranty of 
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the 
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License 
'along with this program.  If not, see http://www.gnu.org/licenses/.

Public Class PuntoTraza

    'Atributos
    Private posicionGPS As PosicionGPS
    Private GPSDateTime As Date
    Private CPUDateTime As Date
    Private idEvent As Integer = 0

    'Constructor
    Public Sub New(ByVal posGPS As PosicionGPS,
                   ByVal GPSDateTime As Date,
                   ByVal CPUDateTime As Date,
                   ByVal idEvent As Integer)
        Me.posicionGPS = posGPS
        Me.GPSDateTime = GPSDateTime
        Me.CPUDateTime = CPUDateTime
        Me.idEvent = idEvent
    End Sub

    'Metodos SET
    Public Sub SetPosGPS(ByVal posGPS As PosicionGPS)
        Me.posicionGPS = posGPS
    End Sub
    Public Sub SetGPSDateTime(ByVal gpsDateTime As Date)
        Me.GPSDateTime = gpsDateTime
    End Sub
    Public Sub SetCPUDateTime(ByVal cpuDateTime As Date)
        Me.CPUDateTime = cpuDateTime
    End Sub
    Public Sub SetIdEvent(ByVal idEvent As Integer)
        Me.idEvent = idEvent
    End Sub

    'Metodos GET
    Public Function GetPosGPS() As PosicionGPS
        Return Me.posicionGPS
    End Function
    Public Function GetGPSDateTime() As Date
        Return Me.GPSDateTime
    End Function
    Public Function GetCPUDateTime() As Date
        Return Me.CPUDateTime
    End Function
    Public Function GetIdEvent() As Integer
        Return Me.idEvent
    End Function

End Class
