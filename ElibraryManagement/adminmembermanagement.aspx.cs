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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            memberListGridView.DataBind();
        }

        protected void lbtnGo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbID.Text))
            {
                GetMemberByID();
            }
            else
            {
                Response.Write("<script>alert('Member ID is not specified!');</script>");
            }
        }

        protected void lbtnActive_Click(object sender, EventArgs e)
        {
            if (CheckMemberExists())
            {
                UpdateMemberStatusByID("Active");
            }
            else
            {
                Response.Write("<script>alert('Member does not exist!');</script>");
            }
        }

        protected void lbtnPending_Click(object sender, EventArgs e)
        {
            if (CheckMemberExists())
            {
                UpdateMemberStatusByID("Pending"); 
            }
            else
            {
                Response.Write("<script>alert('Member does not exist!');</script>");
            }
        }

        protected void lbtnInactive_Click(object sender, EventArgs e)
        {
            if (CheckMemberExists())
            {
                UpdateMemberStatusByID("Inactive"); 
            }
            else
            {
                Response.Write("<script>alert('Member does not exist!');</script>");
            }
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbID.Text))
            {               
                if (CheckMemberExists())
                {
                    DeleteMemberByID();
                }
                else
                {
                    Response.Write("<script>alert('Member does not exist!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Member ID is not specified!');</script>");
            }
        }

        private void GetMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"SELECT * FROM member_master_tbl WHERE member_id = '" + tbID.Text.Trim() + "'",
                con);

                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        tbFullName.Text = sdr.GetValue(0).ToString();
                        tbStatus.Text = sdr.GetValue(10).ToString();
                        tbDOB.Text = sdr.GetValue(1).ToString();
                        tbContact.Text = sdr.GetValue(2).ToString();
                        tbEmail.Text = sdr.GetValue(3).ToString();
                        tbState.Text = sdr.GetValue(4).ToString();
                        tbCity.Text = sdr.GetValue(5).ToString();
                        tbZipCode.Text = sdr.GetValue(6).ToString();
                        tbFullPostalCode.Text = sdr.GetValue(7).ToString();
                    }                   
                }
                else
                {
                    Response.Write("<script>alert('User does not exist! Please make sure the ID is correct.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void UpdateMemberStatusByID(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"UPDATE member_master_tbl SET account_status = '" + status + "' WHERE member_id='"+ tbID.Text.Trim() +"'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();
                memberListGridView.DataBind();
                Response.Write("<script>alert('Member Status UPDATED');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void DeleteMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlCmd = new SqlCommand(@"DELETE FROM member_master_tbl
                WHERE member_id= '" + tbID.Text.Trim() + "'",
                con);

                sqlCmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Member DELETED successfuly.');</script>");
                ClearTextBoxes();
                memberListGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearTextBoxes()
        {
            tbID.Text = String.Empty;
            tbFullName.Text = String.Empty;
            tbStatus.Text = String.Empty;
            tbDOB.Text = String.Empty;
            tbContact.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbState.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbZipCode.Text = String.Empty;
            tbFullPostalCode.Text = String.Empty;
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

                SqlCommand sqlCmd = new SqlCommand(@"SELECT author_id FROM member_master_tbl WHERE member_id = '" + tbID.Text.Trim() + "'",
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
    }
}