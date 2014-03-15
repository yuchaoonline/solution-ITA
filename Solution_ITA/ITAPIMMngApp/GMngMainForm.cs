using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GMngMainForm.SysDb;
using ITAMngApp.TkMng.TaskForm;
using ITAMngApp.TkMng.PropForm;
using ITAMngApp.CmMng.ServForm;
using System.Collections;
using WeifenLuo.WinFormsUI.Docking;
using ITAMngApp.CmMng;
using SCAATSoft.CommFramework;
using ITAMngApp.ApplicationFun;

namespace ITAMngApp
{
    public partial class GMngMainForm : Form
    {
        //对象属性窗体
        private PropertyWindow m_propertyWindow = null;

        //任务导航窗体
        private TaskLeftForm m_taskleftWindow = null;

        //通讯服务信息窗体
        private CommServForm m_commservWindow = null;

        //通讯细节窗体
        private CommDetailForm m_commdetailWindow = null;

        //测试窗体
        private ITAToolForm m_itatoolWindow = null;

        public GMngMainForm()
        {
            Program.MainApp = this;
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        //页面初始化
        private void GMngMainForm_Load(object sender, EventArgs e)
        {
            m_propertyWindow = new PropertyWindow();
            m_propertyWindow.Show(this.dockPanel1);

            m_taskleftWindow = new TaskLeftForm();
            m_taskleftWindow.Show(this.dockPanel1);

            m_commservWindow = new CommServForm();
            m_commservWindow.Show(this.dockPanel1);

            m_commdetailWindow = new CommDetailForm();
            m_commdetailWindow.Show(this.dockPanel1);

            m_itatoolWindow = new ITAToolForm();
            m_itatoolWindow.SetParentForm(this);
            m_itatoolWindow.Show(this.dockPanel1);

            CommServViewFun();

            this.m_taskleftWindow.p_Lv_TaskinfoList.SelectedIndexChanged += new System.EventHandler(this.TaskleftWin_TaskinfoList_SelectedIndexChanged);

            DisconnMenuListEnabled();
        }


        private void TaskleftWin_TaskinfoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_taskleftWindow.p_Lv_TaskinfoList.SelectedItems.Count > 0)
            {
                int count = this.m_taskleftWindow.p_Lv_TaskinfoList.SelectedItems.Count;
                string ID_str = this.m_taskleftWindow.p_Lv_TaskinfoList.SelectedItems[0].SubItems[0].Text;
                string TaskNo_str = this.m_taskleftWindow.p_Lv_TaskinfoList.SelectedItems[0].SubItems[1].Text;
                this.m_taskleftWindow.p_TB_SelectID.Text = ID_str;
                this.m_taskleftWindow.p_TB_SelectTaskNo.Text = TaskNo_str;
                //SelBMSClientMenuListEnabled();
                //设置相关属性窗口
                InitTaskProtery();
                
            }
            else
            {
                this.m_taskleftWindow.p_TB_SelectID.Text = "";
                this.m_taskleftWindow.p_TB_SelectTaskNo.Text = "";
                //ConnectDBMenuListEnabled();
                InitTaskProtery();
            }
        }


        private void InitTaskProtery()
        {
            this.m_propertyWindow.propertyGrid.ShowCustomProperties = true;
            this.m_propertyWindow.propertyGrid.Item.Clear();
            string selid_str = this.m_taskleftWindow.p_TB_SelectID.Text;
            if (selid_str != "")
            {
                hbapp.BLL.ghdata.GH_TASKINFO handle = new hbapp.BLL.ghdata.GH_TASKINFO();
                hbapp.Model.ghdata.GH_TASKINFO m_model = handle.GetModel(int.Parse(selid_str));
                if (m_model != null)
                {
                    this.m_propertyWindow.propertyGrid.Item.Add("编号", m_model.ID.ToString(), true, "基本参数", "编号为检索数据库的依据", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目编号", m_model.TASKNO, true, "基本参数", "项目编号为项目初始化的编号", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("标准编号", m_model.CTVNO, true, "基本参数", "标准编号为项目关联的标准编号", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目名称", m_model.TASKNAME, true, "基本参数", "项目名称为项目的名称，便于标识", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目开始时间", m_model.STARTTIME, true, "基本参数", "项目的具体开始时间", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目结束时间", m_model.ENDTIME, true, "基本参数", "项目的具体结束时间", true);
                    string temp_str = "";
                    if (m_model.TASKTYPE == 1)
                    {
                        temp_str = "仿真项目";
                    }
                    else
                        temp_str = "实际项目";
                    this.m_propertyWindow.propertyGrid.Item.Add("项目类型", temp_str, true, "基本参数", "项目类型分为仿真项目和实际项目", true);

                    if (m_model.ISOFHISTORY == 1)
                    {
                        temp_str = "现行项目";
                    }
                    else
                        temp_str = "历史项目";
                    this.m_propertyWindow.propertyGrid.Item.Add("是否转为项目", temp_str, true, "基本参数", "是否转为历史项目", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("备注", m_model.REMARK, true, "基本参数", "备注信息", true);
                }
                else
                {
                    this.m_propertyWindow.propertyGrid.Item.Add("编号", "", true, "基本参数", "编号为检索数据库的依据", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目编号", "", true, "基本参数", "项目编号为项目初始化的编号", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("标准编号", "", true, "基本参数", "标准编号为项目关联的标准编号", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目名称", "", true, "基本参数", "项目名称为项目的名称，便于标识", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目开始时间", "", true, "基本参数", "项目的具体开始时间", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目结束时间", "", true, "基本参数", "项目的具体结束时间", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("项目类型", "", true, "基本参数", "项目类型分为仿真项目和实际项目", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("是否转为历史", "", true, "基本参数", "是否转为历史项目", true);
                    this.m_propertyWindow.propertyGrid.Item.Add("备注", "", true, "基本参数", "备注信息", true);
                }

            }
            else
            {
                this.m_propertyWindow.propertyGrid.Item.Add("编号", "", true, "基本参数", "编号为检索数据库的依据", true);
                this.m_propertyWindow.propertyGrid.Item.Add("项目编号", "", true, "基本参数", "项目编号为项目初始化的编号", true);
                this.m_propertyWindow.propertyGrid.Item.Add("标准编号", "", true, "基本参数", "标准编号为项目关联的标准编号", true);
                this.m_propertyWindow.propertyGrid.Item.Add("项目名称", "", true, "基本参数", "项目名称为项目的名称，便于标识", true);
                this.m_propertyWindow.propertyGrid.Item.Add("项目开始时间", "", true, "基本参数", "项目的具体开始时间", true);
                this.m_propertyWindow.propertyGrid.Item.Add("项目结束时间", "", true, "基本参数", "项目的具体结束时间", true);
                this.m_propertyWindow.propertyGrid.Item.Add("项目类型", "", true, "基本参数", "项目类型分为仿真任务和实际项目", true);
                this.m_propertyWindow.propertyGrid.Item.Add("是否转为历史", "", true, "基本参数", "是否转为历史项目", true);
                this.m_propertyWindow.propertyGrid.Item.Add("备注", "", true, "基本参数", "备注信息", true);
            }
            this.m_propertyWindow.propertyGrid.Refresh();
        }


        public void RefreshLeftWindows()
        {
            this.m_taskleftWindow.DataBind();
        }


        #region 系统管理工具组

        private void ConnectDBMenuListEnabled()
        {
            this.TaskAddMenuItem.Enabled = true;
            this.TaskEditMenuItem.Enabled = true;
            this.TaskTohisMenuItem.Enabled = true;
            this.TaskDeleteMenuItem.Enabled = true;
            this.TaskMngMenuItem.Enabled = true;
            this.SysdbdislinkMenuItem.Enabled = true;

            this.SetCommServMenuItem.Enabled = true;
            this.StartCommServMenuItem.Enabled = true;
            this.StopCommServMenuItem.Enabled = false;

            this.SysdbLinkMenuItem.Enabled = false;

            this.tsbt_addTask.Enabled = true;
            this.tsbt_deleteTask.Enabled = true;
            this.tsbt_editTask.Enabled = true;
            this.tsbt_MngTask.Enabled = true;
            this.tsbt_toHistoryTask.Enabled = true;

            this.tsbt_SetCommServ.Enabled = true;
            this.tsbt_StartCommServ.Enabled = true;
            this.tsbt_StopCommServ.Enabled = false;

            this.SysdbdislinkToolItem.Enabled = true;
            this.SysdbLinkToolItem.Enabled = false;

            this.m_commservWindow.Bt_StartServ.Enabled = true;
            this.m_commservWindow.Bt_StopServ.Enabled = false;

            this.m_taskleftWindow.Bt_select.Enabled = true;
        }

        private void DisconnMenuListEnabled()
        {
            StopCommServFun();
            CloseMDIFormList();
            this.TaskAddMenuItem.Enabled = false;
            this.TaskEditMenuItem.Enabled = false;
            this.TaskTohisMenuItem.Enabled = false;
            this.TaskDeleteMenuItem.Enabled = false;
            this.TaskMngMenuItem.Enabled = false;
            this.SysdbdislinkMenuItem.Enabled = false;

            this.SetCommServMenuItem.Enabled = false;
            this.StartCommServMenuItem.Enabled = false;
            this.StopCommServMenuItem.Enabled = false;

            this.SysdbLinkMenuItem.Enabled = true;

            this.tsbt_addTask.Enabled = false;
            this.tsbt_deleteTask.Enabled = false;
            this.tsbt_editTask.Enabled = false;
            this.tsbt_MngTask.Enabled = false;
            this.tsbt_toHistoryTask.Enabled = false;

            this.tsbt_SetCommServ.Enabled = false;
            this.tsbt_StartCommServ.Enabled = false;
            this.tsbt_StopCommServ.Enabled = false;

            this.SysdbdislinkToolItem.Enabled = false;
            this.SysdbLinkToolItem.Enabled = true;

            this.m_commservWindow.Bt_StartServ.Enabled = false;
            this.m_commservWindow.Bt_StopServ.Enabled = false;

            this.m_taskleftWindow.Bt_select.Enabled = false;
        }

        private void CloseMDIFormList()
        {
            ArrayList m_formlist = new ArrayList();
            foreach (DockContent m_containform in this.dockPanel1.Documents)
            {
                if (m_propertyWindow.Name != m_containform.Name || m_taskleftWindow.Name != m_containform.Name)
                {
                    m_formlist.Add(m_containform);
                }
            }
            for (int i = 0; i < m_formlist.Count; i++)
            {
                DockContent m_onecontainform = (DockContent)m_formlist[i];
                m_onecontainform.Close();
            }
            m_formlist.Clear();
        }

        private void SysdbSetToolItem_Click(object sender, EventArgs e)
        {
            SysdbSetMenuItem_Fun();
        }

        private void SysdbLinkToolItem_Click(object sender, EventArgs e)
        {
            SysdbLinkMenuItem_Fun();
        }

        private void SysdbdislinkToolItem_Click(object sender, EventArgs e)
        {
            SysdbdislinkMenuItem_Fun();
        }

        private void SysdbSetMenuItem_Click(object sender, EventArgs e)
        {
            SysdbSetMenuItem_Fun();
        }

        private void SysdbLinkMenuItem_Click(object sender, EventArgs e)
        {
            SysdbLinkMenuItem_Fun();
        }

        private void SysdbdislinkMenuItem_Click(object sender, EventArgs e)
        {
            SysdbdislinkMenuItem_Fun();
        }

        private void SysdbSetMenuItem_Fun()
        {
            DbConfigForm m_dbconfigWindow = new DbConfigForm();
            m_dbconfigWindow.StartPosition = FormStartPosition.CenterScreen;
            m_dbconfigWindow.ShowDialog();
        }

        private void SysdbLinkMenuItem_Fun()
        {
            bool ret_value = ITAMngApp.ApplicationFun.DbFunctionHelper.ConnectDB();
            if (ret_value == true)
            {
                ConnectDBMenuListEnabled();
            }
        }

        private void SysdbdislinkMenuItem_Fun()
        {
            bool ret_value = ITAMngApp.ApplicationFun.DbFunctionHelper.DisConnectDB();
            if (ret_value == true)
            {
                DisconnMenuListEnabled();
            }
        }
        #endregion


        #region 现行项目管理菜单组


        private void TaskAddFun()
        {
            NowTaskAddForm m_nowtaskAddWindow = new NowTaskAddForm();
            m_nowtaskAddWindow.SetMainForm(this);
            m_nowtaskAddWindow.StartPosition = FormStartPosition.CenterScreen;
            m_nowtaskAddWindow.ShowDialog();
        }

        private void TaskEditFun()
        {
            string ret_value = m_taskleftWindow.p_TB_SelectID.Text.Trim();
            if (ret_value != "")
            {
                NowTaskUpdateForm m_nowtaskupdateWindow = new NowTaskUpdateForm();
                m_nowtaskupdateWindow.SetMainForm(this);
                m_nowtaskupdateWindow.SetTaskID(ret_value);
                m_nowtaskupdateWindow.StartPosition = FormStartPosition.CenterScreen;
                m_nowtaskupdateWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择项目后再点击修改任务！", "错误");
            }
        }

        private void TaskDelFun()
        {
            string selid_str = this.m_taskleftWindow.p_TB_SelectID.Text;
            if (selid_str != "")
            {
                if (MessageBox.Show("确认删除该项目吗？", "确认删除", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //CloseFormByTaskID(selid_str);
                    hbapp.BLL.ghdata.GH_TASKINFO handle = new hbapp.BLL.ghdata.GH_TASKINFO();
                    int ret_value = handle.Delete(int.Parse(selid_str));
                    if (ret_value > 0)
                    {
                        this.m_taskleftWindow.DataBind();
                        this.m_taskleftWindow.p_TB_SelectID.Text = "";
                        this.m_taskleftWindow.p_TB_SelectTaskNo.Text = "";
                        //this.ConnectDBMenuListEnabled();
                        InitTaskProtery();
                        MessageBox.Show("删除成功！", "成功");
                    }
                    else
                        MessageBox.Show("删除失败！", "失败");
                }
            }
            else
                MessageBox.Show("请选择要删除的项目！", "失败");
        }

        private void TaskToHisFun()
        {
            string selid_str = this.m_taskleftWindow.p_TB_SelectID.Text;
            if (selid_str != "")
            {
                if (MessageBox.Show("确认将该项目转为历史项目吗？", "确认转为历史项目", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //CloseFormByTaskID(selid_str);
                    hbapp.BLL.ghdata.GH_TASKINFO handle = new hbapp.BLL.ghdata.GH_TASKINFO();
                    hbapp.Model.ghdata.GH_TASKINFO model = handle.GetModel(int.Parse(selid_str));
                    if (model != null && model.ISOFHISTORY == 1)
                    {
                        model.ISOFHISTORY = 2;
                        int ret_value = handle.Update(model);
                        if (ret_value > 0)
                        {
                            this.m_taskleftWindow.DataBind();
                            MessageBox.Show("转为历史项目成功！", "成功");
                        }
                        else
                        {
                            MessageBox.Show("转为历史项目失败！", "失败");
                        }
                    }
                    else
                        MessageBox.Show("转为历史项目失败！", "失败");
                }
            }
            else
                MessageBox.Show("请选择要转为历史项目的项目！", "失败");
        }

        private bool ShowFormByTaskID(string p_TaskID)
        {

            string m_TaskText = "[项目编号：" + p_TaskID + "]";
            ArrayList dwlist = new ArrayList();
            foreach (DockContent dw in this.dockPanel1.Contents)
            {
                if (dw.Text == m_TaskText)
                {
                    dw.Show();
                    return true;
                }
            }
            return false;
        }



        private void TaskMngFun()
        {
            string ret_value = m_taskleftWindow.p_TB_SelectID.Text.Trim();
            if (ret_value != "")
            {
                if (false == ShowFormByTaskID(ret_value))
                {

                    TaskMainForm m_taskmainform = new TaskMainForm();
                    m_taskmainform.SetMainForm(this);
                    m_taskmainform.SetTaskID(ret_value);
                    
                    if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
                    {
                        m_taskmainform.MdiParent = this;
                        m_taskmainform.Show();
                    }
                    else
                        m_taskmainform.Show(this.dockPanel1);
                }
            }
            else
            {
                MessageBox.Show("请先选择项目后再点击设置项目！", "错误");
            }
        }

        private void tsbt_addTask_Click(object sender, EventArgs e)
        {
            TaskAddFun();
        }

        private void tsbt_editTask_Click(object sender, EventArgs e)
        {
            TaskEditFun();
        }

        private void tsbt_deleteTask_Click(object sender, EventArgs e)
        {
            TaskDelFun();
        }

        private void tsbt_toHistoryTask_Click(object sender, EventArgs e)
        {
            TaskToHisFun();
        }

        private void tsbt_MngTask_Click(object sender, EventArgs e)
        {
            TaskMngFun();
        }

        private void TaskAddMenuItem_Click(object sender, EventArgs e)
        {
            TaskAddFun();
        }

        private void TaskEditMenuItem_Click(object sender, EventArgs e)
        {
            TaskEditFun();
        }

        private void TaskDeleteMenuItem_Click(object sender, EventArgs e)
        {
            TaskDelFun();
        }

        private void TaskTohisMenuItem_Click(object sender, EventArgs e)
        {
            TaskToHisFun();
        }

        private void TaskMngMenuItem_Click(object sender, EventArgs e)
        {
            TaskMngFun();
        }


        #endregion


        #region 通讯服务管理菜单组

        private UdpSocketServer udpsvhandle = null;

        public void udpsvhandle_OnRecivedData(object sender, DataReceivedEventArgs e)
        {
            ResvNetData("发射指控管理", sender, e);
            //UdpSocketServer udpsvhandle = (UdpSocketServer)sender;
            //string strmsg = DataTransformHelper.byteToHexStr(e.Data, e.DataLen);
            //Console.WriteLine(strmsg);
        }

        public void ResvNetData(string p_destform,object p_sender,DataReceivedEventArgs p_e)
        {
            foreach (DockContent dw in this.dockPanel1.Contents)
            {
                string temp_TaskText = "[项目编号：" + m_taskleftWindow.p_TB_SelectID.Text + "]";
                if (dw.Text == temp_TaskText)
                {
                    TaskMainForm temp_selform = (TaskMainForm)dw;
                    temp_selform.ResvNetData(p_destform, p_sender, p_e);
                }
            }
        }

        public void StartCommServFun()
        {
            m_commservWindow.Lb_statusinfo.Text = "当前状态:启动通讯服务";
            udpsvhandle = new UdpSocketServer();
            udpsvhandle.BufferSize = 1024 * 64;
            udpsvhandle.ServPort = 0x8000;
            udpsvhandle.OnRecivedData += new UdpSocketServer.OnReceivedDataHandler(udpsvhandle_OnRecivedData);
            if (true == udpsvhandle.Init("10.62.23.221"))
            {
                //
                m_commservWindow.Bt_StartServ.Enabled = false;
                m_commservWindow.Bt_StopServ.Enabled = true;
                this.StartCommServMenuItem.Enabled = false;
                this.StopCommServMenuItem.Enabled = true;
                this.tsbt_StartCommServ.Enabled = false;
                this.tsbt_StopCommServ.Enabled = true;

                m_commservWindow.Lb_statusinfo.Text = "当前状态:通讯服务正常运行";
            }
            else
            {
                m_commservWindow.Lb_statusinfo.Text = "当前状态:通讯服务未运行";
            }
        }

        public void StopCommServFun()
        {
            m_commservWindow.Lb_statusinfo.Text = "当前状态:关闭通讯服务";
            if (udpsvhandle != null && udpsvhandle.Close() == true)
            {
                m_commservWindow.Bt_StartServ.Enabled = true;
                m_commservWindow.Bt_StopServ.Enabled = false;
                this.StartCommServMenuItem.Enabled = true;
                this.StopCommServMenuItem.Enabled = false;
                this.tsbt_StartCommServ.Enabled = true;
                this.tsbt_StopCommServ.Enabled = false;
                m_commservWindow.Lb_statusinfo.Text = "当前状态:通讯服务未运行";
            }
            else
            {
                m_commservWindow.Lb_statusinfo.Text = "当前状态:通讯服务关闭失败";
            }
        }

        private void tsbt_SetCommServ_Click(object sender, EventArgs e)
        {

        }

        private void tsbt_StartCommServ_Click(object sender, EventArgs e)
        {
            StartCommServFun();
        }

        private void tsbt_StopCommServ_Click(object sender, EventArgs e)
        {
            StopCommServFun();
        }

        private void SetCommServMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StartCommServMenuItem_Click(object sender, EventArgs e)
        {
            StartCommServFun();
        }

        private void StopCommServMenuItem_Click(object sender, EventArgs e)
        {
            StopCommServFun();
        }

        public void NetInsertMsgToForm(NetMsgExForShow p_netmsgdata)
        {
            m_commdetailWindow.InsertMsgToForm(p_netmsgdata);
        }

        public void NetExchangeReplyStatus(string p_IDInfo, string p_Seq, string p_ReplyStatus)
        {
            m_commdetailWindow.ExchangeReplyStatus(p_IDInfo, p_Seq, p_ReplyStatus);
        }

        #endregion


        #region 关于和帮助
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region 系统关闭
        private void GMngMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ArrayList m_formlist = new ArrayList();
            foreach (DockContent m_containform in this.dockPanel1.Documents)
            {
                m_formlist.Add(m_containform);
            }
            for (int i = 0; i < m_formlist.Count; i++)
            {
                DockContent m_onecontainform = (DockContent)m_formlist[i];
                m_onecontainform.Close();
            }
            m_formlist.Clear();
        }
        
        #endregion


        #region 查看界面视图

        private void TaskLinkViewFun()
        {
            m_taskleftWindow.Show(this.dockPanel1);
        }

        private void TaskPropViewFun()
        {
            this.m_propertyWindow.Show(this.dockPanel1);
        }

        private void CommServViewFun()
        {
            this.m_commservWindow.Show(this.dockPanel1);
        }

        private void CommDetailViewFun()
        {
            this.m_commdetailWindow.Show(this.dockPanel1);
        }


        private void tsbt_taskLink_Click(object sender, EventArgs e)
        {
            TaskLinkViewFun();
        }

        private void tsbt_taskProperty_Click(object sender, EventArgs e)
        {
            TaskPropViewFun();
        }

        private void tsbt_commservinfo_Click(object sender, EventArgs e)
        {
            CommServViewFun();
        }

        private void tsbt_commdetailinfo_Click(object sender, EventArgs e)
        {
            CommDetailViewFun();
        }

        private void taskviewMenuItem_Click(object sender, EventArgs e)
        {
            TaskLinkViewFun();
        }

        private void taskPropertyMenuItem_Click(object sender, EventArgs e)
        {
            TaskPropViewFun();
        }

        private void commservMenuItem_Click(object sender, EventArgs e)
        {
            CommServViewFun();
        }

        private void commdetailMenuItem_Click(object sender, EventArgs e)
        {
            CommDetailViewFun();
        }

        #endregion


        #region 控制输出函数



        #endregion

    }

    
}