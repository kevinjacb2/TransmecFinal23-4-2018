<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Mysheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" width="80%" align="center">
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
                <table align="center" cellpadding="6" cellspacing="0" width="400px" 
                class="table">
            <tr>
                <td colspan="3" class="title123">
                    &nbsp;Login&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="trr">
                    Email Id</td>
                <td class="trd">
                    :
                </td>
                <td>
                    <textboxwatermarkextender id="txtUserName_TextBoxWatermarkExtender" runat="server"
                        enabled="True" targetcontrolid="txtUserName" watermarktext="UserName">
                    </textboxwatermarkextender>
                    <asp:TextBox ID="txtuname" runat="server" Height="26px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuname"
                        Display="Dynamic" ErrorMessage="Enter Email Id" SetFocusOnError="True" 
                        ValidationGroup="v">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="trr">
                    Password
                </td>
                <td class="trd">
                    :
                </td>
                <td>
                    <textboxwatermarkextender id="txtPassword_TextBoxWatermarkExtender" runat="server"
                        enabled="True" targetcontrolid="txtPassword" watermarktext="Password">
                    </textboxwatermarkextender>
                    <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" Height="22px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpwd"
                        Display="Dynamic" ErrorMessage="Enter  Password" SetFocusOnError="True" 
                        ValidationGroup="v">*</asp:RequiredFieldValidator>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="v" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        PostBackUrl="~/Forgotpass.aspx">Forgot 
Password</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="v" 
                        OnClick="btnLogin_Click"  Font-Bold="True" CssClass="button" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Cancel" onclick="Button1_Click" 
                        CssClass="button" />
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

