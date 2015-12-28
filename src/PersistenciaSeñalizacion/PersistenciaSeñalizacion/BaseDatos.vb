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

Imports Db4objects.Db4o
Imports señalizacion
Public Class BaseDatos

    'Atributos
    Private ruta As String = ""
    Private db As IObjectContainer

    'Constructores
    Public Sub New(ByVal rutabaseDatos As String)
        Me.ruta = rutabaseDatos
    End Sub

    'GET
    Public Function GetRuta() As String
        Return(Me.ruta)
    End Function

    'SET
    Public Sub SetRuta(ByVal ruta As String)
        Me.ruta = ruta
    End Sub

    'Subprogramas

    Public Sub abrir()
        Me.db = Db4oEmbedded.OpenFile(Me.ruta)
    End Sub

    Public Sub almacenar(ByVal señal As Señal)
        'En caso de que ya haya almacenada una señal con el mismo numGis, la sobrescribimos
        Dim señales As IList = Me.db.Query(New PredicateSeñal(señal.getNumGIS))
        For Each elemento As Señal In señales
            Me.db.Delete(elemento)
        Next
        Me.db.Store(señal)
    End Sub

    Public Sub almacenar(ByVal listaSeñales As List(Of Señal))
        For Each elemento As Señal In listaSeñales
            almacenar(elemento)
        Next
    End Sub

    Public Function devolver(Optional ByVal numGis As Integer = -1) As List(Of Señal)
        Dim listadoSeñales As IList
        If numGis = -1 Then
            listadoSeñales = Me.db.Query(New PredicateSeñal())
        Else
            listadoSeñales = Me.db.Query(New PredicateSeñal(numGis))
        End If
        Dim listaRetorno As New List(Of Señal)
        For Each elemento As Señal In listadoSeñales
            listaRetorno.Add(elemento)
        Next
        Return listaRetorno
    End Function

    Public Sub borrar(Optional ByVal numGis As Integer = -1)
        Dim señales As IList
        If numGis = -1 Then
            señales = Me.db.Query(New PredicateSeñal())
        Else
            señales = Me.db.Query(New PredicateSeñal(numGis))
        End If
        For Each elemento In señales
            Me.db.Delete(elemento)
        Next
    End Sub

    Public Sub cerrar()
        Me.db.Commit()
        Me.db.Close()
    End Sub

End Class
