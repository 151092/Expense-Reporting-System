<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Expensite.Web.Reports" Codebehind="Reports.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script  type="text/javascript">
        function pageLoad() {
            ShowPopup();
            setTimeout(HidePopup, 2000);
        }

        function ShowPopup() {
          
            $get('btnSubmit').click();
        }

        function HidePopup() {
        
            $get('ibtnCancel').click();
        }
</script>
    
  <div class="grid">

         <table style="width:624px; text-align:center">
             <tr><td colspan="3"></td></tr>

            <tr>
                
                <td style="border-radius:10px; text-align:center" colspan="2" >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" Width="92px" CssClass="TestStyle" Height="29px" /></td>
                    <td></td>
               <%-- <td style="border-radius: 10px; width: 100px;">
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" Width="85px" CssClass="TestStyle" /></td>--%>

               <%-- <td style="border-radius: 10px; " colspan="2">
                    <asp:Button ID="btnReport" runat="server" Text="GeneratePDF" Width="103px" CssClass="TestStyle" />
                  </td>--%>
                
                 </tr>
             
             <tr><td colspan="3"></td></tr>
              <tr><td colspan="3" style="height: 18px"></td></tr>

                <tr><td colspan="3">
                    <asp:TextBox ID="txtReport" runat="server" Height="20px" Width="500px">New Report</asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtReport" WatermarkText="New Report"></cc1:TextBoxWatermarkExtender></td></tr>
             
              <tr><td colspan="3"></td></tr>
             <tr>
                 <td class="auto-style3"></td>
                 <td  style="text-align:right" >Owner:</td>
                 <td style="text-align:left" class="auto-style4">
                     <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
             </tr>
              <tr>
                  <td class="auto-style3"></td>
                 <td style="text-align:right">Date:</td>
                 <td style="text-align:left" class="auto-style4">
                     <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td>
             </tr>
             
              <tr><td colspan="3">
                  <asp:HiddenField ID="hdf" runat="server" />
              </td></tr>

        </table>

        <asp:GridView ID="GridView1" runat="server"  OnPageIndexChanging="gvList_PageIndexChanging" AllowPaging="true" AutoGenerateColumns="False" OnRowCommand="onRowCommand" DataKeyNames="ExpenseID" Width="625px" Height="248px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>



                <asp:BoundField DataField="ExpenseID" HeaderText="ExpenseID" InsertVisible="False" ReadOnly="True" SortExpression="ExpenseID" />
                <asp:BoundField DataField="ExpenseDate" HeaderText="ExpenseDate" SortExpression="ExpenseDate" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <%--<asp:BoundField DataField="Receipts" HeaderText="Receipts" SortExpression="Receipts" />--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDelete" runat="server" OnClientClick="return confirm('Do you want to detele data?') " CommandName="DeleteButton" CommandArgument='<%#Eval("ExpenseID")%>'>Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White"
                HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Height="25px" />
            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" Height="35px" />
            <AlternatingRowStyle BackColor="White" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
          <div>
         <center>
                         <table>
                 <tr><td colspan="2"></td></tr>
                 <tr>
                     <td>
         <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="TestStyle" OnClick="btnSave_Click"  Width="40px"/></td>
                     <td> 
             <asp:Button ID="btnCancl" runat="server" Text="Cancel" CssClass="TestStyle" OnClick="btnCancl_Click" /></td>
                     </tr>
                 <tr><td colspan="2"></td></tr>
                 </table>
             </center>
    </div>
         <cc1:modalpopupextender id="ModalPopupExtenderSubmit"  runat="server" BackgroundCssClass="BackgroundStyle"  TargetControlID="btnSubmit" 
            popupcontrolid="pnlSubmit" cancelcontrolid="imgCancel" enableviewstate="true">
    </cc1:modalpopupextender>
         
        <asp:Panel ID="pnlSubmit" runat="server" BackImageUrl="~/images/popup.jpg" Width="350px">
        <center>
      <table style="border:solid;height:200px;width:350px;border-color:black;border-width:1px" >
      <tr style="height:50px">
          <td colspan="2" style="text-align:center;font-weight:bold;color:white">Submit</td>
          <td style="text-align:right">
              <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/images/cancl.png" Height="30px" Width="30px" OnClientClick="window.child.close()" CausesValidation="false"/></td>

      </tr>

      <tr style="height:50px">
          <td style="width: 100px;color:white">To:</td>
          <td>
              <asp:TextBox ID="txtTo" runat="server" Height="20px"></asp:TextBox></td>
          <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="E-Mail should not be Empty" ControlToValidate="txtTo" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid E-Mail Id" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtTo" ValidationGroup="g1"></asp:RegularExpressionValidator></td>
      </tr>
      <tr>
          <td style="width:100px;color:white">
              From: 
          </td>
          <td>
              <asp:TextBox ID="txtFrom" runat="server" Height="20px"></asp:TextBox>
          </td>
          
          <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="E-Mail should not be Empty" ControlToValidate="txtFrom" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid E-Mail Id" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtFrom" ValidationGroup="g1"></asp:RegularExpressionValidator></td>
      </tr>
      <tr style="height:50px">
          <td colspan="2" style="text-align:center">
              <asp:Button ID="btnSend" runat="server" Text="Send" Width="50px" Height ="30px" ValidationGroup="g1" OnClick="btnSend_Click" CssClass="border"/></td>
           
         
      </tr>
  </table>
        </center>     
      </asp:Panel>
          

    </div>
     
   
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <style type="text/css">
        .auto-style3 {
            width: 387px;
        }
        .auto-style4 {
            width: 105px;
        }
    </style>
</asp:Content>


