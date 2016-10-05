db<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="DeleteAccount.aspx.cs" Inherits="Expensite.Web.DeleteAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border:solid;height:200px;width:500px">
                <tr>
                <td colspan="3" style="text-align:center; font-weight:bold;">Delete Your Account</td>
                   </tr>
                <tr>
                    <td colspan="3" style="color:black">Kindly tell us reason for deleting account:</td>
                </tr>
                <tr>
                    <td colspan="2"><asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox></td>
                    <td style="color:red"><asp:RequiredFieldValidator ID="Reason" runat="server" ControlToValidate="txtReason" ErrorMessage="Reason for deleting Account Must requitred" ValidationGroup="reason"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:center"><asp:Button ID="btnDelete" runat="server" Text="Delete Account" ValidationGroup="reason" OnClick="btnDelete_Click" CssClass="TestStyle" Height="29px"></asp:Button></td>
                </tr>
            </table>
</asp:Content>
