<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.cs" Inherits="Justice.Main.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <section id="user">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="title">
                        <h3>Qeydiyyatdan keç</h3>
                    </div>
                    <div class="register">
                        <form action="api/?v=1&m=signup" method="POST">
                            <div class="form-group row">
                                <label for="inputName3" class="col-sm-3 col-form-label">Ad </label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" name="name" id="inputName3" placeholder="Adınızı daxil edin">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputSurname3" class="col-sm-3 col-form-label">Soyad </label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" name="lname" id="inputSurname3" placeholder="Soyadınızı daxil edin">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputEmail3" class="col-sm-3 col-form-label">Email </label>
                                <div class="col-sm-9">
                                    <input type="email" class="form-control" name="mail" id="inputEmail3" placeholder="Email">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-3 col-form-label">Şifrə</label>
                                <div class="col-sm-9">
                                    <input type="password" class="form-control" name="pass" id="inputPassword3" placeholder="Şifrə">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="inputPassword3" class="col-sm-3 col-form-label">Şifrə Təkrar</label>
                                <div class="col-sm-9">
                                    <input type="password" class="form-control" name="dublpass" id="inputPassword3" placeholder="Şifrə Təkrar">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="birthDate" class="col-sm-3 control-label">Doğum tarixiniz</label>
                                <div class="col-sm-9">
                                    <input type="date" id="birthDate" name="birthday" class="form-control">
                                </div>
                            </div>

                            <div class="form-group row ">
                                <div class="col-sm-9 col-sm-offset-3">
                                    <div class="form-check">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input ">
                                            Email vasitəsilə məlumatlandırılmaq istəyirəm

                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group row ">
                                <div class="col-sm-9 col-sm-offset-3">
                                    <div class="form-check">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input ">
                                            <a href="">Müqaviləni oxudum ,anladım və təsdiqləyirəm</a>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class=" col-sm-12">
                                    <button type="submit" class="btn btn-success pull-right">
                                        Qydiyyatdan Keç <i class="fa fa-check" aria-hidden="true"></i>
                                    </button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
