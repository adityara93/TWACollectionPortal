<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewSite.Master"
    CodeBehind="AddAccess.aspx.vb" Inherits="CollectionPortalDashboard.Addaccess" %>

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
            <!-- Horizontal Form -->
            <div class="card card-info" id="headerdetail">
              <div class="card-header">
                <div class="row">
                    <div class="col-sm-10">
                        <p class="float-left" style="font-size:18px; font-weight:lighter; margin:0px; color:#fff">Access</p>
                    </div>
                    <div class="col-sm-2">
                       <span class="input-group-append  float-right">
                            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sm btn-flat btn-primary" Width="150px" Height="30px">
                                <i class="fas fa-plus-square" style="margin-right:2px"></i> Add Access
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                <div class="card-body" id="col1">
                  <asp:HiddenField runat="server" ID="hfCode" />
                    <asp:HiddenField runat="server" ID="hfPageID" />
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
                                    DataField="Code" />
                                <asp:TemplateField ItemStyle-Width="50">
				                    <ItemTemplate>
					                    <span class="input-group-append">
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm btn-flat btnRemoveCls" CommandName="RemoveColl" Width="50px">
                                                <i class="fas fa-trash" style="margin-right:2px"></i>
                                            </asp:LinkButton>
                                        </span>
				                    </ItemTemplate>
			                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="No." ItemStyle-Width="20">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Code" ItemStyle-CssClass="itemcol" HeaderText="Code" />
                                <asp:BoundField DataField="Description" ItemStyle-CssClass="itemcol" HeaderText="Description" />
                            </Columns>
                            <PagerStyle CssClass="footerCss" />
                        </asp:GridView>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlSubmit" Visible="false">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="font-weight-normal">Code</label>
                                     <asp:TextBox ID="txtRefCode" MaxLength="3" Style="text-transform: uppercase" runat="server" Text="" CssClass="form-control form-control-sm" />
                                </div>
                            </div>
                            <div class="col-md-9">
                                <div class="form-group">
                                    <label class="font-weight-normal">Description</label>
                                    <asp:TextBox ID="txtDescription" MaxLength="100" Style="text-transform: uppercase" runat="server" Text="" CssClass="form-control form-control-sm" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvDataPage" EmptyDataText="No Records Found" runat="server" AllowPaging="false"
	                                CssClass="table table-sm table-bordered" 
                                    HeaderStyle-Font-Bold="false" HeaderStyle-Wrap="false"
                                    HeaderStyle-Font-Size="Smaller" RowStyle-Wrap="false"
                                    Width="100%" ShowHeaderWhenEmpty="true" Font-Size="Medium" 
                                    RowStyle-Font-Size="13px" AutoGenerateColumns="False" >
                                    <Columns>
                                        <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
                                            DataField="ID" />
                                        <asp:BoundField ItemStyle-CssClass="hiddencol itemcol ClassHeaderID" HeaderStyle-CssClass="hiddencol"
                                        DataField="HeaderID" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkBox" name="chkName" CssClass="chkBoxClass" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No." ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PageURL" HeaderText="Page URL" />
                                        <asp:BoundField DataField="PageControlID" HeaderText="Page Control ID" />
                                        <asp:BoundField DataField="PageIcon" HeaderText="Page Icon" />
                                        <asp:BoundField DataField="PageDescription" HeaderText="Page Description" />
                                    </Columns>
                                    <PagerStyle CssClass="footerCss" />
                                </asp:GridView>
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
                    </asp:Panel>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
    </div>
    
    <%--<!-- popup client list -->
    
    
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/moment/moment.min.js")
    %>'></script>--%>
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery-ui/jquery-ui.min.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/moment/moment.min.js")%>' type="text/javascript"></script>
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


        $(document).on('click', '.chkBoxClass', function () {

            var checkedValues = $('input:checkbox:checked').map(function () {
                return $(this).parent().parent().parent().find('td:eq(0)').text().trim()
            }).get();

            $('#MainContent_hfPageID').val(checkedValues)

        });

        $(document).on('click', '.btnRemoveCls', function () {
            var checkedValues = $(this).parent().parent().parent().find('td:eq(0)').text().trim()
            $('#MainContent_hfRemoveID').val(checkedValues)
        });

        LoadChecklist()

        function LoadChecklist() {
            
            var chkArr = [];
            chkArr = $('#MainContent_hfPageID').val().split(",")
            var rowscount = $("#<%=gvDataPage.ClientID %> tr").length;
            //alert(rowscount)
            //alert(chkArr)
            for (var i = 0; i < rowscount; i++) {
                
                var id = $("#MainContent_gvDataPage > tbody > tr:eq(" + i + ") > td:eq(0)").text()
     
                if ($.inArray(id, chkArr) !== -1) {                  
                    $("#MainContent_gvDataPage > tbody > tr:eq(" + i + ") > td:eq(2) > .chkBoxClass > input").prop('checked', 'checked');                    
                } 

            }

        }



        //LoadBG()

        function LoadBG() {


            var rowscount = $("#<%=gvDataPage.ClientID %> tr").length;
            
            for (var i = 0; i < rowscount - 1; i++) {

                if ($("#<%=gvDataPage.ClientID %>").find('tr:eq(' + i + ')').find('.ClassHeaderID').text() == "0") {
                    $("#<%=gvDataPage.ClientID %>").find('tr:eq(' + i + ')').attr('style', 'background:#80808045;')
                }

            }

        }


        var footer = false

        $(document).on('click', '.itemcol', function () {
            if (footer == false) {

                var Code = $(this).parent().find('td:eq(0)').text()

                $('#MainContent_hfCode').val(Code)

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

        var Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 6000
        });

    </script>
   
</asp:Content>
