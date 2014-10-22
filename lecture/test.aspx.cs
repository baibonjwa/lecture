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
    public partial class test : System.Web.UI.Page
    {
        [Inject]
        public IRecordSystem RDAL { get; set; }

        [Inject]
        public ITeacherType irs { get; set; }

        [Inject]
        public IDepartment idp { get; set; }

        [Inject]
        public IUserRegister iur { get; set; }
        [Inject]
        public IUserRepository iurr { get; set; }
        [Inject]
        public ITaskByDetail itbd { get; set; }
        [Inject]
        public ITaskByName itbn { get; set; }
        [Inject]
        public ITaskByType itbt { get; set; }
        [Inject]
        public ITeacherType irt { get; set; }
        [Inject]
        public ICourse ic { get; set; }
        [Inject]
        public IMajor im { get; set; }
        [Inject]
        public IClass iclass { get; set; }
        [Inject]
        public IItemTypeRepository iitr { get; set; }

        [Inject]
        public ILessionCheckUp ilcu { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Tools.add_year(dd_years);
            dd_years.SelectedIndex = Tools.SelectDD_Value(dd_years, DateTime.Now.Year.ToString());

            //LessionRecord lmelr = new LessionRecord();
            //lmelr.Id = 1;
            //lmelr.ClassSpot = "尔雅楼110";

            //if (RDAL.AddRecord(lmelr))
            //{
            //    Response.Write("我的类型是:" + RDAL.GetType().ToString());
            //}


            //教师类型添加
            //TeacherTypeInfo tt = new TeacherTypeInfo();
            //tt.TeacherType = "人才";
            //tt.IsStop = 0;
            //irs.AddType(tt);
            //GridView1.DataSource = irs.GetAllType();
            //GridView1.DataBind();
            //Tools.bind_checkList<TeacherTypeInfo>(CheckBoxList1, irs.GetAllType(), "teacherType", "teacherTypeID");

            //用户注册（添加）
            //TeacherManage tt = new TeacherManage();
            //tt.UserName = "老师";
            //tt.RealName = "就是老师";
            //tt.UserTel = "123";
            //tt.UserEmail = "123123123";
            //tt.UserPassword = "2323";
            //tt.UserDepartment = idp.GetDepartmentByID(2);
            //tt.teacherTypeID = irt.GetTypeById(3);
            //iurr.AddUser((Teacher)tt);

            //部门添加
            //DepartmentInfo di = new DepartmentInfo();
            //di.DepName = "aaa";
            //di.DepType = "bbb";
            //di.IsStop = "0";
            //idp.AddDepartment(di);

            //专业添加
            //MajorInfo di = new MajorInfo();
            //di.MajorName = "通信专业";
            //di.MajorDepartment = idp.GetDepartmentByID(2);
            //di.IsStop = 0;
            //im.AddMajor(di);


            //班级添加
            //ClassInfo di = new ClassInfo();
            //di.ClassName = "计软10-1班";
            //di.ClassMajor = im.GetMajorByID(1);
            //di.ClassDep = idp.GetDepartmentByID(2);
            //iclass.AddClass(di);

            //听课记录添加
            //LessionRecord lr = new LessionRecord();
            //lr.WeekNumber = 0;
            //lr.RecordDate = DateTime.Now;
            //lr.ClassSpot = "静远102";
            //lr.Course = ic.GetCourseByID(1);
            //lr.Listener = iurr.GetUserByName("天才");

            //RecordItem ri = new RecordItem();
            //ri.ItemContent = "不错";
            //ri.ItemTypeID = iitr.GetItemTypeByTypeAndName("学生出勤情况", "迟到").ItemTypeID;
            //lr.AddContent(ri);
            //lr.AddContent(ri);

            //if (RDAL.AddRecord(lr))
            //{
            //    Response.Write("我是天才！！");
            //}
            //Teacher tea = new Teacher();
            //tea.

            //Teacher tea = iurr.GetTeacherByID(2);
            //ilcu.TaskCount(tea, 1);

            //ClassInfo cl = iclass.GetClassByID(1);
            //LessionRecordRepository lrr = new LessionRecordRepository();

            //GridView1.DataSource = lrr.GetRecordsById(1);
            //GridView1.DataBind();
        }
    }
}