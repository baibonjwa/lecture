<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskManager_new.aspx.cs"
    Inherits="lecture.TaskManager_new" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/StyleBtn.css" rel="stylesheet" type="text/css" />
    <script src="Controls/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="Content/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script type='text/javascript' src="Scripts/jquery.autocomplete.js"></script>
    <script>
        function changepos(obj, index) {
            if (index == -1) {
                if (obj.selectedIndex > 0) {
                    obj.options(obj.selectedIndex).swapNode(obj.options(obj.selectedIndex - 1))
                }
            }
            else if (index == 1) {
                if (obj.selectedIndex < obj.options.length - 1) {
                    obj.options(obj.selectedIndex).swapNode(obj.options(obj.selectedIndex + 1))
                }
            }
        }
    </script>
    <script>
        function findValue(li) {
            if (li == null) return alert("No match!");
            if (!!li.extra)
                var sValue = li.extra[0];
        }
        function selectItem(li) {
            findValue(li);
        }
        function lookupLocal() {
            var oSuggest = $(".ajaxinput")[0].autocompleter;
            oSuggest.findValue();
            return false;
        }
        $(document).ready(function () {
            $("#tb_name").autocomplete("Controls/AutoCompleteDataRealName.aspx", {
                delay: 10,
                minChars: 1,
                matchSubset: 1,
                cacheLength: 1,
                onItemSelect: selectItem,
                onFindValue: findValue,
                autoFill: true,
                selectFirst: true,
                maxItemsToShow: 20
            });

        });
        $(document).ready(function () {
            $("#tb_teacherName").autocomplete("Controls/AutoCompleteDataRealName.aspx", {
                delay: 10,
                minChars: 1,
                matchSubset: 1,
                cacheLength: 1,
                onItemSelect: selectItem,
                onFindValue: findValue,
                autoFill: true,
                selectFirst: true,
                maxItemsToShow: 20
            });

        });
    </script>
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            width: 100px;
        }
        .style6
        {
            width: 102px;
        }
        .style8
        {
            height: 20px;
            width: 93px;
        }
        .style9
        {
            width: 93px;
        }
        .style10
        {
            width: 138px;
        }
        .style11
        {
            height: 20px;
            width: 138px;
        }
        .style12
        {
            width: 145px;
        }
        .style13
        {
            width: 115px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Label7" runat="server" Text="听课任务管理" Font-Size="X-Large" ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="lb_name" runat="server" Text="听课教师姓名："></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="tb_name" runat="server"></asp:TextBox>
                </td>
                <td class="style13">
                    <asp:Label ID="lb_post" runat="server" Text="听课教师职务："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dd_type0" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="lb_name0" runat="server" Text="听课教师所在单位："></asp:Label>
                </td>
                <td class="style6">
                    <asp:DropDownList ID="dd_college" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="Label8" runat="server" Text="年份："></asp:Label>
                    &nbsp;
                </td>
                <td class="style6">
                    <asp:DropDownList ID="dd_year" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style13">
                    <asp:Label ID="lb_mouth" runat="server" Text="月份："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dd_month0" runat="server" Width="71px">
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
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Button ID="bt_search" CssClass="btn1" runat="server" Text="查询" OnClick="bt_search_Click" />
                </td>
                <td class="style6">
                    &nbsp;
                </td>
                <td class="style13">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gv_rw" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="gv_rw_SelectedIndexChanging"
                        OnRowDataBound="gv_rw_RowDataBound" OnRowDeleting="gv_rw_RowDeleting" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        Width="657px" AllowPaging="True" onpageindexchanging="gv_rw_PageIndexChanging">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="查看详细任务/修改任务">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:CommandField>
                            <asp:CommandField ShowDeleteButton="True" DeleteText="删除">
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
                    <asp:Button ID="btn_export" runat="server" Text="查看任务报表" CssClass="btn1" OnClick="btn_export_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <table>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label1" runat="server" Text="教师姓名："></asp:Label>
                                </td>
                                <td class="style10">
                                    <asp:TextBox ID="tb_teacherName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="职务:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_type" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                                    <asp:Label ID="Label6" runat="server" Text="月份："></asp:Label>
                                </td>
                                <td class="style11">
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
                                </td>
                                <td class="style1">
                                    &nbsp;
                                </td>
                                <td class="style1">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <hr />
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="450px"
                                        OnRowDeleting="GridView1_RowDeleting">
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
                                            <asp:CommandField DeleteText="删除" ShowDeleteButton="True">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:CommandField>
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
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="Label3" runat="server" Text="听课时间："></asp:Label>
                                                <br />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tb_time" runat="server" onClick="WdatePicker()" OnTextChanged="tb_time_TextChanged"
                                                    Width="100px" AutoPostBack="True"></asp:TextBox>
                                                <asp:DropDownList ID="dd_time" runat="server">
                                                    <asp:ListItem>第一小节</asp:ListItem>
                                                    <asp:ListItem>第二小节</asp:ListItem>
                                                    <asp:ListItem>第三小节</asp:ListItem>
                                                    <asp:ListItem>第四小节</asp:ListItem>
                                                    <asp:ListItem>第五小节</asp:ListItem>
                                                    <asp:ListItem>第六小节</asp:ListItem>
                                                    <asp:ListItem>第七小节</asp:ListItem>
                                                    <asp:ListItem>第八小节</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lb_week" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="Label4" runat="server" Text="听课地点："></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dd_spot" runat="server">
                                                    <asp:ListItem>尔雅楼</asp:ListItem>
                                                    <asp:ListItem>耘慧楼</asp:ListItem>
                                                    <asp:ListItem>静远楼</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="tb_place" runat="server" Width="71px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                <asp:Label ID="Label5" runat="server" Text="课程："></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tb_course" runat="server" Width="140px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="bt_add" runat="server" CssClass="btn1" OnClick="bt_add_Click" Text="添加" />
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <table>
                                        <tr>
                                            <td class="style2">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="bt_tj" runat="server" CssClass="btn1" OnClick="bt_tj_Click" Text="修改完成" />
                                                <asp:Label ID="lb_info" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
