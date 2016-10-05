<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Expensite.Web.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 66px;
        }
    </style>
</head>
<body style="background-color:gray">
    <form id="form1" runat="server">
    <div style="background-color:lightgray">
    <table style="margin:250px 500px">
        <tr>
        <th colspan="2" style="text-align:center"> Login </th>
            </tr>
        <tr>
            <td>E Mail</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td class="auto-style1">
                <asp:RequiredFieldValidator ID="EMail" runat="server" ErrorMessage="E mail should not be Empty" ControlToValidate="txtEMail" Width="150" ValidationGroup="g1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td class="auto-style1"><asp:RequiredFieldValidator ID="Password" runat="server" ErrorMessage="Password should not be Empty" Width="150px" ControlToValidate="TxtPassword" ValidationGroup="g1"></asp:RequiredFieldValidator> </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" /></td>
            <td>
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
