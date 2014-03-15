using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ITAMngApp.CmMng.ServForm
{
    public partial class CommServForm : DockContent
    {
        public CommServForm()
        {
            InitializeComponent();
            base.ShowHint = DockState.DockBottom;
        }

        private void CommServForm_Load(object sender, EventArgs e)
        {

        }

        private void bt_StartServ_Click(object sender, EventArgs e)
        {
            Program.MainApp.StartCommServFun();
        }

        private void bt_StopServ_Click(object sender, EventArgs e)
        {
            Program.MainApp.StopCommServFun();
        }


        public System.Windows.Forms.Button Bt_StartServ
        {
            get { return bt_StartServ; }
            set { bt_StartServ = value; }
        }
        public System.Windows.Forms.Button Bt_StopServ
        {
            get { return bt_StopServ; }
            set { bt_StopServ = value; }
        }


        public System.Windows.Forms.Label Lb_statusinfo
        {
            get { return lb_statusinfo; }
            set { lb_statusinfo = value; }
        }

        public System.Windows.Forms.RichTextBox RTB_Label
        {
            get { return RTB_Output; }
            set { RTB_Output = value; }
        }

    }
}