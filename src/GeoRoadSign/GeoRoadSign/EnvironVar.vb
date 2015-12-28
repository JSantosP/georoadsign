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

Public Class EnvironVar

    Public Shared ReadOnly DEFAULT_PATH_IMAGENES = "C:\Temp\Imagenes"
    Public Shared ReadOnly DEFAULT_PATH_MATERIALES = "C:\Temp\Materiales"
    Public Shared ReadOnly DEFAULT_PATH_MODELOS = "C:\Temp\Modelos"

    Private rutaBD As String
    Private rutaTraza As String
    Private rutaImagenes As String
    Private rutaMateriales As String
    Private rutaModelos As String

    Private listaSeñales As List(Of Señalizacion.Señal)

    Public Sub New()
        rutaBD = ""
        rutaTraza = ""
        rutaImagenes = ""
        rutaMateriales = ""
        rutaModelos = ""
        listaSeñales = New List(Of Señalizacion.Señal)
    End Sub

    Public Property pathBaseDatos() As String
        Get
            Return rutaBD
        End Get
        Set(ByVal Value As String)
            rutaBD = Value
        End Set
    End Property
    Public Property pathTraza() As String
        Get
            Return rutaTraza
        End Get
        Set(ByVal Value As String)
            rutaTraza = Value
        End Set
    End Property
    Public Property pathImagenes() As String
        Get
            Return rutaImagenes
        End Get
        Set(ByVal Value As String)
            rutaImagenes = Value
            Señalizacion.EnvironVar.PATH_IMAGENES = Value
        End Set
    End Property
    Public Property pathMateriales() As String
        Get
            Return rutaMateriales
        End Get
        Set(ByVal Value As String)
            rutaMateriales = Value
            Señalizacion.EnvironVar.PATH_MATERIALES = Value
        End Set
    End Property
    Public Property pathModelos() As String
        Get
            Return rutaModelos
        End Get
        Set(ByVal Value As String)
            rutaModelos = Value
            Señalizacion.EnvironVar.PATH_EXPORTACION_MODELOS = Value
        End Set
    End Property
    Public Property señales As List(Of Señalizacion.Señal)
        Get
            Return listaSeñales
        End Get
        Set(ByVal value As List(Of Señalizacion.Señal))
            listaSeñales.Clear()
            For Each señal As Señalizacion.Señal In value
                listaSeñales.Add(señal)
            Next
        End Set
    End Property
End Class
