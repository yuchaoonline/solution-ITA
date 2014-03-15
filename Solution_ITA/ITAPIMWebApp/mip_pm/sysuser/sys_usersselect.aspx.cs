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

public partial class mip_pm_sys_usersselect : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "7", "");
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
    private bool IsofExport_Action;
    private bool IsofUpdate_Action;
    private bool IsofDetail_Action;
    private bool Isofsetrole_Action;
    private bool Isofdataset_Action;

    /*
        UserMng.action.delete	用户删除按钮
        UserMng.action.update	用户更新按钮
        UserMng.action.detail	用户详细按钮
        UserMng.action.add	用户添加按钮
        UserMng.action.setrole	用户设置角色按钮
        UserMng.action.dataset	用户数据集权限按钮
     */

    private void GetPermission()
    {
        IsofAdd_Action = _IsAuthorizedInaction("UserMng.action.update");
        IsofDelete_Action = _IsAuthorizedInaction("UserMng.action.update");
        IsofUpdate_Action = _IsAuthorizedInaction("UserMng.action.update");
        IsofDetail_Action = _IsAuthorizedInaction("UserMng.action.detail");
        Isofsetrole_Action = _IsAuthorizedInaction("UserMng.action.update");
        Isofdataset_Action = _IsAuthorizedInaction("UserMng.action.update");
    }

    private void bindgridview()
    {
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        Mis.Model.ptgl.SYS_USERS obj = new Mis.Model.ptgl.SYS_USERS();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        //数据过滤
        //string p_permissionScopeCode = "UserMng.data.show";
        //string p_tablenameinfo = "UserMng";
        //dt = this._FilterDataTable(dt, p_permissionScopeCode, p_tablenameinfo);
        //
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dwgridview_sys_users.DataSource = dt.DefaultView;
        dwgridview_sys_users.DataBind();
        for (int i = 0; i <= dwgridview_sys_users.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_users.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
            }
        }

    }


    ///// <summary>
    ///// 判断一个用户的示范区权限设置
    ///// </summary>
    //protected void bindgridview_DFLinkBT_Button()
    //{
    //    foreach (GridViewRow row in dwgridview_sys_users.Rows)
    //    {
    //        LinkButton lbt = null;
    //        lbt = (LinkButton)row.FindControl("datasetright");
    //        if(lbt!=null)
    //        {

    //        }
    //    }
    //}

    /// <summary>
    /// 页面收集组织成查询条件
    /// </summary>
    /// <returns></returns>
    public string getstrwherefrompage()
    {
        string strwhere = "";

        if (TB_DEPTID.Text.Trim() != "")//部门id
        {
            strwhere += " and DEPTID like '%" + TB_DEPTID.Text.Trim() + "%' ";
        }
        if (TB_USERNO.Text.Trim() != "")//人员工号
        {
            strwhere += " and USERNO like '%" + TB_USERNO.Text.Trim() + "%' ";
        }
        if (TB_USERREALNAME.Text.Trim() != "")//人员真实名称
        {
            strwhere += " and USERREALNAME like '%" + TB_USERREALNAME.Text.Trim() + "%' ";
        }
        if (TB_USERNAME.Text.Trim() != "")//用户名
        {
            strwhere += " and USERNAME like '%" + TB_USERNAME.Text.Trim() + "%' ";
        }
        if (TB_PASSWORD.Text.Trim() != "")//人员密码
        {
            strwhere += " and PASSWORD like '%" + TB_PASSWORD.Text.Trim() + "%' ";
        }
        if (int.Parse(DP_SEX.SelectedValue) != 0)//性别
        {
            strwhere += " and SEX  = " + int.Parse(DP_SEX.SelectedValue);
        }
        if (TB_AGE.Text.Trim() != "")//年龄
        {
            // if (int.Parse(TB_AGE.Text.Trim()) != 0)
            {
                strwhere += " and AGE  = " + int.Parse(TB_AGE.Text.Trim());
            }
        }

        if (strwhere != "")
        {
            strwhere = strwhere.Substring(5);
        }
        return strwhere;
    }

    protected string GetDeptName(string p_deptid)
    {
        Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
        Mis.Model.ptgl.SYS_DEPARTMENT model = handle.GetModel(int.Parse(p_deptid));
        return model.DEPTNAME;
    }
    /// <summary>
    /// 控件是否可见
    /// </summary>
    protected void IsofVisible()
    {
        LB_DEPTID.Visible = true; //部门id
        TB_DEPTID.Visible = true; //部门id


        LB_USERNO.Visible = true; //人员工号
        TB_USERNO.Visible = true; //人员工号


        LB_USERREALNAME.Visible = true; //人员真实名称
        TB_USERREALNAME.Visible = true; //人员真实名称


        LB_USERNAME.Visible = true; //用户名
        TB_USERNAME.Visible = true; //用户名


        LB_PASSWORD.Visible = false; //人员密码
        TB_PASSWORD.Visible = false; //人员密码


        LB_SEX.Visible = true; //性别
        DP_SEX.Visible = true; //性别


        LB_AGE.Visible = false; //年龄
        TB_AGE.Visible = false; //年龄


        Bt_select.Visible = true;//查询按钮
    }


    protected void dwgridview_sys_users_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor = '#d5f4fe'");
            //添加自定义属性，当鼠标移走时还原该行的背景色  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            e.Row.Attributes["style"] = "Cursor:hand";
        }
    }

    protected void dwgridview_sys_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dwgridview_sys_users.PageIndex = e.NewPageIndex;
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
        //string p_permissionScopeCode = "UserMng.data.update";
        //string p_tablenameinfo = "UserMng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无修改该条数据权限！", this);
        //    return;
        //}
        ////
        Response.Redirect("sys_usersedit.aspx?action=edit&id=" + id);
    }

    protected void datasetright_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //操作权限管理
        GetPermission();
        if (Isofdataset_Action == false)
        {
            JS.Alert("无设置用户示范区范围权限！", this);
            return;
        }
        //数据过滤
        //string p_permissionScopeCode = "UserMng.data.dataset";
        //string p_tablenameinfo = "UserMng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无操作该用户数据集权限！", this);
        //    return;
        //}
        ////

        Response.Redirect("../xxty/XXTY_ShowArea_Infoselect_datafilter.aspx?id=" + id);
    }

    protected void cityproright_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //操作权限管理
        GetPermission();
        if (Isofdataset_Action == false)
        {
            JS.Alert("无设置用户示范区范围权限！", this);
            return;
        }

        Response.Redirect("../../mip_pm/rightdatafilter/datafilter.aspx?id=" + id);
    }

    /// <summary>
    /// 获得gridview中被选择的记录的条数
    /// </summary>
    /// <returns></returns>
    private int GetCheckedRows()
    {
        int sum = 0;
        int count = 0;
        foreach (GridViewRow row in dwgridview_sys_users.Rows)
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
        foreach (GridViewRow row in dwgridview_sys_users.Rows)
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
        Search("sort", this.dwgridview_sys_users.PageIndex, sortExpression, direction);
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
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        Mis.Model.ptgl.SYS_USERS obj = new Mis.Model.ptgl.SYS_USERS();
        DataTable table = new DataTable();
        if (action.Equals("search") || action.Equals("add") || action.Equals("modify"))
        {
        }
        else
        {
            DataSet ds = handle.GetList(getstrwherefrompage());
            table = ds.Tables[0];
            //数据过滤
            //string p_permissionScopeCode = "UserMng.data.show";
            //string p_tablenameinfo = "UserMng";
            //table = this._FilterDataTable(table, p_permissionScopeCode, p_tablenameinfo);
            //
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
            dwgridview_sys_users.DataSource = dv;
            this.dwgridview_sys_users.PageIndex = pageIndex;
            this.dwgridview_sys_users.AllowPaging = false;
            this.dwgridview_sys_users.DataBind();
        }
        else
        {
            int PageSize = Int32.Parse(Dp_paging.SelectedValue.ToString());
            if (sortExpression != "")
            {
                table = GetSortTable(table, pageIndex, PageSize, sortExpression, direction);
            }
            dwgridview_sys_users.DataSource = table;
            this.dwgridview_sys_users.PageSize = PageSize;
            this.dwgridview_sys_users.PageIndex = pageIndex;
            this.dwgridview_sys_users.AllowPaging = true;
            this.dwgridview_sys_users.DataBind();
        }
        for (int i = 0; i <= dwgridview_sys_users.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_users.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
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
            chk = (CheckBox)this.dwgridview_sys_users.Rows[i].FindControl("inChk");
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
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        DataSet ds = handle.GetList(getstrwherefrompage());
        DataTable dt = ds.Tables[0];
        //数据过滤
        //string p_permissionScopeCode = "UserMng.data.show";
        //string p_tablenameinfo = "UserMng";
        //dt = this._FilterDataTable(dt, p_permissionScopeCode, p_tablenameinfo);
        ////
        dt.Columns[0].ColumnName = "id";
        dt.Columns[1].ColumnName = "部门id";
        dt.Columns[2].ColumnName = "人员工号";
        dt.Columns[3].ColumnName = "人员真实名称";
        dt.Columns[4].ColumnName = "用户名";
        dt.Columns[5].ColumnName = "人员密码";
        dt.Columns[6].ColumnName = "性别";
        dt.Columns[7].ColumnName = "年龄";
        CommonMethod.Excel.DataTable2Excel(dt, "人员信息查询sys_users.xls");
    }

    protected void Bt_select_Click(object sender, EventArgs e)
    {
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        Mis.Model.ptgl.SYS_USERS obj = new Mis.Model.ptgl.SYS_USERS();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        //数据过滤
        //string p_permissionScopeCode = "UserMng.data.show";
        //string p_tablenameinfo = "UserMng";
        //dt = this._FilterDataTable(dt, p_permissionScopeCode, p_tablenameinfo);
        ////
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dwgridview_sys_users.DataSource = dt.DefaultView;
        dwgridview_sys_users.DataBind();
        for (int i = 0; i <= dwgridview_sys_users.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_users.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
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
        //string p_permissionScopeCode = "UserMng.data.delete";
        //string p_tablenameinfo = "UserMng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无删除该数据权限！", this);
        //    return;
        //}
        ////

        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        if (0 < handle.Delete(int.Parse(id)))
        {
            string p_ResTableName = "UserMng";
            string p_ResIDStr = id;
            this._DelResLinkInfo(p_ResTableName, p_ResIDStr);

            bindgridview();
            JS.Alert("删除成功！", this);
        }
        else
            JS.Alert("删除失败！", this);
    }

    protected string GetSEX(string id_str)
    {
        Mis.BLL.ptgl.SYS_INFODICT handle = new Mis.BLL.ptgl.SYS_INFODICT();
        return handle.GetInfoNameByinfono("0", id_str);
    }

    /// <summary>
    /// gridview字段排序的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dwgridview_sys_users_Sorting(object sender, GridViewSortEventArgs e)
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
        //数据过滤
        //string p_permissionScopeCode = "UserMng.data.show";
        //string p_tablenameinfo = "UserMng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无查询该元素详细情况权限！", this);
        //    return;
        //}
        ////
        Response.Redirect("sys_usersedit.aspx?action=detail&id=" + id);
    }

    protected void pzrole_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //操作权限管理
        GetPermission();
        if (Isofsetrole_Action == false)
        {
            JS.Alert("无设置用户角色权限！", this);
            return;
        }
        //数据过滤
        //string p_permissionScopeCode = "UserMng.data.setrole";
        //string p_tablenameinfo = "UserMng";
        //if (false == this._FilterDataAction(id, p_permissionScopeCode, p_tablenameinfo))
        //{
        //    JS.Alert("无设置该用户角色权限！", this);
        //    return;
        //}
        ////
        Response.Redirect("../rightmanage/userrole.aspx?id=" + id);
    }


    protected void Bt_DEPARTMENT_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.open('sys_departmenttreeadd.aspx','userIndex','width=400,height=375,top=150,left=280,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no').focus();</script>");

    }

}

