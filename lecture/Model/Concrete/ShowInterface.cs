using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

public class ShowInterface
{
    db_ctrl sampleDB = new db_ctrl();
    public string LeftMenu(int sectID)
    {
        string result = "";
        return result;
    }
    public void default_bind_dropdownlis(DropDownList dd_name, String strSQL, String text_str, String value_str)
    {
        DataSet zy_ds = new DataSet("zy_ds");
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, sampleDB.con);
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
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, sampleDB.con);
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
        if (dd_name.Items.Count > 1) dd_name.SelectedIndex = 0;
    }
    public void bind_dropdownlis_none(DropDownList dd_name, String strSQL, String text_str, String value_str)
    {
        DataSet zy_ds = new DataSet("zy_ds");
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, sampleDB.con);
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
        if (dd_name.Items.Count > 1) dd_name.SelectedIndex = 0;
    }
    //绑定CheckList
    public void bind_checkList(CheckBoxList cbl, String strSQL, String text_str, String value_str)
    {
        DataSet zy_ds = new DataSet("zy_ds");
        SqlDataAdapter zy_sda = new SqlDataAdapter(strSQL, sampleDB.con);
        zy_sda.Fill(zy_ds);
        cbl.DataSource = zy_ds;
        cbl.DataTextField = text_str;
        cbl.DataValueField = value_str;
        cbl.DataBind();
    }
    public void addTip(Label lb, string str, System.Drawing.Color DrawClor)
    {
        lb.Text = str;
        lb.ForeColor = DrawClor;
    }
    public int SelectDD_Text(DropDownList dd, string Text)
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
    public int SelectDD_Value(DropDownList dd, string value)
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
    //DataList的绑定
    public void ShowDatalist(DataList dl, string sectName, int count)
    {
        string sectID = sampleDB.read_DB_return("select sectID from tb_section where sectName = '" + sectName + "'");
        string str = "select top " + count + " * from tb_contents where sectID = '" + sectID + "' order by conID desc";
        dl.DataSource = sampleDB.return_datagrid(str);
        dl.DataBind();
    }
    public void ShowRepeater(Repeater rep, string sectName, int count)
    {
        string sectID = sampleDB.read_DB_return("select sectID from tb_section where sectName = '" + sectName + "'");
        string str = "select top " + count + " * from tb_contents where sectID = '" + sectID + "' order by conID desc";
        rep.DataSource = sampleDB.return_datagrid(str);
        rep.DataBind();
    }
    public void ShowReapeater_Url(Repeater rep, int UrlType)
    {
        rep.DataSource = sampleDB.return_datagrid("SELECT UrlID, UrlName, Url, UrlType FROM tb_url where UrlType = '" + UrlType + "'");
        rep.DataBind();
    }
    //public void ShowDatalist_fire(DataList dl, int count)
    //{
    //    string str = "select top " + count + " * from tb_fire order by fid desc";
    //    FireInfo fireInfo = new FireInfo();
    //    dl.DataSource = fireInfo.SelectSect_dataset(str);
    //    dl.DataBind();
    //}
    //public void ShowDatalist_tel(DataList dl, int count)
    //{
    //    string str = "select top " + count + " * from tb_tel";
    //    TelInfo telInfo = new TelInfo();
    //    dl.DataSource = telInfo.SelectSect_dataset(str);
    //    dl.DataBind();
    //}
    ////返回路径
    public string return_path(int sectID)
    {
        string results = sampleDB.read_DB_return("select sectPath from tb_section where sectID='" + sectID + "'");
        return results;
    }
    //左侧树状菜单绑定
    #region 左侧树状菜单绑定
    public string TreeMenuBind(int sectID)
    {
        string results = "";
        DataSet ds = new DataSet();
        DataSet ds_all = new DataSet();
        ds_all = sampleDB.return_datagrid("select * from tb_section");
        ds = sampleDB.return_datagrid("select * from tb_section where sectparent='" + sectID + "'");
        DataRow[] dr = ds.Tables[0].Select();
        results = recursion(ds_all, dr, results, sectID);
        return results;
    }
    //递归
    private string recursion(DataSet ds, DataRow[] dr, string str, int sectID)
    {
        str += "<ul class=\"ddmenu2\">";
        if (dr.Length != 0)
        {
            for (int i = 0; i < dr.Length; i++)
            {
                if (dr[i][2].ToString() == sectID.ToString())
                {
                    str += "<li>";
                    //str += "<a href=\"javascript:Change('" + dr[i]["sectName"] + "');document.frames[0].location.replace('" + return_path(Convert.ToInt16(dr[i]["sectID"])) + "?sectID=" + dr[i]["sectID"] + "')\">" + dr[i]["sectName"] + "</a>";
                    str += "<a onclick=\"Change('" + dr[i]["sectName"] + "'); \" href=\"" + return_path(Convert.ToInt16(dr[i]["sectID"])) + "?sectID=" + dr[i]["sectID"] + "\">" + dr[i]["sectName"] + "</a>";
                    DataRow[] dr_new = ds.Tables[0].Select("sectParent='" + dr[i][0].ToString() + "'");
                    if (dr_new.Length != 0)
                        str = recursion(ds, dr_new, str, Convert.ToInt16(dr_new[0]["sectParent"]));
                    str += "</li>";
                }
            }
        }
        else
        {
            str += "<li>";
            //str += "<a href=\"javascript:document.frames[0].location.replace('" + return_path(sectID) + "?sectID=" + sectID + "')\">" + ds.Tables[0].Select("sectID='" + sectID + "'")[0]["sectName"] + " </a>";
            str += "<a href=\"" + return_path(sectID) + "?sectID=" + sectID + "\">" + ds.Tables[0].Select("sectID='" + sectID + "'")[0]["sectName"] + "</a>";
            str += "</li>";
        }
        str += "</ul>";
        return str;
    }
    #endregion

    //绑定首菜单
    #region 绑定首菜单
    public string BindMenu()
    {
        string results = "";
        DataSet ds = new DataSet();
        DataSet ds_all = new DataSet();
        ds_all = sampleDB.return_datagrid("select * from tb_section");
        ds = sampleDB.return_datagrid("select * from tb_section where sectParent=-1 and sectShow=1");
        DataRow[] dr = ds_all.Tables[0].Select();
        for (int i = 0; i < ds_all.Tables[0].Rows.Count; i++)
        {
            if (dr[i]["sectParent"].ToString() == "-1" && dr[i]["sectShow"].ToString() == "1")
            {
                results += "<li><em><a href=\"" + dr[i]["sectPath"] + "?sectID=" + dr[i]["sectID"] + "\">" + dr[i]["sectName"] + "</a></em>";
                if (ds_all.Tables[0].Select("sectParent='" + dr[i][0].ToString() + "'").Length != 0)
                    recursion_tree(ds_all, dr, ref results, Convert.ToInt16(dr[i]["sectID"]));
                results += "</li>";
            }
        }

        return results;
    }
    //递归
    string style = "header_drawer";
    private string recursion_tree(DataSet ds, DataRow[] dr, ref string str, int sectID)
    {
        str += "<div class=\"" + style + "\">";
        str += "<dl>";
        for (int i = 0; i < dr.Length; i++)
        {

            if (dr[i]["sectParent"].ToString() == sectID.ToString())
            {
                str += "<dd class=\"f\">";
                //str += "<a href=\"javascript:Change('" + dr[i]["sectName"] + "');document.frames[0].location.replace('" + return_path(Convert.ToInt16(dr[i]["sectID"])) + "?sectID=" + dr[i]["sectID"] + "')\">" + dr[i]["sectName"] + "</a>";
                str += "<a href=\"" + dr[i]["sectPath"] + "?sectID=" + dr[i]["sectID"] + "\">" + dr[i]["sectName"] + "</a>";
                DataRow[] dr_new = ds.Tables[0].Select("sectParent='" + dr[i][0].ToString() + "'");
                if (dr_new.Length != 0)
                {
                    style = "dd_" + style;
                    str = recursion_tree(ds, dr_new, ref str, Convert.ToInt16(dr_new[0]["sectParent"]));
                }
                str += "</dd>";
            }

        }
        ;
        str += "</dl>";
        str += "</div>";
        return str;
    }
    #endregion 绑定首菜单

    public String find_fixedpower(String tempPower, int position)
    {
        return tempPower.Substring(position - 1, 1);
        //"1000000000" 除第一位外，其它位按开发计划中的权限表设置
    }
    public string GetParent(string i)
    {
        return sampleDB.read_DB_return("select sectParent from tb_section where sectid='" + i + "'");
    }
    public string GetRoot(string i)
    {
        if ("-1" == GetParent(i))
        {
            return i;
        }
        else
        {
            return GetRoot(GetParent(i));
        }
    }
    public string[] firstSection(string i)
    {
        return sampleDB.read_DB_results("select * from tb_section where sectParent='" + i + "'", 7);
    }
    //判断级联下拉框的值
    public string return_moreDD(DropDownList dd1, DropDownList dd2, DropDownList dd3)
    {
        if (dd3.Visible == true && dd3.SelectedValue != "0")
            return dd3.SelectedValue;
        else if (dd2.Visible == true && dd2.SelectedValue != "0")
            return dd2.SelectedValue;
        else if (dd1.Visible == true)
            return dd1.SelectedValue;
        else
            return "无";
    }

    public DataTable DataRow2DataTable(DataRow[] dr)
    {
        DataTable dt = new DataTable();
        foreach (DataRow tempObjRow in dr)
        {
            dt.ImportRow(tempObjRow);
        }
        return dt;
    }
}
