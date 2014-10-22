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
    public partial class ChangePassword : System.Web.UI.Page
    {
        [Inject]
        public IUserRepository iu { get; set; }
        Find_Messages mess = new Find_Messages();

        protected void Page_Load(object sender, EventArgs e)
        {
            btn_ok.Attributes.Add("onclick", "return confirm('修改密码后需要重新登录，是否确定?');");
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            User u = (User)Session["User"];
            Teacher t = (Teacher)Session["Teacher"];
            if (Session["User"] != null)
            {
                if (iu.ChangePassword(u.UserId, tb_OldPaw.Text, tb_newPaw.Text))
                {
                    mess.FinalMessage2("为保证安全性，请重新登录！", "index.aspx", 0, 3);
                }
                else
                {
                    mess.FinalMessage("原密码不正确，密码修改失败！", "ChangePassword.aspx", 0);
                }

            }
            else if(Session["Teacher"] !=null)
            {
                if (iu.ChangePassword(t.UserId, tb_OldPaw.Text, tb_newPaw.Text))
                {
                    mess.FinalMessage2("为保证安全性，请重新登录！", "index.aspx", 0, 3);
                }
                else
                {
                    mess.FinalMessage("原密码不正确，密码修改失败！", "ChangePassword.aspx", 0);
                }
            }
            else
            {
                mess.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0, 2);
            }

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}