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

Public Class Portico
    Inherits Soporte

    'Atributos
    Public Shared ReadOnly DEFAULT_ALTURA = 6.6929134667119277 'pulgadas (0,17 metros)
    Public Shared ReadOnly DEFAULT_GROSOR = 6.6929134667119277 'pulgadas (0,17 metros)
    Public Shared ReadOnly DEFAULT_POSICION_Z = 354.33071294357262 'pulgadas (9,0 metros)
    Public Shared ReadOnly DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES = 3.9370079215952511 'pulgadas (0,10 metros)
    Public Shared ReadOnly DEFAULT_PARTE_VISIBLE_LATERALES_PORTICO = 39.370079215952515 'pulgadas (1,0 metros)

    Private travesañoSuperior As Travesaño
    Private travesañoInferior As Travesaño

    'Constructores
    Public Sub New(ByVal travesañoSuperior As Travesaño, ByVal travesañoInferior As Travesaño)
        Me.travesañoSuperior = travesañoSuperior
        Me.travesañoInferior = travesañoInferior
    End Sub
    Public Sub New(ByVal carteles As List(Of Rectangular))
        'Dada una lista de carteles RECTANGULARES deduce la altura media para ajustar la colocación
        'de los travesaños asi como el ancho de los mismos.
        If carteles.Count < 1 Then
            Throw New ArgumentOutOfRangeException("carteles", "La estructura debe contener al menos un cartel")
        End If
        Dim alturaTotal As Double = 0.0
        Dim anchoTotal As Double = (2 * DEFAULT_PARTE_VISIBLE_LATERALES_PORTICO) _
                                   + ((carteles.Count - 1) * DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES)
        For Each cartel As Rectangular In carteles
            anchoTotal = anchoTotal + cartel.GetAnchura()
            alturaTotal = alturaTotal + cartel.GetAltura()
        Next
        Dim alturaMedia As Double = alturaTotal / carteles.Count
        Me.travesañoInferior = New Travesaño(anchoTotal, _
                                           DEFAULT_ALTURA, _
                                           DEFAULT_GROSOR, _
                                           New Punto3D(-1 * (anchoTotal / 2), _
                                                       DEFAULT_GROSOR / 2, _
                                                       DEFAULT_POSICION_Z + ((1 / 3) * alturaMedia)), _
                                           Me.textura)
        Threading.Thread.Sleep(100)
        Me.travesañoSuperior = New Travesaño(anchoTotal, _
                                           DEFAULT_ALTURA, _
                                           DEFAULT_GROSOR, _
                                           New Punto3D(-1 * (anchoTotal / 2), _
                                                       DEFAULT_GROSOR / 2, _
                                                       DEFAULT_POSICION_Z + ((2 / 3) * alturaMedia)), _
                                           Me.textura)
    End Sub
    'Funciones GET
    Public Function GetTravesañoSuperior() As Travesaño
        Return Me.travesañoSuperior
    End Function
    Public Function GetTravesañoInferior() As Travesaño
        Return Me.travesañoInferior
    End Function
    'Procedimientos SET
    Public Sub SetTravesañoSuperior(ByVal travesaño As Travesaño)
        Me.travesañoSuperior = travesaño
    End Sub
    Public Sub SetTravesañoInferior(ByVal travesaño As Travesaño)
        Me.travesañoInferior = travesaño
    End Sub
    'Resto de Subprogramas
    Public Overrides Sub GenerarSoporte()
        Me.travesañoSuperior.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
        Me.travesañoInferior.GenerarDAE(EnvironVar.PATH_EXPORTACION_MODELOS)
    End Sub
    Public Overrides Function GetIdentificadoresElementosSoporte() As System.Collections.Generic.List(Of String)
        Dim listAux As New List(Of String)
        listAux.Add(Me.travesañoSuperior.GetIdentificador)
        listAux.Add(Me.travesañoInferior.GetIdentificador)
        Return listAux
    End Function
End Class
