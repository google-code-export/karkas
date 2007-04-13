using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Simetri.Core.DataUtil
{
    public abstract class BaseDal<T> where T : new()
    {
        protected AdoTemplate template = new AdoTemplate();

        public BaseDal()
        {

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
        public abstract string InsertString
        {
            get;
        }
        public abstract string UpdateString
        {
            get;
        }
        public abstract string DeleteString
        {
            get;
        }

        public abstract void processRow(IDataReader dr, T row);
    }
}
