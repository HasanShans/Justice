<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Jails.aspx.cs" Inherits="Justice.Admin.Jails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">
            <div class="row-fluid">
                <div class="span12">
                    <div class="grid simple ">
                        <div class="grid-title">
                            <h4><span class="semi-bold">Cəzaçəkmə müəssisəsiləri</span>
                                <br />
                                <span style="font-size: 13px; color: #0aa699;"></span></h4>
                            <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                        </div>
                        <div class="grid-body">
                            <a href="Add/Jail.aspx">
                                <button class="btn btn-primary" style="margin-bottom: 20px" id="test2">Cəzaçəkmə müəssisəsi əlavə et</button></a>
                            <table class="table" id="example3">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Ad</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <tr class='odd gradeX'>
                                        <td>".$data->id."</td>
                                        <td>".$data->jail_name."</td>
                                        <td><a href='edit_jail.php?id=".$data->id."'>
                                            <button type='button' class='btn btn-primary btn-sm'>Redaktə et</button></a></td>
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
