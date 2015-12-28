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

Public Class SeleccionBDForm

    Private Sub SeleccionBDForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = My.Resources.icon
    End Sub

    Private Sub CrearBD_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearBD_Button.Click

        CrearBD_SaveFileDialog.ShowDialog()
        Dim archivo As String = CrearBD_SaveFileDialog.FileName
        Try
            'IO.File.Create(archivo)
            MainForm.variablesEntorno.pathBaseDatos = archivo
            AbrirCSVSeñales_OpenFileDialog.FileName = ""
            AbrirCSVSeñales_OpenFileDialog.ShowDialog()
            If AbrirCSVSeñales_OpenFileDialog.FileName = "" Then
                MsgBox("No se ha seleccionado fichero de señalización válido", MsgBoxStyle.Critical, My.Application.Info.Title)
                Exit Sub
            End If
            Dim miModuloLector As New Input2IntermediateData.ModuloLector(AbrirCSVSeñales_OpenFileDialog.FileName, MainForm.variablesEntorno.pathBaseDatos)
            miModuloLector.procesarFichero()
            Dim BaseDatos As New Persistencia.BaseDatos(archivo)

            cargarSeñalesEnMemoria(BaseDatos)
            MainForm.EstadoBD_PictureBox.Image = My.Resources.Semaforo_verde
            MainForm.ArchivoSeñalizacion_Label.Text = MainForm.variablesEntorno.pathBaseDatos
            MainForm.NumSeñales_Label.Text = MainForm.variablesEntorno.señales.Count
            MsgBox("Base de datos creada con éxito", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Catch ex As Exception
            MainForm.ArchivoSeñalizacion_Label.Text = "-"
            MainForm.NumSeñales_Label.Text = "0"
            MainForm.EstadoBD_PictureBox.Image = My.Resources.Semaforo_rojo
            MsgBox("Error al crear la base de datos" & _
                   vbCrLf & ex.Message, MsgBoxStyle.Exclamation, My.Application.Info.Title)
        End Try

    End Sub

    Private Sub ExaminarBD_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExaminarBD_Button.Click

        AbrirBD_OpenFileDialog.ShowDialog()
        Dim archivo As String = AbrirBD_OpenFileDialog.FileName
        Try
            MainForm.variablesEntorno.pathBaseDatos = archivo
            Dim BaseDatosExistente As New Persistencia.BaseDatos(archivo)
            cargarSeñalesEnMemoria(BaseDatosExistente)
            MainForm.EstadoBD_PictureBox.Image = My.Resources.Semaforo_verde
            MainForm.ArchivoSeñalizacion_Label.Text = MainForm.variablesEntorno.pathBaseDatos
            MainForm.NumSeñales_Label.Text = MainForm.variablesEntorno.señales.Count
            MsgBox("¡Base de datos cargada!", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Catch ex As Exception
            MainForm.ArchivoSeñalizacion_Label.Text = "-"
            MainForm.NumSeñales_Label.Text = "0"
            MainForm.EstadoBD_PictureBox.Image = My.Resources.Semaforo_rojo
            MsgBox("Error al crear la base de datos" & _
                   vbCrLf & ex.Message, MsgBoxStyle.Exclamation, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub cargarSeñalesEnMemoria(ByRef bd As Persistencia.BaseDatos)
        Cargando_Label.Visible = True
        Cargando_ProgressBar.Visible = True
        Cargando_Label.Update()
        Cargando_ProgressBar.Value = 50
        Cargando_ProgressBar.Update()
        bd.abrir()
        MainForm.variablesEntorno.señales = bd.devolver
        bd.cerrar()
        For i As Integer = 50 To 100
            Threading.Thread.Sleep(10)
            Cargando_ProgressBar.Value = i
            Cargando_ProgressBar.Update()
        Next
        Cargando_Label.Visible = False
        Cargando_ProgressBar.Visible = False
    End Sub
End Class