using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice.error.main
{
    public partial class _500 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMINSESSION"] != null)
            {
                Response.Redirect("~/root/server-error");
            }
        }
    }
}