<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftSideBar.ascx.cs" Inherits="Justice.Controls.Admin.LeftSideBar" %>

<div class="page-sidebar " id="main-menu">
    <div class="page-sidebar-wrapper" id="main-menu-wrapper">
        <p class="menu-title">BROWSE <span class="pull-right"><a href="javascript:;"><i class="fa fa-refresh"></i></a></span></p>
        <ul>
            <li class='start'><a href='http://localhost:50857/Admin/Categories.aspx'><i class='fa fa-rocket'></i><span class='title'>Kateqoriyalar </span><span class='selected'></span></span> </a></li>
            <li class='start'><a href='http://localhost:50857/Admin/Jails.aspx'><i class='fa fa-globe'></i><span class='title'>Cəzaçəkmə müəssisəsi</span> <span class='selected'></span></span> </a></li>
            <li class=''><a href='http://localhost:50857/Admin/Orders.aspx'><i class='fa fa-suitcase'></i><span class='title'>Sifarişlər</span></a></li>
            <li class=''><a href='http://localhost:50857/Admin/PostDeliveredOrders.aspx'><i class='fa fa-suitcase'></i><span class='title'>Poçta çatdırılmış sifarişlər</span></a></li>
            <li class=''><a href='http://localhost:50857/Admin/DeliveredOrders.aspx'><i class='fa fa-suitcase'></i><span class='title'>Çatdırılmış sifarişlər</span></a></li>
            <li class=''><a href='http://localhost:50857/Admin/Products.aspx'><i class='fa fa-heart'></i><span class='title'>Məhsullar</span></a></li>
            <li class=''><a href='../api/?v=1&m=logoutAdmin'><i class='fa fa-power-off'></i><span class='title'>Çıxış</span></a></li>
        </ul>

        <div class="clearfix"></div>
    </div>
</div>

<div class="footer-widget">
    <div class="progress transparent progress-small no-radius no-margin">
        <div data-percentage="79%" class="progress-bar progress-bar-success animate-progress-bar"></div>
    </div>
    <div class="pull-right">
        <div class="details-status"><span data-animation-duration="560" data-value="86" class="animate-number"></span>% </div>
        <a href="/administrator/auth/logout"><i class="fa fa-power-off"></i></a>
    </div>
</div>
