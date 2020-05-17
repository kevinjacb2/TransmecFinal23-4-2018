<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewParticularClient.aspx.cs" Inherits="Admin_ViewParticularClient" %>

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
                            Client&nbsp; Information
                            <asp:Label ID="lblBookingId" runat="server" Visible="False"></asp:Label>
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
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtBookingId" runat="server" Visible="False"></asp:TextBox>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClientName"
                                ErrorMessage="Enter Name">*</asp:RequiredFieldValidator>
                            <asp:Label ID="lblClientId" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Gender
                        </td>
                        <td>
                            <asp:RadioButton ID="rdomale" runat="server" GroupName="x" Text="Male" Enabled="False" />
                            <asp:RadioButton ID="rdofemale" runat="server" GroupName="x" Text="Female" Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtaddr" runat="server" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddr"
                                ErrorMessage="Enter Address">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            State Id
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlstateid" runat="server" Enabled="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlstateid"
                                ErrorMessage="Select State">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            City
                        </td>
                        <td>
                            <asp:TextBox ID="txtcity" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcity"
                                ErrorMessage="Enetr City">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Contact No
                        </td>
                        <td>
                            <asp:TextBox ID="txtcontactno" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Email Id
                        </td>
                        <td>
                            <asp:TextBox ID="txtemailid" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtemailid"
                                ErrorMessage="Enter Email Id">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtemailid"
                                ErrorMessage="Enter Valid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
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
                        </td>
                        <td>Booking Information
                        </td>
                        <td>
                            <asp:Label ID="lblChoiceId" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblChoiceType" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblCarId" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
                            </asp:DetailsView>
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
                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="lblPickuptime" runat="server" Text=""></asp:Label>
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
                        &nbsp;<asp:Label ID="lblLocalCityRate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                             <asp:Label ID="lblAppKm" runat="server" Text="Enter Approximate Km"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtApproKm" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                Text="Calculate Approximate Rupees" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                         <asp:Label ID="lblAppRupees" runat="server" Text="Approximate Rupees"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblapproRupees" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                       <asp:Label ID="lblAdRupees" runat="server" Text=" Advance Rupees"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdvanceRupees" runat="server"></asp:TextBox>
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
                            <asp:Label ID="lblMsg" runat="server" Text="....."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btninsert" runat="server" OnClick="btninsert_Click" 
                                Text="Approve" CssClass="button" />
                            &nbsp; &nbsp;
                            <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" 
                                Text="Reject" CssClass="button" />
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

