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

Imports System.Xml
Imports Señalizacion

Public Class FlyTo

    Private Shared ReadOnly DEFAULT_FLYTOMODE = "smooth"
    Private VueloXML As XmlDocument

    Public Sub New(ByVal duracion As Double,
                   ByVal posicion As PosicionGPS,
                   ByVal altitud As Double,
                   ByVal heading As Double,
                   ByVal tilt As Double,
                   ByVal range As Double)

        Me.VueloXML = New XmlDocument

        Dim gxFlyTo As XmlNode = Me.VueloXML.CreateElement("gx", "FlyTo", My.Resources.KMLGXNameSpace)
        Dim gxDuracion As XmlNode = Me.VueloXML.CreateElement("gx", "duration", My.Resources.KMLGXNameSpace)
        Dim gxFlyToMode As XmlNode = Me.VueloXML.CreateElement("gx", "flyToMode", My.Resources.KMLGXNameSpace)


        Me.VueloXML.AppendChild(gxFlyTo)

        gxDuracion.InnerText = duracion.ToString.Replace(",", ".")
        gxFlyTo.AppendChild(gxDuracion)

        gxFlyToMode.InnerText = DEFAULT_FLYTOMODE
        gxFlyTo.AppendChild(gxFlyToMode)

        Dim vista As New LookAtKML(posicion, altitud, heading, tilt, range)
        gxFlyTo.AppendChild(Me.VueloXML.ImportNode(vista.ToXMLDocumnt.FirstChild, True))

    End Sub
    Public Function ToXMLDocument() As XmlDocument
        Return Me.VueloXML
    End Function

End Class
