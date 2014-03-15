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

public partial class mip_pm_rightdatafilter_datafilter : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDwData();
            RefreshDataFilterTree();
            RefreshTree();
            GetPermission();
        }
    }

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
        Isofdataset_Action = _IsAuthorizedInaction("UserMng.action.update");
        this.Bt_commit.Enabled = Isofdataset_Action;
    }

    #region 部门和用户

    private void RefreshTree()
    {
        Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
        Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
        obj = handle.GetModel(1);
        TreeNode headnode = new TreeNode(obj.DEPTNAME, obj.ID.ToString(), "", "", "");
        InitMenuTree(headnode, obj.ID.ToString());
        this.TV_DEPTUSER.Nodes.Clear();
        this.TV_DEPTUSER.Nodes.Add(headnode);
        this.TV_DEPTUSER.ExpandAll();
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
                obj.DEPTNAME = ds.Tables[0].Rows[i]["DEPTNAME"].ToString();
                obj.PARENTID = int.Parse(ds.Tables[0].Rows[i]["PARENTID"].ToString());
            
                obj.DESCRIPTION = ds.Tables[0].Rows[i]["DESCRIPTION"].ToString();
                TreeNode node = new TreeNode(obj.DEPTNAME, obj.ID.ToString(), "", "", "");

                listnode.ChildNodes.Add(node);
                InitMenuTree(node, obj.ID.ToString());

                InitUserNode(node, obj.ID.ToString());
            }
        }

    }

    private void InitUserNode(TreeNode listnode, string parent)
    {
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        DataSet ds = handle.GetList(" deptid=" + parent);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Mis.Model.ptgl.SYS_USERS obj = new Mis.Model.ptgl.SYS_USERS();
                obj.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                obj.USERREALNAME = ds.Tables[0].Rows[i]["USERREALNAME"].ToString();

                TreeNode node = new TreeNode(obj.USERREALNAME, obj.ID.ToString(), "../Ima/menu/person.gif", "", "");
                node.ToolTip = "用户";

                listnode.ChildNodes.Add(node);

            }
        }
    }


    #endregion

    /// <summary>
    /// 信息标准绑定下拉框dp
    /// </summary>
    private void BindDwData()
    {
        Mis.BLL.ptgl.SYS_INFODICT dic = new Mis.BLL.ptgl.SYS_INFODICT();
        dic.BindToRadioButtonList(this.RB_DATAFILTERTYPE,"42");

        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        string p_useridstr = this.Context.Request["id"].Trim();
        Mis.Model.ptgl.SYS_USERS obj = handle.GetModel(int.Parse(p_useridstr));
        this.TB_USERNAME.Text = obj.USERREALNAME;
        this.TB_USERNAME.Enabled = false;

        this.TB_DATAFILTERNAME.Enabled = false;
    }

    #region 控制点树

    private void RefreshDataFilterTree()
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        Djdw.Model.Post.SYS_MENU obj = new Djdw.Model.Post.SYS_MENU();
        obj = handle.GetModel(0);
        TreeNode headnode = new TreeNode(obj.MOUDLENAME, obj.ID.ToString(), "", "", "");
        InitDatafilternodemenuTree(headnode, obj.ID.ToString());
        this._Datafilternodemenu.Nodes.Clear();
        this._Datafilternodemenu.Nodes.Add(headnode);
        this._Datafilternodemenu.ExpandAll();
    }

    private void InitDatafilternodemenuTree(TreeNode listnode, string parent)
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        string where_str = " parent='" + parent + "' and version=2 and syslevel>0";
        DataSet ds = handle.GetList(where_str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Djdw.Model.Post.SYS_MENU obj = new Djdw.Model.Post.SYS_MENU();
                obj.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                obj.MOUDLENAME = ds.Tables[0].Rows[i]["MOUDLENAME"].ToString();

                TreeNode node = new TreeNode(obj.MOUDLENAME, obj.ID.ToString(), "", "", "");
                listnode.ChildNodes.Add(node);
                //如果是叶子节点就加入数据集控制点
                if (IsDataFilterLeafNode(obj.ID.ToString()))
                {
                    InitDataFilterLeafNodes(node, obj.ID.ToString());
                }
                else
                {
                    InitDatafilternodemenuTree(node, obj.ID.ToString());
                }
            }
        }

    }

    private void InitDataFilterLeafNodes(TreeNode listnode, string parent)
    {
        Mis.BLL.ptgl.SYS_MOUDLEACTION handle = new Mis.BLL.ptgl.SYS_MOUDLEACTION();
        DataSet ds = handle.GetList(" isofdatafilter = 2 and moudlename='" + parent + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Mis.Model.ptgl.SYS_MOUDLEACTION obj = new Mis.Model.ptgl.SYS_MOUDLEACTION();
                obj.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());
                obj.ACTION = ds.Tables[0].Rows[i]["ACTION"].ToString();

                TreeNode node = new TreeNode(obj.ACTION, obj.ID.ToString(), "../Ima/menu/datafileternode.GIF", "", "");
                node.ToolTip = "数据集控制点";
               
                listnode.ChildNodes.Add(node);
                
            }
        }
        //t.isofdatafilter = 2 and t.moudlename='17'
    }

    private bool IsDataFilterLeafNode(string p_id)
    {
        Mis.BLL.ptgl.SYS_MENU handle = new Mis.BLL.ptgl.SYS_MENU();
        string where_str = " parent='" + p_id + "' and version=2 and syslevel>0";
        DataSet ds = handle.GetList(where_str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return false;
        }
        else
            return true;
    }

    protected void _Datafilternodemenu_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (this._Datafilternodemenu.SelectedNode.ToolTip.CompareTo("数据集控制点") == 0)
        {
            this.TB_DATAFILTERNAME.Text = this._Datafilternodemenu.SelectedNode.Text;

            string p_useridstr = this.Context.Request["id"].Trim();
            string p_datafilteridstr = this._Datafilternodemenu.SelectedNode.Value;
            BindDataFilterInfo(p_useridstr, p_datafilteridstr);
        }
        else
        {
            JS.Alert("请选择数据集控制点！",this);
        }
    }

    #endregion


    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("../sysuser/sys_usersselect.aspx");
    }

    protected void TV_DEPTUSER_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        if (this.TV_DEPTUSER.SelectedNode != null)
        {
            ChangeTreeNodeChecked(this.TV_DEPTUSER.SelectedNode, this.TV_DEPTUSER.SelectedNode.Checked);
        }
    }

    private void ChangeTreeNodeChecked(TreeNode node,bool p_status)
    {
        node.Checked = p_status;
        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            ChangeTreeNodeChecked(node.ChildNodes[i],p_status);
        }
    }

    protected void Bt_commit_Click(object sender, EventArgs e)
    {
        if (this._Datafilternodemenu.SelectedNode==null || this._Datafilternodemenu.SelectedNode.ToolTip.CompareTo("数据集控制点") != 0)
        {
            JS.Alert("请选择数据集控制点！",this);
            return ;
        }
        //////////////////////////////////////////////////////
        string p_useridstr = this.Context.Request["id"].Trim();
        string p_datafilteridstr = this._Datafilternodemenu.SelectedNode.Value;



        ArrayList sqllist = new ArrayList();
        string del_sql = "delete from SYS_DATASETRIGHT where DATASETRIGHTID='" + p_datafilteridstr + "' and USERID='" + p_useridstr + "'";
        sqllist.Add(del_sql);
        if(RB_DATAFILTERTYPE.SelectedValue.CompareTo("6") == 0)
        {
            //获取明细
            ArrayList p_deptlist = new ArrayList();
            ArrayList p_userlist = new ArrayList();
            GetAlldetailID(this.TV_DEPTUSER.Nodes[0], p_deptlist, p_userlist);
            for (int i = 0; i < p_deptlist.Count; i++)
            {
                string sql_str = "insert into SYS_DATASETRIGHT(id,datasetrightid,userid,rightscopetype,DETAILTYPE,DETAILID) values (SEQSYS_DATASETRIGHT.NEXTVAL,'" + p_datafilteridstr + "', '" + p_useridstr + "'," + RB_DATAFILTERTYPE.SelectedValue + ",1,'" + p_deptlist[i].ToString() + "')";
                sqllist.Add(sql_str);
            }
            for (int i = 0; i < p_userlist.Count; i++)
            {
                string sql_str = "insert into SYS_DATASETRIGHT(id,datasetrightid,userid,rightscopetype,DETAILTYPE,DETAILID) values (SEQSYS_DATASETRIGHT.NEXTVAL,'" + p_datafilteridstr + "', '" + p_useridstr + "'," + RB_DATAFILTERTYPE.SelectedValue + ",2,'" + p_userlist[i].ToString() + "')";
                sqllist.Add(sql_str);
            }
        }
        else
        {
            string sql_str = "insert into SYS_DATASETRIGHT(id,datasetrightid,userid,rightscopetype) values (SEQSYS_DATASETRIGHT.NEXTVAL,'" + p_datafilteridstr + "', '" + p_useridstr + "'," + RB_DATAFILTERTYPE.SelectedValue + ")";
            sqllist.Add(sql_str);
        }
        if (PageDBHelper.ExecuteSqlTran(sqllist) > 0)
        {
            JS.Alert("设置成功！", this);
        }
        else
            JS.Alert("设置失败！",this);
        /*1 所有数据   
        2 全公司数据   
        3 所在部门   
        4 所在工作组   
        5 仅本人   
        6 按明细设置   
        7 无 */

        
    }

    private void GetAlldetailID(TreeNode p_node, ArrayList p_deptlist, ArrayList p_userlist)
    {
        if (p_node.Checked == true)
        {
            if (p_node.ToolTip.CompareTo("用户") == 0)
            {
                p_userlist.Add(p_node.Value);
            }
            else
                p_deptlist.Add(p_node.Value);
        }

        for (int i = 0; i < p_node.ChildNodes.Count; i++)
        {
            GetAlldetailID(p_node.ChildNodes[i], p_deptlist, p_userlist);
        }
    }

    private void BindDataFilterInfo(string p_useridstr, string p_datafilteridstr)
    {
        VoidCheckDAUTree(this.TV_DEPTUSER.Nodes[0]);
        string sql_str = "select rightscopetype from sys_datasetright where DATASETRIGHTID='" + p_datafilteridstr + "' and USERID='" + p_useridstr + "'";
        object rightscopetype = PageDBHelper.GetSingleBySql(sql_str);
       
        if (rightscopetype != null && rightscopetype.ToString() != "")
        {
            RB_DATAFILTERTYPE.SelectedValue = rightscopetype.ToString();
            if (rightscopetype.ToString().CompareTo("6") == 0)
            {
                //DETAILTYPE = 1 为部门选择

                sql_str = "select detailid from sys_datasetright where DATASETRIGHTID='" + p_datafilteridstr + "' and USERID='" + p_useridstr + "' and DETAILTYPE=1";
                DataSet dept_ds = PageDBHelper.GetDataSetBySql(sql_str);
                if (dept_ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dept_ds.Tables[0].Rows.Count; i++)
                    {
                        string dept_idstr = dept_ds.Tables[0].Rows[i]["detailid"].ToString();
                        CheckDeptAndUserTree(this.TV_DEPTUSER.Nodes[0], 1, dept_idstr);
                    }
                }
                //DETAILTYPE = 2 为人员选择 
                sql_str = "select detailid from sys_datasetright where DATASETRIGHTID='" + p_datafilteridstr + "' and USERID='" + p_useridstr + "' and DETAILTYPE=2";
                DataSet user_ds = PageDBHelper.GetDataSetBySql(sql_str);
                if (user_ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < user_ds.Tables[0].Rows.Count; i++)
                    {
                        string user_idstr = user_ds.Tables[0].Rows[i]["detailid"].ToString();
                        CheckDeptAndUserTree(this.TV_DEPTUSER.Nodes[0], 2, user_idstr);
                    }
                }
            }//if
        }//if
    }//fun

    private void VoidCheckDAUTree(TreeNode p_node)
    {
        p_node.Checked = false;
        for (int i = 0; i < p_node.ChildNodes.Count; i++)
        {
            VoidCheckDAUTree(p_node.ChildNodes[i]);
        }
    }

    private void CheckDeptAndUserTree(TreeNode p_node, int p_detailtype, string p_detailid)
    {
        if (p_detailtype == 1)
        {
            if (p_node.ToolTip == "" && p_node.Value.CompareTo(p_detailid) == 0)
            {
                p_node.Checked = true; return;
            }
            for (int i = 0; i < p_node.ChildNodes.Count; i++)
            {
                CheckDeptAndUserTree(p_node.ChildNodes[i], p_detailtype, p_detailid);
            }
        }
        else if (p_detailtype == 2)
        {
            if (p_node.ToolTip == "用户" && p_node.Value.CompareTo(p_detailid) == 0)
            {
                p_node.Checked = true; return;
            }
            for (int i = 0; i < p_node.ChildNodes.Count; i++)
            {
                CheckDeptAndUserTree(p_node.ChildNodes[i], p_detailtype, p_detailid);
            }
        }
    }
}
