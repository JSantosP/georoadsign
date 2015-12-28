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

Public Class AlmacenDatosIntermedios
    Private diccionario As Dictionary(Of Integer, List(Of ModeloDatosIntermedio))

    'Constructor
    Public Sub New()
        Me.diccionario = New Dictionary(Of Integer, List(Of ModeloDatosIntermedio))
    End Sub

    Public Function identificadores() As Dictionary(Of Integer, List(Of ModeloDatosIntermedio)).KeyCollection
        'Devuelve la lista de los N_Gis contenidos en la lista de subelementos de la instancia actual
        Return Me.diccionario.Keys
    End Function
    Public Function señal(ByVal n_Gis As Integer) As List(Of ModeloDatosIntermedio)
        'Devuelve el listado de placas que se corresponden a n_Gis
        Return Me.diccionario.Item(n_Gis)
    End Function
    Public Sub insertar(ByVal placa As ModeloDatosIntermedio)
        'Inserta una placa en el almacen (el almacen se encarga de hacerlo de manera ordenada)

        If Me.diccionario.ContainsKey(placa.GetN_Gis) Then
            Me.diccionario.Item(placa.GetN_Gis).Add(placa)
        Else
            Dim listaAux As New List(Of ModeloDatosIntermedio)
            listaAux.Add(placa)
            Me.diccionario.Add(placa.GetN_Gis, listaAux)
        End If

    End Sub


End Class
