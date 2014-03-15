using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ITAMngApp.TkMng.TaskForm
{
    public partial class NowTaskAddForm : Form
    {
        private GMngMainForm m_mainform = null;

        public NowTaskAddForm()
        {
            InitializeComponent();
        }

        private void NowTaskAddForm_Load(object sender, EventArgs e)
        {
            this.RB_TaskType_1.Checked = true;
            this.RB_IsofHistory_1.Checked = true;
            this.RB_IsofHistory_1.Enabled = false;
            this.RB_IsofHistory_2.Enabled = false;
            this.TB_StartTime.Value = DateTime.Now;
            this.TB_EndTime.Value = DateTime.Now;
        }


        public void SetMainForm(GMngMainForm p_mainform)
        {
            m_mainform = p_mainform;
            
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
            model.TASKNO = this.TB_TaskNo.Text; //项目编号
            model.CTVNO = this.TB_CTVNo.Text; ; //标准编号
            model.TASKNAME = this.TB_TaskName.Text; //项目名称

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

            int ret_value = handle.AddNotall(model);
            if (ret_value > 0)
            {
                if (m_mainform != null) m_mainform.RefreshLeftWindows();
                MessageBox.Show("添加成功！", "成功");
            }
            else
                MessageBox.Show("添加失败！", "失败");
        }


        private void bt_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}