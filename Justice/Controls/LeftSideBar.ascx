<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftSideBar.ascx.cs" Inherits="Justice.LeftSideBar" %>

<div class="col-sm-3 col-md-3">
    <div class="panel-group" id="accordion">
        <div class="panel panel-default active  ">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><span class="glyphicon glyphicon-user">
                    </span>Mənim Səhifəm</a>
                </h4>
            </div>
            <div id="collapseThree" class="panel-collapse collapse in">
                <div class="panel-body">
                    <table class="table">
                        <tr>
                            <td>
                                <a href="information.php"><i class="fa fa-pencil"></i> Şəxsi məlumatlarım</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="password_change.php">
                                <i class="fa fa-unlock-alt"></i>Şifrə Dəyişdir</a> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="address.php">
                                <i class="fa fa-map-marker" aria-hidden="true"></i>Ünvanlarım</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="orders.php"><i class="fa fa-file-text-o"></i>Sifarişlərim</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="favorite.php"><i class="fa fa-star-o"></i>Bəyəndiklərim</a>
                            </td>
                        </tr>

    <!--                                                 <tr>
                            <td>
                                <a href="comment.php"><i class="fa fa-comments-o" aria-hidden="true"></i>Şərhlərim</a>
                            </td>
                        </tr> -->
                        <tr>
                            <td>
                                <a href="ticket.php"><i class="fa fa-credit-card" aria-hidden="true"></i>
                                Qəbzlərim</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="point.php"><i class="fa fa-hand-o-up" aria-hidden="true"></i>Xallarım</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="basket.php"><i class="fa fa-shopping-basket" aria-hidden="true"></i>Səbətim</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="api/?v=1&m=logout"><i class="fa fa-sign-out" aria-hidden="true"></i>
                                Cıxış</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
 </div>