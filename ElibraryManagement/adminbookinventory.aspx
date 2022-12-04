<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="ElibraryManagement.adminbookinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });

        function ReadURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
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
                                    <h5>Book Details</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" width="100px" class="img-fluid" src="images/books.png" />
                                </center>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="FileUpload" class="form-control" runat="server" onchange="ReadURL(this);" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 mt-2 mb-2">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbBookID" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button ID="btnGo" class="form-control btn btn-primary" runat="server" Text="Go" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9 mt-2 mb-2">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbBookName" runat="server" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlLang" class="form-control" runat="server">
                                        <asp:ListItem Text="Czech" Value="Czech" />
                                        <asp:ListItem Text="Slovak" Value="Slovak" />
                                        <asp:ListItem Text="Polish" Value="Polish" />
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="Spanish" Value="Spanish" />
                                        <asp:ListItem Text="Russian" Value="Russian" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlPublisherName" class="form-control" runat="server">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4 mt-2 mb-2">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlAuthorName" class="form-control" runat="server">
                                        <asp:ListItem Text="a1" Value="a1" />
                                        <asp:ListItem Text="a2" Value="a2" />
                                    </asp:DropDownList>
                                </div>
                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbDate" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 mt-2 mb-2">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="listBoxGenre" runat="server" class="form-control" Rows="5" SelectionMode="Multiple">
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbEdition" runat="server" placeholder="Edition"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-4 mt-2 mb-2">
                                <label>Book Cost (per unit)</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbBookCost" runat="server" placeholder="Cost"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4 mt-2 mb-2">
                                <label>Pages</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbPages" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbActualStock" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbCurrentStock" ReadOnly="true" runat="server" placeholder="Current Stock" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 mt-2 mb-2">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tbIssuedBooks" ReadOnly="true" runat="server" placeholder="Issued Books" TextMode="Number">1</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mt-2 mb-2">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbDescription" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="d-grid gap-2">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
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
                                    <h5>Book Inventory List</h5>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="bookInvSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="bookInvListGridView" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="bookInvSqlDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Author -
                                                                    <asp:Label ID="lbAuthorName" runat="server" Text='<%# Eval("author_name") %>'></asp:Label>

                                                                    &nbsp;| Genre -
                                                                    <asp:Label ID="lbGenre" runat="server" Text='<%# Eval("genre") %>'></asp:Label>

                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="lbLang" runat="server" Text='<%# Eval("language") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher -
                                                                    <asp:Label ID="lbPublisher" runat="server" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date -
                                                                    <asp:Label ID="lbPublDate" runat="server" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="lbPages" runat="server" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="lbEdition" runat="server" Text='<%# Eval("edition") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Cost -
                                                                    <asp:Label ID="lbCost" runat="server" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                    <asp:Label ID="lbActStock" runat="server" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available -
                                                                    <asp:Label ID="lbAvailable" runat="server" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="col-12">
                                                                    Description -
                                                            <asp:Label ID="lbBookDescription" runat="server" Text='<%# Eval("book_description") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <asp:Image ID="imgDataGrid" class="img-fluid p-2" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />                                                           
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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