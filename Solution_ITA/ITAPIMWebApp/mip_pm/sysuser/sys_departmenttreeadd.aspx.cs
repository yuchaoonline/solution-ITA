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

public partial class mip_pm_sys_departmenttreeadd : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "9", "");
        if (!IsPostBack)
        {
            RefreshTree();
        }
    }
    private void RefreshTree()
    {
        Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
        Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
        obj = handle.GetModel(1);
        TreeNode headnode = new TreeNode(obj.DEPTNAME, obj.ID.ToString(), "", "", "");
        InitMenuTree(headnode, obj.ID.ToString());
        this.TreeView_Obj.Nodes.Clear();
        this.TreeView_Obj.Nodes.Add(headnode);
        this.TreeView_Obj.ExpandAll();
    }

    private void InitMenuTree(TreeNode listnode, string parent)
    {
        Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
        string where_str = " parentid='" + parent + "'";
        DataSet ds = handle.GetList(where_str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
                obj.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                //obj.IMG = ds.Tables[0].Rows[i]["IMG"].ToString();
                obj.DEPTNAME = ds.Tables[0].Rows[i]["DEPTNAME"].ToString();
                obj.PARENTID = int.Parse(ds.Tables[0].Rows[i]["PARENTID"].ToString());
                //obj.SYSLEVEL=ds.Tables[0].Rows[i]["SYSLEVEL"].ToString();
                //obj. = ds.Tables[0].Rows[i]["SYSNAME"].ToString();
                //obj.URL = ds.Tables[0].Rows[i]["URL"].ToString();
                obj.DESCRIPTION = ds.Tables[0].Rows[i]["DESCRIPTION"].ToString();
                TreeNode node = new TreeNode(obj.DEPTNAME, obj.ID.ToString(), "", "", "");

                listnode.ChildNodes.Add(node);
                InitMenuTree(node, obj.ID.ToString());
            }
        }

    }
    protected void TreeView_Obj_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeNode sel_obj = this.TreeView_Obj.SelectedNode;
        this.Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.opener.document.getElementById('TB_DEPTID').value='" + sel_obj.Value + "';window.opener.document.getElementById('TB_DEPTNAME').value='" + sel_obj.Text + "';window.close();</script>");

    }
}
