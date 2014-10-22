<%@ WebHandler Language="C#" Class="ValidCode" %>

using System;
using System.Web;
using System.Text;
using System.Drawing;

public class ValidCode : IHttpHandler ,System.Web.SessionState.IRequiresSessionState{            //这是一个接口，有绘画访问权限。。。不明白啥意思。。
    
    public void ProcessRequest (HttpContext context) {
        string strValidCode = GetValidCode(5);                                                  // 产生5位随机字符
        context.Session["ValidCode"] = strValidCode;                                            //将字符串保存到Session中，以便需要时进行验证
        Bitmap image = new Bitmap(120, 30);                                                     //定义宽120像素，高30像素的数据定义的图像对象
        Graphics g = Graphics.FromImage(image);                                                 //绘制图片
        try
        {

            Random random = new Random();                                                       //生成随机对象
            g.Clear(Color.White);                                                               //清除图片背景色
            for (int i = 0; i < 25; i++)                                                        // 随机产生图片的背景噪线
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("新宋体", 20, (System.Drawing.FontStyle.Bold));  //设置图片字体风格
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 3, true);//设置画笔类型
            g.DrawString(strValidCode, font, brush, 5, 2);                                      //绘制随机字符


            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);    //绘制图片的前景噪点
            System.IO.MemoryStream ms = new System.IO.MemoryStream();                           //建立存储区为内存的流
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);                                                    //将图像对象储存为内存流
            context.Response.ClearContent();                                                    //清除当前缓冲区流中的所有内容
            context.Response.ContentType = "image/Gif";                                         //设置输出流的MIME类型
            context.Response.BinaryWrite(ms.ToArray());                                         //将内存流写入到输出流
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private string GetValidCode(int num)
    {

        string strRandomCode = "ABCD1EF2GH3IJ4KL5MN6P7QR8ST9UVWXYZ";                                //定义要随机抽取的字符串
        char[] chastr = strRandomCode.ToCharArray();                                                //将定义的字符串转成字符数组
        StringBuilder sbValidCode = new StringBuilder();                                            //定义StringBuilder对象用于存放验证码
        Random rd = new Random();                                                                   //随机函数，随机抽取字符
        for (int i = 0; i < num; i++)
        {
            //以strRandomCode的长度产生随机位置并截取该位置的字符添加到StringBuilder对象中
            sbValidCode.Append(strRandomCode.Substring(rd.Next(0, strRandomCode.Length), 1));
        }
        return sbValidCode.ToString();

    }

}