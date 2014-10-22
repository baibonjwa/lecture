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
using System.Reflection;
using System.Text.RegularExpressions;

namespace lecture
{
    public partial class TaskAdd : System.Web.UI.Page
    {
        [Inject]
        public ITaskByDetail itbd { get; set; }
        [Inject]
        public ITaskByName itbn { get; set; }
        [Inject]
        public ITaskByType itbt { get; set; }
        [Inject]
        public IUserRepository iur { get; set; }
        [Inject]
        public ITeacherType irs { get; set; }
        [Inject]
        public ICourse ic { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                Tools.bind_DropDownList<TeacherTypeInfo>(dd_teacherType, irs.GetAllType(), "teacherType", "teacherTypeID");
            }
        }

        //按类型添加
        protected void btn_typeAdd_Click(object sender, EventArgs e)
        {
            User publisher = new User();
            TaskByTypeEntity taskEntity = new TaskByTypeEntity();
            taskEntity.TeacherType = irs.GetTypeById(Convert.ToInt32(dd_teacherType.SelectedValue));
            taskEntity.Week = Tools.ConvertWeek(cbl_typeWeek);
            taskEntity.Contents = tb_typeContents.Text;
            taskEntity.PublishTime = DateTime.Now;

            //获取姓名
            publisher = iur.GetUserByName("天才");
            taskEntity.Publisher = publisher;
            if (itbt.AddTask(taskEntity))
            {
                Tools.addTip(lb_info, "添加成功！", System.Drawing.Color.Green);
            }
            else
            {
                Tools.addTip(lb_info, "添加失败！", System.Drawing.Color.Green);
            }
        }

        //按姓名添加
        protected void btn_nameAdd_Click(object sender, EventArgs e)
        {
            TaskByNameEntity taskEntity = new TaskByNameEntity();

            taskEntity.Week = Tools.ConvertWeek(cbl_typeWeek);
            taskEntity.Contents = tb_typeContents.Text;
            //获取姓名
            taskEntity.Listener = (Teacher)iur.GetUserByName(tb_teaName.Value);
            taskEntity.Publisher = iur.GetUserByName("天才");
            taskEntity.PublishTime = DateTime.Now;
            taskEntity.Contents = tb_nameContents.Text;
            if (itbn.AddTask(taskEntity))
            {
                Tools.addTip(lb_info, "添加成功！", System.Drawing.Color.Green);
            }
            else
            {
                Tools.addTip(lb_info, "添加失败！", System.Drawing.Color.Green);
            }
        }

        protected void dd_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = dd_type.SelectedIndex;
        }

        protected void btn_detAdd_Click(object sender, EventArgs e)
        {
            //TaskByDetailEntity taskEntity = new TaskByDetailEntity();
            //taskEntity.Listener = (Teacher)iur.GetUserByName(tb_detName.Text);
            ////正则取方括号中的值
            //Regex reg = new Regex(@"(?<=\[)[^\[\]]+(?=\])");
            //MatchCollection mc = reg.Matches(tb_detcourse.Text);
            //taskEntity.Course = ic.GetCourseByNumer(mc[0].Value);
            //taskEntity.Contents = tb_detContents.Text;
            //taskEntity.Publisher = iur.GetUserByName("天才");
            //taskEntity.PublishTime = DateTime.Now;

            //if (itbd.AddTask(taskEntity))
            //{
            //    Tools.addTip(lb_info, "添加成功！", System.Drawing.Color.Green);
            //}
            //else
            //{
            //    Tools.addTip(lb_info, "添加失败！", System.Drawing.Color.Green);
            //}
        }
    }
}
