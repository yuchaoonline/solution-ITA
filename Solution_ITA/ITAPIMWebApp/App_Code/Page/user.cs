using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace PageBaseFun
{
    /// <summary>
    /// user 的摘要说明
    /// </summary>
    /// 
    [Serializable]
    public class user
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        private string _uid;
        public string uid
        {
            get { return _uid; }
            set
            {
                if (_uid != value)
                {
                    _uid = value;
                }
            }
        }

        private string _phone;
        public string phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                }
            }
        }

        private string _pwd;
        public string pwd
        {
            get { return _pwd; }
            set
            {
                if (_pwd != value)
                {
                    _pwd = value;
                }
            }
        }

        private string _realname;
        public string realname
        {
            get { return _realname; }
            set
            {
                if (_realname != value)
                {
                    _realname = value;
                }
            }
        }

        private string _rolelist;
        public string rolelist
        {
            get { return _rolelist; }
            set
            {
                _rolelist = value;
            }
        }

        private ArrayList _rolemenulist;
        public ArrayList rolemenulist
        {
            get { return _rolemenulist; }
            set
            {
                _rolemenulist = value;
            }
        }

        private ArrayList _roledatatypelist;
        public ArrayList roledatatypelist
        {
            get { return _roledatatypelist; }
            set
            {
                _roledatatypelist = value;
            }
        }


        private string _DepartmentID;

        public string DepartmentID
        {
            get { return _DepartmentID; }
            set
            {
                if (_DepartmentID != value)
                {
                    _DepartmentID = value;
                }
            }
        }

        private string _WorkArea;

        public string WorkArea
        {
            get { return _WorkArea; }
            set
            {
                if (_WorkArea != value)
                {
                    _WorkArea = value;
                }
            }
        }

        private string _Team;

        public string Team
        {
            get { return _Team; }
            set
            {
                if (_Team != value)
                {
                    _Team = value;
                }
            }
        }

        private string _Department;

        public string Department
        {
            get { return _Department; }
            set
            {
                if (_Department != value)
                {
                    _Department = value;
                }
            }
        }


    }
}
