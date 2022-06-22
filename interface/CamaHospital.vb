<Serializable()> Public Class CamaHospital
    Private _IDcama As String
    Private _estadoCama As String

    Property IDcama() As String
        Get
            Return _IDcama
        End Get
        Set(ByVal value As String)
            _IDcama = value
        End Set
    End Property

    Property estadoCama() As String
        Get
            Return _estadoCama
        End Get
        Set(ByVal value As String)
            _estadoCama = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

End Class
