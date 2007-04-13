using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Simetri.Core.DataUtil
{
    public abstract class BaseDal<T> where T : new()
    {
        public BaseDal()
        {

        }

        public void parameterEkle(SqlCommand cmd, string parameterName, object value)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parameterName;
            prm.SqlDbType = SqlDbType.VarChar;
            prm.Value = value;
            cmd.Parameters.Add(prm);
        }
        public void parameterEkle(SqlCommand cmd, string parameterName, object value, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parameterName;
            prm.SqlDbType = SqlDbType.VarChar;
            prm.Value = value;
            prm.Size = size;
            cmd.Parameters.Add(prm);
        }



        private SqlConnection connection = new SqlConnection(ConnectionSingleton.Instance.ConnectionString);

        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public void selectKomutuCalistir(List<T> liste, String sql)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Connection;
            SqlDataReader reader = null;
            try
            {
                Connection.Open();
                reader = cmd.ExecuteReader();

                T row = default(T);
                while (reader.Read())
                {
                    row = new T();
                    processRow(reader, row);
                    liste.Add(row);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    Connection.Close();
                }
            }
            return;


        }


        public abstract void processRow(IDataReader dr, T row);
    }
}
