
Imports System.Data.SqlClient

Public Class infoPacientes

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentPatient As Integer

    ' Connection to database Hospital Management System
    Private Sub InfoPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=LAPTOP-4HV6V7EN\SQLEXPRESS;integrated security=true;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    ' Shows all patients automatically in ListBox1 when the form opens 
    Private Sub ShowListOfPatients() Handles MyBase.Load

        CMD.CommandType = CommandType.Text
        CMD.Parameters.Clear()                  '''' Ver se é necessário
        CMD.CommandText = "SELECT * FROM Paciente" '' for SQL statements
        CN.Open()
        '' DataReader !! 
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim P As New Patient
            P.noUtenteSaude = RDR.Item("noUtenteSaude")
            P.firstName = RDR.Item("primeiroNome")
            P.lastName = RDR.Item("ultimoNome")
            P.bDate = RDR.Item("dataNascimento")
            P.genero = RDR.Item("genero")
            P.noTelefone = RDR.Item("noTelefone")
            P.rececionistaID = RDR.Item("func_ID_Rec")
            ''permite NULL
            P.quartoID = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Quarto")), "", RDR.Item("ID_Quarto")))
            P.dataEntrada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataEntrada")), "", RDR.Item("dataEntrada"))).Replace(" 00:00:00", " ")
            'Debug.WriteLine(P.dataEntrada.GetType()) --> String
            'Debug.WriteLine(P.dataEntrada.Replace(" 00:00:00", " "))
            P.dataSaida = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataSaida")), "", RDR.Item("dataSaida"))).Replace(" 00:00:00", " ")
            ListBox1.Items.Add(P) ' Adicionar todos os Pacientes à ListBox1
        End While
        CN.Close()
    End Sub

    ' Indice de cada paciente que aparece na ListBox1
    ' O indice começa no 0
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentPatient = ListBox1.SelectedIndex
            ShowInfoPatient()
        End If
    End Sub

    ' Mostrar a informação do cliente selecionado na ListBox
    ' em cada caixa de texto respetiva
    Sub ShowInfoPatient()
        If ListBox1.Items.Count = 0 Or currentPatient < 0 Then Exit Sub
        Dim patient As Patient = CType(ListBox1.Items.Item(currentPatient), Patient)
        txtNoUtenteSaude.Text = patient.noUtenteSaude
        txtFirstName.Text = patient.firstName
        txtLastName.Text = patient.lastName
        TextBox_Bdate.Text = patient.bDate
        TextBox_genero.Text = patient.genero
        txtNoTelefone.Text = patient.noTelefone
        txtIDrec.Text = patient.rececionistaID
        txtIDquarto.Text = patient.quartoID
        txt_dataEntrada.Text = patient.dataEntrada
        txt_dataSaida.Text = patient.dataSaida
    End Sub

    '' Redefine as variáveis da classe Paciente em função dos valores inseridos nos 
    '' campos do formulário.
    Private Function SavePaciente() As Boolean
        Dim patient As New Patient
        Try
            patient.noUtenteSaude = txtNoUtenteSaude.Text
            patient.firstName = txtFirstName.Text
            patient.lastName = txtLastName.Text
            patient.bDate = TextBox_Bdate.Text
            patient.genero = TextBox_genero.Text
            patient.noTelefone = txtNoTelefone.Text
            patient.rececionistaID = txtIDrec.Text
            patient.quartoID = txtIDquarto.Text
            patient.dataEntrada = txt_dataEntrada.Text
            patient.dataSaida = txt_dataSaida.Text

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        UpdatePaciente(patient)        ''' Atualizar dados paciente.
        ListBox1.Items(currentPatient) = patient

        Return True
    End Function

    Sub ClearFields()
        txtNoUtenteSaude.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        TextBox_Bdate.Text = ""
        TextBox_genero.Text = ""
        txtNoTelefone.Text = ""
        txtIDrec.Text = ""
        txtIDquarto.Text = ""
        txt_dataEntrada.Text = ""
        txt_dataSaida.Text = ""
    End Sub

    '''''''''''''''''''''''''''''''''''' ATUALIZAR dados PACIENTE '''''''''''''''''''''''''''''''''''''''

    Private Sub bttnUpdate_Click(sender As Object, e As EventArgs) Handles bttnUpdate.Click
        Try
            SavePaciente()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UpdatePaciente(ByVal P As Patient)
        CN.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[sp_updateInfoPaciente]"
        CMD.Parameters.AddWithValue("@noUtenteSaude", P.noUtenteSaude)
        CMD.Parameters.AddWithValue("@firstName", P.firstName)
        CMD.Parameters.AddWithValue("@lastName", P.lastName)
        CMD.Parameters.AddWithValue("@bDate", P.bDate)
        CMD.Parameters.AddWithValue("@genero", P.genero)
        CMD.Parameters.AddWithValue("@noTelefone", P.noTelefone)
        CMD.Parameters.AddWithValue("@rececionistaID", P.rececionistaID)
        'CMD.Parameters.AddWithValue("@dataEntrada", P.dataEntrada)
        'CMD.Parameters.AddWithValue("@dataSaida", P.dataSaida)
        CMD.Parameters.AddWithValue("@quartoID", If(String.IsNullOrEmpty(P.quartoID), DBNull.Value, P.quartoID))
        CMD.Parameters.AddWithValue("@dataEntrada", If(String.IsNullOrEmpty(P.dataEntrada), DBNull.Value, P.dataEntrada.Replace("/", "-")))
        Debug.WriteLine(P.dataEntrada)
        'Debug.WriteLine(Convert.ToDateTime(P.dataEntrada))
        CMD.Parameters.AddWithValue("@dataSaida", If(String.IsNullOrEmpty(P.dataSaida), DBNull.Value, P.dataSaida.Replace("/", "-")))

        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update patient in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
            ClearFields()
            MsgBox("Dados do Paciente " + P.noUtenteSaude + " atualizados.")
        End Try
        CN.Close()
    End Sub


    '''''''''''''''''''''''''''''''''''' ELIMINAR PACIENTE ''''''''''''''''''''''''''''''''''''''''''''''
    '''
    Private Sub bttnEliminar_Click(sender As Object, e As EventArgs) Handles bttnEliminar.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                EliminarPaciente(CType(ListBox1.SelectedItem, Patient).noUtenteSaude)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentPatient = ListBox1.Items.Count Then currentPatient = ListBox1.Items.Count - 1
            If currentPatient = -1 Then
                MsgBox("Não existem mais Pacientes")
            Else
                ShowInfoPatient()
            End If
        End If
    End Sub

    '' Remove um paciente em função do seu noUtenteSaude 
    Private Sub EliminarPaciente(ByVal noUtenteSaude As String)

        CN.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[sp_eliminarPaciente]"
        CMD.Parameters.AddWithValue("@noUtenteSaude", noUtenteSaude)

        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to delete patient in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    ''''''''''''''''''''''''''''''''''''' ATUALIZAR a lista de Pacientes '''''''''''''''''''''''''''''''''''''
    Private Sub refreshListBox_Click(sender As Object, e As EventArgs) Handles refreshListBox.Click

        ClearFields()
        searchBar.Text = ""
        ShowListOfPatients()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''' PESQUISAR um Paciente ''''''''''''''''''''''''''''''''''''''''''

    ''' Pesquisa em função do seu noUtenteSaude, primeiroNome, ultimoNome e identificação do Quarto.
    Private Sub searchPaciente_Click(sender As Object, e As EventArgs) Handles searchPaciente.Click
        ClearFields()
        If searchBar.Text = "" Then
            MsgBox("Necessita de introduzir um filtro. 
                    Pode pesquisar o Paciente pelo seu número de Utente de Saúde, primeiro ou ultimo Nome 
                    e pela identificação do quarto.")
        Else
            CMD.CommandType = CommandType.Text
            CMD.CommandText = "SELECT * FROM getPacienteBy_NoUtenteSaude(" + searchBar.Text + ")"
            CN.Open()
            '' DataReader !! 
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            'ListBox1.Items.Clear()
            While RDR.Read
                Dim P As New Patient
                P.noUtenteSaude = RDR.Item("noUtenteSaude")
                P.firstName = RDR.Item("primeiroNome")
                P.lastName = RDR.Item("ultimoNome")
                P.bDate = RDR.Item("dataNascimento")
                P.genero = RDR.Item("genero")
                P.noTelefone = RDR.Item("noTelefone")
                P.rececionistaID = RDR.Item("func_ID_Rec")
                ''permite NULL
                P.quartoID = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Quarto")), "", RDR.Item("ID_Quarto")))
                P.dataEntrada = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataEntrada")), "", RDR.Item("dataEntrada"))).Replace(" 00:00:00", " ")
                P.dataSaida = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataSaida")), "", RDR.Item("dataSaida"))).Replace(" 00:00:00", " ")

                For index As Integer = 0 To ListBox1.Items.Count - 1
                    Dim l_text As Patient = CType(ListBox1.Items(index), Patient)
                    'Debug.WriteLine(l_text)
                    ''' Ir buscar o nome da pessoa que se colocou na pesquisa.
                    'Debug.WriteLine(l_text.firstName)
                    If l_text.firstName = P.firstName And l_text.lastName = P.lastName Then
                        'Debug.WriteLine(index)
                        ListBox1.SelectedIndex = index
                        ShowInfoPatient()
                    End If
                Next
            End While
            CN.Close()
        End If
    End Sub

End Class

