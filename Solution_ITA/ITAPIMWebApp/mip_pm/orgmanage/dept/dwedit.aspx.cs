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

    public partial class infoplatform_orgmanage_dept_dwedit : CePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this._isallowaccess("", "9", "");

            if (!IsPostBack)
            {
                this.syslevel.Enabled = false;
                TransPage();
                string action = this.Context.Request["action"];
                string node = this.Context.Request["node"];
                GetPermission();
                if (action != null && node != null)
                {
                    if (action.Equals("add") == true)
                    {
                        lb_action.Text = "add";
                        addview(node);
                        this.submit.Enabled = this.IsofAdd_Action;
                    }
                    else if (action.Equals("edit") == true)
                    {
                        lb_action.Text = "edit";
                        editview(node);
                        this.submit.Enabled = this.IsofUpdate_Action;
                    }
                    else if (action.Equals("delete") == true)
                    {
                        lb_action.Text = "delete";
                        deleteview(node);
                        this.submit.Enabled = this.IsofDelete_Action;
                    }
                    else
                    {

                    }
                }
                //

                //
            }
        }

        private bool IsofAdd_Action;
        private bool IsofDelete_Action;
        private bool IsofUpdate_Action;

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

            IsofDelete_Action = _IsAuthorizedInaction("Deptmng.action.update");

            IsofUpdate_Action = _IsAuthorizedInaction("Deptmng.action.update");

            
        }


        private void TransPage()
        {
            string Sylever = "级";//级
            ListItem Item0 = new ListItem();
            Item0.Text = Sylever + "0";
            Item0.Value = "0";
            ListItem Item1 = new ListItem();
            Item1.Text = Sylever + "1";
            Item1.Value = "1";
            ListItem Item2 = new ListItem();
            Item2.Text = Sylever + "2";
            Item2.Value = "2";
            ListItem Item3 = new ListItem();
            Item3.Text = Sylever + "3";
            Item3.Value = "3";
            ListItem Item4 = new ListItem();
            Item4.Text = Sylever + "4";
            Item4.Value = "4";
            ListItem Item5 = new ListItem();
            Item5.Text = Sylever + "5";
            Item5.Value = "5";
            ListItem Item6 = new ListItem();
            Item6.Text = Sylever + "6";
            Item6.Value = "6";
            ListItem Item7 = new ListItem();
            Item7.Text = Sylever + "7";
            Item7.Value = "7";
            this.syslevel.Items.Clear();
            this.syslevel.Items.Add(Item0);
            this.syslevel.Items.Add(Item1);
            this.syslevel.Items.Add(Item2);
            this.syslevel.Items.Add(Item3);
            this.syslevel.Items.Add(Item4);
            this.syslevel.Items.Add(Item5);
            this.syslevel.Items.Add(Item6);
            this.syslevel.Items.Add(Item7);


        }
        
        private void addview(string node)
        {
            if ("0" == node)
            {
                //添加系统名称
                this.parent.Text = "0";
                this.syslevel.SelectedValue = "0";



            }
            else
            {
                this.parent.Text = node;
                Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
                Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
                obj = handle.GetModel(int.Parse(node));
                id.Text = handle.GetMaxId().ToString();
                int syslevel = int.Parse(obj.SYSLEVEL) + 1;//从父级别中增加一个级别,然后
                this.syslevel.SelectedValue = syslevel.ToString();

                //添加其他名称
            }
        }

        private void editview(string node)
        {
            if ("0" != node)
            {
                Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
                Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
                obj = handle.GetModel(int.Parse(node));
                this.id.Text = obj.ID.ToString();
                this.departid.Text = obj.DEPTNO;
                this.departname.Text = obj.DEPTNAME;
                this.description.Text = obj.DESCRIPTION;
                this.parent.Text = obj.PARENTID.ToString();
                this.syslevel.SelectedValue = obj.SYSLEVEL;
            }

        }

        private void deleteview(string node)
        {

        }

        /// <summary>
        /// 做输入有效性判断
        /// </summary>
        /// <returns></returns>
        private bool Isputvalid()
        {
            if (this.departid.Text.Trim() == "")
            {
                JS.Alert("部门编号不能为空！", this);
                return false;
            }
            if (this.departname.Text.Trim() == "")
            {
                JS.Alert("部门名称不能为空！", this);
                return false;
            }
            if (this.departid.Text.Length > 15)
            {
                JS.Alert("部门编号过长，长度不能超过15！", this);
                return false;
            }
            if (this.departname.Text.Length > 15)
            {
                JS.Alert("部门名称过长，长度不能超过15！", this);
                return false;
            }
            if (this.description.Text.Length > 100)
            {
                JS.Alert("部门描述过长，长度不能超过100！", this);
                return false;
            }
            return true;
        }

        protected void submit_Click(object sender, ImageClickEventArgs e)
        {
            if (lb_action.Text == "add")
            {
                if (false == Isputvalid())
                {
                    return;
                }
                Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
                obj.ID = int.Parse(this.id.Text);
                obj.PARENTID = int.Parse(this.parent.Text);
                obj.SYSLEVEL = this.syslevel.SelectedValue;
                obj.DEPTNO = this.departid.Text.Trim();
                obj.DEPTNAME = this.departname.Text.Trim();
                obj.DESCRIPTION = this.description.Text.Trim();

                Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
                if (handle.Add(obj) > 0)
                {
                    JS.Alert("添加部门成功", this);//添加部门成功
                    
                }
            }
            else if (lb_action.Text == "edit")
            {
                if (false == Isputvalid())
                {
                    return;
                }
                Mis.Model.ptgl.SYS_DEPARTMENT obj = new Mis.Model.ptgl.SYS_DEPARTMENT();
                obj.ID = int.Parse(this.id.Text);
                obj.PARENTID = int.Parse(this.parent.Text);
                obj.SYSLEVEL = this.syslevel.SelectedValue;
                obj.DEPTNO = this.departid.Text.Trim();
                obj.DEPTNAME = this.departname.Text.Trim();
                obj.DESCRIPTION = this.description.Text.Trim();
                Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
                if (false == IsofDeptInDb(obj.ID.ToString()))
                {
                    JS.Alert("对不起，该部门已被删除，请选择其他部门",this);
                    return;
                }
                try
                {
                    handle.Update(obj);
                    JS.Alert("部门信息更新成功", this);//部门信息更新成功
                   
                }
                catch
                {
                    JS.Alert("部门信息更新失败", this);//部门信息更新失败
                   
                }
            }
            else
                ;
            //刷新前一个列表
            Response.Write("<script language=javascript>window.parent.frames[\"menuconfig_left\"].location.href=\"dwindex.aspx?action=refresh\";</script>");
        }

        private bool IsofDeptInDb(string p_deptid)
        {
            Mis.BLL.ptgl.SYS_DEPARTMENT handle = new Mis.BLL.ptgl.SYS_DEPARTMENT();
            if (null == handle.GetModel(int.Parse(p_deptid)))
            {
                return false;
            }
            else
                return true;
        }

}
