Namespace Entities
    Public Class mPage
        Inherits EntityBase

        Private _ID As String
        Public Property ID() As String
            Get
                Return _ID
            End Get
            Set(ByVal value As String)
                _ID = value
            End Set
        End Property

        Private _PageURL As String
        Public Property PageURL() As String
            Get
                Return _PageURL
            End Get
            Set(ByVal value As String)
                _PageURL = value
            End Set
        End Property

        Private _PageHeader As String
        Public Property PageHeader() As String
            Get
                Return _PageHeader
            End Get
            Set(ByVal value As String)
                _PageHeader = value
            End Set
        End Property

        Private _PageControlID As String
        Public Property PageControlID() As String
            Get
                Return _PageControlID
            End Get
            Set(ByVal value As String)
                _PageControlID = value
            End Set
        End Property

        Private _HeaderID As String
        Public Property HeaderID() As String
            Get
                Return _HeaderID
            End Get
            Set(ByVal value As String)
                _HeaderID = value
            End Set
        End Property

        Private _PageDescription As String
        Public Property PageDescription() As String
            Get
                Return _PageDescription
            End Get
            Set(ByVal value As String)
                _PageDescription = value
            End Set
        End Property

    End Class
End Namespace
