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

Public Class DetallesSeñalesForm

    Private Sub DetallesSeñalesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = My.Resources.icon
        RellenarListadoSeñales()
    End Sub
    Private Sub RellenarListadoSeñales()
        Señales_TreeView.Nodes.Clear()
        borrarCampos()
        For Each elemento As Señalizacion.Señal In MainForm.variablesEntorno.señales
            Dim numGisNormalizado As String = elemento.getNumGIS.ToString
            While numGisNormalizado.Length < 3
                numGisNormalizado = "0" & numGisNormalizado
            End While
            Dim nodoSeñal As New TreeNode("Señal " & numGisNormalizado)
            For Each placa As Señalizacion.Placa In elemento.getPlacas
                nodoSeñal.Nodes.Add(placa.GetIdentificador)
            Next
            Me.Señales_TreeView.Nodes.Add(nodoSeñal)
        Next
        Me.Señales_TreeView.Sort()
        Me.Señales_TreeView.ExpandAll()
    End Sub

    Private Sub rellenarDatosPlaca(ByVal placa As String)
        For Each elemento As Señalizacion.Señal In MainForm.variablesEntorno.señales
            For Each subelemento As Señalizacion.Placa In elemento.getPlacas
                If subelemento.GetIdentificador = placa Then
                    Me.CodigoPlaca_TextBox.Text = subelemento.GetTextura.Split(".")(0)
                    Me.NumGis_TextBox.Text = elemento.getNumGIS
                    Me.IdentificadorPlaca_TextBox.Text = subelemento.GetIdentificador
                    Me.Carretera_TextBox.Text = elemento.getCarretera
                    Me.Demarcacion_TextBox.Text = elemento.getDemarcacion
                    Me.UCarreteras_TextBox.Text = elemento.getUnidadCarretera
                    Me.PK_TextBox.Text = elemento.getPk
                    Me.PosicionGPS_TextBox.Text = elemento.getPosicionGPS.GetLatitud.ToString.Replace(",", ".") & ";" & elemento.getPosicionGPS.GetLongitud.ToString.Replace(",", ".")
                    Me.Rotacion_TextBox.Text = Normalizacion.Rotacion.ToDegrees(subelemento.GetOrientacion).ToString.Replace(",", ".") & " º"
                    Me.Preview_PictureBox.ImageLocation = MainForm.variablesEntorno.pathImagenes & "\" & subelemento.GetTextura
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub Señales_TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Señales_TreeView.AfterSelect
        If Strings.Left(Señales_TreeView.SelectedNode.Text, 5) <> "Señal" Then
            rellenarDatosPlaca(Me.Señales_TreeView.SelectedNode.Text)
        End If
    End Sub
    Private Sub borrarCampos()
        Me.CodigoPlaca_TextBox.Text = ""
        Me.NumGis_TextBox.Text = ""
        Me.IdentificadorPlaca_TextBox.Text = ""
        Me.Carretera_TextBox.Text = ""
        Me.Demarcacion_TextBox.Text = ""
        Me.UCarreteras_TextBox.Text = ""
        Me.PK_TextBox.Text = ""
        Me.PosicionGPS_TextBox.Text = ""
        Me.Rotacion_TextBox.Text = ""
        Me.Preview_PictureBox.Image = Nothing
    End Sub

    Private Sub ExpandirTodo_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandirTodo_Button.Click
        Señales_TreeView.ExpandAll()
    End Sub

    Private Sub ContraerTodo_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraerTodo_Button.Click
        Señales_TreeView.CollapseAll()
    End Sub
End Class