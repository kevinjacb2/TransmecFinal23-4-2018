<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Insurance.aspx.cs" Inherits="Admin_Insurance" %>

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
        <td class="title123" colspan="2">
            Insurance Details</td>
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
            &nbsp;</td>
        <td>
            <asp:TextBox ID="txtinsuranceid" runat="server" Visible="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Insurance Company Name</td>
        <td>
            <asp:TextBox ID="txtcmpanyname" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Insurance Description</td>
        <td>
            <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Car Id</td>
        <td>
            <asp:DropDownList ID="ddcarid" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Insurance Amount</td>
        <td>
            <asp:TextBox ID="txtinsuranceamt" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Insurance Date</td>
        <td>
            <asp:TextBox ID="txtinsurancedate" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Insurance Expiry Date</td>
        <td>
            <asp:TextBox ID="txtexpirydate" runat="server"></asp:TextBox>
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
            <asp:Button ID="btn_insert" runat="server" Text="Insert" 
                onclick="btn_insert_Click" CssClass="button" />
            <asp:Button ID="btn_delete" runat="server" Text="Delete" 
                onclick="btn_delete_Click" CssClass="button" />
            <asp:Button ID="btn_update" runat="server" Text="Update" 
                onclick="btn_update_Click" CssClass="button" />
            <asp:Button ID="btn_clear" runat="server" Text="Clear" 
                onclick="btn_clear_Click" CssClass="button" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="link_edit" runat="server" 
                                CommandArgument='<%# Eval("Insurance_id") %>' onclick="link_edit_Click">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="link_delete" runat="server" 
                                CommandArgument='<%# Eval("Insurance_id") %>' onclick="link_delete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
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

