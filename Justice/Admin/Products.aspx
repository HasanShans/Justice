<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Justice.Admin.Products" %>

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
                            <a href="Add/Product.aspx">
                                <button class="btn btn-primary" style="margin-bottom: 20px" id="test2">Məhsul əlavə et</button></a>
                            <table class="table" id="example3">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Məhsul kodu</th>
                                        <th>Kateqoriya</th>
                                        <th>Ad</th>
                                        <th>Cəzaçəkmə müəssisəsi</th>
                                        <th>Məhbus</th>
                                        <th>Redakte et</th>
                                        <th>Ləğv et</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class='odd gradeX'>
                                        <td>".$data->id."</td>
                                        <td>".$data->code."</td>
                                        <td>".$data->category_name."</td>
                                        <td>".$data->product_name."</td>
                                        <td>".$data->jail_name."</td>
                                        <td>".$data->name." ".$data->lastname."</td>
                                        <td><a href='edit_product.php?id=".$data->code."'>
                                            <button type='button' class='btn btn-primary btn-sm'>Redakte et</button></a></td>
                                        <td><a href=''>
                                            <button type='button' class='btn btn-danger btn-sm'>Ləğv et</button></a></td>
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
