<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="OrdersByJail.aspx.cs" Inherits="Justice.Staff.OrdersByJail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Həbsxanalara görə satışlar
                    <small>həbsxanaların ümumi statistikası</small>
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
                                    <th>Cəzaçəkmə müəssisəsi</th>
                                    <th>Satılan məhsulların sayı</th>
                                    <th>Qazanc</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtOrdersByJail" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("JailName") %></td>
                                            <td><%# Eval("OrderCounts") %></td>
                                            <td><%# Eval("Revenue") %> <i>AZN</i></td>                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                
                                <tr>
                                    <th>Cəzaçəkmə müəssisəsi</th>
                                    <th>Satılan məhsulların sayı</th>
                                    <th>Qazanc</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
