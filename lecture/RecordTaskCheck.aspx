<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordTaskCheck.aspx.cs"
    Inherits="lecture.RecordTaskCheck" %>

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
                <td align="center" class="style1">
                    <asp:Label ID="Label3" runat="server" Text="查看听课教师的听课任务" Font-Size="X-Large" 
                        ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="年份："></asp:Label>
                    <asp:DropDownList ID="dd_year" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:Label ID="lb_mouth" runat="server" Text="月份："></asp:Label>
                    <asp:DropDownList ID="dd_month" runat="server" Width="71px">
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
                    <asp:Button ID="bt_search" CssClass="btn1" runat="server" OnClick="bt_search_Click"
                        Text="查询" />
                    &nbsp;<asp:Label ID="lb_info" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv_rw" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="gv_rw_SelectedIndexChanging"
                        OnRowDataBound="gv_rw_RowDataBound" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None"
                        BorderWidth="1px" CellPadding="3" Width="663px" AllowPaging="True" 
                        onpageindexchanging="gv_rw_PageIndexChanging" PageSize="8">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="查看详细任务信息">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:CommandField>
                            <asp:BoundField HeaderText="任务编号" DataField="TaskID">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="teacher" HeaderText="教师">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="教师类型" DataField="teachertype">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="taskDate" HeaderText="月份">
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
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False"
                        Width="417px">
                        <Columns>
                            <asp:BoundField DataField="dTime" HeaderText="听课时间">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dSpot" HeaderText="听课地点">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dCourse" HeaderText="课程">
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
