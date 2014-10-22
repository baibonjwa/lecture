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
using System.Text;

/// <summary>
///Find_Messages 浮动式提示框
/// </summary>
public class Find_Messages
{
    public Find_Messages()
    { }
    /// <summary>
    /// 处理过程完成
    /// </summary>
    /// <param name="pageMsg">页面提示信息</param>
    /// <param name="go2Url">如果倒退步数为0，就转到该地址</param>
    /// <param name="BackStep">倒退步数</param>
    public void FinalMessage(string pageMsg, string go2Url, int BackStep)
    {
        FinalMessage(pageMsg, go2Url, BackStep, 2);
    }
    /// <summary>
    /// 处理过程完成
    /// </summary>
    /// <param name="pageMsg">页面提示信息</param>
    /// <param name="go2Url">如果倒退步数为0，就转到该地址</param>
    /// <param name="BackStep">倒退步数</param>
    /// <param name="BackStep">自动转向的秒数</param>
    public void FinalMessage(string pageMsg, string go2Url, int BackStep, int Seconds)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>\r\n");
        sb.Append("<html xmlns='http://www.w3.org/1999/xhtml'>\r\n");
        sb.Append("<head>\r\n");
        sb.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />\r\n");
        sb.Append("<head>\r\n");
        sb.Append("<title>系统提示</title>\r\n");
        sb.Append("<style>\r\n");
        sb.Append("body {padding:0; margin:0; }\r\n");
        sb.Append("#infoBox{padding:0; margin:0; position:absolute; top:40%; width:100%; text-align:center;}\r\n");
        sb.Append("#info{padding:0; margin:0;position:relative; top:-40%; right:0; border:0px #B4E0F7 solid; text-align:center;}\r\n");
        sb.Append("</style>\r\n");
        sb.Append("<script language=\"javascript\">\r\n");
        sb.Append("var seconds=" + Seconds + ";\r\n");
        sb.Append("for(i=1;i<=seconds;i++)\r\n");
        sb.Append("{window.setTimeout(\"update(\" + i + \")\", i * 1000);}\r\n");
        sb.Append("function update(num)\r\n");
        sb.Append("{\r\n");
        sb.Append("if(num == seconds)\r\n");
        if (BackStep > 0)
            sb.Append("{ history.go(" + (0 - BackStep) + "); }\r\n");
        else
        {
            if (go2Url != "")
                sb.Append("{ self.location.href='" + go2Url + "'; }\r\n");
            else
                sb.Append("{window.close();}\r\n");
        }
        sb.Append("else\r\n");
        sb.Append("{ }\r\n");
        sb.Append("}\r\n");
        sb.Append("</script>\r\n");
        sb.Append("<base target='_self' />\r\n");
        sb.Append("</head>\r\n");
        sb.Append("<body>\r\n");
        sb.Append("<div id='infoBox'>\r\n");
        sb.Append("<div id='info'>\r\n");
        sb.Append("<div style='text-align:center;margin:0 auto;width:320px;padding-top:4px;line-height:26px;height:26px;font-weight:bold;color:#2259A6;font-size:14px;border:1px #B4E0F7 solid;background:#CAEAFF;'>提示信息</div>\r\n");
        sb.Append("<div style='text-align:center;padding:20px 0 20px 0;margin:0 auto;width:320px;font-size:12px;background:#F5FBFF;border-right:1px #B4E0F7 solid;border-bottom:1px #B4E0F7 solid;border-left:1px #B4E0F7 solid;'>\r\n");
        sb.Append(pageMsg + "<br /><br />\r\n");
        if (BackStep > 0)
            sb.Append("        <a href=\"javascript:history.go(" + (0 - BackStep) + ")\">如果您的浏览器没有自动跳转，请点击这里</a>\r\n");
        else
            sb.Append("        <a href=\"" + go2Url + "\">如果您的浏览器没有自动跳转，请点击这里</a>\r\n");
        sb.Append("    </div>\r\n");
        sb.Append("</div>\r\n");
        sb.Append("</div>\r\n");
        sb.Append("</body>\r\n");
        sb.Append("</html>\r\n");
        HttpContext.Current.Response.Write(sb.ToString());
        //以下这行千万别手痒痒删掉
        HttpContext.Current.Response.End();
    }

    public void FinalMessage2(string pageMsg, string go2Url, int BackStep, int Seconds)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>\r\n");
        sb.Append("<html xmlns='http://www.w3.org/1999/xhtml'>\r\n");
        sb.Append("<head>\r\n");
        sb.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />\r\n");
        sb.Append("<head>\r\n");
        sb.Append("<title>系统提示</title>\r\n");
        sb.Append("<style>\r\n");
        sb.Append("body {padding:0; margin:0; }\r\n");
        sb.Append("#infoBox{padding:0; margin:0; position:absolute; top:40%; width:100%; text-align:center;}\r\n");
        sb.Append("#info{padding:0; margin:0;position:relative; top:-40%; right:0; border:0px #B4E0F7 solid; text-align:center;}\r\n");
        sb.Append("</style>\r\n");
        sb.Append("<script language=\"javascript\">\r\n");
        sb.Append("var seconds=" + Seconds + ";\r\n");
        sb.Append("for(i=1;i<=seconds;i++)\r\n");
        sb.Append("{window.setTimeout(\"update(\" + i + \")\", i * 1000);}\r\n");
        sb.Append("function update(num)\r\n");
        sb.Append("{\r\n");
        sb.Append("if(num == seconds)\r\n");
        if (BackStep > 0)
            sb.Append("{ history.go(" + (0 - BackStep) + "); }\r\n");
        else
        {
            if (go2Url != "")
                sb.Append("{ self.parent.location.href='" + go2Url + "'; }\r\n");
            else
                sb.Append("{window.close();}\r\n");
        }
        sb.Append("else\r\n");
        sb.Append("{ }\r\n");
        sb.Append("}\r\n");
        sb.Append("</script>\r\n");
        sb.Append("<base target='_self' />\r\n");
        sb.Append("</head>\r\n");
        sb.Append("<body>\r\n");
        sb.Append("<div id='infoBox'>\r\n");
        sb.Append("<div id='info'>\r\n");
        sb.Append("<div style='text-align:center;margin:0 auto;width:320px;padding-top:4px;line-height:26px;height:26px;font-weight:bold;color:#2259A6;font-size:14px;border:1px #B4E0F7 solid;background:#CAEAFF;'>提示信息</div>\r\n");
        sb.Append("<div style='text-align:center;padding:20px 0 20px 0;margin:0 auto;width:320px;font-size:12px;background:#F5FBFF;border-right:1px #B4E0F7 solid;border-bottom:1px #B4E0F7 solid;border-left:1px #B4E0F7 solid;'>\r\n");
        sb.Append(pageMsg + "<br /><br />\r\n");
        if (BackStep > 0)
            sb.Append("        <a href=\"javascript:history.go(" + (0 - BackStep) + ")\">如果您的浏览器没有自动跳转，请点击这里</a>\r\n");
        else
            sb.Append("        <a href=\"" + go2Url + "\">如果您的浏览器没有自动跳转，请点击这里</a>\r\n");
        sb.Append("    </div>\r\n");
        sb.Append("</div>\r\n");
        sb.Append("</div>\r\n");
        sb.Append("</body>\r\n");
        sb.Append("</html>\r\n");
        HttpContext.Current.Response.Write(sb.ToString());
        //以下这行千万别手痒痒删掉
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// 生成随机数字字符串
    /// </summary>
    /// <param name="int_NumberLength">数字长度</param>
    /// <returns></returns>
    public string GetRandomNumberString(int int_NumberLength)
    {
        return GetRandomNumberString(int_NumberLength, false);
    }
    /// <summary>
    /// 生成随机数字字符串
    /// </summary>
    /// <param name="int_NumberLength">数字长度</param>
    /// <returns></returns>
    public string GetRandomNumberString(int int_NumberLength, bool onlyNumber)
    {
        Random random = new Random();
        return GetRandomNumberString(int_NumberLength, onlyNumber, random);
    }
    /// <summary>
    /// 生成随机数字字符串
    /// </summary>
    /// <param name="int_NumberLength">数字长度</param>
    /// <returns></returns>
    public string GetRandomNumberString(int int_NumberLength, bool onlyNumber, Random random)
    {
        string strings = "123456789";
        if (!onlyNumber) strings += "abcdefghjkmnpqrstuvwxyz";
        char[] chars = strings.ToCharArray();
        string returnCode = string.Empty;
        for (int i = 0; i < int_NumberLength; i++)
            returnCode += chars[random.Next(0, chars.Length)].ToString();
        return returnCode;
    }


}



