<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Justice.Staff.Orders" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Sifarişlər
                    <small>bütün sifarişlər</small>
        </h1>
        <ol class="breadcrumb">
            <li><i class="fa fa-dashboard"></i>Staff</li>
            <li class="active">Sifarişlər</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                    </div>
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Müştəri</th>
                                    <th>Seriya AZE №</th>
                                    <th>Şəhər</th>
                                    <th>Telefon</th>
                                    <th>zip</th>
                                    <th>Məbləğ (azn)</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtOrders" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("ID") %></td>
                                            <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                                            <td><%# Eval("IDSerialNumber") %></td>
                                            <td><%# Eval("City") %></td>
                                            <td><%# Eval("MobilePhone") %></td>
                                            <td><%# Eval("PostIndex") %></td>
                                            <td><%# Eval("PaymentAmount") %> AZN</td>
                                            <td>
                                                <asp:Label ID="lblOrderID" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                                                <asp:Button runat="server" CssClass='btn btn-success btn-sm' OnClick="orderDeliveredClick"
                                                    OnClientClick="return confirm('Sifarişin təhvil verildiyindən əminsinizmi?');" Text="Təhvil Verildi"></asp:Button>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>Müştəri</th>
                                    <th>Seriya AZE №</th>
                                    <th>Şəhər</th>
                                    <th>Telefon</th>
                                    <th>zip</th>
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
