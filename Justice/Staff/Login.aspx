<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Justice.Staff.Login" %>

<html>
<head>
    <%: Styles.Render("~/Content/Admin/css/bootstrap.css") %>
    <%: Styles.Render("~/Content/Admin/css/AdminLTE.css") %>
    <style>
        body {
            background-image: url("/Content/Admin/img/others/background.jpg");
        }

        .box {
            margin-top: 30%;
            width: 60%;
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <div class="col-md-6 col-md-offset-4">
        <div class="box box-info">
            <div class="box-header with-border">
                <h3 class="box-title">Administratorun şəxsi kabineti</h3>
            </div>
            <form class="form-horizontal">
                <div class="box-body">
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                        <div class="col-sm-10">
                            <input type="email" class="form-control" id="inputEmail3" placeholder="Email">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword3" class="col-sm-2 control-label">Şifrə</label>
                        <div class="col-sm-10">
                            <input type="password" class="form-control" id="inputPassword3" placeholder="Şifrə">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox">
                                    Yadda saxla
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <button type="submit" class="btn btn-info pull-right">Daxil ol</button>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
