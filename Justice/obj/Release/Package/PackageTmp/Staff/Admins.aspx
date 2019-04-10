<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Admins.aspx.cs" Inherits="Justice.Staff.Admins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
        <h1>Satıcılar
                    <small>bütün satıcılar</small>
        </h1>
        <ol class="breadcrumb">
            <li><i class="fa fa-dashboard"></i>Staff</li>
            <li class="active">Satıcılar</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <asp:HyperLink runat="server" CssClass="btn btn-success" Style="margin:10px;" ID="test2" NavigateUrl="~/root/yeni-admin" Text="Admin əlavə et"></asp:HyperLink>
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped">
                            <col width="330">
                            <col width="330">
                            <col width="330">
                            <col width="50">
                            <col width="50">
                            <thead>
                                <tr>
                                    <th>Ləqəb</th>
                                    <th>Şifrə</th>
                                    <th>Həbsxana</th>
                                    <th>Redaktə Et</th>
                                    <th>Sil</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtAdmins" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("UserName") %></td>
                                            <td><%#Eval("DecryptedPass") %></td>
                                            <td><%#Eval("JailName") %></td>
                                            <td>
                                                <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                                                <asp:Button runat="server" CssClass='btn btn-primary btn-sm' OnClick="AdminEditClick" Text="Redaktə Et"></asp:Button>
                                            </td>
                                            <td>
                                                <asp:Button runat="server" CssClass='btn btn-danger btn-sm' OnClick="AdminDeleteClick"
                                                    OnClientClick="return confirm('Siz bu admini silmək istədiyinizdən əminsiniz? Silinmiş məlumat geri qaytarıla bilməz.');" Text="Ləğv Et"></asp:Button>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Ləqəb</th>
                                    <th>Şifrə</th>
                                    <th>Həbsxana</th>
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
