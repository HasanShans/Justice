using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice
{
    public partial class LeftSideBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["NAME"] = null;
            Session["EMAIL"] = null;
            Session["ID"] = null;
            Response.Redirect("~/ana-səhifə");
        }

    }
}