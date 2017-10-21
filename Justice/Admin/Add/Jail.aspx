<%@ Page Title="Cəzaçəkmə müəssisəsi əlavə et" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Jail.aspx.cs" Inherits="Justice.Admin.Add.Jail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">

            <div class="col-md-12">
                <div class="grid simple">
                    <div class="grid-title no-border">
                        <h4><span class="semi-bold">Cəzaçəkmə müəssisəsiləri əlavə edirsiniz</span><br />
                            <span style="font-size: 13px; color: #0aa699;"></span></h4>
                        <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                    </div>
                    <div class="grid-body no-border">
                        <br>
                    <div class="form-group">
                        <label class="form-label">Cəzaçəkmə müəssisəsi adı</label>
                        <div class="input-with-icon  right">
                            <i class=""></i>
                            <asp:TextBox ID="txtJail" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                    </div>
                            <div class="form-actions">
                                <div class="pull-right">
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success btn-cons" Visible="false" OnClick="btnSave_Click" Text="Əlavə Et"></asp:Button>
                                    <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-warning btn-cons" Visible="false" OnClick="btnSave_Click" Text="Yenilə"></asp:Button>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
