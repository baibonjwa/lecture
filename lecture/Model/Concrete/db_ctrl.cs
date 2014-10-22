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

/// <summary>
///db_ctrl 的摘要说明:这个类包含所有对数据库的操作
/// </summary>
public class db_ctrl
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db_lecture"].ToString());
    protected SqlConnection defaultconn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_lecture"].ToString());
    public db_ctrl()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region 数据操作（对数据库进行查（select），增加（insert），更新（update），删除（delet））
    //判断是否有数据读出,如果有数据返回1无数据返回0（select）
    public string read_DB(string SQLstr)
    {
        defaultconn.Open();
        SqlCommand mycommand = new SqlCommand(SQLstr, defaultconn);
        SqlDataReader myreader = mycommand.ExecuteReader();
        if (myreader.Read())
        {
            myreader.Close();
            defaultconn.Close();
            return "1";
        }
        myreader.Close();
        defaultconn.Close();
        return "0";
    }
    //从数据库中返回一个字符串(select)
    public string read_DB_return(string SQLstr)
    {
        defaultconn.Open();
        SqlCommand mycommand = new SqlCommand(SQLstr, defaultconn);
        SqlDataReader myreader = mycommand.ExecuteReader();
        string tempResult = "0";
        if (myreader.Read())
        {
            tempResult = myreader[0].ToString();
        }
        myreader.Close();
        defaultconn.Close();
        return tempResult;
    }
    //返回数据库中的值---字符串数组,从数据库中返回一个字符串数组（select）
    public String[] read_DB_results(string SQLstr, int length)
    {
        String[] results = new String[length];
        defaultconn.Open();
        SqlCommand mycommand = new SqlCommand(SQLstr, defaultconn);
        SqlDataReader myreader = mycommand.ExecuteReader();
        if (myreader.Read())
        {
            for (int i = 0; i < length; i++)
            {
                results[i] = myreader[i].ToString();
            }
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                results[i] = "无数据";
            }
        }
        myreader.Close();
        defaultconn.Close();
        return results;
    }
    //能按字段传值并返回数据库中的值--Object数组值，
    //这样理解Object类型：可以接受任何数据类型的数据，在希望使用Object类型的数据前应先将其转换成相应格式如（.string(),.toint16()等等）
    //DBProperty[] 中填写要查询的数据库字段 用一次你就会了。
    //(select)
    public Object[] read_DB_Object(int length, String[] DBProperty, String clause_where, String dbTable)
    {
        defaultconn.Open();
        string sql_Porperty = " ";
        for (int i = 0; i < length; i++)
        {
            sql_Porperty += DBProperty[i] + ",";
        }

        string tempSQL = sql_Porperty.Substring(0, sql_Porperty.Length - 1);

        Object[] dbPropertys = new Object[length];
        String SQLstr = "select " + tempSQL + "  from " + dbTable + " where " + clause_where;
        SqlCommand mycommand = new SqlCommand(SQLstr, defaultconn);
        SqlDataReader myreader = mycommand.ExecuteReader();
        if (myreader.Read())
        {
            for (int i = 0; i < length; i++)
            {
                dbPropertys[i] = myreader[i];
            }
        }
        myreader.Close();
        defaultconn.Close();
        return dbPropertys;
    }


    //向数据库填加数据，自己写好数据库添加语句然后传进来一个SQL语句直接执行,功能非常若，但是代码简洁，我们基本上使用下面一个它的进化版本（insert）
    public void db_exec(String SQLstr)
    {
        defaultconn.Open();
        SqlCommand mycomm = new SqlCommand(SQLstr, defaultconn);
        mycomm.ExecuteNonQuery();
        defaultconn.Close();
    }
    //向数据库填加数据，不需要自己写SQL语句，将数组填写明白就行
    //用一次你就会了
    //（insert）
    public void db_exec_paras_insert(String[] DBPropertys, String DBTable, int length, Object[] contents)
    {

        defaultconn.Open();

        string sql_Porperty = " ";
        string sql_Porperty2 = " ";

        for (int i = 0; i < length; i++)
        {
            sql_Porperty += DBPropertys[i] + ",";
            sql_Porperty2 += "@" + DBPropertys[i] + ",";
        }

        string tempSQL = sql_Porperty.Substring(0, sql_Porperty.Length - 1);
        string tempSQL2 = sql_Porperty2.Substring(0, sql_Porperty2.Length - 1);
        String SQLstr = "insert into " + DBTable + " (" + tempSQL + ") values (" + tempSQL2 + ")";

        SqlCommand mycomm = new SqlCommand(SQLstr, defaultconn);
        for (int i = 0; i < length; i++)
        {
            mycomm.Parameters.AddWithValue("@" + DBPropertys[i], contents[i]);
        }

        mycomm.ExecuteNonQuery();
        defaultconn.Close();
    }
    //更新数据时使用的代码，不需要自己写SQL语句，将数组填写明白就行
    //用一次你就会用了
    //（update）
    public void db_exec_paras_update(String[] DBPropertys, String DBTable, int length, Object[] contents, String clause_where)
    {
        //try
        //{
        defaultconn.Open();

        string sql_Porperty = " ";

        for (int i = 0; i < length; i++)
        {
            sql_Porperty += (DBPropertys[i] + "=@" + DBPropertys[i] + ",");
        }

        string tempSQL = sql_Porperty.Substring(0, sql_Porperty.Length - 1);

        String SQLstr = "update  " + DBTable + " set " + tempSQL + " where " + clause_where;
        //return SQLstr;
        SqlCommand mycomm = new SqlCommand(SQLstr, defaultconn);
        for (int i = 0; i < length; i++)
        {
            mycomm.Parameters.AddWithValue("@" + DBPropertys[i], contents[i]);
        }

        mycomm.ExecuteNonQuery();
        defaultconn.Close();
        //    return 1;
        //}
        //catch
        //{
        //    defaultconn.Close();
        //    return 0;
        //}

    }
    //这是一个查询用的类，反回的是一个DataSet内存表，你学到一定程度知道什么是DataSet了可以开放这段代码。
    //public DataSet db_exec_paras_selectAll(String[] DBPropertys, String DBTable, int length, SqlDbType[] sqlTypes, Object[] contents)
    //{
    //    DataSet myds = new DataSet();
    //    defaultconn.Open();
    //    try
    //    {

    //        string sql_Porperty = " ";

    //        for (int i = 0; i < length; i++)
    //        {
    //            sql_Porperty += (DBPropertys[i] + "=@" + DBPropertys[i] + " and ");
    //        }

    //        string tempSQL = sql_Porperty.Substring(0, sql_Porperty.Length - 4);

    //        String SQLstr = "select * from " + DBTable + " where " + tempSQL + ")";



    //        SqlDataAdapter mysda = new SqlDataAdapter();
    //        SqlCommand mycomm = new SqlCommand(SQLstr, defaultconn);

    //        for (int i = 0; i < length; i++)
    //        {
    //            mycomm.Parameters.Add(new SqlParameter("@" + DBPropertys[i], sqlTypes[i]));
    //            mycomm.Parameters["@" + DBPropertys[i]].Value = contents[i];
    //        }

    //        mysda.SelectCommand = mycomm;

    //        mysda.Fill(myds);
    //    }
    //    catch
    //    {
    //        myds = null;
    //    }
    //    finally
    //    {
    //        defaultconn.Close();
    //        return myds;
    //    }


    //}
    //可以返回新建主键值（select）
    public int db_insert_exec(String SQLstr)
    {
        int temp_str = 0;
        defaultconn.Open();
        SqlCommand mycomm = new SqlCommand(SQLstr + ";select @@IDENTITY as 'identity'", defaultconn);
        temp_str = Convert.ToInt32(mycomm.ExecuteScalar());
        defaultconn.Close();
        return temp_str;
    }
    //查询数据库并返回一个DataSet表（select）
    public DataSet return_datagrid(String tempsql)
    {
        SqlDataAdapter mysda = new SqlDataAdapter(tempsql, defaultconn);
        DataSet myds = new DataSet();
        mysda.Fill(myds);
        return myds;
    }

    #endregion

    #region 数据绑定
    //用DataSet绑定datagrid控件（不常用）
    public void return_datagrid(String tempsql, DataGrid temp_dg)
    {
        SqlDataAdapter mysda = new SqlDataAdapter(tempsql, defaultconn);
        DataSet myds = new DataSet();
        mysda.Fill(myds);
        temp_dg.DataSource = myds;
        temp_dg.DataBind();
    }
    //用DataSet绑定GridView控件（常用）
    public void return_gridview(String tempsql, GridView tempdv)
    {
        SqlDataAdapter mysda = new SqlDataAdapter(tempsql, defaultconn);
        DataSet myds = new DataSet();
        mysda.Fill(myds);
        tempdv.DataSource = myds;
        tempdv.DataBind();
    }
    //用DataSet绑定GridView控件，这个可以绑定主键（我每次用这个）
    public void Bind_GridView(String tempsql, GridView tempdv, string temp, string tbName)
    {
        SqlDataAdapter mysda = new SqlDataAdapter(tempsql, defaultconn);
        DataSet myds = new DataSet();
        mysda.Fill(myds);
        tempdv.DataSource = myds;
        tempdv.DataKeyNames = new string[] { temp };//主键
        tempdv.DataBind();
    }
    //这个我从来没用过。。。。
    public void return_gridview(String tempsql, GridView tempgv, String[] keyword, String SortSTR)
    {
        SqlDataAdapter mysda = new SqlDataAdapter(tempsql, defaultconn);
        DataSet myds = new DataSet();
        mysda.Fill(myds);
        DataView view = myds.Tables[0].DefaultView;
        view.Sort = SortSTR;
        tempgv.DataSource = view;
        tempgv.DataKeyNames = keyword;
        tempgv.DataBind();
    }
    //绑定下拉列表
    public void default_bind_dropdownlis(DropDownList dd_name, String strSQL, String text_str, String value_str)
    {
        DataSet zy_ds = new DataSet("zy_ds");
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, defaultconn);
        zy_sda.Fill(zy_ds);
        dd_name.DataSource = zy_ds;
        dd_name.DataTextField = text_str;
        dd_name.DataValueField = value_str;
        dd_name.DataBind();
    }
    //绑定下拉列表，并在下拉菜单中添加一个“全部”选项
    public void bind_dropdownlis_all(DropDownList dd_name, String strSQL, String text_str, String value_str)
    {
        DataSet zy_ds = new DataSet("zy_ds");
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, defaultconn);
        zy_sda.Fill(zy_ds);
        dd_name.DataSource = zy_ds;
        dd_name.DataTextField = text_str;
        dd_name.DataValueField = value_str;
        dd_name.DataBind();

        ListItem myddlist = new ListItem();
        myddlist.Text = "全部";
        myddlist.Value = "0";
        dd_name.Items.Insert(0, myddlist);
        // dd_name.Items.Add(myddlist);
        if (dd_name.Items.Count > 1) dd_name.SelectedIndex = 1;
    }
    //绑定下拉列表，并在下拉菜单中添加一个“无”选项
    public void bind_dropdownlis_none(DropDownList dd_name, String strSQL, String text_str, String value_str)
    {
        DataSet zy_ds = new DataSet("zy_ds");
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, defaultconn);
        zy_sda.Fill(zy_ds);
        dd_name.DataSource = zy_ds;
        dd_name.DataTextField = text_str;
        dd_name.DataValueField = value_str;
        dd_name.DataBind();

        ListItem myddlist = new ListItem();
        myddlist.Text = "无";
        myddlist.Value = "0";
        dd_name.Items.Insert(0, myddlist);
        // dd_name.Items.Add(myddlist);
        if (dd_name.Items.Count > 1) dd_name.SelectedIndex = 1;
    }
    //绑定CheckBoxList列表
    public void default_bind_CheckBox(CheckBoxList cb_name, String strSQL, String text_str, String value_str)
    {
        DataSet zy_ds = new DataSet("zy_ds");
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, defaultconn);
        zy_sda.Fill(zy_ds);
        cb_name.DataSource = zy_ds;
        cb_name.DataTextField = text_str;
        cb_name.DataValueField = value_str;
        cb_name.DataBind();
    }
    #endregion

    #region 比较高级的类，等过段时间有一定能力了再看，现在也用不上
    public void table_dis(Panel P_tb, String select_str, String website, String img, int k, String width)
    {
        P_tb.Controls.Clear();

        HtmlTable mytb = new HtmlTable();

        mytb.Border = 0;
        mytb.CellPadding = 0;
        mytb.CellSpacing = 0;
        mytb.Width = "100%";

        defaultconn.Open();
        SqlCommand mycommand = new SqlCommand(select_str, defaultconn);
        SqlDataReader myreader = mycommand.ExecuteReader();

        while (myreader.Read())
        {
            HtmlTableRow mytbr = new HtmlTableRow();
            HtmlTableCell mytbc = new HtmlTableCell();
            HtmlTableCell mytbc_pic = new HtmlTableCell();
            HtmlTableCell mytbc_date = new HtmlTableCell();

            mytbc_pic.InnerHtml = img;
            mytbc_date.Width = "12%";
            mytbr.Cells.Add(mytbc_pic);

            String nr = "  ";
            String id = myreader[0].ToString();
            if (myreader[1].ToString().Length > k)
            {
                nr += myreader[1].ToString().Substring(0, k) + "......";
            }
            else
            {
                nr = myreader[1].ToString();
            }
            mytbc.InnerHtml = "<a href='" + website + "?SendId=" + id + "'>" + nr + "</a>";
            mytbc.Align = "Left";
            mytbr.Cells.Add(mytbc);

            mytbc_date.InnerHtml = Convert.ToDateTime(myreader[2].ToString()).ToString("yyyy-MM-dd");
            mytbc_date.Width = "30%";
            mytbr.Cells.Add(mytbc_date);

            mytb.Rows.Add(mytbr);

        }
        myreader.Close();
        defaultconn.Close();
        P_tb.Controls.Add(mytb);
    }
    //用于文件下载
    public void table_dis(Panel P_tb, String select_str, String img, int k, String width)
    {
        P_tb.Controls.Clear();

        HtmlTable mytb = new HtmlTable();

        mytb.Border = 0;
        mytb.CellPadding = 0;
        mytb.CellSpacing = 0;
        mytb.Width = "100%";

        defaultconn.Open();
        SqlCommand mycommand = new SqlCommand(select_str, defaultconn);
        SqlDataReader myreader = mycommand.ExecuteReader();

        while (myreader.Read())
        {
            HtmlTableRow mytbr = new HtmlTableRow();
            HtmlTableCell mytbc = new HtmlTableCell();
            HtmlTableCell mytbc_pic = new HtmlTableCell();
            HtmlTableCell mytbc_date = new HtmlTableCell();

            mytbc_pic.InnerHtml = img;
            mytbc_date.Width = "12%";
            mytbr.Cells.Add(mytbc_pic);

            String nr = "  ";
            String id = myreader[0].ToString();
            if (myreader[1].ToString().Length > k)
            {
                nr += myreader[1].ToString().Substring(0, k) + "......";
            }
            else
            {
                nr = myreader[1].ToString();
            }
            mytbc.InnerHtml = "<a href='" + id + "'>" + nr + "</a>";
            mytbc.Align = "Left";
            mytbr.Cells.Add(mytbc);

            mytbc_date.InnerHtml = Convert.ToDateTime(myreader[2].ToString()).ToString("yyyy-MM-dd");
            mytbc_date.Width = "30%";
            mytbr.Cells.Add(mytbc_date);

            mytb.Rows.Add(mytbr);

        }
        myreader.Close();
        defaultconn.Close();
        P_tb.Controls.Add(mytb);
    }
    #endregion

    #region 打开数据库连接
    /// <summary>
    ///打开数据库连接
    /// </summary>
    private void Open()
    {
        if (con == null)
        {
            con = defaultconn;
        }
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
    }
    #endregion

    #region 关闭数据库连接
    /// <summary>
    ///关闭数据库连接
    /// </summary>
    public void Close()
    {
        if (con != null)
            con.Close();
    }
    #endregion

    #region 释放数据库链接资源
    /// <summary>
    ///释放数据库链接资源
    /// </summary>
    public void Dispose()
    {
        if (con != null)
        {
            con.Dispose();
            con = null;
        }
    }
    #endregion

    #region 传入参数并且转化成SqlParameter类型,MakeInParam方法用于传入参数，MakeParam方法用于转换参数
    ///<summary>传入参数</summary>
    /// <param name="ParamName">存储过程名称或命令文本</param>
    /// <param name="DbType">参数类型</param>
    /// <param name="Size">参数大小</param>
    /// <param name="Value">参数值</param>
    /// <returns>新的Parameter对象</returns>
    public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
    {
        return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
    }
    ///<summary>初始化参数</summary>
    /// <param name="ParamName">存储过程名称或命令文本</param>
    /// <param name="DbType">参数类型</param>
    /// <param name="Size">参数大小</param>
    /// <param name="Value">参数值</param>
    /// <returns>新的Parameter对象</returns>
    public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
    {
        SqlParameter param;
        if (Size > 0)
            param = new SqlParameter(ParamName, DbType, Size);
        else
            param = new SqlParameter(ParamName, DbType);
        param.Direction = Direction;
        if (!(Direction == ParameterDirection.Output && Value == null))
            param.Value = Value;
        return param;
    }
    #endregion

    #region 执行参数命令文本（数据库中无返回数据）执行添加，修改，删除
    /// <summary>
    /// 执行命令
    /// </summary>
    /// <param name="procName">命令文本</param>
    /// <param name="prams">参数对象</param>
    /// <returns></returns>
    public int RunProc(string procName, SqlParameter[] prams)
    {
        SqlCommand cmd = CreateCommand(procName, prams);
        cmd.ExecuteNonQuery();
        this.Close();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }
    /// <summary>
    /// 直接执行SQL语句
    /// </summary>
    /// <param name="procName">命令文本</param>
    /// <returns></returns>
    public int RunProc(string procName)
    {
        this.Open();
        SqlCommand cmd = new SqlCommand(procName, con);
        cmd.ExecuteNonQuery();
        this.Close();
        return 1;
    }
    #endregion

    #region 执行参数命令文本（有返回值）执行查询命令文本
    /// <summary>
    /// 执行查询命令文本，并且返回DataSet数据集
    /// </summary>
    /// <param name="procName">命令文本</param>
    /// <param name="prams">参数对象</param>
    /// <param name="tbName">数据表名称</param>
    /// <returns>DataSet</returns>
    public DataSet RunProcReturn(string procName, SqlParameter[] prams, string tbName)
    {
        SqlDataAdapter dap = CreateDataAdaper(procName, prams);
        DataSet ds = new DataSet();
        dap.Fill(ds, tbName);
        this.Close();
        return ds;
    }
    /// <summary>
    /// 执行命令文本，并且返回DataSet数据集
    /// </summary>
    /// <param name="procName">命令文本</param>
    /// <param name="tbName">数据表名称</param>
    /// <returns>DataSet</returns>
    public DataSet RunProcRetrun(string procName, string tbName)
    {
        SqlDataAdapter dap = CreateDataAdaper(procName, null);
        DataSet ds = new DataSet();
        dap.Fill(ds, tbName);
        this.Close();
        return ds;
    }
    #endregion

    #region 将命令文本添加到SqlDataAdapter
    /// <summary>
    /// 创建一个SqlDataAdapter对象以此来执行命令文本
    /// </summary>
    /// <param name="procName">命令文本</param>
    /// <param name="prams">参数对象</param>
    /// <returns></returns>
    private SqlDataAdapter CreateDataAdaper(string procName, SqlParameter[] prams)
    {
        this.Open();
        SqlDataAdapter dap = new SqlDataAdapter(procName, con);
        dap.SelectCommand.CommandType = CommandType.Text;
        if (prams != null)
        {
            foreach (SqlParameter parameter in prams)
                dap.SelectCommand.Parameters.Add(parameter);
        }
        dap.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
        return dap;
    }
    #endregion

    #region 创建一个SqlCommand对象以此来执行命令文本
    /// <summary>
    /// 创建一个SqlCommand对象以此来执行命令文本
    /// </summary>
    /// <param name="procName">命令文本</param>
    /// <param name="prams"命令文本所需参数</param>
    /// <returns>返回SqlCommand对象</returns>
    private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
    {
        this.Open();
        SqlCommand cmd = new SqlCommand(procName, con);
        cmd.CommandType = CommandType.Text;
        if (prams != null)
        {
            foreach (SqlParameter parameter in prams)
                cmd.Parameters.Add(parameter);
        }
        cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
        return cmd;
    }
    #endregion


    public string[] sqlinsert(string sqltr, object[] values)
    {
        string[] errinfo = new string[2];
        sqltr += "values(";
        for (int i = 1; i < values.Length; i++)
            sqltr += ("@value_" + i.ToString() + ",");
        sqltr += ("@value_" + values.Length.ToString() + ")");
        try
        {
            defaultconn.Open();
            SqlCommand mycomm = new SqlCommand(sqltr + ";select @@IDENTITY as 'result'", defaultconn);
            for (int k = 1; k <= values.Length; k++)
                mycomm.Parameters.AddWithValue("@value_" + k.ToString(), values[k - 1]);
            errinfo[1] = mycomm.ExecuteScalar().ToString();
            errinfo[0] = "1";
        }
        catch (Exception err) { errinfo[0] = err.Message.ToString(); }
        defaultconn.Close();
        return errinfo;
    }

}