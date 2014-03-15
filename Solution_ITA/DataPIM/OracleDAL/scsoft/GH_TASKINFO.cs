using System;
using System.Data;
using System.Text;
using System.Data.OracleClient;
using  hbapp.IDAL.ghdata;
using DBUtility;
 using System.Collections;

namespace hbapp.OracleDAL.ghdata
{

    /// <summary>
    /// 数据访问类GH_TASKINFO
    /// </summary>
    public class GH_TASKINFO : IGH_TASKINFO
    {
        public GH_TASKINFO()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOra.GetMaxIDBySeq("ID", "GH_TASKINFO");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GH_TASKINFO");
            strSql.Append(" where ID= :ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GH_TASKINFO");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID  desc ");
            return DbHelperOra.Exists(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GH_TASKINFO(");
            strSql.Append("ID,TASKNO,CTVNO,TASKNAME,STARTTIME,ENDTIME,TASKTYPE,ISOFHISTORY,REMARK,REMARK1,REMARK2,REMARK3,REMARK4,REMARK5,REMARK6,REMARK7,REMARK8,REMARK9,REMARK10,REMARK11,REMARK12,REMARK13,REMARK14,REMARK15)");
            strSql.Append(" values (");
            strSql.Append(":ID,:TASKNO,:CTVNO,:TASKNAME,:STARTTIME,:ENDTIME,:TASKTYPE,:ISOFHISTORY,:REMARK,:REMARK1,:REMARK2,:REMARK3,:REMARK4,:REMARK5,:REMARK6,:REMARK7,:REMARK8,:REMARK9,:REMARK10,:REMARK11,:REMARK12,:REMARK13,:REMARK14,:REMARK15)");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,15),
					new OracleParameter(":TASKNO", OracleType.VarChar,20),
					new OracleParameter(":CTVNO", OracleType.VarChar,20),
					new OracleParameter(":TASKNAME", OracleType.VarChar,128),
					new OracleParameter(":STARTTIME", OracleType.VarChar,20),
					new OracleParameter(":ENDTIME", OracleType.VarChar,20),
					new OracleParameter(":TASKTYPE", OracleType.Number,2),
					new OracleParameter(":ISOFHISTORY", OracleType.Number,2),
					new OracleParameter(":REMARK", OracleType.VarChar,20),
					new OracleParameter(":REMARK1", OracleType.VarChar,20),
					new OracleParameter(":REMARK2", OracleType.VarChar,20),
					new OracleParameter(":REMARK3", OracleType.VarChar,20),
					new OracleParameter(":REMARK4", OracleType.VarChar,20),
					new OracleParameter(":REMARK5", OracleType.VarChar,20),
					new OracleParameter(":REMARK6", OracleType.VarChar,20),
					new OracleParameter(":REMARK7", OracleType.VarChar,20),
					new OracleParameter(":REMARK8", OracleType.VarChar,20),
					new OracleParameter(":REMARK9", OracleType.VarChar,20),
					new OracleParameter(":REMARK10", OracleType.VarChar,20),
					new OracleParameter(":REMARK11", OracleType.VarChar,20),
					new OracleParameter(":REMARK12", OracleType.VarChar,20),
					new OracleParameter(":REMARK13", OracleType.VarChar,20),
					new OracleParameter(":REMARK14", OracleType.VarChar,20),
					new OracleParameter(":REMARK15", OracleType.VarChar,20)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.TASKNO; //任务编号
            parameters[2].Value = model.CTVNO; //ChinaHV编号
            parameters[3].Value = model.TASKNAME; //任务名称
            parameters[4].Value = model.STARTTIME; //任务开始时间
            parameters[5].Value = model.ENDTIME; //任务结束时间
            parameters[6].Value = model.TASKTYPE; //任务类型
            parameters[7].Value = model.ISOFHISTORY; //是否转为历史
            parameters[8].Value = model.REMARK; //备注
            parameters[9].Value = model.REMARK1; //备注1
            parameters[10].Value = model.REMARK2; //备注2
            parameters[11].Value = model.REMARK3; //备注3
            parameters[12].Value = model.REMARK4; //备注4
            parameters[13].Value = model.REMARK5; //备注5
            parameters[14].Value = model.REMARK6; //备注6
            parameters[15].Value = model.REMARK7; //备注7
            parameters[16].Value = model.REMARK8; //备注8
            parameters[17].Value = model.REMARK9; //备注9
            parameters[18].Value = model.REMARK10; //备注10
            parameters[19].Value = model.REMARK11; //备注11
            parameters[20].Value = model.REMARK12; //备注12
            parameters[21].Value = model.REMARK13; //备注13
            parameters[22].Value = model.REMARK14; //备注14
            parameters[23].Value = model.REMARK15; //备注15

            int ret_value = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (ret_value >= 0)
            {
                return model.ID;
            }
            else
                return -1;
        }

        /// <summary>
        /// 事务处理增加一个model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public DictionaryEntry AddSql(hbapp.Model.ghdata.GH_TASKINFO model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GH_TASKINFO(");
            strSql.Append("ID,TASKNO,CTVNO,TASKNAME,STARTTIME,ENDTIME,TASKTYPE,ISOFHISTORY,REMARK,REMARK1,REMARK2,REMARK3,REMARK4,REMARK5,REMARK6,REMARK7,REMARK8,REMARK9,REMARK10,REMARK11,REMARK12,REMARK13,REMARK14,REMARK15)");
            strSql.Append(" values (");
            strSql.Append("SEQGH_TASKINFO.NEXTVAL,:TASKNO,:CTVNO,:TASKNAME,:STARTTIME,:ENDTIME,:TASKTYPE,:ISOFHISTORY,:REMARK,:REMARK1,:REMARK2,:REMARK3,:REMARK4,:REMARK5,:REMARK6,:REMARK7,:REMARK8,:REMARK9,:REMARK10,:REMARK11,:REMARK12,:REMARK13,:REMARK14,:REMARK15)");
            OracleParameter[] parameters = {  
					new OracleParameter(":TASKNO", OracleType.VarChar,20),
					new OracleParameter(":CTVNO", OracleType.VarChar,20),
					new OracleParameter(":TASKNAME", OracleType.VarChar,128),
					new OracleParameter(":STARTTIME", OracleType.VarChar,20),
					new OracleParameter(":ENDTIME", OracleType.VarChar,20),
					new OracleParameter(":TASKTYPE", OracleType.Number,2),
					new OracleParameter(":ISOFHISTORY", OracleType.Number,2),
					new OracleParameter(":REMARK", OracleType.VarChar,20),
					new OracleParameter(":REMARK1", OracleType.VarChar,20),
					new OracleParameter(":REMARK2", OracleType.VarChar,20),
					new OracleParameter(":REMARK3", OracleType.VarChar,20),
					new OracleParameter(":REMARK4", OracleType.VarChar,20),
					new OracleParameter(":REMARK5", OracleType.VarChar,20),
					new OracleParameter(":REMARK6", OracleType.VarChar,20),
					new OracleParameter(":REMARK7", OracleType.VarChar,20),
					new OracleParameter(":REMARK8", OracleType.VarChar,20),
					new OracleParameter(":REMARK9", OracleType.VarChar,20),
					new OracleParameter(":REMARK10", OracleType.VarChar,20),
					new OracleParameter(":REMARK11", OracleType.VarChar,20),
					new OracleParameter(":REMARK12", OracleType.VarChar,20),
					new OracleParameter(":REMARK13", OracleType.VarChar,20),
					new OracleParameter(":REMARK14", OracleType.VarChar,20),
					new OracleParameter(":REMARK15", OracleType.VarChar,20)};
            parameters[0].Value = model.TASKNO; //任务编号
            parameters[1].Value = model.CTVNO; //ChinaHV编号
            parameters[2].Value = model.TASKNAME; //任务名称
            parameters[3].Value = model.STARTTIME; //任务开始时间
            parameters[4].Value = model.ENDTIME; //任务结束时间
            parameters[5].Value = model.TASKTYPE; //任务类型
            parameters[6].Value = model.ISOFHISTORY; //是否转为历史
            parameters[7].Value = model.REMARK; //备注
            parameters[8].Value = model.REMARK1; //备注1
            parameters[9].Value = model.REMARK2; //备注2
            parameters[10].Value = model.REMARK3; //备注3
            parameters[11].Value = model.REMARK4; //备注4
            parameters[12].Value = model.REMARK5; //备注5
            parameters[13].Value = model.REMARK6; //备注6
            parameters[14].Value = model.REMARK7; //备注7
            parameters[15].Value = model.REMARK8; //备注8
            parameters[16].Value = model.REMARK9; //备注9
            parameters[17].Value = model.REMARK10; //备注10
            parameters[18].Value = model.REMARK11; //备注11
            parameters[19].Value = model.REMARK12; //备注12
            parameters[20].Value = model.REMARK13; //备注13
            parameters[21].Value = model.REMARK14; //备注14
            parameters[22].Value = model.REMARK15; //备注15

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        public int AddNotall(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GH_TASKINFO(");
            strSql.Append("ID");
            //列出需插入的表字段
            int Param_Num = 0;
            if (model.TASKNO != "")
            {
                Param_Num++;
                strSql.Append(",TASKNO");
            }
            if (model.CTVNO != "")
            {
                Param_Num++;
                strSql.Append(",CTVNO");
            }
            if (model.TASKNAME != "")
            {
                Param_Num++;
                strSql.Append(",TASKNAME");
            }
            if (model.STARTTIME != "")
            {
                Param_Num++;
                strSql.Append(",STARTTIME");
            }
            if (model.ENDTIME != "")
            {
                Param_Num++;
                strSql.Append(",ENDTIME");
            }
            //if (model.TASKTYPE != 0 )
            {
                Param_Num++;
                strSql.Append(",TASKTYPE");
            }
            //if (model.ISOFHISTORY != 0 )
            {
                Param_Num++;
                strSql.Append(",ISOFHISTORY");
            }
            if (model.REMARK != "")
            {
                Param_Num++;
                strSql.Append(",REMARK");
            }
            if (model.REMARK1 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK1");
            }
            if (model.REMARK2 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK2");
            }
            if (model.REMARK3 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK3");
            }
            if (model.REMARK4 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK4");
            }
            if (model.REMARK5 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK5");
            }
            if (model.REMARK6 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK6");
            }
            if (model.REMARK7 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK7");
            }
            if (model.REMARK8 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK8");
            }
            if (model.REMARK9 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK9");
            }
            if (model.REMARK10 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK10");
            }
            if (model.REMARK11 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK11");
            }
            if (model.REMARK12 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK12");
            }
            if (model.REMARK13 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK13");
            }
            if (model.REMARK14 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK14");
            }
            if (model.REMARK15 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK15");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.TASKNO != "")
            {
                strSql.Append(",:TASKNO");
            }
            if (model.CTVNO != "")
            {
                strSql.Append(",:CTVNO");
            }
            if (model.TASKNAME != "")
            {
                strSql.Append(",:TASKNAME");
            }
            if (model.STARTTIME != "")
            {
                strSql.Append(",:STARTTIME");
            }
            if (model.ENDTIME != "")
            {
                strSql.Append(",:ENDTIME");
            }
            strSql.Append(",:TASKTYPE");
            strSql.Append(",:ISOFHISTORY");
            if (model.REMARK != "")
            {
                strSql.Append(",:REMARK");
            }
            if (model.REMARK1 != "")
            {
                strSql.Append(",:REMARK1");
            }
            if (model.REMARK2 != "")
            {
                strSql.Append(",:REMARK2");
            }
            if (model.REMARK3 != "")
            {
                strSql.Append(",:REMARK3");
            }
            if (model.REMARK4 != "")
            {
                strSql.Append(",:REMARK4");
            }
            if (model.REMARK5 != "")
            {
                strSql.Append(",:REMARK5");
            }
            if (model.REMARK6 != "")
            {
                strSql.Append(",:REMARK6");
            }
            if (model.REMARK7 != "")
            {
                strSql.Append(",:REMARK7");
            }
            if (model.REMARK8 != "")
            {
                strSql.Append(",:REMARK8");
            }
            if (model.REMARK9 != "")
            {
                strSql.Append(",:REMARK9");
            }
            if (model.REMARK10 != "")
            {
                strSql.Append(",:REMARK10");
            }
            if (model.REMARK11 != "")
            {
                strSql.Append(",:REMARK11");
            }
            if (model.REMARK12 != "")
            {
                strSql.Append(",:REMARK12");
            }
            if (model.REMARK13 != "")
            {
                strSql.Append(",:REMARK13");
            }
            if (model.REMARK14 != "")
            {
                strSql.Append(",:REMARK14");
            }
            if (model.REMARK15 != "")
            {
                strSql.Append(",:REMARK15");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.TASKNO != "")
            {
                parameters[index_num] = new OracleParameter(":TASKNO", OracleType.VarChar, 20);//任务编号
                parameters[index_num].Value = model.TASKNO;
                index_num++;
            }
            if (model.CTVNO != "")
            {
                parameters[index_num] = new OracleParameter(":CTVNO", OracleType.VarChar, 20);//ChinaHV编号
                parameters[index_num].Value = model.CTVNO;
                index_num++;
            }
            if (model.TASKNAME != "")
            {
                parameters[index_num] = new OracleParameter(":TASKNAME", OracleType.VarChar, 128);//任务名称
                parameters[index_num].Value = model.TASKNAME;
                index_num++;
            }
            if (model.STARTTIME != "")
            {
                parameters[index_num] = new OracleParameter(":STARTTIME", OracleType.VarChar, 20);//任务开始时间
                parameters[index_num].Value = model.STARTTIME;
                index_num++;
            }
            if (model.ENDTIME != "")
            {
                parameters[index_num] = new OracleParameter(":ENDTIME", OracleType.VarChar, 20);//任务结束时间
                parameters[index_num].Value = model.ENDTIME;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":TASKTYPE", OracleType.Number, 2);//任务类型
                parameters[index_num].Value = model.TASKTYPE;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":ISOFHISTORY", OracleType.Number, 2);//是否转为历史
                parameters[index_num].Value = model.ISOFHISTORY;
                index_num++;
            }
            if (model.REMARK != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK", OracleType.VarChar, 20);//备注
                parameters[index_num].Value = model.REMARK;
                index_num++;
            }
            if (model.REMARK1 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK1", OracleType.VarChar, 20);//备注1
                parameters[index_num].Value = model.REMARK1;
                index_num++;
            }
            if (model.REMARK2 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK2", OracleType.VarChar, 20);//备注2
                parameters[index_num].Value = model.REMARK2;
                index_num++;
            }
            if (model.REMARK3 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK3", OracleType.VarChar, 20);//备注3
                parameters[index_num].Value = model.REMARK3;
                index_num++;
            }
            if (model.REMARK4 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK4", OracleType.VarChar, 20);//备注4
                parameters[index_num].Value = model.REMARK4;
                index_num++;
            }
            if (model.REMARK5 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK5", OracleType.VarChar, 20);//备注5
                parameters[index_num].Value = model.REMARK5;
                index_num++;
            }
            if (model.REMARK6 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK6", OracleType.VarChar, 20);//备注6
                parameters[index_num].Value = model.REMARK6;
                index_num++;
            }
            if (model.REMARK7 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK7", OracleType.VarChar, 20);//备注7
                parameters[index_num].Value = model.REMARK7;
                index_num++;
            }
            if (model.REMARK8 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK8", OracleType.VarChar, 20);//备注8
                parameters[index_num].Value = model.REMARK8;
                index_num++;
            }
            if (model.REMARK9 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK9", OracleType.VarChar, 20);//备注9
                parameters[index_num].Value = model.REMARK9;
                index_num++;
            }
            if (model.REMARK10 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK10", OracleType.VarChar, 20);//备注10
                parameters[index_num].Value = model.REMARK10;
                index_num++;
            }
            if (model.REMARK11 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK11", OracleType.VarChar, 20);//备注11
                parameters[index_num].Value = model.REMARK11;
                index_num++;
            }
            if (model.REMARK12 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK12", OracleType.VarChar, 20);//备注12
                parameters[index_num].Value = model.REMARK12;
                index_num++;
            }
            if (model.REMARK13 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK13", OracleType.VarChar, 20);//备注13
                parameters[index_num].Value = model.REMARK13;
                index_num++;
            }
            if (model.REMARK14 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK14", OracleType.VarChar, 20);//备注14
                parameters[index_num].Value = model.REMARK14;
                index_num++;
            }
            if (model.REMARK15 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK15", OracleType.VarChar, 20);//备注15
                parameters[index_num].Value = model.REMARK15;
                index_num++;
            }
            int ret_value = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (ret_value >= 0)
            {
                return model.ID;
            }
            else
                return -1;
        } /// <summary>
        /// 是否存在该记录(model)
        /// </summary>
        public bool Existsmodel(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GH_TASKINFO");
            strSql.Append(" where  TASKNO=:TASKNO and CTVNO=:CTVNO and TASKNAME=:TASKNAME and to_char(STARTTIME,'yyyy-mm-dd') =:STARTTIME and to_char(ENDTIME,'yyyy-mm-dd') =:ENDTIME and TASKTYPE=:TASKTYPE and ISOFHISTORY=:ISOFHISTORY and REMARK=:REMARK and REMARK1=:REMARK1 and REMARK2=:REMARK2 and REMARK3=:REMARK3 and REMARK4=:REMARK4 and REMARK5=:REMARK5 and REMARK6=:REMARK6 and REMARK7=:REMARK7 and REMARK8=:REMARK8 and REMARK9=:REMARK9 and REMARK10=:REMARK10 and REMARK11=:REMARK11 and REMARK12=:REMARK12 and REMARK13=:REMARK13 and REMARK14=:REMARK14 and REMARK15=:REMARK15");
            OracleParameter[] parameters = {  
					new OracleParameter(":TASKNO", OracleType.VarChar,20),
					new OracleParameter(":CTVNO", OracleType.VarChar,20),
					new OracleParameter(":TASKNAME", OracleType.VarChar,128),
					new OracleParameter(":STARTTIME", OracleType.VarChar,20),
					new OracleParameter(":ENDTIME", OracleType.VarChar,20),
					new OracleParameter(":TASKTYPE", OracleType.Number,2),
					new OracleParameter(":ISOFHISTORY", OracleType.Number,2),
					new OracleParameter(":REMARK", OracleType.VarChar,20),
					new OracleParameter(":REMARK1", OracleType.VarChar,20),
					new OracleParameter(":REMARK2", OracleType.VarChar,20),
					new OracleParameter(":REMARK3", OracleType.VarChar,20),
					new OracleParameter(":REMARK4", OracleType.VarChar,20),
					new OracleParameter(":REMARK5", OracleType.VarChar,20),
					new OracleParameter(":REMARK6", OracleType.VarChar,20),
					new OracleParameter(":REMARK7", OracleType.VarChar,20),
					new OracleParameter(":REMARK8", OracleType.VarChar,20),
					new OracleParameter(":REMARK9", OracleType.VarChar,20),
					new OracleParameter(":REMARK10", OracleType.VarChar,20),
					new OracleParameter(":REMARK11", OracleType.VarChar,20),
					new OracleParameter(":REMARK12", OracleType.VarChar,20),
					new OracleParameter(":REMARK13", OracleType.VarChar,20),
					new OracleParameter(":REMARK14", OracleType.VarChar,20),
					new OracleParameter(":REMARK15", OracleType.VarChar,20)};
            parameters[0].Value = model.TASKNO; //任务编号
            parameters[1].Value = model.CTVNO; //ChinaHV编号
            parameters[2].Value = model.TASKNAME; //任务名称
            parameters[3].Value = model.STARTTIME; //任务开始时间
            parameters[4].Value = model.ENDTIME; //任务结束时间
            parameters[5].Value = model.TASKTYPE; //任务类型
            parameters[6].Value = model.ISOFHISTORY; //是否转为历史
            parameters[7].Value = model.REMARK; //备注
            parameters[8].Value = model.REMARK1; //备注1
            parameters[9].Value = model.REMARK2; //备注2
            parameters[10].Value = model.REMARK3; //备注3
            parameters[11].Value = model.REMARK4; //备注4
            parameters[12].Value = model.REMARK5; //备注5
            parameters[13].Value = model.REMARK6; //备注6
            parameters[14].Value = model.REMARK7; //备注7
            parameters[15].Value = model.REMARK8; //备注8
            parameters[16].Value = model.REMARK9; //备注9
            parameters[17].Value = model.REMARK10; //备注10
            parameters[18].Value = model.REMARK11; //备注11
            parameters[19].Value = model.REMARK12; //备注12
            parameters[20].Value = model.REMARK13; //备注13
            parameters[21].Value = model.REMARK14; //备注14
            parameters[22].Value = model.REMARK15; //备注15

            return false;
        }

        public int UpdateNotall(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GH_TASKINFO(");
            strSql.Append("ID");
            //列出需哟插入的表字段
            int Param_Num = 0;
            if (model.TASKNO != "")
            {
                Param_Num++;
                strSql.Append(",TASKNO");
            }
            if (model.CTVNO != "")
            {
                Param_Num++;
                strSql.Append(",CTVNO");
            }
            if (model.TASKNAME != "")
            {
                Param_Num++;
                strSql.Append(",TASKNAME");
            }
            if (model.STARTTIME != "")
            {
                Param_Num++;
                strSql.Append(",STARTTIME");
            }
            if (model.ENDTIME != "")
            {
                Param_Num++;
                strSql.Append(",ENDTIME");
            }
            //if (model.TASKTYPE != 0 )
            {
                Param_Num++;
                strSql.Append(",TASKTYPE");
            }
            //if (model.ISOFHISTORY != 0 )
            {
                Param_Num++;
                strSql.Append(",ISOFHISTORY");
            }
            if (model.REMARK != "")
            {
                Param_Num++;
                strSql.Append(",REMARK");
            }
            if (model.REMARK1 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK1");
            }
            if (model.REMARK2 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK2");
            }
            if (model.REMARK3 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK3");
            }
            if (model.REMARK4 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK4");
            }
            if (model.REMARK5 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK5");
            }
            if (model.REMARK6 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK6");
            }
            if (model.REMARK7 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK7");
            }
            if (model.REMARK8 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK8");
            }
            if (model.REMARK9 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK9");
            }
            if (model.REMARK10 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK10");
            }
            if (model.REMARK11 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK11");
            }
            if (model.REMARK12 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK12");
            }
            if (model.REMARK13 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK13");
            }
            if (model.REMARK14 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK14");
            }
            if (model.REMARK15 != "")
            {
                Param_Num++;
                strSql.Append(",REMARK15");
            }
            strSql.Append(" ) ");
            strSql.Append(" values (");
            strSql.Append(":ID");
            //列出需哟插入的表字段value对象 
            if (model.TASKNO != "")
            {
                strSql.Append(",:TASKNO");
            }
            if (model.CTVNO != "")
            {
                strSql.Append(",:CTVNO");
            }
            if (model.TASKNAME != "")
            {
                strSql.Append(",:TASKNAME");
            }
            if (model.STARTTIME != "")
            {
                strSql.Append(",:STARTTIME");
            }
            if (model.ENDTIME != "")
            {
                strSql.Append(",:ENDTIME");
            }
            strSql.Append(",:TASKTYPE");
            strSql.Append(",:ISOFHISTORY");
            if (model.REMARK != "")
            {
                strSql.Append(",:REMARK");
            }
            if (model.REMARK1 != "")
            {
                strSql.Append(",:REMARK1");
            }
            if (model.REMARK2 != "")
            {
                strSql.Append(",:REMARK2");
            }
            if (model.REMARK3 != "")
            {
                strSql.Append(",:REMARK3");
            }
            if (model.REMARK4 != "")
            {
                strSql.Append(",:REMARK4");
            }
            if (model.REMARK5 != "")
            {
                strSql.Append(",:REMARK5");
            }
            if (model.REMARK6 != "")
            {
                strSql.Append(",:REMARK6");
            }
            if (model.REMARK7 != "")
            {
                strSql.Append(",:REMARK7");
            }
            if (model.REMARK8 != "")
            {
                strSql.Append(",:REMARK8");
            }
            if (model.REMARK9 != "")
            {
                strSql.Append(",:REMARK9");
            }
            if (model.REMARK10 != "")
            {
                strSql.Append(",:REMARK10");
            }
            if (model.REMARK11 != "")
            {
                strSql.Append(",:REMARK11");
            }
            if (model.REMARK12 != "")
            {
                strSql.Append(",:REMARK12");
            }
            if (model.REMARK13 != "")
            {
                strSql.Append(",:REMARK13");
            }
            if (model.REMARK14 != "")
            {
                strSql.Append(",:REMARK14");
            }
            if (model.REMARK15 != "")
            {
                strSql.Append(",:REMARK15");
            }
            strSql.Append(" ) ");
            OracleParameter[] parameters = new OracleParameter[(Param_Num + 1)];
            parameters[0] = new OracleParameter(":ID", OracleType.Number, 4);
            parameters[0].Value = model.ID;
            int index_num = 1;
            //列出需哟插入的表字段value对象的具体值
            if (model.TASKNO != "")
            {
                parameters[index_num] = new OracleParameter(":TASKNO", OracleType.VarChar, 20);//任务编号
                parameters[index_num].Value = model.TASKNO;
                index_num++;
            }
            if (model.CTVNO != "")
            {
                parameters[index_num] = new OracleParameter(":CTVNO", OracleType.VarChar, 20);//ChinaHV编号
                parameters[index_num].Value = model.CTVNO;
                index_num++;
            }
            if (model.TASKNAME != "")
            {
                parameters[index_num] = new OracleParameter(":TASKNAME", OracleType.VarChar, 128);//任务名称
                parameters[index_num].Value = model.TASKNAME;
                index_num++;
            }
            if (model.STARTTIME != "")
            {
                parameters[index_num] = new OracleParameter(":STARTTIME", OracleType.VarChar, 20);//任务开始时间
                parameters[index_num].Value = model.STARTTIME;
                index_num++;
            }
            if (model.ENDTIME != "")
            {
                parameters[index_num] = new OracleParameter(":ENDTIME", OracleType.VarChar, 20);//任务结束时间
                parameters[index_num].Value = model.ENDTIME;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":TASKTYPE", OracleType.Number, 2);//任务类型
                parameters[index_num].Value = model.TASKTYPE;
                index_num++;
            }
            {
                parameters[index_num] = new OracleParameter(":ISOFHISTORY", OracleType.Number, 2);//是否转为历史
                parameters[index_num].Value = model.ISOFHISTORY;
                index_num++;
            }
            if (model.REMARK != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK", OracleType.VarChar, 20);//备注
                parameters[index_num].Value = model.REMARK;
                index_num++;
            }
            if (model.REMARK1 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK1", OracleType.VarChar, 20);//备注1
                parameters[index_num].Value = model.REMARK1;
                index_num++;
            }
            if (model.REMARK2 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK2", OracleType.VarChar, 20);//备注2
                parameters[index_num].Value = model.REMARK2;
                index_num++;
            }
            if (model.REMARK3 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK3", OracleType.VarChar, 20);//备注3
                parameters[index_num].Value = model.REMARK3;
                index_num++;
            }
            if (model.REMARK4 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK4", OracleType.VarChar, 20);//备注4
                parameters[index_num].Value = model.REMARK4;
                index_num++;
            }
            if (model.REMARK5 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK5", OracleType.VarChar, 20);//备注5
                parameters[index_num].Value = model.REMARK5;
                index_num++;
            }
            if (model.REMARK6 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK6", OracleType.VarChar, 20);//备注6
                parameters[index_num].Value = model.REMARK6;
                index_num++;
            }
            if (model.REMARK7 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK7", OracleType.VarChar, 20);//备注7
                parameters[index_num].Value = model.REMARK7;
                index_num++;
            }
            if (model.REMARK8 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK8", OracleType.VarChar, 20);//备注8
                parameters[index_num].Value = model.REMARK8;
                index_num++;
            }
            if (model.REMARK9 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK9", OracleType.VarChar, 20);//备注9
                parameters[index_num].Value = model.REMARK9;
                index_num++;
            }
            if (model.REMARK10 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK10", OracleType.VarChar, 20);//备注10
                parameters[index_num].Value = model.REMARK10;
                index_num++;
            }
            if (model.REMARK11 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK11", OracleType.VarChar, 20);//备注11
                parameters[index_num].Value = model.REMARK11;
                index_num++;
            }
            if (model.REMARK12 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK12", OracleType.VarChar, 20);//备注12
                parameters[index_num].Value = model.REMARK12;
                index_num++;
            }
            if (model.REMARK13 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK13", OracleType.VarChar, 20);//备注13
                parameters[index_num].Value = model.REMARK13;
                index_num++;
            }
            if (model.REMARK14 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK14", OracleType.VarChar, 20);//备注14
                parameters[index_num].Value = model.REMARK14;
                index_num++;
            }
            if (model.REMARK15 != "")
            {
                parameters[index_num] = new OracleParameter(":REMARK15", OracleType.VarChar, 20);//备注15
                parameters[index_num].Value = model.REMARK15;
                index_num++;
            }
            int ret_value = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (ret_value >= 0)
            {
                return model.ID;
            }
            else
                return -1;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GH_TASKINFO set ");
            strSql.Append("TASKNO=:TASKNO,");
            strSql.Append("CTVNO=:CTVNO,");
            strSql.Append("TASKNAME=:TASKNAME,");
            strSql.Append("STARTTIME=:STARTTIME,");
            strSql.Append("ENDTIME=:ENDTIME,");
            strSql.Append("TASKTYPE=:TASKTYPE,");
            strSql.Append("ISOFHISTORY=:ISOFHISTORY,");
            strSql.Append("REMARK=:REMARK,");
            strSql.Append("REMARK1=:REMARK1,");
            strSql.Append("REMARK2=:REMARK2,");
            strSql.Append("REMARK3=:REMARK3,");
            strSql.Append("REMARK4=:REMARK4,");
            strSql.Append("REMARK5=:REMARK5,");
            strSql.Append("REMARK6=:REMARK6,");
            strSql.Append("REMARK7=:REMARK7,");
            strSql.Append("REMARK8=:REMARK8,");
            strSql.Append("REMARK9=:REMARK9,");
            strSql.Append("REMARK10=:REMARK10,");
            strSql.Append("REMARK11=:REMARK11,");
            strSql.Append("REMARK12=:REMARK12,");
            strSql.Append("REMARK13=:REMARK13,");
            strSql.Append("REMARK14=:REMARK14,");
            strSql.Append("REMARK15=:REMARK15");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,15),
					new OracleParameter(":TASKNO", OracleType.VarChar,20),
					new OracleParameter(":CTVNO", OracleType.VarChar,20),
					new OracleParameter(":TASKNAME", OracleType.VarChar,128),
					new OracleParameter(":STARTTIME", OracleType.VarChar,20),
					new OracleParameter(":ENDTIME", OracleType.VarChar,20),
					new OracleParameter(":TASKTYPE", OracleType.Number,2),
					new OracleParameter(":ISOFHISTORY", OracleType.Number,2),
					new OracleParameter(":REMARK", OracleType.VarChar,20),
					new OracleParameter(":REMARK1", OracleType.VarChar,20),
					new OracleParameter(":REMARK2", OracleType.VarChar,20),
					new OracleParameter(":REMARK3", OracleType.VarChar,20),
					new OracleParameter(":REMARK4", OracleType.VarChar,20),
					new OracleParameter(":REMARK5", OracleType.VarChar,20),
					new OracleParameter(":REMARK6", OracleType.VarChar,20),
					new OracleParameter(":REMARK7", OracleType.VarChar,20),
					new OracleParameter(":REMARK8", OracleType.VarChar,20),
					new OracleParameter(":REMARK9", OracleType.VarChar,20),
					new OracleParameter(":REMARK10", OracleType.VarChar,20),
					new OracleParameter(":REMARK11", OracleType.VarChar,20),
					new OracleParameter(":REMARK12", OracleType.VarChar,20),
					new OracleParameter(":REMARK13", OracleType.VarChar,20),
					new OracleParameter(":REMARK14", OracleType.VarChar,20),
					new OracleParameter(":REMARK15", OracleType.VarChar,20)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.TASKNO; //任务编号
            parameters[2].Value = model.CTVNO; //ChinaHV编号
            parameters[3].Value = model.TASKNAME; //任务名称
            parameters[4].Value = model.STARTTIME; //任务开始时间
            parameters[5].Value = model.ENDTIME; //任务结束时间
            parameters[6].Value = model.TASKTYPE; //任务类型
            parameters[7].Value = model.ISOFHISTORY; //是否转为历史
            parameters[8].Value = model.REMARK; //备注
            parameters[9].Value = model.REMARK1; //备注1
            parameters[10].Value = model.REMARK2; //备注2
            parameters[11].Value = model.REMARK3; //备注3
            parameters[12].Value = model.REMARK4; //备注4
            parameters[13].Value = model.REMARK5; //备注5
            parameters[14].Value = model.REMARK6; //备注6
            parameters[15].Value = model.REMARK7; //备注7
            parameters[16].Value = model.REMARK8; //备注8
            parameters[17].Value = model.REMARK9; //备注9
            parameters[18].Value = model.REMARK10; //备注10
            parameters[19].Value = model.REMARK11; //备注11
            parameters[20].Value = model.REMARK12; //备注12
            parameters[21].Value = model.REMARK13; //备注13
            parameters[22].Value = model.REMARK14; //备注14
            parameters[23].Value = model.REMARK15; //备注15

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 事务处理更新一条数据
        /// </summary>
        public DictionaryEntry Updatesql(hbapp.Model.ghdata.GH_TASKINFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GH_TASKINFO set ");
            strSql.Append("TASKNO=:TASKNO,");
            strSql.Append("CTVNO=:CTVNO,");
            strSql.Append("TASKNAME=:TASKNAME,");
            strSql.Append("STARTTIME=:STARTTIME,");
            strSql.Append("ENDTIME=:ENDTIME,");
            strSql.Append("TASKTYPE=:TASKTYPE,");
            strSql.Append("ISOFHISTORY=:ISOFHISTORY,");
            strSql.Append("REMARK=:REMARK,");
            strSql.Append("REMARK1=:REMARK1,");
            strSql.Append("REMARK2=:REMARK2,");
            strSql.Append("REMARK3=:REMARK3,");
            strSql.Append("REMARK4=:REMARK4,");
            strSql.Append("REMARK5=:REMARK5,");
            strSql.Append("REMARK6=:REMARK6,");
            strSql.Append("REMARK7=:REMARK7,");
            strSql.Append("REMARK8=:REMARK8,");
            strSql.Append("REMARK9=:REMARK9,");
            strSql.Append("REMARK10=:REMARK10,");
            strSql.Append("REMARK11=:REMARK11,");
            strSql.Append("REMARK12=:REMARK12,");
            strSql.Append("REMARK13=:REMARK13,");
            strSql.Append("REMARK14=:REMARK14,");
            strSql.Append("REMARK15=:REMARK15");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleType.Number,15),
					new OracleParameter(":TASKNO", OracleType.VarChar,20),
					new OracleParameter(":CTVNO", OracleType.VarChar,20),
					new OracleParameter(":TASKNAME", OracleType.VarChar,128),
					new OracleParameter(":STARTTIME", OracleType.VarChar,20),
					new OracleParameter(":ENDTIME", OracleType.VarChar,20),
					new OracleParameter(":TASKTYPE", OracleType.Number,2),
					new OracleParameter(":ISOFHISTORY", OracleType.Number,2),
					new OracleParameter(":REMARK", OracleType.VarChar,20),
					new OracleParameter(":REMARK1", OracleType.VarChar,20),
					new OracleParameter(":REMARK2", OracleType.VarChar,20),
					new OracleParameter(":REMARK3", OracleType.VarChar,20),
					new OracleParameter(":REMARK4", OracleType.VarChar,20),
					new OracleParameter(":REMARK5", OracleType.VarChar,20),
					new OracleParameter(":REMARK6", OracleType.VarChar,20),
					new OracleParameter(":REMARK7", OracleType.VarChar,20),
					new OracleParameter(":REMARK8", OracleType.VarChar,20),
					new OracleParameter(":REMARK9", OracleType.VarChar,20),
					new OracleParameter(":REMARK10", OracleType.VarChar,20),
					new OracleParameter(":REMARK11", OracleType.VarChar,20),
					new OracleParameter(":REMARK12", OracleType.VarChar,20),
					new OracleParameter(":REMARK13", OracleType.VarChar,20),
					new OracleParameter(":REMARK14", OracleType.VarChar,20),
					new OracleParameter(":REMARK15", OracleType.VarChar,20)};
            parameters[0].Value = model.ID; //编号
            parameters[1].Value = model.TASKNO; //任务编号
            parameters[2].Value = model.CTVNO; //ChinaHV编号
            parameters[3].Value = model.TASKNAME; //任务名称
            parameters[4].Value = model.STARTTIME; //任务开始时间
            parameters[5].Value = model.ENDTIME; //任务结束时间
            parameters[6].Value = model.TASKTYPE; //任务类型
            parameters[7].Value = model.ISOFHISTORY; //是否转为历史
            parameters[8].Value = model.REMARK; //备注
            parameters[9].Value = model.REMARK1; //备注1
            parameters[10].Value = model.REMARK2; //备注2
            parameters[11].Value = model.REMARK3; //备注3
            parameters[12].Value = model.REMARK4; //备注4
            parameters[13].Value = model.REMARK5; //备注5
            parameters[14].Value = model.REMARK6; //备注6
            parameters[15].Value = model.REMARK7; //备注7
            parameters[16].Value = model.REMARK8; //备注8
            parameters[17].Value = model.REMARK9; //备注9
            parameters[18].Value = model.REMARK10; //备注10
            parameters[19].Value = model.REMARK11; //备注11
            parameters[20].Value = model.REMARK12; //备注12
            parameters[21].Value = model.REMARK13; //备注13
            parameters[22].Value = model.REMARK14; //备注14
            parameters[23].Value = model.REMARK15; //备注15

            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete GH_TASKINFO ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 事务处理删除 (int ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DictionaryEntry DeleteSql(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete GH_TASKINFO ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
				new OracleParameter(":ID", OracleType.Number)
			};
            parameters[0].Value = ID;
            DictionaryEntry ret_boj = new DictionaryEntry(strSql, parameters);
            return ret_boj;
        }

        /// <summary>
        /// 事务处理Hashtable
        /// </summary>
        /// <param name="tb">Hashtable</param>
        /// <returns>int</returns>
        public int ExecuteTrans(Hashtable tb)
        {
            return DbHelperOra.ExecuteSqlTran(tb);
        }

        /// <summary>
        /// 事务处理
        /// </summary>
        /// <param name="SQLStringList">ArrayList</param>
        /// <returns>int</returns>
        public int ExecuteSqlTranByArray(ArrayList SQLStringList)
        {
            return DbHelperOra.ExecuteSqlTranByArray(SQLStringList);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public hbapp.Model.ghdata.GH_TASKINFO GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GH_TASKINFO ");
            strSql.Append(" where ID=:ID");
            OracleParameter[] parameters = {
   				new OracleParameter(":ID", OracleType.Number)};
            parameters[0].Value = ID;
            hbapp.Model.ghdata.GH_TASKINFO model = new hbapp.Model.ghdata.GH_TASKINFO();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TASKNO = ds.Tables[0].Rows[0]["TASKNO"].ToString();
                model.CTVNO = ds.Tables[0].Rows[0]["CTVNO"].ToString();
                model.TASKNAME = ds.Tables[0].Rows[0]["TASKNAME"].ToString();
                model.STARTTIME = ds.Tables[0].Rows[0]["STARTTIME"].ToString();
                model.ENDTIME = ds.Tables[0].Rows[0]["ENDTIME"].ToString();
                if (ds.Tables[0].Rows[0]["TASKTYPE"].ToString() != "")
                {
                    model.TASKTYPE = int.Parse(ds.Tables[0].Rows[0]["TASKTYPE"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["ISOFHISTORY"].ToString() != "")
                {
                    model.ISOFHISTORY = int.Parse(ds.Tables[0].Rows[0]["ISOFHISTORY"].ToString().Trim());
                }
                model.REMARK = ds.Tables[0].Rows[0]["REMARK"].ToString();
                model.REMARK1 = ds.Tables[0].Rows[0]["REMARK1"].ToString();
                model.REMARK2 = ds.Tables[0].Rows[0]["REMARK2"].ToString();
                model.REMARK3 = ds.Tables[0].Rows[0]["REMARK3"].ToString();
                model.REMARK4 = ds.Tables[0].Rows[0]["REMARK4"].ToString();
                model.REMARK5 = ds.Tables[0].Rows[0]["REMARK5"].ToString();
                model.REMARK6 = ds.Tables[0].Rows[0]["REMARK6"].ToString();
                model.REMARK7 = ds.Tables[0].Rows[0]["REMARK7"].ToString();
                model.REMARK8 = ds.Tables[0].Rows[0]["REMARK8"].ToString();
                model.REMARK9 = ds.Tables[0].Rows[0]["REMARK9"].ToString();
                model.REMARK10 = ds.Tables[0].Rows[0]["REMARK10"].ToString();
                model.REMARK11 = ds.Tables[0].Rows[0]["REMARK11"].ToString();
                model.REMARK12 = ds.Tables[0].Rows[0]["REMARK12"].ToString();
                model.REMARK13 = ds.Tables[0].Rows[0]["REMARK13"].ToString();
                model.REMARK14 = ds.Tables[0].Rows[0]["REMARK14"].ToString();
                model.REMARK15 = ds.Tables[0].Rows[0]["REMARK15"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GH_TASKINFO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID  desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}


