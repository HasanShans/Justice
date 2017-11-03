<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="ProductsFilter.aspx.cs" Inherits="Justice.Main.ProductsSoon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="products">
        <div class="container">
            <div class="col-md-12 title">
                <h3><%= producstHeader %></h3>
            </div>
            <div class="row">
                <asp:Repeater ID="productRepeater" runat="server">
                    <ItemTemplate>
                        <div class='col-md-3'>
                            <div class='product'>
                                <div runat="server" class="discount" style='right: 25px;' visible='<%# Eval("Discount").ToString()!="0" %>'>
                                    <span><%# Eval("Discount")%> %</span>
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
                                        <p runat="server" class='pull-left' visible='<%# Eval("Price").ToString()==Eval("DiscountPrice").ToString() %>'><%# Eval("Price") %> AZN</p>
                                        <p runat="server" style="text-decoration: line-through" class='pull-left' visible='<%# Eval("Price").ToString()!=Eval("DiscountPrice").ToString() %>'><%# Eval("Price") %> AZN</p>
                                        <p runat="server" class='pull-left' visible='<%# Eval("Price").ToString()!=Eval("DiscountPrice").ToString() %>'><%# Eval("DiscountPrice") %> AZN</p>
                                        <a href='' runat="server" id="btnAddToCart">
                                            <asp:LinkButton ID="btnbtn" CssClass="pull-right" ForeColor="#FEBF00" style="margin-right:10px;" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="btnAddToCart_Click" data-toggle="tooltip" title="Səbətə əlavə et"><i class='fa fa-cart-plus fa-2x' aria-hidden='true' ></i></asp:LinkButton>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class='col-md-3' id="notfoundProduct" runat="server" visible="false">
                    <div class='product'>
                        <div class='images'>
                            <a href='#'>
                                <img class='img-responsive' src='../Content/Main/images/products/notfound.jpg' alt=''></a>
                        </div>
                        <div class='detailes'>
                            <h5 class='text-center'>
                                <a href='#'>Məhsul Tapılmadı</a>
                            </h5>
                            <div class='addShopp'>
                            </div>
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
</asp:Content>
