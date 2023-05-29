Imports System.Data.SqlClient

Public Class Departamentos

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentDept As Integer = 0


    ' Connection to database Hospital Management System
    Private Sub InfoPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=tcp:mednat.ieeta.pt\SQLSERVER,8101;integrated security=true;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.Load

        '' Inicialize lv_Departamentos
        lv_Departamentos.HoverSelection = True
        lv_Departamentos.FullRowSelect = True
        lv_Departamentos.GridLines = True
        lv_Departamentos.ShowGroups = False

        CMD.CommandText = "SELECT * FROM Departamento"
        CN.Open()
        '' DataReader !! 
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        lv_Departamentos.Items.Clear()
        While RDR.Read
            Dim Dep As New Departamento

            Dep.NomeDept = RDR.Item("nome_dept")
            Dep.IDdept = RDR.Item("ID_dept")
            Dep.IDsupervisorDept = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_supervisor_dept")), "", RDR.Item("ID_supervisor_dept")))

            '' Add valores na listView
            lv_Departamentos.Items.Add(Dep.NomeDept)   '' 1º coluna
            lv_Departamentos.Items(currentDept).SubItems.Add(Dep.IDdept) '' 2º coluna
            lv_Departamentos.Items(currentDept).SubItems.Add(Dep.IDsupervisorDept)

            currentDept += 1
        End While
        CN.Close()
    End Sub

End Class
