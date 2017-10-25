<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Justice.Staff.Categories" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Kateqoriyalar
                    <small>bütün kateqoriyalar</small>
        </h1>
        <ol class="breadcrumb">
            <li><i class="fa fa-dashboard"></i>Staff</li>
            <li class="active">Kateqoriyalar</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <asp:HyperLink runat="server" CssClass="btn btn-success" Style="margin:10px;" ID="test2" NavigateUrl="~/Staff/Add/Category.aspx" Text="Kateqoriya əlavə et"></asp:HyperLink>
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <col width="330">
                            <col width="330">
                            <col width="50">
                            <col width="50">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Adı</th>
                                    <th>Redaktə Et</th>
                                    <th>Sil</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtCategories" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("ID") %></td>
                                            <td><%# Eval("CategoryName") %></td>
                                            <td>
                                                <asp:Button runat="server" CssClass='btn btn-primary btn-sm' OnClick="CategoryEditClick" Text="Redaktə Et"></asp:Button>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCatID" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                                                <asp:Button runat="server" CssClass='btn btn-danger btn-sm' OnClick="CategoryDeleteClick"
                                                    OnClientClick="return confirm('Siz bu kateqoriyanı silmək istədiyinizdən əminsiniz? Silinmiş məlumat geri qaytarıla bilməz.');" Text="Ləğv Et"></asp:Button>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>Adı</th>
                                     <th>Redaktə Et</th>
                                    <th>Sil</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
