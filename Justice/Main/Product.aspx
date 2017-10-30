<%@ Page Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Justice.Main.Product" Title="Məhsul"%>

<asp:Content ID="Content" ContentPlaceHolderID="HeaderContent" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <style>
        .sp-zoom {
            width: 900px;
        }

            .sp-zoom img {
                width: 100%;
            }

        .navbar-static-top {
            z-index: 1;
            border-width: 0 0 1px;
        }

        .top-primary-menu ul li a {
            font-size: 12px;
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="product_single">
        <div class="container">
            <div class="row">
                <div class='col-md-12'>
                    <div class='title'>
                        <h3>
                            <a href='../Index.aspx'>Ana Səhifə</a>
                            <i class='fa fa-arrow-right' aria-hidden='true'></i>
                            <a href='../Index?Category=<%= data["mehsul_kateqoriya"]%>'><%= data["mehsul_kateqoriya"] %></a>
                            <i class='fa fa-arrow-right' aria-hidden='true'></i>
                            <%= data["mehsul_ad"] %>
                        </h3>
                    </div>
                </div>
                <div class='col-md-5'>
                    <div class='page'>
                        <div class='sp-loading'>
                            <img src='/Content/Main/images/sp-loading.gif' alt=''><br>
                            LOADING IMAGES</div>
                        <div class='sp-wrap'>
                            <asp:Repeater ID="rprtImages" runat="server">
                                <ItemTemplate>
                                    <a href="../../Content/Main/images/products/<%# Eval("ProductID") %>/<%#Eval("Name") %><%#Eval("Extention") %>">
                                        <img src="../../Content/Main/images/products/<%# Eval("ProductID") %>/<%#Eval("Name") %><%#Eval("Extention") %>" alt=''></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <br>
                </div>
                <div class='col-md-7'>
                    <div class='product_single_about'>
                        <table class='table table-striped table-responsive'>
                            <tbody>
                                <tr>
                                    <td>Məhsul kodu</td>
                                    <td><%= data["mehsul_kod"] %></td>
                                </tr>
                                <tr>
                                    <td>Məhsulun adı</td>
                                    <td><%= data["mehsul_ad"] %></td>
                                </tr>
                                <tr>
                                    <td>Məhsulun ölçüləri</td>
                                    <td><%= data["mehsul_olcu"] %> sm</td>
                                </tr>
                                <tr>
                                    <td>Məhsulun material növü</td>
                                    <td><%= data["mehsul_material"] %></td>
                                </tr>
                                <tr>
                                    <td>Məhsulun kateqoriyası</td>
                                    <td><%= data["mehsul_kateqoriya"] %></td>
                                </tr>
                                <tr>
                                    <td>Məhsulun çəkisi</td>
                                    <td><%= data["mehsul_ceki"] %> kq</td>
                                </tr>
                                <tr>
                                    <td>Anbardakı sayı</td>
                                    <td><%= data["mehsul_say"] %></td>
                                </tr>
                                <tr>
                                    <td>Əlavə məlumat</td>
                                    <td><%= data["elave_melumat"] %></td>
                                </tr>

                                <tr>
                                    <td>Qiyməti </td>
                                    <td><%= data["mehsul_qiymet"] %> AZN</td>
                                </tr>
                                <tr>
                                    <td>Endirimli qiyməti</td>
                                    <td><%= data["endirimli_qiymet"] %> AZN</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id='add'>
        <div class='container'>
            <div class='row'>
                <div class='col-md-8 col-md-offset-4'>
                    <asp:LinkButton CssClass='pull-right btn btn-success addtobasket' runat="server" ID="AddToCart" OnClick="AddToCart_Click">
                                   <i class='fa fa-shopping-cart' aria-hidden='true'></i>Səbətə əlavə et
                    </asp:LinkButton>
                </div>
                <br />
                <br />
                <div id='fb-root'></div>
                <script>
                    (function (d, s, id) {
                        var js, fjs = d.getElementsByTagName(s)[0];
                        if (d.getElementById(id)) return;
                        js = d.createElement(s); js.id = id;
                        js.src = '//connect.facebook.net/aze_AZE/sdk.js#xfbml=1&version=v2.9';
                        fjs.parentNode.insertBefore(js, fjs);
                    }(document, 'script', 'facebook-jssdk'));
                </script>

                <div class='fb-comments' data-href='http://192.168.5.22/api/?v=1&m=getProduct&code=".$code."' data-width='100%' data-numposts='10'></div>
            </div>
        </div>
    </section>

    <section id='products'>
        <div class='container'>
            <div class='col-md-12 title'>
                <h3>Oxşar Məhsullar</h3>

            </div>
            <div class='row'>
               <asp:Repeater  ID="productRepeater" runat="server">
                    <ItemTemplate>
                        <div class='col-md-3'>
                            <div class='product'>
                                <div runat="server" class="discount" style='right: 25px;' Visible='<%# Eval("Discount").ToString()!="0" %>'>
                                    <span><%# Eval("Discount")%> %</span>
                                </div>
                                <div class='images'>
                                    <a href='Product/?id=<%# Eval("ID") %>'>
                                        <img class='img-responsive' src='../../Content/Main/images/products/<%# Eval("ID") %>/<%#Eval("Name") %><%#Eval("Extention") %>' alt=''></a>
                                </div>
                                <div class='detailes'>
                                    <h5 class='text-center'>
                                        <a href='Product/?id=<%# Eval("ID") %>'><%# Eval("ProductName") %></a>
                                    </h5>
                                    <div class='addShopp'>
                                        <p runat="server" class='pull-left' Visible='<%# Eval("Price").ToString()==Eval("DiscountPrice").ToString() %>'><%# Eval("Price") %> AZN</p>    
                                        <p runat="server" style="text-decoration:line-through" class='pull-left' Visible='<%# Eval("Price").ToString()!=Eval("DiscountPrice").ToString() %>'><%# Eval("Price") %> AZN</p>
                                        <p runat="server" class='pull-left' Visible='<%# Eval("Price").ToString()!=Eval("DiscountPrice").ToString() %>'><%# Eval("DiscountPrice") %> AZN</p>
                                        <a href=''>
                                            
                                                <asp:LinkButton CssClass="pull-right" ForeColor="#FEBF00" style="margin-right:10px;" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="btnAddToCart_Click" data-toggle="tooltip" title="Səbətə əlavə et"><i class='fa fa-cart-plus fa-2x' aria-hidden='true' ></i></asp:LinkButton>
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
                                <img class='img-responsive' src="../../Content/Main/images/products/notfound.jpg" alt=''></a>
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
</asp:Content>

<asp:Content ID="EndContent" ContentPlaceHolderID="EndContent" runat="server">
    <script src="/Scripts/Main/bootstrap.js"></script>
    <script src="/Scripts/Main/script.js"></script>
    <script type="text/javascript" src="/Scripts/Main/smoothproducts.min.js"></script>
    <script type="text/javascript">
        /* wait for images to load */
        $(window).load(function () {
            $('.sp-wrap').smoothproducts();
        });
    </script>
</asp:Content>


