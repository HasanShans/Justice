<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Justice.Main.Purchase" %>


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
                                    <th>Məbləğ</th>
                                    <th>Sayı</th>
                                    <th></th>
                                    <th><a style="cursor: pointer; font-size: 25px; color: #FEBF00;" href=""><i class="fa fa-times"></i></a></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repeater" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th>
                                                <img width="80" src="/Content/Main/Images/thumb/thumb_<%# Eval("Image1") %>.jpg" alt="<%# Eval("ProductName") %>">
                                            </th>
                                            <td><%# Eval("Price") %></td>
                                            <td>
                                                <select class="count_update">
                                                    <option>1</option>
                                                </select>
                                            </td>
                                            <td>
                                                <a href=""><i style="cursor: pointer; font-size: 20px; color: #FEBF00;" class="fa fa-exchange"></i></a>
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
                            <p><span>20AZN dan cox alış-veriş etdiyiniz üçün çatdırılma pulsuzdur</span></p>
                            <form action="http://192.168.5.22/api/?v=1&m=addToOrders" method="POST">
                                <input type="text" name="price" value="" hidden>
                                <input type="text" name="amount" value=">" hidden>
                                <button name="buy" type="submit" style="width: 100%;" class="btn btn-success ">Məhsulu al <i class="fa fa-check" aria-hidden="true"></i></button>
                            </form>
                            <!--<button  type="submit" style="width: 100%;" class="btn btn-success "> <a href="address1.php">Məhsulu al</a> <i class="fa fa-check" aria-hidden="true"></i>-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
    <%: Scripts.Render("~/bundles/indexJs") %>
</asp:Content>
