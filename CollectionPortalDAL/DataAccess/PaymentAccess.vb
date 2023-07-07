Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Imports CollectionPortalDAL.Helper.ClassGlobal

Namespace DataAccess
    Public Class PaymentAccess

        Public Shared Function PaymentList() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("proc_GetPageData")

            db.DiscoverParameters(dbcommand)

            Try

                ds = db.ExecuteDataSet(dbcommand)
                If ds.Tables(0) Is Nothing Then
                    Throw New InvalidOperationException("No Data.")
                End If
                If ds.Tables(0).Rows.Count < 0 Then
                    Throw New InvalidOperationException("No Data.")
                End If
                ds = SetError(ds, 0, "Sukses")

            Catch exSql As SqlClient.SqlException
                ds = SetError(ds, UNKNOWN_ERROR, exSql.Message)
            Catch ex As Exception
                ds = SetError(ds, UNKNOWN_ERROR, ex.Message)
            End Try

            Return ds
        End Function

    End Class
End Namespace

