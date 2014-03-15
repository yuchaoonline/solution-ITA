using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace ITAMngApp.ApplicationFun
{
    public class DbFunctionHelper
    {
        public static bool ConnectDB()
        {
            bool ret_value = DBUtility.DbHelperOra.ConnectDB();
            if (ret_value == true)
            {
                MessageBox.Show("连接数据库成功", "成功");
            }
            else
                MessageBox.Show("连接数据库失败", "失败");
            return ret_value;
        }


        public static bool DisConnectDB()
        {
            bool ret_value = DBUtility.DbHelperOra.DisConnectDB();
            if (ret_value == true)
            {
                MessageBox.Show("断开数据库连接成功", "成功");
            }
            else
                MessageBox.Show("断开数据库连接失败", "失败");
            return ret_value;
        }

    }
}
