Namespace Helper
    Public Class SimpleBindingObject
#Region " Variables "

        Private _lookupDisplay As Object = Nothing
        Private _lookupValue As Object = Nothing

#End Region

#Region " Constructors/Destructor "

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal display As Object, ByVal value As Object)
            MyBase.New()
            Me._lookupDisplay = display
            Me._lookupValue = value
        End Sub

#End Region

#Region " Properties "

        Public Property LookupDisplay() As Object
            Get
                Return Me._lookupDisplay
            End Get
            Set(ByVal value As Object)
                Me._lookupDisplay = value
            End Set
        End Property

        Public Property LookupValue() As Object
            Get
                Return Me._lookupValue
            End Get
            Set(ByVal value As Object)
                Me._lookupValue = value
            End Set
        End Property

#End Region
    End Class
End Namespace
