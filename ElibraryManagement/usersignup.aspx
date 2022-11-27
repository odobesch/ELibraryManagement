<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="ElibraryManagement.usersignup" %>

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
                                    <img width="100px" class="img-fluid" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Member Sign Up</h5>
                                </center>
                            </div>
                        </div>
                        <hr /> 

                        <div class="row">
                            <div class="col-md-6 mt-2 mb-2">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbFullName" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 mt-2 mb-2">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbDOB" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6 mt-2 mb-2">
                                <label>Contact Number </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbContactNo" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 mt-2 mb-2">
                                <label>E-mail ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server" placeholder="E-mail ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 mt-2 mb-2">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server" placeholder="State">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="Czech Republic" Value="Czech Republic"></asp:ListItem>
                                        <asp:ListItem Text="Slovakia" Value="Slovakia"></asp:ListItem>
                                        <asp:ListItem Text="Poland" Value="Poland"></asp:ListItem>
                                        <asp:ListItem Text="Austria" Value="Austria"></asp:ListItem>
                                        <asp:ListItem Text="Germany" Value="Germany"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="tbCity" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="tbPinCode" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mt-2 mb-2">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbFullAddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col mt-2 mb-2">
                                <center>
                                    <span class="badge rounded-pill bg-info text-dark">Login Credentials</span>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mt-2 mb-2">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="tbUserId" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 mt-2 mb-2">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="tbPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <div class="form-group d-grid gap-2 pt-3 pt-md-4">
                                    <asp:Button CssClass="btn btn-success" ID="btnUserMemberLogin" runat="server" Text="Sign Up" OnClick="btnUserMemberLogin_Click" />
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
