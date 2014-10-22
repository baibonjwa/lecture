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
using lecture.Model.Abstract;
using lecture.Model.Concrete;
using lecture.Model.Entities;
using lecture.BLL;

public partial class FramePage : System.Web.UI.Page
{
    public String UserRegister = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            User u = (User)Session["User"];
            if (Session["User"] != null)
            {
                if (u.UserVerify == "待审核")
                {
                    lb_user.Text = "帐号未激活";
                    UserRegister = "UserVerifying.aspx";
                }
                else
                {
                    lb_user.Text = "欢迎:" + u.RealName.ToString();
                    UserRegister = "Welcome.aspx";
                }
            }
            else if (Session["Teacher"] != null)
            {
                lb_user.Text = "帐号未激活";
                UserRegister = "UserVerifying.aspx";
            }
            else
            {
                lb_user.Text = "未登录";
                UserRegister = "UserRegister.aspx";
            }
        }
    }

    protected void lbtn_out_Click(object sender, EventArgs e)
    {
        Session.Remove("User");
        Session.Remove("Teacher");
        Response.Redirect("index.aspx");
    }
}
