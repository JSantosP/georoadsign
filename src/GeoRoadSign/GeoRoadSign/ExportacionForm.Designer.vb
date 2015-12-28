<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportacionForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SeñalesExportacion_CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpcionesExportacion_GroupBox = New System.Windows.Forms.GroupBox()
        Me.Exportar_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PrecisionPuntos_TextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.InclinacionCamara_TextBox = New System.Windows.Forms.TextBox()
        Me.FactorVelocidad_TrackBar = New System.Windows.Forms.TrackBar()
        Me.Velocidad_Label = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AlturaVuelo_TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DistanciaCamaraPunto_TextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SeleccionarTodo_Button = New System.Windows.Forms.Button()
        Me.DeseleccionarTodo_Button = New System.Windows.Forms.Button()
        Me.OpcionesExportacion_GroupBox.SuspendLayout()
        CType(Me.FactorVelocidad_TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SeñalesExportacion_CheckedListBox
        '
        Me.SeñalesExportacion_CheckedListBox.CheckOnClick = True
        Me.SeñalesExportacion_CheckedListBox.FormattingEnabled = True
        Me.SeñalesExportacion_CheckedListBox.Location = New System.Drawing.Point(12, 60)
        Me.SeñalesExportacion_CheckedListBox.Name = "SeñalesExportacion_CheckedListBox"
        Me.SeñalesExportacion_CheckedListBox.Size = New System.Drawing.Size(217, 199)
        Me.SeñalesExportacion_CheckedListBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione las señales que desea exportar"
        '
        'OpcionesExportacion_GroupBox
        '
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.DistanciaCamaraPunto_TextBox)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.AlturaVuelo_TextBox)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.FactorVelocidad_TrackBar)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.InclinacionCamara_TextBox)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Velocidad_Label)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label9)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label5)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label4)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label3)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.PrecisionPuntos_TextBox)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label8)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label7)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label10)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label6)
        Me.OpcionesExportacion_GroupBox.Controls.Add(Me.Label2)
        Me.OpcionesExportacion_GroupBox.Location = New System.Drawing.Point(243, 54)
        Me.OpcionesExportacion_GroupBox.Name = "OpcionesExportacion_GroupBox"
        Me.OpcionesExportacion_GroupBox.Size = New System.Drawing.Size(317, 205)
        Me.OpcionesExportacion_GroupBox.TabIndex = 2
        Me.OpcionesExportacion_GroupBox.TabStop = False
        Me.OpcionesExportacion_GroupBox.Text = "Opciones"
        '
        'Exportar_Button
        '
        Me.Exportar_Button.Location = New System.Drawing.Point(351, 265)
        Me.Exportar_Button.Name = "Exportar_Button"
        Me.Exportar_Button.Size = New System.Drawing.Size(106, 23)
        Me.Exportar_Button.TabIndex = 3
        Me.Exportar_Button.Text = "Exportar "
        Me.Exportar_Button.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Precisión puntos GPS"
        '
        'PrecisionPuntos_TextBox
        '
        Me.PrecisionPuntos_TextBox.Location = New System.Drawing.Point(161, 76)
        Me.PrecisionPuntos_TextBox.Name = "PrecisionPuntos_TextBox"
        Me.PrecisionPuntos_TextBox.Size = New System.Drawing.Size(59, 20)
        Me.PrecisionPuntos_TextBox.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Velocidad"
        '
        'InclinacionCamara_TextBox
        '
        Me.InclinacionCamara_TextBox.Location = New System.Drawing.Point(161, 102)
        Me.InclinacionCamara_TextBox.Name = "InclinacionCamara_TextBox"
        Me.InclinacionCamara_TextBox.Size = New System.Drawing.Size(59, 20)
        Me.InclinacionCamara_TextBox.TabIndex = 3
        '
        'FactorVelocidad_TrackBar
        '
        Me.FactorVelocidad_TrackBar.Location = New System.Drawing.Point(89, 31)
        Me.FactorVelocidad_TrackBar.Minimum = 1
        Me.FactorVelocidad_TrackBar.Name = "FactorVelocidad_TrackBar"
        Me.FactorVelocidad_TrackBar.Size = New System.Drawing.Size(174, 45)
        Me.FactorVelocidad_TrackBar.TabIndex = 4
        Me.FactorVelocidad_TrackBar.Value = 1
        '
        'Velocidad_Label
        '
        Me.Velocidad_Label.AutoSize = True
        Me.Velocidad_Label.Location = New System.Drawing.Point(269, 43)
        Me.Velocidad_Label.Name = "Velocidad_Label"
        Me.Velocidad_Label.Size = New System.Drawing.Size(23, 13)
        Me.Velocidad_Label.TabIndex = 2
        Me.Velocidad_Label.Text = "1 X"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Inclinación de cámara"
        '
        'AlturaVuelo_TextBox
        '
        Me.AlturaVuelo_TextBox.Location = New System.Drawing.Point(161, 129)
        Me.AlturaVuelo_TextBox.Name = "AlturaVuelo_TextBox"
        Me.AlturaVuelo_TextBox.Size = New System.Drawing.Size(59, 20)
        Me.AlturaVuelo_TextBox.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Altura de vuelo"
        '
        'DistanciaCamaraPunto_TextBox
        '
        Me.DistanciaCamaraPunto_TextBox.Location = New System.Drawing.Point(161, 155)
        Me.DistanciaCamaraPunto_TextBox.Name = "DistanciaCamaraPunto_TextBox"
        Me.DistanciaCamaraPunto_TextBox.Size = New System.Drawing.Size(59, 20)
        Me.DistanciaCamaraPunto_TextBox.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(226, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "grados"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(226, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "metros"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(226, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "metros"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 158)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Distancia cámara-punto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(226, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "puntos"
        '
        'SeleccionarTodo_Button
        '
        Me.SeleccionarTodo_Button.Location = New System.Drawing.Point(12, 265)
        Me.SeleccionarTodo_Button.Name = "SeleccionarTodo_Button"
        Me.SeleccionarTodo_Button.Size = New System.Drawing.Size(96, 23)
        Me.SeleccionarTodo_Button.TabIndex = 4
        Me.SeleccionarTodo_Button.Text = "Seleccionar todo"
        Me.SeleccionarTodo_Button.UseVisualStyleBackColor = True
        '
        'DeseleccionarTodo_Button
        '
        Me.DeseleccionarTodo_Button.Location = New System.Drawing.Point(114, 265)
        Me.DeseleccionarTodo_Button.Name = "DeseleccionarTodo_Button"
        Me.DeseleccionarTodo_Button.Size = New System.Drawing.Size(115, 23)
        Me.DeseleccionarTodo_Button.TabIndex = 5
        Me.DeseleccionarTodo_Button.Text = "Deseleccionar todo"
        Me.DeseleccionarTodo_Button.UseVisualStyleBackColor = True
        '
        'ExportacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 301)
        Me.Controls.Add(Me.DeseleccionarTodo_Button)
        Me.Controls.Add(Me.SeleccionarTodo_Button)
        Me.Controls.Add(Me.Exportar_Button)
        Me.Controls.Add(Me.OpcionesExportacion_GroupBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SeñalesExportacion_CheckedListBox)
        Me.Name = "ExportacionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportacion"
        Me.OpcionesExportacion_GroupBox.ResumeLayout(False)
        Me.OpcionesExportacion_GroupBox.PerformLayout()
        CType(Me.FactorVelocidad_TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SeñalesExportacion_CheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpcionesExportacion_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DistanciaCamaraPunto_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AlturaVuelo_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents FactorVelocidad_TrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents InclinacionCamara_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Velocidad_Label As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PrecisionPuntos_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Exportar_Button As System.Windows.Forms.Button
    Friend WithEvents SeleccionarTodo_Button As System.Windows.Forms.Button
    Friend WithEvents DeseleccionarTodo_Button As System.Windows.Forms.Button
End Class
