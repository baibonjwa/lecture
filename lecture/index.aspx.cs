using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;
using lecture.BLL;

namespace lecture
{
    public partial class index : System.Web.UI.Page
    {
        [Inject]
        public IUserRepository iu { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lb_messVCode.Text = "";
            lb_messName.Text = "";
            lb_messPwd.Text = "";
        }
        protected void btn_login_Click(object sender, ImageClickEventArgs e)
        {
            if (tb_UserName.Text != "")
            {
                if (tb_Pwd.Text != "")
                {
                    //if (tb_Code.Text.ToUpper() != Session["ValidCode"].ToString())
                    //{
                    //    Tools.addTip(lb_messVCode, "验证码不正确！", System.Drawing.Color.Red);
                    //}
                    //else
                    //{
                    //Tools.addTip(lb_messVCode, "可以登录！", System.Drawing.Color.Green);
                    if (iu.GetPwdAndName(tb_UserName.Text, tb_Pwd.Text))
                    {
                        User re = iu.GetUserByName(tb_UserName.Text);

                        //if (re.UserType == "听课教师" || re.UserType == "学生工作人员")
                        Session["User"] = re;
                        try
                        {
                            Response.Redirect("~/FramePage.aspx");
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                            Server.Transfer("~/FramePage.aspx");
                        }
                    }
                    else
                    {
                        Tools.addTip(lb_messVCode, "用户名或密码错误！", System.Drawing.Color.Red);
                    }

                    //}
                }
                else
                {
                    Tools.addTip(lb_messPwd, "密码不能为空！", System.Drawing.Color.Red);
                }
            }
            else
            {
                Tools.addTip(lb_messName, "用户名不能为空！", System.Drawing.Color.Red);
            }
        }

        protected void lbtn_UserRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FramePage.aspx");
        }

        protected void lbtn_returnPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PwdReturn.aspx");
        }
    }
}