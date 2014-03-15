using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using System.Collections;
using Mis.DALFactory.ptgl;
using System.Web.UI.WebControls;
using Mis.IDAL.Post;

namespace Mis.BLL.ptgl
{

    /// <summary>
    /// 业务逻辑类 SYS_INFODICT 的摘要说明。
    /// </summary>
    public class SYS_INFODICT
    {
        private static readonly ISYS_INFODICT dal = DataAccess.CreateSYS_INFODICT();
        public SYS_INFODICT()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 是否存在该记录strwhere
        /// </summary>
        public bool Exists(string strwhere)
        {
            return dal.Exists(strwhere);
        }

        /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(Djdw.Model.Post.SYS_INFODICT model)
        {
            return dal.Existsmodel(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Djdw.Model.Post.SYS_INFODICT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据(null)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNotall(Djdw.Model.Post.SYS_INFODICT model)
        {
            return dal.AddNotall(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Djdw.Model.Post.SYS_INFODICT model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateNotall(Djdw.Model.Post.SYS_INFODICT model)
        {
            return dal.UpdateNotall(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Djdw.Model.Post.SYS_INFODICT GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 定位数据行
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns>返回Data</returns>
        public Djdw.Model.Post.SYS_INFODICT ToLocalData(DataRow row)
        {
            Djdw.Model.Post.SYS_INFODICT data = new Djdw.Model.Post.SYS_INFODICT();
            data.ID = int.Parse(row["ID"].ToString());
            data.INFONO = (string)row["INFONO"].ToString();
            data.INFONAME = (string)row["INFONAME"].ToString();
            data.PARENTID = int.Parse(row["PARENTID"].ToString());
            data.DESCRIPTION = (string)row["DESCRIPTION"].ToString();
            data.ACTIONPEOPLE = (string)row["ACTIONPEOPLE"].ToString();
            data.INFOLEVEL = int.Parse(row["INFOLEVEL"].ToString());
            return data;
        }



        public DataTable getinfotable(string parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            return table;
        }

        /// <summary>
        ///定位数据表 
        /// </summary>
        /// <param name="table">数据表DataTable</param>
        /// <returns>返回Data[]数组</returns>
        public Djdw.Model.Post.SYS_INFODICT[] ToLocalData(DataTable table)
        {
            Djdw.Model.Post.SYS_INFODICT[] userobjs = new Djdw.Model.Post.SYS_INFODICT[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                userobjs[i] = ToLocalData(table.Rows[i]);
            }
            return userobjs;
        }


        public Djdw.Model.Post.SYS_INFODICT NullToSpace(Djdw.Model.Post.SYS_INFODICT item)
        {
            if (item.INFONO == null)
                item.INFONO = "";
            if (item.INFONAME == null)
                item.INFONAME = "";
            if (item.DESCRIPTION == null)
                item.DESCRIPTION = "";
            if (item.ACTIONPEOPLE == null)
                item.ACTIONPEOPLE = "";
            return item;
        }


        public DataTable GetTable(string strWhere)
        {
            DataSet dts = GetList(strWhere);
            DataTable tb = dts.Tables[0];
            return tb;
        }

        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public DictionaryEntry AddSql(Djdw.Model.Post.SYS_INFODICT model)
        {
            return dal.AddSql(model);
        }

        public DictionaryEntry DeleteSql(int ID)
        {
            return dal.DeleteSql(ID);
        }

        public int ExecuteTrans(Hashtable tb)
        {
            return dal.ExecuteTrans(tb);
        }

        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return dal.ExecuteSqlTranByArray(SQLStringList);
        }

        /// <summary>
        /// 是不是double
        /// </summary>
        /// <returns></returns>
        public bool isofdouble(string content)
        {
            string ValidChars = ".0123456789";
            char Char;
            string sText = content;
            char[] sChar = sText.ToCharArray(0, sText.Length);
            for (int i = 0; i < sText.Length; i++)
            {
                Char = sChar[i];
                if (ValidChars.IndexOf(Char) == -1)
                {
                    return false;
                }
            }
            if (content.IndexOf(".") != content.LastIndexOf("."))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是不是全是数字
        /// </summary>
        /// <returns></returns>
        public bool isofnumber(string content)
        {
            string ValidChars = "0123456789";
            char Char;
            string sText = content;
            char[] sChar = sText.ToCharArray(0, sText.Length);
            for (int i = 0; i < sText.Length; i++)
            {
                Char = sChar[i];
                if (ValidChars.IndexOf(Char) == -1)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// i，j 表示获取table的第几列
        /// </summary>
        /// <param name="list"></param>
        /// <param name="strWhere"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void BindToDropDownList(DropDownList list, string strWhere, int i, int j)
        {

            DataTable table = GetTable(strWhere);
            ListItem lt = new ListItem();

            for (int k = 0; k < table.Rows.Count; k++)
            {
                lt = new ListItem();
                lt.Text = table.Rows[k][i].ToString().Replace("\0", "");
                lt.Value = table.Rows[k][j].ToString().Replace("\0", "");
                list.Items.Add(lt);
            }
        }

        public void BindToDropDownListForWin(System.Windows.Forms.ComboBox p_Comboxlist, string p_Parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + p_Parentno + "') order by id";
            DataTable table = GetTable(strWhere);
            if (table != null && table.Rows.Count > 0)
            {
                p_Comboxlist.Items.Clear();
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    string itemtext = table.Rows[k]["infoname"].ToString();
                    p_Comboxlist.Items.Add(itemtext);
                }
            }
        }

        public void BindToDropDownListInselForWin(System.Windows.Forms.ComboBox p_Comboxlist, string p_Parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + p_Parentno + "') order by id";
            DataTable table = GetTable(strWhere);
            if (table != null && table.Rows.Count > 0)
            {
                p_Comboxlist.Items.Clear();
                p_Comboxlist.Items.Add("全部");
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    string itemtext = table.Rows[k]["infoname"].ToString();
                    p_Comboxlist.Items.Add(itemtext);
                }
            }
        }

        
        public void BindToDropDownList(DropDownList list, string parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "') order by id";
            DataTable table = GetTable(strWhere);
            if (table != null && table.Rows.Count > 0)
            {
                list.Items.Clear();
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    ListItem lt = new ListItem();
                    lt.Text = table.Rows[k]["infoname"].ToString();
                    lt.Value = table.Rows[k]["infono"].ToString();
                    list.Items.Add(lt);
                }
            }
        }

        public void BindToDropDownListInselect(DropDownList list, string parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            if (table != null && table.Rows.Count > 0)
            {
                list.Items.Clear();

                ListItem lt_cb = new ListItem();
                lt_cb.Text = "全部";
                lt_cb.Value = "0";
                list.Items.Add(lt_cb);

                for (int k = 0; k < table.Rows.Count; k++)
                {
                    ListItem lt = new ListItem();
                    lt.Text = table.Rows[k]["infoname"].ToString();
                    lt.Value = table.Rows[k]["infono"].ToString();
                    list.Items.Add(lt);
                }
            }
        }

        public void BindToDropDLInZeroInselect(DropDownList list, string parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            if (table != null && table.Rows.Count > 0)
            {
                list.Items.Clear();

                ListItem lt_cb = new ListItem();
                lt_cb.Text = "全部";
                lt_cb.Value = "-1";
                list.Items.Add(lt_cb);

                for (int k = 0; k < table.Rows.Count; k++)
                {
                    ListItem lt = new ListItem();
                    lt.Text = table.Rows[k]["infoname"].ToString();
                    lt.Value = table.Rows[k]["infono"].ToString();
                    list.Items.Add(lt);
                }
            }
        }

        public void BindToDropDownListInCont(DropDownList list, string parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            if (table != null && table.Rows.Count > 0)
            {
                list.Items.Clear();

                ListItem lt_cb = new ListItem();
                lt_cb.Text = "未选";
                lt_cb.Value = "0";
                list.Items.Add(lt_cb);

                for (int k = 0; k < table.Rows.Count; k++)
                {
                    ListItem lt = new ListItem();
                    lt.Text = table.Rows[k]["infoname"].ToString();
                    lt.Value = table.Rows[k]["description"].ToString();
                    list.Items.Add(lt);
                }
            }
        }

        public DictionaryEntry[] GetInfoListByParentid(string p_parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + p_parentno + "')  order by id";
            DataTable table = GetTable(strWhere);

            DictionaryEntry[] ret_list = new DictionaryEntry[table.Rows.Count];
            for (int k = 0; k < table.Rows.Count; k++)
            {
                DictionaryEntry obj = new DictionaryEntry();
                obj.Key = table.Rows[k]["infono"].ToString();
                obj.Value = table.Rows[k]["infoname"].ToString();
                ret_list[k] = obj;
            }
            return ret_list;
        }


        public string GetInfoNameByinfono(string parentno, string sonno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            for (int k = 0; k < table.Rows.Count; k++)
            {
                if (sonno.CompareTo(table.Rows[k]["infono"].ToString()) == 0)
                    return table.Rows[k]["infoname"].ToString();
            }
            return "";
        }

        public string GetInfoNoByinfoname(string parentno, string sonname)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            for (int k = 0; k < table.Rows.Count; k++)
            {
                if (sonname.CompareTo(table.Rows[k]["infoname"].ToString()) == 0)
                    return table.Rows[k]["infono"].ToString();
            }
            return "";
        }

        public string GetInfoDescripByinfono(string parentno, string sonno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            for (int k = 0; k < table.Rows.Count; k++)
            {
                if (sonno.CompareTo(table.Rows[k]["infono"].ToString()) == 0)
                    return table.Rows[k]["description"].ToString();
            }
            return "";
        }

        public string GetInfoDescripByinfono(string parentno, string sonno,ref string ref_id)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            for (int k = 0; k < table.Rows.Count; k++)
            {
                if (sonno.CompareTo(table.Rows[k]["infono"].ToString()) == 0)
                {
                    string id_str = table.Rows[k]["id"].ToString();
                    ref_id = id_str;
                    return table.Rows[k]["description"].ToString();
                }
            }
            return "";
        }

        public int SetInfoDescripByinfono(string p_parentno, string p_sonno, string p_value)
        {
            string ref_id = "";
            string lastvalue = GetInfoDescripByinfono(p_parentno, p_sonno,ref ref_id);
            if (lastvalue == p_value)
            {
                return 0;
            }
            else 
            {
                Djdw.Model.Post.SYS_INFODICT model = GetModel(int.Parse(ref_id));
                model.DESCRIPTION = p_value;
                return Update(model);
            }
        }

        public int UpdateDescripInfoByid(string p_id,string p_descinfo)
        {
            string p_sql = "update SYS_INFODICT set description='" + p_descinfo + "' where id=" + p_id;
            return DBUtility.DbHelperOra.ExecuteSql(p_sql);
        }

        public void BindToRadioButtonList(RadioButtonList list, string parentno)
        {
            string strWhere = " parentid = (select id from sys_infodict t where parentid =0 and infono='" + parentno + "')";
            DataTable table = GetTable(strWhere);
            if (table != null && table.Rows.Count > 0)
            {
                list.Items.Clear();
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    ListItem lt = new ListItem();
                    lt.Text = table.Rows[k]["infoname"].ToString();
                    lt.Value = table.Rows[k]["infono"].ToString();
                    list.Items.Add(lt);
                }
            }
        }

        #endregion  成员方法
    }
}


