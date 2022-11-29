<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="ElibraryManagement.adminauthormanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $('.table').DataTable();
        //});
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h5>Author Details</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" class="img-fluid" src="images/writer.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbAuthorID" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8 mt-2 mb-2">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbAuthorName" runat="server" placeholder="Author Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-lg btn-block btn-success" OnClick="btnAdd_Click" />
                            </div>
                             <div class="col-4">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-lg btn-block btn-warning" OnClick="btnUpdate_Click" />
                            </div>
                             <div class="col-4">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-lg btn-block btn-danger" OnClick="btnDelete_Click" />
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
                                    <h5>Author List</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="authorListSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="authorListGridView" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="authorListSqlDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
