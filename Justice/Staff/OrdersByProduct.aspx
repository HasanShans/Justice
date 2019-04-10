<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="OrdersByProduct.aspx.cs" Inherits="Justice.Staff.OrdersByProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Sifariş olunan məhsullar
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
                                    <th>Məhsulun adı</th>
                                    <th>Kodu</th>
                                    <th>Satıldığı qiymət</th>
                                    <th>Sifarişçi</th>
                                    <th>Tarix</th>
                                    <th>AZE seriya</th>
                                    <th>Hazırlandığı həbsxana</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtOrdersByProduct" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("ProductName") %></td>
                                            <td><%# Eval("Code") %></td>
                                            <td><%# Eval("OrderedPrice") %> <i>AZN</i></td>
                                            <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                                            <td><%# Eval("OrderDate") %></td>
                                            <td><i>AZE</i> <%# Eval("IDSerialNumber") %></td>
                                            <td><%# Eval("JailName") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>

                                <tr>
                                    <th>Məhsulun adı</th>
                                    <th>Kodu</th>
                                    <th>Satıldığı qiymət</th>
                                    <th>Sifarişçi</th>
                                    <th>Tarix</th>
                                    <th>AZE seriya</th>
                                    <th>Hazırlandığı həbsxana</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
