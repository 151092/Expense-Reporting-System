<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ReportGrid.aspx.cs" Inherits="Expensite.Web.ReportGrid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid">
       
    <table style="width: 624px">
        <tr>
            <td style="width:80px">From Date:</td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                  <cc1:CalendarExtender ID="FromDate" runat="server" TargetControlID="txtFromDate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
            </td>
            <td class="auto-style1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="From Date is required" ControlToValidate="txtFromDate" ValidationGroup="Date"></asp:RequiredFieldValidator></td>
       
            <td class="auto-style2">
                To Date:
            </td>
            <td style="width: 162px">
                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                  <cc1:CalendarExtender ID="ToDate" runat="server" TargetControlID="txtToDate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="To Date is required" ControlToValidate="txtToDate" ValidationGroup="Date"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="6" style="text-align:center">
                <asp:Button ID="btnView" runat="server" CssClass="TestStyle"  Text="View" OnClick="btnView_Click" ValidationGroup="Date" Height="29px" Width="58px" />
            </td>
        </tr>
    </table>
 <asp:GridView ID="gridReport" runat="server" AllowPaging="true" OnPageIndexChanging="gvList_PageIndexChanging" AutoGenerateColumns="False"  Width="625px" Height="207px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gridRowCommand" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
  <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnOpen" runat="server" Text="Open" Height="25px" Width="48px" CssClass="TestStyle" CommandName="OpenButton" CommandArgument='<%#Eval("ReportId")%>'/>
                          <%-- <asp:LinkButton ID="linkOpen" runat="server" CommandName="OpenCommand" CommandArgument='<%#Eval("ReportID")%>'>Open</asp:LinkButton>
 --%>                       </ItemTemplate>
                    </asp:TemplateField>
                         
                
                
                <asp:BoundField DataField="ReportId" HeaderText="ReportId" InsertVisible="False" ReadOnly="True" SortExpression="ReportId" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                 <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDelete" runat="server" OnClientClick="return confirm('Do you want to detele data?') " CommandName="DeleteButton" CommandArgument='<%#Eval("ReportId")%>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                   

                   
                          </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" Height="35px" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Height="25px" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
  </asp:GridView>
        </div>    


</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <style type="text/css">
        .auto-style1 {
            width: 176px;
        }
        .auto-style2 {
            width: 80px;
        }
    </style>
</asp:Content>

