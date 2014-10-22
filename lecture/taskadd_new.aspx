<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskadd_new.aspx.cs" Inherits="lecture.taskadd_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/StyleBtn.css" rel="stylesheet" type="text/css" />
    <link href="Content/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script type='text/javascript' src="Scripts/jquery.autocomplete.js"></script>
    <style>
        .width
        {
            width: 90px;
        }
        .style1
        {
            width: 190px;
        }
        .style2
        {
            width: 73px;
        }
        .style3
        {
            height: 29px;
        }
        .style4
        {
            width: 104px;
        }
        .auto-style1 {
            height: 307px;
        }
    </style>
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
    </script>
    <script src="Controls/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text="添加听课任务" Font-Size="X-Large" ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lb_name" runat="server" Text="听课教师姓名："></asp:Label>
                    <asp:TextBox ID="tb_name" runat="server" Width="100px"></asp:TextBox>
                    &nbsp;<asp:Label ID="lb_post" runat="server" Text="听课教师职务："></asp:Label>
                    <asp:DropDownList ID="dd_type" runat="server">
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
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" Text="设置听课任务的月份："></asp:Label>
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="tb_time" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <table>
                        <tr>
                            <td class="width">
                                听课时间：
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="tb_time" onClick="WdatePicker()" runat="server" Width="100px" OnTextChanged="tb_time_TextChanged"
                                    AutoPostBack="True"></asp:TextBox>
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
                            </td>
                            <td class="style2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lb_week" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tb_time" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="style4">
                                <asp:Label ID="lb_infotime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="width">
                                听课地点：
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="dd_spot" runat="server">
                                    <asp:ListItem>尔雅楼</asp:ListItem>
                                    <asp:ListItem>耘慧楼</asp:ListItem>
                                    <asp:ListItem>静远楼</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="tb_place" runat="server" Width="71px"></asp:TextBox>
                                <asp:Label ID="lb_info" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="width">
                                课程：
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="tb_course" runat="server" Width="142px"></asp:TextBox>
                                <asp:Button ID="bt_add" CssClass="btn1" runat="server" Text="添加听课任务" OnClick="bt_add_Click"
                                    Width="129px" />
                                <asp:Label ID="lb_infocouse" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False"
                                    OnRowDeleting="GridView1_RowDeleting" Width="451px">
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
                                &nbsp; &nbsp;<asp:Label ID="lb_mess" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;
                                <asp:Button ID="bt_tj" CssClass="btn1" runat="server" Text="提交添加的任务到系统" OnClick="bt_tj_Click"
                                    Width="210px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
