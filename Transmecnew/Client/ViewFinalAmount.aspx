<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFinalAmount.aspx.cs" Inherits="Client_ViewFinalAmount" %>

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
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Given Id
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
                            Approve Id
                        </td>
                        <td>
                            <asp:Label ID="lblApproveID" runat="server"></asp:Label>
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
                            <asp:Label ID="lblBookingId" runat="server"></asp:Label>
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
                            <asp:Label ID="lblClientId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Tour Type
                        </td>
                        <td>
                            <asp:Label ID="lblChoiceType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Car ID
                        </td>
                        <td>
                            <asp:Label ID="lblCarId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Car Rate Per KM
                        </td>
                        <td>
                            <asp:Label ID="lblCarRate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Start Date
                        </td>
                        <td>
                            <asp:Label ID="lblGivenDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Starting Meter Reading
                        </td>
                        <td>
                            <asp:Label ID="lblReading" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Car Return Date
                        </td>
                        <td>
                            <asp:Label ID="lblCarReturnDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Car Return Meter Reading
                        </td>
                        <td>
                            <asp:Label ID="lblReturnMeterReading" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Total Kilometer
                        </td>
                        <td>
                            <asp:Label ID="lblTotalKM" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Total Amount
                        </td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
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
                            <asp:Label ID="lblAdvanceRupees" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Remaining Amount
                        </td>
                        <td>
                            <asp:Label ID="lblRemainingAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <div id="divPayment" runat="server">
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
                                    <asp:ListItem>Paypal</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                                <asp:Button ID="btnCreditCard" runat="server" OnClick="btnCreditCard_Click" Text="ClickMe For Credit Card" />
                            </td>
                            <td>
                                &nbsp;
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
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                    Text="Click For Paypal" />
                            </td>
                            <td>
                                &nbsp;
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
                            <td>
                                &nbsp;
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
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </div>
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

