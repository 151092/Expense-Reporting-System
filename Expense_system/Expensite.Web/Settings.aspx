<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True" CodeBehind="Settings.aspx.cs" Inherits="Expensite.Web.Settings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="height:150px;width:630px;">
            <tr style="text-align: center">
                <td>
                    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" CssClass="TestStyle" Width="150px" /></td>
                <td>
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="TestStyle" Width="150px" />
                </td>
                <td>
                    <asp:Button ID="btnDeleteAccount" runat="server" Text="Delete your Account" CssClass="TestStyle" Width="150px" /></td>
            </tr>
            <tr style="text-align:center">
                <td>
                    <asp:Image ID="img1" runat="server" ImageUrl="~/images/Edit Profile.jpg" Height="100px" Width="100px" /></td>
                <td>
                    <asp:Image ID="img2" runat="server" ImageUrl="~/images/ChangePassword.jpg" Height="100px" Width="100px" /></td>
                <td>
                    <asp:Image ID="img3" runat="server" ImageUrl="~/images/Delete.jpg" Height="100px" Width="100px" /></td>
            </tr>
        </table>
    </div>
    <div>
        <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" targetcontrolid="btnChangePassword"
            popupcontrolid="pnlChangePassword" cancelcontrolid="imgCancel" backgroundcssclass="BackgroundStyle" enableviewstate="true">
    </cc1:modalpopupextender>
         <center>   
        <asp:Panel ID="pnlChangePassword" runat="server" BackImageUrl="~/images/popup.jpg" Hight="400px" Width="400px">
        
      <table style="border:solid;height:400px;width:400px" >
      <tr>
          <td colspan="2" style="text-align:center;font-weight:bold;color:white">Change Password</td>
          <td style="text-align:right">
              <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/images/Cancel.jpg" Height="25px" Width="25px" OnClientClick="window.child.close()" CausesValidation="false"/></td>

      </tr>

      <tr>
          <td style="width: 122px;color:white">
              Old Password</td>
          <td> 
               <asp:TextBox ID="txtOldPassword" runat="server" Height="20px"></asp:TextBox>
          </td>
          <td style="color:red">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Old password must be required" ValidationGroup="password" ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
          <td style="width: 122px;color:white">
              New Password
          </td>
          <td>
              <asp:TextBox ID="txtNewPassword" runat="server" Height="20px"></asp:TextBox>
          </td>
          <td style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="New Password is required" ControlToValidate="txtNewPassword" ValidationGroup="password" ></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
          <td style="width: 122px; height: 101px;color:white">Confirm Password</td>
          <td style="height: 101px">
              <asp:TextBox ID="txtConfirmPassword" runat="server" Height="20px"></asp:TextBox>
          </td>
          <td style="height: 101px;color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm password is required" ControlToValidate="txtConfirmPassword" ValidationGroup="password"></asp:RequiredFieldValidator>
              <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword" ValidationGroup="password"></asp:CompareValidator>
          </td>
      </tr>
      <tr>
          <td colspan="3" style="text-align:center">
              <asp:Button ID="btnChangePaswrd" runat="server" Text="Change Password" ValidationGroup="password" OnClick="btnChangePaswrd_Click" /></td>
         
      </tr>
  </table>
      </asp:Panel>
              </center>

    </div>
    <div>
     <cc1:modalpopupextender id="ModalPopupExtender2" runat="server" targetcontrolid="btnDeleteAccount"
            popupcontrolid="pnlDeleteAccount" cancelcontrolid="imgCancel1" backgroundcssclass="BackgroundStyle" enableviewstate="true">
    </cc1:modalpopupextender>
         <center> 
        <asp:Panel ID="pnlDeleteAccount" runat="server" BackImageUrl="~/images/popup.jpg" Height="300px" Width="400px">
            <table style="border:solid;height:300px;width:400px">
                <tr>
                <td colspan="2" style="text-align:center; font-weight:bold;color:white">Delete Your Account</td>
                <td style="text-align:right"><asp:ImageButton ID="imgCancel1" runat="server" ImageUrl="~/images/Cancel.jpg" Height="25px" Width="25px" OnClientClick="window.child.close()"></asp:ImageButton></td>
                   </tr>
                <tr>
                    <td colspan="3" style="color:white">Kindly tell us reason for deleting account:</td>
                </tr>
                <tr>
                    <td colspan="2"><asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox></td>
                    <td style="color:red"><asp:RequiredFieldValidator ID="Reason" runat="server" ControlToValidate="txtReason" ErrorMessage="Reason for deleting Account Must requitred" ValidationGroup="reason"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center"><asp:Button ID="btnDelete" runat="server" Text="Delete Account" ValidationGroup="reason" OnClick="btnDelete_Click"></asp:Button></td>
                </tr>
            </table>
       </asp:Panel>
             </center>
    </div>
</asp:Content>
