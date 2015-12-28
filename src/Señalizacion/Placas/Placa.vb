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

Public MustInherit Class Placa

    'Atributos
    Public Shared ReadOnly DEFAULT_POSICION_Z_PLACA = 78.74015843190503 'pulgadas (2,0 metros)
    Public Shared ReadOnly DEFAULT_GROSOR_PLACA = 1.5748031686381005 'pulgadas (0,04 metros)
    Public Shared ReadOnly DEFAULT_ALTURA_PLACA = 35.433071294357262 'pulgadas (0,90 metros)
    Public Shared ReadOnly DEFAULT_MATERIAL_PLACA = "aluminio.JPG"

    Protected identificador As String = ""
    Protected posicion As New Punto3D
    Protected textura As String = "Unknown"
    Protected orientacion As Double = 0.0
    'Esta orientacion no es efectiva al construir el modelo.
    'Se usará posteriormente para generar el KML.

    'Constructores
    Public Sub New()

    End Sub
    'Funciones GET
    Public Function GetIdentificador() As String
        Return Me.identificador
    End Function
    Public Function GetPosicion() As Punto3D
        Return Me.posicion
    End Function
    Public Function GetTextura() As String
        Return Me.textura
    End Function
    Public Function GetOrientacion() As Double
        Return Me.orientacion
    End Function
    'Funciones SET
    Public Sub SetPosicion(ByVal posicion As Punto3D)
        Me.posicion = posicion
    End Sub
    Public Sub SetTextura(ByVal textura As String)
        Me.textura = textura
    End Sub
    Public Sub SetOrientacion(ByVal orientacion As Double)
        Me.orientacion = orientacion
    End Sub
    'Resto de Subprogramas
    Public Overridable Sub GenerarPlaca()

    End Sub

End Class
