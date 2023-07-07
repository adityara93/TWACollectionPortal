Namespace Entities
    Public Class mCollection
        Inherits EntityBase

        Private _colStatus As String
        Public Property colStatus() As String
            Get
                Return _colStatus
            End Get
            Set(ByVal value As String)
                _colStatus = value
            End Set
        End Property

        Private _lCodeId As String
        Public Property lCodeId() As String
            Get
                Return _lCodeId
            End Get
            Set(ByVal value As String)
                _lCodeId = value
            End Set
        End Property

        Private _docNbr As String
        Public Property docNbr() As String
            Get
                Return _docNbr
            End Get
            Set(ByVal value As String)
                _docNbr = value
            End Set
        End Property


        Private _polNbr As String
        Public Property polNbr() As String
            Get
                Return _polNbr
            End Get
            Set(ByVal value As String)
                _polNbr = value
            End Set
        End Property

        Private _collectionNbr As String
        Public Property collectionNbr() As String
            Get
                Return _collectionNbr
            End Get
            Set(ByVal value As String)
                _collectionNbr = value
            End Set
        End Property

        Private _correspondentID As String
        Public Property correspondentID() As String
            Get
                Return _correspondentID
            End Get
            Set(ByVal value As String)
                _correspondentID = value
            End Set
        End Property

        Private _dueDate As DateTime
        Public Property dueDate() As DateTime
            Get
                Return _dueDate
            End Get
            Set(ByVal value As DateTime)
                _dueDate = value
            End Set
        End Property

        Private _uPiutang As String
        Public Property uPiutang() As String
            Get
                Return _uPiutang
            End Get
            Set(ByVal value As String)
                _uPiutang = value
            End Set
        End Property

        Private _totalAmount As String
        Public Property totalAmount() As String
            Get
                Return _totalAmount
            End Get
            Set(ByVal value As String)
                _totalAmount = value
            End Set
        End Property

        Private _uid As String
        Public Property uid() As String
            Get
                Return _uid
            End Get
            Set(ByVal value As String)
                _uid = value
            End Set
        End Property
    End Class
End Namespace

