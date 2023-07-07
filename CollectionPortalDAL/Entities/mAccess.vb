Namespace Entities
    Public Class mAccess
        Inherits EntityBase

        Private _Id As String
        Public Property Id() As String
            Get
                Return _Id
            End Get
            Set(ByVal value As String)
                _Id = value
            End Set
        End Property

        Private _refID As String
        Public Property refID() As String
            Get
                Return _refID
            End Get
            Set(ByVal value As String)
                _refID = value
            End Set
        End Property

        Private _refCode As String
        Public Property refCode() As String
            Get
                Return _refCode
            End Get
            Set(ByVal value As String)
                _refCode = value
            End Set
        End Property


        Private _listPageArray As String
        Public Property listPageArray() As String
            Get
                Return _listPageArray
            End Get
            Set(ByVal value As String)
                _listPageArray = value
            End Set
        End Property


        Private _Description As String
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

    End Class
End Namespace
