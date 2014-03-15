using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections;
using System.Xml;
using System.IO;
using SCAATSoft.CommFramework;
using ITAMngApp.ApplicationFun;

namespace ITAMngApp
{
    public partial class TaskMainForm : DockContent, IResvNetData
    {
        private GMngMainForm m_mainform = null;

        private string m_TaskID = "";

        private string m_TaskNo = "";

        private string m_CTVNo = "";


        public TaskMainForm()
        {
            InitializeComponent();
        }

        public void SetMainForm(GMngMainForm p_mainform)
        {
            m_mainform = p_mainform;

        }

        public void SetTaskID(string p_Taskid)
        {
            m_TaskID = p_Taskid;
        }

        private void InitParamInfo()
        {
            if (m_TaskNo == "")
            {
                hbapp.BLL.ghdata.GH_TASKINFO handle = new hbapp.BLL.ghdata.GH_TASKINFO();
                hbapp.Model.ghdata.GH_TASKINFO model = handle.GetModel(int.Parse(m_TaskID));
                this.m_TaskNo = model.TASKNO;
            }
           

        }

        private void PriLoadProcess_Load(object sender, EventArgs e)
        {
            if (m_TaskID != null)
            {
                this.Text = "[项目编号：" + m_TaskID + "]";
            }
            InitMenuTree();
            this.TaskMenuTree.ExpandAll();
        }
        #region 树状结构
        private void InitMenuTree()
        {
            //EXE程序所在的目录
            string strAppDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            
            string m_filename = strAppDir + "\\MenuInfoVer1.0.xml";
            
            
            Stream file = null;
            try
            {
                file = File.Open(m_filename, FileMode.Open);
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(file);
                XmlNode root = xdoc.DocumentElement;

                this.TaskMenuTree.CheckBoxes = false;
                //this.TaskMenuTree.ItemHeight = 20;
                this.TaskMenuTree.Nodes[0].Nodes.Clear();
                TreeNode firstnode = this.TaskMenuTree.Nodes[0];
                XmlAttribute a_name;
                XmlAttribute a_text;
                a_name = root.Attributes["name"];
                a_text = root.Attributes["text"];
                if (a_name != null && a_text != null)
                {
                    firstnode.Name = a_name.Value;// "NowTaskNode";
                    firstnode.Text = a_text.Value;// "当前任务";
                }
                //
                AddNodeToMenuTree(root, firstnode);
            }
            catch (Exception e1)
            {

            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                    file.Dispose();
                }
            }
        }

        private void AddNodeToMenuTree(XmlNode p_xmlpnode, TreeNode p_menunode)
        {
            foreach (XmlNode item in p_xmlpnode)
            {
                if (item.Name == "node")
                {
                    TreeNode submenunode = new TreeNode();
                    XmlAttribute a_name;
                    XmlAttribute a_text;
                    XmlAttribute a_form;
                    a_name = item.Attributes["name"];
                    a_text = item.Attributes["text"];
                    a_form = item.Attributes["form"];
                    if (a_name != null && a_text != null)
                    {
                        submenunode.Name = a_name.Value;
                        submenunode.Text = a_text.Value;
                        if (a_form != null)
                        {
                            submenunode.Tag = a_form.Value;
                        }
                        else
                        {
                            submenunode.Tag = null;
                        }

                        p_menunode.Nodes.Add(submenunode);

                        AddNodeToMenuTree(item, submenunode);
                    }
                    
                }
            }
        }

        private void TaskMenuTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            InitParamInfo();

            if (e.Node.Tag!=null)
            {
                string formclassname = e.Node.Tag.ToString();

                DockContent m_form = GetFormInDockPanel(e.Node.Text);

                //反射初始化
                if (m_form == null)
                    m_form = (DockContent)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(formclassname);
                
                m_form.Text = e.Node.Text;
                if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    m_form.MdiParent = this;
                    m_form.Show();
                }
                else
                {
                    m_form.Show(this.dockPanel1);
                }
            }


        }

        #endregion

        private DockContent GetFormInDockPanel(string p_formname)
        {
            foreach (DockContent m_containform in this.dockPanel1.Documents)
            {
                if (m_containform.Text == p_formname)
                {
                    return m_containform;
                }
            }
            return null;
            
        }

        private void CloseDockPanelFormList()
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

        private void dockPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            MessageBox.Show(e.Control.Name);
        }

        private void TaskMainForm_FormClosed(object sender, FormClosedEventArgs e)
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


        #region IResvNetData 成员

        public void ResvNetData(string p_destformtext, object p_sender, DataReceivedEventArgs p_e)
        {
            //
            DockContent m_dcform = GetFormInDockPanel(p_destformtext);
            if (m_dcform != null)
            {
                IResvNetData m_netdatahandle = (IResvNetData)m_dcform;
                m_netdatahandle.ResvNetData(p_destformtext, p_sender, p_e);
            }
        }

        #endregion
    }
}