using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace System.Web.UI
{
    /// <summary>
    /// JS 的摘要说明
    /// </summary>
    public class JS
    {

        private static Regex mobilephone = new Regex(@"^(13[0-9]|15[0-9]|18[0-9])\d{8}$");//手机号码
        //验证Email地址："^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"。
        private static Regex isEmail = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");//验证Email地址
        //^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$    浮点数

        public JS()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static void Alert(string msg, System.Web.UI.Page page)
        {
            string js = "<script>alert('" + msg + "');</script>";
            page.RegisterStartupScript("ALERT", js);
        }
        public static void ExeFun(string fun, System.Web.UI.Page page)
        {
            string js = "<script>" + fun + ";</script>";
            page.RegisterStartupScript("DEFFUN", js);
        }
        public static void ExeFun(string fun, string block, System.Web.UI.Page page)
        {
            string js = "<script>" + fun + ";</script>";
            page.RegisterStartupScript(block, js);
        }
        public static void PreAlert(string msg, System.Web.UI.Page page)
        {
            string js = "<script>alert('" + msg + "');</script>";
            page.Response.Write(js);
            page.Response.End();
        }




        public static bool isoftest(string content)
        {
            content = content.Substring(content.Length - 11);
            string s = @"^(13[0-9]|15[0|3|6|8|9])\d{8}$";

            return Regex.IsMatch(content, s);


        }

        /// <summary>
        /// 验证Email地址
        /// </summary>
        /// <returns></returns>
        public static bool isofEmail(string content)
        {
            Match m = isEmail.Match(content);
            return m.Success;

        }



        /// <summary>
        /// 是不是手机号码
        /// </summary>
        /// <returns></returns>
        public static bool isofmobilephone(string content)
        {
            content = content.Substring(content.Length - 11);
            Match m = mobilephone.Match(content);
            return m.Success;

        }

        /// <summary>
        /// 是不是全是数字
        /// </summary>
        /// <returns></returns>
        public static bool isofnumber(string content)
        {
            string ValidChars = "0123456789";
            char Char;
            string sText = content;
            char[] sChar = sText.ToCharArray(0, sText.Length);
            for (int i = 0; i < sText.Length; i++)
            {
                Char = sChar[i];
                if (ValidChars.IndexOf(Char) == -1)
                {
                    return false;
                }
            }
            try
            {
                int content_int = int.Parse(content);
                if (content.Length > 7) return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是不是double类型数字
        /// </summary>
        /// <returns></returns>
        public static bool isofdouble(string content)
        {
            string ValidChars = ".0123456789";
            char Char;
            string sText = content;
            char[] sChar = sText.ToCharArray(0, sText.Length);
            for (int i = 0; i < sText.Length; i++)
            {
                Char = sChar[i];
                if (ValidChars.IndexOf(Char) == -1)
                {
                    return false;
                }
            }
            if (content.IndexOf(".") != content.LastIndexOf("."))
            {
                return false;
            }
            try
            {
                double content_double = double.Parse(content);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }

}