using System;
using System.Data;
 using System.Collections;
namespace Mis.IDAL.Post
{
    /// <summary>
    /// 接口层 ISYS_MENU 的摘要说明。
    /// </summary>
    public interface ISYS_MENU
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID

        /// </summary>
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);

        /// <summary>
        /// 是否存在该记录strwhere
        /// </summary>
        bool Exists(string strwhere);

        /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        bool Existsmodel(Djdw.Model.Post.SYS_MENU model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Djdw.Model.Post.SYS_MENU model);

        int AddNotall(Djdw.Model.Post.SYS_MENU model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Djdw.Model.Post.SYS_MENU model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int UpdateNotall(Djdw.Model.Post.SYS_MENU model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);

        int Delete(string ID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Djdw.Model.Post.SYS_MENU GetModel(int ID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        DictionaryEntry AddSql(Djdw.Model.Post.SYS_MENU model);

        DictionaryEntry DeleteSql(int ID);

        int ExecuteTrans(Hashtable tb);

        int ExecuteSqlTranByArray(ArrayList SQLStringList);

        #endregion  成员方法
    }
}

