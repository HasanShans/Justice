<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Justice.Main.ForgotPassword" Title="Şifrəni Unutdum"%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <section id="user">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="sign_in">
                        <div class="title">
                            <h3>Şifrəmi Unutdum</h3>
                        </div><br />
                        <div class="login">
                            <div class="row">
                                 <asp:Label ID="Label1" runat="server" CssClass="col-md-8 col-md-offset-2 control-label" Text="Şifrənizi bərpa etmək üçün qeydiyyatdan keçdiyiniz email ünvanınızı daxil edin." Font-Size="Medium" Font-Bold="true" ></asp:Label>
                            </div>
                            <div class="form-group row">
                                    <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Email"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Emaili Daxil Edin" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class=" col-sm-12">
                                        <asp:Button ID="btRequestForgot" runat="server" Class="btn btn-success pull-right" Text="Göndər" OnClick="btPassRec_Click" />
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
