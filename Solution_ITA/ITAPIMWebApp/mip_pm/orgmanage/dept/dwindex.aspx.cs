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

public partial class infoplatform_orgmanage_dept_dwindex : CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "9", "");
        if (!IsPostBack)
        {
            RefreshTree();
            GetPermission();
        }
    }

    private bool IsofAdd_Action;
    private bool IsofDelete_Action;

    /*
        Deptmng.data.delete	部门删除数据控制点
        Deptmng.data.detail	部门详细数据控制点
        Deptmng.data.show	部门查看数据控制点
        Deptmng.data.update	部门更新数据控制点
        Deptmng.action.delete	部门删除按钮
        Deptmng.action.update	部门更新按钮
        Deptmng.action.detail	部门详细按钮
        Deptmng.action.add	部门添加按钮

     */

    private void GetPermission()
    {
        IsofAdd_Action = _IsAuthorizedInaction("Deptmng.action.update");
        this.Imbtn_add.Enabled = IsofAdd_Action;
        IsofDelete_Action = _IsAuthorizedInaction("Deptmng.action.update");
        this.imbtn_delete.Enabled = IsofDelete_Action;

    }
    private void RefreshTree()
    {
        Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
        Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
        obj = handle.GetModel(1);
        TreeNode headnode = new TreeNode(obj.DEPTNAME, obj.ID.ToString(), "", "", "");
        InitMenuTree(headnode, obj.ID.ToString());
        this.menu.Nodes.Clear();
        this.menu.Nodes.Add(headnode);
        this.menu.ExpandAll();
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



    protected void edit_Click(object sender, EventArgs e)
    {
        if (this.menu.SelectedNode != null)
        {
            Response.Write("<script language=javascript>window.parent.frames[\"menuconfig_right\"].location.href=\"dwedit.aspx?action=edit&node=" + this.menu.SelectedNode.Value + "\";</script>");
            //this.menu.SelectedNode = null;
        }
        else
        {
            JS.Alert("请选择部门", this);//请选择部门

        }

    }








    protected void Imbtn_add_Click(object sender, ImageClickEventArgs e)
    {
        if (this.menu.SelectedNode != null)
        {
            Response.Write("<script language=javascript>window.parent.frames[\"menuconfig_right\"].location.href=\"dwedit.aspx?action=add&node=" + this.menu.SelectedNode.Value + "\";</script>");
            //this.menu.SelectedNode = null;
        }
        else
        {
            JS.Alert("请选择部门", this);//请选择部门
        }

    }



    private void GetallChknode(TreeNode node, ArrayList chklist)
    {
        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            if (node.ChildNodes[i].Checked == true)
            {
                string id_str = (string)node.ChildNodes[i].Value;
                chklist.Add(id_str);
            }
            GetallChknode(node.ChildNodes[i], chklist);
        }
    }

    protected void imbtn_delete_Click(object sender, ImageClickEventArgs e)
    {
        ArrayList chklist = new ArrayList();
        GetallChknode(this.menu.Nodes[0], chklist);
        //下面对ArrayList中的菜单施行删除操作
        if (chklist.Count == 0)
        {
            JS.Alert("请选择部门", this);//请选择部门
            return;


        }
        try
        {
            Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
            int i = handle.DeltNodes(chklist);
            if (i > 0)
            {
                chklist.Clear();
                RefreshTree();
                JS.Alert("删除成功", this);//删除成功
            }
            else
            {
                JS.Alert("删除失败,可能违反数据库完整性约束", this);//删除失败,可能违反数据库完整性约束
            }
        }

        catch
        {
            JS.Alert("删除失败,可能违反数据库完整性约束", this);//删除失败,可能违反数据库完整性约束

        }

    }

    protected void menu_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        
    }
    protected void menu_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (this.menu.SelectedNode != null)
        {
            Response.Write("<script language=javascript>window.parent.frames[\"menuconfig_right\"].location.href=\"dwedit.aspx?action=edit&node=" + this.menu.SelectedNode.Value + "\";</script>");
        }
        else
        {
            JS.Alert("请选择部门", this);//请选择部门

        }
    }
}