<%@ Page Title="Sifarişi Təsdiqlə" Language="C#" MasterPageFile="SiteWF.master" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="Justice.ConfirmOrder" %>

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
                                    <div class="pull-right"><span></span><span><asp:Label runat="server" ID="lblProductCount" Text="0"></asp:Label></span></div>
                                </div>
                                <div class="col-md-12">
                                    <strong>Ümumi Məbləğ</strong>
                                    <div class="pull-right"><span></span><span><asp:Label runat="server" ID="lbltotaPrice" Text="0"></asp:Label> AZN</span></div>
                                </div>
                                <div class="col-md-12">
                                    <strong>Çatdırılma</strong>
                                    <div class="pull-right"><span></span><span><asp:Label runat="server" ID="lblShippingPrice" Text="0"></asp:Label> AZN</span></div>
                                </div>
                                <br>
                                <br>
                                <br>
                                <br>
                                <hr>
                                <div class="col-md-12">
                                    <strong>Ödəniləcək Məbləğ </strong>
                                    <div class="pull-right"><span></span><span><asp:Label runat="server" ID="lblTotalPayment" Text="0"></asp:Label> AZN</span></div>
                                    <hr>
                                </div>
                            </div>
                            <form action="https://mpi.3dsecure.az/cgi-bin/cgi_link" method="POST">
                                <%--<input name="AMOUNT" value="<%=PaymentAmount %>" type="hidden">
                                <input name="ORDER" value="<%=Order_ID %>" type="hidden">--%>
                                <input name="AMOUNT" value="<%=AMOUNT %>" type="hidden" >
                                <input name="CURRENCY" value="<%=CURRENCY %>" type="hidden">
                                <input name="ORDER" value="<%=ORDER %>" type="hidden">
                                <input name="DESC" value="<%=DESC %>" type="hidden">
                                <input name="MERCH_NAME" value="<%=MERCH_NAME %>" type="hidden">
                                <input name="MERCH_URL" value="<%=MERCH_URL %>" type="hidden">
                                <input name="TERMINAL" value="<%=TERMINAL %>" type="hidden">
                                <input name="EMAIL" value="<%=EMAIL %>" type="hidden">
                                <input name="TRTYPE" value="<%=TRTYPE %>" type="hidden">
                                <input name="COUNTRY" value="<%=COUNTRY %>" type="hidden">
                                <input name="MERCH_GMT" value="<%=MERCH_GMT %>" type="hidden">
                                <input name="TIMESTAMP" value="<%=OPER_TIME %>" type="hidden">
                                <input name="NONCE" value="<%=NONCE %>" type="hidden" >
                                <input name="BACKREF" value="<%=BACKREF %>" type="hidden" >
                                <input name="P_SIGN" value="<%=P_SIGN %>" type="hidden">
                                
                                <button name="buy" type="submit" style="width: 100%;" class="btn btn-success">Dərhal Ödə  <i class="fa fa-chevron-right " aria-hidden="true"></i></button>
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
<asp:Content ID="Content4" ContentPlaceHolderID="Extra" runat="server">

</asp:Content>
   