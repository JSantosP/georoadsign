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

Public Class Travesaño
    Inherits ElementoSoporte
    'Atributos
    Shared ReadOnly ESQUEMA_XML As String = My.Resources.XML_SCHEME_TRAVESAÑO

    'Constructores
    Public Sub New()
        Dim ahora = Now
        With Now
            Me.identificador = "travesaño" & .Year & .Month & .Day & .Hour & .Minute & .Second & .Millisecond
        End With
        Me.anchura = 0.0
        Me.altura = 0.0
        Me.grosor = 0.0
        Me.posicion = New Punto3D
        Me.textura = DEFAULT_TEXTURA
    End Sub
    Public Sub New(ByVal anchura As Double, _
                   ByVal altura As Double, _
                   ByVal grosor As Double, _
                   ByVal posicion As Punto3D, _
                         Optional ByVal textura As String = Travesaño.DEFAULT_TEXTURA)
        Dim ahora = Now
        With Now
            Me.identificador = "travesaño" & .Year & .Month & .Day & .Hour & .Minute & .Second & .Millisecond
        End With
        Me.anchura = anchura
        Me.altura = altura
        Me.grosor = grosor
        Me.posicion = posicion
        Me.textura = textura
    End Sub
    'Resto de Subprogramas
    Public Overrides Sub GenerarDAE(ByVal PathDestino As String)
        Dim XML As String = Travesaño.ESQUEMA_XML
        Dim nombreDAE = Me.identificador & ".DAE"
        Dim fechaActual As Date = Now
        With fechaActual
            'Dar formato a la fecha según el estándar: AAAA-MM-DD\THH:MM:SS\Z
            XML = XML.Replace("*FECHA_CREACION*", .Year & "-" & .Month & "-" & .Day & "T" & .Hour & ":" & .Minute & ":" & .Second & "Z")
            XML = XML.Replace("*FECHA_MODIFICACION*", .Year & "-" & .Month & "-" & .Day & "T" & .Hour & ":" & .Minute & ":" & .Second & "Z")
        End With
        XML = XML.Replace("*ANCHURA*", Me.anchura.ToString.Replace(",", "."))
        XML = XML.Replace("*ALTURA*", Me.altura.ToString.Replace(",", "."))
        XML = XML.Replace("*GROSOR*", Me.grosor.ToString.Replace(",", "."))
        XML = XML.Replace("*POSICION_X*", Me.posicion.GetX.ToString.Replace(",", "."))
        XML = XML.Replace("*POSICION_Y*", Me.posicion.GetY.ToString.Replace(",", "."))
        XML = XML.Replace("*POSICION_Z*", Me.posicion.GetZ.ToString.Replace(",", "."))
        XML = XML.Replace("*MATERIAL*", Me.textura)
        XML = XML.Replace("*PATH_MATERIALES*", EnvironVar.PATH_MATERIALES)
        If IO.File.Exists(PathDestino & "\" & nombreDAE) Then
            IO.File.Delete(PathDestino & "\" & nombreDAE)
        End If
        IO.File.AppendAllText(PathDestino & "\" & nombreDAE, XML)
    End Sub
End Class
