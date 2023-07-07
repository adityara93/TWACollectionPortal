Namespace Entities
    Public Class r110client
        Inherits EntityBase

        Private _client_id As String
        Public Property client_id() As String
            Get
                Return _client_id
            End Get
            Set(ByVal value As String)
                _client_id = value
            End Set
        End Property

        Private _curr_id As String
        Public Property curr_id() As String
            Get
                Return _curr_id
            End Get
            Set(ByVal value As String)
                _curr_id = value
            End Set
        End Property

        Private _printed_name As String
        Public Property printed_name() As String
            Get
                Return _printed_name
            End Get
            Set(ByVal value As String)
                _printed_name = value
            End Set
        End Property


        Private _address1 As String
        Public Property address1() As String
            Get
                Return _address1
            End Get
            Set(ByVal value As String)
                _address1 = value
            End Set
        End Property

        Private _address2 As String
        Public Property address2() As String
            Get
                Return _address2
            End Get
            Set(ByVal value As String)
                _address2 = value
            End Set
        End Property

        Private _city As String
        Public Property city() As String
            Get
                Return _city
            End Get
            Set(ByVal value As String)
                _city = value
            End Set
        End Property

        Private _VANumber As String
        Public Property VANumber() As String
            Get
                Return _VANumber
            End Get
            Set(ByVal value As String)
                _VANumber = value
            End Set
        End Property

    End Class
End Namespace
