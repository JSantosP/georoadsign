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

Public MustInherit Class ElementoSoporte

    'Atributos
    Protected Const DEFAULT_TEXTURA = "aluminio.JPG"

    Protected identificador As String = "" 'Identificador unívoco. No se puede modificar, se genera en el momento de crear la instancia.
    Protected anchura As Double = 0.0 'PULGADAS
    Protected altura As Double = 0.0 'PULGADAS
    Protected grosor As Double = 0.0 'PULGADAS
    Protected posicion As New Punto3D 'PULGADAS
    Protected textura As String = DEFAULT_TEXTURA 'Nombre del archivo de imagen que contiene la textura

    'Constructores
    Public Sub New()
    End Sub
    'Funciones GET
    Public Function GetAnchura() As Double
        Return Me.anchura
    End Function
    Public Function GetAltura() As Double
        Return Me.altura
    End Function
    Public Function GetGrosor() As Double
        Return Me.grosor
    End Function
    Public Function GetPosicion() As Punto3D
        Return Me.posicion
    End Function
    Public Function GetTextura() As String
        Return Me.textura
    End Function
    Public Function GetIdentificador() As String
        Return Me.identificador
    End Function
    'Procedimientos SET
    Public Sub SetAnchura(ByVal anchura As Double)
        Me.anchura = anchura
    End Sub
    Public Sub SetAltura(ByVal altura As Double)
        Me.altura = altura
    End Sub
    Public Sub SetGrosor(ByVal grosor As Double)
        Me.grosor = grosor
    End Sub
    Public Sub SetPosicion(ByVal posicion As Punto3D)
        Me.posicion = posicion
    End Sub
    Public Sub SetTextura(ByVal textura As String)
        Me.textura = textura
    End Sub
    'Resto de Subprogramas
    Public Overridable Sub GenerarDAE(ByVal PathDestino As String)

    End Sub
End Class