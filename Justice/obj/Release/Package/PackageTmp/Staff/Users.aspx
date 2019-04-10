<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Justice.Staff.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Istifadəçilər
                    <small>bütün istifadəçilər</small>
        </h1>
        <ol class="breadcrumb">
            <li><i class="fa fa-dashboard"></i>Staff</li>
            <li class="active">Istifadəçilər</li>
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
                                    <th>Ad</th>
                                    <th>Soyad</th>
                                    <th>Email</th>
                                    <th>Seriya nömrəsi</th>
                                    <th>Doğum tarixi</th>
                                    <th>Şəhər</th>
                                    <th>Telefon (əl)</th>
                                    <th>Telefon (ev)</th>
                                    <th>Hesab</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rprtUsers" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("FirstName") %></td>
                                            <td><%# Eval("LastName") %></td>
                                            <td><%# Eval("Email") %></td>
                                            <td><i>AZE</i> <%# Eval("IDSerialNumber") %></td>
                                            <td><%# Eval("BirthDate") %></td>
                                            <td><%# Eval("City") %></td>
                                            <td><%# Eval("MobilePhone") %></td>
                                            <td><%# Eval("HomePhone") %></td>
                                            <td> <%# ((int)Eval("Verified") == 1) ? "Təsdiqlənib" : "Təsdiqlənməyib" %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                
                                <tr>
                                    <th>Ad</th>
                                    <th>Soyad</th>
                                    <th>Email</th>
                                    <th>Seriya nömrəsi</th>
                                    <th>Doğum tarixi</th>
                                    <th>Şəhər</th>
                                    <th>Telefon (əl)</th>
                                    <th>Telefon (ev)</th>
                                    <th>Hesab</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
