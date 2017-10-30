<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Justice.Staff.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="error-page" runat="server" id="error404" visible="false">
            <h2 class="headline text-yellow">404</h2>
            <div class="error-content">
                <h3><i class="fa fa-warning text-yellow"></i>Təəssüf! Axtardığınız Səhifə Tapılmadı.</h3>
                <p>
                    Axtardığınız səhifəni tapa bilmədik.
            Əsas səhifəyə qayıtmaq üçün <a href="Products.aspx">bura klikləyin </a>
                </p>
            </div>
        </div>
        <div class="error-page" runat="server" id="error500" visible="false">
            <h2 class="headline text-red">500</h2>
            <div class="error-content">
                <h3><i class="fa fa-warning text-red"></i>Üzr İstəyirik! Xəta baş verdi.</h3>
                <p>
                    Zəhmət olmasa yenidən cəhd edin.
            Əsas səhifəyə qayıtmaq üçün <a href="Products.aspx">bura klikləyin </a>
                </p>
            </div>
        </div>
    </section>
</asp:Content>
