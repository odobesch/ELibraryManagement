using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ElibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            FillAuthorPublisherValues();
            bookInvListGridView.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckBookExists())
            {
                Response.Write("<script>alert('Book already exists');</script>");
            }
            else
            {
                AddNewBook();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void FillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT author_name FROM author_master_tbl",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                ddlAuthorName.DataSource = dt;
                ddlAuthorName.DataValueField = "author_name";
                ddlAuthorName.DataBind();

                sqlCmd = new SqlCommand(@"SELECT publisher_name FROM publisher_mastel_tbl",
                con);

                da = new SqlDataAdapter(sqlCmd);
                dt = new DataTable();
                da.Fill(dt);

                ddlPublisherName.DataSource = dt;
                ddlPublisherName.DataValueField = "publisher_name";
                ddlPublisherName.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private bool CheckBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM book_master_tbl WHERE book_id = '" + tbBookID.Text.Trim() + "' OR book_name='"+ tbBookName.Text.Trim() +"'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);               

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        private void AddNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in listBoxGenre.GetSelectedIndices())
                {
                    genres += listBoxGenre.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                FileUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;

                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"INSERT INTO book_master_tbl
                (book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link)
                VALUES ('" + tbBookID.Text.Trim() + "', '" + tbBookName.Text.Trim() + "','" + genres + "', " +
                "'" + ddlAuthorName.SelectedItem.Value + "','" + ddlPublisherName.SelectedItem.Value + "', '" + tbDate.Text.Trim() + "','" + ddlLang.SelectedItem.Value + "'" +
                ", '" + tbEdition.Text.Trim() + "', '" + tbBookCost.Text.Trim() + "', '" + tbPages.Text.Trim() + "', '" + tbDescription.Text.Trim() + "'" +
                ", '" + tbActualStock.Text.Trim() + "', '" + tbActualStock.Text.Trim() + "', '" + filepath + "')",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('New book was ADDED successfuly.');</script>");
                ClearTextBoxes();

                bookInvListGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        private void ClearTextBoxes()
        {
            tbBookID.Text = String.Empty;
            tbBookName.Text = String.Empty;
            tbDate.Text = String.Empty;
            tbEdition.Text = String.Empty;
            tbBookCost.Text = String.Empty;
            tbPages.Text = String.Empty;
            tbDescription.Text = String.Empty;
            tbActualStock.Text = String.Empty;
            tbCurrentStock.Text = String.Empty;
        }
    }
}