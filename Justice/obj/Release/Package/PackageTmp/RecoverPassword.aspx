<%@ Page  Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="Justice.RecoverPassword" Title="Şifrə Bərbası"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section id="user">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="sign_in">
                        <div class="title">
                            <h3>Yeni Şifrə</h3>
                        </div>
                        <div class="login">
                                <div class="form-group row">
                                    <asp:Label ID="lblPass" runat="server" CssClass="col-md-2 control-label" Text="Yeni Şifrə" Visible="False"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbPass" CssClass="form-control" runat="server" placeholder="Şifrə" TextMode="Password"  Visible="False"></asp:TextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator1" CssClass="text-danger" runat="server"  ErrorMessage="Şifrə Boş Qoyula Bilməz" ControlToValidate="tbPass"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "tbPass" ID="RegularExpressionValidator3" ValidationExpression = "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!$%@#£€*?&]{8,}$" runat="server" ErrorMessage="Şifrədə hərflər və rəqəmlər olmaqla yanaşı uzunluğu 8 simvol olmalıdır" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <asp:Label ID="lblPassConf" runat="server" CssClass="col-md-2 control-label" Text="Yeni Şifrə Təkrar" Visible="False"></asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="tbPassConf" CssClass="form-control" runat="server" placeholder="Şifrə Təkrar" TextMode="Password" Visible="False"></asp:TextBox>
                                         <asp:CompareValidator id="comparePasswords" ToolTip="Şifrələr Eyni Olmalıdır" runat="server" ControlToCompare="tbPass" ControlToValidate="tbPassConf" SetFocusOnError="True"  ErrorMessage="Şifrələr Uyğun Deyil" Display="Dynamic" />
                                        <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Yeni Şifrə Boş Qoyula Bilməz" ControlToValidate="tbPassConf"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class=" col-sm-12">
                                        <asp:Button ID="btRequestForgot" runat="server" Class="btn btn-success pull-right" Text="Yenilə" OnClick="btPassRec_Click"  Visible="False" />
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </div>
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

