<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class infoPacientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(infoPacientes))
        Me.bttnUpdate = New System.Windows.Forms.Button()
        Me.txtIDquarto = New System.Windows.Forms.TextBox()
        Me.txtIDrec = New System.Windows.Forms.TextBox()
        Me.txtNoTelefone = New System.Windows.Forms.TextBox()
        Me.TextBox_genero = New System.Windows.Forms.TextBox()
        Me.TextBox_Bdate = New System.Windows.Forms.TextBox()
        Me.txtNoUtenteSaude = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.searchBar = New System.Windows.Forms.TextBox()
        Me.Label_searchPaciente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bttnEliminar = New System.Windows.Forms.Button()
        Me.refreshListBox = New System.Windows.Forms.PictureBox()
        Me.searchPaciente = New System.Windows.Forms.PictureBox()
        Me.txt_dataEntrada = New System.Windows.Forms.TextBox()
        Me.lbl_dataEntrada = New System.Windows.Forms.Label()
        Me.txt_dataSaida = New System.Windows.Forms.TextBox()
        Me.lbl_dataSaida = New System.Windows.Forms.Label()
        CType(Me.refreshListBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.searchPaciente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bttnUpdate
        '
        Me.bttnUpdate.Location = New System.Drawing.Point(592, 556)
        Me.bttnUpdate.Name = "bttnUpdate"
        Me.bttnUpdate.Size = New System.Drawing.Size(110, 43)
        Me.bttnUpdate.TabIndex = 67
        Me.bttnUpdate.Text = "Atualizar"
        Me.bttnUpdate.UseVisualStyleBackColor = True
        '
        'txtIDquarto
        '
        Me.txtIDquarto.Location = New System.Drawing.Point(592, 321)
        Me.txtIDquarto.Name = "txtIDquarto"
        Me.txtIDquarto.Size = New System.Drawing.Size(149, 27)
        Me.txtIDquarto.TabIndex = 64
        '
        'txtIDrec
        '
        Me.txtIDrec.Location = New System.Drawing.Point(800, 321)
        Me.txtIDrec.Name = "txtIDrec"
        Me.txtIDrec.Size = New System.Drawing.Size(142, 27)
        Me.txtIDrec.TabIndex = 63
        '
        'txtNoTelefone
        '
        Me.txtNoTelefone.Location = New System.Drawing.Point(799, 228)
        Me.txtNoTelefone.Name = "txtNoTelefone"
        Me.txtNoTelefone.Size = New System.Drawing.Size(150, 27)
        Me.txtNoTelefone.TabIndex = 62
        '
        'TextBox_genero
        '
        Me.TextBox_genero.AccessibleDescription = ""
        Me.TextBox_genero.AccessibleName = ""
        Me.TextBox_genero.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TextBox_genero.Location = New System.Drawing.Point(976, 228)
        Me.TextBox_genero.Name = "TextBox_genero"
        Me.TextBox_genero.Size = New System.Drawing.Size(150, 27)
        Me.TextBox_genero.TabIndex = 60
        Me.TextBox_genero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Bdate
        '
        Me.TextBox_Bdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TextBox_Bdate.Location = New System.Drawing.Point(592, 228)
        Me.TextBox_Bdate.Name = "TextBox_Bdate"
        Me.TextBox_Bdate.Size = New System.Drawing.Size(150, 27)
        Me.TextBox_Bdate.TabIndex = 59
        Me.TextBox_Bdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNoUtenteSaude
        '
        Me.txtNoUtenteSaude.Location = New System.Drawing.Point(592, 146)
        Me.txtNoUtenteSaude.Name = "txtNoUtenteSaude"
        Me.txtNoUtenteSaude.Size = New System.Drawing.Size(150, 27)
        Me.txtNoUtenteSaude.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(592, 298)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "ID Quarto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(799, 298)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 20)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "ID Rececionista"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(799, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 20)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Número de telefone"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(800, 146)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(150, 27)
        Me.txtFirstName.TabIndex = 53
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(976, 146)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(150, 27)
        Me.txtLastName.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(976, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Género"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(592, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 20)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Data de Nascimento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(592, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 20)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Número Utente de Saúde"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(976, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Último Nome"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(800, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 20)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Primeiro Nome"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(152, 175)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(316, 424)
        Me.ListBox1.TabIndex = 46
        '
        'searchBar
        '
        Me.searchBar.Location = New System.Drawing.Point(152, 127)
        Me.searchBar.Name = "searchBar"
        Me.searchBar.Size = New System.Drawing.Size(272, 27)
        Me.searchBar.TabIndex = 45
        '
        'Label_searchPaciente
        '
        Me.Label_searchPaciente.AutoSize = True
        Me.Label_searchPaciente.Location = New System.Drawing.Point(152, 94)
        Me.Label_searchPaciente.Name = "Label_searchPaciente"
        Me.Label_searchPaciente.Size = New System.Drawing.Size(328, 20)
        Me.Label_searchPaciente.TabIndex = 44
        Me.Label_searchPaciente.Text = "Insira o número de Utente de Saúde do Paciente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(400, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 31)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Informação Pacientes"
        '
        'bttnEliminar
        '
        Me.bttnEliminar.Location = New System.Drawing.Point(735, 556)
        Me.bttnEliminar.Name = "bttnEliminar"
        Me.bttnEliminar.Size = New System.Drawing.Size(110, 43)
        Me.bttnEliminar.TabIndex = 69
        Me.bttnEliminar.Text = "Eliminar"
        Me.bttnEliminar.UseVisualStyleBackColor = True
        '
        'refreshListBox
        '
        Me.refreshListBox.Image = CType(resources.GetObject("refreshListBox.Image"), System.Drawing.Image)
        Me.refreshListBox.Location = New System.Drawing.Point(474, 570)
        Me.refreshListBox.Name = "refreshListBox"
        Me.refreshListBox.Size = New System.Drawing.Size(36, 29)
        Me.refreshListBox.TabIndex = 71
        Me.refreshListBox.TabStop = False
        '
        'searchPaciente
        '
        Me.searchPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.searchPaciente.Image = CType(resources.GetObject("searchPaciente.Image"), System.Drawing.Image)
        Me.searchPaciente.Location = New System.Drawing.Point(444, 127)
        Me.searchPaciente.Name = "searchPaciente"
        Me.searchPaciente.Size = New System.Drawing.Size(24, 24)
        Me.searchPaciente.TabIndex = 73
        Me.searchPaciente.TabStop = False
        '
        'txt_dataEntrada
        '
        Me.txt_dataEntrada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_dataEntrada.Location = New System.Drawing.Point(592, 412)
        Me.txt_dataEntrada.Name = "txt_dataEntrada"
        Me.txt_dataEntrada.Size = New System.Drawing.Size(150, 27)
        Me.txt_dataEntrada.TabIndex = 75
        Me.txt_dataEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_dataEntrada
        '
        Me.lbl_dataEntrada.AutoSize = True
        Me.lbl_dataEntrada.Location = New System.Drawing.Point(597, 389)
        Me.lbl_dataEntrada.Name = "lbl_dataEntrada"
        Me.lbl_dataEntrada.Size = New System.Drawing.Size(117, 20)
        Me.lbl_dataEntrada.TabIndex = 74
        Me.lbl_dataEntrada.Text = "Data de Entrada"
        '
        'txt_dataSaida
        '
        Me.txt_dataSaida.AllowDrop = True
        Me.txt_dataSaida.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_dataSaida.Location = New System.Drawing.Point(800, 412)
        Me.txt_dataSaida.Name = "txt_dataSaida"
        Me.txt_dataSaida.Size = New System.Drawing.Size(150, 27)
        Me.txt_dataSaida.TabIndex = 77
        Me.txt_dataSaida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_dataSaida
        '
        Me.lbl_dataSaida.AllowDrop = True
        Me.lbl_dataSaida.AutoSize = True
        Me.lbl_dataSaida.Location = New System.Drawing.Point(800, 389)
        Me.lbl_dataSaida.Name = "lbl_dataSaida"
        Me.lbl_dataSaida.Size = New System.Drawing.Size(103, 20)
        Me.lbl_dataSaida.TabIndex = 76
        Me.lbl_dataSaida.Text = "Data de Saida"
        '
        'infoPacientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 628)
        Me.Controls.Add(Me.txt_dataSaida)
        Me.Controls.Add(Me.lbl_dataSaida)
        Me.Controls.Add(Me.txt_dataEntrada)
        Me.Controls.Add(Me.lbl_dataEntrada)
        Me.Controls.Add(Me.searchPaciente)
        Me.Controls.Add(Me.refreshListBox)
        Me.Controls.Add(Me.bttnEliminar)
        Me.Controls.Add(Me.bttnUpdate)
        Me.Controls.Add(Me.txtIDquarto)
        Me.Controls.Add(Me.txtIDrec)
        Me.Controls.Add(Me.txtNoTelefone)
        Me.Controls.Add(Me.TextBox_genero)
        Me.Controls.Add(Me.TextBox_Bdate)
        Me.Controls.Add(Me.txtNoUtenteSaude)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.searchBar)
        Me.Controls.Add(Me.Label_searchPaciente)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "infoPacientes"
        Me.Text = "infoPacientes"
        CType(Me.refreshListBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.searchPaciente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Close As Button
    Friend WithEvents bttnUpdate As Button
    Friend WithEvents txtIDquarto As TextBox
    Friend WithEvents txtIDrec As TextBox
    Friend WithEvents txtNoTelefone As TextBox
    Friend WithEvents TextBox_genero As TextBox
    Friend WithEvents TextBox_Bdate As TextBox
    Friend WithEvents txtNoUtenteSaude As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents searchBar As TextBox
    Friend WithEvents Label_searchPaciente As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents bttnEliminar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents refreshListBox As PictureBox
    Friend WithEvents searchPaciente As PictureBox
    Friend WithEvents txt_dataEntrada As TextBox
    Friend WithEvents lbl_dataEntrada As Label
    Friend WithEvents txt_dataSaida As TextBox
    Friend WithEvents lbl_dataSaida As Label
End Class
