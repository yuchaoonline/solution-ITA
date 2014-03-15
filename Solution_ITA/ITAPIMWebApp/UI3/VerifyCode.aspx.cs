using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class VerifyCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Session["VerifyCode"] = MakeValidateCode();
        CreateImage(Session["VerifyCode"].ToString());
    }
    private void CreateImage(string checkCode)
    {
        int iwidth = (int)(checkCode.Length * 12) + 10;
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 21);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);
        //定义颜色
        Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
        //定义字体
        string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
        Random rand = new Random();
        //随机输出噪点
        for (int i = 0; i < 5; i++)
        {
            int x = rand.Next(image.Width);
            int y = rand.Next(image.Height);
            g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
        }

        //输出不同字体和颜色的验证码字符
        for (int i = 0; i < checkCode.Length; i++)
        {
            int cindex = rand.Next(7);
            int findex = rand.Next(5);

            Font f = new System.Drawing.Font("宋体", 12, System.Drawing.FontStyle.Regular);
            Brush b = new System.Drawing.SolidBrush(c[cindex]);
            int ii = 4;
            if ((i + 1) % 2 == 0)
            {
                ii = 2;
            }
            g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
        }
        //画一个边框
        g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

        //输出到浏览器
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        Response.ClearContent();
        Response.ContentType = "image/Jpeg";
        Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }


    private string MakeValidateCode()
    {
        //0 i o
        char[] s = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string num = "";
        Random r = new Random();
        for (int i = 0; i < 4; i++)
        {
            num += s[r.Next(0, s.Length - 1)].ToString();
        }
        return num;
    }

}
