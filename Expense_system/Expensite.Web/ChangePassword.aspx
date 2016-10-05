<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Expensite.Web.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 139px;
        }
        .auto-style2 {
            height: 101px;
            width: 139px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="border:solid;height:300px;width:400px" >
      <tr>
          <td colspan="3" style="text-align:center;font-weight:bold;">Change Password</td>
          
             
      </tr>

      <tr>
          <td style="width: 122px;">
              Old Password</td>
          <td> 
               <asp:TextBox ID="txtOldPassword" runat="server" Height="20px"></asp:TextBox>
          </td>
          <td style="color:red" class="auto-style1">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Old password must be required" ValidationGroup="password" ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
          <td style="width: 122px;">
              New Password
          </td>
          <td>
              <asp:TextBox ID="txtNewPassword" runat="server" Height="20px"></asp:TextBox>
          </td>
          <td style="color:red" class="auto-style1"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="New Password is required" ControlToValidate="txtNewPassword" ValidationGroup="password" ></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
          <td style="width: 122px; height: 101px;">Confirm Password</td>
          <td style="height: 101px">
              <asp:TextBox ID="txtConfirmPassword" runat="server" Height="20px"></asp:TextBox>
          </td>
          <td style="color:red" class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm password is required" ControlToValidate="txtConfirmPassword" ValidationGroup="password"></asp:RequiredFieldValidator>
              <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword" ValidationGroup="password"></asp:CompareValidator>
          </td>
      </tr>
      <tr>
          <td colspan="3" style="text-align:center">
              <asp:Button ID="btnChangePaswrd" runat="server" Text="Change Password" ValidationGroup="password" OnClick="btnChangePaswrd_Click"  CssClass="TestStyle" Height="29px"/></td>
         
      </tr>
  </table>
</asp:Content>
