Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Imports CollectionPortalDAL.Helper.ClassGlobal

Namespace DataAccess
    Public Class AccountAccess

        Public Shared Function PageAccess(ByVal email As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserAccess")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Value = email

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

        Public Shared Function PageAccessDetail(ByVal email As String, ByVal headerId As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserAccessDetail")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Value = email
            dbcommand.Parameters(2).Value = headerId

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


        Public Shared Function PageData() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserManagementPage")

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

        Public Shared Function PageDataCollectionListTamp(ByVal clientId As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetCollectionListTamp")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Value = clientId
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

        Public Shared Function PageDataByID(ByVal ID As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserManagementPageDataByID")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@ID").Value = ID

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

        Public Shared Function PageDataHeader() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetPageDataHeader")

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

        Public Shared Function PageDataUserCorrespondent(ByVal uid As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpClient")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@uid").Value = uid
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

        Public Shared Function PageDataInsertUserCorrespondent(ByVal uid As String, ByVal client_id As String) As Entities.mUser
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procInsertClientByParam")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output
            dbcommand.Parameters("@userid").Direction = ParameterDirection.Output

            dbcommand.Parameters("@uid").Value = uid
            dbcommand.Parameters("@client_id").Value = client_id

            Dim Result As New Entities.mUser

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim
                Result.user_id = dbcommand.Parameters("@userid").Value.ToString.Trim

            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString

            End Try

            Return Result
        End Function

        Public Shared Function PageDataDeleteUserCorrespondent(ByVal uid As String, ByVal client_id As String) As Entities.mUser
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procDeleteClientByParam")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output
            dbcommand.Parameters("@userid").Direction = ParameterDirection.Output

            dbcommand.Parameters("@uid").Value = uid
            dbcommand.Parameters("@client_id").Value = client_id

            Dim Result As New Entities.mUser

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim
                Result.user_id = dbcommand.Parameters("@userid").Value.ToString.Trim

            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString

            End Try

            Return Result
        End Function

        Public Shared Function PageDataUserCorrespondentByParam(ByVal client_id As String, ByVal client_name As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpClientByParam")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@client_id").Value = client_id
            dbcommand.Parameters("@client_name").Value = client_name
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

        Public Shared Function PageDataUserCorrespondentByParamKey(ByVal codeIns As String, ByVal objmCollection As Entities.mCollection) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetCollectionListRow")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@clientid").Value = objmCollection.correspondentID
            dbcommand.Parameters("@duedate").Value = objmCollection.dueDate
            dbcommand.Parameters("@umurpiutang").Value = objmCollection.uPiutang

            dbcommand.Parameters("@codeId").Value = codeIns

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

        Public Shared Function PageDataUserCorrespondentByID(ByVal uid As String, ByVal params As Entities.mUser) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpClientByID")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@uid").Value = uid
            dbcommand.Parameters("@clientID").Value = params.ClientID

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

        Public Shared Function PageDataHeaderByID(ByVal objmPage As Entities.mPage) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("proc_GetPageDataHeaderByID")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@pageURL").Value = objmPage.PageURL
            dbcommand.Parameters("@pageControlID").Value = objmPage.PageControlID

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



        Public Shared Function GetMasterAccess() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserManagementAccess")

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

        Public Shared Function GetMasterAccessByParam(ByVal refCode As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserManagementAccessByParam")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@refCode").Value = refCode

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


        Public Shared Function UserAccessData() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserManagementUser")

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

        Public Shared Function UserAccessDataByID(ByVal UID As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserManagementUserDataByID")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@UID").Value = UID

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


        Public Shared Function InsertUpdateDeleteUserAccess(ByVal params As Entities.mUser, Optional isDelete As Boolean = False) As Entities.mUser
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procUserManagementCRUDUser")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output

            dbcommand.Parameters("@isDelete").Value = isDelete
            dbcommand.Parameters("@uid").Value = params.UID
            dbcommand.Parameters("@adminname").Value = params.AdminName
            dbcommand.Parameters("@companyname").Value = params.CompanyName
            dbcommand.Parameters("@address").Value = params.Address
            dbcommand.Parameters("@phone").Value = params.Phone
            dbcommand.Parameters("@utype").Value = params.UType
            dbcommand.Parameters("@uaccess").Value = params.UAccess
            dbcommand.Parameters("@email").Value = params.Email
            dbcommand.Parameters("@UserUID").Value = params.AuthUID
            dbcommand.Parameters("@password").Value = EncodePasswordToBase64(params.Password)


            Dim Result As New Entities.mUser

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim

            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString

            End Try

            Return Result
        End Function

        Public Shared Function InsertUpdateDeleteUserCollection(ByVal params As Entities.mCollection, Optional isDelete As Boolean = False) As Entities.mCollection
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procCollectionCRUDList")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output
            dbcommand.Parameters("@collectionNbrFnl").Direction = ParameterDirection.Output

            dbcommand.Parameters("@isDelete").Value = isDelete
            dbcommand.Parameters("@uid").Value = params.UID
            dbcommand.Parameters("@collectionNbr").Value = params.collectionNbr
            dbcommand.Parameters("@corr_id").Value = params.correspondentID
            dbcommand.Parameters("@date").Value = params.dueDate
            dbcommand.Parameters("@prod_trx").Value = "XXXX"
            dbcommand.Parameters("@upiutang").Value = params.uPiutang
            dbcommand.Parameters("@totalamount").Value = params.totalAmount
            dbcommand.Parameters("@collectionStatus").Value = params.colStatus

            Dim Result As New Entities.mCollection

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim
                Result.collectionNbr = dbcommand.Parameters("@collectionNbrFnl").Value.ToString.Trim

            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString
                Result.collectionNbr = dbcommand.Parameters("@collectionNbrFnl").Value.ToString.Trim

            End Try

            Return Result
        End Function

        Public Shared Function InsertUpdateDeleteUserCollectionDetail(ByVal params As Entities.mCollection, Optional isDelete As Boolean = False) As Entities.mCollection
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procCollectionCRUDListDetail")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output

            dbcommand.Parameters("@isDelete").Value = isDelete
            dbcommand.Parameters("@collectionNbr").Value = params.collectionNbr
            dbcommand.Parameters("@codeId").Value = params.lCodeId
            dbcommand.Parameters("@codeDocNbrId").Value = params.docNbr

            Dim Result As New Entities.mCollection

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim

            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString

            End Try

            Return Result
        End Function

        Public Shared Function AcceptCollection(ByVal ColNbr As String, ByVal params As Entities.mUser) As Entities.mUser
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procCollectionAccept")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output

            dbcommand.Parameters("@uid").Value = params.uid
            dbcommand.Parameters("@collectionNbr").Value = ColNbr
            dbcommand.Parameters("@uaccess").Value = params.UAccess

            Dim Result As New Entities.mUser

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim

            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString

            End Try

            Return Result
        End Function

        Public Shared Function AcceptRekonsal(ByVal ColNbr As String, ByVal params As Entities.mUser) As Entities.mUser
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procRekonsalAccept")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output

            dbcommand.Parameters("@uid").Value = params.UID
            dbcommand.Parameters("@collectionNbr").Value = ColNbr
            dbcommand.Parameters("@uaccess").Value = params.UAccess

            Dim Result As New Entities.mUser

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim

            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString

            End Try

            Return Result
        End Function

        Public Shared Function InsertUpdateDeletePage(ByVal params As Entities.mPage, Optional isDelete As Boolean = False) As Entities.mPage
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procUserManagementCRUDPage")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ResultID").Direction = ParameterDirection.Output
            dbcommand.Parameters("@isDelete").Value = isDelete
            dbcommand.Parameters("@ID").Value = params.ID
            dbcommand.Parameters("@PageURL").Value = params.PageURL
            dbcommand.Parameters("@PageControlID").Value = params.PageControlID
            dbcommand.Parameters("@HeaderID").Value = params.HeaderID
            dbcommand.Parameters("@PageDescription").Value = params.PageDescription

            Dim Result As New Entities.mPage

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim
                Result.ID = dbcommand.Parameters("@ResultID").Value.ToString.Trim
            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString
                Result.ID = 0
            End Try

            Return Result
        End Function

        Public Shared Function InsertUpdateDeleteAccess(ByVal params As Entities.mAccess, ByVal UID As String, Optional isDelete As Boolean = False) As Entities.mAccess
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procUserManagementCRUDAccess")

            db.DiscoverParameters(dbcommand)

            dbcommand.Parameters("@ErrorCode").Direction = ParameterDirection.Output
            dbcommand.Parameters("@ErrorDescription").Direction = ParameterDirection.Output
            dbcommand.Parameters("@isDelete").Value = isDelete
            dbcommand.Parameters("@refCode").Value = params.refCode
            dbcommand.Parameters("@listPageArray").Value = params.listPageArray
            dbcommand.Parameters("@Description").Value = params.Description

            Dim Result As New Entities.mAccess

            Try
                db.ExecuteNonQuery(dbcommand)

                Result.ErrorCode = dbcommand.Parameters("@ErrorCode").Value.ToString.Trim
                Result.ErrorDescription = dbcommand.Parameters("@ErrorDescription").Value.ToString.Trim
            Catch ex As Exception
                Result.ErrorCode = UNKNOWN_ERROR
                Result.ErrorDescription = ex.Message.ToString

            End Try

            Return Result
        End Function

        Public Shared Function EncodePasswordToBase64(ByVal password As String) As String
            Try
                Dim encData_byte As Byte() = New Byte(password.Length - 1) {}
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password)
                Dim encodedData As String = Convert.ToBase64String(encData_byte)
                Return encodedData
            Catch ex As Exception
                Throw New Exception("Error in base64Encode" & ex.Message)
            End Try
        End Function

        Public Shared Function DecodeFrom64(ByVal encodedData As String) As String
            Dim encoder As System.Text.UTF8Encoding = New System.Text.UTF8Encoding()
            Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()
            Dim todecode_byte As Byte() = Convert.FromBase64String(encodedData)
            Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
            Dim decoded_char As Char() = New Char(charCount - 1) {}
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
            Dim result As String = New String(decoded_char)
            Return result
        End Function

        Public Shared Function Check_IsLead(ByVal params As Entities.Account) As Entities.Account
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procCheck_IsLead")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Direction = ParameterDirection.Output
            dbcommand.Parameters(2).Direction = ParameterDirection.Output
            dbcommand.Parameters(3).Value = params.AuthUID

            Dim item As New Entities.Account
            Try
                ds = db.ExecuteDataSet(dbcommand)
                item.ErrorCode = dbcommand.Parameters(1).Value.ToString.Trim
                item.ErrorDescription = dbcommand.Parameters(2).Value.ToString.Trim
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try
            Return item
        End Function

        Public Shared Function GetUserLogin(ByVal AuthUID As String, ByVal AuthPass As String) As Entities.Account
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserLogin")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Value = AuthUID
            Dim pass = EncodePasswordToBase64(AuthPass)
            dbcommand.Parameters(2).Value = EncodePasswordToBase64(AuthPass)


            Dim item As New Entities.Account
            Try
                ds = db.ExecuteDataSet(dbcommand)

                If ds.Tables(0) Is Nothing Then
                    Throw New InvalidOperationException("You do not have permission access this application.")
                Else
                    If ds.Tables(0).Rows.Count = 0 Then
                        Throw New InvalidOperationException("You do not have permission access this application.")
                    End If
                End If
                'item = New Entities.Account(ds.Tables(0).Rows(0)("uid"), ds.Tables(0).Rows(0)("name"), _
                '                            ds.Tables(0).Rows(0)("accessid"), ds.Tables(0).Rows(0)("isadmin"))
                item = New Entities.Account(ds.Tables(0).Rows(0)("id"), ds.Tables(0).Rows(0)("uid"), ds.Tables(0).Rows(0)("email"), ds.Tables(0).Rows(0)("admin_name"), _
                                            ds.Tables(0).Rows(0)("company_name"), ds.Tables(0).Rows(0)("utype"), _
                                            ds.Tables(0).Rows(0)("utype_des"), ds.Tables(0).Rows(0)("uaccess"), _
                                            ds.Tables(0).Rows(0)("uaccess_des"))
                item.ErrorCode = "0"
                item.ErrorDescription = ""
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try
            Return item
        End Function

        Public Shared Function GetUserSession(ByVal AuthUID As String) As Entities.Account
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserSession")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Value = AuthUID


            Dim item As New Entities.Account
            Try
                ds = db.ExecuteDataSet(dbcommand)

                If ds.Tables(0) Is Nothing Then
                    Throw New InvalidOperationException("You do not have permission access this application.")
                Else
                    If ds.Tables(0).Rows.Count = 0 Then
                        Throw New InvalidOperationException("You do not have permission access this application.")
                    End If
                End If
                item = New Entities.Account(ds.Tables(0).Rows(0)("uid"), ds.Tables(0).Rows(0)("user_name"), _
                                            ds.Tables(0).Rows(0)("accessid"), ds.Tables(0).Rows(0)("isadmin"))
                item.ErrorCode = "0"
                item.ErrorDescription = ""
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try
            Return item
        End Function

        Public Shared Function ChangePassword(ByVal AuthUID As String, ByVal AuthPass As String) As Entities.Account
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetUserChangePwd")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@uid").Value = AuthUID
            dbcommand.Parameters("@pass").Value = EncodePasswordToBase64(AuthPass)

            Dim item As New Entities.Account

            Try
                ds = db.ExecuteDataSet(dbcommand)
                item = New Entities.Account(ds.Tables(0).Rows(0)("uid"), ds.Tables(0).Rows(0)("name"),
                                            ds.Tables(0).Rows(0)("accessid"), ds.Tables(0).Rows(0)("isadmin"))
                item.ErrorCode = "0"
                item.ErrorDescription = ""
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try

            Return item
        End Function

        Public Shared Function CheckOldPassword(ByVal AuthUID As String, ByVal AuthPass As String) As Entities.Account
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("proc_CheckPwd")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Direction = ParameterDirection.Output
            dbcommand.Parameters(2).Direction = ParameterDirection.Output
            dbcommand.Parameters(3).Value = AuthUID
            dbcommand.Parameters(4).Value = EncodePasswordToBase64(AuthPass)

            Dim item As New Entities.Account
            Try
                ds = db.ExecuteDataSet(dbcommand)
                item.ErrorCode = dbcommand.Parameters(1).Value.ToString.Trim
                item.ErrorDescription = dbcommand.Parameters(2).Value.ToString.Trim
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try
            Return item
        End Function

        Public Shared Function InsertUser(ByVal params As Entities.AccountUser) As Entities.AccountUser
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procInsertUser")

            db.DiscoverParameters(dbcommand)
            '           @logbook_id int,
            '@doc_type varchar(2),
            '@doc_nbr varchar(25),
            '@curr_id varchar(5)
            dbcommand.Parameters(1).Value = params.uid
            dbcommand.Parameters(2).Value = params.user_name
            dbcommand.Parameters(3).Value = params.pos_id
            dbcommand.Parameters(4).Value = params.email
            dbcommand.Parameters(5).Value = EncodePasswordToBase64(params.password)
            dbcommand.Parameters(6).Value = params.mod_uid
            dbcommand.Parameters(7).Value = params.mod_date
            dbcommand.Parameters(8).Direction = ParameterDirection.Output
            dbcommand.Parameters(9).Direction = ParameterDirection.Output


            Dim item As Entities.AccountUser = params
            Try
                item.SqlRowNumber = db.ExecuteNonQuery(dbcommand)
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try
            Return item
        End Function

        Public Shared Function GetEmployeeSession(ByVal AuthUID As String) As Entities.Account
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetEmployeeSession")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Value = AuthUID

            Dim item As New Entities.Account
            Try
                ds = db.ExecuteDataSet(dbcommand)

                If ds.Tables(0) Is Nothing Then
                    Throw New InvalidOperationException("You do not have permission access this application.")
                Else
                    If ds.Tables(0).Rows.Count = 0 Then
                        Throw New InvalidOperationException("You do not have permission access this application.")
                    End If
                End If
                item = New Entities.Account(ds.Tables(0).Rows(0)("uid"), ds.Tables(0).Rows(0)("user_name"), _
                                            ds.Tables(0).Rows(0)("accessid"), ds.Tables(0).Rows(0)("isadmin"))
                item.ErrorCode = "0"
                item.ErrorDescription = ""
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try
            Return item
        End Function

        Public Shared Function Insert_UserPosition(ByVal params As Entities.Account, ByVal isPermanent As Boolean) As Entities.Account
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(VirtualAccountDashboard)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procInsert_UserPosition")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters(1).Direction = ParameterDirection.Output
            dbcommand.Parameters(2).Direction = ParameterDirection.Output
            dbcommand.Parameters(3).Value = params.uid
            dbcommand.Parameters(4).Value = params.accessid
            dbcommand.Parameters(5).Value = params.from_date
            dbcommand.Parameters(6).Value = params.exp_date
            dbcommand.Parameters(7).Value = isPermanent
            dbcommand.Parameters(8).Value = params.file_path
            dbcommand.Parameters(9).Value = params.AuthUID

            Dim item As New Entities.Account
            Try
                ds = db.ExecuteDataSet(dbcommand)
                item.ErrorCode = dbcommand.Parameters(1).Value.ToString.Trim
                item.ErrorDescription = dbcommand.Parameters(2).Value.ToString.Trim
            Catch ex As Exception
                item.ErrorCode = UNKNOWN_ERROR
                item.ErrorDescription = ex.Message.ToString
            End Try
            Return item
        End Function

        Shared Function GetCorrespondent() As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procLookUpClient")

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

        Shared Function GetDataCollectionByParam(ByVal UID As String, ByVal UAccess As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetCollectionList")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@uid").Value = UID
            dbcommand.Parameters("@uaccess").Value = UAccess

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

        Shared Function GetDataCollectionRekonsalByParam(ByVal UID As String, ByVal UAccess As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetRekonsalList")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@uid").Value = UID
            dbcommand.Parameters("@uaccess").Value = UAccess

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

        Shared Function GetDataCollectionFormByParam(ByVal UID As String, ByVal UAccess As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetCollectionForm")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@uid").Value = UID
            dbcommand.Parameters("@uaccess").Value = UAccess

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

        Shared Function GetDataCollectionAllByParam(ByVal CollectionNbr As String) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetCollectionListByParam")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@CollectionNbr").Value = CollectionNbr

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

        Shared Function GetDataInsByParam(ByVal objmCollection As Entities.mCollection) As DataSet
            Dim ds As New DataSet
            Dim db As Database = DatabaseFactory.CreateDatabase(CollectionPortalDB)
            Dim dbcommand As DbCommand = db.GetStoredProcCommand("procGetCollectionListTamp")

            db.DiscoverParameters(dbcommand)
            dbcommand.Parameters("@clientid").Value = objmCollection.correspondentID
            dbcommand.Parameters("@duedate").Value = objmCollection.dueDate
            dbcommand.Parameters("@umurpiutang").Value = objmCollection.uPiutang

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

