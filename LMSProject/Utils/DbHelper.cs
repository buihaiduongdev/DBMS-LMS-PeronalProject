using LMSProject.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LMSProject.Models; // Make sure to include this for the User model

namespace LMSProject.Utils
{
    public class DbHelper
    {
        private string GetConnectionString()
        {
            User currentUser = UserService.CurrentUser;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "."; 
            builder.InitialCatalog = "QuanLyThuVien";
            builder.IntegratedSecurity = false; 

            if (currentUser == null)
            {
                // Case 1: No user is logged in (Login screen)
                builder.UserID = "login_user";
                builder.Password = "LoginPassword123!";
            }
            else
            {
                // Case 2: User is logged in
                string sqlUsername;
                string sqlPassword = "StrongPassword123!"; // Common password for all role-based users

                if (currentUser.VaiTro == 0) // Admin role
                {
                    sqlUsername = "userAD";
                }
                else if (currentUser.VaiTro == 1) // Staff role
                {
                    // Check the specific staff position to assign the correct DB User
                    if (currentUser.ChucVu == "ThuThu")
                    {
                        sqlUsername = "userQL"; // Librarians get the Manager role in DB
                    }
                    else
                    {
                        sqlUsername = "userNV"; // Other staff get the basic Employee role in DB
                    }
                }
                
                builder.UserID = sqlUsername;
                builder.Password = sqlPassword;
            }

            return builder.ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
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
    }
}
