<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewSite.Master"
    CodeBehind="AddUser.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="CollectionPortalDashboard.AddUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery/jquery.min.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.min.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/js/sweetalert.min.js") %>'></script> 
    <link type="text/css" rel="stylesheet" href='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/css/dataTables.bootstrap4.css") %>' />
    <link rel="stylesheet" href='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css") %>' />
    <link type="text/css" rel="Stylesheet" href='<%=ResolveClientUrl("~/Assets/css/main.css") %>' />
    <link type="text/css" rel="Stylesheet" href='<%=ResolveClientUrl("~/Assets/css/myCSS.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Header (Page header) -->
    <div class="content-header">
        <div class="container-fluid">
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->
    <!-- Main content -->
    <div class="content">
        <div class="container-fluid">
            <div class="card card-info" id="headerdetail">
                <div class="card-header">
                    <div class="row">
                        <div class="col-sm-10">
                            <p class="float-left" style="font-size:18px; font-weight:lighter; margin:0px; color:#fff">User</p>
                        </div>
                        <div class="col-sm-2">
                           <span class="input-group-append  float-right">
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sm btn-flat btn-primary" Width="150px" Height="30px">
                                    <i class="fas fa-plus-square" style="margin-right:2px"></i> Add User
                                </asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="card-body" id="col1">
                    <asp:HiddenField runat="server" ID="hfID" />
                    <asp:HiddenField runat="server" ID="hfRemoveID" />
                    <asp:Button runat="server" ID="btnSelectGrid" Style="display: none;" />
                    <div runat="server" visible="false" id="rowWarning" style="background: #80808036;
                        border: #8989894f; border-width: 2px; border-style: groove; margin-bottom: 10px;
                        text-align: center; align-items: center;">
                        <div class="col-sm-6 text-left form-group">
                            <asp:Label runat="server" ID="lblWarning" ForeColor="red" Text="Cannot save data."></asp:Label>
                        </div>
                        <div class="col-sm-4 text-right form-group">
                        </div>
                        <div class="col-sm-2 text-right form-group">
                            <asp:Button runat="server" ID="btnCloseMsg" CssClass="btn btn-secondary btn-sm col-sm-12"
                                Text="Close" />
                        </div>
                    </div>
                    <asp:Panel runat="server" ID="PnlData" Visible="true">
                        <asp:GridView ID="gvData" EmptyDataText="No Records Found" runat="server" AllowPaging="false"
	                                CssClass="table table-sm table-bordered mt-3" 
                                    HeaderStyle-Font-Bold="false" HeaderStyle-Wrap="false"
                                    HeaderStyle-Font-Size="Smaller" RowStyle-Wrap="false"
                                    Width="100%" ShowHeaderWhenEmpty="true" Font-Size="Medium" 
                                    RowStyle-Font-Size="13px" AutoGenerateColumns="False" OnRowCommand="gvData_OnRowCommand">
                            <Columns>
                                <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
                                    DataField="id" />
                                <asp:TemplateField ItemStyle-Width="50">
				                    <ItemTemplate>
					                    <span class="input-group-append">
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm btn-flat btnRemoveCls" CommandName="RemoveColl" Width="50px">
                                                <i class="fas fa-trash" style="margin-right:2px"></i>
                                            </asp:LinkButton>
                                        </span>
				                    </ItemTemplate>
			                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="No." ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="uid" ItemStyle-CssClass="itemcol" HeaderText="UID" />
                                <asp:BoundField DataField="admin_name" ItemStyle-CssClass="itemcol" HeaderText="Admin Name" />
                                <asp:BoundField DataField="company_name" ItemStyle-CssClass="itemcol" HeaderText="Company Name" />
                                <asp:BoundField DataField="email" ItemStyle-CssClass="itemcol" HeaderText="Email" />
                                <asp:BoundField DataField="utype_des" ItemStyle-CssClass="itemcol" HeaderText="User Type" />
                                <asp:BoundField DataField="uaccess_des" ItemStyle-CssClass="itemcol" HeaderText="User Access" />
                                <asp:BoundField DataField="exp_date" ItemStyle-CssClass="itemcol" HeaderText="Exp. Date" />
                            </Columns>
                            <PagerStyle CssClass="footerCss" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlSubmit" Visible="false">
                        <div class="card-body">
                          <div class="row">
                            <div class="col-md-3">
                                <div class="form-group"> 
                                    <label for="lblAdminName" class="font-weight-normal">UID</label>
                                    <asp:TextBox ID="txtUID" MaxLength="3" Widt="10px" runat="server" CssClass="form-control form-control-sm" />
                                  </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="lblAdminName" class="font-weight-normal">Admin Name</label>
                                    <asp:TextBox ID="txtAdminName" MaxLength="100" Widt="10px" runat="server" CssClass="form-control form-control-sm" />
                                  </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label for="lblCompanyName" class="font-weight-normal">Company Name</label>
                                    <asp:TextBox ID="txtCompanyName" MaxLength="100" Widt="10px" runat="server" CssClass="form-control  form-control-sm" />
                                  </div>
                            </div>
                          </div>
                          <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="lblEmail" class="font-weight-normal">Email</label>
                                    <asp:TextBox ID="txtEmail" MaxLength="200" Widt="10px" runat="server" CssClass="form-control  form-control-sm" />
                                  </div>
                            </div>
                          </div>
                          
                          <div class="form-group">
                            <label for="lblAddress" class="font-weight-normal">Address</label>
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtAddess" TextMode="MultiLine" MaxLength="200" Widt="10px" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                          </div>
                          <div class="form-group">
                            <label for="lblPhone" class="font-weight-normal">Phone Number</label>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPhone" MaxLength="200" Widt="10px" runat="server" CssClass="form-control form-control-sm" />
                                </div>
                            </div>
                          </div>
                          <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="lblAdminName" class="font-weight-normal">User Type</label>
                                        <asp:DropDownList runat="server" ID="ddlUserType" class="form-control form-control-sm">
                                        </asp:DropDownList>
                                  </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="lblCompanyName" class="font-weight-normal">User Access</label>
                                        <asp:DropDownList runat="server" ID="ddlUserAccess" class="form-control form-control-sm">
                                        </asp:DropDownList>
                                  </div>
                            </div>
                          </div>
                          <div class="row">
                                <div class="col-md-12">
                                    <div class="btn-group float-left" runat="server">
                                        <span class="input-group-append">
                                            <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-info btn-sm btn-flat mr-2" Width="100px" Height="30px">
                                                <i class="fas fa-plus-square" style="margin-right:2px"></i> Submit
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-append">
                                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-info btn-sm btn-flat mr-2" Width="100px" Height="30px">
                                                <i class="fas fa-plus-square" style="margin-right:2px"></i> Update
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-append">
                                            <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-secondary btn-sm btn-flat" Width="100px" Height="30px">
                                                <i class="fas fa-backward" style="margin-right:2px"></i> Back
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                           </div>
                        </div>
                        <!-- /.card-body -->
                        <div id="dvAddCorr" runat="server">
                            <hr />
                            <div class="row" style="margin-top:10px; margin-bottom:10px"></div>
                            <div class="row">
                               <div class="col-md-8">
                                    </div>
                                    <div class="col-md-4">
                                        <div class="btn-group float-right" runat="server">
                                            <span class="input-group-append">
                                                <asp:LinkButton ID="lnkLookupCorr" runat="server" CssClass="btn btn-warning btn-sm btn-flat mr-2" Width="200px" Height="30px">
                                                    <i class="fas fa-search" style="margin-right:2px"></i> Add Correspondent
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Panel runat="server" ID="pnlGridData" Visible="true">
                                        <asp:GridView ID="gvDataPage" EmptyDataText="No Records Found" runat="server" AllowPaging="false"
	                                    CssClass="table table-sm table-bordered mt-3" ShowHeaderWhenEmpty="true" Font-Size="Medium" HeaderStyle-Font-Size="Small" 
                                        RowStyle-Font-Size="12px" AutoGenerateColumns="False" OnRowCommand="gvDataPage_OnRowCommand">
	                                    <Columns>
		                                    <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
			                                    DataField="client_id" />
		                                    <asp:TemplateField ItemStyle-Width="50">
				                                    <ItemTemplate>
					                                    <span class="input-group-append">
                                                            <asp:LinkButton ID="btnRemoveColl2" runat="server" CssClass="btn btn-danger btn-sm btn-flat btnRemoveCls2" CommandName="RemoveColl2" Width="50px">
                                                                <i class="fas fa-trash" style="margin-right:2px"></i>
                                                            </asp:LinkButton>
                                                        </span>
				                                    </ItemTemplate>
			                                    </asp:TemplateField>
		                                    <asp:TemplateField HeaderText="No." ItemStyle-Width="20px">
			                                    <ItemTemplate>
				                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
			                                    </ItemTemplate>
		                                    </asp:TemplateField>
		                                    <asp:BoundField DataField="client_id" HeaderText="Corr ID" />
		                                    <asp:BoundField DataField="name" HeaderText="Name" />
                                            <asp:BoundField DataField="client_status" HeaderText="Status" />
		                                    <asp:BoundField DataField="biz_code" HeaderText="Biz Code" />
	                                    </Columns>
	                                    <PagerStyle CssClass="footerCss" />
                                    </asp:GridView>
                                    </asp:Panel>
                                </div>   
                            </div>
                        
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <!-- popup client list -->
    <asp:LinkButton ID="lnkCorrIDALT" Style="display: none;" CssClass="btn btn-primary btn-sm"
        runat="server"><i class="fas fa-search"></i></asp:LinkButton>
    <cc1:ModalPopupExtender ID="mpLookupCorrID" runat="server" PopupControlID="pnlPopupCorrID"
        TargetControlID="lnkCorrIDALT" BehaviorID="mp4" CancelControlID="btnCloseHeaderID"
        BackgroundCssClass="ModalPopupBG">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopupCorrID" runat="server" Style="display: none;">
        <iframe id="IframeCorrID" frameborder="0" height="500px" width="700px" runat="server">
        </iframe>
        <asp:HiddenField runat="server" ID="hfHeaderID" />
        <asp:Button ID="btnCloseHeaderID" runat="server" Style="display: none;" />
        <asp:Button ID="btnSelectHeaderID" runat="server" Style="display: none;" />
    </asp:Panel>

    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery-ui/jquery-ui.min.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
   <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script>
  <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/sweetalert2/sweetalert2.min.js")%>' type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            $('#MainContent_gvData').DataTable({
                responsive: true,
                order: [[1, 'asc']],
                scrollX: true,
            });
        });

        var footer = false

        $(document).on('click', '.itemcol', function () {

            if (footer == false) {

                var ID = $(this).parent().find('td:eq(0)').text()

                $('#MainContent_hfID').val(ID)

                $('#MainContent_btnSelectGrid').click()

            }
        });

        $(document).on('click', '.btnRemoveCls', function () {
            var checkedID = $(this).parent().parent().parent().find('td:eq(0)').text().trim()
            var checkedValues = $(this).parent().parent().parent().find('td:eq(6)').text().trim()
            
            $('#MainContent_hfID').val(checkedID)
            $('#MainContent_hfRemoveID').val(checkedValues)
        });

        $(document).on('click', '.btnRemoveCls2', function () {
            var checkedID = $(this).parent().parent().parent().find('td:eq(0)').text().trim()
            alert(checkedID)
            $('#MainContent_hfRemoveID').val(checkedID)
        });


        $(document).on('mouseenter', '.itemcol', function () {
            footer = false;
        });

        $(document).on('mouseenter', '.footerCss', function () {
            footer = true;
        });

        $(document).on('mouseleave', '.footerCss', function () {
            footer = false;
        });

        function callSubmitButton() {
            document.getElementById('<%=btnSubmit.ClientID%>').click();
        }

        function MessageSuccess(alertTitle, alertMessage) {
            Swal.fire({
                icon: 'success',
                title: alertTitle,
                text: alertMessage,
                confirmButtonText: 'Ok',
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location = "AddUser.aspx";
                }
            })
        }

        function MessageInfo(alertTitle, alertMessage) {
            Swal.fire({
                icon: 'info',
                title: alertTitle,
                text: alertMessage
            })
        }

        function MessageError(alertTitle, alertMessage) {
            Swal.fire({
                icon: 'error',
                title: alertTitle,
                text: alertMessage
            })
        }
    </script>
  
</asp:Content>
