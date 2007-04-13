using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Simetri.Core.DataUtil
{
    public class AdoTemplate
    {
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
            paramDbTipiniSetle(prm, value);
            prm.Value = value;
            prm.Size = size;
            cmd.Parameters.Add(prm);
        }


        private void paramDbTipiniSetle(SqlParameter prm, string value)
        {
            prm.SqlDbType = SqlDbType.VarChar;
        }
        private void paramDbTipiniSetle(SqlParameter prm, int value)
        {
            prm.SqlDbType = SqlDbType.Int;
        }
        private void paramDbTipiniSetle(SqlParameter prm, Guid value)
        {
            prm.SqlDbType = SqlDbType.UniqueIdentifier;
        }
        private void paramDbTipiniSetle(SqlParameter prm, long value)
        {
            prm.SqlDbType = SqlDbType.BigInt;
        }
        private void paramDbTipiniSetle(SqlParameter prm, byte value)
        {
                prm.SqlDbType = SqlDbType.TinyInt;
        }
        private void paramDbTipiniSetle(SqlParameter prm, byte[] value)
        {
            prm.SqlDbType = SqlDbType.Binary;
        }
        private void paramDbTipiniSetle(SqlParameter prm, bool value)
        {
            prm.SqlDbType = SqlDbType.Bit;
        }
        private void paramDbTipiniSetle(SqlParameter prm, object value)
        {
        }

        public void CalistirSelectHaric(SqlCommand cmd)
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

        public void CalistirSelectHaric(string sql)
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



        public void CalistirSelectHaric(string sql,SqlParameter[] prmListesi)
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
    
    }
}