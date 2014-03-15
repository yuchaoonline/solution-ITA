using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ITAMngApp.BsMng
{

    public partial class IEBrowerMng : DockContent
    {
        public IEBrowerMng()
        {
            InitializeComponent();
        }

        private void IEBrowerMng_Load(object sender, EventArgs e)
        {
            string mipurlpath_str= System.Configuration.ConfigurationManager.AppSettings["MIPUrlPath"];
            Uri uriobj = new Uri(mipurlpath_str);
            m_MyEebBrowser.Url = uriobj;
            
        }
    }
}