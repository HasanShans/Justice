<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Receipts.aspx.cs" Inherits="Justice.Main.Receits" %>
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
                                    <h3> Qəbzlərim</h3>
                                </div>
                                <table  class="table table-responsive table-bordered">
                                  <thead>
                                    <tr>
                                      <th>#</th>
                                      <th>Tarix</th>
                                      <th>Məbləğ</th>
                                      <th>Açıqlama</th>
                                    </tr>
                                  </thead>
                                  <tbody>
                                    <tr>
                                      <th scope="row">1</th>
                                      <td>14.04.2016</td>
                                      <td>200AZN</td>
                                      <td>Nərd</td>
                                    </tr>
                                    <tr>
                                      <th scope="row">2</th>
                                      <td>15.05.2016</td>
                                      <td>50AZN</td>
                                      <td>Təsbeh</td>
                                    </tr>
                                    <tr>
                                      <th scope="row">CƏMİ ALVER QƏBZİ</th>
                                      <td colspan="3">250AZN</td>
                                    </tr>
                                  </tbody>
                                </table>
                        </div>
                    </div>
                </div>
            </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="EndContent" runat="server">
</asp:Content>
