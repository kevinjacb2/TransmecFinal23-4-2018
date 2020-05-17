<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Car.aspx.cs" Inherits="Admin_Car" %>

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
   
   
    <table class="style1" align="center" width=80%>
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
                        <td colspan="2">
                            &nbsp;
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtcarid" runat="server" Visible="False"></asp:TextBox>
                        </td>
                        <tr>
                            <td>
                                Vehicle Name
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCarName" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlCarName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;Vehicle Brand
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtcarbrand" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Remaining Vehicle</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRemainingCar" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vehicle Model
                            </td>
                            <td>
                                <asp:TextBox ID="txtcartype" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vehicle Color
                            </td>
                            <td>
                                <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vehicle Capacity
                            </td>
                            <td>
                                <asp:TextBox ID="txtcarcapacity" runat="server" Height="16px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fuel Type
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddfueltype" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vehicle CC
                            </td>
                            <td>
                                <asp:TextBox ID="txtcarcc" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vehicle Mileage (Rate/Km)
                            </td>
                            <td>
                                <asp:TextBox ID="txtcarmileage" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Chasses No
                            </td>
                            <td>
                                <asp:TextBox ID="txtchassesno" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Engine No
                            </td>
                            <td>
                                <asp:TextBox ID="txtengineno" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rate Per Kilometer
                            </td>
                            <td>
                                <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Local City Rate
                            </td>
                            <td>
                                <asp:TextBox ID="txtLocalCityRate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vehicle Image
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                &nbsp;
                                <asp:Image ID="Image3" runat="server" Height="38px" Width="50px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btn_insert" runat="server" Text="Insert" 
                                    OnClick="btn_insert_Click" CssClass="button" />
                                <asp:Button ID="btn_delete" runat="server" Text="Delete" 
                                    OnClick="btn_delete_Click" CssClass="button" />
                                <asp:Button ID="btn_update" runat="server" Text="Update" 
                                    OnClick="btn_update_Click" CssClass="button" />
                                <asp:Button ID="btn_clear" runat="server" OnClick="btn_clear_Click" 
                                    Text="Clear" CssClass="button" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <asp:GridView ID="GridView1" runat="server" align="center" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="link_edit" runat="server" CommandArgument='<%# Eval("CarDetail_id") %>'
                                                    OnClick="link_edit_Click">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="link_delete" runat="server" CommandArgument='<%# Eval("CarDetail_id") %>'
                                                    OnClick="link_delete_Click">Delete</asp:LinkButton>
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

