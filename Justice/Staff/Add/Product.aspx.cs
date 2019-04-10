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
                if (Session["ADMINSESSION"].ToString() != "Admin")
                {
                    ddlJails.SelectedValue = Session["ADMINSESSIONJAILNO"].ToString();
                    ddlJails.Enabled = false;
                }
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
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("ProductsSelectByIDJoinCategoriesAndJails", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ID", ProductID);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (!IsPostBack)
                {
                    txtPname.Text = dataTable.Rows[0]["ProductName"].ToString();
                    txtPcode.Text = dataTable.Rows[0]["Code"].ToString();
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
                imagesForm.Visible = false;
                RequiredFieldValidator1.Enabled = false;
                btnEdit.Visible = true;
                btnSave.Visible = false;
            }
        }
        private void BindCategories()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("CategoriesSelectAll", connection);
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
        }
        private void BindJails()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("JailsSelectAll", connection);
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
        }
        private void BindPrisoners()
        {
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("PrisonersSelectAll", connection);
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
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand;
                int discountPrice = Convert.ToInt32(txtPdiscountPrice.Text);
                int price = Convert.ToInt32(txtPprice.Text);
                float discount = ((price - discountPrice) * 100) / price;
                if (Request.QueryString.AllKeys.Contains("ProductID"))
                {
                    sqlCommand = new SqlCommand("ProductsUpdate", connection);
                    sqlCommand.Parameters.AddWithValue("@ID", ProductID);
                }
                else
                {
                    sqlCommand = new SqlCommand("ProductsCreate", connection);
                    sqlCommand.Parameters.AddWithValue("@Discount", discount);
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ProductName", txtPname.Text.ToString().Trim());
                sqlCommand.Parameters.AddWithValue("@Code", txtPcode.Text.ToString().Trim());
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
                sqlCommand.Parameters.AddWithValue("@PrisonerID", Convert.ToInt32(ddlPrisoners.SelectedItem.Value));
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("ProductsLastInsertionID", connection);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                Int32 lastInsertedID = Convert.ToInt32(sqlCommand2.ExecuteScalar());

                //Insert Images

                if (img1p.HasFile)
                {
                    LoadImage(img1p, "01", lastInsertedID, "1");
                }
                if (img2p.HasFile)
                {
                    LoadImage(img2p, "02", lastInsertedID, "0");
                }
                if (img3p.HasFile)
                {
                    LoadImage(img3p, "03", lastInsertedID, "0");
                }
                if (img4p.HasFile)
                {
                    LoadImage(img4p, "04", lastInsertedID, "0");
                }
            }
            Response.Redirect("~/root/məhsullar");
        }

        private void LoadImage(FileUpload imgFile, string numberOfImg, int lastInsertedID, string role)
        {
            string savePath = Server.MapPath("~/Content/Main/images/products/") + lastInsertedID;
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                string extention = Path.GetExtension(imgFile.PostedFile.FileName);
                string name = txtPname.Text.ToString().Replace(" ", "");
                imgFile.SaveAs(savePath + "\\" + name + numberOfImg + extention);
                SqlCommand sqlCommand3 = new SqlCommand("ImagesCreate", connection);
                sqlCommand3.CommandType = CommandType.StoredProcedure;
                sqlCommand3.Parameters.AddWithValue("@ProductID", lastInsertedID);
                sqlCommand3.Parameters.AddWithValue("@Name", name + numberOfImg);
                sqlCommand3.Parameters.AddWithValue("@Extention", extention);
                sqlCommand3.Parameters.AddWithValue("@Role", role);
                sqlCommand3.ExecuteNonQuery();
            }
        }
    }
}