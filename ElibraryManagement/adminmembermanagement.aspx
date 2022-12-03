<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="ElibraryManagement.adminmembermanagement" %>

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
                                    <h5>Member Details</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" class="img-fluid" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-3 mt-2 mb-2">
                                <label>ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbID" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:LinkButton ID="lbtnGo" class="btn btn-primary" runat="server" OnClick="lbtnGo_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4 mt-2 mb-2">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbFullName" runat="server" placeholder="Full Name" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5 mt-2 mb-2">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbStatus" runat="server" placeholder="Status" ReadOnly="true"></asp:TextBox>
                                        <asp:LinkButton ID="lbtnActive" class="btn btn-success ms-1" runat="server" OnClick="lbtnActive_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbtnPending" class="btn btn-warning ms-1" runat="server" OnClick="lbtnPending_Click"><i class="fa-regular fa-circle-pause"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbtnInactive" class="btn btn-danger ms-1" runat="server" OnClick="lbtnInactive_Click"><i class="fa-regular fa-circle-xmark"></i></asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 mt-2 mb-2">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ReadOnly="true" ID="tbDOB" runat="server" placeholder="DOB"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-4 mt-2 mb-2">
                                <label>Contact Nr</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="tbContact" runat="server" placeholder="Contact"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-5 mt-2 mb-2">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="tbEmail" runat="server" placeholder="Email"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 mt-2 mb-2">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbState" ReadOnly="true" runat="server" placeholder="State"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>City</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbCity" ReadOnly="true" runat="server" placeholder="City"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Zip Code</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbZipCode" ReadOnly="true" runat="server" placeholder="Zip Code"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mt-2 mb-2">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbFullPostalCode" ReadOnly="true" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="d-grid gap-2">
                                <asp:Button ID="btnDeleteUser" runat="server" Text="Delete user permanently" CssClass="btn btn-danger" OnClick="btnDeleteUser_Click" />                                
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
                                    <h5>Member List</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="memberListSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="memberListGridView" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="memberListSqlDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" ReadOnly="True" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
