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

Public Class PredicateSeñal
    Inherits Db4objects.Db4o.Query.Predicate

    Private n_GisQuery As Integer

    Public Sub New()
        'Si se llama al constructor sin argumento, al hacer la 'query' devolverá todos los registros
        'de tipo Señal
        Me.n_GisQuery = -1
    End Sub
    Public Sub New(ByVal n_GisQuery As Integer)
        'Solo devolverá los registros de tipo señal cuyo campo numGis coincida con el argumento 
        'del constructor
        Me.n_GisQuery = n_GisQuery
    End Sub

    Public Function Match(ByVal señal As Señalizacion.Señal) As Boolean
        If (señal.getNumGIS = Me.n_GisQuery) Or (Me.n_GisQuery = -1) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
