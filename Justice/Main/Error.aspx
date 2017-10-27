<%@ Page Title="Xəta" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Justice.Main.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" runat="server" id="notfound" visible="true">
        <div class="row">
            <div class="col-md-6 col-md-offset-3 text-center">
                <br>
                <h3>Təəssüf!</h3>
                <p>
                    <img src="../Content/Main/images/404-error.png" width="300px" alt="">
                </p>
                <h2><i class="fa fa-exclamation-triangle" style="color: red"></i>
                    Axtardığınız Səhifə Tapılmadı <small>404 error</small></h2>             
                </p>
                <p>Əsas səhifəyə qayıtmaq üçün <a href="Index.aspx">bura klikləyin </a> </p>
                <p>
                    <a href="#">prison-art.gov.az</a>
                </p>
            </div>
        </div>
    </div>
    <div class="container" runat="server" id="xeta" visible="false">
        <div class="row">
            <div class="col-md-6 col-md-offset-3 text-center">
                <br>
                <h3>Üzr İstəyirik!</h3>
                <p>
                    <img src="../Content/Main/images/xeta.png" width="200px" alt="">
                </p>
                <h2><i class="fa fa-exclamation-triangle" style="color: red"></i>
                    Xəta baş verdi </h2>             
                </p>
                <p>Zəhmət olmasa yenidən cəhd edin</p>
                <p>Əsas səhifəyə qayıtmaq üçün <a href="Index.aspx">bura klikləyin </a> </p>
                <p>
                    <a href="#">prison-art.gov.az</a>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
