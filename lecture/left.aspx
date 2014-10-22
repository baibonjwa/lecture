<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单页</title>
    <script src="Scripts/prototype.lite.js" type="text/javascript"></script>
    <script src="Scripts/moo.fx.js" type="text/javascript"></script>
    <script src="Scripts/moo.fx.pack.js" type="text/javascript"></script>
    <style>
        body
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #000;
            background-color: #EEF2FB;
            margin: 0px;
        }
        #container
        {
            width: 182px;
        }
        H1
        {
            font-size: 12px;
            margin: 0px;
            width: 182px;
            cursor: pointer;
            height: 30px;
            line-height: 20px;
        }
        H1 a
        {
            display: block;
            width: 182px;
            color: #000;
            height: 30px;
            text-decoration: none;
            moz-outline-style: none;
            background-image: url(images/menu_bgS.gif);
            background-repeat: no-repeat;
            line-height: 30px;
            text-align: center;
            margin: 0px;
            padding: 0px;
        }
        .content
        {
            width: 182px;
            height: 26px;
        }
        .MM ul
        {
            list-style-type: none;
            margin: 0px;
            padding: 0px;
            display: block;
        }
        .MM li
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            list-style-type: none;
            display: block;
            text-decoration: none;
            height: 26px;
            width: 182px;
            padding-left: 0px;
        }
        .MM
        {
            width: 182px;
            margin: 0px;
            padding: 0px;
            left: 0px;
            top: 0px;
            right: 0px;
            bottom: 0px;
            clip: rect(0px,0px,0px,0px);
        }
        .MM a:link
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(images/menu_bg1.gif);
            background-repeat: no-repeat;
            height: 26px;
            width: 182px;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
            text-decoration: none;
        }
        .MM a:visited
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(images/menu_bg1.gif);
            background-repeat: no-repeat;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            height: 26px;
            width: 182px;
            text-decoration: none;
        }
        .MM a:active
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            color: #333333;
            background-image: url(images/menu_bg1.gif);
            background-repeat: no-repeat;
            height: 26px;
            width: 182px;
            display: block;
            text-align: center;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
            text-decoration: none;
        }
        .MM a:hover
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 26px;
            font-weight: bold;
            color: #006600;
            background-image: url(images/menu_bg2.gif);
            background-repeat: no-repeat;
            text-align: center;
            display: block;
            margin: 0px;
            padding: 0px;
            height: 26px;
            width: 182px;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="280" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEF2FB">
        <tr>
            <td width="182" valign="top">
                <div id="container">
                    <%--                         <h1 class="type"><a href="javascript:void(0)">听课教师</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
         
          <li><a href="RecordManage.aspx" target="Iframe1">查看任务完成情况</a></li>
          <li><a href="RecordTaskCheck.aspx" target="Iframe1">查看听课任务</a></li>
          <li><a href="RecordIndicator.aspx" target="Iframe1">查看听课指标</a></li>
           <li><a href="RecordAdd.aspx" target="Iframe1"><strong style="color:Red">听课记录添加</strong></a></li>
          <li><a href="RecordDel.aspx" target="Iframe1">听课记录管理</a></li>
 
        </ul>
      </div>--%>
                    <%= info %>
                    <%= studentManage %>
                    <%= CollegeStudentManage %>
                    <%= Teacher %>
                    <%= SystemManage %>
                    <%=UserRegister %>
                    <%--        <h1 class="type"><a href="javascript:void(0)">基本参数管理</a></h1>
      <div class="content">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
            </tr>
          </table>
        <ul class="MM">
        <li><a href="UnderConstruction.aspx" target="Iframe1">课程信息添加</a></li>
            <li><a href="UnderConstruction.aspx" target="Iframe1">课程信息管理</a></li>
            <li><a href="UnderConstruction.aspx" target="Iframe1">班级信息添加</a></li>
          <li><a href="UnderConstruction.aspx" target="Iframe1">班级信息管理</a></li>
          <li><a href="UnderConstruction.aspx" target="Iframe1">专业信息添加</a></li>
          <li><a href="UnderConstruction.aspx" target="Iframe1">专业信息管理</a></li>
          <li><a href="UnderConstruction.aspx" target="Iframe1">教师信息添加</a></li>
          <li><a href="UnderConstruction.aspx" target="Iframe1">教师信息管理</a></li>
        </ul>
      </div>--%>
                </div>
                <script type="text/javascript">
                    var contents = document.getElementsByClassName('content');
                    var toggles = document.getElementsByClassName('type');

                    var myAccordion = new fx.Accordion(
			toggles, contents, { opacity: true, duration: 400 }
		);
                    myAccordion.showThisHideOpen(contents[0]);
                </script>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
