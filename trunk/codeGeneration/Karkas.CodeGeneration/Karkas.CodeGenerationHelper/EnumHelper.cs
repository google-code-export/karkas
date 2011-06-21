using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Karkas.CodeGenerationHelper
{
    public class EnumHelper
    {
        TurkishHelper tHelper = new TurkishHelper();
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
            int enumAdiOrdinal = 1;
            for (int i = 0; i < dtSchema.Rows.Count; i++)
			{
			    if (dtSchema.Rows[i]["DataType"].ToString() == "System.String")
                {
                    enumAdiOrdinal = i;
                    break;
                }

			}

            DataRow row = dtSchema.Rows[0];
            string dataTypeOfEnum = row["DataType"].ToString();
            string charpDataTypeOfEnum = u.GetCSharpTypeFromDotNetType(dataTypeOfEnum);

            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("public partial class {0}Enum"
                                    , u.GetPascalCase(tableName)));
            sb.Append(  @"
    {");
            while (reader.Read())
            {
                sb.Append(Environment.NewLine);
                try
                {
                    sb.Append(String.Format("\t\tpublic const {0} {1} = {2};"
                , charpDataTypeOfEnum
                , u.GetPascalCase(tHelper.ReplaceTurkishChars((reader.GetString(enumAdiOrdinal))))
                , reader.GetValue(0).ToString()));

                }
                catch
                {
                    // Yut
                }
            }
            sb.Append(@"
    }                   ");
            conn.Close();
            return sb.ToString();
        }
        //byte ,sbyte,short,ushort,int,uint,long,ulong
        //
    }
}

