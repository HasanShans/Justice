<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="Justice.error.main._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" runat="server" id="error404">
        <div class="row">
            <div class="col-md-6 col-md-offset-3 text-center">
                <br>
                <h3>Təəssüf!</h3>
                <p>
                    <img src="../Content/Main/images/404.png" width="200px" alt="">
                </p>
                <h2><i class="fa fa-exclamation-triangle" style="color: red"></i>
                    Axtardığınız Səhifə Tapılmadı </h2>             
                </p>
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
