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
public partial class mip_pm_sys_rolesselect : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "8", "");
        if (!IsPostBack)
        {
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
    private bool Isofright_Action;
    /*
        Rolemng.data.delete	角色删除数据控制点
        Rolemng.data.detail	角色详细数据控制点
        Rolemng.data.show	角色查看数据控制点
        Rolemng.data.update	角色更新数据控制点
        Rolemng.data.right	角色权限数据控制点
        Rolemng.action.delete	删除
        Rolemng.action.update	更新
        Rolemng.action.detail	详细
        Rolemng.action.add	添加
        Rolemng.action.right	分配权限

     */

    private void GetPermission()
    {
        IsofAdd_Action = _IsAuthorizedInaction("Rolemng.action.update");
        IsofDelete_Action = _IsAuthorizedInaction("Rolemng.action.update");
        IsofUpdate_Action = _IsAuthorizedInaction("Rolemng.action.update");
        IsofDetail_Action = _IsAuthorizedInaction("Rolemng.action.detail");
        Isofright_Action = _IsAuthorizedInaction("Rolemng.action.update");
    }

    private void bindgridview()
    {
        Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
        Mis.Model.ptgl.SYS_ROLES obj = new Mis.Model.ptgl.SYS_ROLES();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        //数据过滤
        //string p_permissionScopeCode = "Rolemng.data.show";
        //string p_tablenameinfo = "Rolemng";
        //dt = this._FilterDataTable(dt, p_permissionScopeCode, p_tablenameinfo);
        //
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dwgridview_sys_roles.DataSource = dt.DefaultView;
        dwgridview_sys_roles.DataBind();
        for (int i = 0; i <= dwgridview_sys_roles.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_roles.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
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

        if (TB_ROLENO.Text.Trim() != "")//角色编号
        {
            strwhere += " and ROLENO like '%" + TB_ROLENO.Text.Trim() + "%' ";
        }
        if (TB_USERNO.Text.Trim() != "")//角色名称
        {
            strwhere += " and USERNO like '%" + TB_USERNO.Text.Trim() + "%' ";
        }
        if (TB_DESCRIPTION.Text.Trim() != "")//描述
        {
            strwhere += " and DESCRIPTION like '%" + TB_DESCRIPTION.Text.Trim() + "%' ";
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
        LB_ROLENO.Visible = true; //角色编号
        TB_ROLENO.Visible = true; //角色编号


        LB_USERNO.Visible = true; //角色名称
        TB_USERNO.Visible = true; //角色名称


        LB_DESCRIPTION.Visible = false; //描述
        TB_DESCRIPTION.Visible = false; //描述


        Bt_select.Visible = true;//查询按钮
    }

    protected string GetSYSDATATYPE(string p_sysdatatype)
    {
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        return handle.GetInfoNameByinfono("85", p_sysdatatype);
    }


    protected void dwgridview_sys_roles_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor = '#d5f4fe'");
            //添加自定义属性，当鼠标移走时还原该行的背景色  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            e.Row.Attributes["style"] = "Cursor:hand";
        }
    }

    protected void dwgridview_sys_roles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dwgridview_sys_roles.PageIndex = e.NewPageIndex;
        bindgridview();
    }
    protected void update_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //操作权限管理
        GetPermission();
        if (IsofUpdate_Action == false)
        {
            JS.Alert("无修改数据权限！", this);
            return;
        }
        //数据过滤
        //string p_permissionScopeCode = "Rolemng.data.update";
        //string p_tablenameinfo = "Rolemng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无修改该数据权限！", this);
        //    return;
        //}
        ////

        Response.Redirect("sys_rolesedit.aspx?action=edit&id=" + id);
    }

    /// <summary>
    /// 获得gridview中被选择的记录的条数
    /// </summary>
    /// <returns></returns>
    private int GetCheckedRows()
    {
        int sum = 0;
        int count = 0;
        foreach (GridViewRow row in dwgridview_sys_roles.Rows)
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
        foreach (GridViewRow row in dwgridview_sys_roles.Rows)
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
        Search("sort", this.dwgridview_sys_roles.PageIndex, sortExpression, direction);
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
        Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
        Mis.Model.ptgl.SYS_ROLES obj = new Mis.Model.ptgl.SYS_ROLES();
        DataTable table = new DataTable();
        if (action.Equals("search") || action.Equals("add") || action.Equals("modify"))
        {
        }
        else
        {
            DataSet ds = handle.GetList(getstrwherefrompage());
            table = ds.Tables[0];
            //数据过滤
            //string p_permissionScopeCode = "Rolemng.data.show";
            //string p_tablenameinfo = "Rolemng";
            //table = this._FilterDataTable(table, p_permissionScopeCode, p_tablenameinfo);
            ////
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
            dwgridview_sys_roles.DataSource = dv;
            this.dwgridview_sys_roles.PageIndex = pageIndex;
            this.dwgridview_sys_roles.AllowPaging = false;
            this.dwgridview_sys_roles.DataBind();
        }
        else
        {
            int PageSize = Int32.Parse(Dp_paging.SelectedValue.ToString());
            if (sortExpression != "")
            {
                table = GetSortTable(table, pageIndex, PageSize, sortExpression, direction);
            }
            dwgridview_sys_roles.DataSource = table;
            this.dwgridview_sys_roles.PageSize = PageSize;
            this.dwgridview_sys_roles.PageIndex = pageIndex;
            this.dwgridview_sys_roles.AllowPaging = true;
            this.dwgridview_sys_roles.DataBind();
        }
        for (int i = 0; i <= dwgridview_sys_roles.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_roles.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
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
            chk = (CheckBox)this.dwgridview_sys_roles.Rows[i].FindControl("inChk");
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
        Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
        DataSet ds = handle.GetList(getstrwherefrompage());
        DataTable dt = ds.Tables[0];
        //数据过滤
        //string p_permissionScopeCode = "Rolemng.data.show";
        //string p_tablenameinfo = "Rolemng";
        //dt = this._FilterDataTable(dt, p_permissionScopeCode, p_tablenameinfo);
        ////
        dt.Columns[0].ColumnName = "id";
        dt.Columns[1].ColumnName = "角色编号";
        dt.Columns[2].ColumnName = "角色名称";
        dt.Columns[3].ColumnName = "描述";
        CommonMethod.Excel.DataTable2Excel(dt, "角色信息查询sys_roles.xls");
    }

    protected void Bt_select_Click(object sender, EventArgs e)
    {
        Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
        Mis.Model.ptgl.SYS_ROLES obj = new Mis.Model.ptgl.SYS_ROLES();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        //数据过滤
        //string p_permissionScopeCode = "Rolemng.data.show";
        //string p_tablenameinfo = "Rolemng";
        //dt = this._FilterDataTable(dt, p_permissionScopeCode, p_tablenameinfo);
        ////
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dwgridview_sys_roles.DataSource = dt.DefaultView;
        dwgridview_sys_roles.DataBind();
        for (int i = 0; i <= dwgridview_sys_roles.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_roles.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
            }
        }

    }

    protected void delete_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //操作权限管理
        GetPermission();
        if (IsofDelete_Action == false)
        {
            JS.Alert("无删除数据权限！", this);
            return;
        }
        //数据过滤
        //string p_permissionScopeCode = "Rolemng.data.delete";
        //string p_tablenameinfo = "Rolemng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无删除该数据权限！", this);
        //    return;
        //}
        ////

        Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
        if (0 < handle.Delete(int.Parse(id)))
        {
            string p_ResTableName = "Rolemng";
            string p_ResIDStr = id;
            this._DelResLinkInfo(p_ResTableName, p_ResIDStr);
            //JS.Alert("删除成功！", this);
            bindgridview();
        }
        else
            JS.Alert("删除失败！", this);
    }

    protected void rightdip_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        Response.Redirect("../rightmanage/RightDis.aspx?id=" + id);
    }

    /// <summary>
    /// gridview字段排序的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dwgridview_sys_roles_Sorting(object sender, GridViewSortEventArgs e)
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
        //操作权限管理
        GetPermission();
        if (IsofDetail_Action == false)
        {
            JS.Alert("无查询详细情况权限！", this);
            return;
        }
        //数据过滤
        //string p_permissionScopeCode = "Rolemng.data.show";
        //string p_tablenameinfo = "Rolemng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无查询该数据详细情况权限！", this);
        //    return;
        //}

        Response.Redirect("sys_rolesedit.aspx?action=detail&id=" + id);
    }



}

