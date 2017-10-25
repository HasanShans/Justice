using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Justice.App_Code;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Justice.Staff.Add
{
    public partial class Product1 : System.Web.UI.Page
    {
        int ProductID;
        int productAvailability;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
                BindJails();
                BindPrisoners();
            }
            if (Request.QueryString.AllKeys.Contains("ProductID"))
            {
                BindProductDetails();
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }
        private void BindProductDetails()
        {
            ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("ProductsSelectByIDJoinCategoriesAndJails", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", ProductID);
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (!IsPostBack)
            {
                txtPname.Text = dataTable.Rows[0]["ProductName"].ToString();
                txtPsize.Text = dataTable.Rows[0]["Size"].ToString();
                txtPMaterial.Text = dataTable.Rows[0]["Material"].ToString();
                txtPdescription.Text = dataTable.Rows[0]["Description"].ToString();
                txtPweight.Text = dataTable.Rows[0]["Weight"].ToString();
                txtPamount.Text = dataTable.Rows[0]["StockAmount"].ToString();
                txtPprice.Text = dataTable.Rows[0]["Price"].ToString();
                txtPdiscountPrice.Text = dataTable.Rows[0]["DiscountPrice"].ToString();
                ddlCategories.SelectedValue = dataTable.Rows[0]["CategoryID"].ToString();
                ddlJails.SelectedValue = dataTable.Rows[0]["JailID"].ToString();
                ddlPrisoners.SelectedValue = dataTable.Rows[0]["PrisonerID"].ToString();
                if (dataTable.Rows[0]["StockAvailability"].ToString() == "1")
                {
                    rblPavailability.SelectedIndex = 0;
                }
                else
                {
                    rblPavailability.SelectedIndex = 1;
                }
            }
            RequiredFieldValidator1.Enabled = false;
            img1p.Visible = false;
            img2p.Visible = false;
            img3p.Visible = false;
            img4p.Visible = false;
            btnEdit.Visible = true;
            btnSave.Visible = false;
        }
        private void BindCategories()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("CategoriesSelectAll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                ddlCategories.DataSource = dataTable;
                ddlCategories.DataTextField = "CategoryName";
                ddlCategories.DataValueField = "ID";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("-- Kateqoriya Seçin --", "0"));
            }
        }
        private void BindJails()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("JailsSelectAll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                ddlJails.DataSource = dataTable;
                ddlJails.DataTextField = "JailName";
                ddlJails.DataValueField = "ID";
                ddlJails.DataBind();
                ddlJails.Items.Insert(0, new ListItem("-- Həbsxana Seçin --", "0"));
            }
        }
        private void BindPrisoners()
        {
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand = new SqlCommand("PrisonersSelectAll", DB.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count != 0)
            {
                ddlPrisoners.DataSource = dataTable;
                ddlPrisoners.DataTextField = "PrisonerName";
                ddlPrisoners.DataValueField = "ID";
                ddlPrisoners.DataBind();
                ddlPrisoners.Items.Insert(0, new ListItem("-- Məhbus Seçin --", "0"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (rblPavailability.SelectedIndex == 0)
            {
                productAvailability = 1;
            }
            else
            {
                productAvailability = 0;
            }
            if (DB.Connection.State == ConnectionState.Closed)
                DB.Connection.Open();
            SqlCommand sqlCommand;
            if (Request.QueryString.AllKeys.Contains("ProductID"))
            {
                sqlCommand = new SqlCommand("ProductsUpdate", DB.Connection);
                sqlCommand.Parameters.AddWithValue("@ID", ProductID);
            }
            else
            {
                sqlCommand = new SqlCommand("ProductsCreate", DB.Connection);
            }
            int discountPrice = Convert.ToInt32(txtPdiscountPrice.Text);
            int price = Convert.ToInt32(txtPprice.Text);
            float discount = ((price - discountPrice) * 100) / price;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ProductName", txtPname.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@Size", txtPsize.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@Material", txtPMaterial.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@Description", txtPdescription.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@Weight", txtPweight.Text.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@StockAmount", Convert.ToInt32(txtPamount.Text.ToString().Trim()));
            sqlCommand.Parameters.AddWithValue("@Price", Convert.ToInt32(txtPprice.Text.ToString().Trim()));
            sqlCommand.Parameters.AddWithValue("@DiscountPrice", Convert.ToInt32(txtPdiscountPrice.Text.ToString().Trim()));
            sqlCommand.Parameters.AddWithValue("@JailID", Convert.ToInt32(ddlJails.SelectedItem.Value));
            sqlCommand.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(ddlCategories.SelectedItem.Value));
            sqlCommand.Parameters.AddWithValue("@StockAvailability", productAvailability);
            sqlCommand.Parameters.AddWithValue("@Discount", discount);
            sqlCommand.Parameters.AddWithValue("@PrisonerID", Convert.ToInt32(ddlPrisoners.SelectedItem.Value));
            sqlCommand.ExecuteNonQuery();

            SqlCommand sqlCommand2 = new SqlCommand("ProductsLastInsertionID", DB.Connection);
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            Int32 lastInsertedID = Convert.ToInt32(sqlCommand2.ExecuteScalar());

            //Insert Images

            if (img1p.HasFile)
            {
                string savePath = Server.MapPath("~/Content/Main/images/products/") + lastInsertedID;
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string extention = Path.GetExtension(img1p.PostedFile.FileName);
                img1p.SaveAs(savePath + "\\" + txtPname.Text.ToString().Trim() + "01" + extention);
                SqlCommand sqlCommand3 = new SqlCommand("ImagesCreate", DB.Connection);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                sqlCommand3.Parameters.AddWithValue("@ProductID", lastInsertedID);
                sqlCommand3.Parameters.AddWithValue("@Name", txtPname.Text.ToString().Trim() + "01");
                sqlCommand3.Parameters.AddWithValue("@Extention", extention);
                sqlCommand3.Parameters.AddWithValue("@Role", "1");
                sqlCommand3.ExecuteNonQuery();
            }
            if (img2p.HasFile)
            {
                string savePath = Server.MapPath("~/Content/Main/images/products/") + lastInsertedID;
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string extention = Path.GetExtension(img2p.PostedFile.FileName);
                img3p.SaveAs(savePath + "\\" + txtPname.Text.ToString().Trim() + "02" + extention);
                SqlCommand sqlCommand3 = new SqlCommand("ImagesCreate", DB.Connection);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                sqlCommand3.Parameters.AddWithValue("@ProductID", lastInsertedID);
                sqlCommand3.Parameters.AddWithValue("@Name", txtPname.Text.ToString().Trim() + "02");
                sqlCommand3.Parameters.AddWithValue("@Extention", extention);
                sqlCommand3.Parameters.AddWithValue("@Role", "0");
                sqlCommand3.ExecuteNonQuery();
            }
            if (img3p.HasFile)
            {
                string savePath = Server.MapPath("~/Content/Main/images/products/") + lastInsertedID;
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string extention = Path.GetExtension(img3p.PostedFile.FileName);
                img3p.SaveAs(savePath + "\\" + txtPname.Text.ToString().Trim() + "03" + extention);
                SqlCommand sqlCommand3 = new SqlCommand("ImagesCreate", DB.Connection);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                sqlCommand3.Parameters.AddWithValue("@ProductID", lastInsertedID);
                sqlCommand3.Parameters.AddWithValue("@Name", txtPname.Text.ToString().Trim() + "03");
                sqlCommand3.Parameters.AddWithValue("@Extention", extention);
                sqlCommand3.Parameters.AddWithValue("@Role", "0");
                sqlCommand3.ExecuteNonQuery();
            }
            if (img4p.HasFile)
            {
                string savePath = Server.MapPath("~/Content/Main/images/products/") + lastInsertedID;
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string extention = Path.GetExtension(img4p.PostedFile.FileName);
                img4p.SaveAs(savePath + "\\" + txtPname.Text.ToString().Trim() + "04" + extention);
                SqlCommand sqlCommand3 = new SqlCommand("ImagesCreate", DB.Connection);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                sqlCommand3.Parameters.AddWithValue("@ProductID", lastInsertedID);
                sqlCommand3.Parameters.AddWithValue("@Name", txtPname.Text.ToString().Trim() + "04");
                sqlCommand3.Parameters.AddWithValue("@Extention", extention);
                sqlCommand3.Parameters.AddWithValue("@Role", "0");
                sqlCommand3.ExecuteNonQuery();
            }
            Response.Redirect("~/Staff/Products.aspx");
        }
    }
}