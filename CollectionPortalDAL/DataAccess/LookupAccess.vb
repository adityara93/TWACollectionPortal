Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports CollectionPortalDAL.Helper.ClassGlobal

Namespace DataAccess
    Public Class LookupAccess

        Public Function GetClient(ByVal obj As Entities.r110client) As DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)

            Dim ds As New DataSet
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("proc_GetClient")
            db.DiscoverParameters(dbCommand)

            dbCommand.Parameters("@client_id").Value = obj.client_id
            dbCommand.Parameters("@name").Value = obj.printed_name

            Try
                ds = db.ExecuteDataSet(dbCommand)
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

        Public Shared Function LookupUserType() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpUserType")

            db.DiscoverParameters(dbcommand)

            Try
                ds = db.ExecuteDataSet(dbcommand)
                ds.ExtendedProperties("ErrorCode") = NO_ERROR
                ds.ExtendedProperties("ErrorDescription") = ""
            Catch ex As Exception
                ds.ExtendedProperties("ErrorCode") = UNKNOWN_ERROR
                ds.ExtendedProperties("ErrorDescription") = ex.Message.ToString
            End Try
            Return ds
        End Function

        Public Shared Function LookupUmurPiutang() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpUmurPiutang")

            db.DiscoverParameters(dbcommand)

            Try
                ds = db.ExecuteDataSet(dbcommand)
                ds.ExtendedProperties("ErrorCode") = NO_ERROR
                ds.ExtendedProperties("ErrorDescription") = ""
            Catch ex As Exception
                ds.ExtendedProperties("ErrorCode") = UNKNOWN_ERROR
                ds.ExtendedProperties("ErrorDescription") = ex.Message.ToString
            End Try
            Return ds
        End Function

        Public Shared Function LookupStatusCollection() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpStatusCollection")

            db.DiscoverParameters(dbcommand)

            Try
                ds = db.ExecuteDataSet(dbcommand)
                ds.ExtendedProperties("ErrorCode") = NO_ERROR
                ds.ExtendedProperties("ErrorDescription") = ""
            Catch ex As Exception
                ds.ExtendedProperties("ErrorCode") = UNKNOWN_ERROR
                ds.ExtendedProperties("ErrorDescription") = ex.Message.ToString
            End Try
            Return ds
        End Function

        Public Shared Function LookupUserAccess() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpUserAccess")

            db.DiscoverParameters(dbcommand)

            Try
                ds = db.ExecuteDataSet(dbcommand)
                ds.ExtendedProperties("ErrorCode") = NO_ERROR
                ds.ExtendedProperties("ErrorDescription") = ""
            Catch ex As Exception
                ds.ExtendedProperties("ErrorCode") = UNKNOWN_ERROR
                ds.ExtendedProperties("ErrorDescription") = ex.Message.ToString
            End Try
            Return ds
        End Function

        Public Function GetVAByClientIDCurrID(ByVal obj As Entities.r110client) As DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)

            Dim ds As New DataSet
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("proc_GetVAByClientIDCurrID")
            db.DiscoverParameters(dbCommand)

            dbCommand.Parameters("@client_id").Value = obj.client_id
            dbCommand.Parameters("@curr_id").Value = obj.curr_id

            Try
                ds = db.ExecuteDataSet(dbCommand)
                If ds.Tables(0) Is Nothing Then
                    Throw New InvalidOperationException("No Data.")
                End If
                If ds.Tables(0).Rows.Count < 0 Or ds.Tables(0).Rows.Count = 0 Then
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

        Public Function GenerateMandiriVAByClient(ByVal objMandiriVA As Entities.MandiriVA,
                                                  ByVal objAccountUser As Entities.Account) As Entities.MandiriVA
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)

            Dim ds As New DataSet
            Dim dbCommand As DbCommand = db.GetStoredProcCommand("proc_GenerateVirtualAccountByClient")
            db.DiscoverParameters(dbCommand)

            dbCommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbCommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output
            dbCommand.Parameters("@VANumber").Direction = ParameterDirection.Output

            dbCommand.Parameters("@Control1").Value = objMandiriVA.control1
            dbCommand.Parameters("@Control2").Value = objMandiriVA.control2
            dbCommand.Parameters("@Control3").Value = objMandiriVA.control3
            dbCommand.Parameters("@Control4").Value = objMandiriVA.control4
            dbCommand.Parameters("@Control5").Value = objMandiriVA.control5
            dbCommand.Parameters("@Client_ID").Value = objMandiriVA.Client_ID
            dbCommand.Parameters("@Curr_ID").Value = objMandiriVA.Curr_ID
            dbCommand.Parameters("@UID").Value = objAccountUser.uid

            Dim ResultMAndiriVA As New Entities.MandiriVA

            Try
                ds = db.ExecuteDataSet(dbCommand)

                ResultMAndiriVA.ErrorCode = dbCommand.Parameters("@ErrorCode").Value.ToString.Trim
                ResultMAndiriVA.ErrorDescription = dbCommand.Parameters("@ErrorDescription").Value.ToString.Trim
                ResultMAndiriVA.VANumber = dbCommand.Parameters("@VANumber").Value.ToString.Trim

            Catch ex As Exception

                ResultMAndiriVA.ErrorCode = "99971"
                ResultMAndiriVA.ErrorDescription = ex.Message
                ResultMAndiriVA.VANumber = String.Empty

            End Try

            Return ResultMAndiriVA
        End Function



    End Class
End Namespace
