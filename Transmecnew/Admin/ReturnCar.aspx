<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ReturnCar.aspx.cs" Inherits="Admin_ReturnCar" %>

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
                <table class="table" width="80%" align="center">
                    <tr>
                        <td colspan="3" class="title123">
                            Return Car&nbsp; Information
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
                            <asp:GridView ID="GridView1" runat="server">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument='<%# Eval("Appove_id") %>'>View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <div id="divReturnCar" runat="server">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Given Id
                            </td>
                            <td>
                                <asp:Label ID="lblGivenId" runat="server"></asp:Label>
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
                                Choice Id
                            </td>
                            <td>
                                <asp:Label ID="lblChoiceID" runat="server"></asp:Label>
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
                                Car Driver Id
                            </td>
                            <td>
                                <asp:Label ID="lblDriverId" runat="server"></asp:Label>
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
                                <asp:Label ID="lblCarRate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Local Car Rate Per Hrs
                            </td>
                            <td>
                                <asp:Label ID="lblLocalCarRateperhr" runat="server"></asp:Label>
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
                                Start Date
                            </td>
                            <td>
                                <asp:Label ID="lblGivenDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <div id="divOutstation" runat="server">
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
                                    <asp:TextBox ID="txtCarReturn" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtReturnReading" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnCalculate" runat="server" Text="Calculate" 
                                        OnClick="btnCalculate_Click" CssClass="button" />
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
                                    <asp:TextBox ID="txtKilometer" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </div>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Remaining Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemainingAmount" runat="server"></asp:TextBox>
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
                    </div>
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

