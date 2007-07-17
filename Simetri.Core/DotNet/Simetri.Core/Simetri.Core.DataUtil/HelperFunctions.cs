using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Simetri.Core.DataUtil
{
    internal class HelperFunctions
    {
        public void SorguCalistir(DataTable dt, string sql, CommandType cmdType)
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

        public void SorguCalistir(DataTable dt, string sql, CommandType cmdType, SqlParameter[] parameters)
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


        public void ValidateFillArguments(DataTable dataTable, string sql)
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
        public void ValidateFillArguments(DataSet dataSet, string sql)
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
        public void ValidateFillArguments(DataSet dataSet, string sql, SqlParameter[] parameters)
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
        public void ValidateFillArguments(DataTable dataTable, string sql, SqlParameter[] parameters)
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

    }
}
