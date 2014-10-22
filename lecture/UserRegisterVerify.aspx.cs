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
    public partial class UserRegisterVerify : System.Web.UI.Page
    {
        [Inject]
        public IDepartmentRepository idr { get; set; }
        [Inject]
        public IUserRepository iur { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtn_verify.Visible = false;
                Tools.bind_DropDownList(dd_dep, idr.GetAllDepartment(), "DepName", "DepId");
                lbtn_verify.Attributes.Add("onclick", "return confirm('勾选的用户将全部通过审核，是否确定?');");
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = iur.GetUserByVerify("待审核", dd_dep.SelectedValue);
            GridView1.DataBind();
            lbtn_verify.Visible = true;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            if (cmd == "Pass")
            {
                User lr = new User();
                lr.UserId = id;
                lr.UserVerify = "通过审核";

                iur.UpdateUserState(lr);
                GridView1.DataSource = iur.GetUserByVerify("待审核", dd_dep.SelectedValue);
                GridView1.DataBind();
            }
            else if (cmd == "NoPass")
            {
                //User lr = new User();
                //lr.UserId = id;
                //lr.UserVerify = "审核未通过";
                //iur.UpdateUserState(lr);
                iur.DeleteUser(id);
                GridView1.DataSource = iur.GetUserByVerify("待审核", dd_dep.SelectedValue);
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //添加自定义属性，当鼠标移走时还原该行的背景色   
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
                //添加审核确认
                LinkButton lbtn_pass = (LinkButton)e.Row.FindControl("lbtn_pass");
                lbtn_pass.Attributes.Add("onclick", "return confirm('您确认要通过审核吗?');");
                LinkButton lbtn_nopass = (LinkButton)e.Row.FindControl("lbtn_nopass");
                lbtn_nopass.Attributes.Add("onclick", "return confirm('不通过审核将直接删除该用户，是否确定?');");
            }
        }

        protected void lbtn_verify_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ckb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (ckb.Checked == true)
                {
                    User lr = new User();
                    LinkButton lbtn = (LinkButton)GridView1.Rows[i].FindControl("lbtn_pass");
                    lr.UserId = Convert.ToInt32(lbtn.CommandArgument);
                    lr.UserVerify = "通过审核";
                    iur.UpdateUserState(lr);
                }
            }
            GridView1.DataSource = iur.GetUserByVerify("待审核", dd_dep.SelectedValue);
            GridView1.DataBind();
        }
    }
}