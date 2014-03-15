﻿using System;
using System.Data;
 using System.Collections;
namespace Mis.IDAL.Post
{
    /// <summary>
    /// 接口层 ISYS_MOUDLEACTION 的摘要说明。
    /// </summary>
    public interface ISYS_MOUDLEACTION
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
        bool Existsmodel(Mis.Model.ptgl.SYS_MOUDLEACTION model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Mis.Model.ptgl.SYS_MOUDLEACTION model);

        int AddNotall(Mis.Model.ptgl.SYS_MOUDLEACTION model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Mis.Model.ptgl.SYS_MOUDLEACTION model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int UpdateNotall(Mis.Model.ptgl.SYS_MOUDLEACTION model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Mis.Model.ptgl.SYS_MOUDLEACTION GetModel(int ID);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        DictionaryEntry AddSql(Mis.Model.ptgl.SYS_MOUDLEACTION model);

        DictionaryEntry DeleteSql(int ID);

        int ExecuteTrans(Hashtable tb);

        int ExecuteSqlTranByArray(ArrayList SQLStringList);

        #endregion  成员方法
    }
}

