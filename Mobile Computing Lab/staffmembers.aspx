<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffmembers.aspx.cs" Inherits="Mobile_Computing_Lab.Staffmembers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile Computing Lab 1: Daniel Nelson - 1705813</title>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="crossorigin" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/staffmembers.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://fonts.googleapis.com/css2?family=Archivo+Narrow:ital,wght@0,400;1,500&family=Julius+Sans+One&display=swap" rel="stylesheet" />
</head>
<body>
    <div class="plane-bg">

    </div>
    <form id="form1" runat="server" class="container pt-5">
        <div class="row">
            <div class="col">
                <h1 class="text-center mb-4">Staff Members</h1>
            </div>
            <div class="form-check mb-2">
                <asp:CheckBox OnCheckedChanged="TurnOffCheckBox_CheckedChanged" CssClass="form-check-label d-inline-block" ID="TurnOffCheckBox" runat="server" AutoPostBack="true" />
                <asp:Label runat="server" CssClass="fomr-check-input" AssociatedControlID="TurnOffCheckBox" Text="Turn Off"></asp:Label>
            </div>
            <div class="mb-2">
                <asp:Label AssociatedControlID="DepartmentDropdown" runat="server" Text="Department"></asp:Label><br />
                <asp:DropDownList
                    ID="DepartmentDropdown"
                    AutoPostBack="true"
                    runat="server"
                    DataTextField="department name"
                    CssClass="form-control"
                    DataValueField="department num"
                    OnSelectedIndexChanged="DepartmentDropdown_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="mb-2">
                <asp:Label runat="server" Text="Staff Member"></asp:Label><br />
                <asp:DropDownList
                    ID="StaffMemberDropDown"
                    AutoPostBack="true"
                    runat="server"
                    CssClass="form-control"
                    DataTextField="member name"
                    DataValueField="member num"
                    OnSelectedIndexChanged="StaffMemberDropDown_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div id="StaffInfo" class="mb-2">
                <asp:Label runat="server" Text="Contact No for Staff Member"></asp:Label><br />
                <asp:Label ID="MemberContactNumber" runat="server" CssClass="ps-2 fw-bold text-info" Font-Size="Large" Text="-"></asp:Label><br />
                <asp:Label runat="server" Text="Full Address of Staff Member"></asp:Label><br />
                <asp:Label ID="MemberAddress" runat="server" CssClass="ps-2 fw-bold text-info" Font-Size="Large" Text="-"></asp:Label><br />
            </div>
            <div>
                <asp:Label AssociatedControlID="PastTraveledCountriesDropdown" runat="server" Text="Label"></asp:Label><br />
                <asp:DropDownList ID="PastTraveledCountriesDropdown"
                    AutoPostBack="true"
                    runat="server"
                    DataTextField="country name"
                    CssClass="form-control"
                    DataValueField="country num"
                    OnSelectedIndexChanged="PastTraveledCountriesDropdown_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
    </form>
</body>
</html>
