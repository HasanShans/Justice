<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="403.aspx.cs" Inherits="Justice.error.admin._403" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="error-page" runat="server" id="error404">
            <h2 class="headline text-yellow">404</h2>
            <div class="error-content">
                <h3><i class="fa fa-warning text-yellow"></i>Təəssüf! Axtardığınız Səhifə Tapılmadı.</h3>
                <p>
                    Axtardığınız səhifəni tapa bilmədik.
            Əsas səhifəyə qayıtmaq üçün <a href="Products.aspx">bura klikləyin </a>
                </p>
            </div>
        </div>
    </section>
</asp:Content>
