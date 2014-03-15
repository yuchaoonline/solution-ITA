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

public partial class rightmanage_UserInfo : CePage
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
        string userid = this._GetNowUserID();
        //this.LB_USERNAME.Text = userid;
        if (userid !="")
        {
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        Mis.Model.ptgl.SYS_USERS obj = handle.GetModel(int.Parse(userid));

        //this.LB_DESCRIPE.Text = obj.DESCRIPE + "&nbsp;";
        //this.LB_FIXEDPHONE.Text = obj.FIXEDPHONE + "&nbsp;";
        this.LB_JOBNUM.Text = obj.USERNO + "&nbsp;";


       // this.LB_MOBILEPHONE.Text = obj.MOBILEPHONE + "&nbsp;";
        this.LB_REALNAME.Text = obj.USERREALNAME + "&nbsp;";
        this.LB_USERNAME.Text = obj.USERNAME + "&nbsp;";

        //BindDwData(obj.WORKAREAID, obj.DEPARTID, obj.TEAMID);
        }

    }



    ////绑定三个下拉列表 单位－部门-班组
    //private void BindDwData(string select_workareaid, string select_departid, string select_teamid)
    //{

    //    OracleDataAccess oda = new OracleDataAccess();
    //    //把所有单位信息列出来
    //    string sqlStr = "select workareaid ,workarea  from cf_depart where departid is null and teamid is null and workareaid='"+
    //        select_workareaid + "' order by workareaid";
    //    DataSet ds = oda.GetDataSet(sqlStr, "workarea");
    //    DataTable dt = ds.Tables["workarea"];
    //    if (dt != null && dt.Rows.Count > 0)
    //    {
    //        this.LB_WORKAREAID.Text = dt.Rows[0]["workarea"].ToString() + "&nbsp;";
    //        //
    //    }
    //    else
    //    {
    //        this.LB_WORKAREAID.Text = "&nbsp;";
    //    }

    //    //把所有的部门信息列出来
    //    sqlStr = "select  distinct departid ,depart from cf_depart where departid is not null and workareaid='" + select_workareaid + "' and departid='"
    //    + select_departid  + "'";
    //    ds = oda.GetDataSet(sqlStr, "depart");
    //    dt = ds.Tables["depart"];
    //    if (dt != null && dt.Rows.Count > 0)
    //    {
    //        this.LB_DEPARTID.Text = dt.Rows[0]["depart"].ToString() + "&nbsp;";
    //    }
    //    else
    //    {
    //        this.LB_DEPARTID.Text = "&nbsp;";
    //    }
    //    //把部门中所有班组列出来
    //    sqlStr = "select workareaid ,workarea  ,departid ,depart ,teamid ,team  "
    //                + "from cf_depart where departid is not null and teamid is not null and workareaid='"
    //                + select_workareaid
    //                + "' and departid='"
    //                + select_departid
    //                + "' and teamid='"
    //                + select_teamid + "' order by workareaid,departid,teamid";

    //    ds = oda.GetDataSet(sqlStr, "team");
    //    dt = ds.Tables["team"];
    //    if (dt != null && dt.Rows.Count > 0)
    //    {
    //        this.LB_TEAMID.Text = dt.Rows[0]["team"].ToString() + "&nbsp;";
    //    }
    //    else
    //    {
    //        this.LB_TEAMID.Text = "&nbsp;";
    //    }
    //}


 

}
