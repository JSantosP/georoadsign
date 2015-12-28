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

Public Class Punto3D

    'Atributos
    Public Const PULGADA = 0.025399999693036079
    Private x As Double = 0.0
    Private y As Double = 0.0
    Private z As Double = 0.0

    'Constructores
    Public Sub New()
        Me.x = 0.0
        Me.y = 0.0
        Me.z = 0.0
    End Sub
    Public Sub New(ByVal x As Double, _
                   ByVal y As Double, _
                   ByVal z As Double)
        Me.x = x
        Me.y = y
        Me.z = z
    End Sub
    'Funciones GET
    Public Function GetX() As Double
        Return Me.x
    End Function
    Public Function GetY() As Double
        Return Me.y
    End Function
    Public Function GetZ() As Double
        Return Me.z
    End Function
    'Procedimientos SET
    Public Sub SetX(ByVal x As Double)
        Me.x = x
    End Sub
    Public Sub SetY(ByVal y As Double)
        Me.y = y
    End Sub
    Public Sub SetZ(ByVal z As Double)
        Me.z = z
    End Sub
    'Resto de subprogramas
    Public Function distanciaAPunto(ByVal pos As Punto3D) As Double
        Return Math.Sqrt(((Me.x - pos.x) ^ 2) + ((Me.y - pos.y) ^ 2))
    End Function
End Class
