<%@ Page Title="Məhsul əlavə et" Language="C#" MasterPageFile="~/Staff/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Justice.Staff.Add.Product1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Yeni Məhsul</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="form-label">Məhsulun adı *</label>
                            <span class="help">Məs :"Nərd"</span>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="text-danger" runat="server" ErrorMessage="Məhsul Adı Boş Qoyula Bilməz" ControlToValidate="txtPname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Məhsulun ölçüsü *</label>
                            <span class="help">En x uzunluq x hündürlük </span>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPsize" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="text-danger" runat="server" ErrorMessage="Məhsul Ölçüsü Boş Qoyula Bilməz" ControlToValidate="txtPsize" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Material növü *</label>
                            <span class="help">Məs: "Taxta"</span>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPMaterial" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="text-danger" runat="server" ErrorMessage="Məhsulun Materialı Boş Qoyula Bilməz" ControlToValidate="txtPMaterial" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Məhsul haqqında əlavə məlumat </label>
                            <span class="help">Məs: "dekor"</span>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPdescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">İstehsal yeri *</label>
                            <asp:DropDownList ID="ddlJails" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ErrorMessage="İstehsal Yeri Boş Qoyula Bilməz" ControlToValidate="ddlJails" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Ağırlıq (kq)</label>
                            <span class="help">e.g "3.2"</span>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPweight" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ControlToValidate="txtPweight" ID="RegularExpressionValidator2" ValidationExpression="^\d+(\.\d+)*$" runat="server" ErrorMessage="Məhsulun Çəkisi Ədəd Olmalıdır (Məs; 3.5 , 4 , 6)" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Anbardakı sayı *</label>
                            <span class="help">e.g. "say"</span>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPamount" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="Məhsulun Anbardakı Sayı Boş Qoyula Bilməz" ControlToValidate="txtPamount" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">İstehsalçı *</label>
                            <asp:DropDownList ID="ddlPrisoners" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="Məhbus Adı Boş Qoyula Bilməz" ControlToValidate="ddlPrisoners" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="form-label">Kateqoriyası *</label>
                            <asp:DropDownList ID="ddlCategories" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Məhsulun Kateqoriyası Boş Qoyula Bilməz" ControlToValidate="ddlCategories" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Qiyməti *</label>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPprice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Məhsulun Qiyməti Boş Qoyula Bilməz" ControlToValidate="txtPprice" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Endirim qiyməti *</label>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:TextBox ID="txtPdiscountPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Məhsulun Endirim Qiyməti Şəkil Boş Qoyula Bilməz" ControlToValidate="txtPdiscountPrice" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="form-label">Məhsulun şəkli</label>
                            <span class="help">(Minimum şəkil sayı 1)</span>
                            <div class="input-with-icon  right">
                                <i class=""></i>
                                <asp:FileUpload ID="img1p" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Birinci Şəkil Boş Qoyula Bilməz" ControlToValidate="img1p" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator><br />
                                <asp:FileUpload ID="img2p" CssClass="form-control" runat="server" /><br />
                                <asp:FileUpload ID="img3p" CssClass="form-control" runat="server" /><br />
                                <asp:FileUpload ID="img4p" CssClass="form-control" runat="server" /><br />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="form-label">Məhsulun Mövcudluğu *</label>
                            <div class="input-with-icon  right">
                                <asp:RadioButtonList ID="rblPavailability" runat="server">
                                    <asp:ListItem>Satışda</asp:ListItem>
                                    <asp:ListItem>Tezliklə Satışda</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="text-danger" runat="server" ErrorMessage="Bu Sahə Boş Qoyula Bilməz" ControlToValidate="rblPavailability" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="pull-right">
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success btn-cons" OnClick="btnSave_Click" Visible="false" Text="Əlavə Et"></asp:Button>
                                <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-warning btn-cons" Visible="false" OnClick="btnSave_Click" Text="Yenilə"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
