<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="lecture.UserRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Content/StyleBtn.css" />
    <style type="text/css">
        .style1
        {
            width: 40%;
        }
    </style>
    <script type="text/javascript">
        function userNameExist() {
            userName = document.getElementById("tb_username").value;
            document.getElementById("lb_info").innerHTML = lecture.UserRegister.GetUserExist(userName).value;
            document.getElementById("HiddenField1").value = lecture.UserRegister.GetUserExist(userName).value;
        }
        function userNumExist() {
            userNum = document.getElementById("tb_num").value;
            document.getElementById("lb_info2").innerHTML = lecture.UserRegister.GetTeacherNumExist(userNum).value;
            document.getElementById("HiddenField1").value = lecture.UserRegister.GetTeacherNumExist(userNum).value;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%;">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label15" runat="server" Text="用户注册" Font-Size="XX-Large" ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td>
                    带有<asp:Label ID="Label16" runat="server" Text="**" ForeColor="Red"></asp:Label>
                    的为必填项
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label1" runat="server" Text="用户名："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_username" onchange="userNameExist()" runat="server" Width="200px"
                        AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="Label9" runat="server" Text="**" ForeColor="Red"></asp:Label><span
                        runat="server" id="lb_info" style="color: Red;"></span>
                    <asp:Label ID="lb_messUserName" runat="server" ForeColor="Red" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_paw" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="Label10" runat="server" Text="**" ForeColor="Red"></asp:Label>
                    <asp:CompareValidator ID="cvPwd" runat="server" ControlToCompare="tb_paw" ControlToValidate="tb_pwd2"
                        ErrorMessage="* 两次密码输入不一致" SetFocusOnError="True" ValueToCompare="UserRegist"
                        ForeColor="Red"></asp:CompareValidator>
                    <asp:Label ID="lb_messPwd0" runat="server" ForeColor="Red" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label3" runat="server" Text="确认密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_pwd2" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="Label11" runat="server" Text="**" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label4" runat="server" Text="真实姓名："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_realName" runat="server" Width="200px"></asp:TextBox>
                    <asp:Label ID="Label12" runat="server" Text="**" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lb_messRealName" runat="server" ForeColor="Red" ></asp:Label>
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
                    <asp:Label ID="Label17" runat="server" Text="教师类型："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dd_teacherType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label6" runat="server" Text="教师工号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_num" onchange="userNumExist()" runat="server" Width="200px" 
                        AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="Label14" runat="server" Text="**" ForeColor="Red"></asp:Label><span
                        runat="server" id="lb_info2" style="color: Red;">
                    <asp:Label ID="lb_messNum" runat="server" ForeColor="Red" ></asp:Label>
                    </span>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label7" runat="server" Text="联系电话："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_tel" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label8" runat="server" Text="E-mail："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_email" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btn_UserRegister" CssClass="btn1" runat="server" Text="注册" OnClick="btn_UserRegister_Click" />&nbsp;
                    <asp:Button ID="btn_cancel" CssClass="btn1" runat="server" Text="取消" 
                        onclick="btn_cancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
