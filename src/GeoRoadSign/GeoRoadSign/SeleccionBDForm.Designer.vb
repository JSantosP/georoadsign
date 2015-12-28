<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionBDForm
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
        Me.CrearBD_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExaminarBD_Button = New System.Windows.Forms.Button()
        Me.BDOpciones_GroupBox = New System.Windows.Forms.GroupBox()
        Me.Cargando_ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Cargando_Label = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AbrirBD_OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.CrearBD_SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.AbrirCSVSeñales_OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.BDOpciones_GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrearBD_Button
        '
        Me.CrearBD_Button.Location = New System.Drawing.Point(23, 49)
        Me.CrearBD_Button.Name = "CrearBD_Button"
        Me.CrearBD_Button.Size = New System.Drawing.Size(147, 31)
        Me.CrearBD_Button.TabIndex = 0
        Me.CrearBD_Button.Text = "Crear nueva Base de datos"
        Me.CrearBD_Button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Crear una nueva base de datos que contendrá la señalización"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Seleccionar una base de datos ya existente"
        '
        'ExaminarBD_Button
        '
        Me.ExaminarBD_Button.Location = New System.Drawing.Point(23, 121)
        Me.ExaminarBD_Button.Name = "ExaminarBD_Button"
        Me.ExaminarBD_Button.Size = New System.Drawing.Size(145, 31)
        Me.ExaminarBD_Button.TabIndex = 3
        Me.ExaminarBD_Button.Text = "Examinar"
        Me.ExaminarBD_Button.UseVisualStyleBackColor = True
        '
        'BDOpciones_GroupBox
        '
        Me.BDOpciones_GroupBox.Controls.Add(Me.Cargando_ProgressBar)
        Me.BDOpciones_GroupBox.Controls.Add(Me.CrearBD_Button)
        Me.BDOpciones_GroupBox.Controls.Add(Me.Label1)
        Me.BDOpciones_GroupBox.Controls.Add(Me.ExaminarBD_Button)
        Me.BDOpciones_GroupBox.Controls.Add(Me.Cargando_Label)
        Me.BDOpciones_GroupBox.Controls.Add(Me.Label2)
        Me.BDOpciones_GroupBox.Location = New System.Drawing.Point(24, 47)
        Me.BDOpciones_GroupBox.Name = "BDOpciones_GroupBox"
        Me.BDOpciones_GroupBox.Size = New System.Drawing.Size(337, 216)
        Me.BDOpciones_GroupBox.TabIndex = 5
        Me.BDOpciones_GroupBox.TabStop = False
        Me.BDOpciones_GroupBox.Text = "Opciones"
        '
        'Cargando_ProgressBar
        '
        Me.Cargando_ProgressBar.Location = New System.Drawing.Point(25, 181)
        Me.Cargando_ProgressBar.Name = "Cargando_ProgressBar"
        Me.Cargando_ProgressBar.Size = New System.Drawing.Size(295, 22)
        Me.Cargando_ProgressBar.TabIndex = 4
        Me.Cargando_ProgressBar.Visible = False
        '
        'Cargando_Label
        '
        Me.Cargando_Label.AutoSize = True
        Me.Cargando_Label.Location = New System.Drawing.Point(20, 165)
        Me.Cargando_Label.Name = "Cargando_Label"
        Me.Cargando_Label.Size = New System.Drawing.Size(158, 13)
        Me.Cargando_Label.TabIndex = 2
        Me.Cargando_Label.Text = "Cargando señales en memoria..."
        Me.Cargando_Label.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(285, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Seleccione la opción que se ajuste más a sus necesidades"
        '
        'AbrirBD_OpenFileDialog
        '
        Me.AbrirBD_OpenFileDialog.DefaultExt = "yap"
        Me.AbrirBD_OpenFileDialog.FileName = "baseDatos"
        Me.AbrirBD_OpenFileDialog.Filter = "Archivos de bases de datos|*.yap"
        '
        'CrearBD_SaveFileDialog
        '
        Me.CrearBD_SaveFileDialog.DefaultExt = "yap"
        Me.CrearBD_SaveFileDialog.Filter = "Archivos de bases de datos|*.yap"
        '
        'AbrirCSVSeñales_OpenFileDialog
        '
        Me.AbrirCSVSeñales_OpenFileDialog.DefaultExt = "csv"
        Me.AbrirCSVSeñales_OpenFileDialog.Filter = "Archivos de señalización|*.csv"
        Me.AbrirCSVSeñales_OpenFileDialog.Title = "Seleccione el fichero que contiene los datos de señalización a importar"
        '
        'SeleccionBDForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 274)
        Me.Controls.Add(Me.BDOpciones_GroupBox)
        Me.Controls.Add(Me.Label3)
        Me.Name = "SeleccionBDForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SeleccionBD"
        Me.BDOpciones_GroupBox.ResumeLayout(False)
        Me.BDOpciones_GroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrearBD_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExaminarBD_Button As System.Windows.Forms.Button
    Friend WithEvents BDOpciones_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AbrirBD_OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CrearBD_SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Cargando_ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Cargando_Label As System.Windows.Forms.Label
    Friend WithEvents AbrirCSVSeñales_OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
