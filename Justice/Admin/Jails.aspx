<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Jails.aspx.cs" Inherits="Justice.Admin.Jails" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Data Table With Full Features</h3>
                    </div>
                    <asp:HyperLink runat="server" CssClass="btn btn-primary" Style="margin-bottom: 20px" ID="test2" NavigateUrl="~/Admin/Add/Jail.aspx" Text="Həbsxana əlavə et"></asp:HyperLink>
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Ad</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtJails" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("ID") %></td>
                                            </td><%#Eval("JailName") %></td>
                                            <td>
                                                <asp:Button runat="server" CssClass='btn btn-primary btn-sm' OnClick="JailEditClick" Text="Redaktə Et"></asp:Button>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblJailID" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                                                <asp:Button runat="server" CssClass='btn btn-danger btn-sm' OnClick="JailDeleteClick" 
                                                OnClientClick="return confirm('Siz bu həbsxananı silmək istədiyinizdən əminsiniz? Silinmiş məlumat geri qaytarıla bilməz.');" Text="Ləğv Et"></asp:Button>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>Ad</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
