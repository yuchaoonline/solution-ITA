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


    public partial class infodict_infodict_index : CePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //this._isallowaccess("", "6", "");
            if (!IsPostBack)
            {
                //TransPage();
                bindgridview();


            }

        }

    
        private void bindgridview()
        {
            Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
            DataSet dts = handle.GetList("  syslevel=2 and version=2 ");
            this.GridView1.DataSource = dts;
            GridView1.DataBind();


        }

        protected void btn_update_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"editmain.aspx?id=" + id + "\";</script>");

        }

        protected void btn_nextlevel_Command(object sender, CommandEventArgs e)
        {
            string parentid = e.CommandArgument.ToString();
            Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"subclassview.aspx?parentid=" + parentid + "\";</script>");

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindgridview();
        }
        protected void Imbtn_add_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language=javascript>window.parent.frames[\"infodict_right\"].location.href=\"addmain.aspx\";</script>");

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton btn_update = (ImageButton)e.Row.FindControl("btn_update");
            ImageButton btn_nextlevel = (ImageButton)e.Row.FindControl("btn_nextlevel");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor = '#d5f4fe'");
                //添加自定义属性，当鼠标移走时还原该行的背景色  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }
    }
