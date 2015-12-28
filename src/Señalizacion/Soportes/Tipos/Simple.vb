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

Public Class Simple
    Inherits Soporte

    'Atributos
    Public Shared ReadOnly DEFAULT_ALTURA = 98.42519803988128 'pulgadas (2,50 metros)
    Public Shared ReadOnly DEFAULT_ANCHURA = 3.1496063372762011 'pulgadas (0,08 metros)
    Public Shared ReadOnly DEFAULT_GROSOR = 1.5748031686381005 'pulgadas (0,04 metros)

    Private poste As New Poste

    'Constructores
    Public Sub New()
        Me.poste = New Poste(DEFAULT_ANCHURA, _
                             DEFAULT_ALTURA, _
                             DEFAULT_GROSOR, _
                             New Punto3D(0, 0, 0), _
                             Me.textura)
    End Sub
    Public Sub New(ByVal poste As Poste)
        Me.poste = poste
    End Sub
    'Funciones GET
    Public Function GetPoste() As Poste
        Return Me.poste
    End Function
    'Procdedimientos SET
    Public Sub SetPoste(ByVal poste As Poste)
        Me.poste = poste
    End Sub
    'Resto de Subprogramas
    Public Overrides Sub GenerarSoporte()
        Me.poste.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
    End Sub
    Public Overrides Function GetIdentificadoresElementosSoporte() As System.Collections.Generic.List(Of String)
        Dim listAux As New List(Of String)
        listAux.Add(Me.poste.GetIdentificador)
        Return listAux
    End Function
End Class
