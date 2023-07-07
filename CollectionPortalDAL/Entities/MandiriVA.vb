Namespace Entities
    Public Class MandiriVA
        Inherits EntityBase

        Private _control1 As String
        Public Property control1() As String
            Get
                Return _control1
            End Get
            Set(ByVal value As String)
                _control1 = value
            End Set
        End Property
 
        Private _control2 As String
        Public Property control2() As String
            Get
                Return _control2
            End Get
            Set(ByVal value As String)
                _control2 = value
            End Set
        End Property

        Private _control3 As String
        Public Property control3() As String
            Get
                Return _control3
            End Get
            Set(ByVal value As String)
                _control3 = value
            End Set
        End Property


        Private _control4 As String
        Public Property control4() As String
            Get
                Return _control4
            End Get
            Set(ByVal value As String)
                _control4 = value
            End Set
        End Property

        Private _control5 As String
        Public Property control5() As String
            Get
                Return _control5
            End Get
            Set(ByVal value As String)
                _control5 = value
            End Set
        End Property

        Private _Client_ID As String
        Public Property Client_ID() As String
            Get
                Return _Client_ID
            End Get
            Set(ByVal value As String)
                _Client_ID = value
            End Set
        End Property


        Private _Curr_ID As String
        Public Property Curr_ID() As String
            Get
                Return _Curr_ID
            End Get
            Set(ByVal value As String)
                _Curr_ID = value
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
