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

public partial class mip_pm_rightmanage_userrole : System.Web.UI.CePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            InitData();
            GetPermission();
        }
    }

    private bool Isofsetrole_Action;

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
        Isofsetrole_Action = _IsAuthorizedInaction("UserMng.action.update");
        this.Bt_submit.Enabled = Isofsetrole_Action;
        this.Bt_toleftallcommit.Enabled = Isofsetrole_Action;
        this.Bt_torightallcommit.Enabled = Isofsetrole_Action;
        this.Bt_torightonecommit.Enabled = Isofsetrole_Action;
        this.Bt_toleftonecommit.Enabled = Isofsetrole_Action;
    }

    protected ArrayList GetRolebyUserid(string p_userid)
    {
        ArrayList ret_list = new ArrayList();
        Mis.BLL.ptgl.SYS_ROLEUSER roleuser_handle = new Mis.BLL.ptgl.SYS_ROLEUSER();
        DataSet ds = roleuser_handle.GetList(" USERID = " + p_userid +" ");
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                ret_list.Add(ds.Tables[0].Rows[i]["ROLEID"].ToString());
            }
        }
        return ret_list;
    }

    protected void InitData()
    {
        //获取用户名
        this.Tb_USERNAME.Text = this.Context.Request["id"].Trim();
        Mis.BLL.ptgl.SYS_USERS handle = new Mis.BLL.ptgl.SYS_USERS();
        Mis.Model.ptgl.SYS_USERS obj = handle.GetModel(int.Parse(this.Tb_USERNAME.Text));
        this.Lb_EDITUSERNAME.Text =obj.USERREALNAME;

        //获取所有角色列表信息
        Mis.BLL.ptgl.SYS_ROLES role_handle = new Mis.BLL.ptgl.SYS_ROLES();
        DataSet ds  = role_handle.GetAllList();

        //
        ArrayList RolelistbyUserid = GetRolebyUserid(this.Tb_USERNAME.Text);
        this.Lb_noselet.Items.Clear();
        this.Lb_select.Items.Clear();

        if(ds!=null && ds.Tables[0]!=null && ds.Tables[0].Rows.Count>0)
        {
            Mis.Model.ptgl.SYS_ROLES[] allrolelist = role_handle.ToLocalData(ds.Tables[0]);
            //获取一个用户所有的角色信息列表
            for(int i=0;i<allrolelist.Length;i++)
            {
                ListItem item = new ListItem(allrolelist[i].USERNO, allrolelist[i].ID.ToString());//

                if (Isinlist(RolelistbyUserid, allrolelist[i].ID.ToString()) == true)
                {
                    //已经被选中
                    Lb_select.Items.Add(item);
                }
                else
                {
                    //没有选中
                  Lb_noselet.Items.Add(item);
                }
            }//for
        }//if
        
    }

    protected bool Isinlist(ArrayList p_RolelistbyUserid,string p_roleid)
    {
        for (int i = 0; i < p_RolelistbyUserid.Count; i++) 
        {
            if (p_RolelistbyUserid[i].ToString().CompareTo(p_roleid) == 0)
                return true;
        }
        return false;
    }


    protected void Bt_torightallcommit_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.Lb_noselet.Items.Count; i++)
        {
            ListItem sel_item = this.Lb_noselet.Items[i];
            if (sel_item != null)
            {
                this.Lb_select.Items.Add(sel_item);
                sel_item.Selected = false;

            }
        }
        this.Lb_noselet.Items.Clear();

    }
    protected void Bt_toleftallcommit_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.Lb_select.Items.Count; i++)
        {
            ListItem sel_item = this.Lb_select.Items[i];
            if (sel_item != null)
            {
                this.Lb_noselet.Items.Add(sel_item);
                sel_item.Selected = false;

            }
        }
        this.Lb_select.Items.Clear();
      
    }
    protected void Bt_toleftonecommit_Click(object sender, EventArgs e)
    {
        ListItem sel_item = this.Lb_select.SelectedItem;
        if (sel_item != null)
        {
            this.Lb_noselet.Items.Add(sel_item);
            sel_item.Selected = false;
            this.Lb_select.Items.Remove(sel_item);
        }
    }
    protected void Bt_torightonecommit_Click(object sender, EventArgs e)
    {
        ListItem sel_item = this.Lb_noselet.SelectedItem;
        if (sel_item != null)
        {
            this.Lb_select.Items.Add(sel_item);
            sel_item.Selected = false;
            this.Lb_noselet.Items.Remove(sel_item);
        }
    }

    protected void Bt_submit_Click(object sender, EventArgs e)
    {
        Mis.BLL.ptgl.SYS_ROLEUSER handle = new Mis.BLL.ptgl.SYS_ROLEUSER();
        
        string userid = this.Tb_USERNAME.Text;
        ArrayList sqllist = new ArrayList();

        DictionaryEntry de = handle.DeleteUserRole(int.Parse(userid));
        sqllist.Add(de);

        for (int i = 0; i < this.Lb_select.Items.Count; i++)
        {
            string roleid_str = this.Lb_select.Items[i].Value;
            Mis.Model.ptgl.SYS_ROLEUSER obj = new Mis.Model.ptgl.SYS_ROLEUSER();
            obj.DESCRIPTION = "";
            obj.ROLEID = int.Parse(roleid_str);
            obj.USERID = int.Parse(userid);

            de = handle.AddSql(obj);
            sqllist.Add(de);
        }

        if (0 < handle.ExecuteSqlTranByArray(sqllist))
        {
            JS.Alert("提交成功!", this);
        }
        else
        {
            JS.Alert("提交失败!", this);
        }
    }
    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("../sysuser/sys_usersselect.aspx");
    }
}
