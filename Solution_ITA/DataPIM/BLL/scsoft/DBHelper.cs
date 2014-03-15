using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Djdw.BLL.scsoft
{
    public class DBHelper
    {
        public static int ExecuteSql(string SQLString)
        {
            return DBUtility.DbHelperOra.ExecuteSql(SQLString);
        }


        public static DataSet Query(string SQLString)
        {
            return DBUtility.DbHelperOra.Query(SQLString);
        }

    }
}
