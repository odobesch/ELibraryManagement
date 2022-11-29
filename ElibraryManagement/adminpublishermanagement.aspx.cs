using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ElibraryManagement
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            publisherGridView.DataBind();
        }

        protected void btnPublisherAdd_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExists())
            {
                Response.Write("<script>alert('Publisher ID already exists! Use another one to register new publisher.');</script>");
            }
            else
            {
                AddNewPublisher();
            }
        }        

        protected void btnPublisherUpdate_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExists())
            {
                UpdatePublisher();
            }
            else
            {
                Response.Write("<script>alert('This Publisher does NOT exist!');</script>");
            }
        }

       

        protected void btnPublisherDelete_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExists())
            {
                DeleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('This Publisher does NOT exist!');</script>");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetAuthorByID();
        }

        private void GetAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM publisher_mastel_tbl WHERE publisher_id = '" + tbPublisherID.Text.Trim() + "'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                if (dt.Rows.Count >= 1)
                {
                    tbPublisherName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Author ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private bool CheckAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT publisher_id FROM publisher_mastel_tbl WHERE publisher_id = '" + tbPublisherID.Text.Trim() + "'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                sqlCmd.ExecuteNonQuery();
                con.Close();

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

        private void AddNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"INSERT INTO publisher_mastel_tbl
                (publisher_id,publisher_name)
                VALUES ('" + tbPublisherID.Text.Trim() + "', '" + tbPublisherName.Text.Trim() + "')",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher ADDED successfuly.');</script>");
                ClearTextBox();

                publisherGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void UpdatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"UPDATE publisher_mastel_tbl
                SET publisher_name = '" + tbPublisherName.Text.Trim() + "' WHERE publisher_id= '" + tbPublisherID.Text.Trim() + "'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher UPDATED successfuly.');</script>");
                ClearTextBox();

                publisherGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void DeleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"DELETE FROM publisher_mastel_tbl
                WHERE publisher_id= '" + tbPublisherID.Text.Trim() + "'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher DELETED successfuly.');</script>");
                ClearTextBox();

                publisherGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearTextBox()
        {
            tbPublisherID.Text = string.Empty;
            tbPublisherName.Text = string.Empty;
        }
    }
}