using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using Entity;

namespace SQLServerDAL
{
    public class BigTypesDAL
    {
        #region  BigTypes自动生成成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddBigTypesEntity(BigTypesEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BigTypes(");
            strSql.Append("BigName)");
            strSql.Append(" values (");
            strSql.Append("@BigName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BigName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.BigName;

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
        public static void UpdateBigTypesEntity(BigTypesEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BigTypes set ");
            strSql.Append("BigName=@BigName");
            strSql.Append(" where BigTypeID=@BigTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BigTypeID", SqlDbType.Int,4),
					new SqlParameter("@BigName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.BigTypeID;
            parameters[1].Value = model.BigName;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static void DeleteBigTypesEntity(int BigTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BigTypes ");
            strSql.Append(" where BigTypeID=@BigTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BigTypeID", SqlDbType.Int,4)};
            parameters[0].Value = BigTypeID;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static BigTypesEntity GetBigTypesEntity(int BigTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BigTypeID,BigName from BigTypes ");
            strSql.Append(" where BigTypeID=@BigTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BigTypeID", SqlDbType.Int,4)};
            parameters[0].Value = BigTypeID;

            BigTypesEntity model = new BigTypesEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BigTypeID"].ToString() != "")
                {
                    model.BigTypeID = int.Parse(ds.Tables[0].Rows[0]["BigTypeID"].ToString());
                }
                model.BigName = ds.Tables[0].Rows[0]["BigName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  BigTypes自动生成成员方法


        #region BigTypes手写方法

        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static IList<BigTypesEntity> GetBigTypesEntityList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  LittleTypeID,LittleName,BigTypeID from LittleTypes ");

            IList<BigTypesEntity> modelList = new List<BigTypesEntity>();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql.ToString(), CommandType.Text, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    BigTypesEntity model = new BigTypesEntity();
                    if (ds.Tables[0].Rows[i]["BigTypeID"].ToString() != "")
                    {
                        model.BigTypeID = int.Parse(ds.Tables[0].Rows[i]["BigTypeID"].ToString());
                    }
                    model.BigName = ds.Tables[0].Rows[i]["BigName"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion BigTypes手写方法
    }

}