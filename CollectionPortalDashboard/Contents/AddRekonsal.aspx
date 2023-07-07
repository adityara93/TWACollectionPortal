<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewSite.Master"
    CodeBehind="AddRekonsal.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="CollectionPortalDashboard.AddRekonsal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery/jquery.min.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.min.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/js/sweetalert.min.js") %>'></script> 
        <link type="text/css" rel="stylesheet" href='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/css/dataTables.bootstrap4.css") %>' />
    <link type="text/css" rel="stylesheet" href='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/daterangepicker/daterangepicker.css") %>' />
    <link type="text/css" rel="Stylesheet" href='<%=ResolveClientUrl("~/Assets/css/main.css") %>' />
    <link type="text/css" rel="Stylesheet" href='<%=ResolveClientUrl("~/Assets/css/myCSS.css") %>' />

    <%--<link type="text/css" rel="Stylesheet" href='<%=ResolveClientUrl("https://cdn.datatables.net/1.13.4/css/jquery.dataTables.min.css") %>' />--%>
    
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
    <asp:HiddenField runat="server" ID="hfCode" />
    <asp:HiddenField runat="server" ID="hfCodeIns" />
    <asp:HiddenField runat="server" ID="hfDetailId" />
        <div class="container-fluid">
            <div class="card card-info" id="headerdetail">
                <div class="card-header">
                    <div class="row">
                        <div class="col-sm-10">
                            <p class="float-left" style="font-size:18px; font-weight:lighter; margin:0px; color:#fff">Rekonsal List</p>
                        </div>
                        <div class="col-sm-2">
                            <span class="input-group-append  float-right">
                                        <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sm btn-flat btn-primary" Width="150px" Height="30px">
                                            <i class="fas fa-plus-square" style="margin-right:2px"></i> Add Collection
                                        </asp:LinkButton>
                                    </span>
                            <%--<asp:LinkButton ID="btnAdd" autopostback="true" runat="server" Text="Add Collection List" Visible="true" CssClass="btn btn-sm btn-primary" 
                            aria-expanded="false" aria-controls="col1 col2" ToolTip="Add Collection" />--%>
                        </div>
                    </div>
                </div>
                <div class="card-body" id="col1">
                    <asp:HiddenField runat="server" ID="hfID" />
                    <asp:HiddenField runat="server" ID="hfCorrID" />
                    <asp:HiddenField runat="server" ID="hfRemoveID" />
                    <asp:HiddenField runat="server" ID="hfCollNbr" />
                    <asp:HiddenField runat="server" ID="isRemove" />
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
	                                CssClass="table table-sm table-bordered mt-3" ShowHeaderWhenEmpty="true" Font-Size="Medium" HeaderStyle-Font-Size="Small" 
                                    RowStyle-Font-Size="13px" AutoGenerateColumns="False" OnRowCommand="gvDataPage_OnRowCommand">
                            <Columns>
                                <asp:BoundField ItemStyle-CssClass="hiddencol itemcol ClassHeaderID" HeaderStyle-CssClass="hiddencol"
                                    DataField="CollectionNbr" />
                               <%-- <asp:TemplateField ItemStyle-Width="50">
				                    <ItemTemplate>
					                    <span class="input-group-append">
                                            <asp:LinkButton ID="btnEditCollection" runat="server" CssClass="btn btn-warning btn-sm btn-flat" Width="50px">
                                                <i class="fas fa-edit" style="margin-right:2px"></i>
                                            </asp:LinkButton>
                                        </span>
				                    </ItemTemplate>
			                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="No." ItemStyle-Width="30">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 & "." %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CollectionStatus" ItemStyle-CssClass="itemcol" ItemStyle-HorizontalAlign="Center"  HeaderText="Status" />
                                <asp:BoundField DataField="CollectionNbr" ItemStyle-CssClass="itemcol" HeaderText="Collection Nbr" />
                                <asp:BoundField DataField="corr_name" ItemStyle-CssClass="itemcol" HeaderText="Correspondent" />
                                <asp:BoundField DataField="DueDate" ItemStyle-CssClass="itemcol" HeaderText="Due Date" />
                                <asp:BoundField DataField="UmurPiutang" ItemStyle-CssClass="itemcol" HeaderText="Umur Piutang" />
                                <asp:BoundField DataField="totalamount" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"  HeaderText="Total Amount" />
                                <asp:BoundField DataField="CollectionListUID" ItemStyle-CssClass="itemcol" HeaderText="Create UID" />
                                <asp:BoundField DataField="CollectionListDate" ItemStyle-CssClass="itemcol" HeaderText="Create Date" />
                            </Columns>
                            <PagerStyle CssClass="footerCss" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlSubmit" Visible="false">
                        <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="font-weight-normal">Collection Number</label>
                                        <asp:TextBox ID="txtColNumber" MaxLength="50" runat="server" Text="" CssClass="form-control form-control-sm" Enabled="false" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                          <label for="exampleInputEmail1" class="font-weight-normal">Correspondent</label>
                                          <div class="input-group input-group-sm">
                                              <span class="input-group-prepend">
                                                    <asp:LinkButton ID="lnkLookupCorr" runat="server" CssClass="btn btn-info btn-sm btn-flat">
                                                        <i class="fas fa-search" style="margin-right:2px"></i> Search
                                                    </asp:LinkButton>
                                                </span>
                                              <asp:TextBox ID="lblNameCorr" ReadOnly="true" MaxLength="30" runat="server" CssClass="form-control form-control-sm" Font-Size="11px" />
                                            </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group" runat="server">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1" class="font-weight-normal">UID Collector</label>
                                             <asp:TextBox ID="txtUIDCollector" MaxLength="50" runat="server" Text="N/A" CssClass="form-control form-control-sm" Enabled="false" />
                                        </div>
                                    </div>
                                </div>
                        </div>
                        <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="font-weight-normal">As At / Due Date</label>
                                        <div class="input-group input-group-sm">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtDueDate" name="txtDueDate" runat="server" Placeholder="Date To"
                                                CssClass="form-control form-control-sm float-right"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group" runat="server">
                                        <label for="exampleInputEmail1" class="font-weight-normal">Umur Piutang</label>
                                        <asp:DropDownList runat="server" ID="ddlUmurPiutang" class="form-control form-control-sm"></asp:DropDownList>
                                    </div>
                                </div>
                                <div id="dvColStatus" class="col-md-2" runat="server">
                                    <div class="form-group" runat="server">
                                        <label for="exampleInputEmail1" class="font-weight-normal">Collection Status</label>
                                        <asp:DropDownList runat="server" ID="ddlStatus" class="form-control form-control-sm"></asp:DropDownList>
                                    </div>
                                </div>
                                <div id="dvVANumber" class="col-md-2" runat="server">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="font-weight-normal">VA - Collection</label>
                                        <asp:TextBox ID="txtVANumber" MaxLength="50" runat="server" Text="" CssClass="form-control form-control-sm" Enabled="false" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1" class="font-weight-normal">Total Amount IDR</label>
                                        <asp:TextBox ID="txtTotalAmountIDR" MaxLength="50" runat="server" Text="" CssClass="form-control form-control-sm"  Enabled="false" />
                                    </div>
                                </div>
                        </div>
                        <div class="row" style="margin-top:10px; margin-bottom:10px"></div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="btn-group" runat="server">
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-info btn-sm btn-flat mr-2" Width="150px" Height="30px">
                                            <i class="fas fa-plus-square" style="margin-right:2px"></i> Submit Collection
                                        </asp:LinkButton>
                                    </span>
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-info btn-sm btn-flat mr-2" Width="150px" Height="30px" Visible="false">
                                            <i class="fas fa-plus-square" style="margin-right:2px"></i> Update Rekonsal
                                        </asp:LinkButton>
                                    </span>
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnBackCancel" runat="server" CssClass="btn btn-secondary btn-sm btn-flat mr-2" Width="100px" Height="30px">
                                            <i class="fas fa-backward" style="margin-right:2px"></i> Back
                                        </asp:LinkButton>
                                    </span>
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnAccept" runat="server" CssClass="btn btn-success btn-sm btn-flat mr-2" Width="100px" Height="30px">
                                            <i class="fas fa-check" style="margin-right:2px"></i> Accept
                                        </asp:LinkButton>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row" style="margin-top:10px; margin-bottom:10px"></div>
                        <div class="row">
                                <div class="col-md-8">
                                </div>
                                <div class="col-md-4">
                                    <div class="btn-group float-right" runat="server">
                                        <span class="input-group-append">
                                            <asp:LinkButton ID="btnSearchColl" runat="server" CssClass="btn btn-warning btn-sm btn-flat mr-2" Width="100px" Height="30px">
                                                <i class="fas fa-search" style="margin-right:2px"></i> Search
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-append">
                                            <asp:LinkButton ID="btnRollbackColl" runat="server" CssClass="btn btn-secondary btn-sm btn-flat" Width="100px" Height="30px">
                                                <i class="fas fa-recycle" style="margin-right:2px"></i> Rollback
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
			                                DataField="codeId" />
                                        <asp:BoundField ItemStyle-CssClass="hiddencol itemcol" HeaderStyle-CssClass="hiddencol"
			                                DataField="codeDocNbrId" />
		                                <asp:TemplateField ItemStyle-Width="50">
				                                <ItemTemplate>
					                                <span class="input-group-append">
                                                        <asp:LinkButton ID="btnRemoveColl" runat="server" CssClass="btn btn-danger btn-sm btn-flat btnRemoveCls" CommandName="RemoveColl" Width="50px">
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
		                                <asp:BoundField DataField="correspondent_id" HeaderText="Corr ID" />
		                                <asp:BoundField DataField="printed_name" HeaderText="Name" />
                                        <asp:BoundField DataField="policy_nbr" HeaderText="Pol Nbr" />
		                                <asp:BoundField DataField="document_nbr" HeaderText="Doc Nbr" />
		                                <asp:BoundField DataField="due_date" HeaderText="Due Date" />
		                                <asp:BoundField DataField="currency_id" HeaderText="Curr" />
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="jmlTagihan" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"  HeaderText="Amount" />
		                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="totalTagihan" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right"  HeaderText="Amount IDR" />
	                                </Columns>
	                                <PagerStyle CssClass="footerCss" />
                                </asp:GridView>
                                </asp:Panel>
                            </div>   
                        </div>
                    </asp:Panel>

                </div>
            </div>
        </div>
    </div>

    <asp:LinkButton ID="lnkCorrIDALT" Style="display: none;" CssClass="btn btn-primary btn-sm"
        runat="server"><i class="fas fa-search"></i></asp:LinkButton>
    <cc1:ModalPopupExtender ID="mpLookupCorrID" runat="server" PopupControlID="pnlPopupCorrID"
        TargetControlID="lnkCorrIDALT" CancelControlID="btnCloseHeaderID"
        BackgroundCssClass="ModalPopupBG">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopupCorrID" runat="server" Style="display: none;">
        <iframe id="IframeCorrID" frameborder="0" height="500px" width="700px" runat="server">
        </iframe>
        <asp:HiddenField runat="server" ID="hfHeaderID" />
        <asp:Button ID="btnCloseHeaderID" runat="server" Style="display: none;" />
        <asp:Button ID="btnSelectHeaderID" runat="server" Style="display: none;" />
    </asp:Panel>



    <asp:LinkButton ID="lnkAddInsCorr" Style="display: none;" CssClass="btn btn-primary btn-sm"
        runat="server"><i class="fas fa-search"></i></asp:LinkButton>
    <cc1:ModalPopupExtender ID="mLookupInsCorr" runat="server" PopupControlID="pnlPopupInsCorr"
        TargetControlID="lnkAddInsCorr" BehaviorID="mp6" CancelControlID="btnCloseHeaderID"
        BackgroundCssClass="ModalPopupBG">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopupInsCorr" runat="server" Style="display: none;">
        <iframe id="IframeInsCorrID" frameborder="0" height="500px" width="700px" runat="server">
        </iframe>
        <asp:HiddenField runat="server" ID="hfInsuredID" />
        <asp:Button ID="btnCloseInsID" runat="server" Style="display: none;" />
        <asp:Button ID="btnSelectInsID" runat="server" Style="display: none;" />
    </asp:Panel>


   <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/jquery-ui/jquery-ui.min.js")%>' type="text/javascript"></script>
   <script src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/moment/moment.min.js")%>' type="text/javascript"></script>
   <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables/jquery.dataTables.js") %>'></script>
   <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script>
   <script type="text/javascript" src='<%=ResolveClientUrl("~/Assets/admin-lte/plugins/daterangepicker/daterangepicker.js")%>'></script>
   <script>
       $(function () {
           $('#MainContent_txtDueDate').daterangepicker({
               singleDatePicker: true,
               locale: {
                   format: 'DD MMM YYYY'
               }
           })
       });
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#MainContent_gvData').DataTable({
                responsive: true,
                order: [[1, 'asc']]
            });

        });

        var footer = false
        $(document).on('click', '.itemcol', function () {

            if (footer == false) {
                var ID = $(this).parent().find('td:eq(0)').text()
                $('#MainContent_hfCode').val(ID)

                $('#MainContent_btnSelectGrid').click()
            }
        });

        $(document).on('click', '.btnRemoveCls', function () {
            var checkedValues = $(this).parent().parent().parent().find('td:eq(0)').text().trim()
            alert(checkedValues)
            $('#MainContent_hfRemoveID').val(checkedValues)
        });


      
        function LoadBG() {
            var rowscount = $("#<%=gvData.ClientID %> tr").length;
            for (var i = 0; i < rowscount - 1; i++) {
                
                if ($("#<%=gvData.ClientID %>").find('tr:eq(' + i + ')').find('.ClassHeaderID').text() == "0") {                
                    $("#<%=gvData.ClientID %>").find('tr:eq(' + i + ')').attr('style', 'background:#80808045;')
                }
            }
        }

        $(document).on('mouseenter', '.itemcol', function () {
            footer = false;
        });

        $(document).on('mouseenter', '.footerCss', function () {
            footer = true;
        });

        $(document).on('mouseleave', '.footerCss', function () {
            footer = false;
        });

        function removeRow(button) {
            var row = button.parentNode.parentNode; // Get the parent row element
            row.parentNode.removeChild(row); // Remove the row from the GridView
        }


        function MessageSuccess(alertTitle, alertMessage) {
            Swal.fire({
                icon: 'success',
                title: alertTitle,
                text: alertMessage,
                confirmButtonText: 'Ok',
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location = "AddForm.aspx";
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
