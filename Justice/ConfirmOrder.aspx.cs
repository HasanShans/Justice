using Justice.App_Code;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
namespace Justice
{
    public partial class ConfirmOrder : System.Web.UI.Page
    {
        DataTable dataTable = new DataTable();

        private string paymentAmount;
        public string PaymentAmount { set { paymentAmount = value; } get { return paymentAmount; } }
        public String ORDER;
        public String AMOUNT;
        public String CURRENCY;
        public String DESC;
        public String MERCH_NAME;
        public String MERCH_URL;
        public String TERMINAL;
        public String EMAIL;
        public String TRTYPE;
        public String COUNTRY;
        public String MERCH_GMT;
        public String BACKREF;
        public String OPER_TIME;
        public String NONCE;
        public String P_SIGN;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NAME"] == null)
            {
                Response.Redirect("~/login?rurl=səbət");
            }
            else
            {
                BindPaymentDetails();
            }
        }
        private void BindPaymentDetails()
        {
            Int64 OrderID = Convert.ToInt64(Request.QueryString["order"]) / 123456789;
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand("OrdersSelectByID", connection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ID", OrderID);
                comm.ExecuteNonQuery();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count != 0)
                {
                    PaymentAmount = dataTable.Rows[0]["PaymentAmount"].ToString();
                    lblProductCount.Text = dataTable.Rows[0]["ProductCount"].ToString();
                    lblTotalPayment.Text = PaymentAmount;
                    lbltotaPrice.Text = PaymentAmount;
                    ORDER = OrderID.ToString();
                    CURRENCY = "AZN";
                    AMOUNT = PaymentAmount;
                    DESC = "Description of the sale";
                    MERCH_NAME = "Prison Art";
                    MERCH_URL = "https://www.prisonart.gov.az";
                    TERMINAL = "17201253";
                    EMAIL = "hebsxana.art@gmail.com";
                    TRTYPE = "1";
                    COUNTRY = "AZ";
                    MERCH_GMT = "+4";
                    BACKREF = "https://www.prisonart.gov.az/getStatus.aspx";
                    OPER_TIME = DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss");
                    NONCE = Payment.CreateNonce();
                    String to_sign = Payment.GetToSign(AMOUNT, CURRENCY, ORDER, DESC, MERCH_NAME, MERCH_URL, TERMINAL, EMAIL, TRTYPE, COUNTRY, MERCH_GMT, OPER_TIME, NONCE, BACKREF);
                    String key_for_sign = "1d9d6365828487cfe8be5c1c19a56812";
                    P_SIGN = Payment.Encode(to_sign, key_for_sign);
                }
            }
        }
    }
}