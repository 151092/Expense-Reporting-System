<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Expensite.Web.UserProfile" Codebehind="UserProfile.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="hdf" runat="server" />
    <table style="width: 625px; height: 679px">
        <tr>
            <td style="width: 1px"><b>Name:</b></td>
        </tr>
        <tr> 
            <td style="width: 1px">FirstName</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtFName" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="First Name is Required" ValidationGroup="profile" ControlToValidate="txtFName"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 1px">MiddleName</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtMName" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Middle Name is Required" ValidationGroup="profile" ControlToValidate="txtMName"></asp:RequiredFieldValidator></td>

        </tr>
        <tr>
            <td style="width: 1px">LastName</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtLName" runat="server" Width="175px" Height="20px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Last Name is Required" ValidationGroup="profile" ControlToValidate="txtLName"></asp:RequiredFieldValidator></td>

        </tr>

        
       
        <tr>
            <td style="width: 1px">UserType</td>

            <td style="width: 80px">
                <asp:TextBox ID="txtUserType" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="User Type is Required" ValidationGroup="profile" ControlToValidate="txtUserType"></asp:RequiredFieldValidator></td>

        </tr>

        <tr>
            <td style="width: 1px">EmailID</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtEmailId" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="Email ID is Required" ValidationGroup="profile" ControlToValidate="txtEmailId"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmailId" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
            </td>

        </tr>
        <tr>
            <td style="width: 1px">BirthDate</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtBOD" runat="server" Width="175px" Height="20px" TextMode="DateTime"></asp:TextBox></td>
            <cc1:CalendarExtender ID="calender" runat="server" TargetControlID="txtBOD" Format="MM/dd/yyyy"></cc1:CalendarExtender>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="Birth Date is Required" ValidationGroup="profile" ControlToValidate="txtBOD"></asp:RequiredFieldValidator>
                
            </td>


        </tr>
        <tr>
            <td style="width: 1px">Gender</td>
            <td style="width: 80px">
                <asp:RadioButtonList ID="rbGender" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" Width="175px" Height="20px">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="Must Select Gender" ValidationGroup="profile" ControlToValidate="rbGender"></asp:RequiredFieldValidator></td>


        </tr>
        <tr>
            <td style="width: 1px">Mobile No</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtMobileNo" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="Mobile No is Required" ValidationGroup="profile" ControlToValidate="txtMobileNo"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="phoneregularExpression" runat="server" ForeColor="Red" ErrorMessage="Mobile No is not valid"
ControlToValidate="txtMobileNo" Text="Please enter atleast 10 digits" ValidationExpression="^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 1px"><b>Address:</b></td>
        </tr>
        <tr>
            <td style="width: 1px; height: 32px;">Appartment</td>
            <td style="height: 32px; width: 80px;">
                <asp:TextBox ID="txtAppartment" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ErrorMessage="Appartment is Required" ValidationGroup="profile" ControlToValidate="txtAppartment"></asp:RequiredFieldValidator></td>

        </tr>
        <tr>
            <td style="width: 1px">Street</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtStreet" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 1px">City</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtCity" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" ErrorMessage="City is Required" ValidationGroup="profile" ControlToValidate="txtCity"></asp:RequiredFieldValidator></td>

        </tr>
        <tr>
            <td style="width: 1px">Pincode</td>
            <td style="width: 80px">
                <asp:TextBox ID="txtPincode" runat="server" Width="175px" Height="20px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ErrorMessage="Pincode is Required" ValidationGroup="profile" ControlToValidate="txtPincode"></asp:RequiredFieldValidator></td>

        </tr>
        <tr>
            <td colspan="3" style="border-radius:10px;text-align:center">
                <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="86px" ValidationGroup="profile" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Button ID="btnReset" runat="server" Text="RESET" Width="87px" OnClick="btnReset_Click" />
           </td>
        </tr>

    </table>

</asp:Content>

