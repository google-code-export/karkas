using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Simetri.MyGenerationHelper
{
    public class EnumHelper
    {
        public string GetEnumDescription(string dbName, string schemaName, string tableName, string connectionString)
        {
            Utils u = new Utils();
            connectionString = ConnectionHelper.RemoveProviderFromConnectionString(connectionString);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT * FROM {0}.{1}.{2}", dbName, schemaName, tableName);
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            DataTable dtSchema = reader.GetSchemaTable();
            DataRow row = dtSchema.Rows[0];
            string dataTypeOfEnum = row["DataType"].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("public enum {0} : {1}"
                                    , u.SetPascalCase(tableName)
                                    ,u.GetCSharpTypeFromDotNetType(dataTypeOfEnum)));
            sb.Append(  @"
    {");
            while (reader.Read())
            {
                sb.Append(Environment.NewLine);
                sb.Append("\t\t");
                sb.Append(u.SetPascalCase( u.ReplaceTurkishChars((reader.GetString(1)))));
                sb.Append(" = ");
                sb.Append(u.SetPascalCase((reader.GetValue(0).ToString())));
                sb.Append(",");
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append(@"
    }                   ");
            conn.Close();
            return sb.ToString();
        }
        //byte ,sbyte,short,ushort,int,uint,long,ulong
        //
    }
}
