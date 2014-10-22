<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskAdd.aspx.cs" Inherits="lecture.TaskAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="Content/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script type='text/javascript' src="Scripts/jquery.autocomplete.js"></script>
    <script src="Controls/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
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
            $("#tb_teaName").autocomplete("Controls/AutoCompleteData.aspx", {
                delay: 10,
                minChars: 1,
                matchSubset: 1,
                cacheLength: 1,
                onItemSelect: selectItem,
                onFindValue: findValue,
                autoFill: true,
                maxItemsToShow: 20
            });
        });
        $(document).ready(function () {
            $("#tb_detName").autocomplete("Controls/AutoCompleteData.aspx", {
                delay: 10,
                minChars: 1,
                matchSubset: 1,
                cacheLength: 1,
                onItemSelect: selectItem,
                onFindValue: findValue,
                autoFill: true,
                maxItemsToShow: 20
            });
        });
        $(document).ready(function () {
            $("#tb_detcourse").autocomplete("Controls/AutoCompleteDataCourse.aspx", {
                delay: 10,
                minChars: 1,
                matchSubset: 1,
                cacheLength: 1,
                onItemSelect: selectItem,
                onFindValue: findValue,
                autoFill: true,
                maxItemsToShow: 20
            });
        }); 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td>
                    <asp:DropDownList ID="dd_type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dd_type_SelectedIndexChanged">
                        <asp:ListItem Value="lecture.BLL.TaskByTypeFactory|lecture.Model.Entities.TaskByTypeEntity">按教师类别添加</asp:ListItem>
                        <asp:ListItem Value="lecture.BLL.TaskByNameFactory|lecture.Model.Entities.TaskByNameEntity">按教师姓名添加</asp:ListItem>
                        <asp:ListItem Value="lecture.BLL.TaskByDetailFactory|lecture.Model.Entities.TaskByDetailEntity">详细听课任务添加</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="lb_teaType" runat="server" Text="请输入人员属性："></asp:Label>
                                        <asp:DropDownList ID="dd_teacherType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        请输入听课任务时间安排：<asp:CheckBoxList ID="cbl_typeWeek" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">周一</asp:ListItem>
                                            <asp:ListItem Value="1">周二</asp:ListItem>
                                            <asp:ListItem Value="2">周三</asp:ListItem>
                                            <asp:ListItem Value="3">周四</asp:ListItem>
                                            <asp:ListItem Value="4">周五</asp:ListItem>
                                            <asp:ListItem Value="5">周六</asp:ListItem>
                                            <asp:ListItem Value="6">周日</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="任务内容："></asp:Label>
                                        <asp:TextBox ID="tb_typeContents" runat="server" Height="70px" TextMode="MultiLine"
                                            Width="308px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_typeAdd" runat="server" OnClick="btn_typeAdd_Click" Text="添加" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="请输入人员姓名："></asp:Label>
                                        <input id="tb_teaName" type="text" runat="server" />
                                        <%--<asp:TextBox ID="tb_teaName" runat="server" Width="229px"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        请输入听课任务时间安排：<asp:CheckBoxList ID="cbl_week0" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">周一</asp:ListItem>
                                            <asp:ListItem Value="1">周二</asp:ListItem>
                                            <asp:ListItem Value="2">周三</asp:ListItem>
                                            <asp:ListItem Value="3">周四</asp:ListItem>
                                            <asp:ListItem Value="4">周五</asp:ListItem>
                                            <asp:ListItem Value="5">周六</asp:ListItem>
                                            <asp:ListItem Value="6">周日</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="任务内容："></asp:Label>
                                        <asp:TextBox ID="tb_nameContents" runat="server" Height="70px" TextMode="MultiLine"
                                            Width="308px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_nameAdd" runat="server" OnClick="btn_nameAdd_Click" Text="添加" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <table class="style1">
                                <tr>
                                    <td>
                                        请输入人员姓名：<asp:TextBox ID="tb_detName" runat="server" Width="229px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="听课时间："></asp:Label>
                                        <asp:TextBox ID="tb_detTime" onclick="WdatePicker()" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        听课地点：<asp:TextBox ID="tb_detPlace" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        听课课程：<asp:TextBox ID="tb_detcourse" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        任务内容：<asp:TextBox ID="tb_detContents" runat="server" Height="70px" TextMode="MultiLine"
                                            Width="308px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_detAdd" runat="server" Text="添加" OnClick="btn_detAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lb_info" runat="server"></asp:Label>
    </form>
</body>
</html>
