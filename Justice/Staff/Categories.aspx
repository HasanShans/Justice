<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Justice.Staff.Categories" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">
            <div class="row-fluid">
                <div class="span12">
                    <div class="grid simple ">
                        <div class="grid-title">
                            <h4><span class="semi-bold">Kateqoriyalar</span><br />
                                <span style="font-size: 13px; color: #0aa699;" /></h4>
                            <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                        </div>

                        <div class="grid-body ">
                                <asp:HyperLink runat="server" CssClass="btn btn-primary" style="margin-bottom: 20px" ID="test2" NavigateUrl="~/Staff/Add/Category.aspx" Text="Kateqoriya əlavə et"></asp:HyperLink>
                            <asp:Repeater ID="rprtCategories" runat="server">
                                <HeaderTemplate>
                                    <table class="table" id="example3">
                                        <col width="100" />
                                        <col width="400" />
                                        <col width="20" />
                                        <col width="20" />
                                        <thead>
                                            <tr>
                                                <th>ID</th>
                                                <th>Ad</th>
                                                <th>Redakte et</th>
                                                <th>Ləğv et</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>

                                        <tr class='odd gradeX'>
                                            <td><%#Eval("ID") %></td>
                                            <td><%#Eval("CategoryName") %></td>
                                            <td>
                                                <asp:Button runat="server" CssClass='btn btn-primary btn-sm' OnClick="CategoryEditClick"  Text="Redaktə Et"></asp:Button>
                                            <td>
                                                <asp:Label ID="lblCatID" runat="server" Text='<%# Eval("ID") %>' visible="false"/>
                                                <asp:Button runat="server" CssClass='btn btn-danger btn-sm' OnClick ="CategoryDeleteClick" OnClientClick="return confirm('Siz bu kateqoriyanı silmək istədiyinizdən əminsiniz? Silinmiş məlumat geri qaytarıla bilməz.');" Text="Ləğv Et
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
