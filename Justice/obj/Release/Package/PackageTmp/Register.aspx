<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Register.aspx.cs" Inherits="Justice.Register" Title="Üzv Ol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <section id="user">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="title">
                        <h3>Qeydiyyatdan keç</h3>
                    </div>
                    <div class="register">
                        <div class="form-group row">
                            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Ad"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbName" CssClass="form-control" runat="server" placeholder="Ad"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="Ad Boş Qoyula Bilməz" ControlToValidate="tbName" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="tbName" ID="RegularExpressionValidator1" ValidationExpression="^[a-zA-Z]{2,15}$" runat="server" ErrorMessage="Ancaq Hərflər Daxil Edin" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Soyad"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbSurname" CssClass="form-control" runat="server" placeholder="Soyad"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Soyad Boş Qoyula Bilməz" ControlToValidate="tbSurname" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="tbSurname" ID="RegularExpressionValidator2" ValidationExpression="^[a-zA-Z]{2,15}$" runat="server" ErrorMessage="Ancaq Hərflər Daxil Edin" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Email" TextMode="Email"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Email Boş Qoyla Bilməz" ControlToValidate="tbEmail" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Şifrə"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" placeholder="Şifrə" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Şifrə Boş Qoyula Bilməz" ControlToValidate="tbPassword" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ControlToValidate="tbPassword" ID="RegularExpressionValidator3" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!$%@#£€*?&]{8,}$" runat="server" ErrorMessage="Şifrədə hərflər və rəqəmlər olmaqla yanaşı uzunluğu 8 simvol olmalıdır" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="Şifrəni Təkrarlayın"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbPasswordConfirm" CssClass="form-control" runat="server" placeholder="Təkrar Şifrə" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Şifrəni Təkrarlayın" ControlToValidate="tbPasswordConfirm" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="comparePasswords" ToolTip="Şifrələr Eyni Olmalıdır" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbPasswordConfirm" SetFocusOnError="True" ErrorMessage="Şifrələr Uyğun Deyil" Display="Dynamic" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="Label6" runat="server" CssClass="col-md-2 control-label" Text="Doğum Tarixi"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbBirthdate" CssClass="form-control" runat="server" placeholder="Doğum Tarixi" TextMode="Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="Doğum Tarixi Boş Qoyula Bilməz" ControlToValidate="tbBirthdate" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvDate" runat="server" ControlToValidate="tbBirthdate" ErrorMessage="Doğum Tarixi Düzgün Deyil" Type="Date" MinimumValue="01/01/1920" MaximumValue="01/01/2100" Display="Dynamic"></asp:RangeValidator>
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
                        <div class="form-group row">
                            <div class=" col-sm-10 col-sm-offset-2">
                                <label for="txtCaptcha">Captcha daxil edin</label>
                                <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                                <BotDetect:WebFormsCaptcha ID="Captcha" runat="server" />
                                <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="Captchani daxil edin" ControlToValidate="txtCaptcha"></asp:RequiredFieldValidator>
                                <asp:Label ID="CaptchaErrorLabel" runat="server" />
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                <asp:Button ID="btSignup" runat="server" Class="btn btn-success pull-right" Text="Qeydiyyatdan Keç" OnClick="btSignup_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <uc:ModalSuccess ID="ModalSuccess" runat="server" />
    <script>
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="EndContent" ContentPlaceHolderID="EndContent" runat="server">
    <%: Scripts.Render("~/bundles/indexJs") %>
</asp:Content>
