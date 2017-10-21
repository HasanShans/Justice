<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Justice.Main.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="products" style="min-height: 352px;">
        <div class="container">
            <div class="col-md-12 title">
                <h3>Axtarılan: <%= searchedProduct %> | Nəticə: <%= result %></h3>
            </div>
            <div class="row">
                    <asp:Repeater ID="repeater" runat="server">
                        <ItemTemplate>
                            <div class='col-md-3'>
                                <div class='product'>
                                    <div class='discount' style='right: 25px;'>
                                        <span><%# Eval("Discount")%> AZN</span>
                                    </div>
                                    <div class='images'>
                                        <a href='Product/?id=<%# Eval("ID") %>'>
                                            <img class='img-responsive' src='../Content/Main/images/products/<%# Eval("Image1") %>.jpg' alt=''></a>
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
        </div>
    </section>
    <section id="pagination">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="pagination">
                        <a href='http://192.168.5.22/search.php?word=".$word."&s={$i}'>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
    <%: Scripts.Render("~/bundles/indexJs") %>
</asp:Content>
