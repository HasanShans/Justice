<%@ Page Language="C#"  MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Justice.Main.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<section id="user">
<div class="container">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
			<div class="sign_in">
	            <div class="title">
	            	<h3>Daxil ol</h3>
	            </div>
	            <div class="login">
					<form action="api/?v=1&m=login" method="POST" >
				        <div class="form-group row">
					        <label for="inputEmail3" class="col-sm-2 col-form-label">Email </label>
					        <div class="col-sm-10">
					        <input type="email" name="mail" class="form-control" id="inputEmail3" placeholder="Email">
					        </div>
				        </div>
				        <div class="form-group row">
					        <label for="inputPassword3" class="col-sm-2 col-form-label">Şifrə</label>
					        <div class="col-sm-10">
					        <input  type="password" name="pass" class="form-control" id="inputPassword3" placeholder="Şifrə">
					        </div>
				        </div>
				        <div class="form-group row">
					        <div class=" col-sm-12">
					        <button  type="submit" class="btn btn-success pull-right">Daxil Ol <i class="fa fa-check" aria-hidden="true"></i>
					        </button>
					        </div>
				        </div>
			        </form>
	             </div>
              </div>
           </div>
        </div>
    </div>
</section>
</asp:Content>
