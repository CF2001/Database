Public Class Departamento
    Private _NomeDept As String
    Private _IDdept As String
    Private _IDsupervisorDept As String

    Property NomeDept() As String
        Get
            Return _NomeDept
        End Get
        Set(ByVal value As String)
            _NomeDept = value
        End Set
    End Property

    Property IDdept() As String
        Get
            Return _IDdept
        End Get
        Set(ByVal value As String)
            _IDdept = value
        End Set
    End Property

    Property IDsupervisorDept() As String
        Get
            Return _IDsupervisorDept
        End Get
        Set(ByVal value As String)
            _IDsupervisorDept = value
        End Set
    End Property


End Class
