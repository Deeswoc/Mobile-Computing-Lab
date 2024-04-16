<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="halls.aspx.cs" Inherits="Mobile_Computing_Lab.halls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Prison</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="crossorigin" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css2?family=Archivo+Narrow:ital,wght@0,400;1,500&family=Julius+Sans+One&display=swap" rel="stylesheet" />
</head>
<body class="bg-dark text-white">
    <form id="form1" class="" runat="server">
        <div class="container py-5">
            <h1 class="mb-3">UTech Residential Hall Applications
            </h1>
            <div class="form-check mb-2">
                <asp:CheckBox ID="CheckBox_student" CssClass="form-check-input" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_student_CheckedChanged" />
                <asp:Label ID="Label_student" CssClass="form-check-label" AssociatedControlID="CheckBox_student" runat="server" Text="Student"></asp:Label>
            </div>
            <div class="form-check mb-2">
                <asp:CheckBox ID="CheckBox_isAthlete" CssClass="form-check-input" AutoPostBack="true" Enabled="false" runat="server" OnCheckedChanged="CheckBox_isAthlete_CheckedChanged" />
                <asp:Label ID="Label_isAthelete" CssClass="form-check-label" AssociatedControlID="CheckBox_isAthlete" runat="server" Text="Is an Athlete"></asp:Label>
            </div>
            <div class="mb-2">
                <asp:Label ID="Label_hall" AssociatedControlID="DropDownList_hall" runat="server" Text="Hall:"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_hall" CssClass="form-select" Enabled="false" runat="server"></asp:DropDownList>
            </div>
            <div class="text-center w-100 py-4">

            <asp:Button ID="Button_reset" CssClass="btn btn-primary"  runat="server" Text="Reset" OnClick="Button_reset_Click" />
            </div>
        </div>
    </form>
</body>
</html>
