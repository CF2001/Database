Imports System.Data.SqlClient

Public Class show_EnfermeirosNAOsup

    Dim CN As SqlConnection
    Dim CMD As SqlCommand

    ' Connection to database Hospital Management System
    Private Sub InfoPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=tcp:mednat.ieeta.pt\SQLSERVER,8101;integrated security=true;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub
    Private Sub show_EnfermeirosNAOsup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Inicialize ListView Paciente
        ListView1.HoverSelection = True
        ListView1.FullRowSelect = True
        ListView1.GridLines = False
        ListView1.ShowGroups = False

        CMD.CommandType = CommandType.Text
        CMD.CommandText = "SELECT * FROM getEnfermeiros_naoS() "
        CN.Open()
        '' DataReader !! 
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListView1.Items.Clear()
        While RDR.Read
            Dim Enf As New Enf_NaoSup
            Enf.IDEnf = RDR.Item("func_ID_Enf")

            '' Add valores na listView
            ListView1.Items.Add(Enf.IDEnf)   '' 1º coluna
        End While
        CN.Close()
    End Sub
End Class


<Serializable()> Public Class Enf_NaoSup
    Private _IDEnf As String
    'Private _FirstnomeEnf As String
    'Private _LastnomeEnf As String

    Property IDEnf() As String
        Get
            Return _IDEnf
        End Get
        Set(ByVal value As String)
            _IDEnf = value
        End Set
    End Property

    'Property FirstnomeEnf() As String
    '    Get
    '        Return _FirstnomeEnf
    '    End Get
    '    Set(ByVal value As String)
    '        _FirstnomeEnf = value
    '    End Set
    'End Property

    'Property LastnomeEnf() As String
    '    Get
    '        Return _LastnomeEnf
    '    End Get
    '    Set(ByVal value As String)
    '        _LastnomeEnf = value
    '    End Set
    'End Property

    Public Sub New()
        MyBase.New()
    End Sub

End Class
