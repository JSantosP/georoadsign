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
Imports Persistencia

Public Class ModuloEscritor

    Public Shared ReadOnly LINK_IMAGEN_ACERCADE = My.Resources.URLAcercaDe

    'Documento XML
    Private KMLDestino As XmlDocument

    'Path KML destino
    Private pathKMLDestino As String = ""

    'Atributos de SEÑALES
    Private baseDatosSeñales As BaseDatos
    Private listadoSeñalesKML As List(Of SeñalKML)

    'Atributos de VIAJE
    Private lectorTraza As LectorGPS
    Private viaje As ViajeKML

    Public Sub New(ByVal pathKMLDestino As String,
                         ByVal listadoSeñales As List(Of Señal),
                         Optional ByVal pathTrazaCSV As String = "",
                         Optional ByVal precisionPuntosGPS As Double = LectorGPS.DEFAULT_PRECISION,
                         Optional ByVal factorVelocidadViaje As Double = ViajeKML.DEFAULT_FACTOR_VELOCIDAD,
                         Optional ByVal inclinacionX As Double = ViajeKML.DEFAULT_TILT,
                         Optional ByVal distanciaCamaraAlPunto As Double = ViajeKML.DEFAULT_RANGE,
                         Optional ByVal altitudCamara As Double = ViajeKML.DEFAULT_ALTITUD)


        'Almacenamos el string del path donde guardaremos el KML
        Me.pathKMLDestino = pathKMLDestino

        'Procesamos la traza, si la tuviera
        If pathTrazaCSV <> "" Then
            Me.lectorTraza = New LectorGPS(pathTrazaCSV, precisionPuntosGPS)
            Dim listadoPuntos As List(Of PuntoTraza) = Me.lectorTraza.procesaFichero()
            Me.viaje = New ViajeKML(listadoPuntos,
                                    factorVelocidadViaje,
                                    inclinacionX,
                                    distanciaCamaraAlPunto,
                                    altitudCamara)
        End If

        'Procesamos las señales almacenadas en la BD, si la tuviera

        Me.listadoSeñalesKML = New List(Of SeñalKML)
        For Each objetoSeñal As Señal In listadoSeñales
            Me.listadoSeñalesKML.Add(New SeñalKML(objetoSeñal))
            'generamos el modelo de la señal
            objetoSeñal.GenerarSeñal()
        Next

        'Consturimos el KML definitivo

        '   Generamos cabecera
        Me.KMLDestino = New XmlDocument
        Dim heading As XmlDeclaration = KMLDestino.CreateXmlDeclaration("1.0", "UTF-8", "")
        KMLDestino.AppendChild(heading)

        Dim root As XmlNode = Me.KMLDestino.CreateElement("kml")
        Dim xmlns As XmlAttribute = Me.KMLDestino.CreateAttribute("xmlns")
        xmlns.Value = My.Resources.KMLNameSpace
        root.Attributes.Append(xmlns)
        Dim xmlnsGx As XmlAttribute = Me.KMLDestino.CreateAttribute("xmlns:gx")
        xmlnsGx.Value = My.Resources.KMLGXNameSpace
        root.Attributes.Append(xmlnsGx)
        Me.KMLDestino.AppendChild(root)
        Dim document As XmlNode = Me.KMLDestino.CreateElement("Document")
        root.AppendChild(document)
        Dim name As XmlNode = Me.KMLDestino.CreateElement("name")
        name.InnerText = "DocumentoKML"
        document.AppendChild(name)
        Dim open As XmlNode = Me.KMLDestino.CreateElement("open")
        open.InnerText = "1"
        document.AppendChild(open)

        'Añadir viaje

        If Not (Me.viaje Is Nothing) Then
            document.AppendChild(Me.KMLDestino.ImportNode(Me.viaje.ToXMLDocument.FirstChild, True))
        End If

        'Añadir señales
        If Not (Me.listadoSeñalesKML Is Nothing) Then
            For Each elementoXML As SeñalKML In listadoSeñalesKML
                document.AppendChild(Me.KMLDestino.ImportNode(elementoXML.ToXMLDocument.FirstChild, True))
            Next
        End If

        '   Añadimos el nodo AcercaDe

        document.AppendChild(Me.KMLDestino.ImportNode(createScreenOverlay.FirstChild, True))

    End Sub

    Public Sub AlmacenarKML()
        Me.KMLDestino.Save(Me.pathKMLDestino)
    End Sub

    Private Function createScreenOverlay() As XmlDocument
        'Añade al KML el AcercaDe
        Dim ret As New XmlDocument
        Dim ScreenOverlay As XmlNode = ret.CreateElement("ScreenOverlay")
        Dim name As XmlNode = ret.CreateElement("name")
        Dim Icon As XmlNode = ret.CreateElement("Icon")
        Dim href As XmlNode = ret.CreateElement("href")
        Dim params() As XmlNode = {ret.CreateElement("overlayXY"),
                      ret.CreateElement("screenXY"),
                      ret.CreateElement("rotationXY"),
                      ret.CreateElement("size")}
        ret.AppendChild(ScreenOverlay)
        name.InnerText = "AcercaDe"
        ScreenOverlay.AppendChild(name)
        ScreenOverlay.AppendChild(Icon)
        href.InnerText = LINK_IMAGEN_ACERCADE
        Icon.AppendChild(href)
        For Each elemento As XmlNode In params
            Dim x As XmlAttribute = ret.CreateAttribute("x")
            x.Value = "0"
            elemento.Attributes.Append(x)
            Dim y As XmlAttribute = ret.CreateAttribute("y")
            Select Case Array.IndexOf(params, elemento)
                Case 0, 1
                    y.Value = "1"
                Case 2, 3
                    y.Value = "0"
            End Select
            elemento.Attributes.Append(y)
            Dim xunits As XmlAttribute = ret.CreateAttribute("xunits")
            xunits.Value = "fraction"
            elemento.Attributes.Append(xunits)
            Dim yunits As XmlAttribute = ret.CreateAttribute("yunits")
            yunits.Value = "fraction"
            elemento.Attributes.Append(yunits)
            ScreenOverlay.AppendChild(elemento)
        Next
        Return ret
    End Function

End Class
