<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewSite.Master"
    CodeBehind="AddUserCorr.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="CollectionPortalDashboard.AddUserCorr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery/jquery.min.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.min.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/js/sweetalert.min.js") %>'></script> 
    <link type="text/css" rel="stylesheet" href='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/css/dataTables.bootstrap4.css") %>' />
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
                        <div class="col-sm-3">
                            <p class="float-left" style="font-size:18px; font-weight:lighter; margin:0px; color:#fff">Correspondent User</p>
                        </div>
                    </div>
                </div>
                <div class="card-body" id="col1">
                    <asp:HiddenField runat="server" ID="hfID" />
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
                        <asp:GridView ID="gvData" EmptyDataText="No Records Found" runat="server" AllowPaging="True"
                            PageSize="10" CssClass="table table-sm table-bordered" ShowHeaderWhenEmpty="true"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
                                    DataField="id" />
                                <asp:TemplateField HeaderText="No." ItemStyle-Width="100">
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
                                    <label for="lblAdminName">UID</label>
                                    <asp:TextBox ID="txtUID" MaxLength="5" Widt="10px" runat="server" CssClass="form-control form-control-sm" />
                                  </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="lblAdminName">Admin Name</label>
                                    <asp:TextBox ID="txtAdminName" MaxLength="100" Widt="10px" runat="server" CssClass="form-control form-control-sm" />
                                  </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label for="lblCompanyName">Company Name</label>
                                    <asp:TextBox ID="txtCompanyName" MaxLength="100" Widt="10px" runat="server" CssClass="form-control  form-control-sm" />
                                  </div>
                            </div>
                          </div>
                          <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="lblEmail">Email</label>
                                    <asp:TextBox ID="txtEmail" MaxLength="200" Widt="10px" runat="server" CssClass="form-control  form-control-sm" />
                                  </div>
                            </div>
                          </div>
                          <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="lblEmail">Correspondent</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtPageHeader" ReadOnly="true" MaxLength="30" runat="server" Text=""
                                                CssClass="form-control form-control-sm" />
                                            <div class="input-group-append primary">
                                                <asp:LinkButton ID="lnkHeader" runat="server" CssClass="btn btn-primary btn-sm"><i class="fas fa-search m-1"></i></asp:LinkButton>
                                            </div>
                                            <div class="input-group-append primary m-1">
                                                &nbsp;<asp:LinkButton runat="server" ID="lnkClear">Clear</asp:LinkButton>
                                            </div>
                                        </div>
                                </div>
                            </div>
                        </div>
                          <div class="row">
                            <div class="col-md-12">
                                     <asp:GridView ID="gvDataPage" runat="server">
                                        </asp:GridView>
                            </div>
                           
                        </div>
                          <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                            <asp:LinkButton ID="btnSubmit" autopostback="true" runat="server" CssClass="btn btn-sm btn-primary"
                                                Width="100px" Text="Add" aria-expanded="false" aria-controls="col1 col2" OnClick="btnSubmit_Click" />
                                            <asp:LinkButton ID="btnDelete" autopostback="true" runat="server" CssClass="btn btn-sm btn-danger"
                                                Width="100px" Text="Delete" aria-expanded="false" aria-controls="col1 col2" />
                                            <asp:LinkButton ID="btnClear" autopostback="true" runat="server" CssClass="btn btn-sm btn-secondary"
                                                Width="100px" Text="Back" aria-expanded="false" aria-controls="col1 col2" OnClick="btnClear_Click" />
                                </div>
                                </div>
                        </div>
                        </div>
                        <!-- /.card-body -->

                        
            


                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <%--<!-- popup client list -->
    
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/moment/moment.min.js")
    %>'></script>--%>

    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
   <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script>

    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            $('#MainContent_gvDataPage').DataTable();
        });
//        $(document).ready(function () {
//            $('#MainContent_gvDataPage').DataTable({
//                columnDefs: [{
//                    orderable: false,
//                    className: 'select-checkbox',
//                    targets: 0
//                }],
//                select: {
//                    style: 'os',
//                    selector: 'td:first-child'
//                },
//                order: [[1, 'asc']]
//            });
//        });
        

        var footer = false

        $(document).on('click', '.itemcol', function () {

            if (footer == false) {

                var ID = $(this).parent().find('td:eq(0)').text()

                $('#MainContent_hfID').val(ID)

                $('#MainContent_btnSelectGrid').click()

            }
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

        function MessageInfo(alertTitle, alertMessage) {
            swal({
                title: alertTitle,
                text: alertMessage,
                icon: "info"
            });
        }

        function MessageError(alertTitle, alertMessage) {
            swal({
                title: alertTitle,
                text: alertMessage,
                icon: "error"
            });
        }
    </script>
  
</asp:Content>
