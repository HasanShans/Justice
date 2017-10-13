<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DeliveredOrders.aspx.cs" Inherits="Justice.Admin.DeliveredOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">
            <div class="row-fluid">
                <div class="span12">
                    <div class="grid simple ">
                        <div class="grid-title">
                            <h4><span class="semi-bold">Delivered orders</span>
                                <br />
                                <span style="font-size: 13px; color: #0aa699;"></span></h4>
                            <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                        </div>

                        <div class="grid-body ">
                            <table class="table" id="example3">
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

                                    <tr class='odd gradeX'>
                                        <td>".$data->product_name." : ".$data->code."</td>
                                        <td>".$data->name." ".$data->lastname."</td>
                                        <td>".$data->total_price." AZN</td>
                                        <td>".$data->modifed."</td>
                                        <td>".$data->city."</td>
                                        <td>".$data->phone." , ".$data->home_phone."</td>
                                        <td>".$data->aze."</td>
                                        <td>".$data->poct."</td>

                                        <td><a href=''>
                                            <button type='button' class='btn btn-primary btn-sm'>Məhsula bax</button></a>
                                        </td>
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
