<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label_F1_Menu = New System.Windows.Forms.Label()
        Me.F1btt_patientRegistration = New System.Windows.Forms.Button()
        Me.F1btt_patientInformation = New System.Windows.Forms.Button()
        Me.F1bbt_staffInfo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bttn_infoDep = New System.Windows.Forms.Button()
        Me.bttn_infoConsultas = New System.Windows.Forms.Button()
        Me.bttn_infoCirurgia = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_F1_Menu
        '
        Me.Label_F1_Menu.AutoSize = True
        Me.Label_F1_Menu.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label_F1_Menu.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label_F1_Menu.Location = New System.Drawing.Point(45, 28)
        Me.Label_F1_Menu.Name = "Label_F1_Menu"
        Me.Label_F1_Menu.Size = New System.Drawing.Size(116, 46)
        Me.Label_F1_Menu.TabIndex = 0
        Me.Label_F1_Menu.Text = "MENU"
        '
        'F1btt_patientRegistration
        '
        Me.F1btt_patientRegistration.Location = New System.Drawing.Point(12, 106)
        Me.F1btt_patientRegistration.Name = "F1btt_patientRegistration"
        Me.F1btt_patientRegistration.Size = New System.Drawing.Size(201, 40)
        Me.F1btt_patientRegistration.TabIndex = 1
        Me.F1btt_patientRegistration.Text = "Registo Paciente"
        Me.F1btt_patientRegistration.UseVisualStyleBackColor = True
        '
        'F1btt_patientInformation
        '
        Me.F1btt_patientInformation.Location = New System.Drawing.Point(12, 152)
        Me.F1btt_patientInformation.Name = "F1btt_patientInformation"
        Me.F1btt_patientInformation.Size = New System.Drawing.Size(201, 40)
        Me.F1btt_patientInformation.TabIndex = 2
        Me.F1btt_patientInformation.Text = "Informação Pacientes"
        Me.F1btt_patientInformation.UseVisualStyleBackColor = True
        '
        'F1bbt_staffInfo
        '
        Me.F1bbt_staffInfo.Location = New System.Drawing.Point(12, 290)
        Me.F1bbt_staffInfo.Name = "F1bbt_staffInfo"
        Me.F1bbt_staffInfo.Size = New System.Drawing.Size(201, 40)
        Me.F1bbt_staffInfo.TabIndex = 3
        Me.F1bbt_staffInfo.Text = "Informação Funcionários"
        Me.F1bbt_staffInfo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(243, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1045, 674)
        Me.Panel1.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(55, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(950, 616)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 198)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 40)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Informação Quartos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bttn_infoDep
        '
        Me.bttn_infoDep.Location = New System.Drawing.Point(12, 244)
        Me.bttn_infoDep.Name = "bttn_infoDep"
        Me.bttn_infoDep.Size = New System.Drawing.Size(201, 40)
        Me.bttn_infoDep.TabIndex = 1
        Me.bttn_infoDep.Text = "Departamentos"
        Me.bttn_infoDep.UseVisualStyleBackColor = True
        '
        'bttn_infoConsultas
        '
        Me.bttn_infoConsultas.Location = New System.Drawing.Point(12, 336)
        Me.bttn_infoConsultas.Name = "bttn_infoConsultas"
        Me.bttn_infoConsultas.Size = New System.Drawing.Size(201, 40)
        Me.bttn_infoConsultas.TabIndex = 6
        Me.bttn_infoConsultas.Text = "Consultas"
        Me.bttn_infoConsultas.UseVisualStyleBackColor = True
        '
        'bttn_infoCirurgia
        '
        Me.bttn_infoCirurgia.Location = New System.Drawing.Point(12, 382)
        Me.bttn_infoCirurgia.Name = "bttn_infoCirurgia"
        Me.bttn_infoCirurgia.Size = New System.Drawing.Size(201, 40)
        Me.bttn_infoCirurgia.TabIndex = 7
        Me.bttn_infoCirurgia.Text = "Cirurgias"
        Me.bttn_infoCirurgia.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1309, 741)
        Me.Controls.Add(Me.bttn_infoCirurgia)
        Me.Controls.Add(Me.bttn_infoConsultas)
        Me.Controls.Add(Me.bttn_infoDep)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.F1bbt_staffInfo)
        Me.Controls.Add(Me.F1btt_patientInformation)
        Me.Controls.Add(Me.F1btt_patientRegistration)
        Me.Controls.Add(Me.Label_F1_Menu)
        Me.Name = "Form1"
        Me.Text = "Hospital Management System"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_F1_Menu As Label
    Friend WithEvents F1btt_patientRegistration As Button
    Friend WithEvents F1btt_patientInformation As Button
    Friend WithEvents F1bbt_staffInfo As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents bttn_infoDep As Button
    Friend WithEvents bttn_infoConsultas As Button
    Friend WithEvents bttn_infoCirurgia As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
