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
public partial class gtled_sys_oplogselect : System.Web.UI.CePage
{
    private bool IsofDetail_Action;
    /*
        logview.action.detail	详细

     */

    private void GetPermission()
    {
        IsofDetail_Action = _IsAuthorizedInaction("logview.action.detail");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPermission();
            if (IsofDetail_Action == false)
            {
                Response.Write("对不起，暂时您无权查看该信息");
                Response.End();
            }//
            bindgridview();
            this.Dp_paging.SelectedValue = "10";
            ViewState["direction"] = "ASC";
            ViewState["sortexpression"] = "";
            IsofVisible();
        }
    }
    private void bindgridview()
    {
        Mis.BLL.ptgl.SYS_OPLOG handle = new Mis.BLL.ptgl.SYS_OPLOG();
        gtled.Model.Post.SYS_OPLOG obj = new gtled.Model.Post.SYS_OPLOG();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dt.DefaultView.Sort = "ID DESC"; //id编号倒叙排序

        dwgridview_sys_oplog.DataSource = dt.DefaultView;
        dwgridview_sys_oplog.DataBind();
        for (int i = 0; i <= dwgridview_sys_oplog.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_oplog.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
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

        if (TB_USERID.Text.Trim() != "")//用户编号
        {
            strwhere += " and USERID like '%" + TB_USERID.Text.Trim() + "%' ";
        }
        if (TB_USERNAME.Text.Trim() != "")//用户真实姓名
        {
            strwhere += " and USERNAME like '%" + TB_USERNAME.Text.Trim() + "%' ";
        }
        if (TB_OPTYPE.Text.Trim() != "")//操作种类
        {
            strwhere += " and OPTYPE like '%" + TB_OPTYPE.Text.Trim() + "%' ";
        }
        if (TB_OPTIME.Text.Trim() != "")//操作时间
        {
            strwhere += " and to_char(OPTIME,'yyyy-mm-dd') >= '" + TB_OPTIME.Text + "' ";
        }
        if (TB_endOPTIME.Text.Trim() != "")//操作时间
        {
            strwhere += " and to_char(OPTIME,'yyyy-mm-dd')  <= '" + TB_endOPTIME.Text + "' ";
        }
        if (TB_REMARK.Text.Trim() != "")//备注
        {
            strwhere += " and REMARK like '%" + TB_REMARK.Text.Trim() + "%' ";
        }
        if (TB_REMARK1.Text.Trim() != "")//备注1
        {
            strwhere += " and REMARK1 like '%" + TB_REMARK1.Text.Trim() + "%' ";
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
        LB_USERID.Visible = false; //用户编号
        TB_USERID.Visible = false; //用户编号



        LB_USERNAME.Visible = false; //用户真实姓名
        TB_USERNAME.Visible = false; //用户真实姓名



        LB_OPTYPE.Visible = false; //操作种类
        TB_OPTYPE.Visible = false; //操作种类



        LB_OPTIME.Visible = true; //操作时间
        TB_OPTIME.Visible = true; //操作时间
        TB_endOPTIME.Visible = true; //操作时间
        Label_OPTIME.Visible = true; //操作时间



        LB_REMARK.Visible = false; //备注
        TB_REMARK.Visible = false; //备注



        LB_REMARK1.Visible = false; //备注1
        TB_REMARK1.Visible = false; //备注1



        Bt_select.Visible = true;//查询按钮
    }


    protected void dwgridview_sys_oplog_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor = '#d5f4fe'");
            //添加自定义属性，当鼠标移走时还原该行的背景色  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            e.Row.Attributes["style"] = "Cursor:hand";
        }
    }

    protected void dwgridview_sys_oplog_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dwgridview_sys_oplog.PageIndex = e.NewPageIndex;
        bindgridview();
    }
    protected void update_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        Response.Redirect("sys_oplogedit.aspx?action=edit&id=" + id);
    }

    /// <summary>
    /// 获得gridview中被选择的记录的条数
    /// </summary>
    /// <returns></returns>
    private int GetCheckedRows()
    {
        int sum = 0;
        int count = 0;
        foreach (GridViewRow row in dwgridview_sys_oplog.Rows)
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
        foreach (GridViewRow row in dwgridview_sys_oplog.Rows)
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
        Search("sort", this.dwgridview_sys_oplog.PageIndex, sortExpression, direction);
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
        Mis.BLL.ptgl.SYS_OPLOG handle = new Mis.BLL.ptgl.SYS_OPLOG();
        gtled.Model.Post.SYS_OPLOG obj = new gtled.Model.Post.SYS_OPLOG();
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
            dwgridview_sys_oplog.DataSource = dv;
            this.dwgridview_sys_oplog.PageIndex = pageIndex;
            this.dwgridview_sys_oplog.AllowPaging = false;
            this.dwgridview_sys_oplog.DataBind();
        }
        else
        {
            int PageSize = Int32.Parse(Dp_paging.SelectedValue.ToString());
            if (sortExpression != "")
            {
                table = GetSortTable(table, pageIndex, PageSize, sortExpression, direction);
            }
            dwgridview_sys_oplog.DataSource = table;
            this.dwgridview_sys_oplog.PageSize = PageSize;
            this.dwgridview_sys_oplog.PageIndex = pageIndex;
            this.dwgridview_sys_oplog.AllowPaging = true;
            this.dwgridview_sys_oplog.DataBind();
        }
        for (int i = 0; i <= dwgridview_sys_oplog.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_oplog.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
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
            chk = (CheckBox)this.dwgridview_sys_oplog.Rows[i].FindControl("inChk");
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
        Mis.BLL.ptgl.SYS_OPLOG handle = new Mis.BLL.ptgl.SYS_OPLOG();
        DataSet ds = handle.GetList(getstrwherefrompage());
        ds.Tables[0].Columns[0].ColumnName = "编号";
        ds.Tables[0].Columns[1].ColumnName = "用户编号";
        ds.Tables[0].Columns[2].ColumnName = "用户真实姓名";
        ds.Tables[0].Columns[3].ColumnName = "操作种类";
        ds.Tables[0].Columns[4].ColumnName = "操作时间";
        ds.Tables[0].Columns[5].ColumnName = "备注";
        ds.Tables[0].Columns[6].ColumnName = "备注1";
        CommonMethod.Excel.DataTable2Excel(ds.Tables[0], "日志查询sys_oplog.xls");
    }

    protected void Bt_select_Click(object sender, EventArgs e)
    {
        Mis.BLL.ptgl.SYS_OPLOG handle = new Mis.BLL.ptgl.SYS_OPLOG();
        gtled.Model.Post.SYS_OPLOG obj = new gtled.Model.Post.SYS_OPLOG();
        DataTable dt = new DataTable();
        dt = handle.GetTable(getstrwherefrompage());
        Lb_Count.Text = "查到记录条数:" + dt.Rows.Count;
        dwgridview_sys_oplog.DataSource = dt.DefaultView;
        dwgridview_sys_oplog.DataBind();
        for (int i = 0; i <= dwgridview_sys_oplog.Rows.Count - 1; i++)
        {
            if (i % 2 == 1)
            {
                dwgridview_sys_oplog.Rows[i].BackColor = System.Drawing.Color.FloralWhite;
            }
        }

    }




    /// <summary>
    ///删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void delete_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        Mis.BLL.ptgl.SYS_OPLOG handle = new Mis.BLL.ptgl.SYS_OPLOG();
        if (0 < handle.Delete(int.Parse(id)))
        {
            //JS.Alert("删除成功！", this);
            bindgridview();
        }
        else
            JS.Alert("删除失败！", this);
    }

    /// <summary>
    /// gridview字段排序的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dwgridview_sys_oplog_Sorting(object sender, GridViewSortEventArgs e)
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
        Response.Redirect("sys_oplogedit.aspx?action=detail&id=" + id);
    }
    protected void inChk_CheckedChanged(object sender, EventArgs e)
    {
    }

}

