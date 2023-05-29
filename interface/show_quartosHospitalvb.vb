Imports System.Data.SqlClient

Public Class show_quartosHospitalvb

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentQ_ListView As Integer = 0

    ' Connection to database Hospital Management System
    Private Sub InfoPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=tcp:mednat.ieeta.pt\SQLSERVER,8101;integrated security=true;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    '''''''''''''''''''' Dispõe a lista de pacientes e camas de um determiando Quarto inserido na txt box.
    Private Sub showInformation(sender As Object, e As EventArgs) Handles MyBase.Load

        '' Inicialize ListView Paciente
        ListView1.HoverSelection = True
        ListView1.FullRowSelect = True
        ListView1.GridLines = False
        ListView1.ShowGroups = False

        CMD.CommandType = CommandType.Text
        CMD.CommandText = "SELECT * FROM Quarto_Hospital"
        CN.Open()
        '' DataReader !! 
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListView1.Items.Clear()
        While RDR.Read
            Dim quarto As New QuartoHospital
            quarto.IDquarto = RDR.Item("ID_Quarto")
            quarto.noCamas = RDR.Item("noCamas")

            '' Add valores na listView
            ListView1.Items.Add(quarto.IDquarto)   '' 1º coluna
            ListView1.Items(currentQ_ListView).SubItems.Add(quarto.noCamas) '' 2º coluna

            currentQ_ListView += 1
        End While
        CN.Close()

    End Sub
End Class


<Serializable()> Public Class QuartoHospital
    Private _IDquarto As String
    Private _noCamas As String

    Property IDquarto() As String
        Get
            Return _IDquarto
        End Get
        Set(ByVal value As String)
            _IDquarto = value
        End Set
    End Property

    Property noCamas() As String
        Get
            Return _noCamas
        End Get
        Set(ByVal value As String)
            _noCamas = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

End Class
