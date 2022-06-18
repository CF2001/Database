<Serializable()> Public Class Patient
    Private _noUtenteSaude As String
    Private _firstName As String
    Private _lastName As String
    Private _bDate As String
    Private _genero As String
    Private _noTelefone As String
    Private _rececionistaID As String
    Private _quartoID As String
    Private _dataEntrada As String
    Private _dataSaida As String

    Property noUtenteSaude() As String
        Get
            Return _noUtenteSaude
        End Get
        Set(ByVal value As String)
            _noUtenteSaude = value
        End Set
    End Property

    Property firstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    Property lastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property
    Property bDate() As String
        Get
            Return _bDate
        End Get
        Set(ByVal value As String)
            _bDate = value
        End Set
    End Property

    Property genero() As String
        Get
            Return _genero
        End Get
        Set(ByVal value As String)  '' Verificar que é inserido F ou M
            _genero = value
        End Set
    End Property

    Property noTelefone() As String
        Get
            Return _noTelefone
        End Get
        Set(ByVal value As String)      '' Verificar que tem 9 carcateres !!
            _noTelefone = value
        End Set
    End Property

    Property rececionistaID() As String
        Get
            Return _rececionistaID
        End Get
        Set(ByVal value As String)
            _rececionistaID = value
        End Set
    End Property

    Property quartoID() As String
        Get
            Return _quartoID
        End Get
        Set(ByVal value As String)
            _quartoID = value
        End Set
    End Property

    Property dataEntrada() As String
        Get
            Return _dataEntrada
        End Get
        Set(ByVal value As String)
            _dataEntrada = value
        End Set
    End Property

    Property dataSaida() As String
        Get
            Return _dataSaida
        End Get
        Set(ByVal value As String)
            _dataSaida = value
        End Set
    End Property

    ' Forma de como aparece na ListBox1 - infoPacientes.vb
    Overrides Function ToString() As String
        Return _firstName & "" & _lastName
    End Function

    Public Sub New()
        MyBase.New()
    End Sub




End Class
