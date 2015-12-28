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

Public Class Octogonal
    Inherits Placa

    'Atributos
    Shared ReadOnly ESQUEMA_XML As String = My.Resources.XML_SCHEME_OCTOGONAL

    'Constructores
    Public Sub New(ByVal posicion As Punto3D, _
                   ByVal textura As String, _
                   ByVal orientacion As Double)
        Me.posicion = posicion
        Me.textura = textura
        Me.orientacion = orientacion
        Dim ahora = Now
        With Now
            Me.identificador = "octogonal" & .Year & .Month & .Day & .Hour & .Minute & .Second & .Millisecond
        End With
    End Sub
    'Resto de Subprogramas
    Public Overrides Sub GenerarPlaca()
        Dim XML As String = Octogonal.ESQUEMA_XML
        Dim nombreDAE = Me.identificador & ".DAE"
        Dim fechaActual As Date = Now
        With fechaActual
            'Dar formato a la fecha según el estándar: AAAA-MM-DD\THH:MM:SS\Z
            XML = XML.Replace("*FECHA_CREACION*", .Year & "-" & .Month & "-" & .Day & "T" & .Hour & ":" & .Minute & ":" & .Second & "Z")
            XML = XML.Replace("*FECHA_MODIFICACION*", .Year & "-" & .Month & "-" & .Day & "T" & .Hour & ":" & .Minute & ":" & .Second & "Z")
        End With
        XML = XML.Replace("*POSICION_X*", Me.posicion.GetX.ToString.Replace(",", "."))
        XML = XML.Replace("*POSICION_Y*", Me.posicion.GetY.ToString.Replace(",", "."))
        XML = XML.Replace("*POSICION_Z*", Me.posicion.GetZ.ToString.Replace(",", "."))
        XML = XML.Replace("*GROSOR*", Placa.DEFAULT_GROSOR_PLACA.ToString.Replace(",", "."))
        XML = XML.Replace("*TEXTURA*", Me.textura.Replace("Png", "JPG"))
        XML = XML.Replace("*MATERIAL*", Placa.DEFAULT_MATERIAL_PLACA)
        XML = XML.Replace("*PATH_MATERIALES*", EnvironVar.PATH_MATERIALES)
        XML = XML.Replace("*PATH_IMAGENES*", EnvironVar.PATH_IMAGENES)
        If IO.File.Exists(EnvironVar.PATH_EXPORTACION_MODELOS & "\" & nombreDAE) Then
            IO.File.Delete(EnvironVar.PATH_EXPORTACION_MODELOS & "\" & nombreDAE)
        End If
        IO.File.AppendAllText(EnvironVar.PATH_EXPORTACION_MODELOS & "\" & nombreDAE, XML)
    End Sub
End Class
