using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Data;

namespace Karkas.CodeGenerationHelper.SmoHelpers
{
    public class InsertScriptHelper
    {
        //TODO: byte[] icin neye cevirecegiz. unutulmus baska typelar da olabilir.
        //TODO: Su anda pk cakismalari icin bir onlem yok ama boyle bir cakisma olmayacagi assumptioni dogru olmali
            //Pk cakismasini engellemek icin yazilmasi gereken kodlar "out of scope" olarak kalmali.
        //TODO: su anda UIdaki create Database option war ise insert scriptleri olusturuluyor. ayirmak lazim.
        public string GetRowsToBeInserted(string pDatabaseName, string pSchemaName, string pTableName, string connectionString)
        {
            string insertSql = "";

            DataTable table = GetDataToBeInserted(pDatabaseName, pSchemaName, pTableName, connectionString);

            if (table.Rows.Count > 0)
            {
                insertSql = CreateInsertScript(table, pDatabaseName, pSchemaName, pTableName);
            }

            return insertSql;
        }

        private DataTable GetDataToBeInserted(string pDatabaseName, string pSchemaName, string pTableName, string connectionString)
        {
            connectionString = ConnectionHelper.RemoveProviderFromConnectionString(connectionString);
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                command.Connection = conn;
                //Just in case "top 5000" eklendi
                command.CommandText = String.Format(@"SELECT TOP 5000 * FROM {0}.{1}.{2}", pDatabaseName, pSchemaName, pTableName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                conn.Close();

            }

            return table;

        }

        private string CreateInsertScript(DataTable table, string pDatabaseName, string pSchemaName, string pTableName)
        {
            string output = "";

            string identityOn = String.Format("SET IDENTITY_INSERT [{0}].[{1}].[{2}] ON\r\n\r\n", pDatabaseName, pSchemaName, pTableName);
            string identityOff = String.Format("SET IDENTITY_INSERT [{0}].[{1}].[{2}] OFF\r\n\r\n", pDatabaseName, pSchemaName, pTableName);

            output += "INSERT INTO ";
            output += String.Format("{0}.{1}.{2}\r\n(", pDatabaseName, pSchemaName, pTableName);

            foreach (DataColumn loopColumn in table.Columns)
            {
                output += String.Format("[{0}],\r\n", loopColumn.Caption);
            }

            output = output.Remove((output.Length - 3), 1);
            output += ")\r\n VALUES\r\n";

            string values = CreateValueStrings(table);

            output += values;
            output = identityOn + output + "\r\n";
            output = output + identityOff;
            output += "GO";

            return output;
        }

        private string CreateValueStrings(DataTable pTable)
        {
            string valueString = "";

            for (int i = 0; i < pTable.Rows.Count; i++)
            {
                valueString += "(";

                for (int j = 0; j < pTable.Columns.Count; j++)
                {
                    valueString += GetDataBaseEquivalentString(pTable.Rows[i][j]) + ",";
                }
                valueString = valueString.Remove(valueString.Length - 1);
                valueString += "),\r\n";
            }
            valueString = valueString.Remove((valueString.Length - 3), 1);
            return valueString;
        }

        private string GetDataBaseEquivalentString(object p)
        {
            string dbEq = "";

            bool cevirmeGerekliMi = !((p is System.Int32) ||
                                        (p is System.Int16) ||
                                        (p is System.Int64) ||
                                        (p is System.Decimal) ||
                                        (p is System.Double) || 
                                        (p is System.Byte)
                                            );
            if (!cevirmeGerekliMi)
            {
                dbEq = p.ToString();
            }
            else if (p is System.String)
            {
                dbEq = "'" + p.ToString() + "'";
            }
            else if (p is System.Boolean)
            {
                if (Convert.ToBoolean(p) == true)
                {
                    dbEq = "1";
                }
                else
                    dbEq = "0";
            }
            else if (p is System.DateTime)
            {
                dbEq = String.Format("CAST('{0}' as DateTime)", p.ToString());
            }
            else if (p == DBNull.Value)
            {
                dbEq = "null";
            }

            return dbEq;
        }

    }
}
