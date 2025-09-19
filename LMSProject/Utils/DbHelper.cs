using LMSProject.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LMSProject.Models;
using System.Windows.Forms;

namespace LMSProject.Utils
{
    public class DbHelper
    {
         private static string _sessionConnectionString;

        public static void BuildAndSetConnectionString(string username, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "QuanLyThuVien";
            builder.IntegratedSecurity = false;
            builder.UserID = username;
            builder.Password = Security.HashMD5(password);

            string connString = builder.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open(); 
                }
                _sessionConnectionString = connString;
            }
            catch (SqlException)
            {
                _sessionConnectionString = null;
                throw;
            }
        }

        public SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_sessionConnectionString))
            {
                throw new InvalidOperationException("Chuỗi kết nối chưa được thiết lập");
            }
            return new SqlConnection(_sessionConnectionString);
        }

        private void AddParameters(SqlCommand cmd, Dictionary<string, object> parameters)
        {
            if (parameters == null) return;
            foreach (var param in parameters)
            {
                cmd.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
            }
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (isStoredProcedure)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    AddParameters(cmd, parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteReader(string sql, Dictionary<string, object> parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (isStoredProcedure)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    AddParameters(cmd, parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public object ExecuteScalar(string sql, Dictionary<string, object> parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (isStoredProcedure)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    AddParameters(cmd, parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
        public int ExecuteProcedure(string procName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        // ExecuteScalarFunction: gọi scalar function SQL Server
        public object ExecuteScalarFunction(string functionName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = $"SELECT {functionName}(";

                if (parameters != null && parameters.Count > 0)
                    sql += string.Join(", ", parameters.Keys);

                sql += ")";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        // Hàm gọi table-valued function, trả về DataTable
        public DataTable ExecuteTableFunction(string functionName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                // Tạo câu SQL gọi TVF
                string sql = $"SELECT * FROM {functionName}(";

                if (parameters != null && parameters.Count > 0)
                {
                    sql += string.Join(", ", parameters.Keys);
                }
                sql += ")";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}
