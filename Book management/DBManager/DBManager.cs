using System;
using System.Data;
using System.Data.SqlClient;

namespace Book_management.DatabaseManager
{
    class DBManager
        {
            public SqlConnection sc = new SqlConnection();
            public DBManager()
            {
                sc = new SqlConnection(@"Server = ERROR; Database = Bookify; integrated security =True");
            }
            public void Open()
            {
                if (sc.State == ConnectionState.Closed)
                {
                    sc.Open();
                }
            }

            public void Close()
            {
                if (sc.State == ConnectionState.Open)
                {
                    sc.Close();
                }
            }

            public DataTable Read(string store, SqlParameter[] pr)
            {
                SqlCommand scm = new SqlCommand();
                scm.Connection = sc;
                scm.CommandType = CommandType.StoredProcedure;
                scm.CommandText = store;
                if (pr != null)
                {
                    scm.Parameters.AddRange(pr);
                }
                SqlDataAdapter SDA = new SqlDataAdapter(scm);
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                return dt;
            }

            public void Execute(String store, SqlParameter[] pr)
            {
                SqlCommand smc = new SqlCommand();
                smc.Connection = sc;
                smc.CommandType = CommandType.StoredProcedure;
                smc.CommandText = store;
                if (pr != null)
                {
                    smc.Parameters.AddRange(pr);
                }
                smc.ExecuteNonQuery();
            }

            public DataTable SelectData(String storedProcedure, SqlParameter[] param)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;
                cmd.Connection = sc;
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
