using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Simetri.Core.DataUtil
{
    public class AdoTemplate
    {
        private SqlConnection connection = new SqlConnection(ConnectionSingleton.Instance.ConnectionString);
        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }



        public Object TekDegerGetir(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            object sonuc = 0;
            try
            {
                Connection.Open();
                sonuc = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, cmdText);
            }
            finally
            {
                Connection.Close();
            }
            return sonuc;
        }
        
        public void SorguHariciKomutCalistir(String cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, cmdText);
            }
            finally
            {
                Connection.Close();
            }
        }



        public void SorguHariciKomutCalistir(SqlCommand cmd)
        {
            SqlConnection conn = ConnectionSingleton.Instance.Connection;
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, cmd.CommandText);
            }
            finally
            {
                conn.Close();
            }
        }



        public void SorguHariciKomutCalistir(string sql, SqlParameter[] prmListesi)
        {
            SqlConnection conn = ConnectionSingleton.Instance.Connection;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;



            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, sql);
            }
            finally
            {
                conn.Close();
            }


        }


        #region "DataTable Olusturma Methods"
        public DataTable DataTableOlustur(string sql, CommandType commandType)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, commandType);
            return dataTable;
        }
        public DataTable DataTableOlustur(string sql)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, CommandType.Text);
            return dataTable;
        }

        public DataTable DataTableOlustur(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, commandType, parameters);
            return dataTable;
        }
        public DataTable DataTableOlustur(string sql, SqlParameter[] parameters)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, CommandType.Text, parameters);
            return dataTable;
        }





        #endregion

        #region "DataTable Doldurma Methodlari"
        public void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType)
        {
            ValidateFillArguments(dataTable, sql);
            SorguCalistir(dataTable, sql, commandType);
        }
        public void DataTableDoldur(DataTable dataTable, string sql)
        {
            ValidateFillArguments(dataTable, sql);
            SorguCalistir(dataTable, sql, CommandType.Text);
        }
        public void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType
                , SqlParameter[] parameters)
        {
            ValidateFillArguments(dataTable, sql);
            SorguCalistir(dataTable, sql, commandType, parameters);
        }
        public void DataTableDoldur(DataTable dataTable, string sql
                , SqlParameter[] parameters)
        {
            ValidateFillArguments(dataTable, sql);
            SorguCalistir(dataTable, sql, CommandType.Text, parameters);
        }

        #endregion

        #region "Helpers"

        protected void SorguCalistir(DataTable dt, string sql, CommandType cmdType)
        {
            SqlConnection conn = ConnectionSingleton.Instance.Connection;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, sql);
            }
            finally
            {
                conn.Close();
            }

        }

        protected void SorguCalistir(DataTable dt, string sql, CommandType cmdType, SqlParameter[] parameters)
        {
            SqlConnection conn = ConnectionSingleton.Instance.Connection;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;
            foreach (SqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, sql);
            }
            finally
            {
                conn.Close();
            }

        }

        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Locale = CultureInfo.InvariantCulture;
            return dataTable;
        }

        protected virtual DataSet CreateDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            return dataSet;
        }

        protected virtual void ValidateFillArguments(DataTable dataTable, string sql)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable", "DataTable argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataSet Fill operation can not be null");
            }
        }
        protected virtual void ValidateFillArguments(DataSet dataSet, string sql)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet", "DataSet argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataSet Fill operation can not be null");
            }
        }
        protected virtual void ValidateFillArguments(DataSet dataSet, string sql, SqlParameter[] parameters)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet", "DataSet argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataSet Fill operation can not be null");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters", "Parameters for DataSet Fill operations can not be null");
            }
        }
        protected virtual void ValidateFillArguments(DataTable dataTable, string sql, SqlParameter[] parameters)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable", "DataTable argument can not be null");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql", "SQL for DataTable Fill operation can not be null");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters", "Parameters for DataTable Fill operations can not be null");
            }
        }
        #endregion

    }
}