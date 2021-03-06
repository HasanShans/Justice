﻿<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Justice.Purchase" Title="Səbət" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="basket">
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <div class="basket_about">
                        <div style="margin-bottom: 15px;" class="title">
                            <h3>Səbətim</h3>
                        </div>
                        <table class="table table-responsive text-center table-bordered">
                            <thead>
                                <tr>
                                    <th>Məhsul</th>
                                    <th>Qiyməti</th>
                                    <th>Sayı</th>
                                    <th><a style="cursor: pointer; font-size: 25px; color: #FEBF00;" href=""><i class="fa fa-times"></i></a></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repeaterPurchase" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <img width="80" src="../Content/Main/images/products/<%# Eval("ProductID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt="<%# Eval("ProductName") %>">
                                            </td>
                                            <td><%# Eval("DiscountPrice") %> AZN</td>
                                            <td>
                                                <select class="count_update">
                                                    <option>1</option>
                                                </select>
                                            </td>

                                            <td>
                                                <asp:LinkButton ID="RemoveFromCart" runat="server" style="cursor: pointer; font-size: 25px; color: #FEBF00;" CommandArgument='<%# Eval("ProductID") %>' OnClick="RemoveFromCart_Click" >
                                                   <i class="fa fa-times"></i>
                                                </asp:LinkButton>                                           
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="basket_product_buy text-center">
                        <div class="title">
                            <h3 class="">Sifariş Məcmusu</h3>
                        </div>
                        <div class="sifaris">
                            <p>Məhsul ədədi</p>
                            <p><span id="product_count"><%= amount %></span></p>
                            <hr class="hr1">
                            <p>Ümumi məbləğ</p>
                            <p><span id="product_sum"><%= sum %> AZN</span></p>
                            <hr class="hr1">
                            <p>Çatdırılma</p>
                            <p><span>Çatdırılma pulsuzdur</span></p>
                                <asp:Button runat="server" OnClick="btnProductBuy_Click" ID="btnProductBuy" style="width: 100%;" CssClass="btn btn-success " Text="Məhsulu al" Enabled="false"></asp:Button>
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
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
   <%-- <script>
        $.ajax({
            url: 'PaymentStatus.aspx',             
            type: 'POST',           
            success: function (data, textStatus) { 
            }
        });
    </script>--%>
    
    <%: Scripts.Render("~/bundles/indexJs") %>
    
</asp:Content>
