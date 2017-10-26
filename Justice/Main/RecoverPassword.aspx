<%@ Page  Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="Justice.Main.RecoverPassword" Title="Şifrə Bərbası"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section id="user">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="sign_in">
                        <div class="title">
                            <h3>Yeni Şifrə</h3>
                        </div>
                        <div class="login">
                                <div class="form-group row">
                                    <asp:Label ID="lblPass" runat="server" CssClass="col-md-2 control-label" Text="Yeni Şifrə" Visible="False"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbPass" CssClass="form-control" runat="server" placeholder="Email" TextMode="Password"  Visible="False"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server"  ErrorMessage="Şifrə Boş Qoyula Bilməz" ControlToValidate="tbPass"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <asp:Label ID="lblPassConf" runat="server" CssClass="col-md-2 control-label" Text="Yeni Şifrə Təkrar" Visible="False"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbPassConf" CssClass="form-control" runat="server" placeholder="Email" TextMode="Password" Visible="False"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Yeni Şifrə Boş Qoyula Bilməz" ControlToValidate="tbPassConf"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class=" col-sm-12">
                                        <asp:Button ID="btRequestForgot" runat="server" Class="btn btn-success pull-right" Text="Yenilə" OnClick="btPassRec_Click"  Visible="False" />
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
  <asp:Content ID="EndContent" ContentPlaceHolderID="EndContent" runat="server">
    <%: Scripts.Render("~/bundles/indexJs") %>
</asp:Content>

