<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordVerify.aspx.cs" Inherits="lecture.RecordVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td align="center" class="style1">
                <asp:Label ID="Label3" runat="server" Text="听课记录修改申请" Font-Size="X-Large" ForeColor="#99CCFF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lb_info" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv_Del" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="784px"
                    OnRowCommand="gv_Del_RowCommand" OnRowDataBound="gv_Del_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="查看详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_check" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") %>'
                                    CommandName="Sel">查看详细</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="weekNumber" HeaderText="周次">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="recordDate" HeaderText="听课日期" DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RecordTime_Str" HeaderText="上课时间">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="听课教师">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Listener.realName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField HtmlEncode="false" DataField="Class_Str" HeaderText="上课班级">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="classSpot" HeaderText="听课地点">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="State" HeaderText="状态" />
                        <asp:TemplateField HeaderText="通过审核">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_pass" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") %>'
                                    CommandName="Pass">通过审核</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="不通过">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_nopass" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") %>'
                                    CommandName="NoPass">不通过</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#dde7f5" Font-Bold="True" ForeColor="black" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                    <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                    <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                    <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
