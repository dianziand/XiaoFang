using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SQLServerDAL
{
    public class CommonDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要显示的字段列表</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的记录数</param>
        /// <param name="fldSort">排序字段列表或条件</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="StrCondition">查询条件,不需where</param>
        /// <param name="ID">主表的主键</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>
        /// <returns></returns>
        public static DataTable GetResultSP_Page2000(
            string tblName,
            string fldName,
            int pageSize,
            int page,
            out int pageCount,

            out int Counts,
            string fldSort,
            int Sort,
            string strCondition,
            string ID,

            int Dist)
        {
            pageCount = 0;
            Counts = 0;
            SqlParameter[] parm ={
										new SqlParameter("@tblName",SqlDbType.VarChar,200),
										new SqlParameter("@fldName",SqlDbType.VarChar,500),
										new SqlParameter("@pageSize",SqlDbType.Int),
										new SqlParameter("@page",SqlDbType.Int),
										new SqlParameter("@pageCount",SqlDbType.Int),

										new SqlParameter("@Counts",SqlDbType.Int),
										new SqlParameter("@fldSort",SqlDbType.VarChar,200),
										new SqlParameter("@Sort",SqlDbType.Int),
										new SqlParameter("@strCondition",SqlDbType.VarChar,500),
										new SqlParameter("@ID",SqlDbType.VarChar,150),

										new SqlParameter("@Dist",SqlDbType.Int)

                                };

            parm[0].Value = tblName;
            parm[1].Value = fldName;
            parm[2].Value = pageSize;
            parm[3].Value = page;
            parm[4].Value = pageCount;

            parm[5].Value = Counts;
            parm[6].Value = fldSort;
            parm[7].Value = Sort;
            parm[8].Value = strCondition;
            parm[9].Value = ID;

            parm[10].Value = Dist;

            return SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, "SP_Page2000", CommandType.StoredProcedure, parm, out pageCount, out Counts, 5, 6);
        }
    }
}
