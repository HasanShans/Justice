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
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (Session["NAME"] == null)
            {
                linkLoginReg.Visible = true;
                linkCart.Visible = false;
                linkLiked.Visible = false;
                linkMypage.Visible = false;
                linkNameEmail.Visible = false;
            }
            else
            {
                linkLoginReg.Visible = false;
                linkCart.Visible = true;
                linkLiked.Visible = true;
                linkMypage.Visible = true;
                linkNameEmail.Visible = true;
                var yourspan = new HtmlGenericControl("span");
                yourspan.InnerHtml = "the text inside your span ";
                yourspan.Attributes["id"] = "spanName";
                pannel.Controls.Add(yourspan);
            }
        }
    }
}