<%@ Page Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Justice.Main.Orders" Title="Sifarişlər" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="my_page">
        <div class="container">
            <div class="row">
                <uc:LeftMenu ID="LeftMenu" runat="server" />
                <div class="col-sm-9 col-md-9">
                    <div class="title">
                        <h3>Sifarişlərim</h3>
                    </div>
                    <table class="table  table-bordered table-responsive">
                        <thead>
                            <tr>
                                <th>Sifariş Vaxtı</th>
                                <th>Status</th>
                                <th>Məhsulun Sayı</th>
                                <th>Məbləğ</th>
                           </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rprtOrders" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("OrderDate") %></td>
                                        <td><%# Eval("StatusDisplay") %></td>
                                        <td><%# Eval("ProductCount") %></td>
                                        <td><%# Eval("PaymentAmount") %> AZN    </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <td colspan="4" runat="server" id="tdRow" visible ="false">Hörmətli istifadəçi, siz bizim saytdan məhsul sifariş etməmisiniz</td>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
