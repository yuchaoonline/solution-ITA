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

public partial class sys_moudleaction_subclassview : CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this._isallowaccess("", "6", "");
        if (!IsPostBack)
        {

            bindgridview();


        }

    }

    private bool IsofAdd_Action;
    private bool IsofDelete_Action;
    private bool IsofUpdate_Action;


    /*
        Actionmng.data.delete	动作删除数据控制点
        Actionmng.data.detail	动作详细数据控制点
        Actionmng.data.show	动作查看数据控制点
        Actionmng.data.update	动作更行数据控制点
        Actionmng.action.delete	动作删除按钮
        Actionmng.action.update	动作更新按钮
        Actionmng.action.detail	动作详细按钮
        Actionmng.action.add	动作添加按钮

     */

    private void GetPermission()
    {
        IsofAdd_Action = _IsAuthorizedInaction("Actionmng.action.update");
        this.Imbtn_add.Enabled = IsofAdd_Action;
        IsofDelete_Action = _IsAuthorizedInaction("Actionmng.action.update");
        IsofUpdate_Action = _IsAuthorizedInaction("Actionmng.action.update");
        
    }

    private void bindgridview()
    {
        string parentid = this.Context.Request["parentid"].Trim();
        Mis.BLL.ptgl.SYS_MOUDLEACTION handle = new Mis.BLL.ptgl.SYS_MOUDLEACTION();
        Mis.Model.ptgl.SYS_MOUDLEACTION obj = new Mis.Model.ptgl.SYS_MOUDLEACTION();
        DataSet dts = handle.GetList("  moudlename ='" + parentid + "'");



        this.GridView1.DataSource = dts;
        GridView1.DataBind();


    }

    protected void btn_delete_Command(object sender, CommandEventArgs e)
    {
        //操作权限管理
        GetPermission();
        if (IsofDelete_Action == false)
        {
            JS.Alert("无权限删除数据！", this);
            return;
        }
        string id = e.CommandArgument.ToString();
        Mis.BLL.ptgl.SYS_MOUDLEACTION handle = new Mis.BLL.ptgl.SYS_MOUDLEACTION();
        if (0 < handle.Delete(int.Parse(id)))
        {
            bindgridview();
            JS.Alert("删除成功！", this);
            
        }
        else
            JS.Alert("删除失败！", this);
    }

    protected void btn_update_Command(object sender, CommandEventArgs e)
    {
        string parentid = this.Context.Request["parentid"].Trim();
        string id = e.CommandArgument.ToString();

        //操作权限管理
        GetPermission();
        if (IsofUpdate_Action == false)
        {
            JS.Alert("无权限修改数据！", this);
            return;
        }

        Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"editsub.aspx?id=" + id + "&parentid=" + parentid + "&action=edit\";</script>");

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgridview();
    }
    protected void Imbtn_add_Click(object sender, ImageClickEventArgs e)
    {
        string parentid = this.Context.Request["parentid"].Trim();
        Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"addsub.aspx?parentid=" + parentid + "\";</script>");

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ImageButton btn_update = (ImageButton)e.Row.FindControl("btn_update");

        // btn_update.ToolTip = handle_resmanage.GetString("80");//修改信息标准分类信息
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor = '#d5f4fe'");
            //添加自定义属性，当鼠标移走时还原该行的背景色  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            e.Row.Attributes["style"] = "Cursor:hand";
        }

    }

    protected string GetMOUDLENAME(string p_moudlenameid)
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        Djdw.Model.Post.SYS_MENU model = handle.GetModel(int.Parse(p_moudlenameid));
        return model.MOUDLENAME;
    }

    protected string GetISOFDATAFILTER(string p_isofdatafilter)
    {
        if (p_isofdatafilter == "") return "";
        else
        {
            Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
            //是否筛选数据
            return dic.GetInfoNameByinfono("41", p_isofdatafilter);
        }
    }
}
