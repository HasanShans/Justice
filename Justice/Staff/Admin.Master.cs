using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice.Staff
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMINSESSION"] == null)
            {
                Response.Redirect("~/root/login");
            }
            else
            {
                if (Session["ADMINSESSION"].ToString() != "Admin")
                {
                    users.Visible = false;
                    jails.Visible = false;
                    prisoners.Visible = false;
                    categories.Visible = false;
                    orders.Visible = false;
                    ordersByJail.Visible = true;
                }
            }
        }

        protected void adminLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/root/login");
        }
    }
}