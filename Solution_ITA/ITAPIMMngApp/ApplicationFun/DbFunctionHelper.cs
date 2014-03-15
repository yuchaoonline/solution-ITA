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
                MessageBox.Show("�������ݿ�ɹ�", "�ɹ�");
            }
            else
                MessageBox.Show("�������ݿ�ʧ��", "ʧ��");
            return ret_value;
        }


        public static bool DisConnectDB()
        {
            bool ret_value = DBUtility.DbHelperOra.DisConnectDB();
            if (ret_value == true)
            {
                MessageBox.Show("�Ͽ����ݿ����ӳɹ�", "�ɹ�");
            }
            else
                MessageBox.Show("�Ͽ����ݿ�����ʧ��", "ʧ��");
            return ret_value;
        }

    }
}
