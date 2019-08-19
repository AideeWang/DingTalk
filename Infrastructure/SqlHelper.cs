using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Infrastructure
{
    /// <summary>
    /// ADO.NET-------底层的数据操作
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// 通过构造函数来实例化连接字符串
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlHelper(string connectionString="")
        {
            this.connectionString = connectionString;
        }
        private string connectionString;
        /// <summary>
        /// 设置DB访问字符串
        /// </summary>
        public string ConnectionSrting
        {
            set { connectionString = value; }
        }

        #region 执行一个查询，返回查询的结果集+ExecuteDataTable(string sql, CommandType commandtype, SqlParameter[] parameters)
        public DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }
        public DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }

        /// <summary>
        /// 执行一个查询，返回查询的结果集。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandtype"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandtype, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();  //实例化datatable,用于装载查询的结果集
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = commandtype;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);   //将参数添加到sql语句中。
                        }
                    }
                    //申明sqldataadapter，通过cmd来实例化它，这个是数据设备器，可以直接往datatable,dataset中写入。
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);   //利用Fill来填充。
                }
            }
            return data;
        }
        #endregion

        #region 返回一个SqlDataReader对象。

        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }
        public SqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }

        /// <summary>
        /// 返回一个SqlDataReader，从 SQL Server 数据库读取行的只进流的方式
        /// </summary>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            //CommandBehavior.CloseConnection+关闭reader对象关闭与其连接的Connection对象。
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region 执行一个查询，返回结果集的首行首列。忽略其他行，其他列
        /// <summary>
        /// 只执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 可以执行存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }
        /// <summary>
        /// 执行一个查询，返回结果集的首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            //cmd.ExecuteScalar()+执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略其他列或行。
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }

        #endregion

        #region 进行CRUD操作

        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }
        public int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }
        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">执行的Sql语句</param>
        /// <param name="commandType">要执行的查询语句类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程的参数数组</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(cmd);
                }
            }
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }

        #endregion

        #region  返回当前连接的数据库中所有用户创建的数据库
        /// <summary>
        /// 返回当前连接的数据库中所有用户创建的数据库
        /// </summary>        
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DataTable GetTable(string tableName)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                table = conn.GetSchema(tableName);
            }
            return table;
        }
        #endregion
    }
}