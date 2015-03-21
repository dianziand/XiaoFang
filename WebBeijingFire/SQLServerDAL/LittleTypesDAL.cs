using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using Entity;

namespace SQLServerDAL
{
    public class LittleTypesDAL
    {
        #region  LittleTypes自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddLittleTypesEntity(LittleTypesEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LittleTypes(");
            strSql.Append("LittleName,BigTypeID)");
            strSql.Append(" values (");
            strSql.Append("@LittleName,@BigTypeID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LittleName", SqlDbType.NVarChar,50),
					new SqlParameter("@BigTypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.LittleName;
            parameters[1].Value = model.BigTypeID;

            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static void UpdateLittleTypesEntity(LittleTypesEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LittleTypes set ");
            strSql.Append("LittleName=@LittleName,");
            strSql.Append("BigTypeID=@BigTypeID");
            strSql.Append(" where LittleTypeID=@LittleTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LittleTypeID", SqlDbType.Int,4),
					new SqlParameter("@LittleName", SqlDbType.NVarChar,50),
					new SqlParameter("@BigTypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.LittleTypeID;
            parameters[1].Value = model.LittleName;
            parameters[2].Value = model.BigTypeID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteLittleTypesEntity(int LittleTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LittleTypes ");
            strSql.Append(" where LittleTypeID=@LittleTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LittleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = LittleTypeID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static LittleTypesEntity GetLittleTypesEntity(int LittleTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LittleTypeID,LittleName,BigTypeID from LittleTypes ");
            strSql.Append(" where LittleTypeID=@LittleTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LittleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = LittleTypeID;

            LittleTypesEntity model = new LittleTypesEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LittleTypeID"].ToString() != "")
                {
                    model.LittleTypeID = int.Parse(ds.Tables[0].Rows[0]["LittleTypeID"].ToString());
                }
                model.LittleName = ds.Tables[0].Rows[0]["LittleName"].ToString();
                if (ds.Tables[0].Rows[0]["BigTypeID"].ToString() != "")
                {
                    model.BigTypeID = int.Parse(ds.Tables[0].Rows[0]["BigTypeID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  LittleTypes自动生成成员方法

        #region LittleTypes手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<LittleTypesEntity> GetLittleTypesEntityList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  LittleTypeID,LittleName,BigTypeID from LittleTypes ");

            IList<LittleTypesEntity> modelList = new List<LittleTypesEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    LittleTypesEntity model = new LittleTypesEntity();

                    if (ds.Tables[0].Rows[i]["LittleTypeID"].ToString() != "")
                    {
                        model.LittleTypeID = int.Parse(ds.Tables[0].Rows[i]["LittleTypeID"].ToString());
                    }
                    model.LittleName = ds.Tables[0].Rows[i]["LittleName"].ToString();
                    if (ds.Tables[0].Rows[i]["BigTypeID"].ToString() != "")
                    {
                        model.BigTypeID = int.Parse(ds.Tables[0].Rows[i]["BigTypeID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<LittleTypesEntity> GetLittleTypesEntityList(int Top, string strWhere, string filedOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" LittleTypeID,LittleName,BigTypeID from LittleTypes ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            IList<LittleTypesEntity> modelList = new List<LittleTypesEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    LittleTypesEntity model = new LittleTypesEntity();

                    if (ds.Tables[0].Rows[i]["LittleTypeID"].ToString() != "")
                    {
                        model.LittleTypeID = int.Parse(ds.Tables[0].Rows[i]["LittleTypeID"].ToString());
                    }
                    model.LittleName = ds.Tables[0].Rows[i]["LittleName"].ToString();
                    if (ds.Tables[0].Rows[i]["BigTypeID"].ToString() != "")
                    {
                        model.BigTypeID = int.Parse(ds.Tables[0].Rows[i]["BigTypeID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion LittleTypes手写方法
    }
}
