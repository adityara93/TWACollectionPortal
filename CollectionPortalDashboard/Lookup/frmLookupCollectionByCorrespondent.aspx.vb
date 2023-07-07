Imports CollectionPortalDAL.Entities
Imports CollectionPortalDAL.DataAccess
Imports CollectionPortalDAL

Public Class frmLookupCollectionByCorrespondent
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objmCollection As New Entities.mCollection
        objmCollection = Session("objmCollection")

        gvData.DataSource = AccountAccess.GetDataInsByParam(objmCollection).Tables(0)
        gvData.DataBind()

        gvData.UseAccessibleHeader = True
        gvData.HeaderRow.TableSection = TableRowSection.TableHeader

        If gvData.TopPagerRow IsNot Nothing Then
            gvData.TopPagerRow.TableSection = TableRowSection.TableHeader
        End If

        If gvData.BottomPagerRow IsNot Nothing Then
            gvData.BottomPagerRow.TableSection = TableRowSection.TableFooter
        End If

        

    End Sub

    'Private Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click

    '    Dim objmUser As New mUser
    '    Dim ID As String = Session("User").user_id
    '    objmUser.ClientID = txtClient.Text.Trim
    '    objmUser.CorrName = txtName.Text.Trim

    '    gvData.DataSource = AccountAccess.PageDataUserCorrespondentByID(ID, objmUser).Tables(0)
    '    gvData.DataBind()

    'End Sub

    Private Sub gvData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        gvData.PageIndex = e.NewPageIndex
        gvData.DataBind()
    End Sub
End Class