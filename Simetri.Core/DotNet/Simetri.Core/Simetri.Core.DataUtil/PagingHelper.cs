using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Simetri.Core.DataUtil
{
    internal class PagingHelper
    {

        private HelperFunctions helper = new HelperFunctions();

        private const string PAGING_SQL = @"
                                WITH temp AS 
                                ( 
                                {0}
                                ) 
                                SELECT * 
                                FROM temp 
                                WHERE RowNumber >= {1} AND RowNumber  <= {2}
                                ";

        //Where RowNumber >= @RowStart and RowNumber <= @

        #region "DataTable Doldur"
        public void DataTableDoldurSayfalamaYap(
            DataTable dataTable, string sql 
            , int pPageSize, int pStartRowIndex
            , string pOrderBy, SqlParameter[] parameters)
        {
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text, parameters);
        }


        public void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql
        , int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text);

        }


        #endregion


        public DataTable DataTableOlusturSayfalamaYap(string sql
        , int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            DataTable dataTable = new DataTable();
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text);
            return dataTable;
        }


        public DataTable DataTableOlusturSayfalamaYap(string sql
, int pPageSize, int pStartRowIndex, string pOrderBy, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            pagingSqliniAyarla(ref sql, pPageSize, ref pStartRowIndex, pOrderBy);
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text, parameters);
            return dataTable;
        }



        public int KayitSayisiniBul(string sql, string orderby, int startRowIndex, int pageSize)
        {
            return 0;
        }

        #region HelperFunctions
        private static void pagingSqliniAyarla(ref string sql, int pPageSize, ref int pStartRowNumber, string pOrderBy)
        {
            if (pStartRowNumber == 0)
            {
                sql = sql.Replace("SELECT", "SELECT TOP " + pPageSize);
                sql = sql + "ORDER BY " + pOrderBy;
            }
            else
            {
                int rowEnd = pStartRowNumber + pPageSize - 1;
                sql = sql.Replace("FROM", String.Format(",ROW_NUMBER() OVER (order by {0}) as RowNumber FROM ", pOrderBy));
                sql = String.Format(PAGING_SQL, sql, pStartRowNumber, rowEnd);
            }
        }

        #endregion


    }
}
