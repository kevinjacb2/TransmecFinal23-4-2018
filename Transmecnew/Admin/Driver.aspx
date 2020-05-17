<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Driver.aspx.cs" Inherits="Admin_Driver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <link href="Mysheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" width=80% align="center" >
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table class="table">
    <tr>
        <td class="title123" colspan="3">
            Driver Details<br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style3">
            <asp:TextBox ID="txtdriverid" runat="server" Visible="False"></asp:TextBox>
        </td>
        <td class="style3">
        </td>
    </tr>
    <tr>
        <td>
            Driver Name</td>
        <td>
            <asp:TextBox ID="txtdrivername" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver Address</td>
        <td>
            <asp:TextBox ID="txtdriveraddress" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver State</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddstate" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddstate_SelectedIndexChanged">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver City</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlCity" runat="server">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver DateofBirth</td>
        <td>
            <asp:TextBox ID="txtDateofBirth" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver License Number</td>
        <td>
            <asp:TextBox ID="txtdriverlicenseno" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver License Date</td>
        <td>
            <asp:TextBox ID="txtlicensedate" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver License Expiry Date</td>
        <td>
            <asp:TextBox ID="txtlicensexpdate" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Driver License Type</td>
        <td>
            <asp:DropDownList ID="ddlicensetype" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btn_insert" runat="server" onclick="btn_insert_Click" 
                Text="Insert" CssClass="button" />
            <asp:Button ID="btn_delete" runat="server" onclick="btn_delete_Click" 
                Text="Delete" CssClass="button" />
            <asp:Button ID="btn_update" runat="server" onclick="btn_update_Click" 
                Text="Update" CssClass="button" />
            <asp:Button ID="btn_clear" runat="server" onclick="btn_clear_Click" 
                Text="Clear" Height="34px" CssClass="button" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="link_edit" runat="server" 
                                CommandArgument='<%# Eval("Driver_id") %>' onclick="link_edit_Click">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="link_delete" runat="server" 
                                CommandArgument='<%# Eval("Driver_id") %>' onclick="link_delete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

