<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Register.aspx.cs" Inherits="Justice.Main.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <section id="user">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="title">
                        <h3>Qeydiyyatdan keç</h3>
                    </div>
                    <div class="register">
                        <form runat="server">
                            <div class="form-group row">
                                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Ad"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="tbName" CssClass="form-control" runat="server" placeholder="Ad"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="Ad Boş Qoyula Bilməz" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Soyad"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="tbSurname" CssClass="form-control" runat="server" placeholder="Soyad"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Soyad Boş Qoyula Bilməz" ControlToValidate="tbSurname"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Email" TextMode="Email"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Email Boş Qoyla Bilməz" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Şifrə"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" placeholder="Şifrə" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Şifrə Boş Qoyula Bilməz" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="Şifrəni Təkrarlayın"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="tbPasswordConfirm" CssClass="form-control" runat="server" placeholder="Təkrar Şifrə" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Şifrəni Təkrarlayın" ControlToValidate="tbPasswordConfirm"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label6" runat="server" CssClass="col-md-2 control-label" Text="Doğum Tarixi"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="tbBirthdate" CssClass="form-control" runat="server" placeholder="Doğum Tarixi" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="Doğum Tarixi Boş Qoyula Bilməz" ControlToValidate="tbBirthdate"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row ">
                                <div class="col-sm-10 col-sm-offset-2">
                                    <div class="form-check">
                                        <asp:CheckBox ID="tbLicense" runat="server" />
                                        <asp:LinkButton ID="lblLicense" runat="server" PostBackUrl="~/">Müqaviləni oxudum ,anladım və təsdiqləyirəm</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row ">
                                <div class="col-sm-10 col-sm-offset-2">
                                    <div class="form-check">
                                     <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class=" col-sm-12">
                                    <asp:Button ID="btSignup" runat="server" Class="btn btn-success pull-right" Text="Qeydiyyatdan Keç"  OnClick="btSignup_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
