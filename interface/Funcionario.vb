Imports System.Data.SqlClient
Public Class Funcionario
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentFunc As Integer

    Private Sub Funcionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=LAPTOP-4HV6V7EN\SQLEXPRESS;integrated security=True;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    Private Sub ShowListOfFuncionarios() Handles MyBase.Load
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Clear()                  '''' Ver se é necessário
        CMD.CommandText = "SELECT * FROM Funcionario" '' for SQL statements
        CN.Open()
        '' DataReader !! 
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim F As New Funcionario
            F.funcID = RDR.Item("func_ID")
            F.primeiroNome = RDR.Item("primeiroNome")
            F.ultimoNome = RDR.Item("ultimoNome")
            F.dataNascimento = RDR.Item("dataNascimento")
            F.genero = RDR.Item("genero")
            F.telefone = RDR.Item("noTelefone")
            F.morada = RDR.Item("morada")
            F.salary = RDR.Item("salary")
            F.email = RDR.Item("email")
            F.tipo = RDR.Item("tipo")

            ListBox1.Items.Add(F)
        End While
        CN.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentFunc = ListBox1.SelectedIndex
            ShowInfoFuncionario()
        End If
    End Sub

    Sub ShowInfoFuncionario()
        If ListBox1.Items.Count = 0 Or currentFunc < 0 Then Exit Sub
        Dim funcionario As Funcionario = CType(ListBox1.Items.Item(currentFunc), Funcionario)
        txtFuncID.Text = funcionario.funcID
        txtPrimeiroNome.Text = funcionario.primeiroNome
        txtUltimoNome.Text = funcionario.ultimoNome
        txtDataNascimento.Text = funcionario.dataNascimento
        txtGenero.Text = funcionario.genero
        txtTelefone.Text = funcionario.telefone
        txtMorada.Text = funcionario.morada
        txtSalario.Text = funcionario.salary
        txtEmail.Text = funcionario.email
        txtTipo.Text = funcionario.tipo
    End Sub

    Private Function SaveFuncionario() As Boolean
        Dim funcionario As New Funcionario
        Try
            funcionario.funcID = txtFuncID.Text
            funcionario.primeiroNome = txtPrimeiroNome.Text
            funcionario.ultimoNome = txtUltimoNome.Text
            funcionario.dataNascimento = txtDataNascimento.Text
            funcionario.genero = txtGenero.Text
            funcionario.telefone = txtTelefone.Text
            funcionario.morada = txtMorada.Text
            funcionario.salary = txtSalario.Text
            funcionario.email = txtEmail.Text
            funcionario.tipo = txtTipo.Text

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        UpdateFuncionario(funcionario)        ''' Atualizar dados funcionario.
        ListBox1.Items(currentFunc) = funcionario

        Return True
    End Function

    Sub ClearFields()
        txtFuncID.Text = ""
        txtPrimeiroNome.Text = ""
        txtUltimoNome.Text = ""
        txtDataNascimento.Text = ""
        txtGenero.Text = ""
        txtTelefone.Text = ""
        txtMorada.Text = ""
        txtSalario.Text = ""
        txtEmail.Text = ""
        txtTipo.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            SaveFuncionario()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UpdateFuncionario(ByVal F As Funcionario)
        CN.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[sp_updateInfoFuncionario]"
        CMD.Parameters.AddWithValue("@funcID", F.funcID)
        CMD.Parameters.AddWithValue("@primeiroNome", F.primeiroNome)
        CMD.Parameters.AddWithValue("@ultimoNome", F.ultimoNome)
        CMD.Parameters.AddWithValue("@dataNascimento", F.dataNascimento)
        CMD.Parameters.AddWithValue("@genero", F.genero)
        CMD.Parameters.AddWithValue("@telefone", F.telefone)
        CMD.Parameters.AddWithValue("@morada", F.morada)
        CMD.Parameters.AddWithValue("@salary", F.salary)
        CMD.Parameters.AddWithValue("@email", F.email)
        CMD.Parameters.AddWithValue("@tipo", F.tipo)

        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update funcionario in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
            ClearFields()
            MsgBox("Dados do Paciente " + F.funcID + " atualizados.")
        End Try
        CN.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                EliminarFuncionario(CType(ListBox1.SelectedItem, Funcionario).funcID)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentFunc = ListBox1.Items.Count Then currentFunc = ListBox1.Items.Count - 1
            If currentFunc = -1 Then
                MsgBox("Não existem mais Pacientes")
            Else
                ShowInfoFuncionario()
            End If
        End If
    End Sub

    '' Remove um funcionario em função do seu ID 
    Private Sub EliminarFuncionario(ByVal funcID As String)

        CN.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Clear()
        CMD.CommandText = "[dbo].[sp_eliminarFuncionario]"
        CMD.Parameters.AddWithValue("@func_ID", funcID)

        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to delete patient in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ClearFields()
        searchBar.Text = ""
        ShowListOfFuncionarios()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ClearFields()
        If searchBar.Text = "" Then
            MsgBox("Necessita de introduzir um filtro. 
                    Pode pesquisar o Funcionario pelo seu ID.")
        Else
            CMD.CommandType = CommandType.Text
            CMD.CommandText = "SELECT * FROM Funcionario WHERE funcID = " + searchBar.Text
            CN.Open()
            '' DataReader !! 
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            ListBox1.Items.Clear()
            While RDR.Read
                Dim F As New Funcionario
                F.funcID = RDR.Item("func_ID")
                F.primeiroNome = RDR.Item("primeiroNome")
                F.ultimoNome = RDR.Item("ultimoNome")
                F.dataNascimento = RDR.Item("dataNascimento")
                F.genero = RDR.Item("genero")
                F.telefone = RDR.Item("noTelefone")
                F.morada = RDR.Item("morada")
                F.salary = RDR.Item("salary")
                F.email = RDR.Item("email")
                F.tipo = RDR.Item("tipo")
                ListBox1.Items.Add(F)
            End While
            CN.Close()
            currentFunc = 0
            ShowInfoFuncionario()
        End If
    End Sub
End Class