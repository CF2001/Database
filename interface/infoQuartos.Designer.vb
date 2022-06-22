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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lv_CamaHospital = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader()
        Me.lv_Pacientes = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader()
        Me.bttn_eliminarR = New System.Windows.Forms.Button()
        Me.bbtn_AddPacienteInt = New System.Windows.Forms.Button()
        Me.txt_noUtenteSaude = New System.Windows.Forms.TextBox()
        Me.txt_DataEntrada = New System.Windows.Forms.TextBox()
        Me.txt_DataSaida = New System.Windows.Forms.TextBox()
        Me.bttn_Editar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_noUtenteS = New System.Windows.Forms.Label()
        Me.txt_firstName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_LastName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lv_EnfermeirosS = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(365, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 31)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Informação Quartos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(155, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 23)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Insira a identificação do quarto"
        '
        'txt_IDquarto
        '
        Me.txt_IDquarto.Location = New System.Drawing.Point(155, 101)
        Me.txt_IDquarto.Name = "txt_IDquarto"
        Me.txt_IDquarto.Size = New System.Drawing.Size(126, 27)
        Me.txt_IDquarto.TabIndex = 46
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.CausesValidation = False
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(155, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 23)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Lista de Pacientes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.CausesValidation = False
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(951, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 23)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Lista de Camas"
        '
        'lv_CamaHospital
        '
        Me.lv_CamaHospital.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lv_CamaHospital.Location = New System.Drawing.Point(951, 196)
        Me.lv_CamaHospital.Name = "lv_CamaHospital"
        Me.lv_CamaHospital.Size = New System.Drawing.Size(250, 271)
        Me.lv_CamaHospital.TabIndex = 60
        Me.lv_CamaHospital.UseCompatibleStateImageBehavior = False
        Me.lv_CamaHospital.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Identificação"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Estado"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 120
        '
        'lv_Pacientes
        '
        Me.lv_Pacientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lv_Pacientes.Location = New System.Drawing.Point(155, 196)
        Me.lv_Pacientes.Name = "lv_Pacientes"
        Me.lv_Pacientes.Size = New System.Drawing.Size(724, 271)
        Me.lv_Pacientes.TabIndex = 61
        Me.lv_Pacientes.UseCompatibleStateImageBehavior = False
        Me.lv_Pacientes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Número Utente de Saúde"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nome"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Data de Entrada"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 155
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Data de Saída"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 155
        '
        'bttn_eliminarR
        '
        Me.bttn_eliminarR.Location = New System.Drawing.Point(567, 657)
        Me.bttn_eliminarR.Name = "bttn_eliminarR"
        Me.bttn_eliminarR.Size = New System.Drawing.Size(151, 48)
        Me.bttn_eliminarR.TabIndex = 62
        Me.bttn_eliminarR.Text = "Eliminar registo paciente"
        Me.bttn_eliminarR.UseVisualStyleBackColor = True
        '
        'bbtn_AddPacienteInt
        '
        Me.bbtn_AddPacienteInt.Location = New System.Drawing.Point(181, 657)
        Me.bbtn_AddPacienteInt.Name = "bbtn_AddPacienteInt"
        Me.bbtn_AddPacienteInt.Size = New System.Drawing.Size(151, 48)
        Me.bbtn_AddPacienteInt.TabIndex = 63
        Me.bbtn_AddPacienteInt.Text = "Adicionar Paciente "
        Me.bbtn_AddPacienteInt.UseVisualStyleBackColor = True
        '
        'txt_noUtenteSaude
        '
        Me.txt_noUtenteSaude.Location = New System.Drawing.Point(181, 522)
        Me.txt_noUtenteSaude.Name = "txt_noUtenteSaude"
        Me.txt_noUtenteSaude.Size = New System.Drawing.Size(150, 27)
        Me.txt_noUtenteSaude.TabIndex = 64
        '
        'txt_DataEntrada
        '
        Me.txt_DataEntrada.Location = New System.Drawing.Point(180, 586)
        Me.txt_DataEntrada.Name = "txt_DataEntrada"
        Me.txt_DataEntrada.Size = New System.Drawing.Size(151, 27)
        Me.txt_DataEntrada.TabIndex = 66
        '
        'txt_DataSaida
        '
        Me.txt_DataSaida.Location = New System.Drawing.Point(371, 586)
        Me.txt_DataSaida.Name = "txt_DataSaida"
        Me.txt_DataSaida.Size = New System.Drawing.Size(148, 27)
        Me.txt_DataSaida.TabIndex = 67
        '
        'bttn_Editar
        '
        Me.bttn_Editar.Location = New System.Drawing.Point(371, 657)
        Me.bttn_Editar.Name = "bttn_Editar"
        Me.bttn_Editar.Size = New System.Drawing.Size(151, 48)
        Me.bttn_Editar.TabIndex = 68
        Me.bttn_Editar.Text = "Editar dados"
        Me.bttn_Editar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(181, 494)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 20)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Número Utente de Saúde"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(180, 563)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 20)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Data de Entrada"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(371, 563)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 20)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Data de Saida"
        '
        'lbl_noUtenteS
        '
        Me.lbl_noUtenteS.AutoSize = True
        Me.lbl_noUtenteS.Location = New System.Drawing.Point(371, 494)
        Me.lbl_noUtenteS.Name = "lbl_noUtenteS"
        Me.lbl_noUtenteS.Size = New System.Drawing.Size(110, 20)
        Me.lbl_noUtenteS.TabIndex = 74
        Me.lbl_noUtenteS.Text = "Primeiro Nome"
        '
        'txt_firstName
        '
        Me.txt_firstName.Location = New System.Drawing.Point(371, 522)
        Me.txt_firstName.Name = "txt_firstName"
        Me.txt_firstName.Size = New System.Drawing.Size(150, 27)
        Me.txt_firstName.TabIndex = 73
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(567, 494)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 20)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Último Nome"
        '
        'txt_LastName
        '
        Me.txt_LastName.Location = New System.Drawing.Point(567, 522)
        Me.txt_LastName.Name = "txt_LastName"
        Me.txt_LastName.Size = New System.Drawing.Size(150, 27)
        Me.txt_LastName.TabIndex = 75
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.CausesValidation = False
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(951, 494)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(280, 23)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Lista de Enfermeiros Supervisores"
        '
        'lv_EnfermeirosS
        '
        Me.lv_EnfermeirosS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lv_EnfermeirosS.Location = New System.Drawing.Point(951, 522)
        Me.lv_EnfermeirosS.Name = "lv_EnfermeirosS"
        Me.lv_EnfermeirosS.Size = New System.Drawing.Size(348, 183)
        Me.lv_EnfermeirosS.TabIndex = 78
        Me.lv_EnfermeirosS.UseCompatibleStateImageBehavior = False
        Me.lv_EnfermeirosS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Identificação"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "ID Enfermeiro Supervisor"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 220
        '
        'infoQuartos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1312, 871)
        Me.Controls.Add(Me.lv_EnfermeirosS)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_LastName)
        Me.Controls.Add(Me.lbl_noUtenteS)
        Me.Controls.Add(Me.txt_firstName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bttn_Editar)
        Me.Controls.Add(Me.txt_DataSaida)
        Me.Controls.Add(Me.txt_DataEntrada)
        Me.Controls.Add(Me.txt_noUtenteSaude)
        Me.Controls.Add(Me.bbtn_AddPacienteInt)
        Me.Controls.Add(Me.bttn_eliminarR)
        Me.Controls.Add(Me.lv_Pacientes)
        Me.Controls.Add(Me.lv_CamaHospital)
        Me.Controls.Add(Me.Label6)
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
    Friend WithEvents Label6 As Label
    Friend WithEvents ListView_Camas As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents lv_Pacientes As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents lv_CamaHospital As ListView
    Friend WithEvents bttn_eliminarR As Button
    Friend WithEvents bbtn_AddPacienteInt As Button
    Friend WithEvents txt_noUtenteSaude As TextBox
    Friend WithEvents txt_DataEntrada As TextBox
    Friend WithEvents txt_DataSaida As TextBox
    Friend WithEvents bttn_Editar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbl_noUtenteS As Label
    Friend WithEvents txt_firstName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_LastName As TextBox
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Label5 As Label
    Friend WithEvents lv_EnfermeirosS As ListView
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
End Class
