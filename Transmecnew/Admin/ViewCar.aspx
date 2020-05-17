<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCar.aspx.cs" Inherits="Admin_ViewCar" %>

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
                <table width=80% class="table">
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Label ID="lblCarType" runat="server" Visible="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView1" runat="server" 
                                onrowdatabound="GridView1_RowDataBound">
                               
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkbtnedit" runat="server" CommandArgument='<%# Eval("CarDetail_id") %>'
                                                OnClick="linkbtnedit_Click">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Car Image">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" Height="60px" 
                                                ImageUrl='<%# Eval("Car_Image") %>' Width="60px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView> <asp:Label ID="lblCarId" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblClientId" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblChoiceId" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                            <td>
                                <asp:Label ID="lblSelectDate" runat="server" Text="Select Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" 
                                    OnVisibleMonthChanged="Calendar1_VisibleMonthChanged1" 
                                    onselectionchanged="Calendar1_SelectionChanged">
                                </asp:Calendar>
                               
                            </td>
                        </tr>
                    <div id="divOutStation" runat="server">
                        
                        <tr>
                            <td>
                                Start Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                End Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Pick up Time
                            </td>
                            <td>
                                <asp:TextBox ID="txtOutPickUptime" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnBook" runat="server" Text="Book" OnClick="btnBook_Click" />
                            </td>
                        </tr>
                    </div>
                    <div id="divLocal" runat="server">
                         <tr>
                            <td>
                                Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtLocalDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Pick up Time
                            </td>
                            <td>
                                <asp:TextBox ID="txtLocalPickUptime" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnBooklocal" runat="server" Text="Book" OnClick="btnBook_Click" />
                            </td>
                        </tr>
                    </div>
                    <div id="divAirport" runat="server">
                        <tr>
                            <td>
                                Select Date
                            </td>
                            <td>
                                <asp:Calendar ID="Calendar3" runat="server" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged1">
                                </asp:Calendar>
                                <asp:TextBox ID="txtAirportDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Time
                            </td>
                            <td>
                                <asp:TextBox ID="txtAirportTime" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnAirport" runat="server" Text="Book" OnClick="btnBook_Click" 
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

