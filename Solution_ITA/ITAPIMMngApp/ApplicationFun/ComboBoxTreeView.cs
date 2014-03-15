using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ITAMngApp.ApplicationFun
{
    public class ComboBoxTreeView : ComboBox
    {
        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;
        ToolStripControlHost treeViewHost;
        ToolStripDropDown dropDown;

        private string selectname;

        public ComboBoxTreeView()
        {
            TreeView treeView = new TreeView();
            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
            treeView.BorderStyle = BorderStyle.None;

            treeViewHost = new ToolStripControlHost(treeView);
            dropDown = new ToolStripDropDown();
            dropDown.Width = this.Width;
            dropDown.Items.Add(treeViewHost);
            selectname = "";
        }

        public void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = TreeView.SelectedNode.Text;
            this.selectname = TreeView.SelectedNode.Name;
            dropDown.Close();
        }

        public void InitSelectNode(string p_nodename)
        {
            this.Focus();
            TreeNode refnode=null;
            InitSelectNodeByName(p_nodename, TreeView.Nodes[0], ref refnode);
            if (refnode != null)
            {
                this.Text = refnode.Text;
                this.selectname = refnode.Name;
            }
        }

        private void InitSelectNodeByName(string p_nodename, TreeNode p_parentnode,ref TreeNode p_refnode)
        {
            if (p_parentnode.Name == p_nodename)
            {
                p_refnode = p_parentnode;
                return;
            }
            else
            {
                for (int i = 0; i < p_parentnode.Nodes.Count; i++)
                {
                    InitSelectNodeByName(p_nodename, p_parentnode.Nodes[i], ref p_refnode);
                }
            }
        }

        public TreeView TreeView
        {
            get { return treeViewHost.Control as TreeView; }
        }

        public string SelectName
        {
            get { return this.selectname;}
        }

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                treeViewHost.Size = new Size(DropDownWidth - 2, DropDownHeight);
                dropDown.Show(this, 0, this.Height);
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                ShowDropDown();
                return;
            }
            base.WndProc(ref m);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }

    }
}
