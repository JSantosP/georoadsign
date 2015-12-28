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

Public Class Señal

    'Atributos
    Private numGIS As Integer = 0
    Private posicionGPS As New PosicionGPS
    Private rotacion As Double = 0.0 'radianes
    Private soporte As Soporte
    Private placas As New List(Of Placa)
    '>>MetaInformación
    Private demarcacion As String = ""
    Private unidadCarretera As String = ""
    Private carretera As String = ""
    Private pk As Double = 0.0
    Private tipoEje As String = ""

    'Constructores
    Public Sub New(ByVal numGIS As Integer,
                   ByVal posicionGPS As PosicionGPS,
                   ByVal rotacion As Double,
                   ByVal soporte As Soporte,
                   ByVal placas As List(Of Placa),
                         Optional ByVal demarcacion As String = "",
                         Optional ByVal unidadCarretera As String = "",
                         Optional ByVal carretera As String = "",
                         Optional ByVal pk As Double = 0.0,
                         Optional ByVal tipoEje As String = "")
        Me.numGIS = numGIS
        Me.posicionGPS = posicionGPS
        Me.rotacion = rotacion
        Me.soporte = soporte
        Me.placas.Clear()
        For Each elemento In placas
            Me.placas.Add(elemento)
        Next
        'MetaInformación
        Me.demarcacion = demarcacion
        Me.unidadCarretera = unidadCarretera
        Me.carretera = carretera
        Me.pk = pk
        Me.tipoEje = tipoEje
    End Sub

    'Funciones GET
    Public Function getNumGIS() As Integer
        Return Me.numGIS
    End Function
    Public Function getPosicionGPS() As PosicionGPS
        Return (Me.posicionGPS)
    End Function
    Public Function getRotacion() As Double
        Return Me.rotacion
    End Function
    Public Function getSoporte() As Soporte
        Return Me.soporte
    End Function
    Public Function getPlacas() As List(Of Placa)
        Dim retorno As New List(Of Placa)
        retorno.Clear()
        For Each elemento In Me.placas
            retorno.Add(elemento)
        Next
        Return retorno
    End Function
    Public Function getDemarcacion() As String
        Return Me.demarcacion
    End Function
    Public Function getUnidadCarretera() As String
        Return Me.unidadCarretera
    End Function
    Public Function getCarretera() As String
        Return Me.carretera
    End Function
    Public Function getPk() As Double
        Return Me.pk
    End Function
    Public Function getTipoEje() As String
        Return Me.tipoEje
    End Function

    'Procedimientos SET
    Public Sub setNumGIS(ByVal numGIS As Integer)
        Me.numGIS = numGIS
    End Sub
    Public Sub setPosicionGPS(ByVal posicionGPS As PosicionGPS)
        Me.posicionGPS = posicionGPS
    End Sub
    Public Sub setRotacion(ByVal rotacion As Double)
        Me.rotacion = rotacion
    End Sub
    Public Sub setSoporte(ByVal soporte As Soporte)
        Me.soporte = soporte
    End Sub
    Public Sub setPlacas(ByVal placas As List(Of Placa))
        Me.placas.Clear()
        For Each elemento As Placa In placas
            Me.placas.Add(elemento)
        Next
    End Sub
    Public Sub setDemarcacion(ByVal demarcacion As String)
        Me.demarcacion = demarcacion
    End Sub
    Public Sub setUnidadCarretera(ByVal unidadCarretera As String)
        Me.unidadCarretera = unidadCarretera
    End Sub
    Public Sub setCarretera(ByVal carretera As String)
        Me.carretera = carretera
    End Sub
    Public Sub setPk(ByVal pk As Double)
        Me.pk = pk
    End Sub
    Public Sub setTipoEje(ByVal tipoEje As String)
        Me.tipoEje = tipoEje
    End Sub

    'Resto de Subprogramas
    Public Sub AñadePlaca(ByVal placa As Placa)
        Me.placas.Add(placa)
    End Sub
    Public Sub GenerarSeñal()
        Me.soporte.GenerarSoporte()
        For Each elemento As Placa In Me.placas
            elemento.GenerarPlaca()
        Next
    End Sub
    Public Function GetMetaInfoHTML() As String
        Dim metaInfo As String =
            "<TABLE BORDER=0>" & _
            "<TR><TH align=" & Chr(34) & "left" & Chr(34) & ">Demarcación<TD>" & Me.demarcacion & _
            "<TR><TH align=" & Chr(34) & "left" & Chr(34) & ">Ud.Carreteras<TD>" & Me.unidadCarretera & _
            "<TR><TH align=" & Chr(34) & "left" & Chr(34) & ">Carretera<TD>" & Me.carretera & _
            "<TR><TH align=" & Chr(34) & "left" & Chr(34) & ">PK<TD>" & Me.pk.ToString & _
            "<TR><TH align=" & Chr(34) & "left" & Chr(34) & ">Tipo de eje<TD>" & Me.tipoEje & _
            "</TABLE>"
        Return metaInfo
    End Function
End Class
