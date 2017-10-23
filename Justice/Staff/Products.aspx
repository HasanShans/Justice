<%@ Page Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Justice.Staff.Products" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="Content1" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">
            <div class="row-fluid">
                <div class="span12">
                    <div class="grid simple ">
                        <div class="grid-title">
                            <h4><span class="semi-bold">Məhsullar</span>
                                <br />
                                <span style="font-size: 13px; color: #0aa699;"></span></h4>
                            <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                        </div>
                        <div class="grid-body ">
                            <asp:HyperLink runat="server" CssClass="btn btn-primary" Style="margin-bottom: 20px" ID="test2" NavigateUrl="~/Staff/Add/Product.aspx" Text="Məhsul əlavə et"></asp:HyperLink>
                            <asp:Repeater ID="rprtPoducts" runat="server">
                                <HeaderTemplate>
                                    <table class="table" id="example3">
                                        
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
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>

                                        <tr class='odd gradeX'>
                                            <td><%#Eval("ID") %></td>
                                            <td><%#Eval("Code") %></td>
                                            <td><%#Eval("ProductName") %></td>
                                            <td><%#Eval("CategoryName") %></td>
                                            <td><%#Eval("JailName") %></td>
                                            <td><%#Eval("LastName") + " " + Eval("FirstName") %></td>
                                            <td>
                                                <asp:Button runat="server" CssClass='btn btn-primary btn-sm' OnClick="ProductEditClick" Text="Redaktə Et"></asp:Button>
                                            <td>
                                                <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ID") %>' Visible="false" />
                                                <asp:Button runat="server" CssClass='btn btn-danger btn-sm' OnClick="ProductDeleteClick" OnClientClick="return confirm('Siz bu məhsulu silmək istədiyinizdən əminsiniz? Silinmiş məlumat geri qaytarıla bilməz.');" Text="Ləğv Et
                                                    "></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
