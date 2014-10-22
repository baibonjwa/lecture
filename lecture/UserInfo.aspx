<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="lecture.UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Content/StyleBtn.css" />
    <style type="text/css">
        .style1
        {
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <table style="width: 100%;">
            <tr>
                <td align="center">
                   
                    <asp:Label ID="Label15" runat="server" Text="用户信息管理" Font-Size="X-Large" 
                        ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    &nbsp;
                    &nbsp;
                    <asp:Label ID="Label17" runat="server" Text="教师姓名："></asp:Label>
                    <asp:TextBox ID="tb_teacherName" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Button ID="btn_search" CssClass="btn1" runat="server" Text="查询" 
                        onclick="btn_search_Click" />
                </td>
            </tr>
            <tr>
                <td>

                    <asp:GridView ID="gv_info" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False"
                        Width="701px" OnRowCommand="gv_info_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="查看详细/修改信息">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_pass" runat="server" CausesValidation="False" CommandArgument='<%#Eval("UserId") %>'
                                        CommandName="Sel">查看详细/修改信息</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="userName" HeaderText="用户名">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="真实姓名" DataField="realName">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="单位">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("UserDepartment.DepName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TeacherNum" HeaderText="教师工号">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="联系电话" DataField="userTel">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#dde7f5" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
        </table> 
        <asp:Panel ID="Panel1" runat="server">
     
        <table style="width:100%;">
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_username0" runat="server" Width="200px" 
                        AutoCompleteType="Disabled" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="**"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label4" runat="server" Text="真实姓名："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_realName" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                    <asp:Label ID="Label12" runat="server" Text="**" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label5" runat="server" Text="单位："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dd_dep" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="Label13" runat="server" Text="**" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label19" runat="server" Text="教师类型："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dd_teacherType" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="**"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label20" runat="server" Text="用户权限组："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dd_power" runat="server">
                        <asp:ListItem>听课教师</asp:ListItem>
                        <asp:ListItem>学生工作人员</asp:ListItem>
                        <asp:ListItem>院级学生工作人员</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label14" runat="server" Text="**" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label6" runat="server" Text="教师工号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_num" runat="server" AutoCompleteType="Disabled" 
                        Enabled="False" ReadOnly="True" Width="200px"></asp:TextBox>
                    <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="**"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label7" runat="server" Text="联系电话："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_tel0" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label8" runat="server" Text="E-mail："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_email0" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_UserRegister" runat="server" CssClass="btn1" Text="保存" 
                        onclick="btn_UserRegister_Click" />
                    &nbsp;
                    <asp:Button ID="btn_cancel" runat="server" CssClass="btn1" Text="取消" />
                </td>
            </tr>
        </table>
       </asp:Panel>
    </div>
    </form>
</body>
</html>
