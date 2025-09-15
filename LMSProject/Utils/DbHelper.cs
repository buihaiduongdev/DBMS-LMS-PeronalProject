
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LMSProject.Utils
{
    public class DbHelper
    {
        private readonly string _connStr = "Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();
            return conn;
        }

        private void AddParameters(SqlCommand cmd, Dictionary<string, object> parameters)
        {
            if (parameters == null) return;

            foreach (var param in parameters)
            {
                cmd.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
            }
        }

        public object ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                AddParameters(cmd, parameters);
                return cmd.ExecuteScalar();
            }
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null, bool isStoredProcedure = false)
        {
            using (SqlConnection conn = GetConnection())
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

        public DataTable ExecuteReader(string sql, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                AddParameters(cmd, parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public object ExecuteScalarFunction(string functionName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = $"SELECT {functionName}(";
                if (parameters != null && parameters.Count > 0)
                {
                    sql += string.Join(", ", parameters.Keys);
                }
                sql += ")";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    AddParameters(cmd, parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public DataTable ExecuteTableFunction(string functionName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = $"SELECT * FROM {functionName}(";
                if (parameters != null && parameters.Count > 0)
                {
                    sql += string.Join(", ", parameters.Keys);
                }
                sql += ")";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
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
    }
}
