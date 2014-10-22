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
using System.Data.SqlClient;
using System.Text;
public partial class ajax_AutoCompleteData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string key = Request.QueryString["q"];
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db_lecture"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        string sql = "select userName from tb_user where userName like'%" + key + "%'";
        SqlCommand command = connection.CreateCommand();
        command.CommandText = sql;
        connection.Open();
        StringBuilder items = new StringBuilder();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                items.Append(reader.GetString(0) + "\n");
            }
        }
        Response.Write(items.ToString());
        Response.End();
    }
}
