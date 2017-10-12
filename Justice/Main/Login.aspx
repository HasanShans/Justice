<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Login.aspx.cs" Inherits="Justice.Main.Login" %>

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
                            <form runat="server">
                                <div class="form-group row">
                                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Email"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Emaili Daxil Edin" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Şifrə"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" placeholder="Şifrə" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Şifrəni Daxil Edin" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
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
                                            <asp:HyperLink runat="server" ID="lbForgotPass" NavigateUrl="~/Main/ForgotPassword.aspx">Şifrəmi Unutdum</asp:HyperLink>
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
                                        <asp:Button ID="btLogin" runat="server" Class="btn btn-success pull-right" Text="Daxil Ol" />
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
