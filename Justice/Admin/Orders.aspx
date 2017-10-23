<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Justice.Admin.Orders" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Data Table With Full Features</h3>
                    </div>
                    <asp:HyperLink runat="server" CssClass="btn btn-primary" Style="margin-bottom: 20px" ID="test2" NavigateUrl="~/Admin/Add/Jail.aspx" Text="Kateqoriya əlavə et"></asp:HyperLink>
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                        <th>MƏHSUL KODU</th>
                                        <th>Müştəri</th>
                                        <th>Məbləğ</th>
                                        <th>Təhvil verildi</th>
                                        <th>Şəhər</th>
                                        <th>Telefon</th>
                                        <th>Seriya №</th>
                                        <th>zip</th>
                                        <th></th>
                                </tr>
                            </thead>
                            <tbody>
                            <asp:Repeater ID="rprtJails" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                                 </tbody>
                            <tfoot>
                                <tr>
                                   <th>MƏHSUL KODU</th>
                                        <th>Müştəri</th>
                                        <th>Məbləğ</th>
                                        <th>Təhvil verildi</th>
                                        <th>Şəhər</th>
                                        <th>Telefon</th>
                                        <th>Seriya №</th>
                                        <th>zip</th>
                                        <th></th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
                       
</asp:Content>
