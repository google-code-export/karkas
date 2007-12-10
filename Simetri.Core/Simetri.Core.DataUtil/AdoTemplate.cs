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

        public AdoTemplate()
        {

        }

        private HelperFunctions _helper;
        private HelperFunctions helper
        {
            get
            {
                if (_helper == null)
                {
                    _helper = new HelperFunctions(Connection);
                }
                return _helper;
            }
        }

        private PagingHelper _pagingHelper;

        private PagingHelper pagingHelper
        {
            get
            {
                if (_pagingHelper == null)
                {
                    _pagingHelper = new PagingHelper(Connection);
                }
                return _pagingHelper;
            }
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
        public Object TekDegerGetir(string cmdText, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            foreach (SqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

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
            cmd.Connection = Connection;
            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, cmd.CommandText);
            }
            finally
            {
                Connection.Close();
            }
        }



        public void SorguHariciKomutCalistir(string sql, SqlParameter[] prmListesi)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.CommandType = CommandType.Text;
            foreach (SqlParameter p in prmListesi)
            {
                cmd.Parameters.Add(p);
            }



            try
            {
                Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, sql);
            }
            finally
            {
                Connection.Close();
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
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, commandType);
        }
        public void DataTableDoldur(DataTable dataTable, string sql)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text);
        }
        public void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType
                , SqlParameter[] parameters)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, commandType, parameters);
        }
        public void DataTableDoldur(DataTable dataTable, string sql
                , SqlParameter[] parameters)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text, parameters);
        }

        #endregion

        #region "DataTable Olustur Sayfalama Yap"

        public DataTable DataTableOlusturSayfalamaYap(string sql
, int pPageSize, int pStartRowIndex, string pOrderBy, SqlParameter[] parameters)
        {
            return pagingHelper.DataTableOlusturSayfalamaYap(sql, pPageSize, pStartRowIndex, pOrderBy, parameters);
        }


        public DataTable DataTableOlusturSayfalamaYap(string sql
, int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            return pagingHelper.DataTableOlusturSayfalamaYap(sql, pPageSize, pStartRowIndex, pOrderBy);
        }




        #endregion

        #region "DataTable Doldur Sayfalama Yap"

        public void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql
        , int pPageSize, int pStartRowIndex, string pOrderBy, SqlParameter[] parameters)
        {
            pagingHelper.DataTableDoldurSayfalamaYap(dataTable, sql, pPageSize, pStartRowIndex, pOrderBy, parameters);
        }


        public void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql
                , int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            pagingHelper.DataTableDoldurSayfalamaYap(dataTable, sql, pPageSize, pStartRowIndex, pOrderBy);
        }



        #endregion


        #region "Helpers"


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

        #endregion

    }
}