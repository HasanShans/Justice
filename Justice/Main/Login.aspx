<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Login.aspx.cs" Inherits="Justice.Main.Login" Title="Daxil Ol" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <section id="user">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="sign_in">
                        <div class="title">
                            <h3>Daxil ol</h3>
                        </div>
                        <div class="login">
                            <asp:Label ID="lblMsgVerify" runat="server" CssClass="col-md-12 control-label" Text="" Font-Size="Medium"></asp:Label>
                            <br />
                                <div class="form-group row">
                                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Email"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Emaili Daxil Edin" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Parol"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" placeholder="Parol" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Parolu Daxil Edin" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group row ">
                                    <div class="col-sm-10 col-sm-offset-2">
                                        <div class="form-check">
                                            <asp:CheckBox ID="tbRememberMe" runat="server" />
                                            <asp:Label ID="Label3" runat="server" Text="Yadda Saxla"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row ">
                                    <div class="col-sm-10 col-sm-offset-2">
                                        <div class="form-check">
                                            <asp:HyperLink runat="server" ID="lbForgotPass" NavigateUrl="~/Main/ForgotPassword.aspx">Parolu Unutdum</asp:HyperLink>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row ">
                                    <div class="col-sm-10 col-sm-offset-2">
                                        <div class="form-check">
                                            <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="~/Main/Register.aspx">Yeni Hesab Yarat</asp:HyperLink>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class=" col-sm-12">
                                        <asp:Button ID="btLogin" runat="server" Class="btn btn-success pull-right" Text="Daxil Ol" OnClick="btnLogin_Click"/>
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