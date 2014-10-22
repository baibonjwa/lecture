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
    public partial class UserRegister : System.Web.UI.Page
    {
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public IDepartmentRepository idr { get; set; }
        [Inject]
        public ITeacherTypeRepsoitory ittr { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(UserRegister));
            if (!IsPostBack)
            {
                Tools.bind_DropDownList(dd_dep, idr.GetAllDepartment(), "DepName", "DepId");
                Tools.bind_DropDownList(dd_teacherType, ittr.GetAllType(), "teacherType", "teacherTypeID");
            }
        }


        [AjaxPro.AjaxMethod]
        public String GetUserExist(String userName)
        {
            String str = "";
            UserRepository ur = new UserRepository();
            if (ur.GetUserByName(userName) != null)
            {
                str = "该用户名已存在";
            }
            else
            {
            }
            return str;
        }
        [AjaxPro.AjaxMethod]
        public String GetTeacherNumExist(String num)
        {
            String str = "";
            UserRepository ur = new UserRepository();
            if (ur.GetTeacherByNum(num) != null)
            {
                str = "该工号已存在";
            }
            else
            {

            }
            return str;
        }

        protected void btn_UserRegister_Click(object sender, EventArgs e)
        {
            if(tb_username.Text =="")
            {
                lb_messUserName.Text = "用户名不能为空！";
            }
            else if(tb_paw.Text =="")
            {
                lb_messPwd0.Text = "密码不能为空！";
            }
            else if(tb_realName.Text =="")
            {
                lb_messRealName.Text = "请输入真实姓名！";
            }
            else if (tb_num.Text == "")
            {
                lb_messNum.Text = "教师工号不能为空！";
            }
            else
            {
                Teacher tea = new Teacher();
                tea.UserName = tb_username.Text;
                tea.UserPassword = tb_pwd2.Text;
                tea.RealName = tb_realName.Text;
                tea.UserDepartment = idr.GetDepartmentByID(Convert.ToInt32(dd_dep.SelectedItem.Value));
                tea.TeacherNum = tb_num.Text;
                tea.UserTel = tb_tel.Text;
                tea.UserEmail = tb_email.Text;
                tea.teacherType = ittr.GetTypeById(Convert.ToInt32(dd_teacherType.SelectedValue));
                tea.UserVerify = "待审核";

                if (HiddenField1.Value == "")
                    if (iurr.AddUser(tea))
                    {
                        Teacher tear = new Teacher();
                        tear = iurr.GetTeacherByNum(tea.TeacherNum);
                        Session["Teacher"] = (Teacher)tear;
                        Find_Messages mess = new Find_Messages();
                        mess.FinalMessage2("注册成功，待管理员审核通过后开放权限！", "FramePage.aspx", 0,2);
                    }
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Find_Messages mess2 = new Find_Messages();
            mess2.FinalMessage2("正在返回...","index.aspx",0,1);
        }

    }
}