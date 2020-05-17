<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowProduct.aspx.cs" Inherits="ShowProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="nav-justified">
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
                    <td class="title1">
                        Show Product</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Select Product Category&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlProdCate" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlProdCate_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Select Sub Category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlSubCat" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlSubCat_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" 
                            RepeatDirection="Horizontal" 
                            >
                            <ItemTemplate>
                                Product_Id:
                                <asp:Label ID="Product_IdLabel" runat="server" 
                                    Text='<%# Eval("Product_Id") %>' />
                                <br />
                                Product_Name:
                                <asp:Label ID="Product_NameLabel" runat="server" 
                                    Text='<%# Eval("Product_Name") %>' />
                                <br />
                                Quantity:
                                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                                <br />
                                Rate:
                                <asp:Label ID="RateLabel" runat="server" Text='<%# Eval("Rate") %>' />
                                <br />
                                <asp:Label ID="Product_Category_IdLabel" runat="server" 
                                    Text='<%# Eval("Product_Category_Id") %>' />
                                <br />
                                <br />
                                <asp:Image ID="Image3" runat="server" Height="150px" 
                                    ImageUrl='<%# Eval("Prod_Image") %>' Width="150px" />
<br />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
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

