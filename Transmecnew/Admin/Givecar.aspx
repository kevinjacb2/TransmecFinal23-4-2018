<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Givecar.aspx.cs" Inherits="Admin_Givecar" %>

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
                            Today Booking Information
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
                    <%-- <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Booking Id</td>
                        <td>
                            <asp:TextBox ID="txtBookingId" runat="server" Visible="False"></asp:TextBox>
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
                            Client Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtClientName" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Car Id</td>
                        <td>
                            <asp:TextBox ID="txtCar" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Car Rate</td>
                        <td>
                            <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Car Starting Meter Reading</td>
                        <td>
                            <asp:TextBox ID="txtCarMeter" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btninsert" runat="server" OnClick="btninsert_Click" 
                                Text="Submit" />
                            &nbsp; &nbsp;
                            <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" 
                                Text="Clear" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
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
                    <div id="divDetail" runat="server">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Booking Id
                            </td>
                            <td>
                                <asp:Label ID="lblBookingId" runat="server"></asp:Label>
                                <asp:Label ID="ApproveId" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Client Id
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
                                <asp:Label ID="lblTourType" runat="server"></asp:Label>
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
                                <asp:Label ID="lblStartdate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                End Date
                            </td>
                            <td>
                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Approximate Km
                            </td>
                            <td>
                                <asp:Label ID="lblAppKm" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Approximate Rupees
                            </td>
                            <td>
                                <asp:Label ID="lblAppRupees" runat="server"></asp:Label>
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
                                Remaining Rupees
                            </td>
                            <td>
                                <asp:Label ID="lblRemainingRupees" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Payment Type
                            </td>
                            <td style="margin-left: 120px">
                                <asp:Label ID="lblPaymentType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Select Driver
                            </td>
                            <td style="margin-left: 120px">
                                <asp:DropDownList ID="ddlDriver" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Car Starting Meter Reading
                            </td>
                            <td>
                                <asp:TextBox ID="txtReading" runat="server"></asp:TextBox>
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
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" 
                                    CssClass="button" />
                            </td>
                        </tr>
                    </div>
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

