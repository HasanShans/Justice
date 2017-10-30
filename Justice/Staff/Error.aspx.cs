using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice.Staff
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("statusCode"))
            {
                error404.Visible = true;
                error500.Visible = false;
            }
            else
            {
                error404.Visible = false;
                error500.Visible = true;
            }
        }
    }
}