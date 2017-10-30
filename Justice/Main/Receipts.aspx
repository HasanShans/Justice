<%@ Page Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Receipts.aspx.cs" Inherits="Justice.Main.Receipts" Title="Qəbzlər" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="my_page">
        <div class="container">
            <div class="row">
                <uc:LeftMenu ID="LeftMenu" runat="server" />
                <div class="col-sm-9 col-md-9">
                    <!-- <div class="well"> -->
                    <div class="title">
                        <h3>Qəbzlərim</h3>
                    </div>
                    <table class="table table-responsive table-bordered">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Tarix</th>
                                <th>Məbləğ</th>
                                <th>Açıqlama</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rprtReceipts">
                                <ItemTemplate>
                                    <tr>
                                        <th scope="row"><%# Eval("Number") %></th>
                                        <td><%# Eval("OrderDate") %></td>
                                        <td><%# Eval("DiscountPrice") %></td>
                                        <td><%# Eval("ProductName") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr runat="server" id="tdRow" visible="false">
                                <td colspan="4">Hörmətli istifadəçi, siz bizim saytdan məhsul sifariş etməmisiniz</td>
                            </tr>
                            <tr>
                                <th scope="row">CƏMİ ALVER QƏBZİ</th>
                                <td colspan="3"><%= totalSum %>AZN</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
