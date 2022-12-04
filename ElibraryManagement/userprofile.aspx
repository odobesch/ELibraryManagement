<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ElibraryManagement.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
     </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
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
                                    <h5>Your Profile</h5>
                                    <span>Account Status -</span>
                                    <asp:Label ID="lbYourStatus" class="badge rounded-pill bg-info text-dark" runat="server" Text="Your Status"></asp:Label>
                                </center>
                            </div>
                            <hr />
                        </div>

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
                                    <asp:TextBox CssClass="form-control" ID="tbDateOfBirth" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mt-2 mb-2">
                                <label>Contact Number </label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="tbContactNumber" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 mt-2 mb-2">
                                <label>E-mail ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ReadOnly="true" ID="tbEmailID" runat="server" placeholder="E-mail ID" TextMode="Email"></asp:TextBox>
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
                                    <asp:TextBox CssClass="form-control" ReadOnly="true" ID="tbFullAddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                            <div class="col-md-4 mt-2 mb-2">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ReadOnly="true" ID="tbUserID" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Old Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="tbOldPassword" ReadOnly="true" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="tbNewPassword" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <div class="form-group d-grid gap-2 pt-3 pt-md-4">
                                        <asp:Button CssClass="btn btn-primary" ID="btnUpdateUserMemberLogin" runat="server" Text="Update" OnClick="btnUpdateUserMemberLogin_Click" />
                                    </div>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="pb-4">
                    <a href="homepage.aspx"><< Back to Home</a>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" class="img-fluid" src="images/books.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Your Issued Books</h5>
                                    <asp:Label ID="lbYourIssuedBooks" class="badge rounded-pill bg-info text-dark" runat="server" Text="Info about book due date"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="yourIssuedBooksGridView" class="table table-striped table-bordered" runat="server" OnRowDataBound="yourIssuedBooksGridView_RowDataBound"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
