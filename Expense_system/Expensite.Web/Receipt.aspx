<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="Expensite.Web.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:624px; text-align:center">
             <tr><td colspan="3"></td></tr>

            <tr style="text-align:center">
                <td  style="border-radius: 10px;text-align:left" class="auto-style3">
                    <asp:FileUpload ID="FileUploadControl" runat="server" Height="28px" CssClass="TestStyle" Width="242px" /></td>

                <td  style="border-radius: 10px;">
                    <asp:Button ID="btnSave" runat="server" CssClass="TestStyle" Text="SAVE" OnClick="btnSave_Click" Width="81px" Height="29px" />
                </td>

            </tr>
        <tr>
            
                <td style="border-radius: 10px;" class="auto-style3">
                    <asp:Button ID="btnExpense" runat="server"  CssClass="TestStyle" Text="ADD TO EXPENSE" Width="150px" OnClick="btnExpense_Click" Height="29px"/></td>

                <td style="border-radius: 10px; ">
                    <asp:Button ID="btnSelectAll" runat="server"  CssClass="TestStyle" Text="SELECT ALL" Width="125px" OnClick="btnSelectAll_Click" Height="29px" /></td>
               
        </tr>
             <tr><td colspan="3"></td></tr>

        </table>
      <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="gvList_PageIndexChanging" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="ReceiptID" Width="625px" Height="207px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="onRowCommand">
            <Columns>
                <asp:TemplateField ItemStyle-Width="10px">
                 
                    <ItemTemplate>
                        <asp:CheckBox ID="checkBox2" runat="server" TextAlign="Right" />
                    </ItemTemplate>

<ItemStyle Width="10px"></ItemStyle>
                </asp:TemplateField>
     

                <asp:BoundField DataField="ReceiptID" HeaderText="ReceiptID" InsertVisible="False" ReadOnly="True" SortExpression="ReceiptID" />
                <asp:BoundField DataField="ReceiptPath" HeaderText="ReceiptPath" SortExpression="ReceiptPath" />
                   <asp:TemplateField HeaderText="Receipt">
<ItemTemplate>
<asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/Receipt/"+Eval("ReceiptPath") %>'  Height="80px" Width="80px"/>
</ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDelete" runat="server" OnClientClick="return confirm('Do you want to detele data?') " CommandName="DeleteCommand" CommandArgument='<%#Eval("ReceiptID")%>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                   
                          </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White"
                HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
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
   
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <style type="text/css">
    .auto-style3 {
            width: 393px;
        }
</style>
</asp:Content>

