using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace mvcdemo1.Models
{
    public class SQLHelper
    {
        //static string mystr = @"Data Source=(local);Initial Catalog=his;Integrated Security=True";
        private SqlConnection conn = new SqlConnection(Configuration.DbConnectionString);

        /// <summary>
        /// 执行查询操作，返回DataTable
        /// </summary>
        /// <param name="procName">要执行的存储过程名</param>
        /// <param name="prams">该存储过程所需要用到的参数数组</param>
        /// <returns>DataTable</returns>
        public DataTable ExcuteDataTable(string procName, SqlParameter[] prams)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (prams != null)
            {
                foreach (SqlParameter pram in prams)
                {
                    cmd.Parameters.Add(pram);
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }

        /// <summary>
        /// 执行插入，删除，修改等非查询操作
        /// </summary>
        /// <param name="procName">要执行的存储过程名</param>
        /// <param name="prams">该存储过程所需要用到的参数数组</param>
        /// <returns>若执行成功，则返回true,否则返回false</returns>
        public bool ExcuteNonQuery(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            if (prams != null)
            {
                foreach (SqlParameter pram in prams)
                {
                    cmd.Parameters.Add(pram);
                }
            }
            bool isSuccess = false;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch
            {
            }
            finally
            {
                cmd.Connection.Close();
            }
            return isSuccess;
        }
    }
}