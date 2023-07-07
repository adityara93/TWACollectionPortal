Namespace Entities
    Public Class AccountUser
        Inherits EntityBase

        Sub New()

        End Sub

        Sub New(ByVal uid As String, ByVal user_name As String, ByVal pos_id As Integer)
            _uid = uid
            _user_name = user_name
            _pos_id = pos_id
        End Sub

        Private _pos_id As String
        Public Property pos_id() As String
            Get
                Return _pos_id
            End Get
            Set(ByVal value As String)
                _pos_id = value
            End Set
        End Property

        Private _prod_ctr As String
        Public Property prod_ctr() As String
            Get
                Return _prod_ctr
            End Get
            Set(ByVal value As String)
                _prod_ctr = value
            End Set
        End Property

        Private _password As String
        Public Property password() As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                _password = value
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
        
        Private _user_name As String
        Public Property user_name() As String
            Get
                Return _user_name
            End Get
            Set(ByVal value As String)
                _user_name = value
            End Set
        End Property
       

        Private _from_date As Date
        Public Property from_date() As Date
            Get
                Return _from_date
            End Get
            Set(ByVal value As Date)
                _from_date = value
            End Set
        End Property

        Private _file_path As String
        Public Property file_path() As String
            Get
                Return _file_path
            End Get
            Set(ByVal value As String)
                _file_path = value
            End Set
        End Property

        Private _exp_date As Date
        Public Property exp_date() As Date
            Get
                Return _exp_date
            End Get
            Set(ByVal value As Date)
                _exp_date = value
            End Set
        End Property

        Private _mod_uid As String
        Public Property mod_uid() As String
            Get
                Return _mod_uid
            End Get
            Set(ByVal value As String)
                _mod_uid = value
            End Set
        End Property


        Private _mod_date As String
        Public Property mod_date() As String
            Get
                Return _mod_date
            End Get
            Set(ByVal value As String)
                _mod_date = value
            End Set
        End Property

        Private _email As String
        Public Property email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property

    End Class
End Namespace

