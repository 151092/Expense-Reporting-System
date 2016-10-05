<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="Expensite.Web.AdminHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <table style="width: 404px; height: 146px">
        <tr>
        <th colspan="2" style="text-align:center"> Login </th>
            </tr>
        <tr>
            <td>E Mail</td>
            <td>
                <asp:TextBox ID="txtmail" runat="server"></asp:TextBox></td>
            <td class="auto-style1">
              
                <asp:RequiredFieldValidator ID="EMail" runat="server" ErrorMessage="E mail should not be Empty" ControlToValidate="txtMail" Width="150" ValidationGroup="g1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td class="auto-style1"><asp:RequiredFieldValidator ID="Password" runat="server" ErrorMessage="Password should not be Empty" Width="150px" ControlToValidate="TxtPassword" ValidationGroup="g1"></asp:RequiredFieldValidator> </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click1" /></td>
            <td>
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click1" /></td>
        </tr>
        </table>
    <br />
    <br />
    <br />
    <table>
           <tr>
        <th colspan="2" style="text-align:center"> Updates </th>
            </tr>
        <tr>
            <td> Date</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"></cc1:CalendarExtender></td>
            <td class="auto-style1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="date should not be Empty" ControlToValidate="txtDate" Width="150" ValidationGroup="g2"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Description</td>
            <td>
                <asp:TextBox ID="txtUpdate" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This field should not be Empty" Width="150px" ControlToValidate="txtUpdate" ValidationGroup="g2"></asp:RequiredFieldValidator> </td>
        </tr>
        <tr>
            <td style="text-align:center" colspan="2">
                <asp:Button ID="btnSaveUpdate" runat="server" Text="Save" ValidationGroup="g2" OnClick="btnSaveUpdate_Click"   /></td>
           
        </tr>
    

</table>
    
    
</asp:Content>
