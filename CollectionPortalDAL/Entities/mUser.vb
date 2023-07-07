Namespace Entities
    Public Class mUser
        Inherits EntityBase

        Private _user_id As String
        Public Property user_id() As String
            Get
                Return _user_id
            End Get
            Set(ByVal value As String)
                _user_id = value
            End Set
        End Property

        Private _ClientID As String
        Public Property ClientID() As String
            Get
                Return _ClientID
            End Get
            Set(ByVal value As String)
                _ClientID = value
            End Set
        End Property

        Private _CorrName As String
        Public Property CorrName() As String
            Get
                Return _CorrName
            End Get
            Set(ByVal value As String)
                _CorrName = value
            End Set
        End Property

        Private _UAccess As String
        Public Property UAccess() As String
            Get
                Return _UAccess
            End Get
            Set(ByVal value As String)
                _UAccess = value
            End Set
        End Property

        Private _UType As String
        Public Property UType() As String
            Get
                Return _UType
            End Get
            Set(ByVal value As String)
                _UType = value
            End Set
        End Property

        Private _Phone As String
        Public Property Phone() As String
            Get
                Return _Phone
            End Get
            Set(ByVal value As String)
                _Phone = value
            End Set
        End Property

        Private _Address As String
        Public Property Address() As String
            Get
                Return _Address
            End Get
            Set(ByVal value As String)
                _Address = value
            End Set
        End Property

        Private _CompanyName As String
        Public Property CompanyName() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal value As String)
                _CompanyName = value
            End Set
        End Property

        Private _AdminName As String
        Public Property AdminName() As String
            Get
                Return _AdminName
            End Get
            Set(ByVal value As String)
                _AdminName = value
            End Set
        End Property

        Private _UID As String
        Public Property UID() As String
            Get
                Return _UID
            End Get
            Set(ByVal value As String)
                _UID = value
            End Set
        End Property

        Private _Isadmin As String
        Public Property Isadmin() As String
            Get
                Return _Isadmin
            End Get
            Set(ByVal value As String)
                _Isadmin = value
            End Set
        End Property

        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _Prod_ctr As String
        Public Property Prod_ctr() As String
            Get
                Return _Prod_ctr
            End Get
            Set(ByVal value As String)
                _Prod_ctr = value
            End Set
        End Property

        Private _AccessID As String
        Public Property AccessID() As String
            Get
                Return _AccessID
            End Get
            Set(ByVal value As String)
                _AccessID = value
            End Set
        End Property

        Private _Email As String
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property

        Private _Expirydate As String
        Public Property Expirydate() As String
            Get
                Return _Expirydate
            End Get
            Set(ByVal value As String)
                _Expirydate = value
            End Set
        End Property

        Private _Password As String
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
 

    End Class
End Namespace
