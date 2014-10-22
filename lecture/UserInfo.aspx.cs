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
    public partial class UserInfo : System.Web.UI.Page
    {
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public IDepartmentRepository idr { get; set; }
        [Inject]
        public ITeacherTypeRepsoitory ittr { get; set; }
        Find_Messages mess = new Find_Messages();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    Panel1.Visible = false;
                    Tools.bind_DropDownList(dd_dep, idr.GetAllDepartment(), "DepName", "DepId");
                    Tools.bind_DropDownList(dd_teacherType, ittr.GetAllType(), "teacherType", "teacherTypeID");
                }
                else
                {
                    mess.FinalMessage2("登录信息失效，请重新登录","index.aspx",0,2);
                }
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            gv_info.DataSource = iurr.GetTeacherByName(tb_teacherName.Text);
            gv_info.DataBind();
            Panel1.Visible = false;
        }

        protected void btn_UserRegister_Click(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                int id = Convert.ToInt32(Session["id"]);
                Teacher tea = new Teacher();
                tea.teacherType = new TeacherTypeInfo();
                tea.UserId = id;
                tea.UserName = tb_username0.Text;
                tea.teacherType.TeacherTypeID = Convert.ToInt32(dd_teacherType.SelectedValue);
                tea.RealName = tb_realName.Text;
                tea.UserDepartment = idr.GetDepartmentByID(Convert.ToInt32(dd_dep.SelectedItem.Value));
                tea.TeacherNum = tb_num.Text;
                tea.UserTel = tb_tel0.Text;
                tea.UserEmail = tb_email0.Text;
                tea.UserType = dd_power.SelectedItem.Text;
                iurr.UpdateUser(tea);
                mess.FinalMessage("用户信息修改成功！", "UserInfo.aspx", 0);
            }
            else
            {
                mess.FinalMessage("请选择一条信息查看！", "UserInfo.aspx", 0);
            }
        }

        protected void gv_info_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            Session["id"] = id;
            if (cmd == "Sel")
            {
                Panel1.Visible = true;
                Teacher tea = new Teacher();
                tea = iurr.GetTeacherByID(id);
                tb_username0.Text = tea.UserName;
                tb_realName.Text = tea.RealName;
                dd_dep.SelectedIndex = Tools.SelectDD_Text(dd_dep, tea.UserDepartment.DepName);
                dd_teacherType.SelectedIndex = Tools.SelectDD_Text(dd_teacherType, tea.teacherType.TeacherType);
                dd_power.SelectedIndex = Tools.SelectDD_Value(dd_power, tea.UserType.ToString());
                tb_num.Text = tea.TeacherNum.ToString();
                tb_tel0.Text = tea.UserTel;
                tb_email0.Text = tea.UserEmail;

            }
        }

    }
}