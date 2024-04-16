<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modules.aspx.cs" Inherits="Mobile_Computing_Lab.modules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/default.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div id="main" class="d-flex flex-column" runat="server">
                <br />
                <asp:Button ID="student_maintanence_btn" CssClass="btn btn-primary" runat="server" Text="Student Maintanence" OnClick="student_maintanence_btn_Click" />
                <asp:Button ID="module_maintanence_btn" CssClass="btn btn-primary" runat="server" Text="Module Mainanence" OnClick="module_maintanence_btn_Click" />
                <asp:Button ID="module_info_btn" CssClass="btn btn-primary" runat="server" Text="Module Info" OnClick="module_info_btn_Click" />
            </div>
            <div id="module_info" runat="server">
                <div class="div">
                    <asp:Label ID="Label1" runat="server" Text="Student"></asp:Label>
                    <br />
                    <asp:DropDownList
                        CssClass="droplist"
                        ID="StudentDropdown"
                        runat="server"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="StudentDropdown_SelectedIndexChanged"
                        DataTextField="student"
                        DataValueField="student num">
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="student_fname" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="student_lname" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="div">
                    <asp:Label ID="Label2" runat="server" Text="Module"></asp:Label>
                    <br />
                    <asp:DropDownList
                        CssClass="droplist"
                        ID="ModuleDropdown"
                        runat="server"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ModuleDropdown_SelectedIndexChanged"
                        DataValueField="module num"
                        DataTextField="module code">
                    </asp:DropDownList>
                </div>
                <div class="info-box">
                    <div>
                        <asp:Label runat="server" Text="Lecturer"></asp:Label>
                        <br />
                        <asp:Label ID="lecturer" runat="server" ForeColor="Brown" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="lecturer_email" runat="server" ForeColor="Brown" Text="Label"></asp:Label>
                        <br />
                        <br />
                        <asp:Label runat="server" Text="Faculty/College to which module belongs"></asp:Label>
                        <br />
                        <asp:Label ID="faculty_college_owner" ForeColor="Brown" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
                <div id="module-students">
                    <asp:Label ID="Label3" runat="server" Text="Students doing this module"></asp:Label>
                    <br />
                    <asp:DropDownList
                        CssClass="droplist"
                        ID="ModuleStudentsDropdown"
                        runat="server"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ModuleStudenstDropdown_SelectedIndexChanged"
                        DataTextField="student name"
                        DataValueField="student num">
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="text-center py-2">
                    <asp:Button ID="module_info_back_btn" runat="server" Text="Go Back" CssClass="btn btn-primary" OnClick="module_info_back_btn_Click" />
                </div>
            </div>
            <div id="student_maintanence" runat="server">
                <br />
                <asp:Label runat="server" Text="Student"></asp:Label>
                <asp:DropDownList
                    ID="students_maintanence_dropdown"
                    runat="server"
                    DataTextField="student"
                    DataValueField="student num"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="students_maintanence_dropdown_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="student_maintanence_edit_btn" runat="server" Text="Edit" OnClick="student_maintanence_edit_btn_Click" />
                <br />
                <br />
                <asp:Label ID="first_name_lbl" runat="server" Text="First Name"></asp:Label>
                <asp:TextBox ID="student_maintanence_firstname_txt_bx" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="last_name_lbl" runat="server" Text="Last Name"></asp:Label>
                <asp:TextBox ID="student_maintanence_lastname_txt_bx" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="student_maintanence_feedback" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:GridView ID="students_gridview" runat="server" BorderStyle="None" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="students_select" runat="server" Text="Select" OnClick="students_select_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="students_edit" runat="server" Text="Select" OnClick="students_edit_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="student num" />
                        <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="last name" HeaderText="Last Name" HeaderStyle-CssClass="labelstuff" />
                        <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="first name" HeaderText="First Name" HeaderStyle-CssClass="labelstuff" />
                    </Columns>
                </asp:GridView>
                <asp:TextBox ID="gridviewstudents_selected_num" Visible="false" runat="server"></asp:TextBox>
                <asp:Button ID="student_maintanence_new" runat="server" Text="New" OnClick="student_maintanence_new_Click" />
                <asp:Button ID="student_maintanence_add" runat="server" Text="Add" OnClick="student_maintanence_add_Click" />
                <asp:Button ID="student_maintanence_update" runat="server" Text="Update" OnClick="student_maintanence_update_Click" />
                <asp:Button ID="student_maintanence_go_back" runat="server" Text="Go Back" OnClick="student_maintanence_go_back_Click" />
            </div>
            <div id="module_maintanence" runat="server">
                <asp:Button ID="module_maintanence_new" runat="server" Text="New" OnClick="module_maintanence_new_Click" />
                <asp:Button ID="module_maintanence_add" runat="server" Text="Add" OnClick="module_maintanence_add_Click" />
                <asp:Button ID="module_maintanence_update" runat="server" Text="Update" OnClick="module_maintanence_update_Click" />
                <asp:Button ID="module_maintanence_go_back" runat="server" Text="Go Back" OnClick="module_maintanence_go_back_Click" />
            </div>
        </div>
    </form>
</body>
</html>
