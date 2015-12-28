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

Imports Normalizacion
Imports Normalizacion.Rotacion
Imports Señalizacion

Public Enum Eje
    TRONCO
    RAMAL
End Enum
Public Enum Orientacion
    FRONTAL
    POSTERIOR
    DERECHO
    IZQUIERDO
End Enum
Public Enum DireccionalCodigo
    DIRECCIONAL
    VERTICAL
End Enum
Public Enum Geometria
    PANEL
    RECTÁNGULO
    CUADRADO
    CÍRCULO
    TRIÁNGULO
    OCTÓGONO
    VACIA
End Enum
Public Enum TipoSoporte
    POSTE
    FAROLA
    PREAVISO
    FLECHAD
    FLECHAI
    FLECHAID
    PORTICO
    BANDEROLAD
    CONFIRMACION
    DESCONOCIDO
End Enum
Public Class ModeloDatosIntermedio
    Shared ReadOnly CARACTER_DELIMITADOR = ";"
    Shared ReadOnly TEXTURA_NO_ENCONTRADA = "NOT_FOUND.JPG"
    Shared ReadOnly FACTOR_AUMENTO_IMAGEN = 4
    Private Const PLUS_DISTANCIA_Y_BANDEROLA = 1.7

    'Atributos
    Private N_Gis As Integer = 0
    Private N_Pla As Integer = 0
    Private Demarcacion As String = ""
    Private UCarretera As String = ""
    Private Carretera As String = ""
    Private PK As Double = 0.0
    Private Tipo_Eje As Eje = Eje.TRONCO
    Private Gis_X As Double = 0.0
    Private Gis_Y As Double = 0.0
    Private DireccionalCodigo As DireccionalCodigo = DireccionalCodigo.VERTICAL
    Private Codigo As String = ""
    Private Geometria As Geometria
    Private NombreArchivo As String = ""
    Private Soporte As TipoSoporte
    Private angulo As Double = 0.0 'radianes
    Private ordenFila As Integer = 1
    Private SopPanel As Orientacion = Orientacion.FRONTAL

    'Constructor
    Public Sub New(ByVal cadena As String)
        Dim params() As Object = cadena.Split(CARACTER_DELIMITADOR)
        Me.N_Gis = CInt(params(0))
        Me.N_Pla = CInt(params(1))
        Me.Demarcacion = params(2)
        Me.UCarretera = params(3)
        Me.Carretera = params(4)
        Me.PK = CDbl(params(5))
        Select Case UCase(params(6))
            Case "TRONCO"
                Me.Tipo_Eje = Eje.TRONCO
            Case "RAMAL"
                Me.Tipo_Eje = Eje.RAMAL
            Case Else
                Me.Tipo_Eje = Eje.TRONCO
        End Select
        Me.Gis_X = CDbl(params(7))
        Me.Gis_Y = CDbl(params(8))
        Select Case UCase(params(9))
            Case "DIRECCIONAL"
                Me.DireccionalCodigo = DireccionalCodigo.DIRECCIONAL
            Case "VERTICAL"
                Me.DireccionalCodigo = DireccionalCodigo.VERTICAL
            Case Else
                Me.DireccionalCodigo = DireccionalCodigo.VERTICAL
        End Select
        Me.Codigo = params(10)
        Select Case UCase(params(11))
            Case "TRIÁNGULO"
                Me.Geometria = Geometria.TRIÁNGULO
            Case "CUADRADO"
                Me.Geometria = Geometria.CUADRADO
            Case "RECTÁNGULO"
                Me.Geometria = Geometria.RECTÁNGULO
            Case "PANEL"
                Me.Geometria = Geometria.PANEL
            Case "CÍRCULO"
                Me.Geometria = Geometria.CÍRCULO
            Case "OCTÓGONO"
                Me.Geometria = Geometria.OCTÓGONO
            Case Else
                'Es posible que no haya reconocido algún caracter con tilde
                If Right(UCase(params(11)), 5) = "RCULO" Then
                    Me.Geometria = Geometria.CÍRCULO
                ElseIf Left(UCase(params(11)), 3) = "TRI" Then
                    Me.Geometria = Geometria.TRIÁNGULO
                ElseIf Left(UCase(params(11)), 4) = "RECT" Then
                    Me.Geometria = Geometria.RECTÁNGULO
                ElseIf Left(UCase(params(11)), 3) = "OCT" Then
                    Me.Geometria = Geometria.OCTÓGONO
                Else
                    Me.Geometria = Geometria.VACIA
                End If
        End Select
        Me.NombreArchivo = params(12)
        Select Case UCase(params(13))
            Case "POSTE"  'ÑAPA. Revisar!
                Me.Soporte = TipoSoporte.POSTE
            Case "FAROLA"
                Me.Soporte = TipoSoporte.FAROLA
            Case "PREAVISO"
                Me.Soporte = TipoSoporte.PREAVISO
            Case "FLECHAD"
                Me.Soporte = TipoSoporte.FLECHAD
            Case "FLECHAI"
                Me.Soporte = TipoSoporte.FLECHAI
            Case "FLECHAID"
                Me.Soporte = TipoSoporte.FLECHAID
            Case "CONFIRMACION"
                Me.Soporte = TipoSoporte.CONFIRMACION
            Case "PORTICO"
                Me.Soporte = TipoSoporte.PORTICO
            Case "BANDEROLA"
                Me.Soporte = TipoSoporte.BANDEROLAD
            Case Else
                Me.Soporte = TipoSoporte.DESCONOCIDO
        End Select
        Me.angulo = CDbl(params(14))
        'omitimos WMFAncho - no lo usamos
        'omitimos WMFAlto - no lo usamos
        Me.ordenFila = CInt(params(17))
        Select Case UCase(params(18))
            Case "FRONTAL"
                Me.SopPanel = Orientacion.FRONTAL
            Case "POSTERIOR"
                Me.SopPanel = Orientacion.POSTERIOR
            Case "DERECHO"
                Me.SopPanel = Orientacion.DERECHO
            Case "IZQUIERDO"
                Me.SopPanel = Orientacion.IZQUIERDO
            Case Else
                Me.SopPanel = Orientacion.FRONTAL
        End Select
    End Sub

    'Functiones GET
    Public Function GetN_Gis() As Integer
        Return Me.N_Gis
    End Function
    Public Function GetN_Pla() As Integer
        Return Me.N_Pla
    End Function
    Public Function GetDemarcacion() As String
        Return Me.Demarcacion
    End Function
    Public Function GetUCarretera() As String
        Return Me.UCarretera
    End Function
    Public Function GetCarretera() As String
        Return Me.Carretera
    End Function
    Public Function GetPK() As Double
        Return Me.PK
    End Function
    Public Function GetTipoEje() As Eje
        Return Me.Tipo_Eje
    End Function
    Public Function GetGis_X() As Double
        Return Me.Gis_X
    End Function
    Public Function GetGis_Y() As Double
        Return Me.Gis_Y
    End Function
    Public Function GetDireccionalCodigo() As DireccionalCodigo
        Return Me.DireccionalCodigo
    End Function
    Public Function GetCodigo() As String
        Return Me.Codigo
    End Function
    Public Function GetGeometria() As Geometria
        Return Me.Geometria
    End Function
    Public Function GetNombreArchivo() As String
        Return Me.NombreArchivo
    End Function
    Public Function GetSoporte() As tipoSoporte
        Return Me.Soporte
    End Function
    Public Function GetAngulo() As Double
        Return Me.angulo
    End Function
    Public Function GetOrdenFila() As Integer
        Return Me.ordenFila
    End Function
    Public Function GetSopPanel() As Orientacion
        Return Me.SopPanel
    End Function

    'Procedimientos SET
    Public Sub SetN_Gis(ByVal N_Gis As Integer)
        Me.N_Gis = N_Gis
    End Sub
    Public Sub SetN_Pla(ByVal N_Pla As Integer)
        Me.N_Pla = N_Pla
    End Sub
    Public Sub SetDemarcacion(ByVal Demarcacion As String)
        Me.Demarcacion = Demarcacion
    End Sub
    Public Sub SetUCarretera(ByVal UCarretera As String)
        Me.UCarretera = UCarretera
    End Sub
    Public Sub SetPK(ByVal PK As Double)
        Me.PK = PK
    End Sub
    Public Sub SetTipoEje(ByVal tipoEje As Eje)
        Me.Tipo_Eje = tipoEje
    End Sub
    Public Sub SetGis_X(ByVal Gis_X As Double)
        Me.Gis_X = Gis_X
    End Sub
    Public Sub SetGis_Y(ByVal Gis_Y As Double)
        Me.Gis_Y = Gis_Y
    End Sub
    Public Sub SetDireccionalCodigo(ByVal DireccionalCodigo As DireccionalCodigo)
        Me.DireccionalCodigo = DireccionalCodigo
    End Sub
    Public Sub SetCodigo(ByVal Codigo As String)
        Me.Codigo = Codigo
    End Sub
    Public Sub SetGeometria(ByVal geometria As Geometria)
        Me.Geometria = geometria
    End Sub
    Public Sub SetNombreArchivo(ByVal nombreArchivo As String)
        Me.NombreArchivo = nombreArchivo
    End Sub
    Public Sub SetSoporte(ByVal soporte As tiposoporte)
        Me.Soporte = soporte
    End Sub
    Public Sub SetAngulo(ByVal angulo As Double)
        Me.angulo = angulo
    End Sub
    Public Sub SetOrdenFila(ByVal ordenFila As Integer)
        Me.ordenFila = ordenFila
    End Sub
    Public Sub SetSopPanel(ByVal sopPanel As Orientacion)
        Me.SopPanel = sopPanel
    End Sub

    'Resto de Subprogramas
    Public Shared Function ConvertToSeñal(ByVal listaComponentes As List(Of ModeloDatosIntermedio)) As Señal

        If listaComponentes.Count < 1 Then
            Throw New ArgumentException("La lista de datosIntermedios debe contener al menos un elemento")
        End If
        Dim señal As Señal
        With listaComponentes.Item(0)

            'DEFINIR METADATOS

            Dim N_Gis As Integer = .GetN_Gis
            Dim rotacion As Double = ToAzimut(.GetAngulo)
            Dim demarcacion As String = .GetDemarcacion
            Dim unidadCarretera As String = .GetUCarretera
            Dim carretera As String = .GetCarretera
            Dim pk As Double = .GetPK
            Dim tipoeje As String = ""
            Select Case .GetTipoEje
                Case Eje.RAMAL
                    tipoeje = "RAMAL"
                Case Eje.TRONCO
                    tipoeje = "TRONCO"
            End Select


            Dim posicionGPS As PosicionGPS = _
                posicionGPS.UTM_to_WGS84(New Punto3D(.GetGis_X, .GetGis_Y, 0))

            'DEFINIR PLACAS

            Dim placas As New List(Of Placa)
            For Each elemento In listaComponentes
                Dim textura As String = Replace(UCase(elemento.GetNombreArchivo), "PNG", "JPG")
                Dim orientado As Double = 0.0
                Select Case elemento.GetSopPanel
                    Case Orientacion.FRONTAL
                        orientado = ToAzimut(.GetAngulo)
                    Case Orientacion.POSTERIOR
                        orientado = ToAzimut(.GetAngulo, Math.PI)
                    Case Orientacion.IZQUIERDO
                        orientado = ToAzimut(.GetAngulo, Math.PI / 2)
                    Case Orientacion.DERECHO
                        orientado = ToAzimut(.GetAngulo, -1 * Math.PI / 2)
                End Select
                Dim imagenAux As Image
                Try
                    imagenAux = Image.FromFile(Señalizacion.EnvironVar.PATH_IMAGENES & "\" & textura)
                Catch ex As System.IO.FileNotFoundException
                    imagenAux = Image.FromFile(Señalizacion.EnvironVar.PATH_IMAGENES & "\" & Señalizacion.EnvironVar.TEXTURA_NO_ENCONTRADA)
                    textura = TEXTURA_NO_ENCONTRADA
                End Try
                Dim posicion As New Punto3D
                If elemento.GetDireccionalCodigo = DireccionalCodigo.DIRECCIONAL Or textura = TEXTURA_NO_ENCONTRADA Then
                    posicion.SetX(-1 * ((((imagenAux.Width * factor_aumento_imagen) / 1000) / Punto3D.PULGADA) / 2))
                Else
                    posicion.SetX(-1 * (Placa.DEFAULT_ALTURA_PLACA / 2))
                End If
                posicion.SetY(Señalizacion.Soporte.DEFAULT_SEPARACION_PLACA)
                If elemento.Soporte = TipoSoporte.BANDEROLAD Then
                    posicion.SetY(PLUS_DISTANCIA_Y_BANDEROLA * Señalizacion.Soporte.DEFAULT_SEPARACION_PLACA)
                    posicion.SetX(-1 * ((Math.Abs(posicion.GetX) * 2) + Banderola.DEFAULT_PARTE_VISIBLE_LATERAL_BANDEROLA + (Banderola.DEFAULT_LATERAL_SOPORTE / 2)))
                End If
                'Determinar la forma de la placa
                Select Case elemento.GetDireccionalCodigo
                    Case DireccionalCodigo.VERTICAL
                        posicion.SetZ(Placa.DEFAULT_POSICION_Z_PLACA - ((elemento.GetOrdenFila - 1) * Placa.DEFAULT_ALTURA_PLACA))
                    Case DireccionalCodigo.DIRECCIONAL
                        Dim defaultZ As Double
                        Select Case elemento.GetSoporte
                            Case TipoSoporte.PREAVISO, TipoSoporte.CONFIRMACION, TipoSoporte.FLECHAD, TipoSoporte.FLECHAI, TipoSoporte.FLECHAID
                                defaultZ = Placa.DEFAULT_POSICION_Z_PLACA
                            Case TipoSoporte.BANDEROLAD
                                defaultZ = Banderola.DEFAULT_POSICION_Z
                            Case TipoSoporte.PORTICO
                                defaultZ = Portico.DEFAULT_POSICION_Z
                        End Select
                        posicion.SetZ(defaultZ - ((elemento.GetOrdenFila - 1) * (((imagenAux.Height * FACTOR_AUMENTO_IMAGEN) / 1000) / Punto3D.PULGADA)))
                End Select
                Dim placaActual As Placa = Nothing
                Select Case elemento.GetGeometria
                    Case Geometria.CUADRADO, Geometria.RECTÁNGULO, Geometria.PANEL
                        placaActual = New Rectangular(posicion, textura, orientado, (((imagenAux.Width * FACTOR_AUMENTO_IMAGEN) / 1000) / Punto3D.PULGADA), (((imagenAux.Height * FACTOR_AUMENTO_IMAGEN) / 1000) / Punto3D.PULGADA))
                    Case Geometria.VACIA
                        placaActual = New Rectangular(posicion, textura, orientado, (((imagenAux.Width * FACTOR_AUMENTO_IMAGEN) / 1000) / Punto3D.PULGADA), (((imagenAux.Height * FACTOR_AUMENTO_IMAGEN) / 1000) / Punto3D.PULGADA))
                    Case Geometria.CÍRCULO
                        placaActual = New Circular(posicion, textura, orientado)
                    Case Geometria.OCTÓGONO
                        placaActual = New Octogonal(posicion, textura, orientado)
                    Case Geometria.TRIÁNGULO
                        If UCase(elemento.GetCodigo) = "R-1" Then
                            'caso especial -> triangular invertida
                            placaActual = New TriangularInvertida(posicion, textura, orientado)
                        Else
                            placaActual = New Triangular(posicion, textura, orientado)
                        End If
                End Select
                placas.Add(placaActual)
            Next

            'DEFINIR SOPORTE.

            Dim soporte As Soporte = Nothing
            Select Case .GetDireccionalCodigo
                Case DireccionalCodigo.VERTICAL
                    Select Case .GetSoporte
                        Case TipoSoporte.FAROLA
                            soporte = New Farola()
                        Case TipoSoporte.POSTE
                            soporte = New Simple()
                        Case Else
                            soporte = New Simple()
                    End Select
                Case DireccionalCodigo.DIRECCIONAL
                    Dim cartelUnico As Image
                    Try
                        cartelUnico = Image.FromFile(Señalizacion.EnvironVar.PATH_IMAGENES & "\" & placas.Item(0).GetTextura)
                    Catch ex As Exception
                        cartelUnico = Image.FromFile(Señalizacion.EnvironVar.PATH_IMAGENES & "\" & Señalizacion.EnvironVar.TEXTURA_NO_ENCONTRADA)
                    End Try
                    Dim cartelesPortico As New List(Of Rectangular)
                    For Each cartel As Placa In placas
                        cartelesPortico.Add(CType(cartel, Rectangular))
                    Next
                    Select Case .GetSoporte
                        Case TipoSoporte.PREAVISO, _
                                TipoSoporte.CONFIRMACION, _
                                TipoSoporte.FLECHAD, TipoSoporte.FLECHAI, TipoSoporte.FLECHAID
                            soporte = New Doble(cartelUnico.Width / 1000)
                        Case TipoSoporte.BANDEROLAD
                            soporte = New Banderola(placas.Item(0))
                        Case TipoSoporte.PORTICO
                            soporte = New Portico(cartelesPortico)
                            'En este caso se redefine la posicion de las placas.
                            Dim origen As Double = -1 * (CType(soporte, Portico).GetTravesañoSuperior.GetAnchura / 2)
                            For Each cartel As Rectangular In placas
                                Dim posX As Double = origen
                                Select Case placas.IndexOf(cartel)
                                    Case 0
                                        posX = posX +
                                            Portico.DEFAULT_PARTE_VISIBLE_LATERALES_PORTICO
                                    Case 1
                                        posX = posX +
                                            Portico.DEFAULT_PARTE_VISIBLE_LATERALES_PORTICO +
                                            CType(placas(0), Rectangular).GetAnchura +
                                            Portico.DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES
                                    Case 2
                                        posX = posX +
                                            Portico.DEFAULT_PARTE_VISIBLE_LATERALES_PORTICO +
                                            CType(placas(0), Rectangular).GetAnchura +
                                            Portico.DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES +
                                            CType(placas(1), Rectangular).GetAnchura +
                                            Portico.DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES
                                    Case 3
                                        posX = posX +
                                            Portico.DEFAULT_PARTE_VISIBLE_LATERALES_PORTICO +
                                            CType(placas(0), Rectangular).GetAnchura +
                                            Portico.DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES +
                                            CType(placas(1), Rectangular).GetAnchura +
                                            Portico.DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES +
                                            CType(placas(2), Rectangular).GetAnchura +
                                            Portico.DEFAULT_PARTE_VISIBLE_ENTRE_CARTELES
                                End Select
                                cartel.SetPosicion(New Punto3D(posX, cartel.GetPosicion.GetY, cartel.GetPosicion.GetZ))
                            Next
                    End Select
            End Select
            señal = New Señal(N_Gis, posicionGPS, rotacion, soporte, placas, demarcacion, unidadCarretera, carretera, pk, tipoeje)
        End With
        Return señal
    End Function
    Public Function ToSeñal() As Señal
        Dim listaAuxiliar As New List(Of ModeloDatosIntermedio)
        listaAuxiliar.Add(Me)
        Return ConvertToSeñal(listaAuxiliar)
    End Function

End Class
