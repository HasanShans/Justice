<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="DeliveredOrders.aspx.cs" Inherits="Justice.Staff.DeliveredOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Təhvil Verilmiş Sifarişlər
            <small>
                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlYear" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                </asp:DropDownList>
            </small>
            <small>
                <asp:DropDownList CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlMonthFilter_SelectedIndexChanged" runat="server" ID="ddlMonthFilter">
                    <asp:ListItem Value="0">Bütün aylar</asp:ListItem>
                    <asp:ListItem Value="1">Yanvar</asp:ListItem>
                    <asp:ListItem Value="2">Fevral</asp:ListItem>
                    <asp:ListItem Value="3">Mart</asp:ListItem>
                    <asp:ListItem Value="4">Aprel</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">İyun</asp:ListItem>
                    <asp:ListItem Value="7">İyul</asp:ListItem>
                    <asp:ListItem Value="8">Avqust</asp:ListItem>
                    <asp:ListItem Value="9">Sentyabr</asp:ListItem>
                    <asp:ListItem Value="10">Oktyabr</asp:ListItem>
                    <asp:ListItem Value="11">Noyabr</asp:ListItem>
                    <asp:ListItem Value="12">Dekabr</asp:ListItem>
                </asp:DropDownList>
            </small>
        </h1>   
                    <ol class="breadcrumb">
                        <li><i class="fa fa-dashboard"></i>Staff</li>
                        <li class="active">Çatdırılmış Sifarişlər</li>
                    </ol>
    </section>
  <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>Müştəri</th>
                                    <th>Seriya AZE №</th>
                                    <th>Şəhər</th>
                                    <th>Telefon</th>
                                    <th>Zip</th>
                                    <th>Sifariş</th>
                                    <th>Çatdırılma</th>
                                    <th>Məbləğ (azn)</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                            <asp:Repeater ID="rprtDeliveredOrders" runat="server">
                                <ItemTemplate>
                                    <tr>
                                            <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                                            <td><%# Eval("IDSerialNumber") %></td>
                                            <td><%# Eval("City") %></td>
                                            <td><%# Eval("MobilePhone") %></td>
                                            <td><%# Eval("PostIndex") %></td>
                                            <td><%# Eval("OrderDate") %></td>
                                            <td><%# Eval("DeliveryDate") %></td>
                                            <td><%# Eval("PaymentAmount") %> AZN</td>
                                            <td>Təhvil Verilib</td>
                                        </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                                 </tbody>
                            <tfoot>
                                <tr>
                                    <th>Müştəri</th>
                                    <th>Seriya AZE №</th>
                                    <th>Şəhər</th>
                                    <th>Telefon</th>
                                    <th>Zip</th>
                                    <th>Sifariş</th>
                                    <th>Çatdırılma</th>
                                    <th>Məbləğ (azn)</th>
                                    <th>Status</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
                       
</asp:Content>
