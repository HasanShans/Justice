<%@ Page Title="Məhsul əlavə et" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Justice.Admin.Add.Product1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-content ">
        <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
        <div class="clearfix"></div>
        <div class="content">

            <div class="col-md-12">
                <div class="grid simple">
                    <div class="grid-title no-border">
                        <h4>Məhsul  <span class="semi-bold">əlavə et</span>
                            <br />
                            <span style="font-size: 13px; color: #0aa699;"></span></h4>
                        <div class="tools"><a href="javascript:;" class="collapse"></a><a href="#grid-config" data-toggle="modal" class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a></div>
                    </div>
                    <div class="grid-body no-border">
                        <br>
                        <form action='' method='POST' enctype='multipart/form-data'>
                            <div class="form-group">
                                <label class="form-label">Məhsulun adı</label>
                                <span class="help">Məs :"Nərd"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type="text" name="product_name" value="" id="form1Name" class="form-control">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Məhsulun ölçüsü</label>
                                <span class="help">En x uzunluq x hündürlük </span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type="text" name="size" value="" id="form1Size" class="form-control ">
                                    <input type="hidden" name="_token" value="nI34N2Y1to3NYJ3Cp4LIIDO7y2O9TM5NzKai6r9I">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Material növü</label>
                                <span class="help">Məs: "Taxta"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type="text" name="raw" value="" id="form1Name" class="form-control">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Məhsul haqqında əlavə məlumat </label>
                                <span class="help">Məs: "dekor"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <textarea style="resize: vertical; max-width: 100%;" rows="9" name="description" class="form-control"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">İstehsal yeri</label>
                                <select class="form-control" name="jail_id" value="">
                                    <option value='".$data->id."'>".$data->jail_name."</option>
                                    "
                                </select>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Ağırlıq</label>
                                <span class="help">e.g. "kq"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type="number" name="weight" value="" id="form1Weight" class="form-control ">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Anbardakı sayı</label>
                                <span class="help">e.g. "say"</span>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type="number" name="amount" value="" id="form1Number" class="form-control ">
                                    <input type="hidden" name="_token" value="nI34N2Y1to3NYJ3Cp4LIIDO7y2O9TM5NzKai6r9I">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">İstehsalçı</label>
                                <select class="form-control" name="prisoner_id" value="">
                                    <option value='".$data->id."'>".$data->name." ".$data->lastname."</option>
                                    "
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
                                    <input type="number" name="price" value="" id="form1Name" class="form-control ">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Endirim qiyməti</label>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input type="number" name="discount" value="" id="form1Name" class="form-control ">
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="form-label">Məhsulun şəkli</label>
                                <div class="input-with-icon  right">
                                    <i class=""></i>
                                    <input style="border-style: none" type="file" name="image1" multiple>
                                    <input style="border-style: none" type="file" name="image2" multiple>
                                    <input style="border-style: none" type="file" name="image3" multiple>
                                    <input style="border-style: none" type="file" name="image4" multiple>
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
                                    <button type="submit" class="btn btn-danger btn-cons"><i class="icon-ok"></i>Yadda saxla</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
