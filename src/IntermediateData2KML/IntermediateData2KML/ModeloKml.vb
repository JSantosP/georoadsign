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

Public Class ModeloKml

    Public Shared ReadOnly DISTANCIA_VISTA_MODELO = 3 'metros
    Private modelo As XmlDocument

    Public Sub New(ByVal nombreModelo As String, _
                   ByVal posicionGPS As PosicionGPS, _
                   ByVal orientacion As Double, _
                   ByVal pathFicheroDAE As String, _
                   ByVal pathTexturas As List(Of String))

        'Declaración de elementos del XML

        modelo = New XmlDocument()

        Dim placeMark As XmlNode = modelo.CreateElement("Placemark")
        Dim nombre As XmlNode = modelo.CreateElement("name")
        Dim visibilidad As XmlNode = modelo.CreateElement("visibility")
        Dim longitud As XmlNode = modelo.CreateElement("longitude")
        Dim latitud As XmlNode = modelo.CreateElement("latitude")
        Dim altitud As XmlNode = modelo.CreateElement("altitude")
        Dim heading As XmlNode = modelo.CreateElement("heading")
        Dim tilt As XmlNode = modelo.CreateElement("tilt")
        Dim idModelo As XmlNode = modelo.CreateElement("Model")
        Dim location As XmlNode = modelo.CreateElement("Location")
        Dim orientation As XmlNode = modelo.CreateElement("Orientation")
        Dim roll As XmlNode = modelo.CreateElement("roll")
        Dim scale As XmlNode = modelo.CreateElement("Scale")
        Dim x As XmlNode = modelo.CreateElement("x")
        Dim y As XmlNode = modelo.CreateElement("y")
        Dim z As XmlNode = modelo.CreateElement("z")
        Dim link As XmlNode = modelo.CreateElement("Link")
        Dim href As XmlNode = modelo.CreateElement("href")
        Dim resourceMap As XmlNode = modelo.CreateElement("ResourceMap")

        'Construimos el nodo del modelo


        modelo.AppendChild(placeMark)
        nombre.InnerText = nombreModelo
        placeMark.AppendChild(nombre)
        visibilidad.InnerText = "1" 'True
        placeMark.AppendChild(visibilidad)

        Dim vista As New LookAtKML(posicionGPS, 0, 0, 0, DISTANCIA_VISTA_MODELO)
        placeMark.AppendChild(Me.modelo.ImportNode(vista.ToXMLDocumnt.FirstChild, True))

        Dim idModeloAttr As XmlAttribute = modelo.CreateAttribute("id")
        idModeloAttr.Value = nombreModelo
        idModelo.Attributes.Append(idModeloAttr)
        placeMark.AppendChild(idModelo)

        longitud.InnerText = posicionGPS.GetLongitud.ToString.Replace(",", ".")
        latitud.InnerText = posicionGPS.GetLatitud.ToString.Replace(",", ".")
        altitud.InnerText = "0"

        idModelo.AppendChild(location)
        location.AppendChild(longitud)
        location.AppendChild(latitud)
        location.AppendChild(altitud)
        idModelo.AppendChild(orientation)
        heading.InnerText = (orientacion * 180 / Math.PI).ToString.Replace(",", ".")
        tilt.InnerText = "0"
        roll.InnerText = "0"

        orientation.AppendChild(heading)
        orientation.AppendChild(tilt)
        orientation.AppendChild(roll)

        idModelo.AppendChild(scale)
        x.InnerText = "1"
        y.InnerText = "1"
        z.InnerText = "1"

        scale.AppendChild(x)
        scale.AppendChild(y)
        scale.AppendChild(z)

        idModelo.AppendChild(link)
        href.InnerText = pathFicheroDAE
        link.AppendChild(href)

        idModelo.AppendChild(resourceMap)

        'Por cada textura hay que generar 1 nodo hijo de nombre 'Alias'

        For Each textura As String In pathTexturas
            Dim aliasSource As XmlNode = modelo.CreateElement("Alias")
            Dim TargetHRef As XmlNode = modelo.CreateElement("targetHRef")
            Dim sourceHRef As XmlNode = modelo.CreateElement("sourceHRef")

            resourceMap.AppendChild(aliasSource)
            TargetHRef.InnerText = textura
            sourceHRef.InnerText = textura

            aliasSource.AppendChild(TargetHRef)
            aliasSource.AppendChild(sourceHRef)
        Next

    End Sub
    Public Function ToXMLDocument() As XmlDocument
        Return Me.modelo
    End Function
End Class
