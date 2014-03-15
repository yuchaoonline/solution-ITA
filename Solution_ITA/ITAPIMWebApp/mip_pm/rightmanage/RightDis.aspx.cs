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

public partial class mip_pm_rightmanage_RightDis : System.Web.UI.CePage
{
    ArrayList HadMenuRightlist  =  null;

    ArrayList HadActionRightlist = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        this._isallowaccess("", "8", "");
        if(!IsPostBack)
        {
            HadMenuRightlist = new ArrayList();
            HadActionRightlist = new ArrayList();
            BindDwinfo();
            lb_QxCklist.Text = GetAllInfo();

            GetPermission();
        }
    }

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
        Isofright_Action = _IsAuthorizedInaction("Rolemng.action.update");
        this.Bt_commit.Enabled = Isofright_Action;
    }

    /// <summary>
    /// 通过角色ID获取所有权限
    /// </summary>
    /// <param name="p_roleid"></param>
    /// <returns></returns>
    protected ArrayList GetRightbyroleid(string p_roleid)
    {
        ArrayList ret_list = new ArrayList();
        Mis.BLL.ptgl.SYS_ROLEPLMENUSRIGHTS roleuser_handle = new Mis.BLL.ptgl.SYS_ROLEPLMENUSRIGHTS();
        DataSet ds = roleuser_handle.GetList(" roleplid = " + p_roleid + " ");
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ret_list.Add(ds.Tables[0].Rows[i]["menuid"].ToString());
            }
        }
        return ret_list;
    }

    /// <summary>
    /// 通过角色获取到角色的动作权限
    /// </summary>
    /// <param name="p_roleid"></param>
    /// <returns></returns>
    private ArrayList GetActionRightByroleid(string p_roleid)
    {
        ArrayList ret_list = new ArrayList();
        Mis.BLL.ptgl.SYS_ROLEACTRIGHTS roleuser_handle = new Mis.BLL.ptgl.SYS_ROLEACTRIGHTS();
        DataSet ds = roleuser_handle.GetList(" roleplid = " + p_roleid + " ");
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ret_list.Add(ds.Tables[0].Rows[i]["actionid"].ToString());
            }
        }
        return ret_list;
    }

    protected void BindDwinfo()
    {

        this.TB_ID.Text = this.Context.Request["id"].Trim();

        Mis.BLL.ptgl.SYS_ROLES handle = new Mis.BLL.ptgl.SYS_ROLES();
        Mis.Model.ptgl.SYS_ROLES obj = handle.GetModel(int.Parse(this.TB_ID.Text));
        TB_ID.Text = obj.ID.ToString();

        TB_ROLENO.Text = obj.ROLENO;

        TB_USERNO.Text = obj.USERNO;

        TB_DESCRIPTION.Text = obj.DESCRIPTION;

        HadMenuRightlist = GetRightbyroleid(this.TB_ID.Text);

        HadActionRightlist = GetActionRightByroleid(this.TB_ID.Text);
    }

    protected void InitCklistData()
    {
        lb_QxCklist.Text = "";
    }

    //获取一级模块数量
    protected Djdw.Model.Post.SYS_MENU[] GetModuleClass()
    {
        string sql_str = "select id,moudlename from sys_menu t where syslevel=1 and version=2 order by id";
        DataSet ds = GetDataSetBySql(sql_str);
        if(ds!=null && ds.Tables[0]!=null &&ds.Tables[0].Rows.Count>0)
        {
            Djdw.Model.Post.SYS_MENU[] list = new Djdw.Model.Post.SYS_MENU[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                Djdw.Model.Post.SYS_MENU obj = new Djdw.Model.Post.SYS_MENU();
                obj.ID = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                obj.MOUDLENAME = ds.Tables[0].Rows[i]["moudlename"].ToString();
                list[i] = obj;
            }
            return list;
        }
        return null;
    }

    protected string GetAllInfo()
    {
        Djdw.Model.Post.SYS_MENU[] modulelist = GetModuleClass();
        
        int allclassnum = 0;
        if (modulelist != null) allclassnum = modulelist.Length;

        int alltrnum = allclassnum/1;
        if(allclassnum%1>0)alltrnum+=1;

        string allinfos = " <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";

        int p_index = 0;
        for(int i=0;i<alltrnum;i++)
        {
            allinfos += "<tr valign=\"top\">";
            //第1列
            allinfos+="<td width=\"5%\"></td>";
            //第2列
            allinfos += "<td width=\"95%\">";
            if (p_index < allclassnum) { allinfos += GetModuleInfo(p_index + 1, modulelist[p_index].ID.ToString(), modulelist[p_index].MOUDLENAME); }
            p_index++;
            allinfos +="</td>";
            //第3列
            //allinfos += "<td width=\"50%\">";
            //if (p_index < allclassnum) { allinfos += GetModuleInfo(p_index + 1, modulelist[p_index].ID.ToString(), modulelist[p_index].MOUDLENAME); }
            //p_index++;
            //allinfos += "</td>";
            //第4列
            //allinfos += "<td width=\"30%\">";
            //if (p_index < allclassnum) { allinfos += GetModuleInfo(p_index + 1, modulelist[p_index].ID.ToString(), modulelist[p_index].MOUDLENAME); }
            //p_index++;
            //allinfos += "</td>";
            allinfos += "</tr>";
           
        }
        allinfos += "</table>";
        return allinfos;
    }


    //获取一级模组下所有二级模块信息
    protected string GetModuleInfo(int p_index, string p_id, string p_modulename)
    {
        string sql_str = "select id,moudlename,url,img from sys_menu t where syslevel=2  and version=2  and parent='" + p_id + "' order by id";
        DataSet ds = GetDataSetBySql(sql_str);
        string allinfos = "";
        //
        allinfos += "<h5><img src=\"moduleimg/" + p_index.ToString() + ".png\" style=\"width: 20px; height: 20px\" />" + p_modulename + "</h5>";
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string moudlename = ds.Tables[0].Rows[i]["moudlename"].ToString();
                string idstr = ds.Tables[0].Rows[i]["id"].ToString();
                if (this.Ishadright(idstr) == true)
                {
                    allinfos += "<input type=\"checkbox\" name=\"box\" value=\"" + idstr + "\" checked>" + moudlename;
                }
                else
                {
                    allinfos += "<input type=\"checkbox\" name=\"box\" value=\"" + idstr + "\">" + moudlename;
                }

                string actionstrs = GetActionInfo(idstr);
                if (actionstrs != "") allinfos += " ( "+actionstrs+" )";

                allinfos += "<br />";
            }
        }

        return allinfos;
    }

    protected string GetActionInfo(string p_moudleid)
    {

        string sql_str = "select id,moudlename,action,description from sys_moudleaction t where moudlename='" + p_moudleid + "' and isofdatafilter=1 order by id";
        DataSet ds = GetDataSetBySql(sql_str);
        string allinfos = "";

        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            int spanrownum = 3;
            if (ds.Tables[0].Rows.Count > 3) spanrownum = 2;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string actionname = ds.Tables[0].Rows[i]["action"].ToString();
                string idstr = ds.Tables[0].Rows[i]["id"].ToString();
                if (this.IsHadActionRight(idstr) == true)
                {
                    allinfos += "<input type=\"checkbox\" name=\"actionbox\" value=\"" + idstr + "\" checked>" + actionname;
                }
                else
                {
                    allinfos += "<input type=\"checkbox\" name=\"actionbox\" value=\"" + idstr + "\">" + actionname;
                }
                allinfos += "";
                if (i <= 3)
                {
                    spanrownum = 3;
                    if (i > 0 && (((i + 1) % spanrownum) == 0)) allinfos += "<br/>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;";
                }
                else
                {
                    spanrownum = 2;
                    if (i > 0 && (((i-3 + 1) % spanrownum) == 0)) allinfos += "<br/>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;";
                    
                }
                
            }
        }
        return allinfos;
        //"  |__";
    }

    protected bool Ishadright(string p_id)
    {
        for(int i=0;i<HadMenuRightlist.Count;i++)
        {
            if (HadMenuRightlist[i].ToString().CompareTo(p_id) == 0)
                return true;
        }
        return false;
    }

    protected bool IsHadActionRight(string p_id)
    {
        for (int i = 0; i < HadActionRightlist.Count; i++)
        {
            if (HadActionRightlist[i].ToString().CompareTo(p_id) == 0)
                return true;
        }
        return false;
    }

    protected void Bt_commit_Click(object sender, EventArgs e)
    {
        ArrayList sqllist = new ArrayList();

        //管理角色和菜单的权限关系
        Mis.BLL.ptgl.SYS_ROLEPLMENUSRIGHTS roleuser_handle = new Mis.BLL.ptgl.SYS_ROLEPLMENUSRIGHTS();
        
        DictionaryEntry de = roleuser_handle.DeleteByroleid(int.Parse(this.TB_ID.Text));
        sqllist.Add(de);
        if (!string.IsNullOrEmpty(Request["box"]))
        {
            //JS.Alert(Request["box"], this);
            string right_str= Request["box"];
            string[] rightlist = right_str.Split(',');

            for(int i=0;i<rightlist.Length;i++)
            {
                Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS model = new Mis.Model.ptgl.SYS_ROLEPLMENUSRIGHTS();
                model.ROLEPLID = int.Parse(this.TB_ID.Text);
                model.MENUID = int.Parse(rightlist[i]);
                model.ROLESNAME = 1;
                model.TYPE = 1;
                DictionaryEntry de1 = roleuser_handle.AddSql(model);
                sqllist.Add(de1);
            }//for
        }//if

        //管理角色和动作的权限管理

        Mis.BLL.ptgl.SYS_ROLEACTRIGHTS roleaction_handle = new Mis.BLL.ptgl.SYS_ROLEACTRIGHTS();
        DictionaryEntry action_de = roleaction_handle.DeleteByroleid(int.Parse(this.TB_ID.Text));
        sqllist.Add(action_de);
        if (!string.IsNullOrEmpty(Request["actionbox"]))
        {
            //JS.Alert(Request["box"], this);
            string actionright_str = Request["actionbox"];
            string[] actionrightlist = actionright_str.Split(',');

            for (int i = 0; i < actionrightlist.Length; i++)
            {
                Mis.Model.ptgl.SYS_ROLEACTRIGHTS model = new Mis.Model.ptgl.SYS_ROLEACTRIGHTS();
                model.ROLEPLID = int.Parse(this.TB_ID.Text);
                model.ACTIONID = int.Parse(actionrightlist[i]);
                model.ROLESNAME = 1;
                model.TYPE = 1;
                DictionaryEntry action_de1 = roleaction_handle.AddSql(model);
                sqllist.Add(action_de1);
            }//for
        }//if

        if (0 < roleuser_handle.ExecuteSqlTranByArray(sqllist))
        {
            HadMenuRightlist = new ArrayList();
            BindDwinfo();
            lb_QxCklist.Text = GetAllInfo();
            JS.Alert("提交成功!", this);
        }
        else
        {
            HadMenuRightlist = new ArrayList();
            BindDwinfo();
            lb_QxCklist.Text = GetAllInfo();
            JS.Alert("提交失败!", this);
        }
    }

    protected void Bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("../sysrole/sys_rolesselect.aspx");
    }

    private DataSet GetDataSetBySql(string sql)
    {
        return PageDBHelper.GetDataSetBySql(sql);
    }
}
