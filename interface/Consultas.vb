Imports System.Data.SqlClient

Public Class Consultas
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentConsulta As Integer = 0
    Private Sub InfoConsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=LAPTOP-4HV6V7EN\SQLEXPRESS;integrated security=True;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.Load

        lv_Consultas.HoverSelection = True
        lv_Consultas.FullRowSelect = True
        lv_Consultas.GridLines = True
        lv_Consultas.ShowGroups = False


        CMD.CommandType = CommandType.Text
        CMD.CommandText = "SELECT * FROM Cirurgia"
        CN.Open()
        '' DataReader !! 
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        lv_Consultas.Items.Clear()
        While RDR.Read
            Dim C As New Consulta

            C.funcIDMedico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("funcIDMedico")), "", RDR.Item("funcIDMedico")))
            C.dataConsulta = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataConsulta")), "", RDR.Item("dataConsulta")))
            C.hora = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("hora")), "", RDR.Item("hora")))
            C.noConsulta = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("noConsulta")), "", RDR.Item("noConsulta")))
            C.noUtenteSaude = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("noUtenteSaude")), "", RDR.Item("noUtenteSaude")))

            '' Add valores na listView
            lv_Consultas.Items.Add(C.noUtenteSaude)   '' 1º coluna
            lv_Consultas.Items(currentConsulta).SubItems.Add(C.noConsulta) '' 2º coluna
            lv_Consultas.Items(currentConsulta).SubItems.Add(C.dataConsulta)
            lv_Consultas.Items(currentConsulta).SubItems.Add(C.hora)
            lv_Consultas.Items(currentConsulta).SubItems.Add(C.funcIDMedico)

            currentConsulta += 1
        End While
        CN.Close()
    End Sub
End Class


<Serializable()> Public Class Consulta
    Private _funcIDMedico As String
    Private _noConsulta As String
    Private _hora As String
    Private _dataConsulta As String
    Private _noUtenteSaude As String

    Property funcIDMedico As String
        Get
            Return _funcIDMedico
        End Get
        Set(ByVal value As String)
            _funcIDMedico = value
        End Set
    End Property

    Property noConsulta As String
        Get
            Return _noConsulta
        End Get
        Set(ByVal value As String)
            _noConsulta = value
        End Set
    End Property

    Property dataConsulta As String
        Get
            Return _dataConsulta
        End Get
        Set(ByVal value As String)
            _dataConsulta = value
        End Set
    End Property

    Property hora As String
        Get
            Return _hora
        End Get
        Set(ByVal value As String)
            _hora = value
        End Set
    End Property


    Property noUtenteSaude As String
        Get
            Return _noUtenteSaude
        End Get
        Set(ByVal value As String)
            _noUtenteSaude = value
        End Set
    End Property

End Class

