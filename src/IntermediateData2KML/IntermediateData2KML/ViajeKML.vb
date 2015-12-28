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
Public Class ViajeKML
    Private Const DEFAULT_DURACION_VUELO_ULTIMO_PUNTO = 4 'segundos
    Public Const DEFAULT_FACTOR_VELOCIDAD = 1.0 ' velocidad x 1.0
    Public Const DEFAULT_TILT = 80 'grados de inclinación sobre el eje X
    Public Const DEFAULT_RANGE = 10 'metros de distancia al punto
    Public Const DEFAULT_ALTITUD = 5 'metros de altitud sobre el suelo (relativoAlSuelo)


    Private viaje As XmlDocument

    Public Sub New(ByVal listadoPuntos As List(Of PuntoTraza),
                   Optional ByVal factorVelocidad As Double = DEFAULT_FACTOR_VELOCIDAD,
                   Optional ByVal tilt As Double = DEFAULT_TILT,
                   Optional ByVal range As Double = DEFAULT_RANGE,
                   Optional ByVal altitud As Double = DEFAULT_ALTITUD)

        Me.viaje = New XmlDocument

        Dim gxTour As XmlNode = Me.viaje.CreateElement("gx", "Tour", My.Resources.KMLGXNameSpace)
        Dim name As XmlNode = Me.viaje.CreateElement("name")
        Dim playList As XmlNode = Me.viaje.CreateElement("gx", "Playlist", My.Resources.KMLGXNameSpace)

        Me.viaje.AppendChild(gxTour)

        name.InnerText = "Demostración de Viaje Virtual"
        gxTour.AppendChild(name)
        gxTour.AppendChild(playList)

        'duracion | posicion | altitud | heading | tilt | range
        Dim vectoresOrientacion As List(Of Double) = HallarVectoresOrientación(listadoPuntos)
        For Each punto As PuntoTraza In listadoPuntos
            Dim duracionVuelo As Double
            Try
                duracionVuelo = listadoPuntos(listadoPuntos.IndexOf(punto) + 1).GetCPUDateTime.Subtract(
                    punto.GetCPUDateTime).TotalMilliseconds / 1000
            Catch ex As ArgumentOutOfRangeException
                'se ha llegado al ultimo punto y no tiene con quien comparar la diferencia de tiempo
                duracionVuelo = DEFAULT_DURACION_VUELO_ULTIMO_PUNTO
            End Try
            Dim nodo As New FlyTo(
                duracionVuelo / factorVelocidad,
                punto.GetPosGPS,
                altitud,
                vectoresOrientacion(listadoPuntos.IndexOf(punto)),
                tilt,
                range)
            playList.AppendChild(Me.viaje.ImportNode(nodo.ToXMLDocument.FirstChild, True))
        Next

    End Sub

    Public Function ToXMLDocument() As XmlDocument
        Return Me.viaje
    End Function

    Private Function HallarVectoresOrientación(ByVal puntos As List(Of PuntoTraza)) As List(Of Double)
        Dim vectoresOrientacion As New List(Of Double)
        Try
            For Each punto As PuntoTraza In puntos
                vectoresOrientacion.Add(
                    punto.GetPosGPS.anguloConPosicion(
                        puntos(puntos.IndexOf(punto) + 1).GetPosGPS))
            Next
        Catch ex As Exception
            vectoresOrientacion.Add(0.0)
            Return vectoresOrientacion
        End Try
        Return vectoresOrientacion
    End Function
End Class
