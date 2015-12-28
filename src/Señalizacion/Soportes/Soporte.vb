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

Public MustInherit Class Soporte

    'Atributos
    Public Shared ReadOnly DEFAULT_SEPARACION_PLACA = 3.9370079215952511 'pulgadas (0,10 metros)
    Protected textura As String = "aluminio.JPG" 'Nombre de la imagen de textura del soporte

    'Constructores
    Public Sub New()
    End Sub
    'Funciones GET
    Public Function GetTextura() As String
        Return Me.textura
    End Function
    'Procedimientos SET
    Public Sub SetTextura(ByVal textura As String)
        Me.textura = textura
    End Sub
    'Resto de Subprogramas
    Public Overridable Sub GenerarSoporte()
    End Sub
    Public Overridable Function GetIdentificadoresElementosSoporte() As List(Of String)
        Return New List(Of String)
    End Function
End Class
