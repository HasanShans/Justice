<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Prisoner.aspx.cs" Inherits="Justice.Staff.Add.Prisoner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Yeni Məhbus</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="form-label">Adı *</label>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPrisonerName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="Ad Boş Qoyula Bilməz" ControlToValidate="txtPrisonerName"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Soyadı *</label>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPrisonerSurname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Soyad Boş Qoyula Bilməz" ControlToValidate="txtPrisonerSurname"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Məhbus Haqqında Əlavə Məlumat</label>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPrisonerInfo" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
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
    </section>
</asp:Content>
