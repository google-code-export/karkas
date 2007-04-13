using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Simetri.Core.DataUtil
{
    public class AdoTemplate
    {
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
    }
}