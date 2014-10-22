<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordFinish.aspx.cs" Inherits="lecture.RecordFinish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/StyleBtn.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text="查看听课教师的听课记录情况" Font-Size="X-Large" 
                        ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lb_name" runat="server" Text="听课教师姓名："></asp:Label>
                    <asp:TextBox ID="tb_name" runat="server" Width="120px"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="Label4" runat="server" Text="听课教师所在单位："></asp:Label>
                    <asp:DropDownList ID="dd_college" runat="server">
                    </asp:DropDownList>
                </td>
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
                    &nbsp;<asp:Label ID="lb_mouth" runat="server" Text="月份："></asp:Label>
                    <asp:DropDownList ID="dd_month" runat="server" Width="71px">
                        <asp:ListItem Value="0">全部</asp:ListItem>
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
                    &nbsp;<asp:Label ID="lb_mouth0" runat="server" Text="时间："></asp:Label>
                    <asp:DropDownList ID="dd_time" runat="server">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">最近一周内</asp:ListItem>
                        <asp:ListItem Value="2">最近两周内</asp:ListItem>
                        <asp:ListItem Value="3">最近三周内</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="bt_search" CssClass="btn1" runat="server" OnClick="bt_search_Click"
                        Text="查询" />
                    &nbsp;<asp:Button ID="btn_excel" runat="server" OnClick="btn_excel_Click" Text="导出Excel表格"
                        CssClass="btn1" />
                    <asp:Label ID="lb_info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv_Del" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="744px"
                        OnRowCommand="gv_Del_RowCommand" OnRowDataBound="gv_Del_RowDataBound" 
                        AllowPaging="True" onpageindexchanging="gv_Del_PageIndexChanging">
                        <Columns>
                            <%--  <asp:TemplateField HeaderText="修改">
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
                            <asp:BoundField DataField="RecordTime_Str" HeaderText="上课时间">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="听课教师">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Listener.realName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField HtmlEncode="false" DataField="Class_Str" HeaderText="上课班级">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseTeacher_Str" HeaderText="授课教师">
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
