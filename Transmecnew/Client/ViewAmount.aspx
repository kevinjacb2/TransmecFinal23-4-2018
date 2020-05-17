<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAmount.aspx.cs" Inherits="Client_ViewAmount" %>

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
    <table class="style1" width=80% align="center">
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
                <table class="table" width="80%" align="center">
                    <tr>
                        <td colspan="3" class="title123">
                            Client&nbsp; Information
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Select&nbsp; Id
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGivenId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGivenId_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Booking ID
                        </td>
                        <td>
                            <asp:TextBox ID="txtBookingId" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Client ID
                        </td>
                        <td>
                            <asp:TextBox ID="txtClientId" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           ClientChoice Id
                        </td>
                        <td>
                            <asp:TextBox ID="txtClientChoiceId" runat="server"></asp:TextBox>
                            <asp:Label ID="lblChoiceType" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        
                        </td>
                        <td>
                            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
                            </asp:DetailsView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           Car Rate
                        </td>
                        <td>
                            <asp:Label ID="lblRate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           Pick up time
                        </td>
                        <td>
                            <asp:Label ID="lblPickupTime" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           Approxiamte Km
                        </td>
                        <td>
                            <asp:Label ID="lblApproximateKm" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           Approxiamte Rupees
                        </td>
                        <td>
                            <asp:Label ID="lblApproximateRupees" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                           Advance Rupees
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdvanceRupees" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                        </td>
                        <td>
                            Payment Through
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPaymentType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Cash</asp:ListItem>
                                <asp:ListItem>ByCheque</asp:ListItem>
                                <asp:ListItem>ByCreditCard</asp:ListItem>
                                <asp:ListItem>PayPal</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Button ID="btnCreditCard" runat="server" OnClick="btnCreditCard_Click" 
                                Text="ClickMe For Credit Card" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblBankName" runat="server" Text="BankName"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="Click For Paypal" 
                                onclick="Button1_Click" />
                            </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblChequeNo" runat="server" Text="ChequeNo :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtChequeNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblBranch" runat="server" Text="Branch Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btninsert" runat="server" OnClick="btninsert_Click" 
                                Text="Submit" CssClass="button" />
                            &nbsp; &nbsp;
                            <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" 
                                Text="Clear" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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

