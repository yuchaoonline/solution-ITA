using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GMngMainForm.SysDb
{
    public partial class DbConfigForm : Form
    {
        public DbConfigForm()
        {
            InitializeComponent();
        }

        private bool ValidateInfo()
        {
            if (tB_dbsource.Text == "")
            {
                MessageBox.Show("配置数据库名称不能为空！", "错误");
                return false;
            }
            if (tB_user.Text == "")
            {
                MessageBox.Show("配置数据库用户名不能为空！", "错误");
                return false;
            }
            if (tB_pwd.Text == "")
            {
                MessageBox.Show("配置数据库密码不能为空！", "错误");
                return false;
            }
            return true;
        }

        private void InitInfo()
        {
            tB_dbsource.Text = DBUtility.Configuration.GetConfigValue(DBUtility.Configuration.FRAMEWORK_DBServer_DB_STRING);
            tB_user.Text = DBUtility.Configuration.GetConfigValue(DBUtility.Configuration.FRAMEWORK_DBServer_USER_STRING);
            tB_pwd.Text = DBUtility.Configuration.GetConfigValue(DBUtility.Configuration.FRAMEWORK_DBServer_PWD_STRING);
        }

        private void DbConfigForm_Load(object sender, EventArgs e)
        {
            InitInfo();
        }

        private void bt_submit_Click(object sender, EventArgs e)
        {
            bool ret_value = true;
            ret_value = ValidateInfo();
            if (ret_value == false)
            {
                return;
            }
            ret_value = DBUtility.Configuration.SetConfigValue(DBUtility.Configuration.FRAMEWORK_DBServer_DB_STRING, tB_dbsource.Text);
            if (ret_value == false)
            {
                MessageBox.Show("配置数据库名称错误！", "错误");
                return;
            }
            ret_value = DBUtility.Configuration.SetConfigValue(DBUtility.Configuration.FRAMEWORK_DBServer_USER_STRING, tB_user.Text);
            if (ret_value == false)
            {
                MessageBox.Show("配置数据库用户名错误！", "错误");
                return;
            }
            ret_value = DBUtility.Configuration.SetConfigValue(DBUtility.Configuration.FRAMEWORK_DBServer_PWD_STRING, tB_pwd.Text);
            if (ret_value == false)
            {
                MessageBox.Show("配置数据库密码错误！", "错误");
                return;
            }
            MessageBox.Show("配置参数成功，请关闭数据库连接后，重新建立数据库连接！", "成功");
            this.Close();
        }

        private void bt_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}