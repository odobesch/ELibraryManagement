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
    public partial class userprofile : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session expired. Log in again);</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    GetUserBookData();

                    if (!Page.IsPostBack)
                    {
                        GetUserPersonalData();
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Session expired. Log in again);</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        protected void btnUpdateUserMemberLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session expired. Log in again);</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    UpdatePersonalData();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Session expired. Log in again);</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        private void UpdatePersonalData()
        {
            string password = "";
            if (tbNewPassword.Text.Trim() == "")
            {
                password = tbOldPassword.Text.Trim();
            }
            else
            {
                password = tbNewPassword.Text.Trim();
            }

            try
            {   
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"UPDATE member_master_tbl
                SET full_name = '" + tbFullName.Text.Trim() + "', dob='"+ tbDateOfBirth.Text.Trim() + "', contact_no='"+tbContactNumber.Text.Trim() + "'," +
                "email='"+ tbEmailID.Text.Trim() +"', state='"+ ddlState.SelectedValue.Trim() +"',city='"+ tbCity.Text.Trim() + "',pincode='"+ tbPinCode.Text.Trim() +"'" +
                ",full_address='"+ tbFullAddress.Text.Trim() +"',password='"+ password + "',account_status='Pending'" +
                " WHERE full_name= '" + Session["username"].ToString() + "'",
                con);

                int result = sqlCmd.ExecuteNonQuery();
                con.Close();

                if(result > 0)
                {
                    Response.Write("<script>alert('User profile UPDATED successfuly.');</script>");
                    GetUserBookData();
                    GetUserPersonalData();
                }
                else
                {
                    Response.Write("<script>alert('Invalid entry');</script>");
                }

                //ClearTextBox();
               
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void GetUserPersonalData()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM member_master_tbl WHERE full_name = '" + Session["username"].ToString() + "'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                tbFullName.Text = dt.Rows[0]["full_name"].ToString();
                tbDateOfBirth.Text = dt.Rows[0]["dob"].ToString();
                tbContactNumber.Text = dt.Rows[0]["contact_no"].ToString();
                tbEmailID.Text = dt.Rows[0]["email"].ToString();
                ddlState.SelectedValue = dt.Rows[0]["state"].ToString();
                tbCity.Text = dt.Rows[0]["city"].ToString();
                tbPinCode.Text = dt.Rows[0]["pincode"].ToString();
                tbFullAddress.Text = dt.Rows[0]["full_address"].ToString();
                tbUserID.Text = dt.Rows[0]["member_id"].ToString();
                tbOldPassword.Text = dt.Rows[0]["password"].ToString();
                lbYourStatus.Text = dt.Rows[0]["account_status"].ToString();

                if(dt.Rows[0]["account_status"].ToString() == "Active")
                {
                    lbYourStatus.Attributes.Add("class", "badge rounded-pill bg-success text-dark");
                }
                else if (dt.Rows[0]["account_status"].ToString() == "Pending")
                {
                    lbYourStatus.Attributes.Add("class", "badge rounded-pill bg-warning text-dark");
                }
                else if (dt.Rows[0]["account_status"].ToString() == "Inactive")
                {
                    lbYourStatus.Attributes.Add("class", "badge rounded-pill bg-danger text-dark");
                }
                else
                {
                    lbYourStatus.Attributes.Add("class", "badge rounded-pill bg-info text-dark");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void GetUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM book_issue_tbl WHERE member_id = '" + Session["username"].ToString() + "'",
                con);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                yourIssuedBooksGridView.DataSource = dt;
                yourIssuedBooksGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void yourIssuedBooksGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}