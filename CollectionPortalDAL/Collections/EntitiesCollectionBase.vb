Namespace Collections
    Public MustInherit Class EntitiesCollectionBase
        Private _SqlRowNumber As Integer
        Private _errorCode As String = 0
        Private _errorDescription As String = String.Empty

        Public Property SqlRowNumber() As Integer
            Get
                Return Me._SqlRowNumber
            End Get
            Set(value As Integer)
                Me._SqlRowNumber = value
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
    End Class

End Namespace
