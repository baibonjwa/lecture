<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PwdReturn.aspx.cs" Inherits="lecture.PwdReturn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .style1 {
            width: 40%;
            text-align: right;
        }

        button, input, select {
            vertical-align: middle;
        }

        .btn1 {
            padding: 0 6px;
            font-size: 15px;
            line-height: 22px;
            color: #333;
            border: 1px solid #d9e8f5;
            background: url('images/button_bg1.gif') repeat-x;
            cursor: pointer;
        }

        .auto-style1 {
            width: 40%;
            text-align: right;
            height: 20px;
        }

        .auto-style2 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label1" runat="server" Text="密码找回" Font-Size="XX-Large"
                        ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="输入真实姓名："></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tb_realName" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">&nbsp;</td>
                <td>&nbsp;<asp:Button ID="btn_pwdReturn" runat="server" CssClass="btn1" Text="密码找回"
                    OnClick="btn_ok_Click" />
                </td>
            </tr>
            <tr>
                <td class="style1">&nbsp;</td>
                <td>
                    <asp:Label ID="lb_info" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
