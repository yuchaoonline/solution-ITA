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

                this.TB_TaskNo.Text = model.TASKNO; //������
                this.TB_CTVNo.Text = model.CTVNO; ; //�������

                this.TB_TaskName.Text = model.TASKNAME; //��������
                this.TB_StartTime.Text = model.STARTTIME; //����ʼʱ��
                this.TB_EndTime.Text = model.ENDTIME; //�������ʱ��

                if (model.TASKTYPE == 1)//��������
                {
                    this.RB_TaskType_1.Checked = true;
                }
                else
                    this.RB_TaskType_2.Checked = true;


                if (model.ISOFHISTORY == 1)//�Ƿ�תΪ��ʷ
                {
                    this.RB_IsofHistory_1.Checked = true;
                }
                else
                    this.RB_IsofHistory_2.Checked = true;

                this.TB_Remark.Text = model.REMARK; //��ע
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
            model.TASKNO = this.TB_TaskNo.Text; //��Ŀ���
            model.CTVNO = this.TB_CTVNo.Text; ; //��׼���
            model.TASKNAME = this.TB_TaskName.Text; //��������
            model.STARTTIME = this.TB_StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"); //��Ŀ��ʼʱ��
            model.ENDTIME = this.TB_EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"); //��Ŀ����ʱ��
            if (this.RB_TaskType_1.Checked)
            {
                model.TASKTYPE = 1; //��Ŀ����
            }
            else
                model.TASKTYPE = 2;
            if (this.RB_IsofHistory_1.Checked)
            {
                model.ISOFHISTORY = 1; //�Ƿ�תΪ��ʷ
            }
            else
                model.ISOFHISTORY = 2;
            model.REMARK = this.TB_Remark.Text; //��ע
            model.REMARK1 = ""; //��ע1
            model.REMARK2 = ""; //��ע2
            model.REMARK3 = ""; //��ע3
            model.REMARK4 = ""; //��ע4
            model.REMARK5 = ""; //��ע5
            model.REMARK6 = ""; //��ע6
            model.REMARK7 = ""; //��ע7
            model.REMARK8 = ""; //��ע8
            model.REMARK9 = ""; //��ע9
            model.REMARK10 = ""; //��ע10
            model.REMARK11 = ""; //��ע11
            model.REMARK12 = ""; //��ע12
            model.REMARK13 = ""; //��ע13
            model.REMARK14 = ""; //��ע14
            model.REMARK15 = ""; //��ע15

            int ret_value = handle.Update(model);
            if (ret_value > 0)
            {
                if (m_mainform != null) m_mainform.RefreshLeftWindows();
                MessageBox.Show("�޸ĳɹ���", "�ɹ�");
            }
            else
                MessageBox.Show("�޸�ʧ�ܣ�", "ʧ��");
        }

        private void bt_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}