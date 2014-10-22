<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegisterVerify.aspx.cs"
    Inherits="lecture.UserRegisterVerify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/StyleBtn.css" rel="stylesheet" type="text/css" />
    <script>
        function SB002SelectAll(checkbox) {
            if (checkbox.checked == false) {
                var table = document.getElementById("GridView1");
                for (var i = 1; i < table.rows.length; i++) {
                    var input = table.rows[i].cells[0].getElementsByTagName("input")[0];
                    input.checked = this.checked;
                }
            }
            else {
                var table = document.getElementById("GridView1");
                for (var i = 1; i < table.rows.length; i++) {
                    var input = table.rows[i].cells[0].getElementsByTagName("input")[0];
                    input.checked = !this.checked;
                }
            }
        }
        /* 
        全解除 
        */
     

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="用户注册审核" Font-Size="X-Large" ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="单位："></asp:Label>
                    <asp:DropDownList ID="dd_dep" runat="server">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="btn_search" CssClass="btn1" runat="server" Text="查询" OnClick="btn_search_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False"
                        Width="701px" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="CheckAll" type="checkbox" onclick="SB002SelectAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
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
                            <asp:TemplateField HeaderText="通过审核">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_pass" runat="server" CausesValidation="False" CommandArgument='<%#Eval("UserId") %>'
                                        CommandName="Pass">通过审核</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="不通过">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_nopass" runat="server" CausesValidation="False" CommandArgument='<%#Eval("UserId") %>'
                                        CommandName="NoPass">删除该用户</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
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
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lbtn_verify" runat="server" OnClick="lbtn_verify_Click">批量审核</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
