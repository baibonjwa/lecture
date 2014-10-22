using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;
using System.IO;
using lecture.Model.Concrete;


/// <summary>
///DataClass 的摘要说明
/// </summary>
public class FileUpDown
{
    protected SqlConnection defaultconn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_competition"].ToString());
    public FileUpDown()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
//    public bool SaveFilesInfo(HttpFileCollection fileColl)
//    {
//        SqlCommand sqlComm;
//        string strComm = @"insert into 
//                        tb_file
//                        values(@fileName,@fileType,@filePath)";
//        StringBuilder sbFileName;
//        try
//        {
//            string myDicPath = "~/Files/Upload/";
//            myDicPath += DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_";
//            if (!Directory.Exists(myDicPath))
//                Directory.CreateDirectory(myDicPath);
//            sqlComm = new SqlCommand(strComm, SqlHelper.GetConnection());
//            //循环保存上传信息
//            for (int i = 0; i < fileColl.Count; i++)
//            {
//                if (!String.IsNullOrEmpty(fileColl[i].FileName))
//                {
//                    //使用年月日时分秒毫秒生成文件名
//                    sbFileName = new StringBuilder();
//                    sbFileName.Append(Path.GetExtension(fileColl[i].FileName));
//                    sbFileName.Append('_');
//                    sbFileName.Append(DateTime.Now.Year);
//                    sbFileName.Append(DateTime.Now.Month);
//                    sbFileName.Append(DateTime.Now.Day);
//                    sbFileName.Append(DateTime.Now.Hour);
//                    sbFileName.Append(DateTime.Now.Minute);
//                    sbFileName.Append(DateTime.Now.Second);
//                    sbFileName.Append(DateTime.Now.Millisecond);


//                    //为SQL命令指定对应参数
//                    //sqlComm.Parameters.Clear();
//                    //sqlComm.Parameters.AddWithValue("@fileName", sbFileName.ToString());
//                    //sqlComm.Parameters.AddWithValue("@fileType", );
//                    //sqlComm.Parameters.AddWithValue("@filePath", System.Web.HttpContext.Current.Server.MapPath(myDicPath));

//                    sqlComm.ExecuteNonQuery();//执行SQL命令
//                    //保存对应的文件到服务器
//                    fileColl[i].SaveAs(System.Web.HttpContext.Current.Server.MapPath(myDicPath) + sbFileName.ToString());
//                }
//            }
//            return true;
//        }
//        catch (Exception ex)
//        {
//            return false;
//        }
//    }
    public DataTable GetFilesInfo()
    {
        SqlDataAdapter sqlAdpt;
        DataTable dtFilesInfo;
        string strComm = "select NewFileName,OldFileName,SaveAddress,UploadTime,TypeName from tb_UploadFile";
        try
        {
            sqlAdpt = new SqlDataAdapter(strComm, SqlHelper.GetConnection());//使用数据适配器读取数据
            dtFilesInfo = new DataTable();
            sqlAdpt.Fill(dtFilesInfo);//填充数据到DataTable
            return dtFilesInfo;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




}
