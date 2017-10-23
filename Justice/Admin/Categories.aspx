<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Justice.Admin.Categories" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Data Table With Full Features</h3>
                    </div>
                    <asp:HyperLink runat="server" CssClass="btn btn-primary" Style="margin-bottom: 20px" ID="test2" NavigateUrl="~/Admin/Add/Category.aspx" Text="Kateqoriya əlavə et"></asp:HyperLink>
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Adı</th>
                                </tr>
                            </thead>
                            <tbody>
                            <asp:Repeater ID="rprtCategories" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ID") %></td>
                                        <td><%# Eval("CategoryName") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                                 </tbody>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>Adı</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
