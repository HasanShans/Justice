<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="Justice.Main.ConfirmOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="basket">
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <div class="basket_about">
                        <div style="margin-bottom: 15px;" class="title">
                            <h3>Sizini Sifarişiniz</h3>
                            <div class="panel-body">
                                <div class="col-md-12">
                                    <strong>Məhsul Ədədi</strong>
                                    <div class="pull-right"><span></span><span></span></div>
                                </div>
                                <div class="col-md-12">
                                    <strong>Ümumi Məbləğ</strong>
                                    <div class="pull-right"><span></span><span>AZN</span></div>
                                </div>
                                <div class="col-md-12">
                                    <strong>Çatdırılma</strong>
                                    <div class="pull-right"><span></span><span>0 AZN</span></div>
                                </div>
                                <br>
                                <br>
                                <br>
                                <br>
                                <hr>
                                <div class="col-md-12">
                                    <strong>Ödəniləcək Məbləğ</strong>
                                    <div class="pull-right"><span></span><span>AZN</span></div>
                                    <hr>
                                </div>
                            </div>
                            <form action="https://mpi.3dsecure.az/cgi-bin/cgi_link" method="POST">
                                <button name="buy" type="submit" style="width: 100%;" class="btn btn-success ">Dərhal Ödə  <i class="fa fa-chevron-right " aria-hidden="true"></i></button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
