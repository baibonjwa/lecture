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
    public partial class RecordVerify : System.Web.UI.Page
    {
        [Inject]
        public IRecordSystem RDAL { get; set; }
        [Inject]
        public ITeacherType irs { get; set; }
        [Inject]
        public ITargetRepository itr { set; get; }
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public ILessionRecordRepository ILRR { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    if (ILRR.SelectedRecordIsPass("待审核") != null)
                    {
                        lb_info.Text = "";
                        List<LessionRecord> list = ILRR.SelectedRecordIsPass("待审核");
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i].ClassSpot = list[i].ClassSpot.Replace("|", "-");
                            String temp = "";
                            String[] str = list[i].Class_Str.Split('|');
                            for (int j = 0; j < str.Length - 1; j++)
                            {
                                temp += str[j];
                                temp += "<br />";
                            }
                            temp += str[str.Length - 1];
                            list[i].Class_Str = temp;
                        }
                        gv_Del.DataSource = list;
                        gv_Del.DataBind();
                    }
                    else
                    {
                        Tools.addTip(lb_info, "暂时没有修改申请！", System.Drawing.Color.Green);
                    }
                }
                else
                {
                    Find_Messages mess = new Find_Messages();
                    mess.FinalMessage2("登录信息已失效，请重新登录！", "index.aspx", 0, 2);
                }
            }
        }

        protected void gv_Del_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cmd = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);

            if (cmd == "Sel")
            {
                Session["id"] = id;
                Response.Redirect("RecordCheck.aspx");
            }
            else if (cmd == "Pass")
            {
                LessionRecord lr = new LessionRecord();
                lr.Id = id;
                lr.State = "通过审核";
                ILRR.UpdateRecordState(lr);
                gv_Del.DataSource = ILRR.SelectedRecordIsPass("待审核");
                gv_Del.DataBind();
                //if (ILRR.UpdateRecordState(lr))
                //{
                //    //Response.Write("我是天才！！");
                //    Find_Messages mess = new Find_Messages();
                //    mess.FinalMessage("审核通过，正在自动返回...", "RecordVerify.aspx", 0);
                //}
            }
            else if (cmd == "NoPass")
            {
                LessionRecord lr = new LessionRecord();
                lr.Id = id;
                lr.State = "审核未通过";
                ILRR.UpdateRecordState(lr);
                gv_Del.DataSource = ILRR.SelectedRecordIsPass("待审核");
                gv_Del.DataBind();
                //if (ILRR.UpdateRecordState(lr))
                //{
                //    //Response.Write("我是天才！！");
                //    Find_Messages mess = new Find_Messages();
                //    mess.FinalMessage("审核不予通过，正在自动返回...", "RecordVerify.aspx", 0);
                //}
            }
        }

        protected void gv_Del_RowDataBound(object sender, GridViewRowEventArgs e)
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
                lbtn_nopass.Attributes.Add("onclick", "return confirm('您确认不要通过审核吗?');");
            }
        }
    }
}