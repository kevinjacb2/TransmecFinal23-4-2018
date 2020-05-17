<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="BookCab.aspx.cs" Inherits="Client_BookCab" %>

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
                <table style="width: 100%" class="table">
                    <tr>
                        <td colspan="2">
                            &nbsp;
                            <asp:Label ID="lblClientId" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Select Option
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>OutStation</asp:ListItem>
                                <asp:ListItem>Local</asp:ListItem>
                                <%--<asp:ListItem>Airport</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <div id="divOutStation" runat="server">
                        <tr>
                            <td>
                                From City
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCityOutStation" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Destination City
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDestinationCity" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                        
                    </div>
                    <div id="divLocal" runat="server">
                        <tr>
                            <td>
                                In City
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLocalCity" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Travel Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtLocalDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Per Hrs/Per Km
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHrs" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </div>
                    <div id="divAirport" runat="server">
                        <tr>
                            <td>
                                Select Option
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAirport" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>From Airport</asp:ListItem>
                                    <asp:ListItem>Coming From</asp:ListItem>
                                    <asp:ListItem>Both</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Airport
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAirportCity" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Going To Airport</asp:ListItem>
                                    <asp:ListItem>Coming From Airport</asp:ListItem>
                                    <asp:ListItem>With Return</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Travel Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtAirportDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </div>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                OnClick="btnSearch_Click" CssClass="button" />
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

