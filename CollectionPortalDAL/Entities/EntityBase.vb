Namespace Entities
    Public MustInherit Class EntityBase
        Private _sqlrownumber As Integer = 0
        Private _errorCode As String = "0"
        Private _errorDescription As String = String.Empty
        
        Public Property SqlRowNumber() As Integer
            Get
                Return Me._sqlrownumber
            End Get
            Set(value As Integer)
                Me._sqlrownumber = value
            End Set
        End Property

        Public Property ErrorCode() As String
            Get
                Return Me._errorCode
            End Get
            Set(value As String)
                Me._errorCode = value
            End Set
        End Property

        Public Property ErrorDescription() As String
            Get
                Return Me._errorDescription
            End Get
            Set(value As String)
                Me._errorDescription = value
            End Set
        End Property

        Private _authUID As String
        Public Property AuthUID() As String
            Get
                Return _authUID
            End Get
            Set(ByVal value As String)
                _authUID = value
            End Set
        End Property

        Private _processDate As DateTime
        Public Property ProcessDate() As DateTime
            Get
                Return _processDate
            End Get
            Set(ByVal value As DateTime)
                _processDate = value
            End Set
        End Property


    End Class

End Namespace