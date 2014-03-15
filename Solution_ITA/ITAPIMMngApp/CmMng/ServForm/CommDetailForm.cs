using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ITAMngApp.ApplicationFun;

namespace ITAMngApp.CmMng.ServForm
{
    public partial class CommDetailForm : DockContent
    {
        private int m_allmsgnum = 0;

        public CommDetailForm()
        {
            InitializeComponent();
            base.ShowHint = DockState.DockBottom;
            ListView.CheckForIllegalCrossThreadCalls = false;
        }

        private void CommDetailForm_Load(object sender, EventArgs e)
        {
            m_allmsgnum = 0;
        }

        public void InsertMsgToForm(NetMsgExForShow p_netmsgdata)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = p_netmsgdata.Msg_01_ID;
            item.SubItems.Add(p_netmsgdata.Msg_02_State);
            item.SubItems.Add(p_netmsgdata.Msg_03_CommModule);
            item.SubItems.Add(p_netmsgdata.Msg_04_IDInfo);
            item.SubItems.Add(p_netmsgdata.Msg_05_Len);
            item.SubItems.Add(p_netmsgdata.Msg_06_SrcId);
            item.SubItems.Add(p_netmsgdata.Msg_07_DestId);
            item.SubItems.Add(p_netmsgdata.Msg_08_Seq);
            item.SubItems.Add(p_netmsgdata.Msg_09_Tm);
            item.SubItems.Add(p_netmsgdata.Msg_10_SendorResv);
            item.SubItems.Add(p_netmsgdata.Msg_11_Content);
            item.SubItems.Add(p_netmsgdata.Msg_13_ReplyStatus);

            item.Tag = p_netmsgdata.Msg_12_Obj;
            if (m_allmsgnum % 2 == 1)
            {
                item.BackColor = System.Drawing.Color.FromArgb(254, 222, 202);//设置交替行的背景颜色
            }
            Lv_NetinfoList.Items.Insert(0,item);
            m_allmsgnum++;
        }

        public void ExchangeReplyStatus(string p_IDInfo, string p_Seq, string p_ReplyStatus)
        {
            for (int i = 0; i < Lv_NetinfoList.Items.Count; i++)
            {
                ListViewItem item = Lv_NetinfoList.Items[i];
                if( item.SubItems[3].Text.Trim() == p_IDInfo && item.SubItems[7].Text.Trim() == p_Seq)
                {
                    item.SubItems[11].Text = p_ReplyStatus;
                }
            }
        }//
    }
}