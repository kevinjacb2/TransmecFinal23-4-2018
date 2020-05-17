<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bbShoppingCart.aspx.cs" Inherits="ShoppingCart"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>

    <table style="width: 86%;" class="table123">
        <tr>
            <td>
            </td>
            <td align="center">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Label ID="lblMSg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="center">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderMasterID"
                    Width="403px" EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("OrderMasterID") %>'
                                    OnClick="lnkDelete_Click">Remove Item From Cart</asp:LinkButton>
                                &nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProductName">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductId" Height="26px" Width="44px" runat="server" Text='<%# Bind("ProductMasterID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Product_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProductImage">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" Height="55px" Width="61px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:TemplateField HeaderText="Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" Height="26px" Width="44px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="lbltotal" runat="server" ForeColor="Red"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
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
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" 
                    Text="Total Amount  Rs. :="></asp:Label>
                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnCalculate" runat="server" OnClick="BtnCalculate_Click" 
                    Text="Calculate Amount" CssClass="button" />
            </td>
            <td>
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
        <tr>
            <td>
            </td>
            <td>
            &nbsp;
                <asp:Button ID="BtnContinue" runat="server" OnClick="BtnContinue_Click" 
                    Text="Continue Shopping ?" CssClass="button" />
                &nbsp;
                <img src="images/empty_cart.jpg" style="height: 71px; width: 94px" />&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Bill Payment" 
                    OnClick="Button2_Click" CssClass="button" />
            &nbsp;
                <asp:Button ID="btnCheckOut" runat="server" onclick="btnCheckOut_Click" 
                    Text="CheckOut" CssClass="button" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton7" runat="server" 
                    PostBackUrl="BuyProduct.aspx">Continue Shopping?</asp:LinkButton>
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
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblusername" runat="server" Visible="false"></asp:Label>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <link href="testcss/Mysheet.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>

