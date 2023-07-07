Namespace Entities
    Public Class Account
        Inherits EntityBase
        Sub New()

        End Sub

        Sub New(ByVal uid As String, ByVal user_name As String, ByVal accessid As String, ByVal isadmin As String)
            _uid = uid
            _user_name = user_name
            _accessid = accessid
            _isadmin = isadmin
        End Sub



        Sub New(ByVal user_id As String, ByVal uid As String, ByVal email As String, ByVal admin_name As String, ByVal company_name As String, ByVal utype As String, ByVal utype_desc As String, ByVal uaccess As String, ByVal uaccess_des As String)
            ' TODO: Complete member initialization 
            _user_id = user_id
            _uid = uid
            _email = email
            _admin_name = admin_name
            _company_name = company_name
            _utype = utype
            _utype_desc = utype_desc
            _uaccess = uaccess
            _uaccess_des = uaccess_des
        End Sub

        Private _user_id As String
        Public Property user_id() As String
            Get
                Return _user_id
            End Get
            Set(ByVal value As String)
                _user_id = value
            End Set
        End Property

        Private _uaccess_des As String
        Public Property uaccess_des() As String
            Get
                Return _uaccess_des
            End Get
            Set(ByVal value As String)
                _uaccess_des = value
            End Set
        End Property

        Private _uaccess As String
        Public Property uaccess() As String
            Get
                Return _uaccess
            End Get
            Set(ByVal value As String)
                _uaccess = value
            End Set
        End Property

        Private _utype_desc As String
        Public Property utype_desc() As String
            Get
                Return _utype_desc
            End Get
            Set(ByVal value As String)
                _utype_desc = value
            End Set
        End Property

        Private _utype As String
        Public Property utype() As String
            Get
                Return _utype
            End Get
            Set(ByVal value As String)
                _utype = value
            End Set
        End Property

        Private _company_name As String
        Public Property company_name() As String
            Get
                Return _company_name
            End Get
            Set(ByVal value As String)
                _company_name = value
            End Set
        End Property

        Private _admin_name As String
        Public Property admin_name() As String
            Get
                Return _admin_name
            End Get
            Set(ByVal value As String)
                _admin_name = value
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

        Private _accessid As String
        Public Property accessid() As String
            Get
                Return _accessid
            End Get
            Set(ByVal value As String)
                _accessid = value
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

        Private _isadmin As Boolean
        Public Property isadmin() As Boolean
            Get
                Return _isadmin
            End Get
            Set(ByVal value As Boolean)
                _isadmin = value
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
    End Class
End Namespace

