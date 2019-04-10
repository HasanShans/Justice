<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="Justice.error.main._500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" runat="server" id="error500">
        <div class="row">
            <div class="col-md-6 col-md-offset-3 text-center">
                <br>
                <h3>Üzr İstəyirik!</h3>
                <p>
                    <img src="../Content/Main/images/500.png" width="180px" alt="">
                </p>
                <h2><i class="fa fa-exclamation-triangle" style="color: red"></i>
                    Xəta baş verdi </h2>             
                
                <p>Zəhmət olmasa yenidən cəhd edin</p>
                <p>Əsas səhifəyə qayıtmaq üçün <a href="ana-səhifə">bura klikləyin </a> </p>
                <p>
                    <a href="#">prison-art.gov.az</a>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
