<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Justice.Admin.Categories" %>

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
                            <a href="Add/Category.aspx" class="btn btn-primary" style="margin-bottom: 20px" id="test2">Kateqoriya əlavə et</a>
                            <table class="table" id="example3">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Ad</th>
                                        <th>Redakte et</th>
                                        <th>Ləğv et</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repeater" runat="server">
                                        <ItemTemplate>
                                            <tr class='odd gradeX'>
                                                <td><%# Eval("ID") %></td>
                                                <td><%# Eval("CategoryName") %></td>
                                                <td>
                                                    <asp:Button ID="EditButton" CssClass="btn btn-primary btn-sm" runat="server" Text="Redaktə et" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="DeleteButton" CssClass="btn btn-danger btn-sm" runat="server" Text="Ləğv et" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
