<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Expensite.Web.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
: <head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 197px;
        }
        .auto-style2 {
            height: 39px;
            width: 320px;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            color: #1FADBE;
        }
        .auto-style5 {
            font-size: large;
            color: #1FADBE;
        }
        .auto-style6 {
            height: 34px;
            width: 320px;
            font-size: medium;
        }
        .auto-style8 {
            color: #000000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
           
                <div class="body-bg">
                    <!-- HEADER -->
                    <div id="header">
                        <div class="row-1">
                            <div class="fleft" style="background-color:#333333; height: 69px;">
                                <img src="images/logo.jpg" alt="" style
                                    ="height:45px; width:50px;"/>
                                <label id="lblName" style="font-size: 35px; color: #20B7C9;">Expensite</label>
                            </div>
                          </div> 
                        </div>
                    </div>
        <center>
    <table>
        <tr><td class="auto-style2"><span class="auto-style5"><strong>F</strong></span><span class="auto-style4"><strong class="auto-style3">orgot Your Password??</strong></span></td></tr>
        <tr><td class="auto-style6">Please Enter your Email-Id and Password Below</td></tr>
        </table>
        <table>
         <tr>
            <td class="auto-style8"><strong>E-Mail :</strong></td>
            <td class="auto-style1"><asp:TextBox ID="txtEmail1" runat="server" /></td>
            </tr>
        <tr>
            <td><span class="auto-style8"><strong>Mobile No</strong></span><strong> :</strong></td>
            <td class="auto-style1"><asp:TextBox ID="txtMobile" runat="server" /></td>
        </tr>
        <tr ><td colspan="3" style="text-align:center"><asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" Width="122px" OnClick="btnResetPassword_Click" Height="32px" style="font-weight: 700; color: #FFFFFF; background-color: #20B7C9"   /></td></tr>
    </table>
            </center>
    </div>
    </form>
</body>
</html>
