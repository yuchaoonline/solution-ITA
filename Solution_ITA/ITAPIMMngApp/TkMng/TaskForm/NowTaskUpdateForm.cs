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
    public partial class NowTaskUpdateForm : Form
    {
        private GMngMainForm m_mainform = null;

        private string m_TaskID = "";
        

        public NowTaskUpdateForm()
        {
            InitializeComponent();
            this.RB_IsofHistory_1.Enabled = false;
            this.RB_IsofHistory_2.Enabled = false;
        }

        public void SetMainForm(GMngMainForm p_mainform)
        {
            m_mainform = p_mainform;

        }

        public void SetTaskID(string p_Taskid)
        {
            m_TaskID = p_Taskid;
        }

        private void NowTaskUpdateForm_Load(object sender, EventArgs e)
        {
            if (m_TaskID != "")
            {
                hbapp.BLL.ghdata.GH_TASKINFO handle = new hbapp.BLL.ghdata.GH_TASKINFO();
                hbapp.Model.ghdata.GH_TASKINFO model = handle.GetModel(int.Parse(m_TaskID));

                this.TB_ID.Text = model.ID.ToString();

                this.TB_TaskNo.Text = model.TASKNO; //任务编号
                this.TB_CTVNo.Text = model.CTVNO; ; //货船编号

                this.TB_TaskName.Text = model.TASKNAME; //任务名称
                this.TB_StartTime.Text = model.STARTTIME; //任务开始时间
                this.TB_EndTime.Text = model.ENDTIME; //任务结束时间

                if (model.TASKTYPE == 1)//任务类型
                {
                    this.RB_TaskType_1.Checked = true;
                }
                else
                    this.RB_TaskType_2.Checked = true;


                if (model.ISOFHISTORY == 1)//是否转为历史
                {
                    this.RB_IsofHistory_1.Checked = true;
                }
                else
                    this.RB_IsofHistory_2.Checked = true;

                this.TB_Remark.Text = model.REMARK; //备注
            }
        }

        private bool ValidateInput()
        {
            return true;
        }


        private void bt_submit_Click(object sender, EventArgs e)
        {
            if (false == ValidateInput()) return;
            hbapp.BLL.ghdata.GH_TASKINFO handle = new hbapp.BLL.ghdata.GH_TASKINFO();
            hbapp.Model.ghdata.GH_TASKINFO model = new hbapp.Model.ghdata.GH_TASKINFO();
            model.ID = int.Parse(m_TaskID);
            model.TASKNO = this.TB_TaskNo.Text; //项目编号
            model.CTVNO = this.TB_CTVNo.Text; ; //标准编号
            model.TASKNAME = this.TB_TaskName.Text; //任务名称
            model.STARTTIME = this.TB_StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"); //项目开始时间
            model.ENDTIME = this.TB_EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"); //项目结束时间
            if (this.RB_TaskType_1.Checked)
            {
                model.TASKTYPE = 1; //项目类型
            }
            else
                model.TASKTYPE = 2;
            if (this.RB_IsofHistory_1.Checked)
            {
                model.ISOFHISTORY = 1; //是否转为历史
            }
            else
                model.ISOFHISTORY = 2;
            model.REMARK = this.TB_Remark.Text; //备注
            model.REMARK1 = ""; //备注1
            model.REMARK2 = ""; //备注2
            model.REMARK3 = ""; //备注3
            model.REMARK4 = ""; //备注4
            model.REMARK5 = ""; //备注5
            model.REMARK6 = ""; //备注6
            model.REMARK7 = ""; //备注7
            model.REMARK8 = ""; //备注8
            model.REMARK9 = ""; //备注9
            model.REMARK10 = ""; //备注10
            model.REMARK11 = ""; //备注11
            model.REMARK12 = ""; //备注12
            model.REMARK13 = ""; //备注13
            model.REMARK14 = ""; //备注14
            model.REMARK15 = ""; //备注15

            int ret_value = handle.Update(model);
            if (ret_value > 0)
            {
                if (m_mainform != null) m_mainform.RefreshLeftWindows();
                MessageBox.Show("修改成功！", "成功");
            }
            else
                MessageBox.Show("修改失败！", "失败");
        }

        private void bt_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}