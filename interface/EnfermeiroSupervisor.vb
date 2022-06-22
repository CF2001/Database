<Serializable()> Public Class EnfermeiroSupervisor
    Private _IDfuncionarioEnfS As String
    Private _IDCamaEnfS As String

    Property IDfuncionarioEnfS() As String
        Get
            Return _IDfuncionarioEnfS
        End Get
        Set(ByVal value As String)
            _IDfuncionarioEnfS = value
        End Set
    End Property

    Property IDCamaEnfS() As String
        Get
            Return _IDCamaEnfS
        End Get
        Set(ByVal value As String)
            _IDCamaEnfS = value
        End Set
    End Property
End Class
