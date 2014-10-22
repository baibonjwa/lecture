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
    public partial class UserEdit : System.Web.UI.Page
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
                User u = (User)Session["User"];
                if (Session["User"] != null)
                {
                    Teacher tea = iurr.GetTeacherByID(u.UserId);
                    tb_username.Text = tea.UserName;
                    //tb_pwd2.Text = tb_paw.Text = tea.UserPassword;
                    tea.RealName = tb_realName.Text = tea.RealName;
                    dd_dep.SelectedIndex = Tools.SelectDD_Value(dd_dep, tea.UserDepartment.DepId.ToString());
                    tb_num.Text = tea.TeacherNum;
                    //tb_tel.Text = tea.UserTel;
                    //tb_email.Text = tea.UserEmail;
                    dd_teacherType.SelectedIndex = Tools.SelectDD_Value(dd_dep, tea.teacherType.TeacherTypeID.ToString());
                }
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
            Teacher tea = new Teacher();
            tea.UserName = tb_username.Text;
            tea.RealName = tb_realName.Text;
            tea.UserDepartment = idr.GetDepartmentByID(Convert.ToInt32(dd_dep.SelectedItem.Value));
            tea.TeacherNum = tb_num.Text;
            tea.teacherType = ittr.GetTypeById(Convert.ToInt32(dd_teacherType.SelectedValue));

            if (HiddenField1.Value == "")
                iurr.UpdateUser(tea);
        }

    }
}