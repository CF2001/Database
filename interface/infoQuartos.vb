Imports System.Data.SqlClient

Public Class infoQuartos

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim nomeCompleto As String
    Dim currentPatient_ListView As Integer = 0
    Dim currentCama_ListView As Integer = 0
    Dim currentEnf_ListView As Integer = 0


    ' Connection to database Hospital Management System
    Private Sub InfoPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=LAPTOP-4HV6V7EN\SQLEXPRESS;integrated security=true;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub


    Private Sub lv_Pacientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv_Pacientes.SelectedIndexChanged
        If lv_Pacientes.SelectedItems.Count > 0 Then
            txt_noUtenteSaude.Text = lv_Pacientes.SelectedItems(0).SubItems(0).Text
            nomeCompleto = lv_Pacientes.SelectedItems(0).SubItems(1).Text
            txt_firstName.Text = nomeCompleto.Remove(10, 14)
            txt_LastName.Text = nomeCompleto.Remove(0, 9)
            txt_DataEntrada.Text = lv_Pacientes.SelectedItems(0).SubItems(2).Text
            txt_DataSaida.Text = lv_Pacientes.SelectedItems(0).SubItems(3).Text
        End If
    End Sub


    Sub ClearFields()
        txt_noUtenteSaude.Text = ""
        txt_firstName.Text = ""
        txt_LastName.Text = ""
        txt_IDquarto.Text = ""
        txt_DataEntrada.Text = ""
        txt_DataSaida.Text = ""
    End Sub


    '''''''''''''''''''' Dispõe a lista de pacientes e camas de um determiando Quarto inserido na txt box.
    Private Sub txt_IDquarto_TextChanged(sender As Object, e As EventArgs) Handles txt_IDquarto.TextChanged

        '' Inicialize ListView Paciente
        lv_Pacientes.HoverSelection = True
        lv_Pacientes.FullRowSelect = True
        lv_Pacientes.GridLines = False
        lv_Pacientes.ShowGroups = False


        If txt_IDquarto.Text = "" Then
            ''Debug.WriteLine("Fine !!")
            lv_Pacientes.Items.Clear()
            lv_CamaHospital.Items.Clear()
            currentPatient_ListView = 0
            currentCama_ListView = 0
        Else

            ''''''' LISTA PACIENTES 
            '''
            CMD.CommandType = CommandType.Text
            ''' Obter os pacientes que estão no ID do quarto inserido no txt
            CMD.CommandText = "SELECT * FROM getPacienteBy_IDQuarto(" + txt_IDquarto.Text + ")"
            CN.Open()
            '' DataReader !! 
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            lv_Pacientes.Items.Clear()
            While RDR.Read
                Dim P As New Patient
                P.noUtenteSaude = RDR.Item("noUtenteSaude")
                P.firstName = RDR.Item("primeiroNome")
                P.lastName = RDR.Item("ultimoNome")
                P.dataEntrada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataEntrada")), "", RDR.Item("dataEntrada"))).Replace(" 00:00:00", " ")
                P.dataSaida = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataSaida")), "", RDR.Item("dataSaida"))).Replace(" 00:00:00", " ")

                '' Add valores na listView
                lv_Pacientes.Items.Add(P.noUtenteSaude)   '' 1º coluna
                lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(P.firstName & P.lastName) '' 2º coluna
                lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(P.dataEntrada)
                lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(P.dataSaida)

                currentPatient_ListView += 1
            End While
            CN.Close()

            ''''''' LISTA PACIENTES 
            '''
            CMD.CommandType = CommandType.Text
            CMD.Parameters.Clear()
            ''' Obter as camas totais do ID do quarto inserido no txt
            CMD.CommandText = "SELECT * FROM getCamaHospitalBy_IDQuarto(" + txt_IDquarto.Text + ")"
            Debug.WriteLine(CMD.CommandText)
            CN.Open()
            '' DataReader !! 
            Dim RDR_2 As SqlDataReader
            RDR_2 = CMD.ExecuteReader
            lv_CamaHospital.Items.Clear()
            While RDR_2.Read
                Dim CH As New CamaHospital

                CH.IDcama = RDR_2.Item("ID_Cama")
                Debug.WriteLine(CH.IDcama)
                CH.estadoCama = RDR_2.Item("camaOcupada")
                Debug.WriteLine(CH.estadoCama)

                '' Add valores na listView
                lv_CamaHospital.Items.Add(CH.IDcama)   '' 1º coluna
                If CH.estadoCama = "True" Then
                    lv_CamaHospital.Items(currentCama_ListView).SubItems.Add("Ocupada") '' 2º coluna - cama ocupada
                    'lv_CamaHospital.Items(currentCama_ListView).SubItems.Add(EnfermeiroSup.IDfuncionarioEnfS) '' 3º coluna
                Else
                    lv_CamaHospital.Items(currentCama_ListView).SubItems.Add("Livre") '' 2º coluna - cama livre 
                    'lv_CamaHospital.Items(currentCama_ListView).SubItems.Add(" ") '' 3º coluna
                End If

                currentCama_ListView += 1
            End While
            CN.Close()

            ''''''' LISTA ENFERMEIROS 
            '''
            CMD.CommandType = CommandType.Text
            ''' Obter os pacientes que estão no ID do quarto inserido no txt
            CMD.CommandText = "SELECT * FROM getEnfSupervisorBy_IDQuarto(" + txt_IDquarto.Text + ")"
            CN.Open()
            '' DataReader !! 
            Dim RDR_3 As SqlDataReader
            RDR_3 = CMD.ExecuteReader
            lv_EnfermeirosS.Items.Clear()
            While RDR_3.Read
                Dim EnfermeiroSup As New EnfermeiroSupervisor

                EnfermeiroSup.IDCamaEnfS = RDR_3.Item("ID_Cama")
                EnfermeiroSup.IDfuncionarioEnfS = RDR_3.Item("func_ID_EnfS")

                '' Add valores na listView
                lv_EnfermeirosS.Items.Add(EnfermeiroSup.IDCamaEnfS)   '' 1º coluna
                lv_EnfermeirosS.Items(currentEnf_ListView).SubItems.Add(EnfermeiroSup.IDfuncionarioEnfS)

                currentEnf_ListView += 1
            End While
            CN.Close()



        End If

    End Sub

    '''''''''''''''''''''''''''''      Paciente deixa de estar internado.

    ''' Eliminar registo Paciente da lista de Pacientes de um determinado quarto
    Private Sub bttn_eliminarR_Click(sender As Object, e As EventArgs) Handles bttn_eliminarR.Click
        If lv_Pacientes.SelectedItems IsNot Nothing Then    '' Se tiver elementos selecionados 
            Try
                UpdatePaciente_NaoInternado(lv_Pacientes.FocusedItem.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For Each index As ListViewItem In lv_Pacientes.SelectedItems
                'Debug.WriteLine(index)
                lv_Pacientes.Items.Remove(index)
            Next
        End If
    End Sub

    ''' Atualizar dados do paciente e da cama de Hospital na base de dados 
    Private Sub UpdatePaciente_NaoInternado(ByVal noUtenteSaude As String)

        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[UpdatePaciente_NaoInternado]"
        CMD.Parameters.AddWithValue("@noUtenteSaude", noUtenteSaude)
        CMD.Parameters.AddWithValue("@quartoID", txt_IDquarto.Text)

        Try
            CN.Open()
            CMD.ExecuteNonQuery()
            CN.Close()
        Catch ex As Exception
            Throw New Exception("Failed to update patient in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
        MsgBox("Paciente " + noUtenteSaude + " retirado da lista de Pacientes Internados.")
        'ClearFields()
    End Sub


    '''''''''''''''''''''''''''''''      Paciente é internado.

    '''''''' Atribuir ao Paciente um Quarto e atualizar o estado de uma cama do determinado Quarto '''''''''
    Private Sub bbtn_AddPacienteInt_Click(sender As Object, e As EventArgs) Handles bbtn_AddPacienteInt.Click
        Try
            SavePaciente_Internado()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function SavePaciente_Internado() As Boolean
        Dim patient As New Patient

        Try
            patient.noUtenteSaude = txt_noUtenteSaude.Text
            patient.firstName = txt_firstName.Text
            patient.lastName = txt_LastName.Text
            patient.quartoID = txt_IDquarto.Text
            patient.dataEntrada = txt_DataEntrada.Text
            patient.dataSaida = txt_DataSaida.Text


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        UpdatePaciente_Internado(patient)        ''' Adicionar paciente à lista de Pacientes internados

        lv_Pacientes.Items.Add(patient.noUtenteSaude)   '' 1º coluna
        lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(patient.firstName & " " & patient.lastName) '' 2º coluna
        lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(patient.dataEntrada)
        lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(patient.dataSaida)

        Return True
    End Function

    Private Sub UpdatePaciente_Internado(ByVal P As Patient)

        CN.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[UpdatePaciente_Internado]"
        CMD.Parameters.AddWithValue("@noUtenteSaude", P.noUtenteSaude)
        CMD.Parameters.AddWithValue("@dataEntrada", P.dataEntrada)
        CMD.Parameters.AddWithValue("@dataSaida", P.dataSaida)
        CMD.Parameters.AddWithValue("@quartoID", txt_IDquarto.Text)

        Try
            CMD.ExecuteNonQuery()
            CN.Close()
        Catch ex As Exception
            Throw New Exception("Failed to update patient in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
        ClearFields()
        MsgBox("Paciente " + P.noUtenteSaude + " adicionado à lista de Pacientes Internados.")
    End Sub

    ''''''''''''''''''''''' Atualização dos valores da data de Entrada e Saída de um paciente internado.
    Private Sub bttn_Editar_Click(sender As Object, e As EventArgs) Handles bttn_Editar.Click
        Try
            SavePaciente_dadosEdit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function SavePaciente_dadosEdit() As Boolean
        Dim patient As New Patient

        Try
            patient.noUtenteSaude = txt_noUtenteSaude.Text
            patient.firstName = txt_firstName.Text
            patient.lastName = txt_LastName.Text
            patient.dataEntrada = txt_DataEntrada.Text
            patient.dataSaida = txt_DataSaida.Text


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        UpdateDadosPaciente_Internado(patient)        ''' Atualização dos dados de um Paciente internado

        lv_Pacientes.Items.Add(patient.noUtenteSaude)   '' 1º coluna
        lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(patient.firstName & patient.lastName) '' 2º coluna
        lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(patient.dataEntrada)
        lv_Pacientes.Items(currentPatient_ListView).SubItems.Add(patient.dataSaida)

        Return True
    End Function

    Private Sub UpdateDadosPaciente_Internado(ByVal P As Patient)

        CN.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[UpdateDadosPaciente_Internado]"
        CMD.Parameters.AddWithValue("@noUtenteSaude", P.noUtenteSaude)
        CMD.Parameters.AddWithValue("@dataEntrada", If(String.IsNullOrEmpty(P.dataEntrada), DBNull.Value, P.dataEntrada))
        CMD.Parameters.AddWithValue("@dataSaida", If(String.IsNullOrEmpty(P.dataSaida), DBNull.Value, P.dataSaida))

        Try
            CMD.ExecuteNonQuery()
            CN.Close()
        Catch ex As Exception
            Throw New Exception("Failed to update patient in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
        ClearFields()
        MsgBox("Dados do Paciente " + P.noUtenteSaude + " atualizados.")

    End Sub
End Class
