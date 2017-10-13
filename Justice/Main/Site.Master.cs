using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Justice
{
    public partial class SiteMaster : MasterPage
    {
        public string Username;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["NAME"] == null)
            {
                linkLoginReg.Visible = true;
                linkLiked.Visible = false;
                linkMypage.Visible = false;
                linkNameEmail.Visible = false;
            }
            else
            {
                this.Username = Session["NAME"].ToString();
                linkLoginReg.Visible = false;
                linkLiked.Visible = true;
                linkMypage.Visible = true;
                linkNameEmail.Visible = true;
               
            }
        }

        protected void signOut_Click(object sender, EventArgs e)
        {
            Session["NAME"] = null;
            Response.Redirect("Index.aspx");
        }
    }
}