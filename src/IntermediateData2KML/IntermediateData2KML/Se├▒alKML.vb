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

Imports Normalizacion.Rotacion
Imports Señalizacion
Imports System.Xml

Public Class SeñalKML

    Private Shared ReadOnly DEFAULT_MAX_SNIPPET_LINES = 7
    Private Shared ReadOnly ALTITUD_VISTA_SEÑAL = 5
    Private Shared ReadOnly DISTANCIA_VISTA_MODELO = 12
    Private Shared ReadOnly TILT_VISTA_SEÑAL = 45

    Private folderModelos As XmlDocument
    Private nodosXML As List(Of ModeloKml)

    Public Sub New(ByVal señal As Señal)

        'Construimos los ModelosKML que servirán de nodos para
        'el Folder KML que los englobará

        nodosXML = New List(Of ModeloKml)
        For Each id In señal.getSoporte.GetIdentificadoresElementosSoporte
            Dim modeloEltoSoporte As New ModeloKml(
                id,
                señal.getPosicionGPS,
                señal.getRotacion,
                Señalizacion.EnvironVar.PATH_EXPORTACION_MODELOS & "\" & id & ".DAE",
                New List(Of String)({Señalizacion.EnvironVar.PATH_MATERIALES & "\" & señal.getSoporte.GetTextura}))
            nodosXML.Add(modeloEltoSoporte)
        Next

        For Each eltoPlaca As Placa In señal.getPlacas
            Dim modeloEltoPlaca As New ModeloKml(
                eltoPlaca.GetIdentificador,
                señal.getPosicionGPS,
                eltoPlaca.GetOrientacion,
                Señalizacion.EnvironVar.PATH_EXPORTACION_MODELOS & "\" & eltoPlaca.GetIdentificador & ".DAE",
                New List(Of String)({Señalizacion.EnvironVar.PATH_IMAGENES & "\" & eltoPlaca.GetTextura, _
                                     Señalizacion.EnvironVar.PATH_MATERIALES & "\" & señal.getSoporte.GetTextura}))
            nodosXML.Add(modeloEltoPlaca)
        Next

        'Construimos el Folder KML con los nodos recogidos

        Me.folderModelos = New XmlDocument()

        Dim Folder As XmlNode = Me.folderModelos.CreateElement("Folder")
        Dim name As XmlNode = Me.folderModelos.CreateElement("name")
        Dim description As XmlNode = Me.folderModelos.CreateElement("description")
        Dim open As XmlNode = Me.folderModelos.CreateElement("open")
        Dim Style As XmlNode = Me.folderModelos.CreateElement("Style")
        Dim ListStyle As XmlNode = Me.folderModelos.CreateElement("ListStyle")
        Dim listItemType As XmlNode = Me.folderModelos.CreateElement("listItemType")
        Dim ItemIconOpen As XmlNode = Me.folderModelos.CreateElement("ItemIcon")
        Dim stateOpen As XmlNode = Me.folderModelos.CreateElement("state")
        Dim hrefOpen As XmlNode = Me.folderModelos.CreateElement("href")
        Dim ItemIconClosed As XmlNode = Me.folderModelos.CreateElement("ItemIcon")
        Dim stateClosed As XmlNode = Me.folderModelos.CreateElement("state")
        Dim hrefClosed As XmlNode = Me.folderModelos.CreateElement("href")


        Me.folderModelos.AppendChild(Folder)
        name.InnerText = Chr(34) & "Id. Export. " & señal.getNumGIS & Chr(34)
        Folder.AppendChild(name)

        Dim snippet As XmlNode = Me.folderModelos.CreateElement("Snippet")
        Dim maxlines As XmlAttribute = Me.folderModelos.CreateAttribute("maxLines")
        maxlines.Value = DEFAULT_MAX_SNIPPET_LINES
        snippet.Attributes.Append(maxlines)
        Dim cdata As XmlNode = Me.folderModelos.CreateCDataSection(señal.GetMetaInfoHTML)
        snippet.AppendChild(cdata)
        Folder.AppendChild(snippet)

        open.InnerText = "0" 'False
        Folder.AppendChild(open)
        Folder.AppendChild(ListStyle)
        listItemType.InnerText = "checkHideChildren"
        ListStyle.AppendChild(listItemType)

        ListStyle.AppendChild(ItemIconOpen)
        stateOpen.InnerText = "open"
        ItemIconOpen.AppendChild(stateOpen)
        hrefOpen.InnerText = ":/mysavedplaces_open.png"
        ItemIconOpen.AppendChild(hrefOpen)

        ListStyle.AppendChild(ItemIconClosed)
        stateClosed.InnerText = "closed"
        ItemIconClosed.AppendChild(stateClosed)
        hrefClosed.InnerText = ":/mysavedplaces_closed.png"
        ItemIconClosed.AppendChild(hrefClosed)

        Dim heading As Double = ToDegrees(modulo360(señal.getRotacion - (Math.PI / 2)))
        Dim vista As New LookAtKML(señal.getPosicionGPS, ALTITUD_VISTA_SEÑAL, heading, TILT_VISTA_SEÑAL, DISTANCIA_VISTA_MODELO)
        Folder.AppendChild(Me.folderModelos.ImportNode(vista.ToXMLDocumnt.FirstChild, True))

        For Each placemark As ModeloKml In nodosXML
            Dim aux As XmlNode = Me.folderModelos.ImportNode(placemark.ToXMLDocument.FirstChild, True)
            Folder.AppendChild(aux)
        Next

    End Sub
    Public Function ToXMLDocument() As XmlDocument
        Return Me.folderModelos
    End Function
End Class
