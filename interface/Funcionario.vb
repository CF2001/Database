<Serializable> Public Class Funcionario
    Private _funcID As String
    Private _primeiroNome As String
    Private _ultimoNome As String
    Private _dataNascimento As String
    Private _genero As String
    Private _telefone As String
    Private _morada As String
    Private _salary As String
    Private _email As String
    Private _tipo As String

    Property funcID() As String
        Get
            Return _funcID
        End Get
        Set(ByVal value As String)
            _funcID = value
        End Set
    End Property

    Property primeiroNome() As String
        Get
            Return _primeiroNome
        End Get
        Set(ByVal value As String)
            _primeiroNome = value
        End Set
    End Property

    Property ultimoNome() As String
        Get
            Return _ultimoNome
        End Get
        Set(ByVal value As String)
            _ultimoNome = value
        End Set
    End Property

    Property dataNascimento() As String
        Get
            Return _dataNascimento
        End Get
        Set(ByVal value As String)
            _dataNascimento = value
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

    Property telefone() As String
        Get
            Return _telefone
        End Get
        Set(ByVal value As String)      '' Verificar que tem 9 carcateres !!
            _telefone = value
        End Set
    End Property

    Property morada() As String
        Get
            Return _morada
        End Get
        Set(ByVal value As String)
            _morada = value
        End Set
    End Property

    Property salary() As String
        Get
            Return _salary
        End Get
        Set(ByVal value As String)
            _salary = value
        End Set
    End Property

    Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    ' Forma de como aparece na ListBox1 - infoPacientes.vb
    Overrides Function ToString() As String
        Return _primeiroNome & "" & _ultimoNome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

End Class
