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

public partial class mip_pm_SYS_MENUselect : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "5", "");
        if (!IsPostBack)
        {
            BindDwData();
            bindgridview();
            this.Dp_paging.SelectedValue = "10";
            ViewState["direction"] = "ASC";
            ViewState["sortexpression"] = "";
            IsofVisible();
        }
    }

    private bool IsofAdd_Action;
    private bool IsofDelete_Action;
    private bool IsofUpdate_Action;
    private bool IsofDetail_Action;

    /*
        Menumng.data.delete	菜单删除数据控制点
        Menumng.data.detail	菜单详细数据控制点
        Menumng.data.show	菜单查看数据控制点
        Menumng.data.update	菜单更新数据控制点
        Menumng.action.delete	菜单删除按钮
        Menumng.action.update	菜单更新按钮
        Menumng.action.detail	菜单详细按钮
        Menumng.action.add	菜单添加按钮

     */

    private void GetPermission()
    {
        //IsofAdd_Action = _IsAuthorizedInaction("Menumng.action.add");
        //IsofDelete_Action = _IsAuthorizedInaction("Menumng.action.delete");
        //IsofUpdate_Action = _IsAuthorizedInaction("Menumng.action.update");
        //IsofDetail_Action = _IsAuthorizedInaction("Menumng.action.detail");
        IsofAdd_Action = _IsAuthorizedInaction("Menumng.action.update");
        IsofDelete_Action = _IsAuthorizedInaction("Menumng.action.update");
        IsofUpdate_Action = _IsAuthorizedInaction("Menumng.action.update");
        IsofDetail_Action = _IsAuthorizedInaction("Menumng.action.detail");
 
    }

    /// <summary>
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        //下拉框 级别
        dic.BindToDropDownListInselect(this.DP_SYSLEVEL, "2");
        //下拉框 颁本
        dic.BindToDropDownListInselect(this.DP_VERSION, "1");
    }


    private void bindgridview()
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        Djdw.Model.Post.SYS_MENU obj = new Djdw.Model.Post.SYS_MENU();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dwgridview_SYS_MENU.DataSource = dt.DefaultView;
        dwgridview_SYS_MENU.DataBind();
        for (int i = 0; i <= dwgridview_SYS_MENU.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_SYS_MENU.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
            }
        }

    }

    /// <summary>
    /// 页面收集组织成查询条件
    /// </summary>
    /// <returns></returns>
    public string getstrwherefrompage()
    {
        string strwhere = "";

        if (TB_SYSNAME.Text.Trim() != "")//系统名称
        {
            strwhere += " and SYSNAME like '%" + TB_SYSNAME.Text.Trim() + "%' ";
        }
        if (TB_MOUDLENAME.Text.Trim() != "")//模块名称
        {
            strwhere += " and MOUDLENAME like '%" + TB_MOUDLENAME.Text.Trim() + "%' ";
        }
        if (int.Parse(DP_SYSLEVEL.SelectedValue) != 0)//级别
        {
            strwhere += " and SYSLEVEL  = " + int.Parse(DP_SYSLEVEL.SelectedValue);
        }
        if (TB_PARENT.Text.Trim() != "")//上一级别模块
        {
            strwhere += " and PARENT like '%" + TB_PARENT.Text.Trim() + "%' ";
        }
        if (TB_URL.Text.Trim() != "")//url
        {
            strwhere += " and URL like '%" + TB_URL.Text.Trim() + "%' ";
        }
        if (TB_DESCRIPTION.Text.Trim() != "")//描述
        {
            strwhere += " and DESCRIPTION like '%" + TB_DESCRIPTION.Text.Trim() + "%' ";
        }
        if (TB_IMG.Text.Trim() != "")//模块对应的图片url
        {
            strwhere += " and IMG like '%" + TB_IMG.Text.Trim() + "%' ";
        }
        if (int.Parse(DP_VERSION.SelectedValue) != 0)//颁本
        {
            strwhere += " and VERSION  = " + int.Parse(DP_VERSION.SelectedValue);
        }

        if (strwhere != "")
        {
            strwhere = strwhere.Substring(5);
        }
        return strwhere;
    }


    /// <summary>
    /// 控件是否可见
    /// </summary>
    protected void IsofVisible()
    {
        LB_SYSNAME.Visible = true; //系统名称
        TB_SYSNAME.Visible = true; //系统名称


        LB_MOUDLENAME.Visible = true; //模块名称
        TB_MOUDLENAME.Visible = true; //模块名称


        LB_SYSLEVEL.Visible = true; //级别
        DP_SYSLEVEL.Visible = true; //级别


        LB_PARENT.Visible = false; //上一级别模块
        TB_PARENT.Visible = false; //上一级别模块


        LB_URL.Visible = false; //url
        TB_URL.Visible = false; //url


        LB_DESCRIPTION.Visible = false; //描述
        TB_DESCRIPTION.Visible = false; //描述


        LB_IMG.Visible = false; //模块对应的图片url
        TB_IMG.Visible = false; //模块对应的图片url


        LB_VERSION.Visible = true; //颁本
        DP_VERSION.Visible = true; //颁本


        Bt_select.Visible = true;//查询按钮
    }


    protected void dwgridview_SYS_MENU_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor = '#d5f4fe'");
            //添加自定义属性，当鼠标移走时还原该行的背景色  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            e.Row.Attributes["style"] = "Cursor:hand";
        }
    }

    protected void dwgridview_SYS_MENU_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dwgridview_SYS_MENU.PageIndex = e.NewPageIndex;
        bindgridview();
    }
    protected void update_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //修改数据
        GetPermission();
        if (IsofUpdate_Action == false)
        {
            JS.Alert("无修改数据权限！", this);
            return;
        }
        Response.Redirect("SYS_MENUedit.aspx?action=edit&id=" + id);
    }

    /// <summary>
    /// 获得gridview中被选择的记录的条数
    /// </summary>
    /// <returns></returns>
    private int GetCheckedRows()
    {
        int sum = 0;
        int count = 0;
        foreach (GridViewRow row in dwgridview_SYS_MENU.Rows)
        {
            count++;
            CheckBox chk = null;
            chk = (CheckBox)row.FindControl("inChk");
            if (chk.Checked == true)
            {
                ViewState["rowNumber"] = count.ToString();
                sum++;
            }
        }
        return sum;
    }


    /// <summary>
    /// 全check
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Ck_checkAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in dwgridview_SYS_MENU.Rows)
        {
            CheckBox chk = null;
            chk = (CheckBox)row.FindControl("inChk");
            chk.Checked = ((CheckBox)sender).Checked;
        }
    }


    /// <summary>
    /// 对指定索引页面进行排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    private DataTable GetSortTable(DataTable table, int PageIndex, int PageSize, string sortExpression, string direction)
    {
        DataTable tmptable = new DataTable();
        tmptable = table.Clone();
        int startrow = PageIndex * PageSize;
        int endrow = (PageIndex + 1) * PageSize;
        //如果全部
        if (table.Rows.Count < endrow)
        {
            endrow = table.Rows.Count;
        }
        //复制出来
        for (int i = startrow; i < endrow; i++)
        {
            DataRow dr = tmptable.NewRow();
            dr.ItemArray = table.Rows[i].ItemArray;
            tmptable.Rows.Add(dr);
        }
        //排序
        DataRow[] rows = tmptable.Select("", sortExpression + " " + direction);
        //再复制回去
        for (int i = startrow; i < endrow; i++)
        {
            table.Rows.RemoveAt(i);
            DataRow dr = table.NewRow();
            dr.ItemArray = rows[i - startrow].ItemArray;
            table.Rows.InsertAt(dr, i);
        }
        return table;
    }


    /// <summary>
    /// 响应排序查询的真正代码
    /// </summary>
    /// <param name="sortExpression"></param>
    /// <param name="direction"></param>
    private void SortGridView(string sortExpression, string direction)
    {
        Search("sort", this.dwgridview_SYS_MENU.PageIndex, sortExpression, direction);
    }

    /// <summary>
    ///真正的查询函数，也就是查询的执行体
    /// </summary>
    /// <param name="action">控件调用的变量</param>
    /// <param name="pageIndex">gridview的页码参数</param>
    /// <param name="sortExpression">排序的字段</param>
    /// <param name="direction">升序还是降序</param>
    private void Search(string action, int pageIndex, string sortExpression, string direction)
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        Djdw.Model.Post.SYS_MENU obj = new Djdw.Model.Post.SYS_MENU();
        DataTable table = new DataTable();
        if (action.Equals("search") || action.Equals("add") || action.Equals("modify"))
        {
        }
        else
        {
            DataSet ds = handle.GetList(getstrwherefrompage());
            table = ds.Tables[0];
        }
        Lb_Count.Text = "总记录条数:" + table.Rows.Count;
        //排序
        if (Dp_paging.SelectedValue == "不分页")
        {
            DataView dv = new DataView(table);
            if (sortExpression != "")
            {
                dv.Sort = sortExpression + " " + direction;
            }
            dwgridview_SYS_MENU.DataSource = dv;
            this.dwgridview_SYS_MENU.PageIndex = pageIndex;
            this.dwgridview_SYS_MENU.AllowPaging = false;
            this.dwgridview_SYS_MENU.DataBind();
        }
        else
        {
            int PageSize = Int32.Parse(Dp_paging.SelectedValue.ToString());
            if (sortExpression != "")
            {
                table = GetSortTable(table, pageIndex, PageSize, sortExpression, direction);
            }
            dwgridview_SYS_MENU.DataSource = table;
            this.dwgridview_SYS_MENU.PageSize = PageSize;
            this.dwgridview_SYS_MENU.PageIndex = pageIndex;
            this.dwgridview_SYS_MENU.AllowPaging = true;
            this.dwgridview_SYS_MENU.DataBind();
        }
        for (int i = 0; i <= dwgridview_SYS_MENU.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_SYS_MENU.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
            }
        }

    }


    /// <summary>
    /// 确定修改数据时选中的时那一行
    /// </summary>
    private void SelectedCheckbox()
    {
        if (ViewState["rowNumber"] != null)
        {
            int i = Int32.Parse(ViewState["rowNumber"].ToString()) - 1;
            CheckBox chk = null;
            chk = (CheckBox)this.dwgridview_SYS_MENU.Rows[i].FindControl("inChk");
            if (chk != null)
            {
                chk.Checked = true;
            }
        }
    }


    /// <summary>
    /// 导出EXCEL报表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_EXCEL_Click(object sender, ImageClickEventArgs e)
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        DataSet ds = handle.GetList(getstrwherefrompage());
        ds.Tables[0].Columns[0].ColumnName = "编号";
        ds.Tables[0].Columns[1].ColumnName = "系统名称";
        ds.Tables[0].Columns[2].ColumnName = "模块名称";
        ds.Tables[0].Columns[3].ColumnName = "级别";
        ds.Tables[0].Columns[4].ColumnName = "上一级别模块";
        ds.Tables[0].Columns[5].ColumnName = "url";
        ds.Tables[0].Columns[6].ColumnName = "描述";
        ds.Tables[0].Columns[7].ColumnName = "模块对应的图片url";
        ds.Tables[0].Columns[8].ColumnName = "颁本";
        CommonMethod.Excel.DataTable2Excel(ds.Tables[0], "菜单查询SYS_MENU.xls");
    }

    protected void Bt_select_Click(object sender, EventArgs e)
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        Djdw.Model.Post.SYS_MENU obj = new Djdw.Model.Post.SYS_MENU();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dwgridview_SYS_MENU.DataSource = dt.DefaultView;
        dwgridview_SYS_MENU.DataBind();
        for (int i = 0; i <= dwgridview_SYS_MENU.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_SYS_MENU.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
            }
        }

    }

    protected void delete_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();

        GetPermission();
        if (IsofDelete_Action == false)
        {
            JS.Alert("无删除数据权限！", this);
            return;
        }

        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        if (0 < handle.Delete(id.Trim()))
        {
            JS.Alert("删除成功！", this);
            bindgridview();
        }
        else
            JS.Alert("删除失败！", this);
    }

    protected string GetSYSLEVEL(string id_str)
    {
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        return handle.GetInfoNameByinfono("2", id_str);
    }

    protected string GetVERSION(string id_str)
    {
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        return handle.GetInfoNameByinfono("1", id_str);
    }

    /// <summary>
    /// gridview字段排序的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dwgridview_SYS_MENU_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortexpression"] = e.SortExpression;
        SortGridView(ViewState["sortexpression"].ToString(), ViewState["direction"].ToString());
        if (ViewState["direction"].ToString() == "DESC")
        {
            ViewState["direction"] = "ASC";
        }
        else
        {
            ViewState["direction"] = "DESC";
        }
    }


    /// <summary>
    /// /控制gridview的分页显示设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Dp_paging_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Session["test_managedata"] != null)
        {
            Search("page", 0, ViewState["sortexpression"].ToString(), ViewState["direction"].ToString());
        }
    }


    protected void detail_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //修改数据
        GetPermission();
        if (IsofDetail_Action == false)
        {
            JS.Alert("无查询数据详细权限！", this);
            return;
        }
        //
        Response.Redirect("SYS_MENUedit.aspx?action=detail&id=" + id);
    }


}

