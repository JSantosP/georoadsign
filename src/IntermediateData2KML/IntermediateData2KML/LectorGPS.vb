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

Public Class LectorGPS

    Private Const CARACTER_COMENTARIO = "#"
    Public Const DEFAULT_PRECISION = 10

    Private pathCSV As String
    Private precision As Integer
    Private listadoPuntos As List(Of PuntoTraza)

    Public Sub New(ByVal pathFicheroOrigen As String,
                         Optional ByVal precision As Double = DEFAULT_PRECISION)
        Me.listadoPuntos = New List(Of PuntoTraza)
        Me.precision = precision
        Me.pathCSV = pathFicheroOrigen
    End Sub

    Public Function procesaFichero() As List(Of PuntoTraza)
        listadoPuntos = New List(Of PuntoTraza)
        Dim fileDesc As New IO.StreamReader(Me.pathCSV)
        Dim iteracion As Long = 0
        While Not fileDesc.EndOfStream
            Dim inputLine As String = fileDesc.ReadLine
            If iteracion Mod precision = 0 Then
                If Left(inputLine, 1) <> CARACTER_COMENTARIO Then
                    Dim params() As String = Split(inputLine, ";")
                    If Not (params(0) = "0" And params(1) = "0") Then
                        listadoPuntos.Add(New PuntoTraza(
                                          New PosicionGPS(
                                              params(0), params(1)),
                                          New Date(
                                              CInt(Split(params(2), "/")(2)),
                                              CInt(Split(params(2), "/")(0)),
                                              CInt(Split(params(2), "/")(1)),
                                              CDate(params(3)).Hour,
                                              CDate(params(3)).Minute,
                                              CDate(params(3)).Second,
                                              CDate(params(3)).Millisecond),
                                          New Date(
                                              CInt(Split(params(4), "/")(2)),
                                              CInt(Split(params(4), "/")(0)),
                                              CInt(Split(params(4), "/")(1)),
                                              CDate(params(5)).Hour,
                                              CDate(params(5)).Minute,
                                              CDate(params(5)).Second,
                                              CDate(params(5)).Millisecond),
                                          params(6)))
                    End If
                End If
            End If
            iteracion = iteracion + 1
        End While
        Return Me.listadoPuntos
    End Function
End Class
