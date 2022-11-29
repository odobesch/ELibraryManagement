using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            authorListGridView.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExists())
            {
                Response.Write("<script>alert('Author ID already exists! Use another one to register new author.');</script>");
            }
            else
            {
                AddNewAuthor();
            }
        }        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExists())
            {
                UpdateAuthor();
            }
            else
            {
                Response.Write("<script>alert('This Author does NOT exist!');</script>");
            }
        }      

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckAuthorExists())
            {
                DeleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('This Author does NOT exist!');</script>");
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

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM author_master_tbl WHERE author_id = '" + tbAuthorID.Text.Trim() + "'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                if (dt.Rows.Count >= 1)
                {
                    tbAuthorName.Text = dt.Rows[0][1].ToString();
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

                SqlCommand sqlCmd = new SqlCommand(@"SELECT author_id FROM author_master_tbl WHERE author_id = '" + tbAuthorID.Text.Trim() + "'",
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

        private void AddNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"INSERT INTO author_master_tbl
                (author_id,author_name)
                VALUES ('" + tbAuthorID.Text.Trim() + "', '" + tbAuthorName.Text.Trim() + "')",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author ADDED successfuly.');</script>");
                ClearTextBox();

                authorListGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void UpdateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"UPDATE author_master_tbl
                SET author_name = '" + tbAuthorName.Text.Trim() + "' WHERE author_id= '"+ tbAuthorID.Text.Trim() +"'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author UPDATED successfuly.');</script>");
                ClearTextBox();

                authorListGridView.DataBind();
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

                SqlCommand sqlCmd = new SqlCommand(@"DELETE FROM author_master_tbl
                WHERE author_id= '" + tbAuthorID.Text.Trim() + "'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author DELETED successfuly.');</script>");
                ClearTextBox();

                authorListGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearTextBox()
        {
            tbAuthorID.Text = string.Empty;
            tbAuthorName.Text = string.Empty;
        }
    }
}