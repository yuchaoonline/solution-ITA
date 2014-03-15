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
    public partial class ITAToolForm : DockContent
    {

        private GMngMainForm m_ParentForm = null;

        public ITAToolForm()
        {
            InitializeComponent();
            base.ShowHint = DockState.DockRight;
        }

        public void SetParentForm(GMngMainForm p_ParentForm)
        {
            m_ParentForm = p_ParentForm;
        }


        private void ITAToolForm_Load(object sender, EventArgs e)
        {

        }
    }
}