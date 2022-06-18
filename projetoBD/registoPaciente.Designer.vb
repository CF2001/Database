<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class registoPaciente
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
        Me.bttnInserir = New System.Windows.Forms.Button()
        Me.txtIDquarto = New System.Windows.Forms.TextBox()
        Me.txtIDrec = New System.Windows.Forms.TextBox()
        Me.txtNoTelefone = New System.Windows.Forms.TextBox()
        Me.Txt_genero = New System.Windows.Forms.TextBox()
        Me.Txt_Bdate = New System.Windows.Forms.TextBox()
        Me.txtNoUtenteS = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtDataEntrada = New System.Windows.Forms.TextBox()
        Me.lbl_dataEntrada = New System.Windows.Forms.Label()
        Me.txtDataSaida = New System.Windows.Forms.TextBox()
        Me.lblDataSaida = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'bttnInserir
        '
        Me.bttnInserir.Location = New System.Drawing.Point(555, 369)
        Me.bttnInserir.Name = "bttnInserir"
        Me.bttnInserir.Size = New System.Drawing.Size(111, 44)
        Me.bttnInserir.TabIndex = 90
        Me.bttnInserir.Text = "Inserir"
        Me.bttnInserir.UseVisualStyleBackColor = True
        '
        'txtIDquarto
        '
        Me.txtIDquarto.Location = New System.Drawing.Point(155, 275)
        Me.txtIDquarto.Name = "txtIDquarto"
        Me.txtIDquarto.Size = New System.Drawing.Size(99, 27)
        Me.txtIDquarto.TabIndex = 87
        Me.txtIDquarto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDrec
        '
        Me.txtIDrec.Location = New System.Drawing.Point(154, 342)
        Me.txtIDrec.Name = "txtIDrec"
        Me.txtIDrec.Size = New System.Drawing.Size(100, 27)
        Me.txtIDrec.TabIndex = 86
        Me.txtIDrec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNoTelefone
        '
        Me.txtNoTelefone.Location = New System.Drawing.Point(356, 191)
        Me.txtNoTelefone.Name = "txtNoTelefone"
        Me.txtNoTelefone.Size = New System.Drawing.Size(150, 27)
        Me.txtNoTelefone.TabIndex = 85
        Me.txtNoTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_genero
        '
        Me.Txt_genero.AccessibleDescription = ""
        Me.Txt_genero.AccessibleName = ""
        Me.Txt_genero.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Txt_genero.Location = New System.Drawing.Point(555, 191)
        Me.Txt_genero.Name = "Txt_genero"
        Me.Txt_genero.Size = New System.Drawing.Size(110, 27)
        Me.Txt_genero.TabIndex = 83
        Me.Txt_genero.Text = "F/M"
        Me.Txt_genero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Bdate
        '
        Me.Txt_Bdate.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Txt_Bdate.Location = New System.Drawing.Point(154, 191)
        Me.Txt_Bdate.Name = "Txt_Bdate"
        Me.Txt_Bdate.Size = New System.Drawing.Size(150, 27)
        Me.Txt_Bdate.TabIndex = 82
        Me.Txt_Bdate.Text = "yyyy-mm-dd"
        Me.Txt_Bdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNoUtenteS
        '
        Me.txtNoUtenteS.Location = New System.Drawing.Point(154, 107)
        Me.txtNoUtenteS.Name = "txtNoUtenteS"
        Me.txtNoUtenteS.Size = New System.Drawing.Size(150, 27)
        Me.txtNoUtenteS.TabIndex = 81
        Me.txtNoUtenteS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(155, 243)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 20)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "ID Quarto"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(154, 319)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 20)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "ID Rececionista"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(357, 159)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 20)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "Número de telefone"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(555, 107)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(150, 27)
        Me.txtLastName.TabIndex = 76
        Me.txtLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(356, 107)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(150, 27)
        Me.txtFirstName.TabIndex = 75
        Me.txtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(555, 159)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 20)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "Género"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(154, 159)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(145, 20)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "Data de Nascimento"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(154, 74)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(177, 20)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "Número Utente de Saúde"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(555, 74)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 20)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "Último Nome"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(357, 74)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(110, 20)
        Me.Label21.TabIndex = 70
        Me.Label21.Text = "Primeiro Nome"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label22.Location = New System.Drawing.Point(338, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(188, 32)
        Me.Label22.TabIndex = 69
        Me.Label22.Text = "Registo Paciente"
        '
        'txtDataEntrada
        '
        Me.txtDataEntrada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtDataEntrada.Location = New System.Drawing.Point(356, 275)
        Me.txtDataEntrada.Name = "txtDataEntrada"
        Me.txtDataEntrada.Size = New System.Drawing.Size(150, 27)
        Me.txtDataEntrada.TabIndex = 92
        Me.txtDataEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_dataEntrada
        '
        Me.lbl_dataEntrada.AutoSize = True
        Me.lbl_dataEntrada.Location = New System.Drawing.Point(356, 243)
        Me.lbl_dataEntrada.Name = "lbl_dataEntrada"
        Me.lbl_dataEntrada.Size = New System.Drawing.Size(117, 20)
        Me.lbl_dataEntrada.TabIndex = 91
        Me.lbl_dataEntrada.Text = "Data de Entrada"
        '
        'txtDataSaida
        '
        Me.txtDataSaida.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtDataSaida.Location = New System.Drawing.Point(555, 275)
        Me.txtDataSaida.Name = "txtDataSaida"
        Me.txtDataSaida.Size = New System.Drawing.Size(150, 27)
        Me.txtDataSaida.TabIndex = 94
        Me.txtDataSaida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDataSaida
        '
        Me.lblDataSaida.AutoSize = True
        Me.lblDataSaida.Location = New System.Drawing.Point(555, 243)
        Me.lblDataSaida.Name = "lblDataSaida"
        Me.lblDataSaida.Size = New System.Drawing.Size(103, 20)
        Me.lblDataSaida.TabIndex = 93
        Me.lblDataSaida.Text = "Data de Saida"
        '
        'registoPaciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 471)
        Me.Controls.Add(Me.txtDataSaida)
        Me.Controls.Add(Me.lblDataSaida)
        Me.Controls.Add(Me.txtDataEntrada)
        Me.Controls.Add(Me.lbl_dataEntrada)
        Me.Controls.Add(Me.bttnInserir)
        Me.Controls.Add(Me.txtIDquarto)
        Me.Controls.Add(Me.txtIDrec)
        Me.Controls.Add(Me.txtNoTelefone)
        Me.Controls.Add(Me.Txt_genero)
        Me.Controls.Add(Me.Txt_Bdate)
        Me.Controls.Add(Me.txtNoUtenteS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "registoPaciente"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Picture_Hospital As PictureBox
    Friend WithEvents Button_Fechar As Button
    Friend WithEvents bttnInserir As Button
    Friend WithEvents txtIDquarto As TextBox
    Friend WithEvents txtIDrec As TextBox
    Friend WithEvents txtNoTelefone As TextBox
    Friend WithEvents Txt_genero As TextBox
    Friend WithEvents Txt_Bdate As TextBox
    Friend WithEvents txtNoUtenteS As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtDataEntrada As TextBox
    Friend WithEvents lbl_dataEntrada As Label
    Friend WithEvents txtDataSaida As TextBox
    Friend WithEvents lblDataSaida As Label
End Class
