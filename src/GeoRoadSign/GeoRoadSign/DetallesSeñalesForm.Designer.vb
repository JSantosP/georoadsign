<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesSeñalesForm
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
        Me.Señales_TreeView = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Preview_PictureBox = New System.Windows.Forms.PictureBox()
        Me.InfoSeñal_GroupBox = New System.Windows.Forms.GroupBox()
        Me.Carretera_TextBox = New System.Windows.Forms.TextBox()
        Me.CodigoPlaca_TextBox = New System.Windows.Forms.TextBox()
        Me.Rotacion_TextBox = New System.Windows.Forms.TextBox()
        Me.PosicionGPS_TextBox = New System.Windows.Forms.TextBox()
        Me.PK_TextBox = New System.Windows.Forms.TextBox()
        Me.UCarreteras_TextBox = New System.Windows.Forms.TextBox()
        Me.Demarcacion_TextBox = New System.Windows.Forms.TextBox()
        Me.IdentificadorPlaca_TextBox = New System.Windows.Forms.TextBox()
        Me.NumGis_TextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExpandirTodo_Button = New System.Windows.Forms.Button()
        Me.ContraerTodo_Button = New System.Windows.Forms.Button()
        CType(Me.Preview_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InfoSeñal_GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Señales_TreeView
        '
        Me.Señales_TreeView.Location = New System.Drawing.Point(12, 39)
        Me.Señales_TreeView.Name = "Señales_TreeView"
        Me.Señales_TreeView.Size = New System.Drawing.Size(245, 436)
        Me.Señales_TreeView.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Listado de señales"
        '
        'Preview_PictureBox
        '
        Me.Preview_PictureBox.BackColor = System.Drawing.Color.White
        Me.Preview_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Preview_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Preview_PictureBox.Location = New System.Drawing.Point(368, 39)
        Me.Preview_PictureBox.Name = "Preview_PictureBox"
        Me.Preview_PictureBox.Size = New System.Drawing.Size(180, 180)
        Me.Preview_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Preview_PictureBox.TabIndex = 2
        Me.Preview_PictureBox.TabStop = False
        '
        'InfoSeñal_GroupBox
        '
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Carretera_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.CodigoPlaca_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Rotacion_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.PosicionGPS_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.PK_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.UCarreteras_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Demarcacion_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.IdentificadorPlaca_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.NumGis_TextBox)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label6)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label8)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label7)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label5)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label10)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label4)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label3)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label9)
        Me.InfoSeñal_GroupBox.Controls.Add(Me.Label2)
        Me.InfoSeñal_GroupBox.Location = New System.Drawing.Point(263, 225)
        Me.InfoSeñal_GroupBox.Name = "InfoSeñal_GroupBox"
        Me.InfoSeñal_GroupBox.Size = New System.Drawing.Size(390, 284)
        Me.InfoSeñal_GroupBox.TabIndex = 3
        Me.InfoSeñal_GroupBox.TabStop = False
        Me.InfoSeñal_GroupBox.Text = "Info"
        '
        'Carretera_TextBox
        '
        Me.Carretera_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Carretera_TextBox.Location = New System.Drawing.Point(116, 110)
        Me.Carretera_TextBox.Name = "Carretera_TextBox"
        Me.Carretera_TextBox.ReadOnly = True
        Me.Carretera_TextBox.Size = New System.Drawing.Size(89, 20)
        Me.Carretera_TextBox.TabIndex = 9
        '
        'CodigoPlaca_TextBox
        '
        Me.CodigoPlaca_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CodigoPlaca_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodigoPlaca_TextBox.Location = New System.Drawing.Point(116, 32)
        Me.CodigoPlaca_TextBox.Name = "CodigoPlaca_TextBox"
        Me.CodigoPlaca_TextBox.ReadOnly = True
        Me.CodigoPlaca_TextBox.Size = New System.Drawing.Size(157, 20)
        Me.CodigoPlaca_TextBox.TabIndex = 8
        Me.CodigoPlaca_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Rotacion_TextBox
        '
        Me.Rotacion_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Rotacion_TextBox.Location = New System.Drawing.Point(116, 240)
        Me.Rotacion_TextBox.Name = "Rotacion_TextBox"
        Me.Rotacion_TextBox.ReadOnly = True
        Me.Rotacion_TextBox.Size = New System.Drawing.Size(131, 20)
        Me.Rotacion_TextBox.TabIndex = 7
        '
        'PosicionGPS_TextBox
        '
        Me.PosicionGPS_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PosicionGPS_TextBox.Location = New System.Drawing.Point(116, 214)
        Me.PosicionGPS_TextBox.Name = "PosicionGPS_TextBox"
        Me.PosicionGPS_TextBox.ReadOnly = True
        Me.PosicionGPS_TextBox.Size = New System.Drawing.Size(228, 20)
        Me.PosicionGPS_TextBox.TabIndex = 6
        '
        'PK_TextBox
        '
        Me.PK_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PK_TextBox.Location = New System.Drawing.Point(116, 188)
        Me.PK_TextBox.Name = "PK_TextBox"
        Me.PK_TextBox.ReadOnly = True
        Me.PK_TextBox.Size = New System.Drawing.Size(89, 20)
        Me.PK_TextBox.TabIndex = 5
        '
        'UCarreteras_TextBox
        '
        Me.UCarreteras_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UCarreteras_TextBox.Location = New System.Drawing.Point(116, 162)
        Me.UCarreteras_TextBox.Name = "UCarreteras_TextBox"
        Me.UCarreteras_TextBox.ReadOnly = True
        Me.UCarreteras_TextBox.Size = New System.Drawing.Size(131, 20)
        Me.UCarreteras_TextBox.TabIndex = 4
        '
        'Demarcacion_TextBox
        '
        Me.Demarcacion_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Demarcacion_TextBox.Location = New System.Drawing.Point(116, 136)
        Me.Demarcacion_TextBox.Name = "Demarcacion_TextBox"
        Me.Demarcacion_TextBox.ReadOnly = True
        Me.Demarcacion_TextBox.Size = New System.Drawing.Size(131, 20)
        Me.Demarcacion_TextBox.TabIndex = 3
        '
        'IdentificadorPlaca_TextBox
        '
        Me.IdentificadorPlaca_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IdentificadorPlaca_TextBox.Location = New System.Drawing.Point(116, 84)
        Me.IdentificadorPlaca_TextBox.Name = "IdentificadorPlaca_TextBox"
        Me.IdentificadorPlaca_TextBox.ReadOnly = True
        Me.IdentificadorPlaca_TextBox.Size = New System.Drawing.Size(228, 20)
        Me.IdentificadorPlaca_TextBox.TabIndex = 2
        '
        'NumGis_TextBox
        '
        Me.NumGis_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumGis_TextBox.Location = New System.Drawing.Point(116, 58)
        Me.NumGis_TextBox.Name = "NumGis_TextBox"
        Me.NumGis_TextBox.ReadOnly = True
        Me.NumGis_TextBox.Size = New System.Drawing.Size(48, 20)
        Me.NumGis_TextBox.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "PK"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Posicion GPS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Rotación"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Unidad Carreteras"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Carretera"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Demarcación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Identificador placa"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Código placa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Num_Gis"
        '
        'ExpandirTodo_Button
        '
        Me.ExpandirTodo_Button.Location = New System.Drawing.Point(12, 481)
        Me.ExpandirTodo_Button.Name = "ExpandirTodo_Button"
        Me.ExpandirTodo_Button.Size = New System.Drawing.Size(117, 23)
        Me.ExpandirTodo_Button.TabIndex = 4
        Me.ExpandirTodo_Button.Text = "Expandir todo"
        Me.ExpandirTodo_Button.UseVisualStyleBackColor = True
        '
        'ContraerTodo_Button
        '
        Me.ContraerTodo_Button.Location = New System.Drawing.Point(140, 481)
        Me.ContraerTodo_Button.Name = "ContraerTodo_Button"
        Me.ContraerTodo_Button.Size = New System.Drawing.Size(117, 23)
        Me.ContraerTodo_Button.TabIndex = 5
        Me.ContraerTodo_Button.Text = "Contraer todo"
        Me.ContraerTodo_Button.UseVisualStyleBackColor = True
        '
        'DetallesSeñalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 515)
        Me.Controls.Add(Me.ContraerTodo_Button)
        Me.Controls.Add(Me.ExpandirTodo_Button)
        Me.Controls.Add(Me.InfoSeñal_GroupBox)
        Me.Controls.Add(Me.Preview_PictureBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Señales_TreeView)
        Me.Name = "DetallesSeñalesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DetallesSeñales"
        CType(Me.Preview_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InfoSeñal_GroupBox.ResumeLayout(False)
        Me.InfoSeñal_GroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Señales_TreeView As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Preview_PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents InfoSeñal_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Rotacion_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PosicionGPS_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PK_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents UCarreteras_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Demarcacion_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents IdentificadorPlaca_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumGis_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CodigoPlaca_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Carretera_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ExpandirTodo_Button As System.Windows.Forms.Button
    Friend WithEvents ContraerTodo_Button As System.Windows.Forms.Button
End Class
