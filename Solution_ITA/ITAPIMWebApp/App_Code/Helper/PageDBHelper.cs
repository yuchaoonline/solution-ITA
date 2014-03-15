using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace PageBaseFun
{
    /// <summary>
    /// PageDBHelper 的摘要说明
    /// </summary>
    public class PageDBHelper
    {
        public PageDBHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        public static DataSet GetDataSetBySql(string p_sql)
        {
            return DBUtility.DbHelperOra.Query(p_sql);
        }

        public static object GetSingleBySql(string p_sql)
        {
            return DBUtility.DbHelperOra.GetSingle(p_sql);
        }

        public static int ExecuteSql(string p_sql)
        {
            return DBUtility.DbHelperOra.ExecuteSql(p_sql);
        }

        public static int ExecuteSqlTran(ArrayList p_sqllist)
        {
            return DBUtility.DbHelperOra.ExecuteSqlTran(p_sqllist);
        }

    }


}
