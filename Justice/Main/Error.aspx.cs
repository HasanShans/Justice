using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice.Main
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMINSESSION"] != null)
            {
                if (Request.QueryString["statusCode"] == "404")
                {
                    Response.Redirect("~/Staff/Error.aspx?statusCode=404");
                }
                else
                {
                    Response.Redirect("~/Staff/Error.aspx");
                }
            }
            else {
                if (Request.QueryString["statusCode"] == "404")
                {
                    error404.Visible = true;
                    error500.Visible = false;
                } else 
                {
                    error404.Visible = false;
                    error500.Visible = true;
                }
            }
        }
    }
}