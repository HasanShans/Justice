<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Justice.Main.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <section id="my_page">   
                <div class="container">
                    <div class="row">
                        <uc:LeftMenu ID="LeftMenu" runat="server" />
                        <div class="col-sm-9 col-md-9">
                            <!-- <div class="well"> -->
                                <div class="title">
                                    <h3>Sifarişlərim</h3>
                                </div>
                                <table class="table  table-bordered table-responsive">
                                  <thead>
                                    <tr>
                                      <th>Məhsul</th>
                                      <th>Sifariş vaxtı</th>
                                      <th>Məhsul sayı</th>
                                      <th> Məbləğ</th>
                                    </tr>
                                  </thead>
                                  <tbody>
                                    <tr>
                                        <td>Təsbeh</td>
                                        <td>11.03.2017</td>
                                        <td>2</td>
                                        <td >80AZN</td>

                                    </tr>
                                  </tbody>
                                </table>
                            <!-- </div> -->
                        </div>
                    </div>
                </div>

                
            </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
