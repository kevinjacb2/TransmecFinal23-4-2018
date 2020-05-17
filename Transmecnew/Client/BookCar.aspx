<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="BookCar.aspx.cs" Inherits="Client_BookCar" %>

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
                <table class="table" align="center">
        <tr>
            <td class="title123" colspan="2">
                &nbsp;
                Car Details
            </td>
        </tr>
        <tr class="table">
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Label ID="lblCarid" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="table">
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtcarid" runat="server" Visible="False"></asp:TextBox>
                <asp:Label ID="lblClientId" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car Name
            </td>
            <td>
                <asp:TextBox ID="txtcarname" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car Model
            </td>
            <td>
                <asp:TextBox ID="txtcartype" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car Brand
            </td>
            <td>
                <asp:TextBox ID="txtcarbrand" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car Color
            </td>
            <td>
                <asp:TextBox ID="txtColor" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car Capacity
            </td>
            <td>
                <asp:TextBox ID="txtcarcapacity" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Fuel Type
            </td>
            <td>
                <asp:TextBox ID="txtFuelType" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car CC
            </td>
            <td>
                <asp:TextBox ID="txtcarcc" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car Mileage (Rate/Km)
            </td>
            <td>
                <asp:TextBox ID="txtcarmileage" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Rate Per Kilometer
            </td>
            <td>
                <asp:TextBox ID="txtRate" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                Car Image
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" />
            </td>
        </tr>
        <tr class="table">
            <td>
                Select Date
            </td>
            <td>
                <asp:Calendar ID="Calendar1" runat="server" ondayrender="Calendar1_DayRender" 
                    onselectionchanged="Calendar1_SelectionChanged" 
                    onvisiblemonthchanged="Calendar1_VisibleMonthChanged" Height="85px" 
                    Width="105px"></asp:Calendar>
            </td>
        </tr>
        <tr class="table">
            <td>
                Selected Date :</td>
            <td>
                <asp:TextBox ID="txtSelectedDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="table">
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Button ID="btn_insert" runat="server" Text="Book" 
                    OnClick="btn_insert_Click" CssClass="button" />
            </td>
        </tr>
        <tr class="table">
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

