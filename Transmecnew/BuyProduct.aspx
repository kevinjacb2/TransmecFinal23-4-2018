<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuyProduct.aspx.cs" Inherits="ShowBuyProduct" %>


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
                <tr class="table123">
                    <td class="title1">
                        Show Product&nbsp;
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                </tr>
                <tr class="table123">
                    <td>
                        &nbsp;</td>
                </tr>
                <tr class="table123">
                    <td>
                        Select Product Category&nbsp;&nbsp;&nbsp;
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlProdCate" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlProdCate_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr class="table123">
                    <td>
                        Select Product Sub Category&nbsp;&nbsp;
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubCat" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlSubCat_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr class="table123">
                    <td>
                        &nbsp;</td>
                </tr>
                <tr class="table123">
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DataList ID="DataList1" runat="server" 
                                    onitemcommand="DataList1_ItemCommand" RepeatColumns="4" 
                                    RepeatDirection="Horizontal">
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
                                        <asp:LinkButton ID="lnkbuyProd" runat="server" 
                                            CommandArgument='<%# Eval("Product_Id") %>' CommandName="Cart" ForeColor="Red" 
                                            onclick="lnkbuyProd_Click">Buy Product</asp:LinkButton>
<br />
                                    </ItemTemplate>
                                </asp:DataList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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

