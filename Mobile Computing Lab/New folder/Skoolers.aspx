<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Skoolers.aspx.cs" Inherits="Mobile_Computing_Lab.Skoolers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>High School</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="crossorigin" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css2?family=Archivo+Narrow:ital,wght@0,400;1,500&family=Julius+Sans+One&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" class="container py-5" runat="server">
        <div>
            <div runat="server" id="login">
                <h1>Login</h1>
                <div class="mb-2">
                    <asp:Label
                        ID="user_label"
                        runat="server"
                        Text="user">
                        User ID
                    </asp:Label>
                    <br />
                    <input class="form-control" id="userId" type="text" runat="server" />
                </div>
                <div class="mb-2">
                    <asp:Label
                        ID="password_label"
                        runat="server"
                        Text="user">
                        Password
                    </asp:Label>
                    <br />
                    <input class="form-control" id="password" type="text" runat="server" />
                </div>
                <asp:Button
                    ID="loginBtn"
                    CssClass="btn btn-primary"
                    runat="server"
                    Text="Login"
                    OnClick="loginBtn_Click" />
            </div>
            <div id="main" runat="server">
                <h1>Skoolers App</h1>
                <div class="d-flex flex-column">

                <asp:Button CssClass="btn btn-primary mb-2" ID="high_school_maintanence_btn" runat="server" Text="High School Maintanence" OnClick="high_school_maintanence_btn_Click" /><br />
                <asp:Button CssClass="btn btn-primary mb-2" ID="view_school_btn" Text="View School" runat="server" OnClick="view_school_btn_Click" /><br />
                <asp:Button CssClass="btn btn-primary mb-2" ID="logout" runat="server" Text="Logout" OnClick="logout_Click" />
                </div>
            </div>
            <div id="high_school_maintanence" runat="server">
                <h1 class="text-center">High School Maintanence</h1>
                <div class="d-flex flex-row mb-2">

                    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="highschool_dropdown_SelectedIndexChanged" CssClass="custom-select" ID="highschool_dropdown" runat="server" DataTextField="name" DataValueField="num"></asp:DropDownList>
                    <asp:Button CssClass="btn btn-primary ml-2" ID="editBtn" runat="server" Text="Edit" OnClick="editBtn_Click"/>
                    <asp:Button CssClass="btn btn-primary ml-2" ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
                    <asp:Button CssClass="btn btn-danger ml-2" ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click"/>
                </div>
                <asp:Label ID="high_school_maintanence_error" runat="server" Text=""></asp:Label>
                <input class="form-control" id="highschool_name" type="text" runat="server" /><br />
                <label>Head Student</label>
                <div class="d-flex flex-row mb-2">

                    <asp:DropDownList CssClass="form-control" ID="student_dropdown" DataTextField="name" DataValueField="num" runat="server"></asp:DropDownList><br />
                    <asp:Button CssClass="btn btn-primary ml-2" ID="studentEditBtn" runat="server" Text="Edit" OnClick="studentEditBtn_Click"/>
                    <asp:Button CssClass="btn btn-primary ml-2" ID="studentSaveBtn" runat="server" Text="Update" OnClick="studentSaveBtn_Click"/>
                    <asp:Button CssClass="btn btn-danger ml-2" ID="studentCancelBtn" runat="server" Text="Cancel" OnClick="studentCancelBtn_Click"/>
                </div>
                <asp:Button CssClass="btn btn-primary" ID="newBtn" runat="server" Text="New" OnClick="newBtn_Click"/>
                <asp:Button CssClass="btn btn-primary" ID="addBtn" runat="server" Text="Add" OnClick="addBtn_Click" />
                <asp:Button CssClass="btn btn-primary" ID="removeBtn" runat="server" Text="Remove" OnClick="removeBtn_Click" />
                <asp:Button CssClass="btn btn-danger" ID="cancelAddBtn" runat="server" Text="Cancel" OnClick="cancelAddBtn_Click" />

                <asp:Button CssClass="btn btn-danger" ID="high_school_maintanence_backBtn" runat="server" Text="Back" OnClick="high_school_maintanence_backBtn_Click" />
            </div>
            <div id="view_school" runat="server">
                <asp:DropDownList ID="view_school_dropdown" OnSelectedIndexChanged="view_school_dropdown_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" runat="server" DataTextField="name" DataValueField="num"></asp:DropDownList><br />
                <label>Head Student</label><br />
                <label id="head_student" runat="server"></label><br />
                <asp:Button ID="view_school_backBtn" CssClass="btn btn-danger" runat="server" Text="Back" OnClick="view_school_backBtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
