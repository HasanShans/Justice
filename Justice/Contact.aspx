<%@ Page Title="Əlaqə" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Justice.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="contact">
        <div class="container">
            <div id="user" class="">
                <div class="title">
                    <h3>Bizimlə Əlaqə</h3>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="map shake wow ">
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3039.546677834978!2d49.81591511481208!3d40.3745749661273!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307dc0223d8c99%3A0xcbca10d3885f5c91!2z0JzQuNC90LjRgdGC0LXRgNGB0YLQstC-INCu0YHRgtC40YbQuNC4!5e0!3m2!1sru!2s!4v1511256859197" width="100%" height="300" frameborder="0" style="border: 2px solid #747474;" allowfullscreen></iframe>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 wow wow fadeInLeft">
                    <div class="panel">
                        <div class="panel-head">
                            <h3><i class="fa fa-map-marker" aria-hidden="true"></i>Bizim ofisimiz</h3>
                        </div>
                        <div class="panel-body">
                            <address>
                                <strong>Azərbaycan Respublikası Ədliyyə Nazirliyi
                                </strong>
                                <p>
                                  
                                    <i class="fa fa-phone"></i>+994 12 598 07 64
                                </p>
                            </address>
                        </div>
                    </div>
                    <div class="panel">
                        <div class="panel-head ">
                            <h3><i class="fa fa-clock-o" aria-hidden="true"></i>İş günləri</h3>
                        </div>
                        <div class="panel-body">
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>Gün</th>
                                        <th>Saat</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Bazar ertəsi</td>
                                        <td>9:00-18:00</td>
                                    </tr>
                                    <tr>
                                        <td>Çərşənbə axşamı</td>
                                        <td>9:00-18:00</td>
                                    </tr>
                                    <tr>
                                        <td>Çərşənbə</td>
                                        <td>9:00-18:00</td>
                                    </tr>
                                    <tr>
                                        <td>Cümə axşamı</td>
                                        <td>9:00-18:00</td>
                                    </tr>
                                    <tr>
                                        <td>Cümə</td>
                                        <td>9:00 - 18:00</td>
                                    </tr>
                                    <tr class="warning">
                                        <td>Şənbə</td>
                                        <td>11:00 - 16:00</td>
                                    </tr>
                                    <tr class="danger">
                                        <td>Bazar</td>
                                        <td>İş günü deyil</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-md-8 wow fadeInRight">
                    <div class="panel">
                        <div class="panel-head">
                            <h3><i class="fa fa-envelope" aria-hidden="true"></i>Bizə yazın</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label for="exampleInputName1">Ad və Soyad</label>
                                <asp:TextBox ID="tbNameSurname" CssClass="form-control" runat="server" placeholder="Ad və Soyad"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Bu sahə boş qoyula bilməz" ControlToValidate="tbNameSurname"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputName1">Email</label>
                                <asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Bu sahə boş qoyula bilməz" ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputName1">Telefon</label>
                                <asp:TextBox ID="tbPhone" CssClass="form-control" runat="server" placeholder="Əlaqə Nömrəsi"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputName1">Mesaj</label>
                                <asp:TextBox ID="tbMessage" CssClass="form-control" runat="server" placeholder="Mətn" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Bu sahə boş qoyula bilməz" ControlToValidate="tbMessage"></asp:RequiredFieldValidator>
                            </div>
                            <label for="txtCaptcha">Captcha daxil edin</label>
                            <asp:textbox ID="txtCaptcha" runat="server"></asp:textbox>
                                    <BotDetect:WebFormsCaptcha ID="Captcha" runat="server" />
                            <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Captchani daxil edin" ControlToValidate="txtCaptcha"></asp:RequiredFieldValidator>
                                    <asp:Label ID="CaptchaErrorLabel" runat="server"/>
                            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Göndər" OnClick="SendMessage_Click"></asp:Button>
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
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
