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

Public Class Farola
    Inherits Soporte

    'Atributos
    Private Shared ReadOnly ESQUEMA_XML = My.Resources.XML_SCHEME_FAROLA
    Private identificador As String = ""

    'Constructores
    Public Sub New()
        Dim ahora = Now
        With Now
            Me.identificador = "farola" & .Year & .Month & .Day & .Hour & .Minute & .Second & .Millisecond
        End With
    End Sub
    'funciones GET
    Public Function GetIdentificador()
        Return Me.identificador
    End Function
    'Resto de Subprogramas
    Public Overrides Sub GenerarSoporte()
        Dim XML As String = Farola.ESQUEMA_XML
        Dim nombreDAE = Me.identificador & ".DAE"
        Dim fechaActual As Date = Now
        With fechaActual
            'Dar formato a la fecha según el estándar: AAAA-MM-DD\THH:MM:SS\Z
            XML = XML.Replace("*FECHA_CREACION*", .Year & "-" & .Month & "-" & .Day & "T" & .Hour & ":" & .Minute & ":" & .Second & "Z")
            XML = XML.Replace("*FECHA_MODIFICACION*", .Year & "-" & .Month & "-" & .Day & "T" & .Hour & ":" & .Minute & ":" & .Second & "Z")
        End With
        IO.File.AppendAllText(EnvironVar.PATH_EXPORTACION_MODELOS & "\" & nombreDAE, XML)
    End Sub
    Public Overrides Function GetIdentificadoresElementosSoporte() As System.Collections.Generic.List(Of String)
        Dim listAux As New List(Of String)
        listAux.Add(Me.identificador)
        Return listAux
    End Function
End Class
