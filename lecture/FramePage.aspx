<%@ Page Language="C#" AutoEventWireup="True" Inherits="FramePage" CodeBehind="FramePage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>辽宁工大葫芦岛校区听课记录管理系统</title>
    <link href="Content/FramePage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #Iframe1
        {
            height: 479px;
            width: 770px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px; height: 140px; margin: 0 auto;">
        <img src="Images/banner.jpg" />
    </div>
    <div id="top">
        <h2>
            管理菜单</h2>
        <div class="jg">
        </div>
        <div id="topTags">
            <ul>
                <li>
                    <asp:Label ID="lb_user" runat="server"></asp:Label>
                </li>
                <li>
                    <asp:LinkButton ID="lbtn_out" runat="server" OnClick="lbtn_out_Click">退出</asp:LinkButton>
                </li>
                <li>欢迎使用本系统！ </li>
            </ul>
        </div>
    </div>
    <div id="main">
        <div id="leftMenu">
            <iframe src="left.aspx" scrolling="no" frameborder="0" onload="this.height=500" width="185">
            </iframe>
        </div>
        <div class="jg">
            &nbsp;</div>
        <div id="content">
            <div id="welcome" class="content" style="display: block;">
                <div align="center">
                    <div>
                        <iframe id="Iframe1" name="Iframe1" frameborder="0" src='<%=UserRegister %>'></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="footer">
        Copyright for LNTU by 恒慧软件</div>
    </form>
</body>
</html>
