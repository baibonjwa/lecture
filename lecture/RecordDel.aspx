<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordDel.aspx.cs" Inherits="lecture.RecordDel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/StyleBtn.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="center" class="style2">
                    <asp:Label ID="Label3" runat="server" Text="个人任务完成情况" Font-Size="X-Large" ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    您的<strong style="color: Red;">本月</strong>听课记录共
                    <asp:Label ID="lb_mess0" runat="server"></asp:Label>
                    条&nbsp; 您本月的听课指标为：<asp:Label ID="lb_count" runat="server" Text="4"></asp:Label>
                    次</td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="年份："></asp:Label>
                    <asp:DropDownList ID="dd_year" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="月份："></asp:Label>
                    <asp:DropDownList ID="dd_mouth" runat="server">
                        <asp:ListItem Value="1">一月份</asp:ListItem>
                        <asp:ListItem Value="2">二月份</asp:ListItem>
                        <asp:ListItem Value="3">三月份</asp:ListItem>
                        <asp:ListItem Value="4">四月份</asp:ListItem>
                        <asp:ListItem Value="5">五月份</asp:ListItem>
                        <asp:ListItem Value="6">六月份</asp:ListItem>
                        <asp:ListItem Value="7">七月份</asp:ListItem>
                        <asp:ListItem Value="8">八月份</asp:ListItem>
                        <asp:ListItem Value="9">九月份</asp:ListItem>
                        <asp:ListItem Value="10">十月份</asp:ListItem>
                        <asp:ListItem Value="11">十一月份</asp:ListItem>
                        <asp:ListItem Value="12">十二月份</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="btn_search" runat="server" CssClass="btn1" Text="查询" OnClick="btn_search_Click" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lb_monthCount" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv_Del" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="744px"
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
                            <asp:BoundField DataField="classSpot" HeaderText="听课地点">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="recordDate" HeaderText="听课日期" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField HtmlEncode="false" DataField="RecordTime_Str" HeaderText="上课时间">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Str" HtmlEncode="false" HeaderText="上课班级">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseTeacher_Str" HeaderText="授课教师">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <%--    <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_update" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") %>'
                            CommandName="Edit">修改</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ltbn_del" runat="server" CausesValidation="False" CommandArgument='<%#Eval("Id") %>'
                            CommandName="Del" >删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="State" HeaderText="申请修改状态">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
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
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
