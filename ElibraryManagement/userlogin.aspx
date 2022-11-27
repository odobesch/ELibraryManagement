<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ElibraryManagement.userlogin" %>

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
                                    <img width="150px" class="img-fluid" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbUserMemberName" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>

                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbUserMemberPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group d-grid gap-2 pt-3 pt-md-4">
                                    <asp:Button CssClass="btn btn-success" ID="btnUserMemberLogin" runat="server" Text="Login" OnClick="btnUserMemberLogin_Click" />
                                </div>

                                <a href="usersignup.aspx">
                                    <div class="form-group d-grid gap-2 pt-3 pt-md-3 pb-2 pb-md-2">
                                        <input class="btn btn-primary d-grid gap-2" id="btnUserMemberSignUp" type="button" value="Sign Up" />
                                    </div>
                                </a>
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
