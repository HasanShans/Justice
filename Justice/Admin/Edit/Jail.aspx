<%@ Page Title="Cəzaçəkmə müəssisəsi redaktə et" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Jail.aspx.cs" Inherits="Justice.Admin.Edit.Jail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">
            <div class="col-md-12">
                <div class="grid simple">
                    <div class="grid-title no-border">
                        <h4><span class="semi-bold">Cəzaçəkmə müəssisəsi adına deyişiklik edirsiniz</span><br />
                            <span style="font-size: 13px; color: #0aa699;"></span></h4>
                        <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                    </div>
                    <div class="grid-body no-border">
                        <br>
                        "<form action='' method='post'>
                            <div class="form-group">
                                <label class="form-label">Cəzaçəkmə müəssisəsi adı</label>
                                <div class='input-with-icon  right'>
                                    <i class=''></i>
                                    <input type='text' name='name' value='".$json->data[0]->jail_name."' id='form1Name' class='form-control'>
                                </div>
                            </div>
                            <div class="form-actions">
                                <div class="pull-right">
                                    <button type="submit" class="btn btn-danger btn-cons"><i class="icon-ok"></i>Yadda saxla</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
