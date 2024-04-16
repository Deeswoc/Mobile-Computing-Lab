<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inmates.aspx.cs" Inherits="Mobile_Computing_Lab.inmates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab Test 3</title>
    <link rel="stylesheet" type="text/css" href="Styles/default.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" class="px-2" runat="server">
        <div id="main" class="d-flex flex-column" runat="server">
            <br />
            <asp:Button ID="view_blocks" CssClass="btn btn-primary" runat="server" Text="View Blocks" OnClick="view_blocks_Click" />
            <asp:Button ID="new_inmate_btn" CssClass="btn btn-primary" runat="server" Text="New Inmate" OnClick="new_inmate_btn_Click" />
        </div>
        <div id="block_view">
            <asp:GridView ID="blocks_gridview" runat="server" BorderStyle="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="block num" />
                    <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="block name" HeaderText="Block Name" HeaderStyle-CssClass="labelstuff" />
                    <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="year opened" HeaderText="Year Opened" HeaderStyle-CssClass="labelstuff" />
                    <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="male" HeaderText="Male" HeaderStyle-CssClass="labelstuff" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="block_select" CssClass="btn btn-primary" runat="server" Text="Select" OnClick="block_select_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <asp:GridView ID="inmates_gridview" runat="server" BorderStyle="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="inmate num" />
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("last name") + ", " + Eval("first name")  %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="male" HeaderText="Block Name" HeaderStyle-CssClass="labelstuff" />
                    <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="year incarcerated" HeaderText="Year Opened" HeaderStyle-CssClass="labelstuff" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="inmate_select" CssClass="btn btn-primary" runat="server" Text="Select" OnClick="inmate_select_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Table CssClass="table" ID="inmate_details" runat="server">

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lastname_info" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="firstname_label" runat="server" Text="First Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="firstname_info" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="blockname_info" runat="server" Text="Year Incarcerated"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="year_incarcerated_info" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Year Due for Release"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="release_year_info" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label7" runat="server" Text="Convicted Offence"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="offence_commited_info" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>

            <asp:TextBox ID="gridviewblocks_selected_num" Visible="false" runat="server"></asp:TextBox>
            <asp:TextBox ID="gridviewinmates_selected_num" Visible="false" runat="server"></asp:TextBox>
            <asp:Button ID="move_inmate_block" CssClass="btn btn-primary" runat="server" Text="Move Block" OnClick="move_inmate_block_Click" />
            <asp:Button ID="save_inmate_block" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="save_inmate_block_Click" />
            <asp:Button ID="cancel_inmate_block_move" CssClass="btn btn-warning" runat="server" Text="Cancel" />
            <asp:DropDownList ID="inmate_block_dropdown" runat="server" DataTextField="block name" DataValueField="block num"></asp:DropDownList>

        </div>
        <div id="new_inmate_page" runat="server">
            <asp:Table CssClass="table" ID="new_inmate_table" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <input id="lastname_input" runat="server" type="text" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label5" runat="server" Text="First Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <input id="firstname_input" runat="server" type="text" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label8" runat="server" Text="Year Incarcerated"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <input id="year_incarcerated_input" runat="server" type="text" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label10" runat="server" Text="Year Due for Release"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <input id="year_for_release_input" runat="server" type="text" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label12" runat="server" Text="Convicted Offence"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="new_inmate_offense_dropdown" DataTextField="offence name" DataValueField="offence num" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label4" runat="server" Text="Block"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="new_inmate_block_dropdown" runat="server" DataTextField="block name" DataValueField="block num"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server" Text="Male"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="new_inmate_male_checkbox" OnCheckedChanged="new_inmate_male_checkbox_CheckedChanged" AutoPostBack="true" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button ID="save_new_inmate" CssClass="btn btn-primary" runat="server" Text="Save Inmate" OnClick="save_new_inmate_Click"/>
        </div>
    </form>
</body>
</html>
