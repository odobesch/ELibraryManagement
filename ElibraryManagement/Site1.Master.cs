using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                if (Session["role"] == null) 
                {
                    userLoginLinkButton2.Visible = true;
                    signUpLinkButton.Visible = true;

                    logoutLinkButton.Visible = false;
                    helloUserLinkButton.Visible = false;

                    adminLoginLinkButton.Visible = true;
                    authorMgmtLinkButton.Visible = false;
                    publisherMgmtLinkButton.Visible = false;
                    bookInventoryLinkButton.Visible = false;
                    bookIssuingLinkButton.Visible = false;
                    memberMgmtLinkButton.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    userLoginLinkButton2.Visible = false;
                    signUpLinkButton.Visible = false;

                    logoutLinkButton.Visible = true;
                    helloUserLinkButton.Visible = true;
                    helloUserLinkButton.Text = $"Hello {Session["userName"]}";

                    adminLoginLinkButton.Visible = true;
                    authorMgmtLinkButton.Visible = false;
                    publisherMgmtLinkButton.Visible = false;
                    bookInventoryLinkButton.Visible = false;
                    bookIssuingLinkButton.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    userLoginLinkButton2.Visible = false;
                    signUpLinkButton.Visible = false;

                    logoutLinkButton.Visible = true;
                    helloUserLinkButton.Visible = true;
                    helloUserLinkButton.Text = $"Hello Admin";

                    adminLoginLinkButton.Visible = false;
                    authorMgmtLinkButton.Visible = true;
                    publisherMgmtLinkButton.Visible = true;
                    bookInventoryLinkButton.Visible = true;
                    bookIssuingLinkButton.Visible = true;
                }
            }
            catch (Exception)
            {
                userLoginLinkButton2.Visible = true;
                signUpLinkButton.Visible = true;

                logoutLinkButton.Visible = false;
                helloUserLinkButton.Visible = false;

                adminLoginLinkButton.Visible = true;
                authorMgmtLinkButton.Visible = false;
                publisherMgmtLinkButton.Visible = false;
                bookInventoryLinkButton.Visible = false;
                bookIssuingLinkButton.Visible = false;
                memberMgmtLinkButton.Visible = false;
            }
        }

        protected void adminLoginLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void authorMgmtLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void publisherMgmtLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void bookInventoryLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void bookIssuingLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void memberMgmtLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void viewBooksLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void userLoginLinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void signUpLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void logoutLinkButton_Click(object sender, EventArgs e)
        {
            Session["userName"] = "";
            Session["fullName"] = "";
            Session["role"] = "";
            Session["status"] = "";

            userLoginLinkButton2.Visible = true;
            signUpLinkButton.Visible = true;

            logoutLinkButton.Visible = false;
            helloUserLinkButton.Visible = false;

            adminLoginLinkButton.Visible = true;
            authorMgmtLinkButton.Visible = false;
            publisherMgmtLinkButton.Visible = false;
            bookInventoryLinkButton.Visible = false;
            bookIssuingLinkButton.Visible = false;
            memberMgmtLinkButton.Visible = false;
        }
    }
}