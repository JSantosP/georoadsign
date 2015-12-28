<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.SeleccionarBD_Button = New System.Windows.Forms.Button()
        Me.SeleccionarTraza_Button = New System.Windows.Forms.Button()
        Me.VerSeñales_Button = New System.Windows.Forms.Button()
        Me.Exportar_Button = New System.Windows.Forms.Button()
        Me.EstadoBD_GroupBox = New System.Windows.Forms.GroupBox()
        Me.NumSeñales_Label = New System.Windows.Forms.Label()
        Me.ArchivoSeñalizacion_Label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EstadoBD_PictureBox = New System.Windows.Forms.PictureBox()
        Me.AbrirTraza_OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.EstadoTraza_GroupBox = New System.Windows.Forms.GroupBox()
        Me.NumPuntos_Label = New System.Windows.Forms.Label()
        Me.ArchivoTraza_Label = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.VariablesEntorno_GroupBox = New System.Windows.Forms.GroupBox()
        Me.ExaminarRutaModelos_Button = New System.Windows.Forms.Button()
        Me.ExaminarRutaMateriales_Button = New System.Windows.Forms.Button()
        Me.ExaimnarRutaImagenes_Button = New System.Windows.Forms.Button()
        Me.RutaModelos_TextBox = New System.Windows.Forms.TextBox()
        Me.RutaMateriales_TextBox = New System.Windows.Forms.TextBox()
        Me.RutaImagenes_TextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.EstadoBD_GroupBox.SuspendLayout()
        CType(Me.EstadoBD_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EstadoTraza_GroupBox.SuspendLayout()
        Me.VariablesEntorno_GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SeleccionarBD_Button
        '
        Me.SeleccionarBD_Button.Location = New System.Drawing.Point(66, 268)
        Me.SeleccionarBD_Button.Name = "SeleccionarBD_Button"
        Me.SeleccionarBD_Button.Size = New System.Drawing.Size(93, 43)
        Me.SeleccionarBD_Button.TabIndex = 0
        Me.SeleccionarBD_Button.Text = "Seleccionar base de datos"
        Me.SeleccionarBD_Button.UseVisualStyleBackColor = True
        '
        'SeleccionarTraza_Button
        '
        Me.SeleccionarTraza_Button.Location = New System.Drawing.Point(165, 268)
        Me.SeleccionarTraza_Button.Name = "SeleccionarTraza_Button"
        Me.SeleccionarTraza_Button.Size = New System.Drawing.Size(93, 43)
        Me.SeleccionarTraza_Button.TabIndex = 1
        Me.SeleccionarTraza_Button.Text = "Seleccionar traza GPS"
        Me.SeleccionarTraza_Button.UseVisualStyleBackColor = True
        '
        'VerSeñales_Button
        '
        Me.VerSeñales_Button.Location = New System.Drawing.Point(264, 268)
        Me.VerSeñales_Button.Name = "VerSeñales_Button"
        Me.VerSeñales_Button.Size = New System.Drawing.Size(93, 43)
        Me.VerSeñales_Button.TabIndex = 2
        Me.VerSeñales_Button.Text = "Ver señales"
        Me.VerSeñales_Button.UseVisualStyleBackColor = True
        '
        'Exportar_Button
        '
        Me.Exportar_Button.Location = New System.Drawing.Point(363, 268)
        Me.Exportar_Button.Name = "Exportar_Button"
        Me.Exportar_Button.Size = New System.Drawing.Size(93, 43)
        Me.Exportar_Button.TabIndex = 3
        Me.Exportar_Button.Text = "Exportación a KML"
        Me.Exportar_Button.UseVisualStyleBackColor = True
        '
        'EstadoBD_GroupBox
        '
        Me.EstadoBD_GroupBox.Controls.Add(Me.NumSeñales_Label)
        Me.EstadoBD_GroupBox.Controls.Add(Me.ArchivoSeñalizacion_Label)
        Me.EstadoBD_GroupBox.Controls.Add(Me.Label2)
        Me.EstadoBD_GroupBox.Controls.Add(Me.Label1)
        Me.EstadoBD_GroupBox.Controls.Add(Me.EstadoBD_PictureBox)
        Me.EstadoBD_GroupBox.Location = New System.Drawing.Point(12, 129)
        Me.EstadoBD_GroupBox.Name = "EstadoBD_GroupBox"
        Me.EstadoBD_GroupBox.Size = New System.Drawing.Size(260, 119)
        Me.EstadoBD_GroupBox.TabIndex = 5
        Me.EstadoBD_GroupBox.TabStop = False
        Me.EstadoBD_GroupBox.Text = "Estado de Base de datos"
        '
        'NumSeñales_Label
        '
        Me.NumSeñales_Label.AutoSize = True
        Me.NumSeñales_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumSeñales_Label.Location = New System.Drawing.Point(51, 98)
        Me.NumSeñales_Label.Name = "NumSeñales_Label"
        Me.NumSeñales_Label.Size = New System.Drawing.Size(11, 13)
        Me.NumSeñales_Label.TabIndex = 3
        Me.NumSeñales_Label.Text = "-"
        '
        'ArchivoSeñalizacion_Label
        '
        Me.ArchivoSeñalizacion_Label.AutoSize = True
        Me.ArchivoSeñalizacion_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArchivoSeñalizacion_Label.Location = New System.Drawing.Point(51, 51)
        Me.ArchivoSeñalizacion_Label.Name = "ArchivoSeñalizacion_Label"
        Me.ArchivoSeñalizacion_Label.Size = New System.Drawing.Size(11, 13)
        Me.ArchivoSeñalizacion_Label.TabIndex = 2
        Me.ArchivoSeñalizacion_Label.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Número de señales almacenadas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Archivo de señalización"
        '
        'EstadoBD_PictureBox
        '
        Me.EstadoBD_PictureBox.Image = Global.GeoRoadSign.My.Resources.Resources.Semaforo_rojo
        Me.EstadoBD_PictureBox.InitialImage = Global.GeoRoadSign.My.Resources.Resources.Semaforo_rojo
        Me.EstadoBD_PictureBox.Location = New System.Drawing.Point(16, 26)
        Me.EstadoBD_PictureBox.Name = "EstadoBD_PictureBox"
        Me.EstadoBD_PictureBox.Size = New System.Drawing.Size(18, 51)
        Me.EstadoBD_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EstadoBD_PictureBox.TabIndex = 0
        Me.EstadoBD_PictureBox.TabStop = False
        '
        'AbrirTraza_OpenFileDialog
        '
        Me.AbrirTraza_OpenFileDialog.DefaultExt = "csv"
        Me.AbrirTraza_OpenFileDialog.Filter = "Archivos de traza GPS|*.csv"
        '
        'EstadoTraza_GroupBox
        '
        Me.EstadoTraza_GroupBox.Controls.Add(Me.NumPuntos_Label)
        Me.EstadoTraza_GroupBox.Controls.Add(Me.ArchivoTraza_Label)
        Me.EstadoTraza_GroupBox.Controls.Add(Me.Label4)
        Me.EstadoTraza_GroupBox.Controls.Add(Me.Label3)
        Me.EstadoTraza_GroupBox.Location = New System.Drawing.Point(278, 129)
        Me.EstadoTraza_GroupBox.Name = "EstadoTraza_GroupBox"
        Me.EstadoTraza_GroupBox.Size = New System.Drawing.Size(258, 119)
        Me.EstadoTraza_GroupBox.TabIndex = 6
        Me.EstadoTraza_GroupBox.TabStop = False
        Me.EstadoTraza_GroupBox.Text = "Estado de Traza GPS"
        '
        'NumPuntos_Label
        '
        Me.NumPuntos_Label.AutoSize = True
        Me.NumPuntos_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumPuntos_Label.Location = New System.Drawing.Point(52, 98)
        Me.NumPuntos_Label.Name = "NumPuntos_Label"
        Me.NumPuntos_Label.Size = New System.Drawing.Size(11, 13)
        Me.NumPuntos_Label.TabIndex = 3
        Me.NumPuntos_Label.Text = "-"
        '
        'ArchivoTraza_Label
        '
        Me.ArchivoTraza_Label.AutoSize = True
        Me.ArchivoTraza_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArchivoTraza_Label.Location = New System.Drawing.Point(52, 51)
        Me.ArchivoTraza_Label.Name = "ArchivoTraza_Label"
        Me.ArchivoTraza_Label.Size = New System.Drawing.Size(11, 13)
        Me.ArchivoTraza_Label.TabIndex = 2
        Me.ArchivoTraza_Label.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Número de puntos almacenados"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Archivo de puntos"
        '
        'VariablesEntorno_GroupBox
        '
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.ExaminarRutaModelos_Button)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.ExaminarRutaMateriales_Button)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.ExaimnarRutaImagenes_Button)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.RutaModelos_TextBox)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.RutaMateriales_TextBox)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.RutaImagenes_TextBox)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.Label7)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.Label6)
        Me.VariablesEntorno_GroupBox.Controls.Add(Me.Label5)
        Me.VariablesEntorno_GroupBox.Location = New System.Drawing.Point(12, 12)
        Me.VariablesEntorno_GroupBox.Name = "VariablesEntorno_GroupBox"
        Me.VariablesEntorno_GroupBox.Size = New System.Drawing.Size(524, 111)
        Me.VariablesEntorno_GroupBox.TabIndex = 8
        Me.VariablesEntorno_GroupBox.TabStop = False
        Me.VariablesEntorno_GroupBox.Text = "Variables de configuración"
        '
        'ExaminarRutaModelos_Button
        '
        Me.ExaminarRutaModelos_Button.Location = New System.Drawing.Point(412, 79)
        Me.ExaminarRutaModelos_Button.Name = "ExaminarRutaModelos_Button"
        Me.ExaminarRutaModelos_Button.Size = New System.Drawing.Size(95, 20)
        Me.ExaminarRutaModelos_Button.TabIndex = 6
        Me.ExaminarRutaModelos_Button.Text = "Examinar"
        Me.ExaminarRutaModelos_Button.UseVisualStyleBackColor = True
        '
        'ExaminarRutaMateriales_Button
        '
        Me.ExaminarRutaMateriales_Button.Location = New System.Drawing.Point(412, 53)
        Me.ExaminarRutaMateriales_Button.Name = "ExaminarRutaMateriales_Button"
        Me.ExaminarRutaMateriales_Button.Size = New System.Drawing.Size(95, 20)
        Me.ExaminarRutaMateriales_Button.TabIndex = 5
        Me.ExaminarRutaMateriales_Button.Text = "Examinar"
        Me.ExaminarRutaMateriales_Button.UseVisualStyleBackColor = True
        '
        'ExaimnarRutaImagenes_Button
        '
        Me.ExaimnarRutaImagenes_Button.Location = New System.Drawing.Point(412, 27)
        Me.ExaimnarRutaImagenes_Button.Name = "ExaimnarRutaImagenes_Button"
        Me.ExaimnarRutaImagenes_Button.Size = New System.Drawing.Size(95, 20)
        Me.ExaimnarRutaImagenes_Button.TabIndex = 4
        Me.ExaimnarRutaImagenes_Button.Text = "Examinar"
        Me.ExaimnarRutaImagenes_Button.UseVisualStyleBackColor = True
        '
        'RutaModelos_TextBox
        '
        Me.RutaModelos_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RutaModelos_TextBox.Location = New System.Drawing.Point(109, 79)
        Me.RutaModelos_TextBox.Name = "RutaModelos_TextBox"
        Me.RutaModelos_TextBox.ReadOnly = True
        Me.RutaModelos_TextBox.Size = New System.Drawing.Size(297, 20)
        Me.RutaModelos_TextBox.TabIndex = 3
        '
        'RutaMateriales_TextBox
        '
        Me.RutaMateriales_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RutaMateriales_TextBox.Location = New System.Drawing.Point(109, 53)
        Me.RutaMateriales_TextBox.Name = "RutaMateriales_TextBox"
        Me.RutaMateriales_TextBox.ReadOnly = True
        Me.RutaMateriales_TextBox.Size = New System.Drawing.Size(297, 20)
        Me.RutaMateriales_TextBox.TabIndex = 2
        '
        'RutaImagenes_TextBox
        '
        Me.RutaImagenes_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RutaImagenes_TextBox.Location = New System.Drawing.Point(109, 27)
        Me.RutaImagenes_TextBox.Name = "RutaImagenes_TextBox"
        Me.RutaImagenes_TextBox.ReadOnly = True
        Me.RutaImagenes_TextBox.Size = New System.Drawing.Size(297, 20)
        Me.RutaImagenes_TextBox.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Ruta modelos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Ruta materiales"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Ruta imágenes"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 334)
        Me.Controls.Add(Me.VariablesEntorno_GroupBox)
        Me.Controls.Add(Me.EstadoTraza_GroupBox)
        Me.Controls.Add(Me.EstadoBD_GroupBox)
        Me.Controls.Add(Me.Exportar_Button)
        Me.Controls.Add(Me.VerSeñales_Button)
        Me.Controls.Add(Me.SeleccionarTraza_Button)
        Me.Controls.Add(Me.SeleccionarBD_Button)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GeoRoadSign"
        Me.EstadoBD_GroupBox.ResumeLayout(False)
        Me.EstadoBD_GroupBox.PerformLayout()
        CType(Me.EstadoBD_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EstadoTraza_GroupBox.ResumeLayout(False)
        Me.EstadoTraza_GroupBox.PerformLayout()
        Me.VariablesEntorno_GroupBox.ResumeLayout(False)
        Me.VariablesEntorno_GroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SeleccionarBD_Button As System.Windows.Forms.Button
    Friend WithEvents SeleccionarTraza_Button As System.Windows.Forms.Button
    Friend WithEvents VerSeñales_Button As System.Windows.Forms.Button
    Friend WithEvents Exportar_Button As System.Windows.Forms.Button
    Friend WithEvents EstadoBD_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ArchivoSeñalizacion_Label As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EstadoBD_PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NumSeñales_Label As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AbrirTraza_OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents EstadoTraza_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents NumPuntos_Label As System.Windows.Forms.Label
    Friend WithEvents ArchivoTraza_Label As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents VariablesEntorno_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ExaminarRutaModelos_Button As System.Windows.Forms.Button
    Friend WithEvents ExaminarRutaMateriales_Button As System.Windows.Forms.Button
    Friend WithEvents ExaimnarRutaImagenes_Button As System.Windows.Forms.Button
    Friend WithEvents RutaModelos_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents RutaMateriales_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents RutaImagenes_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog

End Class
