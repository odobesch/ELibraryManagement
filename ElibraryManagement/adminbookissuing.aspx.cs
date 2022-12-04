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
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            bookIssuingGridView.DataBind();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetNames();
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if(CheckBookExists() && CheckMemberExists())
            {
                if (CheckIssueEntryExists())
                {
                    Response.Write("<script>alert('User already has this book issued!');</script>");
                }
                else
                {
                    IssueBook();
                }                
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID or Member ID');</script>");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (CheckBookExists() && CheckMemberExists())
            {
                if (CheckIssueEntryExists())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('This entry does not exist!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID or Member ID');</script>");
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

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM book_master_tbl WHERE book_id='" + tbBookID.Text.Trim() + "' AND current_stock > 0 ",
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
            catch (Exception)
            {
                return false;
            }
        }

        private bool CheckMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT full_name FROM member_master_tbl WHERE member_id='" + tbMemberID.Text.Trim() + "'",
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
            catch (Exception)
            {
                return false;
            }
        }

        private bool CheckIssueEntryExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM book_issue_tbl WHERE member_id='" + tbMemberID.Text.Trim() + "' AND book_id='"+ tbBookID.Text.Trim() + "' ",
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
            catch (Exception)
            {
                return false;
            }
        }

        private void GetNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT book_name FROM book_issue_tbl WHERE book_id='" + tbBookID.Text.Trim() + "'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
               
                if(dt.Rows.Count >= 1)
                {
                    tbBookName.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong book ID');</script>");
                }

                sqlCmd = new SqlCommand(@"SELECT full_name FROM member_master_tbl WHERE member_id='" + tbMemberID.Text.Trim() + "'",
                con);

                da = new SqlDataAdapter(sqlCmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    tbMemberName.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong book ID');</script>");
                }
            }
            catch (Exception)
            {

            }
        }

        private void IssueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"INSERT INTO book_issue_tbl
                (member_id,member_name,book_id,book_name,issue_date,due_date)
                VALUES ('" + tbMemberID.Text.Trim() + "', '" + tbMemberName.Text.Trim() + "','" + tbBookID.Text.Trim() + "', " +
                "'" + tbBookName.Text.Trim() + "','" + tbStartDate.Text.Trim() + "', '" + tbEndDate.Text.Trim() + "')",
                con);
                sqlCmd.ExecuteNonQuery();                

                sqlCmd = new SqlCommand(@"UPDATE book_master_tbl SET current_stock=current_stock-1 WHERE book_id='"+ tbBookID.Text.Trim() +"'",                     
                con);
                sqlCmd.ExecuteNonQuery();
                con.Close();

                bookIssuingGridView.DataBind();
                Response.Write("<script>alert('Book issued successfully');</script>");

            }
            catch (Exception)
            {                
            }
        }

        private void ReturnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"DELETE FROM book_issue_tbl
                WHERE book_id='"+ tbBookID.Text.Trim() + "' AND member_id= '"+ tbMemberID.Text.Trim() +"'",
                con);
                int result = sqlCmd.ExecuteNonQuery();                

                if(result > 0)
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    sqlCmd = new SqlCommand(@"UPDATE book_master_tbl SET current_stock=current_stock+1 WHERE book_id='" + tbBookID.Text.Trim() + "'",
                    con);
                    sqlCmd.ExecuteNonQuery();
                    con.Close();
                }

                bookIssuingGridView.DataBind();
                Response.Write("<script>alert('Book returned successfully');</script>");
                con.Close();
            }
            catch (Exception)
            {
            }
        }

        protected void bookIssuingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if(today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
            }
        }
    }
}