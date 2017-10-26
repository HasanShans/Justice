<%@ Page Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Points.aspx.cs" Inherits="Justice.Main.Points" Title="Xallar"%>

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
                        <h3>Xallarım</h3>
                    </div>
                    <table class="table   table-bordered table-responsive">
                        <thead>
                            <tr>
                                <th>Xallarınız</th>
                                <th>100</th>
                                <th>5AZN</th>
                            </tr>

                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-center" colspan="3">Xalınızla məhsul almaq üçün minumum xalınız 500 olmalıdır</td>

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
