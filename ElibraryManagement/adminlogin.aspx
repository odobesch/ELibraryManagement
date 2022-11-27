<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ElibraryManagement.adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row pt-4">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" class="img-fluid" src="images/adminuser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">  
                                <label>Admin ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbAdminID" runat="server" placeholder="Admin ID"></asp:TextBox>
                                </div>

                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbAdminPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group d-grid gap-2 pt-3 pt-md-4">
                                    <asp:Button CssClass="btn btn-success" ID="btnAdminMemberLogin" runat="server" Text="Login" OnClick="btnAdminMemberLogin_Click" />
                                </div>                               
                            </div>
                        </div>
                    </div>
                </div>
                <div class="pb-4">
                    <a href="homepage.aspx"><< Back to Home</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
