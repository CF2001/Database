<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class infoQuartos
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_IDquarto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ListBox_listaPacientes = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ListBox_listaCamas = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(325, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 32)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Informação Quartos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(73, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 20)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Insira a identificação do quarto"
        '
        'txt_IDquarto
        '
        Me.txt_IDquarto.Location = New System.Drawing.Point(73, 147)
        Me.txt_IDquarto.Name = "txt_IDquarto"
        Me.txt_IDquarto.Size = New System.Drawing.Size(126, 27)
        Me.txt_IDquarto.TabIndex = 46
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.CausesValidation = False
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(414, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 20)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Lista de Pacientes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(414, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 22)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "   Numero US   "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(518, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 22)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "       Nome       "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(622, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 22)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = " Data de Entrada "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Location = New System.Drawing.Point(744, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 22)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = " Data de Saida "
        '
        'ListBox_listaPacientes
        '
        Me.ListBox_listaPacientes.FormattingEnabled = True
        Me.ListBox_listaPacientes.ItemHeight = 20
        Me.ListBox_listaPacientes.Location = New System.Drawing.Point(414, 177)
        Me.ListBox_listaPacientes.Name = "ListBox_listaPacientes"
        Me.ListBox_listaPacientes.Size = New System.Drawing.Size(443, 144)
        Me.ListBox_listaPacientes.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.CausesValidation = False
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(412, 358)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 20)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Lista de Camas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(518, 386)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 22)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "       Estado       "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(414, 386)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 22)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "  Identificação  "
        '
        'ListBox_listaCamas
        '
        Me.ListBox_listaCamas.FormattingEnabled = True
        Me.ListBox_listaCamas.ItemHeight = 20
        Me.ListBox_listaCamas.Location = New System.Drawing.Point(414, 411)
        Me.ListBox_listaCamas.Name = "ListBox_listaCamas"
        Me.ListBox_listaCamas.Size = New System.Drawing.Size(216, 144)
        Me.ListBox_listaCamas.TabIndex = 58
        '
        'infoQuartos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 645)
        Me.Controls.Add(Me.ListBox_listaCamas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ListBox_listaPacientes)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_IDquarto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "infoQuartos"
        Me.Text = "infoQuartos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_IDquarto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ListBox_listaPacientes As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ListBox_listaCamas As ListBox
End Class
