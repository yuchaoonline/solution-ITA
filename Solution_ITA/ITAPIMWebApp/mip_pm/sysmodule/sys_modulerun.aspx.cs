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
using PageBaseFun;

public partial class mip_pm_sys_modulerun : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        string sql_str = "select * from sys_modulerun";
        DataSet ds = PageDBHelper.GetDataSetBySql(sql_str);
        this.dwgridview_sys_modulerun.DataSource = ds.Tables[0];
        this.dwgridview_sys_modulerun.DataBind();
    }

    protected string GetTimeOverInfo(string p_id)
    {
        string sql_str = "select * from sys_modulerun where id=" + p_id;
        DataSet ds = PageDBHelper.GetDataSetBySql(sql_str);
        string p_lastruntime_str = ds.Tables[0].Rows[0]["lastruntime"].ToString();
        int    p_runtimespan = int.Parse(ds.Tables[0].Rows[0]["runtimespan"].ToString());
        DateTime p_lastruntime = DateTime.Parse(p_lastruntime_str);
        TimeSpan p_tmspan = DateTime.Now - p_lastruntime;
        int p_tmspan_int =Convert.ToInt32(p_tmspan.TotalMinutes);
        if (p_tmspan_int > p_runtimespan)
        {
            int p_overtime = p_tmspan_int - p_runtimespan;
            return "超时" + p_overtime.ToString() + "分钟";
        }//
        else
            return "运行正常！";
    }
}
