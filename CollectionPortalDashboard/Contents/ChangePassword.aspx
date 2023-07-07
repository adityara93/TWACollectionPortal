<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewSite.Master"
    CodeBehind="ChangePassword.aspx.vb" Inherits="CollectionPortalDashboard.ChangePassword" %>

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
                            <p class="float-left" style="font-size:18px; font-weight:lighter; margin:0px; color:#fff">Change Password</p>
                        </div>
                        <div class="col-sm-2">
                           <span class="input-group-append  float-right">
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sm btn-flat btn-primary" Width="150px" Height="30px" Visible="false">
                                    <i class="fas fa-plus-square" style="margin-right:2px"></i> Add User
                                </asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="card-body" id="col1">
                  <div class="row">
                        <div class="col-md-4">
                            <div class="form-group"> 
                                <label for="lblAdminName" class="font-weight-normal">New Password</label>
                                <asp:TextBox ID="txtNew" MaxLength="100" Widt="10px" runat="server" CssClass="form-control form-control-sm" />
                                </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group"> 
                                <label for="lblAdminName" class="font-weight-normal">Confirm Password</label>
                                <asp:TextBox ID="txtConfirm" MaxLength="100" Widt="10px" runat="server" CssClass="form-control form-control-sm" />
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
                                        <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-secondary btn-sm btn-flat" Width="100px" Height="30px">
                                            <i class="fas fa-backward" style="margin-right:2px"></i> Back
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- popup client list -->
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery-ui/jquery-ui.min.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/moment/moment.min.js")%>' type="text/javascript"></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
   <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script>
  <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/sweetalert2/sweetalert2.min.js")%>' type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
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
                    window.location = "AddAccess.aspx";
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
