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

Imports Señalizacion
Imports System.Xml

Public Class LookAtKML
    Private Shared ReadOnly MODO_ALTITUD = "relativeToGround" 'relativeToGround"
    Private VistaXML As XmlDocument

    Public Sub New(ByVal posicionV As PosicionGPS,
                   ByVal altitudV As Double,
                   ByVal headingV As Double,
                   ByVal tiltV As Double,
                   ByVal rangeV As Double)
        VistaXML = New XmlDocument

        Dim root As XmlNode = VistaXML.CreateElement("LookAt")
        VistaXML.AppendChild(root)
        Dim longitud As XmlNode = VistaXML.CreateElement("longitude")
        Dim latitud As XmlNode = VistaXML.CreateElement("latitude")
        Dim altitud As XmlNode = VistaXML.CreateElement("altitude")
        Dim heading As XmlNode = VistaXML.CreateElement("heading")
        Dim tilt As XmlNode = VistaXML.CreateElement("tilt")
        Dim range As XmlNode = VistaXML.CreateElement("range")

        longitud.InnerText = posicionV.GetLongitud.ToString.Replace(",", ".")
        latitud.InnerText = posicionV.GetLatitud.ToString.Replace(",", ".")
        altitud.InnerText = altitudV.ToString.Replace(",", ".")
        heading.InnerText = headingV.ToString.Replace(",", ".")
        tilt.InnerText = tiltV.ToString.Replace(",", ".")
        range.InnerText = rangeV.ToString.Replace(",", ".")

        root.AppendChild(longitud)
        root.AppendChild(latitud)
        root.AppendChild(altitud)
        root.AppendChild(heading)
        root.AppendChild(tilt)
        root.AppendChild(range)

        Dim altitudeMode As XmlNode = VistaXML.CreateElement("altitudeMode")
        altitudeMode.InnerText = MODO_ALTITUD
        root.AppendChild(altitudeMode)

    End Sub

    Public Function ToXMLDocumnt() As XmlDocument
        Return Me.VistaXML
    End Function


End Class
