<%@ Page Title="Məhsul redaktə et" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Justice.Admin.Edit.Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">
            <div class="col-md-12">
                <div class="grid simple">
                    <div class="grid-title no-border">
                        <h4>Edit <span class="semi-bold">Product</span>
                            <br />
                            <span style="font-size: 13px; color: #0aa699;"></span></h4>
                        <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                    </div>
                    <div class="grid-body no-border">
                        <br>
                        <form action="" method="POST" enctype="multipart/form-data">
                            <div class="form-group">
                                <label class="form-label">Məhsulun adı</label>
                                <span class="help">e.g. "Moto x"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type='text' name='product_name' value='".$json->data[0]->product_name."' id='form1Name' class='form-control'>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Məhsulun Ölçüsü</label>
                                <span class="help">xx "metr"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type='text' name='size' value='".$json->data[0]->size."' id='form1Size' class='form-control'>
                                    <input type="hidden" name="_token" value="nI34N2Y1to3NYJ3Cp4LIIDO7y2O9TM5NzKai6r9I">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Məhsul haqqında əlavə məlumat </label>
                                <span class="help">Məs: "dekor"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <textarea style='resize: vertical; max-width: 100%;' rows='9' name='description' value='' class='form-control'>".$json->data[0]->description."</textarea>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="form-label">İstehsal Yeri</label>
                                <select class="form-control" name="jail_id" value="">
                                    <option value='".$data->id."'>".$data->jail_name."</option>

                                </select>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Ağırlıq</label>
                                <span class="help">e.g. "kq"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type='text' name='weight' value='".$json->data[0]->weight."' id='form1Size' class='form-control'>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Anbardakı Sayı</label>
                                <span class="help">e.g. "say"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type='text' name='amount' value='".$json->data[0]->amount."' id='form1Size' class='form-control'>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">İstehsalçı</label>
                                <select class="form-control" name="prisoner_id" value="">
                                    <option value='".$data->id."'>".$data->name." ".$data->lastname."</option>

                                </select>
                            </div>

                            <div class="form-group">
                                <label class="form-label">Kateqoriyası</label>
                                <select class="form-control" name="category_id" value="">
                                    <option value='".$data->id."'>".$data->category_name."</option>

                                </select>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Qiyməti</label>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type='text' name='price' value='".$json->data[0]->price."' id='form1Size' class='form-control'>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Endirim qiyməti</label>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type='text' name='discount' value='".$json->data[0]->discount."' id='form1Size' class='form-control'>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Satış məsələsi </label>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type="radio" name="soon" value="0" checked>
                                    Satışda<br>
                                    <input type="radio" name="soon" value="1">
                                    Tezliklə Satışda<br>
                                </div>
                            </div>
                            <div class="form-actions">
                                <div class="pull-right">
                                    <button type="submit" class="btn btn-danger btn-cons"><i class="icon-ok"></i>Save</button>
                                    <button type="button" class="btn btn-white btn-cons">Cancel</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
