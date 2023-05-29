Imports System.Data.SqlClient

Public Class registoPaciente

    Dim CN As SqlConnection
    Dim CMD As SqlCommand

    ' Connection to database Hospital Management System
    Private Sub InfoPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LAPTOP-4HV6V7EN\SQLEXPRESS
        ' tcp:mednat.ieeta.pt\SQLSERVER,8101
        CN = New SqlConnection("data source=tcp:mednat.ieeta.pt\SQLSERVER,8101;integrated security=true;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    Private Sub bttnInserir_Click(sender As Object, e As EventArgs) Handles bttnInserir.Click
        Try
            SavePaciente()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '' Redefine as variáveis da classe Paciente em função dos valores inseridos nos 
    '' campos do formulário.
    Private Function SavePaciente() As Boolean
        Dim patient As New Patient

        Try
            patient.noUtenteSaude = txtNoUtenteS.Text
            patient.firstName = txtFirstName.Text
            patient.lastName = txtLastName.Text
            patient.bDate = Txt_Bdate.Text
            patient.genero = Txt_genero.Text
            patient.noTelefone = txtNoTelefone.Text
            patient.rececionistaID = txtIDrec.Text
            patient.quartoID = txtIDquarto.Text
            patient.dataEntrada = txtDataEntrada.Text
            patient.dataSaida = txtDataSaida.Text


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        registoPaciente(patient)        ''' Registar paciente.
        Return True
    End Function


    '' Função que insere os valores do Paciente na tabela Paciente na Base de dados
    Private Sub registoPaciente(ByVal P As Patient)
        CN.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[sp_registoPaciente]"
        CMD.Parameters.AddWithValue("@noUtenteSaude", P.noUtenteSaude)
        'Debug.WriteLine(P.noUtenteSaude)
        CMD.Parameters.AddWithValue("@firstName", P.firstName)
        CMD.Parameters.AddWithValue("@lastName", P.lastName)
        CMD.Parameters.AddWithValue("@bDate", P.bDate)
        CMD.Parameters.AddWithValue("@genero", P.genero)
        CMD.Parameters.AddWithValue("@noTelefone", P.noTelefone)
        CMD.Parameters.AddWithValue("@rececionistaID", P.rececionistaID)
        CMD.Parameters.AddWithValue("@quartoID", If(String.IsNullOrEmpty(P.quartoID), DBNull.Value, P.quartoID))
        CMD.Parameters.AddWithValue("@dataEntrada", If(String.IsNullOrEmpty(P.dataEntrada), DBNull.Value, P.dataEntrada))
        'Debug.WriteLine(P.dataEntrada)
        CMD.Parameters.AddWithValue("@dataSaida", If(String.IsNullOrEmpty(P.dataSaida), DBNull.Value, P.dataSaida))
        'Debug.WriteLine(P.dataSaida)

        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to register patient in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()

        MsgBox("Paciente Inserido na Base de Dados.")
        ClearFields()
    End Sub


    Sub ClearFields()
        txtNoUtenteS.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        Txt_Bdate.Text = ""
        Txt_genero.Text = ""
        txtNoTelefone.Text = ""
        txtIDrec.Text = ""
        txtIDquarto.Text = ""
        txtDataEntrada.Text = ""
        txtDataSaida.Text = ""
    End Sub

    '''Text Box genero.
    Private Sub Txt_genero_Enter(sender As Object, e As EventArgs) Handles Txt_genero.Enter
        If Txt_genero.Text = "F/M" Then
            Txt_genero.Text = ""
            Txt_genero.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Txt_genero_Leave(sender As Object, e As EventArgs) Handles Txt_genero.Leave
        If Txt_genero.Text = "" Then
            Txt_genero.Text = "F/M"
            Txt_genero.ForeColor = SystemColors.ButtonShadow
        End If
    End Sub

    '''Text Box Bdate.
    Private Sub Txt_Bdate_Enter(sender As Object, e As EventArgs) Handles Txt_Bdate.Enter
        If Txt_Bdate.Text = "yyyy-mm-dd" Then
            Txt_Bdate.Text = ""
            Txt_Bdate.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Txt_Bdate_Leave(sender As Object, e As EventArgs) Handles Txt_Bdate.Leave
        If Txt_Bdate.Text = "" Then
            Txt_Bdate.Text = "yyyy-mm-dd"
            Txt_Bdate.ForeColor = SystemColors.ButtonShadow
        End If
    End Sub

    '''Text Box Data de Entrada
    Private Sub txtDataEntrada_Enter(sender As Object, e As EventArgs) Handles txtDataEntrada.Enter
        If txtDataEntrada.Text = "yyyy-mm-dd" Then
            txtDataEntrada.Text = ""
            txtDataEntrada.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtDataEntrada_Leave(sender As Object, e As EventArgs) Handles txtDataEntrada.Leave
        If txtDataEntrada.Text = "" Then
            txtDataEntrada.Text = "yyyy-mm-dd"
            txtDataEntrada.ForeColor = SystemColors.ButtonShadow
        End If
    End Sub

    '''Text Box Data de Saida
    Private Sub txtDataSaida_Enter(sender As Object, e As EventArgs) Handles txtDataSaida.Enter
        If txtDataSaida.Text = "yyyy-mm-dd" Then
            txtDataSaida.Text = ""
            txtDataSaida.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtDataSaida_Leave(sender As Object, e As EventArgs) Handles txtDataSaida.Leave
        If txtDataSaida.Text = "" Then
            txtDataSaida.Text = "yyyy-mm-dd"
            txtDataSaida.ForeColor = SystemColors.ButtonShadow
        End If
    End Sub

End Class
