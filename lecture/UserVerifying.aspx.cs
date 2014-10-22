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
    public partial class UserVerifying : System.Web.UI.Page
    {
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public IDepartmentRepository idr { get; set; }
        [Inject]
        public ITeacherTypeRepsoitory ittr { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tools.bind_DropDownList(dd_dep, idr.GetAllDepartment(), "DepName", "DepId");
                Tools.bind_DropDownList(dd_teacherType, ittr.GetAllType(), "teacherType", "teacherTypeID");
                bind();
            }

        }
        void bind()
        {
            User nn = (User)Session["User"];
            Teacher u = (Teacher)Session["Teacher"];
            if (Session["Teacher"] != null)
            {
                lb_title.Text = "用户未激活";
                tb_username.Text = u.UserName;
                dd_dep.SelectedIndex = Tools.SelectDD_Value(dd_dep, u.UserDepartment.DepId.ToString());
                dd_teacherType.SelectedIndex = Tools.SelectDD_Value(dd_teacherType, u.teacherType.TeacherTypeID.ToString());
                tb_realName.Text = u.RealName;
                tb_num.Text = u.TeacherNum;
                tb_tel.Text = u.UserTel;
                tb_email.Text = u.UserEmail;

            }
            else if (Session["User"] != null)
            {
                if (nn.UserVerify == "待审核")
                {
                    lb_title.Text = "用户未激活";

                }
                else
                {
                    lb_title.Text = "用户信息修改";
                    tb_username.Enabled = false;
                    tb_realName.Enabled = false;
                    dd_dep.Enabled = false;
                    dd_teacherType.Enabled = false;
                    tb_num.Enabled = false;
                }
                u = iurr.GetTeacherByID(nn.UserId);
                tb_username.Text = u.UserName;
                dd_dep.SelectedIndex = Tools.SelectDD_Value(dd_dep, u.UserDepartment.DepId.ToString());
                dd_teacherType.SelectedIndex = Tools.SelectDD_Value(dd_teacherType, u.teacherType.TeacherTypeID.ToString());
                tb_realName.Text = u.RealName;
                tb_num.Text = u.TeacherNum;
                tb_tel.Text = u.UserTel;
                tb_email.Text = u.UserEmail;
            }

            else
            {
                Find_Messages mess = new Find_Messages();
                mess.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0, 2);
            }
        }

        protected void btn_UserRegister_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "")
            {
                lb_messUserName.Text = "用户名不能为空！";
            }
            else if (tb_realName.Text == "")
            {
                lb_messRealName.Text = "请输入真实姓名！";
            }
            else if (tb_num.Text == "")
            {
                lb_messNum.Text = "教师工号不能为空！";
            }
            else
            {
                int id;
                if (Session["User"] != null)
                {
                    User u = (User)Session["User"];
                    id = u.UserId;

                    Teacher tea = new Teacher();
                    tea.UserId = id;
                    tea.teacherType = new TeacherTypeInfo();
                    tea.teacherType.TeacherTypeID = Convert.ToInt32(dd_teacherType.SelectedValue);
                    tea.UserName = tb_username.Text;
                    tea.RealName = tb_realName.Text;
                    tea.UserDepartment = idr.GetDepartmentByID(Convert.ToInt32(dd_dep.SelectedItem.Value));
                    tea.TeacherNum = tb_num.Text;
                    tea.UserTel = tb_tel.Text;
                    tea.UserEmail = tb_email.Text;
                    tea.UserType = u.UserType;
                    iurr.UpdateUser(tea);
                    Find_Messages mes = new Find_Messages();
                    mes.FinalMessage("保存成功！", "UserVerifying.aspx", 0);

                }
                else if (Session["Teacher"] != null)
                {
                    Teacher tt = (Teacher)Session["Teacher"];
                    id = tt.UserId;
                    Teacher tea = new Teacher();
                    tea.teacherType = new TeacherTypeInfo();
                    tea.UserId = id;
                    tea.teacherType.TeacherTypeID = Convert.ToInt32(dd_teacherType.SelectedValue);
                    tea.UserName = tb_username.Text;
                    tea.RealName = tb_realName.Text;
                    tea.UserDepartment = idr.GetDepartmentByID(Convert.ToInt32(dd_dep.SelectedItem.Value));
                    tea.TeacherNum = tb_num.Text;
                    tea.UserTel = tb_tel.Text;
                    tea.UserEmail = tb_email.Text;
                    tea.UserType = tt.UserType;
                    iurr.UpdateUser(tea);
                    Session["Teacher"] = tea;
                    Find_Messages mes = new Find_Messages();
                    mes.FinalMessage("保存成功！", "UserVerifying.aspx", 0);
                }
                else
                {
                    Find_Messages mes = new Find_Messages();
                    mes.FinalMessage2("登录信息丢失，请重新登录！", "index.aspx", 0, 2);
                }
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
    }
}