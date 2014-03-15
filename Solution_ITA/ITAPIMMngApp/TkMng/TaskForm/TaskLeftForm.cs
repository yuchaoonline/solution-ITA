using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ITAMngApp.TkMng.TaskForm
{
    public partial class TaskLeftForm : DockContent
    {
        public TaskLeftForm()
        {
            InitializeComponent();
            base.ShowHint = DockState.DockLeft;
            this.RB_IsofHistory_1.Checked = true;
        }

        private void bt_select_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        public void DataBind()
        {
            string where_str = "";
            if (this.TB_TaskNo.Text != "")
            {
                where_str += " and TASKNO like '%" + this.TB_TaskNo.Text + "%'";
            }
            if (this.RB_IsofHistory_1.Checked == true)
            {
                where_str += " and ISOFHISTORY = 1";
            }
            if (this.RB_IsofHistory_2.Checked == true)
            {
                where_str += " and ISOFHISTORY = 2";
            }
            if (where_str.Length > 5)
            {
                where_str = where_str.Substring(5);
            }
            DataBind(where_str);
        }

        private void DataBind(string p_strwhere)
        {
            hbapp.BLL.ghdata.GH_TASKINFO handle = new hbapp.BLL.ghdata.GH_TASKINFO();
            DataSet ds = handle.GetList(p_strwhere);

            this.Lv_TaskinfoList.Items.Clear();
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems[0].Text = ds.Tables[0].Rows[i]["ID"].ToString();
                    item.SubItems.Add(ds.Tables[0].Rows[i]["TASKNO"].ToString());
                    item.SubItems.Add(ds.Tables[0].Rows[i]["CTVNO"].ToString());
                    item.SubItems.Add(ds.Tables[0].Rows[i]["TASKNAME"].ToString());
                    string m_tasktype = ds.Tables[0].Rows[i]["TASKTYPE"].ToString();
                    if (m_tasktype == "1")
                    {
                        item.SubItems.Add("仿真项目");
                    }
                    else
                        item.SubItems.Add("实际项目");
                    if (i % 2 == 1)
                    {
                        item.BackColor = System.Drawing.Color.FromArgb(254, 222, 202);//设置交替行的背景颜色
                    }
                    Lv_TaskinfoList.Items.Add(item);
                }
            }

        }

        public ListView p_Lv_TaskinfoList
        {
            get
            {
                return this.Lv_TaskinfoList;
            }
        }

        public TextBox p_TB_SelectTaskNo
        {
            get
            {
                return this.TB_SelectTaskNo;
            }
        }

        public TextBox p_TB_SelectID
        {
            get
            {
                return this.TB_SelectID;
            }
        }

        public System.Windows.Forms.Button Bt_select
        {
            get { return bt_select; }
        }

        private void TaskLeftForm_Load(object sender, EventArgs e)
        {

        }
    }
}