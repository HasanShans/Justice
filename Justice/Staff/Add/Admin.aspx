<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Justice.Staff.Add.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Yeni Admin</h3>

                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="form-label">Ləqəb *</label>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtAdmin" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="Ləqəb Boş Qoyula Bilməz" ControlToValidate="txtAdmin"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Cəzaçəkmə müəssisəsi *</label>
                            <asp:DropDownList ID="ddlJails" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ErrorMessage="Cəzaçəkmə müəssisəsini seçin" ControlToValidate="ddlJails" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group" runat="server" id="pass">
                            <label class="form-label">Şifrə *</label>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Şifrə Boş Qoyula Bilməz" ControlToValidate="tbPassword" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ControlToValidate="tbPassword" ID="RegularExpressionValidator3" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!$%@#£€*?&]{8,}$" runat="server" ErrorMessage="Şifrədə hərflər və rəqəmlər olmaqla yanaşı uzunluğu 8 simvol olmalıdır" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
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
