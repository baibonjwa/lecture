<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="lecture.index" %>



<%@ Register src="Controls/ValidCode.ascx" tagname="ValidCode" tagprefix="uc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登录</title>
    <STYLE type="text/css">
        BODY 
        {
        	FONT-SIZE: 12px; 
        	COLOR: #ffffff; 
        	FONT-FAMILY: 宋体
        	}
        TD 
        {
        	FONT-SIZE: 12px; 
        	COLOR: #ffffff; 
        	FONT-FAMILY: 宋体
        	}
</STYLE>
</head>
<body>
    <form id="form1" runat="server">
<DIV>

<DIV id=div1 
style="LEFT: 0px; POSITION: absolute; TOP: 0px; BACKGROUND-COLOR: #0066ff"></DIV>
<DIV id=div2 
style="LEFT: 0px; POSITION: absolute; TOP: 0px; BACKGROUND-COLOR: #0066ff"></DIV>

<DIV>&nbsp;&nbsp; </DIV>
<DIV>
<TABLE cellSpacing=0 cellPadding=0 width=900 align=center border=0>
  <TBODY>
  <TR>
    <TD style="HEIGHT: 105px"><IMG src="Images/login_1.gif" 
  border=0></TD></TR>
  <TR>
    <TD background="Images/login_2.jpg" height="300">
      <TABLE height=300 cellPadding=0 width=900 border=0>
        <TBODY>
        <TR>
          <TD colSpan=2 height=35></TD></TR>
        <TR>
          <TD width=360></TD>
          <TD>
            <TABLE cellSpacing=0 cellPadding=2 border=0>
             
              <TR>
                <TD style="HEIGHT: 28px" width="80px">登录名：</TD>
                <TD style="HEIGHT: 28px" width="150px">
                    <asp:TextBox ID="tb_UserName" Width="130px" runat="server"></asp:TextBox>
                  </TD>
                <TD style="HEIGHT: 28px" width="370px"><SPAN 
                  style="FONT-WEIGHT: bold;  COLOR: white">
                    <asp:Label ID="lb_messName" runat="server"></asp:Label></SPAN></TD></TR>
              <TR>
                <TD style="HEIGHT: 28px; width:80px;">密&nbsp;码：</TD>
                <TD style="HEIGHT: 28px">
                    <asp:TextBox ID="tb_Pwd" Width="130px" runat="server" TextMode="Password"></asp:TextBox>
                  </TD>
                <TD style="HEIGHT: 28px"><SPAN 
                  style="FONT-WEIGHT: bold; COLOR: white">
                    <asp:Label ID="lb_messPwd" runat="server"></asp:Label></SPAN></TD></TR>
                <%--  <TR>
                <TD style="HEIGHT: 28px">验证码：</TD>
                <TD style="HEIGHT: 28px">
                    <asp:TextBox ID="tb_Code" Width="130px" runat="server"></asp:TextBox>
                                                        </TD>
                <TD style="HEIGHT: 28px">
                    <uc1:ValidCode ID="ValidCode1" runat="server" />
                  </TD></TR>
              <TR>--%>
                <TD style="HEIGHT: 18px"></TD>
                <TD style="HEIGHT: 18px">
                    <asp:Label ID="lb_messVCode" runat="server"></asp:Label>
                  </TD>
                <TD style="HEIGHT: 18px"></TD></TR>
              <TR>
                <TD style="HEIGHT: 18px"></TD>
                <TD style="HEIGHT: 18px">
                    <asp:ImageButton ID="btn_login" runat="server" 
                        ImageUrl="~/Images/login_button.gif" onclick="btn_login_Click" />
                  </TD>
                <TD style="HEIGHT: 18px">
                   <asp:LinkButton ID="lbtn_UserRegister" ForeColor="White" runat="server" 
                        onclick="lbtn_UserRegister_Click" Font-Size="Large">用户注册</asp:LinkButton>
                    &nbsp;
                   <asp:LinkButton ID="lbtn_returnPwd" ForeColor="White" runat="server" 
                        onclick="lbtn_returnPwd_Click" Font-Size="Large">密码找回</asp:LinkButton>
                    </TD></TR>
              <TR>
                <TD></TD>
                <TD>
                    <%--<asp:LinkButton ID="lbtn_forget" ForeColor="White" runat="server">忘记密码？</asp:LinkButton>--%>
                  </TD></TR></TABLE></TD></TR></TBODY></TABLE></TD></TR>
  <TR>
    <TD><IMG src="Images/login_3.jpg" 
border=0></TD></TR></TBODY></TABLE></DIV>

    </form>
</body>
</html>
