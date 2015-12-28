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

Public Class MainForm
    Private Enum TipoRuta
        IMAGENES
        MATERIALES
        MODELOS
    End Enum

    Public variablesEntorno As New EnvironVar

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = My.Resources.icon

        Me.RutaImagenes_TextBox.Text = EnvironVar.DEFAULT_PATH_IMAGENES
        Me.RutaMateriales_TextBox.Text = EnvironVar.DEFAULT_PATH_MATERIALES
        Me.RutaModelos_TextBox.Text = EnvironVar.DEFAULT_PATH_MODELOS
        Me.variablesEntorno.pathImagenes = Me.RutaImagenes_TextBox.Text
        Me.variablesEntorno.pathMateriales = Me.RutaMateriales_TextBox.Text
        Me.variablesEntorno.pathModelos = Me.RutaModelos_TextBox.Text

    End Sub

    Private Sub SeleccionarBD_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarBD_Button.Click
        SeleccionBDForm.ShowDialog()
    End Sub

    Private Sub SeleccionarTraza_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTraza_Button.Click
        AbrirTraza_OpenFileDialog.ShowDialog()
        Dim traza As String = AbrirTraza_OpenFileDialog.FileName
        Dim lector As New IntermediateData2KML.LectorGPS(traza, 1) 'Cogemos todos los puntos para visualizar el total, aunque luego se exporten menos
        Try
            Me.NumPuntos_Label.Text = lector.procesaFichero.Count
            Me.ArchivoTraza_Label.Text = traza
            Me.variablesEntorno.pathTraza = traza
            MsgBox("Archivo cargado con éxito", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As Exception
            Me.NumPuntos_Label.Text = "0"
            Me.ArchivoTraza_Label.Text = "-"
            MsgBox("El archivo de traza está corrupto o no es válido", MsgBoxStyle.Exclamation, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub ExaimnarRutaImagenes_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExaimnarRutaImagenes_Button.Click
        ActualizarRuta(TipoRuta.IMAGENES)
    End Sub

    Private Sub ExaminarRutaMateriales_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExaminarRutaMateriales_Button.Click
        ActualizarRuta(TipoRuta.MATERIALES)
    End Sub

    Private Sub ExaminarRutaModelos_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExaminarRutaModelos_Button.Click
        ActualizarRuta(TipoRuta.MODELOS)
    End Sub

    Private Sub ActualizarRuta(ByVal tipo As TipoRuta)
        Dim rutaActual As String = ""
        Select Case tipo
            Case TipoRuta.IMAGENES
                rutaActual = Me.RutaImagenes_TextBox.Text
            Case TipoRuta.MATERIALES
                rutaActual = Me.RutaMateriales_TextBox.Text
            Case TipoRuta.MODELOS
                rutaActual = Me.RutaModelos_TextBox.Text
        End Select
        Me.FolderBrowserDialog.SelectedPath = ""
        Me.FolderBrowserDialog.ShowDialog()
        If Me.FolderBrowserDialog.SelectedPath <> "" And Me.FolderBrowserDialog.SelectedPath <> rutaActual Then
            Select Case tipo
                Case TipoRuta.IMAGENES
                    Me.variablesEntorno.pathImagenes = Me.FolderBrowserDialog.SelectedPath
                    Me.RutaImagenes_TextBox.Text = Me.FolderBrowserDialog.SelectedPath
                Case TipoRuta.MATERIALES
                    Me.variablesEntorno.pathMateriales = Me.FolderBrowserDialog.SelectedPath
                    Me.RutaMateriales_TextBox.Text = Me.FolderBrowserDialog.SelectedPath
                Case TipoRuta.MODELOS
                    Me.variablesEntorno.pathModelos = Me.FolderBrowserDialog.SelectedPath
                    Me.RutaModelos_TextBox.Text = Me.FolderBrowserDialog.SelectedPath
            End Select
        End If
    End Sub

    Private Sub VerSeñales_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerSeñales_Button.Click
        If Me.variablesEntorno.señales.Count > 0 Then
            DetallesSeñalesForm.ShowDialog()
        Else
            MsgBox("No se pueden mostrar señales" & vbCrLf & "Asegurese de que haya una base de datos no vacía cargada en memoria", MsgBoxStyle.Exclamation, My.Application.Info.Title)
        End If
    End Sub

    Private Sub Exportar_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exportar_Button.Click
        ExportacionForm.ShowDialog()
    End Sub
End Class
