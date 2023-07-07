Imports System.Text.RegularExpressions

Namespace Helper
    Public Class ClassGlobal
        Public Shared ReadOnly Property VirtualAccountDashboard As String
            Get
                Return "VirtualAccountDashboard"
            End Get
        End Property
        Public Shared ReadOnly Property CollectionPortalDB As String
            Get
                Return "CollectionPortalDB"
            End Get
        End Property

        Public Shared ReadOnly Property CurrentCulture As System.Globalization.CultureInfo
            Get
                Return System.Globalization.CultureInfo.CurrentCulture
            End Get
        End Property

        Public Shared ReadOnly Property IDCulture As System.Globalization.CultureInfo
            Get
                Return System.Globalization.CultureInfo.CreateSpecificCulture("id-ID")
            End Get
        End Property

        '
#Region "Set Error"
        Public Shared ReadOnly Property NO_ERROR As Integer
            Get
                Return "0"
            End Get
        End Property
        Public Shared ReadOnly Property NO_ERROR_DESC As String
            Get
                Return "SUCCESS"
            End Get
        End Property
        Public Shared ReadOnly Property UNKNOWN_ERROR As Integer
            Get
                Return "99999"
            End Get
        End Property
        Public Shared Function SetError(ByVal dsParam As Data.DataSet, ByVal sErrorCode As String, ByVal sErrorDescription As String) As Data.DataSet
            dsParam.ExtendedProperties("ErrorCode") = sErrorCode
            dsParam.ExtendedProperties("ErrorDescription") = sErrorDescription
            Return dsParam
        End Function
#End Region

#Region "Format Data"
        Public Shared ReadOnly Property FORMAT_AMT As String
            Get
                Return "###,###,###,###,##0.00"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_AMT2 As String
            Get
                Return "###,###,###,###,##0.0000"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_AMT3 As String
            Get
                Return "#####0"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_AMT4 As String
            Get
                Return "###,###,###,###,##0"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_PCT As String
            Get
                Return "##0.0000"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_DATE As String
            Get
                Return "MM/dd/yyyy"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_DATE2 As String
            Get
                Return "dd MMMM yyyy"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_DATE3 As String
            Get
                Return "dd MMMM yyyy hh:mm:ss"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_DATE4 As String
            Get
                Return "dd/MM/yyyy"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_DATE5 As String
            Get
                Return "yyyy-MM-dd"
            End Get
        End Property
        Public Shared ReadOnly Property FORMAT_DATE6 As String
            Get
                Return "yyyy-MM-dd HH:mm:ss.fff"
            End Get
        End Property
#End Region

#Region "ValidData"
        Public Shared Function IsValidDate(ByVal d As Object) As Boolean
            Try
                Dim dd As DateTime = Convert.ToDateTime(d)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Shared Function IsValidInteger(ByVal d As Object, ByVal positive As Boolean) As Boolean
            Try
                Dim dd As Integer = Convert.ToInt64(d)
                If positive Then Return dd >= 0
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Shared Function IsValidDecimal(ByVal d As Object) As Boolean
            Try
                Dim dd As Decimal = Convert.ToDecimal(d)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Shared Function IsValidDouble(ByVal d As Object) As Boolean
            Try
                Dim dd As Double = Convert.ToDouble(d)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Shared Function IsValidString(ByVal d As Object) As Boolean
            Try
                Dim dd As String = Convert.ToString(d)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Shared Function IsValidYear(ByVal d As Object) As Boolean
            If Not IsValidInteger(d, True) Then Return False
            Dim y As Integer = Convert.ToInt32(d)
            Return 1900 <= y AndAlso y <= 9999
        End Function
        Public Shared Function IsValidEmail(ByVal d As Object) As Boolean
            Try
                Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
                Return emailExpression.IsMatch(d)
            Catch ex As Exception
                Return False
            End Try
        End Function
#End Region


    End Class

End Namespace
