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

Imports System.Math

Public Class Rotacion

    Public Shared Function ToRadians(ByVal anguloSexa As Double) As Double
        Return (anguloSexa * PI / 180)
    End Function

    Public Shared Function ToDegrees(ByVal anguloRad As Double) As Double
        Return (anguloRad * 180 / PI)
    End Function

    Public Shared Function modulo360(ByVal anguloRad As Double) As Double
        Dim ret As Double = anguloRad
        If anguloRad > (2 * PI) Then
            ret = anguloRad - (2 * PI)
        ElseIf anguloRad < 0 Then
            ret = (2 * PI) - Abs(ret)
        End If
        Return ret
    End Function

    Public Shared Function ToAzimut(ByVal anguloRadianes As Double,
                                             Optional ByVal incremento As Double = 0) As Double

        'Pasamos a grados sexagesimales para hacer calculos más comodamente
        Dim ret As Double = anguloRadianes * 180 / Math.PI

        'restamos 90º por la rotación del origen de los grados acicutales de Google
        ret = ret - 90

        'Hallamos el ángulo complementario en caso de ser menor que 0.0
        If ret < 0.0 Then
            ret = 360 - Math.Abs(ret)
        End If
        ret = 360 - ret

        'Sumamos el incremento
        ret = ret + (incremento * 180 / Math.PI)

        'Si pasa de 360 hallamos el angulo complementario
        If ret > 360 Then
            ret = ret - 360
        End If

        'Devolvemos el resultado en Radianes
        Return (ret * Math.PI / 180)
    End Function
End Class

