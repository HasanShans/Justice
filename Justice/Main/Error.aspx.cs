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
            if (Request.QueryString["statusCode"] == "404")
            {
                error404.Visible = true;
                error500.Visible = false;
            }else if(Request.QueryString["statusCode"] == "500")
            {
                error404.Visible = false;
                error500.Visible = true;
            }
            else if(Request.QueryString["statusCode"] == "503")
            {
                error404.Visible = false;
                error500.Visible = true;
            }
        }
    }
}