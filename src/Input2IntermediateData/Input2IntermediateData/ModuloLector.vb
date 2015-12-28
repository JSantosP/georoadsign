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
Imports Persistencia.BaseDatos
Public Class ModuloLector

    'Atributos
    Private rutaFicheroEntrada As String = ""
    Private rutaBaseDatos As String = ""
    'Usamos nuestra propia implementación de diccionario para agrupar los datos de entrada 
    'por Número de elemento GIS (N_Gis)
    Private almacen As New AlmacenDatosIntermedios()
    Private listadoSeñales As List(Of Señal) = New List(Of Señal)
    Dim baseDatos As Persistencia.BaseDatos

    'Constructor
    Public Sub New(ByVal ficheroEntrada As String,
                   ByVal baseDatos As String)
        Me.rutaBaseDatos = baseDatos
        Me.rutaFicheroEntrada = ficheroEntrada
    End Sub

    Public Sub procesarFichero()

        '1. Recorrer CSV y genenerar Datos Intermedios (ordenadamente)

        Dim flujoLectura As New System.IO.StreamReader(rutaFicheroEntrada)
        'omitimos la cabecera
        flujoLectura.ReadLine()
        While Not (flujoLectura.EndOfStream)
            Dim cadenaActual As String = flujoLectura.ReadLine
            Dim datoEntrada As New ModeloDatosIntermedio(cadenaActual)
            'Insertar en el diccionario
            almacen.insertar(datoEntrada)
        End While

        '2. Pasar datosIntermedios a señales

        For Each n_gis As Integer In almacen.identificadores
            If Not (almacen.señal(n_gis)(0).GetSoporte = TipoSoporte.DESCONOCIDO) Then
                listadoSeñales.Add(ModeloDatosIntermedio.ConvertToSeñal(almacen.señal(n_gis)))
            End If
        Next

        '3. Almacenarlas en la base de datos

        baseDatos = New Persistencia.BaseDatos(Me.rutaBaseDatos)
        baseDatos.abrir()
        baseDatos.almacenar(listadoSeñales)
        baseDatos.cerrar()
    End Sub

End Class