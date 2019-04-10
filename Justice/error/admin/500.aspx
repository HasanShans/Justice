<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="Justice.error.admin._500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="error-page" runat="server" id="error500">
            <h2 class="headline text-red">500</h2>
            <div class="error-content">
                <h3><i class="fa fa-warning text-red"></i>Üzr İstəyirik! Xəta baş verdi.</h3>
                <p>
                    Zəhmət olmasa yenidən cəhd edin.
            Əsas səhifəyə qayıtmaq üçün <a href="/root/məhsullar">bura klikləyin </a>
                </p>
            </div>
        </div>
    </section>
</asp:Content>
