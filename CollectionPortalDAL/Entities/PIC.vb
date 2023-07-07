Namespace Entities
    Public Class PIC
        Inherits EntityBase

        Private _pic_uid As String
        Public Property pic_uid() As String
            Get
                Return _pic_uid
            End Get
            Set(ByVal value As String)
                _pic_uid = value
            End Set
        End Property

        Private _pic_name As String
        Public Property pic_name() As String
            Get
                Return _pic_name
            End Get
            Set(ByVal value As String)
                _pic_name = value
            End Set
        End Property


    End Class
End Namespace
