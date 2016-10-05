<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Analytics.aspx.cs" Inherits="Expensite.Web.Analytics" %>
<%@ Register Assembly="JQChart.Web" Namespace="JQChart.Web.UI.WebControls" TagPrefix="jqChart" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/jquery.jqChart.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/jquery.jqRangeSlider.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/themes/smoothness/jquery-ui-1.8.21.css" />
    <script src="<% = ResolveUrl("~/Scripts/jquery-1.5.1.min.js") %>" type="text/javascript"></script>
    <script src="<% = ResolveUrl("~/Scripts/jquery.jqRangeSlider.min.js") %>" type="text/javascript"></script>
    <script src="<% = ResolveUrl("~/Scripts/jquery.jqChart.min.js") %>" type="text/javascript"></script>
    
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <asp:ObjectDataSource ID="ObjectDataSource1"
        runat="server"
        SelectMethod="GetPieChartData"
        TypeName="Expensite.Web.Analytics"></asp:ObjectDataSource>--%>
 


     <jqChart:Chart ID="Chart1" Width="598px" Height="500px" runat="server" style="margin-right: 72px">
        <Background FillStyleType="LinearGradient" X1="0">
            <ColorStops>
                <jqChart:ColorStop Color="#d2e6c9" />
                <jqChart:ColorStop Color="white" Offset="1" />
            </ColorStops>
        </Background>
        <Title Text="Pie Chart"></Title>
        <Border StrokeStyle="#6ba851" />
        <Legend><Title Text="ExpenseType"></Title></Legend>
        <Animation Enabled="True" Duration="00:00:01" />
        <Shadows Enabled="true" />
        <Series>
            <jqChart:PieSeries DataLabelsField="Label" DataValuesField="Value1" ExplodedRadius="10">
                 <ExplodedSlices>
                    <jqChart:DoubleValue Value="5" />
                </ExplodedSlices>
                <FillStyles>
                    <jqChart:StringValue Value="#418CF0" />
                    <jqChart:StringValue Value="#FCB441" />
                    <jqChart:StringValue Value="#E0400A" />
                    <jqChart:StringValue Value="#056492" />
                    <jqChart:StringValue Value="#BFBFBF" />
                    <jqChart:StringValue Value="#1A3B69" />
                    <jqChart:StringValue Value="#FFE382" />
                </FillStyles>
                <Labels Visible="true" Font="15px sans-serif" StringFormat="%.1f%%" ValueType="Percentage">
                    <FillStyle Color="White"></FillStyle>
                </Labels>
            </jqChart:PieSeries>
        </Series>
    </jqChart:Chart>
    <script lang="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#<%= Chart1.ClientID %>').bind('tooltipFormat', function (e, data) {
                var percentage = data.series.getPercentage(data.value);
                percentage = data.chart.stringFormat(percentage, '%.2f%%');

                return '<b>' + data.dataItem[0] + '</b><br />' +
                           data.value + ' (' + percentage + ')';
            });
        });
    </script>
    <%--<center>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnexportToImage" runat="server" Text="Export To Image" Width="122px" Height="32px" style="font-weight: 700; color: #FFFFFF; background-color: #20B7C9"   />
            </td>
        </tr>
    </table>
    </center>--%>
    <center>
        <table><tr><td></td></tr></table>
    <input type="button" id="btnexportToImage" value="Export To Image" class="TestStyle"/></center>
    <script lang="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#btnexportToImage').click(function () {
                alert("hi");
                var config = {
                    fileName: 'Chart.png',
                    type: 'image/png' // 'image/png' or 'image/jpeg'
                };
                alert("hello");
                $('#<%= Chart1.ClientID %>').jqChart('exportToImage', config);
            });
        });
        </script>

</asp:Content>
