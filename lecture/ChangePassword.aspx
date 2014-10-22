<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="lecture.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/StyleBtn.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 40%;
            text-align:right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label1" runat="server" Text="修改密码" Font-Size="XX-Large" 
                        ForeColor="#99CCFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label2" runat="server" Text="旧密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_OldPaw" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label3" runat="server" Text="新密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_newPaw" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label4" runat="server" Text="确认密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_newPaw2" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvPwd" runat="server" ControlToCompare="tb_newPaw" ControlToValidate="tb_newPaw2"
                        ErrorMessage="* 两次密码输入不一致" SetFocusOnError="True" ValueToCompare="UserRegist"
                        ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;<asp:Button ID="btn_ok" runat="server" CssClass="btn1" Text="确认" 
                        onclick="btn_ok_Click" />
                    &nbsp;
                    <asp:Button ID="btn_cancel" CssClass="btn1" runat="server" Text="取消" 
                        onclick="btn_cancel_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
