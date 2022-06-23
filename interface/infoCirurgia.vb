Imports System.Data.SqlClient

Public Class Cirurgias
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentCirurgia As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=LAPTOP-4HV6V7EN\SQLEXPRESS;integrated security=True;initial catalog=Hospital_Management_System")
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles MyBase.Load

        lv_Cirurgias.HoverSelection = True
        lv_Cirurgias.FullRowSelect = True
        lv_Cirurgias.GridLines = True
        lv_Cirurgias.ShowGroups = False


        CMD.CommandType = CommandType.Text
        CMD.CommandText = "SELECT * FROM Cirurgia"
        CN.Open()
        '' DataReader !! 
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        lv_Cirurgias.Items.Clear()
        While RDR.Read
            Dim C As New Cirurgia

            C.tipoCirurgia = RDR.Item("tipoCirurgia")
            C.dataCirurgia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("dataCirurgia")), "", RDR.Item("dataCirurgia")))
            C.horaInicio = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("horaInicio")), "", RDR.Item("horaInicio")))
            C.duracao = RDR.Item("duracao")
            C.equipaMID = RDR.Item("equipaMID")
            C.noBlocoOperatorio = RDR.Item("noBlocoOperatorio")
            C.noUtenteSaude = RDR.Item("noUtenteSaude")

            '' Add valores na listView
            lv_Cirurgias.Items.Add(C.noUtenteSaude)   '' 1º coluna
            lv_Cirurgias.Items(currentCirurgia).SubItems.Add(C.noBlocoOperatorio) '' 2º coluna
            lv_Cirurgias.Items(currentCirurgia).SubItems.Add(C.dataCirurgia)
            lv_Cirurgias.Items(currentCirurgia).SubItems.Add(C.horaInicio)
            lv_Cirurgias.Items(currentCirurgia).SubItems.Add(C.duracao)
            lv_Cirurgias.Items(currentCirurgia).SubItems.Add(C.tipoCirurgia)
            lv_Cirurgias.Items(currentCirurgia).SubItems.Add(C.equipaMID)

            currentCirurgia += 1
        End While
        CN.Close()
    End Sub
End Class


<Serializable()> Public Class Cirurgia
        Private _tipoCirurgia As String
        Private _dataCirurgia As String
        Private _horaInicio As String
        Private _duracao As String
        Private _equipaMID As String
        Private _noBlocoOperatorio As String
        Private _noUtenteSaude As String

        Property tipoCirurgia As String
            Get
                Return _tipoCirurgia
            End Get
            Set(ByVal value As String)
                _tipoCirurgia = value
            End Set
        End Property

        Property dataCirurgia As String
            Get
                Return _dataCirurgia
            End Get
            Set(ByVal value As String)
                _dataCirurgia = value
            End Set
        End Property

        Property horaInicio As String
            Get
                Return _horaInicio
            End Get
            Set(ByVal value As String)
                _horaInicio = value
            End Set
        End Property

        Property duracao As String
            Get
                Return _duracao
            End Get
            Set(ByVal value As String)
                _duracao = value
            End Set
        End Property

        Property equipaMID As String
            Get
                Return _equipaMID
            End Get
            Set(ByVal value As String)
                _equipaMID = value
            End Set
        End Property

        Property noBlocoOperatorio As String
            Get
                Return _noBlocoOperatorio
            End Get
            Set(ByVal value As String)
                _noBlocoOperatorio = value
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

