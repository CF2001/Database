Public Class Form1

    ''' Função para fazer a trocar dos formulários a partir dos butoes correspondentes.
    Sub switchPanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    ''''''' Voltar à página inicial do Hospital, clicando no label MENU.
    Private Sub Label_F1_Menu_Click(sender As Object, e As EventArgs) Handles Label_F1_Menu.Click
        switchPanel(pictureHospital)
    End Sub

    ''''''' Registo Pacientes.
    Private Sub F1btt_patientRegistration_Click(sender As Object, e As EventArgs) Handles F1btt_patientRegistration.Click
        switchPanel(registoPaciente)
    End Sub

    ''''''' Informação Pacientes
    Private Sub F1btt_patientInformation_Click(sender As Object, e As EventArgs) Handles F1btt_patientInformation.Click
        switchPanel(infoPacientes)
    End Sub

    ''''''' Informação Quartos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        switchPanel(infoQuartos)
    End Sub

    ''''''' Informação Departamentos
    Private Sub bttn_infoDep_Click(sender As Object, e As EventArgs) Handles bttn_infoDep.Click
        switchPanel(Departamentos)
    End Sub

    ''''''' Informação Funcionários
    Private Sub F1bbt_staffInfo_Click(sender As Object, e As EventArgs) Handles F1bbt_staffInfo.Click
        switchPanel(infoFuncionario)
    End Sub

    ''''''' Informação Consultas
    Private Sub bttn_infoConsultas_Click(sender As Object, e As EventArgs) Handles bttn_infoConsultas.Click
        'switchPanel(infoConsultas)
    End Sub

    ''''''' Informação Cirurgias
    Private Sub bttn_infoCirurgia_Click(sender As Object, e As EventArgs) Handles bttn_infoCirurgia.Click
        'switchPanel(infoCirurgias)
    End Sub

End Class
