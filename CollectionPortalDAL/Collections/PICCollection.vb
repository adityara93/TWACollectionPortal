Namespace Collections
    Public Class PICCollection
        Inherits EntitiesCollectionBase

        Private _data As List(Of Entities.PIC)
        Public Sub New()
            MyBase.New()
            Me._data = New List(Of Entities.PIC)
        End Sub

        Public Property Data() As List(Of Entities.PIC)
            Get
                Return Me._data
            End Get
            Set(value As List(Of Entities.PIC))
                Me._data = value
            End Set
        End Property
    End Class
End Namespace
