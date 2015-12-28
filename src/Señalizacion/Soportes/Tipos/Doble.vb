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

Public Class Doble
    Inherits Soporte

    'Atributos
    Public Shared ReadOnly DEFAULT_ALTURA = 78.74015843190503 'pulgadas (2 metros)
    Public Shared ReadOnly DEFAULT_ANCHURA = 7.8740158431905023 'pulgadas (0,20 metros)
    Public Shared ReadOnly DEFAULT_GROSOR = 3.9370079215952511 'pulgadas (0,10 metros)
    Public Shared ReadOnly DEFAULT_POSICION_RESPECTO_ANCHO_CARTEL = 4 'Los postes se colocarán a 1/4 y 3/4 del ancho del cartel


    Private posteIzquierdo As Poste
    Private posteDerecho As Poste

    'Constructores
    Public Sub New(ByVal posteIzq As Poste, _
                   ByVal posteDer As Poste)
        Me.posteIzquierdo = posteIzq
        Me.posteDerecho = posteDer
    End Sub
    Public Sub New(ByVal anchoDeCartel As Double)
        Dim anchoCartelPulgadas As Double = anchoDeCartel / Punto3D.PULGADA
        'Genera un soporte de poste doble teniendo en cuenta el ancho del cartel (metros)
        Me.posteIzquierdo = New Poste(Doble.DEFAULT_ANCHURA, _
                                    Doble.DEFAULT_ALTURA, _
                                    Doble.DEFAULT_GROSOR, _
                                    New Punto3D((-1 * (anchoCartelPulgadas / 2)) + (anchoCartelPulgadas / DEFAULT_POSICION_RESPECTO_ANCHO_CARTEL), 0, 0), _
                                    Me.textura)
        Threading.Thread.Sleep(100)
        Me.posteDerecho = New Poste(Doble.DEFAULT_ANCHURA, _
                                    Doble.DEFAULT_ALTURA, _
                                    Doble.DEFAULT_GROSOR, _
                                    New Punto3D((anchoCartelPulgadas / 2) - (anchoCartelPulgadas / DEFAULT_POSICION_RESPECTO_ANCHO_CARTEL), 0, 0), _
                                    Me.textura)
    End Sub
    'Funciones GET
    Public Function GetPosteIzquierdo() As Poste
        Return Me.posteIzquierdo
    End Function
    Public Function GetPosteDerecho() As Poste
        Return Me.posteDerecho
    End Function
    'Procedimientos SET
    Public Sub SetPosteIzquierdo(ByVal posteIzq As Poste)
        Me.posteIzquierdo = posteIzq
    End Sub
    Public Sub SetPosteDerecho(ByVal posteDer As Poste)
        Me.posteDerecho = posteDer
    End Sub
    'Resto de Subprogramas
    Public Overrides Sub GenerarSoporte()
        Me.posteIzquierdo.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
        Me.posteDerecho.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
    End Sub
    Public Overrides Function GetIdentificadoresElementosSoporte() As System.Collections.Generic.List(Of String)
        Dim listAux As New List(Of String)
        listAux.Add(Me.posteIzquierdo.GetIdentificador)
        listAux.Add(Me.posteDerecho.GetIdentificador)
        Return listAux
    End Function
End Class
