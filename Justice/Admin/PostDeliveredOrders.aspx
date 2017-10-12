﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PostDeliveredOrders.aspx.cs" Inherits="Justice.Admin.PostDeliveredOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">
            <div class="row-fluid">
                <div class="span12">
                    <div class="grid simple ">
                        <div class="grid-title">
                            <h4><span class="semi-bold">Poçta çatdırılmış məhsullar</span>
                                <br />
                                <span style="font-size: 13px; color: #0aa699;"></span></h4>
                            <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                        </div>

                        <div class="grid-body ">
                            <!--   <a href="create_product.php"> <button class="btn btn-primary"  style="margin-bottom:20px" id="test2">Add Product</button></a> -->

                            <table class="table" id="example3">
                                <thead>
                                    <tr>
                                        <th>MƏHSUL KODU</th>
                                        <th>Müştəri</th>
                                        <th>Məbləğ</th>
                                        <th>Poçta çatdırıldı</th>
                                        <th>Şəhər</th>
                                        <th>Telefon</th>
                                        <th>Seriya №</th>
                                        <th>zip</th>
                                        <th></th>
                                        <th></th>

                                    </tr>
                                </thead>
                                <tbody>

                                    <tr class='odd gradeX'>
                                        <td>".$data->product_name." : ".$data->code."</td>
                                        <td>".$data->name." ".$data->lastname."</td>
                                        <td>".$data->total_price." AZN</td>
                                        <td>".$data->poct_modifed."</td>
                                        <td>".$data->city."</td>
                                        <td>".$data->phone." , ".$data->home_phone."</td>
                                        <td>".$data->aze."</td>
                                        <td>".$data->poct."</td>

                                        <td><a href=''>
                                            <button type='button' class='btn btn-warning btn-sm' title='Məhsula bax'><i class='fa fa-eye' aria-hidden='true'></i></button>
                                        </a></td>
                                        <td><a href=''>
                                            <button type='button' class='btn btn-primary btn-circle' title='Təhvil verildi'><i class='glyphicon glyphicon-ok'></i></button>
                                        </a></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
