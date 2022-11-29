using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class usersignup : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUserMemberLogin_Click(object sender, EventArgs e)
        {
            if (CheckMemberExists())
            {
                Response.Write("<script>alert('Member with this ID already exists!');</script>");
            }
            else
            {
                RegisterNewUser();
            }
        }

        bool CheckMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT member_id FROM member_master_tbl WHERE member_id = '" + tbUserId.Text.Trim() + "'",
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

        void RegisterNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"INSERT INTO member_master_tbl
                (full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status)
                VALUES ('" + tbFullName.Text.Trim() + "', '" + tbDOB.Text.Trim() + "','" + tbContactNo.Text.Trim() + "','" + tbEmail.Text.Trim() + "'," +
                "'" + ddlState.SelectedValue.Trim() + "','" + tbCity.Text.Trim() + "','" + tbPinCode.Text.Trim() + "'," + "'" + tbFullAddress.Text.Trim() + "'," +
                "'" + tbUserId.Text.Trim() + "','" + tbPassword.Text.Trim() + "','Pending')",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Sign Up Successful. Go to User Login page to login.');</script>");
                Response.Redirect("homepage.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}