using System;
using System.Web.Optimization;
using System.Web.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Justice
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", "", "~/Index.aspx");
            routes.MapPageRoute("IndexRoute", "ana-səhifə", "~/Index.aspx");
            routes.MapPageRoute("ContactRoute", "əlaqə", "~/Contact.aspx");
            routes.MapPageRoute("LoginRoute", "login", "~/Login.aspx");
            routes.MapPageRoute("registerRoute", "qeydiyyat", "~/Register.aspx");
            routes.MapPageRoute("ChangePasswordRoute", "yeni-şifrə", "~/ChangePassword.aspx");
            routes.MapPageRoute("ConfirmOrderRoute", "sifarişi-təsdiqlə", "~/ConfirmOrder.aspx");
            routes.MapPageRoute("ErrorRoute", "xəta", "~/Error.aspx");
            routes.MapPageRoute("ForgotPasswordRoute", "şifrəmi-unutdum", "~/ForgotPassword.aspx");
            routes.MapPageRoute("InformationRoute", "şəxsi-məlumatlar", "~/Information.aspx");
            routes.MapPageRoute("OrdersRoute", "sifarişlərim", "~/Orders.aspx");
            routes.MapPageRoute("PointsRoute", "xallar", "~/Points.aspx");
            routes.MapPageRoute("ReceiptsRoute", "qəbzlər", "~/Receipts.aspx");
            routes.MapPageRoute("ProductRoute", "məhsul", "~/Product.aspx");
            routes.MapPageRoute("ProductsFilterRoute", "məhsul-filter", "~/ProductsFilter.aspx");
            routes.MapPageRoute("PurchaseRoute", "səbət", "~/Purchase.aspx");
            routes.MapPageRoute("RecoverPasswordRoute", "şifrə-bərpası", "~/RecoverPassword.aspx");
            routes.MapPageRoute("", "root/məhsullar", "~/Staff/Products.aspx");
            routes.MapPageRoute("", "root/həbsxanalar", "~/Staff/Jails.aspx");
            routes.MapPageRoute("", "root/məhbuslar", "~/Staff/Prisoners.aspx");
            routes.MapPageRoute("", "root/alıcılar", "~/Staff/Users.aspx");
            routes.MapPageRoute("", "root/satıcılar", "~/Staff/Admins.aspx");
            routes.MapPageRoute("", "root/sifarişlər", "~/Staff/Orders.aspx");
            routes.MapPageRoute("", "root/login", "~/Staff/Login.aspx");
            routes.MapPageRoute("", "root/çatdırılmış-sifarişlər", "~/Staff/DeliveredOrders.aspx");
            routes.MapPageRoute("", "root/kateqoriyalar", "~/Staff/Categories.aspx");
            routes.MapPageRoute("", "root/sifarişlər-məhsula-görə", "~/Staff/OrdersByProduct.aspx");
            routes.MapPageRoute("", "root/sifarişlər-həbsxanaya-görə", "~/Staff/OrdersByJail.aspx");
            routes.MapPageRoute("", "root/sifarişlər-statistika", "~/Staff/OrderStatistics.aspx");
            routes.MapPageRoute("", "root/yeni-kateqoriya", "~/Staff/Add/Category.aspx");
            routes.MapPageRoute("", "root/yeni-məhsul", "~/Staff/Add/Product.aspx");
            routes.MapPageRoute("", "root/yeni-admin", "~/Staff/Add/Admin.aspx");
            routes.MapPageRoute("", "root/yeni-məhbus", "~/Staff/Add/Prisoner.aspx");
            routes.MapPageRoute("", "root/yeni-həbsxana", "~/Staff/Add/Jail.aspx");
            routes.MapPageRoute("", "root/notfound", "~/error/admin/404.aspx");
            routes.MapPageRoute("", "root/server-error", "~/error/admin/500.aspx");
            routes.MapPageRoute("", "root/forbidden", "~/error/admin/403.aspx");
            routes.MapPageRoute("", "error/notfound", "~/error/main/404.aspx");
            routes.MapPageRoute("", "error/server-error", "~/error/main/500.aspx");
            routes.MapPageRoute("", "error/forbidden", "~/error/main/403.aspx");
        }
    }
}