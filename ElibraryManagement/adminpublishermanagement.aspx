<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="ElibraryManagement.adminpublishermanagement" %>
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
                                    <h5>Publisher Details</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" class="img-fluid" src="images/publisher.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbPublisherID" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8 mt-2 mb-2">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbPublisherName" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnPublisherAdd" runat="server" Text="Add" CssClass="btn btn-lg btn-block btn-success" OnClick="btnPublisherAdd_Click"/>
                            </div>
                             <div class="col-4">
                                <asp:Button ID="btnPublisherUpdate" runat="server" Text="Update" CssClass="btn btn-lg btn-block btn-warning" OnClick="btnPublisherUpdate_Click" />
                            </div>
                             <div class="col-4">
                                <asp:Button ID="btnPublisherDelete" runat="server" Text="Delete" CssClass="btn btn-lg btn-block btn-danger" OnClick="btnPublisherDelete_Click" />
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
                                    <h5>Publisher List</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="publisherSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_mastel_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="publisherGridView" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="publisherSqlDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
