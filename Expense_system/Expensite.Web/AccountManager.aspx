<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AccountManager.aspx.cs" Inherits="Expensite.Web.AccountManager" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <script type="text/javascript">
         function PrintContent(id, w, h) {
             var divData = document.getElementById(id);
             var html = "";
             var htmlBody = '<div class="contant">' + $("#" + id).html() + '</div></div>';

             //            //Add css
             $('link').each(function () {
                 if ($(this).attr('rel').indexOf('stylesheet') != -1) {
                     html += '<link rel="stylesheet" href="' + $(this).attr("href") + '" />';
                 }
             });
             //Avoid Extra Last Page;
             html = html + '<style type="text/css">.print{page-break-after: avoid;}</style>';
             html += htmlBody;

             var left = 20;
             var top = 20;
             var printWin = window.open(html, 'PrintWindow', 'width=' + w + ',height=' + h + ',top=' + top + ',left=' + left + ',toolbars=no,scrollbars=yes,status=no,resizable=yes');

             if (divData != null) {
                 printWin.document.write(html);
             }
             printWin.focus();
             printWin.document.close();
             printWin.print();
             printWin.focus();
             printWin.close();
         }
         function printDiv(id) {
             var html = "";
             //$(".attorneyAccordionOpenContent").css("display", "block");
             //$("#dvPrintTittle").css('display', 'block');
             PrintContent(id, 700, 1400);

         }
    </script>
     <style type="text/css">
        -style2 {
             width: 28px;
         }
         .auto-style4 {
             width: 1px;
         }
         .auto-style5 {
             width: 133px;
         }
         
         .auto-style6 {
             width: 127px;
         }
         
     </style>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="grid">
       
         <table style="width:624px; text-align:center">
             <tr><td colspan="4"></td></tr>

            <tr>
                <td style="border-radius: 10px; text-align:center;" class="auto-style6">
                    <asp:Button ID="btnApprove" runat="server" Text="APPROVE" Width="93px" OnClick="btnApprove_Click" CssClass="TestStyle" Height="29px" /></td>

              <td style="border-radius: 10px; text-align:center;" class="auto-style6">
                    <asp:Button ID="btnReject" runat="server" Text="REJECT ALL" Width="113px" OnClick="btnReject_Click" CssClass="TestStyle" Height="29px" /></td>

                <td style="border-radius: 10px; " class="auto-style5">
                    <asp:Button ID="btnPolicy" runat="server" Text="POLICY" Width="93px" CssClass="TestStyle" Height="29px" OnClick="btnPolicy_Click" /></td>

                <td style="border-radius: 10px; width:100px; ">
                   <input type="button" value="Print Page" OnClick="printDiv('pdf1')" name="Print Page" class="TestStyle" style=" width: 116px;height:29px"/></td>
                 </tr>
             
             <tr style="white-space"><td colspan="4"></td></tr>
              <tr><td colspan="4" style="height: 18px"></td></tr>

                <tr><td colspan="4">
                    <asp:TextBox ID="txtReport" runat="server" Height="20px" Width="500px">New Report</asp:TextBox>
               </td></tr>
          </table>
         
          <div id="pdf1"   >
             <center> 
           <table>
              
                  <tr>     
                 <td style="text-align:center" class="auto-style1">Report ID:</td>
                 <td style="text-align:left" class="auto-style1">
                     <asp:Label ID="lblReportId" runat="server"></asp:Label></td>
              </tr>
             <tr>
                 <td style="text-align:center">Owner:</td>
                 <td style="text-align:left">
                     <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
             </tr>
              <tr>
                 <td style="text-align:center">Date:</td>
                 <td style="text-align:left">
                     <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td>
             </tr>
              <tr>
                 <td style="text-align:center">Total Amount:</td>
                 <td style="text-align:left">
                     <asp:Label ID="lblAmt" runat="server" Text=""></asp:Label></td>
             </tr>
              <tr><td colspan="2">
                  <asp:HiddenField ID="hdf" runat="server" />
                  </td></tr>
        </table>
          </center>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="gvList_PageIndexChanging"
  AutoGenerateColumns="False"  Width="625px" Height="248px" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ExpenseID">
            <Columns>
               <asp:TemplateField ItemStyle-Width="10px">
                
                    <ItemTemplate>
                        <asp:CheckBox ID="checkBox2" runat="server" TextAlign="Right"  />
                    </ItemTemplate>


                </asp:TemplateField>
     

                <asp:BoundField DataField="ExpenseID" HeaderText="ExpenseID" InsertVisible="False" ReadOnly="True" SortExpression="ExpenseID" />
                <asp:BoundField DataField="ExpenseDate" HeaderText="ExpenseDate" SortExpression="ExpenseDate" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="ReceiptPath" HeaderText="ReceiptPath" SortExpression="ReceiptPath" Visible="false" />
                   <asp:TemplateField HeaderText="Receipt">
<ItemTemplate>
<asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/Receipt/"+Eval("ReceiptPath") %>'  Height="80px" Width="80px"/>
</ItemTemplate>
</asp:TemplateField>
               
                          </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White"
                HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="White" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
         
         </div>
         <center>
         <table>
             <tr><td  colspan="2" style="height: 18px"></td></tr>
             <tr>
                 <td>Approved By:</td>
                 <td>
                     <asp:Label ID="lblApprover" runat="server" Text=""></asp:Label></td>
             </tr>
         </table>
             </center>
         
    </div>

</asp:Content>
