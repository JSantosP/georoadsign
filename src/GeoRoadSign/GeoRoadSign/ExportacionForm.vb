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

Public Class ExportacionForm

    Private Sub ExportacionForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = My.Resources.icon
        Me.PrecisionPuntos_TextBox.Text = IntermediateData2KML.LectorGPS.DEFAULT_PRECISION
        Me.InclinacionCamara_TextBox.Text = IntermediateData2KML.ViajeKML.DEFAULT_TILT
        Me.DistanciaCamaraPunto_TextBox.Text = IntermediateData2KML.ViajeKML.DEFAULT_RANGE
        Me.AlturaVuelo_TextBox.Text = IntermediateData2KML.ViajeKML.DEFAULT_ALTITUD

        RellenarListadoSeñalesExportacion()
    End Sub
    Private Sub RellenarListadoSeñalesExportacion()
        For Each elemento As Señalizacion.Señal In MainForm.variablesEntorno.señales
            Dim nombreSeñal As String = elemento.getNumGIS.ToString
            While nombreSeñal.Length < 3
                nombreSeñal = "0" & nombreSeñal
            End While
            SeñalesExportacion_CheckedListBox.Items.Add("Señal " & nombreSeñal, True)
        Next
        Me.SeñalesExportacion_CheckedListBox.Sorted = True
    End Sub

    Private Sub FactorVelocidad_TrackBar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FactorVelocidad_TrackBar.ValueChanged
        Me.Velocidad_Label.Text = FactorVelocidad_TrackBar.Value & " X"
    End Sub

    Private Sub SeleccionarTodo_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodo_Button.Click
        For i As Integer = 0 To SeñalesExportacion_CheckedListBox.Items.Count - 1
            SeñalesExportacion_CheckedListBox.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub DeseleccionarTodo_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeseleccionarTodo_Button.Click
        For i As Integer = 0 To SeñalesExportacion_CheckedListBox.Items.Count - 1
            SeñalesExportacion_CheckedListBox.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub Exportar_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exportar_Button.Click
        Dim saveFileDialog As New Windows.Forms.SaveFileDialog
        saveFileDialog.AddExtension = True
        saveFileDialog.DefaultExt = "kml"
        saveFileDialog.Filter = "Archivos kml|*.kml"
        saveFileDialog.FileName = ""
        saveFileDialog.ShowDialog()
        If saveFileDialog.FileName = "" Then
            MsgBox("Nombre de fichero no válido", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Exit Sub
        End If
        Dim señalesSeleccionadas As New List(Of Señalizacion.Señal)
        For Each elemento As String In SeñalesExportacion_CheckedListBox.CheckedItems
            For Each señal As Señalizacion.Señal In MainForm.variablesEntorno.señales
                If señal.getNumGIS = CDbl(Split(elemento, " ")(1)) Then
                    señalesSeleccionadas.Add(señal)
                End If
            Next
        Next
        Dim modEsc As New IntermediateData2KML.ModuloEscritor(saveFileDialog.FileName,
                                                              señalesSeleccionadas,
                                                              MainForm.variablesEntorno.pathTraza,
                                                              CDbl(Me.PrecisionPuntos_TextBox.Text),
                                                              CDbl(Me.FactorVelocidad_TrackBar.Value),
                                                              CDbl(Me.InclinacionCamara_TextBox.Text),
                                                              CDbl(Me.DistanciaCamaraPunto_TextBox.Text),
                                                              CDbl(Me.AlturaVuelo_TextBox.Text))
        modEsc.AlmacenarKML()
        MsgBox("Fichero kml generado con éxito", MsgBoxStyle.Information, My.Application.Info.Title)
    End Sub
End Class