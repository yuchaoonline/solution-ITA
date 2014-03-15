using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ITAMngApp.TkMng.PropForm
{
    public partial class PropertyWindow : DockContent
    {
        public PropertyWindow()
        {
            InitializeComponent();
            base.ShowHint = DockState.DockRight;
        }

        private void PropertyWindow_Load(object sender, EventArgs e)
        {

        }

        public PropertyGridEx.PropertyGridEx propertyGrid
        {
            get
            {
                return this.propertyGridEx1;
            }
        }

        private void PropertyWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void propertyGridEx1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}