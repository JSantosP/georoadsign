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

Public Class Banderola
    Inherits Soporte

    'Atributos
    Public Shared ReadOnly DEFAULT_ALTURA_TRAVESAÑO = 6.6929134667119277 'pulgadas (0,17 metros)
    Public Shared ReadOnly DEFAULT_GROSOR_TRAVESAÑO = 6.6929134667119277 'pulgadas (0,17 metros)
    Public Shared ReadOnly DEFAULT_LATERAL_SOPORTE = 11.811023764785753 'pulgadas (0,30 metros)
    Public Shared ReadOnly DEFAULT_POSICION_Z = 196.85039607976256 'pulgadas (6,0 metros)
    Public Shared ReadOnly DEFAULT_PARTE_VISIBLE_LATERAL_BANDEROLA = 19.685039607976258 'pulgadas (0,5 metros)

    Private soportePrincipal As Poste
    Private travesañoSuperior As Travesaño
    Private travesañoInferior As Travesaño

    'Constructores
    Public Sub New(ByVal soportePrincipal As Poste, _
                   ByVal travesañoSuperior As Travesaño, _
                   ByVal travesañoInferior As Travesaño)
        Me.soportePrincipal = soportePrincipal
        Me.travesañoSuperior = travesañoSuperior
        Me.travesañoInferior = travesañoInferior
    End Sub
    Public Sub New(ByVal cartel As Rectangular)
        Me.soportePrincipal = New Poste(DEFAULT_LATERAL_SOPORTE, _
                                        cartel.GetAltura + DEFAULT_POSICION_Z, _
                                        DEFAULT_LATERAL_SOPORTE, _
                                        New Punto3D(0, 0, 0), Me.textura)
        Me.travesañoInferior = New Travesaño(cartel.GetAnchura + DEFAULT_PARTE_VISIBLE_LATERAL_BANDEROLA, _
                                             DEFAULT_ALTURA_TRAVESAÑO, _
                                             DEFAULT_GROSOR_TRAVESAÑO, _
                                             New Punto3D(-1 * (cartel.GetAnchura + DEFAULT_PARTE_VISIBLE_LATERAL_BANDEROLA + (DEFAULT_LATERAL_SOPORTE / 2)), _
                                                         DEFAULT_GROSOR_TRAVESAÑO / 2, _
                                                         (cartel.GetAltura / 3) + DEFAULT_POSICION_Z))
        Threading.Thread.Sleep(300)
        Me.travesañoSuperior = New Travesaño(cartel.GetAnchura + DEFAULT_PARTE_VISIBLE_LATERAL_BANDEROLA, _
                                             DEFAULT_ALTURA_TRAVESAÑO, _
                                             DEFAULT_GROSOR_TRAVESAÑO, _
                                             New Punto3D(-1 * (cartel.GetAnchura + DEFAULT_PARTE_VISIBLE_LATERAL_BANDEROLA + (DEFAULT_LATERAL_SOPORTE / 2)), _
                                                         DEFAULT_GROSOR_TRAVESAÑO / 2, _
                                                         (2 * cartel.GetAltura / 3) + DEFAULT_POSICION_Z))
    End Sub
    'Funciones GET
    Public Function GetSoportePrincipal() As Poste
        Return Me.soportePrincipal
    End Function
    Public Function GetTravesañoSuperior() As Travesaño
        Return Me.travesañoSuperior
    End Function
    Public Function GetTravesañoInferior() As Travesaño
        Return Me.travesañoInferior
    End Function
    'Procedimientos SET
    Public Sub SetSoportePrincipal(ByVal soportePrincipal As Poste)
        Me.soportePrincipal = soportePrincipal
    End Sub
    Public Sub SetTravesañoSuperior(ByVal travesañoSuperior As Travesaño)
        Me.travesañoSuperior = travesañoSuperior
    End Sub
    Public Sub SetTravesañoInferior(ByVal travesañoInferior As Travesaño)
        Me.travesañoInferior = travesañoInferior
    End Sub
    'Resto de Subprogramas
    Public Overrides Sub GenerarSoporte()
        Me.soportePrincipal.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
        Me.travesañoInferior.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
        Me.travesañoSuperior.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
    End Sub
    Public Overrides Function GetIdentificadoresElementosSoporte() As System.Collections.Generic.List(Of String)
        Dim listAux As New List(Of String)
        listAux.Add(Me.travesañoSuperior.GetIdentificador)
        listAux.Add(Me.travesañoInferior.GetIdentificador)
        listAux.Add(Me.soportePrincipal.GetIdentificador)
        Return listAux
    End Function
End Class
