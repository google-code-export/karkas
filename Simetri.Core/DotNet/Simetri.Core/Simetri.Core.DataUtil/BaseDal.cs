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
            paramDbTipiniSetle(prm, value);
            prm.Value = value;
            cmd.Parameters.Add(prm);
        }
        public void parameterEkle(SqlCommand cmd, string parameterName, object value, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = parameterName;
            paramDbTipiniSetle(prm,value);
            prm.Value = value;
            prm.Size = size;
            cmd.Parameters.Add(prm);
        }

        private void paramDbTipiniSetle(SqlParameter prm,object value)
        {
            if (value is string)
            {
                prm.SqlDbType = SqlDbType.VarChar;

            }else if (value is int)
            {
                prm.SqlDbType = SqlDbType.Int;
            }else if (value is Guid)
            {
                prm.SqlDbType = SqlDbType.UniqueIdentifier;
            }
            else if (value is long)
            {
                prm.SqlDbType = SqlDbType.BigInt;
            }
            else if (value is byte)
            {
                prm.SqlDbType = SqlDbType.TinyInt;
            }
            else if (value is short)
            {
                prm.SqlDbType = SqlDbType.TinyInt;
            }
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
                ExceptionDegistirici.Degistir(ex,sql);
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

        public abstract string SelectString
        {
            get;
        }

        public abstract void processRow(IDataReader dr, T row);
    }
}
