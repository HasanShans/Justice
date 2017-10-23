<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="ProductsFilter.aspx.cs" Inherits="Justice.Main.ProductsSoon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="products">
        <div class="container">
            <div class="col-md-12 title">
                <h3>Tezliklə Satışda Olacaq Məhsullar</h3>
            </div>
            <div class="row">
                <asp:Repeater  ID="productRepeater" runat="server">
                    <ItemTemplate>
                        <div class='col-md-3'>
                            <div class='product'>
                                <div class='discount' style='right: 25px;'>
                                    <span><%# Eval("Discount")%> AZN</span>
                                </div>
                                <div class='images'>
                                    <a href='Product/?id=<%# Eval("ID") %>'>
                                        <img class='img-responsive' src='../Content/Main/images/products/<%# Eval("ID") %>/<%#Eval("Name") %><%#Eval("Extention") %>' alt=''></a>
                                </div>
                                <div class='detailes'>
                                    <h5 class='text-center'>
                                        <a href='Product/?id=<%# Eval("ID") %>'><%# Eval("ProductName") %></a>
                                    </h5>
                                    <div class='addShopp'>
                                        <p class='pull-left'><%# Eval("Price") %> AZN</p>
                                        <a href=''>
                                            <button class='pull-right'>
                                                <a href='http://192.168.5.22/api/?v=1&m=addFavorite&user_id=".$json2->data->id."&product_id=".$data->id."'><i class='fa fa-star-o fa-2x' aria-hidden='true'></i></a>
                                            </button>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
