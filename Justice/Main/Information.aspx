<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Information.aspx.cs" Inherits="Justice.Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <section id="my_page">   
        <uc:leftmenu id="leftmenu" runat="server"/>
        <div class="container">
            <div class="row">
                <div class="col-sm-9 col-md-9">
                    <div class="title">
                        <h3>Məlumatlarım</h3>
                    </div>
                    <div class="register">
                        <form action ='www.google.com' method='POST'>
                        <div class='form-group row'>
                            <label for='inputName3' class='col-sm-3 col-form-label'>Ad </label>
                            <div class='col-sm-9'>
                            <input type='text' name='name' class='form-control' id='inputName3' placeholder='Adınızı daxil edin' value='".$json->data->name."' ".$check.">
                            </div>
                        </div>
                        <div class='form-group row'>
                            <label for='inputSurname3' class='col-sm-3 col-form-label'>Soyad </label>
                            <div class='col-sm-9'>
                            <input type='text' name='lastname' class='form-control' id='inputSurname3' placeholder='Soyadınızı daxil edin' value='".$json->data->lastname."' ".$check.">
                            </div>
                        </div>
                        <div class='form-group row'>
                            <label for='inputEmail3' class='col-sm-3 col-form-label'>Email </label>
                            <div class='col-sm-9'>
                            <input type='email' class='form-control' id='inputEmail3' placeholder='Email' value='".$json->data->mail."' disabled>
                            </div>
                        </div>

                        <div class='form-group row'>
                            <label for='birthDate' class='col-sm-3 control-label'>Doğum tarixiniz</label>
                            <div class='col-sm-9'>
                            <input type='date' name='birthday' id='birthDate' class='form-control' value='".$json->data->birthday."' ".$check.">
                            </div>
                        </div>

                        <div class='form-group row'>
                            <label class='col-sm-3 control-label'>Şəxsiyyət vəsiqəsi seriya nömrəsi *</label>
                            <div class='col-sm-9'>
                                    <div class='input-group'>
								    <span class='input-group-addon'>AZE</span>
									    <input name='aze' type='text' class='form-control' value='".$json->data->aze."'  placeholder='Şəxsiyyət Vəsiqəsinin Nömrəsi xxxxxxxx' ".$check." required>
								    </div>
                            </div>
                        </div>


                        <div class='form-group row'>
                            <label for='country' class='col-sm-3 control-label'> Ya&#351;ad&#305;&#287;&#305;n&#305;z &#350;&#601;h&#601;r *</label>
                            <div class='col-sm-9'>
                                <input type='text' name='city' value='".$json->data->city."' class='form-control' id='inputName3' placeholder='Yaşadığınız şəhəri daxil edin' required>
                            </div>
                        </div> <!-- /.form-group -->


                        <div class='form-group row'>
                            <label for='inputName3' class='col-sm-3 col-form-label'>Poçt kodu *</label>
                            <div class='col-sm-9'>
                            <input type='text' name='poct' value='".$json->data->poct."' class='form-control' maxlength='6' id='inputName3' placeholder='Poçt kodunuzu daxil edin ' required>
                            </div>
                        </div>

                        <div class='form-group row'>
                            <label class='col-sm-3 control-label'>Mobil nömrə *</label>
                            <div class='col-sm-9'>
                                    <input  type='text' name='phone' value='".$json->data->phone."' class='form-control' placeholder='Mobil nömrənizi daxil edin' required/>
						    </div>
                        </div>
									
					    <div class='form-group row'>
                            <label class='col-sm-3 control-label'>Ev nömrəsi</label>
                            <div class='col-sm-9'>
                                    <input type='text' name='home_phone' value='".$json->data->home_phone."' class='form-control' placeholder='Ev nömrənizi daxil edin' required/>
						    </div>
                        </div>

                        <div class='form-group row'>
                            <div class=' col-sm-12'>
                            <button  type='submit' class='btn btn-success pull-right'> Yadda Saxla<i class='fa fa-check' aria-hidden='true'></i>
                            </button>
                            </div>
                         </div>
                       </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%: Scripts.Render("~/Scripts/Custom/jquery-3.1.1.min.js") %>
    <%: Scripts.Render("~/Scripts/Custom/bootstrap.js") %>
    <%: Scripts.Render("~/Scripts/Custom/bootstrap.min.js") %>
    <%: Scripts.Render("~/Scripts/Custom/script.js") %>
</asp:Content>