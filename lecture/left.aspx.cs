using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Ninject;
using lecture.BLL;
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;

public partial class left : System.Web.UI.Page
{
    public String studentManage = "";
    public String Teacher = "";
    public String SystemManage = "";
    public String UserRegister = "";
    public String info = "";
    public String CollegeStudentManage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = (User)Session["User"];

        if (Session["User"] != null)
        {
            if (u.UserVerify == "待审核")
            {
                info = "<h1 class=\"type\"><a href=\"javascript:void(0)\">帐号未激活</a></h1>";
                info += "<div class=\"content\">";
                info += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                info += "<tr>";
                info += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                info += "</tr>";
                info += "</table>";
                info += "  <ul class=\"MM\">";
                info += "<li><a href=\"UserVerifying.aspx\" target=\"Iframe1\">修改个人信息</a></li>";
                info += "<li><a href=\"ChangePassword.aspx\" target=\"Iframe1\">修改密码</a></li>";
                info += "</ul>";
                info += "</div>";
            }
            else
            {
                switch (u.UserType)
                {
                    case "学生工作人员":
                        studentManage = "<h1 class=\"type\"><a href=\"javascript:void(0)\">学生工作管理人员</a></h1>";
                        studentManage += "<div class=\"content\">";
                        studentManage += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        studentManage += "<tr>";
                        studentManage += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        studentManage += "</tr>";
                        studentManage += "</table>";
                        studentManage += "  <ul class=\"MM\">";
                        studentManage += "  <li><a href=\"RecordFinish.aspx\" target=\"Iframe1\">查看任务完成情况</a></li>";
                        studentManage += "<li><a href=\"taskadd_new.aspx\" target=\"Iframe1\">听课任务添加</a></li>";
                        studentManage += "<li><a href=\"TaskManager_new.aspx\" target=\"Iframe1\"><strong style=\"color:Red\">听课任务管理</strong></a></li>";
                        studentManage += "<li><a href=\"RecordVerify.aspx\" target=\"Iframe1\">审核修改申请</a></li>";
                        studentManage += "</ul>";
                        studentManage += "</div>";
                        studentManage += " <h1 class=\"type\"><a href=\"javascript:void(0)\">听课教师</a></h1>";
                        studentManage += "<div class=\"content\">";
                        studentManage += "  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        studentManage += " <tr>";
                        studentManage += "  <td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        studentManage += "  </tr>";
                        studentManage += " </table>";
                        studentManage += " <ul class=\"MM\">";
                        studentManage += "  <li><a href=\"RecordDel.aspx\" target=\"Iframe1\">个人任务完成情况</a></li>";
                        studentManage += "  <li><a href=\"RecordAdd.aspx\" target=\"Iframe1\">听课记录添加</a></li>";
                        studentManage += "  <li><a href=\"RecordTaskCheck.aspx\" target=\"Iframe1\">查看听课任务</a></li>";
                        studentManage += "  <li><a href=\"RecordIndicator.aspx\" target=\"Iframe1\">查看听课指标</a></li>";
                        //studentManage += " <li><a href=\"RecordDel.aspx\" target=\"Iframe1\">听课记录管理</a></li>";
                        studentManage += " </ul>";
                        studentManage += "</div>";

                        studentManage += "<h1 class=\"type\"><a href=\"javascript:void(0)\">账户管理</a></h1>";
                        studentManage += "<div class=\"content\">";
                        studentManage += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        studentManage += "<tr>";
                        studentManage += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        studentManage += "</tr>";
                        studentManage += "</table>";
                        studentManage += "  <ul class=\"MM\">";
                        studentManage += "<li><a href=\"ChangePassword.aspx\" target=\"Iframe1\">修改密码</a></li>";
                        studentManage += "<li><a href=\"UserVerifying.aspx\" target=\"Iframe1\">修改个人信息</a></li>";
                        //studentManage += "<li><a href=\"UserInfo.aspx\" target=\"Iframe1\">教师信息维护</a></li>";
                        studentManage += "<li><a href=\"UserRegisterVerify.aspx\" target=\"Iframe1\">注册审核</a></li>";
                        studentManage += "<li><a href=\"UserInfo.aspx\" target=\"Iframe1\">教师信息维护</a></li>";
                        studentManage += "</ul>";
                        studentManage += "</div>";
                        break;
                    case "院级学生工作人员":
                        CollegeStudentManage = "<h1 class=\"type\"><a href=\"javascript:void(0)\">院级学生工作人员</a></h1>";
                        CollegeStudentManage += "<div class=\"content\">";
                        CollegeStudentManage += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        CollegeStudentManage += "<tr>";
                        CollegeStudentManage += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        CollegeStudentManage += "</tr>";
                        CollegeStudentManage += "</table>";
                        CollegeStudentManage += "  <ul class=\"MM\">";
                        CollegeStudentManage += "  <li><a href=\"RecordFinish.aspx\" target=\"Iframe1\">查看任务完成情况</a></li>";
                        CollegeStudentManage += "<li><a href=\"TaskManager_new.aspx\" target=\"Iframe1\"><strong style=\"color:Red\">听课任务管理</strong></a></li>";
                        CollegeStudentManage += "</ul>";
                        CollegeStudentManage += "</div>";
                        CollegeStudentManage += " <h1 class=\"type\"><a href=\"javascript:void(0)\">听课教师</a></h1>";
                        CollegeStudentManage += "<div class=\"content\">";
                        CollegeStudentManage += "  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        CollegeStudentManage += " <tr>";
                        CollegeStudentManage += "  <td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        CollegeStudentManage += "  </tr>";
                        CollegeStudentManage += " </table>";
                        CollegeStudentManage += " <ul class=\"MM\">";
                        CollegeStudentManage += "  <li><a href=\"RecordDel.aspx\" target=\"Iframe1\">个人任务完成情况</a></li>";
                        CollegeStudentManage += "  <li><a href=\"taskadd_new.aspx\" target=\"Iframe1\">听课任务添加</a></li>";
                        CollegeStudentManage += "  <li><a href=\"RecordAdd.aspx\" target=\"Iframe1\">听课记录添加</a></li>";
                        CollegeStudentManage += "  <li><a href=\"RecordTaskCheck.aspx\" target=\"Iframe1\">查看听课任务</a></li>";
                        CollegeStudentManage += "  <li><a href=\"RecordIndicator.aspx\" target=\"Iframe1\">查看听课指标</a></li>";
                        //studentManage += " <li><a href=\"RecordDel.aspx\" target=\"Iframe1\">听课记录管理</a></li>";
                        CollegeStudentManage += " </ul>";
                        CollegeStudentManage += "</div>";

                        CollegeStudentManage += "<h1 class=\"type\"><a href=\"javascript:void(0)\">账户管理</a></h1>";
                        CollegeStudentManage += "<div class=\"content\">";
                        CollegeStudentManage += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        CollegeStudentManage += "<tr>";
                        CollegeStudentManage += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        CollegeStudentManage += "</tr>";
                        CollegeStudentManage += "</table>";
                        CollegeStudentManage += "  <ul class=\"MM\">";
                        CollegeStudentManage += "<li><a href=\"ChangePassword.aspx\" target=\"Iframe1\">修改密码</a></li>";
                        CollegeStudentManage += "<li><a href=\"UserVerifying.aspx\" target=\"Iframe1\">修改个人信息</a></li>";
                        CollegeStudentManage += "</ul>";
                        CollegeStudentManage += "</div>";
                        break;
                    case "听课教师":
                        Teacher = " <h1 class=\"type\"><a href=\"javascript:void(0)\">听课教师</a></h1>";
                        Teacher += "<div class=\"content\">";
                        Teacher += "  <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        Teacher += " <tr>";
                        Teacher += "  <td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        Teacher += "  </tr>";
                        Teacher += " </table>";
                        Teacher += " <ul class=\"MM\">";
                        Teacher += "  <li><a href=\"RecordAdd.aspx\" target=\"Iframe1\"><strong style=\"color:Red\">听课记录添加</strong></a></li>";
                        Teacher += "  <li><a href=\"RecordDel.aspx\" target=\"Iframe1\">个人任务完成情况</a></li>";
                        Teacher += "  <li><a href=\"taskadd_new.aspx\" target=\"Iframe1\">听课任务添加</a></li>";
                        Teacher += "  <li><a href=\"RecordTaskCheck.aspx\" target=\"Iframe1\">查看听课任务</a></li>";
                        Teacher += "  <li><a href=\"RecordIndicator.aspx\" target=\"Iframe1\">查看听课指标</a></li>";
                        //Teacher += " <li><a href=\"RecordDel.aspx\" target=\"Iframe1\">听课记录管理</a></li>";
                        Teacher += " </ul>";
                        Teacher += "</div>";
                        Teacher += "<h1 class=\"type\"><a href=\"javascript:void(0)\">账户管理</a></h1>";
                        Teacher += "<div class=\"content\">";
                        Teacher += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        Teacher += "<tr>";
                        Teacher += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        Teacher += "</tr>";
                        Teacher += "</table>";
                        Teacher += "  <ul class=\"MM\">";
                        Teacher += "<li><a href=\"ChangePassword.aspx\" target=\"Iframe1\">修改密码</a></li>";
                        Teacher += "<li><a href=\"UserVerifying.aspx\" target=\"Iframe1\">修改个人信息</a></li>";
                        Teacher += "</ul>";
                        Teacher += "</div>";
                        break;
                    case "系统管理员":
                        SystemManage = "<h1 class=\"type\"><a href=\"javascript:void(0)\">用户管理</a></h1>";
                        SystemManage += "<div class=\"content\">";
                        SystemManage += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        SystemManage += "<tr>";
                        SystemManage += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        SystemManage += "</tr>";
                        SystemManage += "</table>";
                        SystemManage += "  <ul class=\"MM\">";
                        SystemManage += "<li><a href=\"UserRegisterVerify.aspx\" target=\"Iframe1\">注册审核</a></li>";
                        SystemManage += "</ul>";
                        SystemManage += "</div>";
                        SystemManage += "<h1 class=\"type\"><a href=\"javascript:void(0)\">基本参数管理</a></h1>";
                        SystemManage += "<div class=\"content\">";
                        SystemManage += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                        SystemManage += "<tr>";
                        SystemManage += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
                        SystemManage += " </tr>";
                        SystemManage += "</table>";
                        SystemManage += "<ul class=\"MM\">";
                        SystemManage += "  <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">课程信息添加</a></li>";
                        SystemManage += " <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">课程信息管理</a></li>";
                        SystemManage += " <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">班级信息添加</a></li>";
                        SystemManage += "  <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">班级信息管理</a></li>";
                        SystemManage += "  <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">专业信息添加</a></li>";
                        SystemManage += "   <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">专业信息管理</a></li>";
                        SystemManage += " <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">教师信息添加</a></li>";
                        SystemManage += " <li><a href=\"UnderConstruction.aspx\" target=\"Iframe1\">教师信息管理</a></li>";
                        SystemManage += "</ul>";
                        SystemManage += "</div>";
                        break;
                }
            }
        }
        else if (Session["Teacher"] != null)
        {
            info = "<h1 class=\"type\"><a href=\"javascript:void(0)\">帐号未激活</a></h1>";
            info += "<div class=\"content\">";
            info += " <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            info += "<tr>";
            info += "<td><img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" /></td>";
            info += "</tr>";
            info += "</table>";
            info += "  <ul class=\"MM\">";
            info += "<li><a href=\"UserVerifying.aspx\" target=\"Iframe1\">修改个人信息</a></li>";
            info += "<li><a href=\"ChangePassword.aspx\" target=\"Iframe1\">修改密码</a></li>";
            info += "</ul>";
            info += "</div>";
        }

    }
}
