<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Expensite.Web.Expenses" Codebehind="Expenses.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script> 
    <script type="text/javascript">
        function setImage(file) {
            var _control = document.getElementById('<%= receipt.ClientID %>');
            if (navigator.appName == 'Microsoft Internet Explorer') {
                if (document.all) {
                    document.getElementById('<%= receiptImage.ClientID %>').src = file.value;
                }
                else {
                    
                    document.getElementById('<%= receiptImage.ClientID %>').src = file.files.item(0).getAsDataURL();
                    
                }
            }
            else {
                // Get a reference to the fileList
                var files = !!_control.files ? _control.files : [];

                // If no files were selected, or no FileReader support, return
                if (!files.length || !window.FileReader) return;

                if (/^image/.test(files[0].type)) {

                    // Create a new instance of the FileReader
                    var reader = new FileReader();

                    // Read the local file as a DataURL
                    reader.readAsDataURL(files[0]);

                    // When loaded, set image data as background of page
                    reader.onloadend = function () {
                     
                        $('#<%= receiptImage.ClientID %>').attr("src", this.result);
                    }
                }
            }
        }
    </script>
 
  <script type="text/javascript">  
      function Validate() {
          var gv = document.getElementById('<%= ExpenseGrid.ClientID %>');
          var rbs = gv.getElementsByTagName("input");
          var count;
          var flag = 0;
          for (var i = 0; i < rbs.length; i++) {

              if (rbs[i].type == "checkbox") {
                  if (rbs[i].checked) {
                      flag++;
                      if (flag !=1) {
                          alert("plaese select one checkbox not allow multiple or Zero checked");
                          
                          document.getElementById('<%= ModalPopupExtender.ClientID %>').style.display = 'none';
                      }
                      else {
                           
                      }
                     
                  }
              }

          }
      }

  </script>
    <script  type="text/javascript">
        function pageLoad() {
            ShowPopup();
            setTimeout(HidePopup, 2000);
        }

        function ShowPopup() {
           // $find('modalpopup').show();
            $get('btnAdd').click();
        }

        function HidePopup() {
            //$find('modalpopup').hide();
            $get('ibtnCancel').click();
        }
</script>


 



    <div class="grid">

         <table style="width:624px; text-align:center">
             <tr><td colspan="4"></td></tr>

            <tr>
                <td style="border-radius: 10px; width: 205px;">
                    <asp:Button ID="btnAdd" runat="server" CssClass="TestStyle" Text="ADD" Width="86px" Height="29px" /></td>

                <td style="border-radius: 10px; width: 198px;">
                    <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="TestStyle"  OnClientClick="javascript:Validate();"  Width="92px" OnClick="btnUpdate_Click" Height="29px" /></td>

                <td style="border-radius: 10px; width: 198px; ">
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="TestStyle" Width="92px" OnClick="btnDelete_Click" OnClientClick="return confirm('Do you want to detele data?') " Height="29px" /></td>
               
                 <td  style="border-radius: 10px; width: 198px;">
                    <asp:Button ID="btnSelectAll" runat="server" Text="SELECT ALL" CssClass="TestStyle" Width="120px" OnClick="btnSelectAll_Click" Height="29px" />
                </td>
            </tr>
             
             <tr>
                 <td colspan="4"></td>
             </tr>
            
             <tr><td>
                 <asp:HiddenField ID="hdf" runat="server" /></td>
                 <td>
                     <asp:HiddenField ID="hdfReceipt" runat="server" />
                 </td>
                 <td colspan="2">
                 <asp:HiddenField ID="hdf1" runat="server" />
                 </td></tr>
             <tr>
                 <td colspan="4"></td>
             </tr>
             <tr>
                 <td colspan="2" style="text-align:right;font-weight:bold">View By Expense Type</td>
                 <td colspan="2" style="text-align:left">
                     <asp:DropDownList ID="drpExpenseType" runat="server" AutoPostBack="true" BorderStyle="Ridge" OnSelectedIndexChanged="drpExpenseType_SelectedIndexChanged"></asp:DropDownList></td>
             </tr>
     
<tr>
    <td colspan="4">

      <asp:GridView ID="ExpenseGrid" runat="server" OnPageIndexChanging="gvList_PageIndexChanging" AllowPaging="true"  AutoGenerateColumns="False" DataKeyNames="ExpenseID" Width="625px" Height="248px" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <Columns>

                <asp:BoundField DataField="ExpenseID" HeaderText="ExpenseID" InsertVisible="False" ReadOnly="True" SortExpression="ExpenseID" />
                <asp:BoundField DataField="ExpenseType" HeaderText="ExpenseType" SortExpression="ExpenseType" />
                 <asp:BoundField DataField="ExpenseDate" HeaderText="Date" SortExpression="ExpenseDate" />
                <asp:BoundField DataField="Amount" HeaderText="Amount(Rs)" SortExpression="Amount" />
                <asp:TemplateField ItemStyle-Width="10px">
                
                    <ItemTemplate>
                        <asp:CheckBox ID="checkGrid" runat="server"/>
                    </ItemTemplate>


                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White"
                HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Height="25px" HorizontalAlign="Left" />
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
          </td>
</tr>
             <tr>
            <td colspan="4">
               <asp:Button ID="btnAddToReport" runat="server" Text="ADD TO REPORT" Width="164px" CssClass="TestStyle" OnClick="btnAddToReport_Click" Height="29px" />
             </td>
          </tr>
    
           </table>
            </div>
<div>
    <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="btnAdd"
        PopupControlID="pnlpopup" CancelControlID="ibtnCancel" BackgroundCssClass="BackgroundStyle" EnableViewState="true" >
    </cc1:ModalPopupExtender>
  
    <asp:Panel ID="pnlpopup" runat="server" BackImageUrl="~/images/popup.jpg" Height="550px" Width="650px">
     <center>    
         <table class="auto-style3" style="border:solid;height:550px;width:650px;border-color:black;border-width:1px" >
          <tr>
                 <td colspan="6" style="font-weight:bolder;font-size:larger;text-align:center;color:white">Receipts</td>
                 <td style="text-align:right"><asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/images/cancl.png" Height="30px" Width="30px" OnClientClick="window.child.close()" CausesValidation="false"></asp:ImageButton></td>
             </tr>
                         <tr>
                                <td class="auto-style4" style="color:white"></td>
                                <td class="auto-style7">

                                    </td>
                             <td style="color:red"></td>
                                <td colspan="3">
                                <asp:FileUpload ID="receipt" runat="server" onchange="javascript:setImage(this);" /> </td>
                             <td style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="receipt" runat="server" ValidationGroup="VgReceipt" ErrorMessage="Please choose file" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="auto-style4" style="color:white">Date</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="txtDate" runat="server" Width="150px" BorderStyle="Ridge"></asp:TextBox></td>
                                <cc1:CalendarExtender ID="Date" runat="server" TargetControlID="txtDate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
                                <td style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDate" runat="server" ValidationGroup="VgReceipt" ErrorMessage="Date is required" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
                                <td rowspan="5" colspan="3"> 
                                   <asp:Image ID="receiptImage" runat="server" Height="275" Width="225"  />

                                    </td>
                            </tr>
                            <tr>
                                <td class="auto-style4" style="color:white">Currency</td>
                                <td class="auto-style7">
                                    <asp:DropDownList ID="dlCurrency" runat="server"  Width="150px" BorderStyle="Ridge">
                                       
                                         
                                    </asp:DropDownList>
                                    
                                    </td>
                                <td style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="dlCurrency" runat="server" ValidationGroup="VgReceipt" ErrorMessage="Please select one of currency type" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="auto-style4" style="color:white">Amount</td>
                                <td class="auto-style7"><asp:TextBox ID="txtAmount" runat="server" Width="150px" BorderStyle="Ridge"></asp:TextBox> </td>
                                <td style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAmount" runat="server" ValidationGroup="VgReceipt" ErrorMessage="Please Enter Amount" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="auto-style4" style="color:white">Expense Type </td>
                                <td class="auto-style7">
                                    <asp:DropDownList ID="dlExpenseType" runat="server" AutoPostBack="false" Width="150px" BorderStyle="Ridge" >
                                     
                                       
                                    </asp:DropDownList></td>
                                <td style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="dlExpenseType" runat="server" ValidationGroup="VgReceipt" ErrorMessage="Please select one of Expense type" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="auto-style4" style="color:white">Comment</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="150px" BorderStyle="Ridge"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td ></td>
                                <td></td>
                              <td style="width:30px"></td>
                                <td class="auto-style5" style="text-align:center;width:220px" >
                                    <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" Height="28px" Width="80px" CssClass="border"/></td>
                               <%-- <td class="auto-style6">
                                    <asp:Button ID="btnCrop" runat="server" Text="Crop"  /></td>
                               --%> 
                            </tr>
                            <tr>
                                <td colspan="7" style="text-align:center">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="VgReceipt" OnClick="btnSave_click" Height="28px" Width="55px" CssClass="border" /></td>
                            </tr>
                        </table>
                     </center>
 </asp:Panel>
 </div>
    

</asp:Content>

