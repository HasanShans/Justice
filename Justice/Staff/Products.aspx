<%@ Page Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Justice.Staff.Products" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="Content1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Data Table With Full Features</h3>
                    </div>
                    <asp:HyperLink runat="server" CssClass="btn btn-primary" Style="margin-bottom: 20px" ID="test2" NavigateUrl="~/Admin/Add/Product.aspx" Text="Məhsul əlavə et"></asp:HyperLink>
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Məhsul Kodu</th>
                                    <th>Ad</th>
                                    <th>Kateqoriya</th>
                                    <th>Cəzaçəkmə Müəssisəsi</th>
                                    <th>Məhbus</th>
                                    <th>Redakte et</th>
                                    <th>Ləğv et</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtProducts" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("ID") %></td>
                                            <td><%#Eval("Code") %></td>
                                            <td><%#Eval("ProductName") %></td>
                                            <td><%#Eval("CategoryName") %></td>
                                            <td><%#Eval("JailName") %></td>
                                            <td><%#Eval("LastName") + " " + Eval("FirstName") %></td>
                                            <td>
                                                <asp:Button runat="server" CssClass='btn btn-primary btn-sm' OnClick="ProductEditClick" Text="Redaktə Et"></asp:Button>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                                                <asp:Button runat="server" CssClass='btn btn-danger btn-sm' OnClick="ProductDeleteClick" OnClientClick="return confirm('Siz bu məhsulu silmək istədiyinizdən əminsiniz? Silinmiş məlumat geri qaytarıla bilməz.');" Text="Ləğv Et
                                                    "></asp:Button></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>Məhsul Kodu</th>
                                    <th>Ad</th>
                                    <th>Kateqoriya</th>
                                    <th>Cəzaçəkmə Müəssisəsi</th>
                                    <th>Məhbus</th>
                                    <th>Redakte et</th>
                                    <th>Ləğv et</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
