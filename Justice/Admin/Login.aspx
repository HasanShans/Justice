<!DOCTYPE html>
<html>
<head>

    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Admin Panel</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <%: Styles.Render("~/bundles/adminCss") %>

    </head>
<body class="error-body no-top lazy" style="background-image: url('../Admin/img/work.jpg')">
<div class="container">
    <div class="row login-container animated fadeInUp">
        <div class="col-md-7 col-md-offset-2 tiles white no-padding">
            <div class="p-t-30 p-l-40 p-b-20 xs-p-t-10 xs-p-l-10 xs-p-b-10">
                <h2 class="normal">Daxil Olun</h2>
                <p class="p-b-20" font-color="red"></p>
            </div>
            <div class="tiles grey p-t-20 p-b-20 text-black">
                <div class="grid-body no-border"> <br>
                <form id="frm_login" class="animated fadeIn" action="../api/?v=1&m=loginAdmin" method="post">

                    <div class="row form-row m-l-20 m-r-20 xs-m-l-10 xs-m-r-10">
                        <div class="col-md-6 col-sm-6 ">
                            <input id="login_username" name="login" type="text"  class="form-control" placeholder="Enter Login">
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <input id="login_pass" type="password" name="pass"  class="form-control" placeholder="Enter Password">
                        </div>
                    </div>
                    <div class="row p-t-10 m-l-20 m-r-20 xs-m-l-10 xs-m-r-10">
                        <div class="control-group  col-md-12">
                                <button type="submit"  class="btn btn-primary btn-cons pull-right" id="login_toggle">Login</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
    </div>
    <%: Scripts.Render("~/bundles/adminJs") %>


</body>



</html>