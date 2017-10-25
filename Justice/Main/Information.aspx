<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="Site.Master" CodeBehind="Information.aspx.cs" Inherits="Justice.Main.Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="my_page">

        <div class="container">
            <div class="row">
                <uc:LeftMenu ID="LeftMenu" runat="server" />
                <div class="col-sm-9 col-md-9">
                    <div class="title">
                        <h3>Məlumatlarım</h3>
                    </div>
                    <div class="register">
                        <div class='form-group row'>
                            <asp:Label ID="nameLabel" AssociatedControlID="nameTextBox" Text="Ad" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'><i class="fa fa-user"></i></span>
                                    <asp:TextBox ID="nameTextBox" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class='form-group row'>
                            <asp:Label ID="surnameLabel" AssociatedControlID="surnameTextBox" Text="Soyad" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'><i class="fa fa-user"></i></span>
                                    <asp:TextBox ID="surnameTextBox" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class='form-group row'>
                            <asp:Label ID="emailLabel" AssociatedControlID="emailTextBox" Text="Email" CssClass="col-sm-3 col-form-label" runat="server" placeholder="example@gmail.com" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'><i class="fa fa-envelope"></i></span>
                                    <asp:TextBox ID="emailTextBox" CssClass="form-control" runat="server" TextMode="Email"/>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="emailTextBox" CssClass="text-danger" ErrorMessage="Emailinizi qeyd edin!"  Display="Dynamic" SetFocusOnError="true"/>
                            </div>
                        </div>

                        <div class='form-group row'>
                            <asp:Label ID="dateLabel" AssociatedControlID="dateTextBox" Text="Doğum tarixi" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="dateTextBox" CssClass="form-control" TextMode="Date" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class='form-group row'>
                            <asp:Label ID="serialLabel" AssociatedControlID="serialTextBox" Text="Şəxsiyyət vəsiqəsi seriya nömrəsi *" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'>AZE</span>
                                    <asp:TextBox ID="serialTextBox" CssClass="form-control" runat="server" placeholder="12345678" />
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="serialValidator" ControlToValidate="serialTextBox" CssClass="text-danger" ErrorMessage="Şəxsiyyət vəsiqəsi seriya nömrəsini qeyd edin!"  Display="Dynamic" SetFocusOnError="true"/>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="serialTextBox" ID="RegularExpressionValidator2" ValidationExpression="[0-9]{7,8}$" runat="server" ErrorMessage="8 Rəqəmli Seriya Nömrəsini Daxil Edin" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>

<<<<<<< HEAD

                            <%--<div class='form-group row'>
                                <asp:Label ID="cityLabel" AssociatedControlID="cityTextBox" Text="Ya&#351;ad&#305;&#287;&#305;n&#305;z &#350;&#601;h&#601;r *" CssClass="col-sm-3 col-form-label" runat="server" />
                                <div class='col-sm-9'>
                                    <asp:DropDownList ID="ddlBrands" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" id="cityValidator" controltovalidate="cityTextBox" cssClass="text-danger" errormessage="Yaşadığınız şəhəri qeyd edin!" />
                                </div>
                            </div>--%>
                            <!-- /.form-group -->

                            <div class='form-group row'>
                                <div class=' col-sm-12'>
                                    <button class='btn btn-success pull-right' onserverclick="submitClick" runat="server">
                                        Yadda Saxla<i class='fa fa-check' aria-hidden='true'></i>
                                    </button>
=======
                        <div class='form-group row'>
                            <asp:Label ID="cityLabel" AssociatedControlID="cityTextBox" Text="Şəhər *" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'><i class="fa fa-home"></i></span>
                                    <asp:TextBox ID="cityTextBox" CssClass="form-control" runat="server" placeholder="Bakı"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="cityValidator" ControlToValidate="cityTextBox" CssClass="text-danger" ErrorMessage="Yaşadığınız şəhəri qeyd edin!"  Display="Dynamic" SetFocusOnError="true"/>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="cityTextBox" ID="RegularExpressionValidator1" ValidationExpression="^[a-zA-Z ]{3,15}$" runat="server" ErrorMessage="Yanlış Şəhər Adı" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class='form-group row'>
                            <asp:Label ID="Label1" AssociatedControlID="PostIndexTextBox" Text="Poçt İndeksi *" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class="input-group">
                                    <span class='input-group-addon'>AZ</span>
                                    <asp:TextBox ID="PostIndexTextBox" CssClass="form-control" runat="server" placeholder="1234"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="PostIndexTextBox" CssClass="text-danger" ErrorMessage="Poçt indeksini qeyd edin!"  Display="Dynamic" SetFocusOnError="true"/>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="PostIndexTextBox" ID="RegularExpressionValidator3" ValidationExpression="^[0-9]{4}$" runat="server" ErrorMessage="4 Rəqəmli Poçt İndeksini Daxil Edin" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class='form-group row'>
                            <asp:Label ID="Label2" AssociatedControlID="MobilePhoneTextBox" Text="Mobil Telefon *" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'><i class="fa fa-mobile"></i></span>
                                    <asp:TextBox ID="MobilePhoneTextBox" CssClass="form-control" runat="server" placeholder="050xxxxxxx"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="MobilePhoneTextBox" CssClass="text-danger" ErrorMessage="Mobil nömrənizi qeyd edin!"  Display="Dynamic" SetFocusOnError="true"/>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="MobilePhoneTextBox" ID="RegularExpressionValidator4" ValidationExpression="[0-9]{10}$" runat="server" ErrorMessage="10 Rəqəmli Mobil Nomrənizi Daxil Edin" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class='form-group row'>
                            <asp:Label ID="Label3" AssociatedControlID="HomePhoneTextBox" Text="Ev Telefonu" CssClass="col-sm-3 col-form-label" runat="server" />
                            <div class='col-sm-9'>
                                <div class='input-group'>
                                    <span class='input-group-addon'><i class="fa fa-phone"></i></span>
                                    <asp:TextBox ID="HomePhoneTextBox" CssClass="form-control" runat="server" placeholder="012xxxxxxx"></asp:TextBox>
>>>>>>> e20b681b50dc51c3d76c0a6cd068d4eed34e90e3
                                </div>
                                <asp:RegularExpressionValidator ControlToValidate="HomePhoneTextBox" ID="RegularExpressionValidator5" ValidationExpression="[0-9]{10}$" runat="server" ErrorMessage="10 Rəqəmli Ev Telefonu Nomrənizi Daxil Edin" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            </div>
                    </div>
                    <!-- /.form-group -->

                    <div class='form-group row'>
                        <div class=' col-sm-12'>
                            <button class='btn btn-success pull-right' onserverclick="submitClick" runat="server">
                                Yadda Saxla<i class='fa fa-check' aria-hidden='true'></i>
                            </button>
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
