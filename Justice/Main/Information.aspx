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
                                    <asp:TextBox ID="nameTextBox" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class='form-group row'>
                                <asp:Label ID="surnameLabel" AssociatedControlID="surnameTextBox" Text="Soyad" CssClass="col-sm-3 col-form-label" runat="server" />
                                <div class='col-sm-9'>
                                    <asp:TextBox ID="surnameTextBox" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class='form-group row'>
                                <asp:Label ID="emailLabel" AssociatedControlID="emailTextBox" Text="Email" CssClass="col-sm-3 col-form-label" runat="server" />
                                <div class='col-sm-9'>
                                    <asp:TextBox ID="emailTextBox" CssClass="form-control" runat="server" />
                                </div>
                            </div>

                            <div class='form-group row'>
                                <asp:Label ID="dateLabel" AssociatedControlID="dateTextBox" Text="Doğum tarixi" CssClass="col-sm-3 col-form-label" runat="server" />
                                <div class='col-sm-9'>
                                    <asp:TextBox ID="dateTextBox" CssClass="form-control" TextMode="Date" runat="server" />
                                </div>
                            </div>

                            <div class='form-group row'>
                                <asp:Label ID="serialLabel" AssociatedControlID="serialTextBox" Text="Şəxsiyyət vəsiqəsi seriya nömrəsi *" CssClass="col-sm-3 col-form-label" runat="server" />
                                <div class='col-sm-9'>
                                    <div class='input-group'>
                                        <span class='input-group-addon'>AZE</span>
                                        <asp:TextBox ID="serialTextBox" CssClass="form-control" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" id="serialValidator" controltovalidate="serialTextBox" cssClass="text-danger" errormessage="Şəxsiyyət vəsiqəsi seriya nömrəsini qeyd edin!" />
                                </div>
                            </div>

                            <div class='form-group row'>
                                <asp:Label ID="cityLabel" AssociatedControlID="cityTextBox" Text="Ya&#351;ad&#305;&#287;&#305;n&#305;z &#350;&#601;h&#601;r *" CssClass="col-sm-3 col-form-label" runat="server" />
                                <div class='col-sm-9'>
                                    <asp:DropDownList ID="ddlBrands" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" id="cityValidator" controltovalidate="cityTextBox" cssClass="text-danger" errormessage="Yaşadığınız şəhəri qeyd edin!" />
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
