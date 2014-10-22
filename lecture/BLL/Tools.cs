using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Web.UI;
using System.Reflection;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using lecture.Model.Entities;

namespace lecture.BLL
{
    static public class Tools
    {
        //周次转换成数组
        //static public int[] ConvertWeek(CheckBoxList cbl)
        //{
        //    int[] results = new int[7];
        //    for (int i = 0; i < 7; i++)
        //    {
        //        if (cbl.Items[i].Selected == true)
        //        {
        //            results[i] = 1;
        //        }
        //        else
        //        {
        //            results[i] = 0;
        //        }
        //    }
        //    return results;
        //}
        //返回星期几
        static public string DaysoOfTheWeek(DateTime dt)
        {
            string week = "";
            switch (dt.DayOfWeek.ToString())
            {
                case "Monday":
                    week = "星期一";
                    break;
                case "Tuesday":
                    week = "星期二";
                    break;
                case "Wednesday":
                    week = "星期三";
                    break;
                case "Thursday":
                    week = "星期四";
                    break;
                case "Friday":
                    week = "星期五";
                    break;
                case "Saturday":
                    week = "星期六";
                    break;
                case "Sunday":
                    week = "星期日";
                    break;
            }
            return week;
        }
        //添加年
        static public void add_year(DropDownList dd)
        {
            int years = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["StartYear"]);

            DateTime now = DateTime.Now;
            if (now.Month > 10)
            {
                years = years + 1;
            }
            //int years = now.Year +1;

            for (int i = 2013; i <= years; )
            {
                dd.Items.Add(years.ToString());
                years--;
            }
        }
        static public String ConvertWeek(CheckBoxList cbl)
        {
            string results = "";
            for (int i = 0; i < 7; i++)
            {
                if (cbl.Items[i].Selected == true)
                {
                    results += "1,";
                }
                else
                {
                    results += "0,";
                }

            }
            results = results.Substring(0, results.Length - 1);
            return results;
        }

        static public void addTip(Label lb, string str, System.Drawing.Color DrawClor)
        {
            lb.Text = str;
            lb.ForeColor = DrawClor;
        }
        static public void bind_checkList<T>(CheckBoxList cbl, List<T> ds, String text_str, String value_str)
        {
            cbl.DataSource = ds;
            cbl.DataTextField = text_str;
            cbl.DataValueField = value_str;
            cbl.DataBind();
        }
        static public void bind_DropDownList<T>(DropDownList ddl, List<T> ds, String text_str, String value_str)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = text_str;
            ddl.DataValueField = value_str;
            ddl.DataBind();
        }
        static public void bind_DropDownList_all<T>(DropDownList ddl, List<T> ds, String text_str, String value_str)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = text_str;
            ddl.DataValueField = value_str;
            ddl.DataBind();

            ListItem myddlist = new ListItem();
            myddlist.Text = "全部";
            myddlist.Value = "0";
            ddl.Items.Insert(0, myddlist);
            // dd_name.Items.Add(myddlist);
            if (ddl.Items.Count > 1) ddl.SelectedIndex = 0;
        }
        static public int SelectDD_Text(DropDownList dd, string Text)
        {
            int j = 0;
            for (j = 0; j < dd.Items.Count; j++)
            {
                if (dd.Items[j].Text == Text)
                {
                    return j;
                }
                else
                {
                    continue;
                }
            }
            return -1;
        }
        static public int SelectDD_Value(DropDownList dd, string value)
        {
            int k = 0;
            int j = 0;
            for (j = 0; j < dd.Items.Count; j++)
            {
                if (dd.Items[j].Value == value)
                {
                    k = 1;
                    break;
                }
            }
            if (1 == k)
            {
                return j;
            }
            else
            {
                return -1;
            }
        }
        static public DataSet ListToDataSet(IList ResList)
        {
            DataSet RDS = new DataSet();
            DataTable TempDT = new DataTable();

            //此处遍历IList的结构并建立同样的DataTable
            System.Reflection.PropertyInfo[] p = ResList[0].GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo pi in p)
            {
                TempDT.Columns.Add(pi.Name, System.Type.GetType(pi.PropertyType.ToString()));
            }

            for (int i = 0; i < ResList.Count; i++)
            {
                IList TempList = new ArrayList();
                //将IList中的一条记录写入ArrayList
                foreach (System.Reflection.PropertyInfo pi in p)
                {
                    object oo = pi.GetValue(ResList[i], null);
                    TempList.Add(oo);
                }

                object[] itm = new object[p.Length];
                //遍历ArrayList向object[]里放数据
                for (int j = 0; j < TempList.Count; j++)
                {
                    itm.SetValue(TempList[j], j);
                }
                //将object[]的内容放入DataTable
                TempDT.LoadDataRow(itm, true);
            }
            //将DateTable放入DataSet
            RDS.Tables.Add(TempDT);
            //返回DataSet
            return RDS;
        }
        public static void GridViewToExcel(Control ctrl, string FileType, string FileName)
        {
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;//注意编码
            HttpContext.Current.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            HttpContext.Current.Response.ContentType = FileType;//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword 
            ctrl.Page.EnableViewState = false;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            ctrl.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }
        //static public DataSet ListToDataSet(IList ResList)
        //{
        //    DataSet RDS = new DataSet();
        //    DataTable TempDT = new DataTable();

        //    //此处遍历IList的结构并建立同样的DataTable
        //    System.Reflection.PropertyInfo[] p = ResList[0].GetType().GetProperties();
        //    foreach (System.Reflection.PropertyInfo pi in p)
        //    {
        //        TempDT.Columns.Add(pi.Name, System.Type.GetType(pi.PropertyType.ToString()));
        //    }

        //    for (int i = 0; i < ResList.Count; i++)
        //    {
        //        IList TempList = new ArrayList();
        //        //将IList中的一条记录写入ArrayList
        //        foreach (System.Reflection.PropertyInfo pi in p)
        //        {
        //            object oo = pi.GetValue(ResList[i], null);
        //            TempList.Add(oo);
        //        }

        //        object[] itm = new object[p.Length];
        //        //遍历ArrayList向object[]里放数据
        //        for (int j = 0; j < TempList.Count; j++)
        //        {
        //            itm.SetValue(TempList[j], j);
        //        }
        //        //将object[]的内容放入DataTable
        //        TempDT.LoadDataRow(itm, true);
        //    }
        //    //将DateTable放入DataSet
        //    RDS.Tables.Add(TempDT);
        //    //返回DataSet
        //    return RDS;
        //}
        /// <summary>
        /// 泛型集合类导出成excel
        /// </summary>
        /// <param name="list">泛型集合类</param>
        /// <param name="fileName">生成的excel文件名</param>
        /// <param name="propertyName">excel的字段列表</param>
        public static void ListToExcel(IList<LessionRecord> list, string fileName, params string[] propertyName)
        {
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel;charset=UTF-8";
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.BinaryWrite(ListToExcel(list, propertyName).GetBuffer());
            HttpContext.Current.Response.End();
        }

        public static MemoryStream ListToExcel(IList<LessionRecord> list, params string[] propertyName)
        {
            //创建流对象
            using (MemoryStream ms = new MemoryStream())
            {
                //将参数写入到一个临时集合中
                List<string> propertyNameList = new List<string>();
                if (propertyName != null)
                    propertyNameList.AddRange(propertyName);
                //床NOPI的相关对象

                Workbook workbook = new HSSFWorkbook();
                Sheet sheet = workbook.CreateSheet();
                Row headerRow = sheet.CreateRow(0);

                for (int i = 0; i < propertyName.Length; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(propertyName[i]);
                }

                if (list.Count > 0)
                {
                    //通过反射得到对象的属性集合
                    //PropertyInfo[] propertys = list[0].GetType().GetProperties();
                    ////遍历属性集合生成excel的表头标题
                    //for (int i = 0; i < propertys.Count(); i++)
                    //{
                    //    //判断此属性是否是用户定义属性
                    //    if (propertyNameList.Count == 0)
                    //    {
                    //        headerRow.CreateCell(i).SetCellValue(propertys[i].Name);
                    //    }
                    //    else
                    //    {
                    //        if (propertyNameList.Contains(propertys[i].Name))
                    //            headerRow.CreateCell(i).SetCellValue(propertys[i].Name);
                    //    }
                    //}


                    int rowIndex = 1;
                    //遍历集合生成excel的行集数据
                    for (int i = 0; i < list.Count; i++)
                    {
                        Row dataRow = sheet.CreateRow(rowIndex);

                        dataRow.CreateCell(0).SetCellValue(list[i].WeekNumber.ToString());
                        dataRow.CreateCell(1).SetCellValue(list[i].RecordDate.ToString());
                        dataRow.CreateCell(2).SetCellValue(list[i].RecordTime_Str);
                        dataRow.CreateCell(3).SetCellValue(list[i].ClassSpot);
                        dataRow.CreateCell(4).SetCellValue(list[i].Class_Str);
                        dataRow.CreateCell(5).SetCellValue(list[i].CourseTeacher_Str);
                        dataRow.CreateCell(6).SetCellValue(list[i].CourseType_Str);
                        dataRow.CreateCell(7).SetCellValue(list[i].Course_Str);
                        if (list[i].Contents.Count == 22)
                        {
                            dataRow.CreateCell(8).SetCellValue(list[i].Contents[0].ItemContent);
                            dataRow.CreateCell(9).SetCellValue(list[i].Contents[1].ItemContent);
                            dataRow.CreateCell(10).SetCellValue(list[i].Contents[2].ItemContent);
                            dataRow.CreateCell(11).SetCellValue(list[i].Contents[3].ItemContent);
                            dataRow.CreateCell(12).SetCellValue(list[i].Contents[4].ItemContent);
                            dataRow.CreateCell(13).SetCellValue(list[i].Contents[5].ItemContent);
                            dataRow.CreateCell(14).SetCellValue(list[i].Contents[6].ItemContent);
                            dataRow.CreateCell(15).SetCellValue(list[i].Contents[7].ItemContent);
                            dataRow.CreateCell(16).SetCellValue(list[i].Contents[8].ItemContent);
                            dataRow.CreateCell(17).SetCellValue(list[i].Contents[9].ItemContent);
                            dataRow.CreateCell(18).SetCellValue(list[i].Contents[10].ItemContent);
                            dataRow.CreateCell(19).SetCellValue(list[i].Contents[11].ItemContent);
                            dataRow.CreateCell(20).SetCellValue(list[i].Contents[12].ItemContent);
                            dataRow.CreateCell(21).SetCellValue(list[i].Contents[13].ItemContent);
                            dataRow.CreateCell(22).SetCellValue(list[i].Contents[14].ItemContent);
                            dataRow.CreateCell(23).SetCellValue(list[i].Contents[15].ItemContent);
                            dataRow.CreateCell(24).SetCellValue(list[i].Contents[16].ItemContent);
                            dataRow.CreateCell(25).SetCellValue(list[i].Contents[17].ItemContent);
                            dataRow.CreateCell(26).SetCellValue(list[i].Contents[18].ItemContent);
                            dataRow.CreateCell(27).SetCellValue(list[i].Contents[19].ItemContent);
                            dataRow.CreateCell(28).SetCellValue(list[i].Contents[20].ItemContent);
                            dataRow.CreateCell(29).SetCellValue(list[i].Contents[21].ItemContent);
                        }
                        dataRow.CreateCell(30).SetCellValue(list[i].Listener.RealName);
                        dataRow.CreateCell(31).SetCellValue(list[i].Listener.UserDepartment.DepName);
                        //if (propertyNameList.Count == 0)
                        //{
                        //    object obj = propertys[j].GetValue(list[i], null);
                        //    if (obj == null)
                        //    {
                        //        dataRow.CreateCell(j).SetCellValue("无值");
                        //    }
                        //    else
                        //    {
                        //        dataRow.CreateCell(j).SetCellValue(obj.ToString());
                        //    }

                        //}
                        //else
                        //{
                        //    if (propertyNameList.Contains(propertys[j].Name))
                        //    {
                        //        object obj = propertys[j].GetValue(list[i], null);
                        //        dataRow.CreateCell(j).SetCellValue(obj.ToString());
                        //    }
                        //}
                        rowIndex++;
                    }
                }
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }
    }
}