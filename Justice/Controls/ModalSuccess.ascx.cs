using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justice
{
    public partial class ModalSuccess : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Label LabelModalMsg { get { return modalLabel; } }
        public HyperLink HlInformation { get { return hlInformation; } }
        public Button BtnCancel { get { return btnCancel; } }
        public HyperLink HlPurchase { get { return hlPurchase; } }
        public HyperLink HlLogin { get { return hlLogin; } }
        public HyperLink HlIndex { get { return hlIndex; } }
    }
}
