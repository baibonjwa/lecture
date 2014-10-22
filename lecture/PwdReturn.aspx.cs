using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;
using lecture.BLL;

namespace lecture
{
    public partial class PwdReturn : System.Web.UI.Page
    {
        UserRepository ur = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            User user = ur.GetUserByRealName(tb_realName.Text);
            if (user == null)
            {
                lb_info.Text = "该用户不存在";
            }
            else
            {
                MailAddress from = new MailAddress("lntulecture@163.com");
                MailAddress to = new MailAddress(user.UserEmail);
                MailMessage mm = new MailMessage(from, to);
                mm.Subject = "大学生课堂质量监督反馈系统---密码找回";
                mm.Body = "您的用户名为：" + user.UserName + " 您的密码为：" + user.UserPassword;
                mm.CC.Add(user.UserEmail);
                SmtpClient client = new SmtpClient("smtp.163.com");
                client.Credentials = new NetworkCredential("lntulecture@163.com", "lecture");

                if (user.UserEmail == "")
                {
                    lb_info.Text = "您没填写邮箱信息，无法找回密码。";
                }
                else
                {
                    try
                    {
                        client.Send(mm);
                        lb_info.Text = "发送成功！！";
                    }
                    catch
                    {
                        lb_info.Text = "发送失败！！请确保您已经输入正确的邮箱！";
                    }
                }
            }
        }
    }
}