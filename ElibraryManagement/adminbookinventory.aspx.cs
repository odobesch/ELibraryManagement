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
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAuthorPublisherValues(); 
            }
            bookInvListGridView.DataBind();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetBookByID();
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
            if (CheckBookExists())
            {
                UpdateBookByID();
            }
            else
            {
                Response.Write("<script>alert('Invalid book ID');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckBookExists())
            {
                DeleteBookByID();
            }
            else
            {
                Response.Write("<script>alert('Invalid book ID');</script>");
            }
        }

        private void DeleteBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"DELETE FROM book_master_tb
                WHERE book_id= '" + tbBookID.Text.Trim() + "'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Book DELETED successfuly.');</script>");
                ClearTextBoxes();

                bookInvListGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void GetBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM book_master_tbl WHERE book_id='" + tbBookID.Text.Trim() + "'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    tbBookName.Text = dt.Rows[0]["book_name"].ToString();
                    ddlLang.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    ddlPublisherName.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    ddlAuthorName.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    tbDate.Text = dt.Rows[0]["publish_date"].ToString().Trim();

                    listBoxGenre.ClearSelection();

                    string[] genres = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    for (int i = 0; i < genres.Length; i++)
                    {
                        for (int j = 0; j < listBoxGenre.Items.Count; j++)
                        {
                            if (listBoxGenre.Items[j].ToString() == genres[i])
                            {
                                listBoxGenre.Items[j].Selected = true;
                            }
                        }
                    }
                    tbEdition.Text = dt.Rows[0]["edition"].ToString();
                    tbBookCost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    tbPages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    tbActualStock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    tbCurrentStock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    tbIssuedBooks.Text = (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString())).ToString();
                    tbDescription.Text = dt.Rows[0]["book_description"].ToString();

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong book ID');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateBookByID()
        {
            try
            {
                int actual_stock = Convert.ToInt32(tbActualStock.Text.Trim());
                int current_stock = Convert.ToInt32(tbCurrentStock.Text.Trim());

                if (actual_stock == current_stock)
                {

                }
                else 
                { 
                    if(actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert('Actual Stock value can not be less than the Issued books.');</script>");
                        return;
                    }
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        tbCurrentStock.Text = current_stock.ToString();
                    }
                }
                
                string genres = "";
                foreach (int i in listBoxGenre.GetSelectedIndices())
                {
                    genres += listBoxGenre.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload.PostedFile.FileName);

                if (String.IsNullOrEmpty(filename))
                {
                    filepath = global_filepath;
                }
                else
                {
                    FileUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"UPDATE book_master_tbl
                SET book_name = '" + tbBookName.Text.Trim() + "', genre='"+ genres +"', author_name='"+ ddlAuthorName.SelectedItem.Value +"', " +
                "publisher_name='"+ ddlPublisherName.SelectedItem.Value + "', publish_date='"+ tbDate.Text.Trim() +"', language='"+ ddlLang.SelectedItem.Value + "', " +
                "edition='"+ tbEdition.Text.Trim() +"',book_cost='"+ tbBookCost.Text.Trim() + "', no_of_pages='"+ tbPages.Text.Trim() + "', " +
                "book_description='"+ tbDescription.Text.Trim() + "',actual_stock='"+ actual_stock + "',current_stock='"+ current_stock +"',book_img_link='"+ filepath +"' " +
                "WHERE book_id= '" + tbBookID.Text.Trim() + "'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Book UPDATED successfuly.');</script>");               

                bookInvListGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
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

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM book_master_tbl WHERE book_id = '" + tbBookID.Text.Trim() + "' OR book_name='" + tbBookName.Text.Trim() + "'",
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