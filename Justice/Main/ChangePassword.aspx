<%@ Page Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Justice.Main.ChangePassword" Title="Yeni Şifrə"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="my_page">

        <div class="container">
            <div class="row">
                <uc:LeftMenu ID="LeftMenu" runat="server" />
                <div class="col-sm-9 col-md-9">
                    <div class="title">
                        <h3>Yeni Şifrə</h3>
                    </div>
                    <div class="register">
                        <div class='form-group row'>
                            <asp:Label ID="nameLabel" AssociatedControlID="txtOldPass" Text="Hazırki Şifrə" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <asp:TextBox ID="txtOldPass" CssClass="form-control" runat="server" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" SetFocusOnError="True" ID="RequiredFieldValidator2" ControlToValidate="txtOldPass" CssClass="text-danger" ErrorMessage="Hazırki Şifrənizi Daxil Edin" Display="Dynamic" />
                            </div>
                        </div>
                        <div class='form-group row'>
                            <asp:Label ID="lblll" AssociatedControlID="txtNewPass" Text="Yeni Şifrə" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <asp:TextBox ID="txtNewPass" CssClass="form-control" runat="server" TextMode="Password"/>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtNewPass" CssClass="text-danger" ErrorMessage="Yeni Şifrənizi Daxil Edin" Display="Dynamic" SetFocusOnError="true" />
                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtNewPass" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{6,14}$" runat="server" ErrorMessage="Sizin Şifrə Minimum 6 Maksimum 14 Simvol Olmalıdır" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class='form-group row'>
                            <asp:Label ID="dasd" AssociatedControlID="txtNewPassConf" Text="Yeni Şifrə Təkrar" CssClass="col-sm-3 col-form-label" runat="server" placeholder="example@gmail.com" />
                            <div class='col-sm-9'>
                                <asp:TextBox ID="txtNewPassConf" CssClass="form-control" runat="server" TextMode="Password"/>
                               <asp:CompareValidator id="comparePasswords" ToolTip="Şifrələr Eyni Olmalıdır" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtNewPassConf" SetFocusOnError="True"  ErrorMessage="Şifrələr Uyğun Deyil" Display="Dynamic" />
                               <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtNewPassConf" CssClass="text-danger" ErrorMessage="Şifrəni Təkrar Daxil Edin" Display="Dynamic" SetFocusOnError="true" />
                            </div>
                        </div>
                        <div class='form-group row'>
                            <div class="col-sm-3"></div>
                            <div class=' col-sm-9'>
                                <asp:Label runat="server" ID="lblMsg" Font-Size="Medium"></asp:Label>
                                <asp:Button runat="server" CssClass='btn btn-success pull-right' Text="Yadda Saxla" OnClick="saveNewPassword">
                                </asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
