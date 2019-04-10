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
                                <a href="şəxsi-məlumatlar"><i class="fa fa-pencil"></i> Şəxsi məlumatlarım</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="yeni-şifrə">
                                <i class="fa fa-unlock-alt"></i>Şifrə Dəyişdir</a> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="sifarişlərim"><i class="fa fa-file-text-o"></i>Sifarişlərim</a>
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                                <a href="qəbzlər"><i class="fa fa-credit-card" aria-hidden="true"></i>
                                Qəbzlərim</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="xallar"><i class="fa fa-hand-o-up" aria-hidden="true"></i>Xallarım</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="səbət"><i class="fa fa-shopping-basket" aria-hidden="true"></i>Səbətim</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton runat="server" OnClick="btnSignOut_Click" CausesValidation="false"><i class="fa fa-sign-out" aria-hidden="true"></i>
                                Cıxış</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
 </div>