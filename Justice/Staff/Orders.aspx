<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Justice.Staff.Orders" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
                    <h1>Sifarişlər
                    <small>bütün sifarişlər</small>
                    </h1>
                   <ol class="breadcrumb">
                        <li><i class="fa fa-dashboard"></i>Staff</li>
                        <li class="active">Sifarişlər</li>
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
