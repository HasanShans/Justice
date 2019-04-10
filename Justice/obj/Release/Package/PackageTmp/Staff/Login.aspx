<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Justice.Staff.Login" %>

<html>
<head>
    <%: Styles.Render("~/Content/Admin/css/bootstrap.css") %>
    <%: Styles.Render("~/Content/Admin/css/AdminLTE.css") %>
    <style>
        body {
            background-image: url("/Content/Admin/img/others/background.jpg");
        }

        .box {
            margin-top: 30%;
            width: 60%;
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="col-md-6 col-md-offset-4">
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">Administratorun şəxsi kabineti</h3>
                </div>
                    <div class="box-body">
                        <div class="form-group row">
                            <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Login"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbLogin" CssClass="form-control" runat="server" placeholder="Login"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Logini Daxil Edin" ControlToValidate="tbLogin"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Parol"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" placeholder="Parol" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Parolu Daxil Edin" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-10 col-md-offset-2">
                                <asp:Label ID="lblMsg" runat="server" CssClass="col-md-12 control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <div class="checkbox">
                                    <label for="txtCaptcha">Captcha daxil edin</label>
                                    <asp:textbox ID="txtCaptcha" runat="server"></asp:textbox>
                                    <BotDetect:WebFormsCaptcha ID="Captcha" runat="server" />
                                    <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Captchani daxil edin" ControlToValidate="txtCaptcha"></asp:RequiredFieldValidator>
                                    <asp:Label ID="CaptchaErrorLabel" runat="server"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-footer">
                        <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-info pull-right" Text="Daxil ol"></asp:Button>
                    </div>
            </div>
        </div>
    </form>
</body>
</html>
