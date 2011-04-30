using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Microsoft.SqlServer.Management.Smo;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class ColumnSqlServer : IColumn
    {
        Column smoColumn;
        TableSqlServer table;

        public ColumnSqlServer(Column pSmoColumn,TableSqlServer pTable)
        {
            smoColumn = pSmoColumn;
            table = pTable;
        }

        public bool IsAutoKey
        {
            get
            {
                if (smoColumn.Identity)
                {
                    return true;
                }
                if (smoColumn.RowGuidCol)
                {
                    return true;
                }
                return false;
            }
        }

        public string Name
        {
            get
            {
                return smoColumn.Name;
            }
        }

        public bool IsInPrimaryKey
        {
            get
            {
                return smoColumn.InPrimaryKey;
            }
        }

        public bool IsInForeignKey
        {
            get
            {
                return smoColumn.IsForeignKey;
            }
        }

        public bool IsNullable
        {
            get
            {
                return smoColumn.Nullable;
            }
        }

        private string getLanguageTypeFromDataType()
        {
            if (
                    DataTypeName.Equals("varchar") || 
                    DataTypeName.Equals("nvarchar") || 
                    DataTypeName.Equals("char") || 
                    DataTypeName.Equals("nchar") ||
                    DataTypeName.Equals("ntext") ||
                    DataTypeName.Equals("text") 
                
                )
            {
                
                return "string";
            }
            if (DataTypeName.Equals("uniqueidentifier"))
            {
                return "System.Guid";
            }
            if (DataTypeName.Equals("int"))
            {
                return "int";
            }
            if (DataTypeName.Equals("tinyint"))
            {
                return "byte";
            }
            if (DataTypeName.Equals("smallint"))
            {
                return "short";
            }
            if (DataTypeName.Equals("bigint"))
            {
                return "long";
            }
            if (
                DataTypeName.Equals("datetime") || 
                DataTypeName.Equals("smalldatetime") 
                )
            {
                return "DateTime";
            }
            if (DataTypeName.Equals("bit"))
            {
                return "bool";
            }
            if (DataTypeName.Equals("bit"))
            {
                return "bool";
            }
            
                
            
            if (
                DataTypeName.Equals("numeric") || 
                DataTypeName.Equals("decimal") || 
                DataTypeName.Equals("money") || 
                DataTypeName.Equals("smallmoney") 
                )
            {
                return "decimal";
            }
            if (DataTypeName.Equals("float"))
            {
                return "float";
            }
            if (DataTypeName.Equals("real"))
            {
                return "double";
            }
            if (
                DataTypeName.Equals("image") ||
                DataTypeName.Equals("binary") ||
                DataTypeName.Equals("varbinary")  ||
                DataTypeName.Equals("timestamp")
                )
            {
                return "byte[]";
            }
            if (DataTypeName.Equals("sql_variant") )
            {
                return "object";
            }

            
            return "Unknown";

        }

        public string LanguageType
        {
            get
            {
                string sonuc = getLanguageTypeFromDataType();
                if (sonuc.Equals("Unknown"))
                {
                    Console.WriteLine("Name : {0} , DataType : {1} ", Name, DataTypeName);
                }
                return sonuc;
            }
        }

        public ITable Table
        {
            get
            {
                return table;
            }
        }

        public bool IsComputed
        {
            get
            {
                return smoColumn.Computed;
            }
        }

        public string DbTargetType
        {
            get
            {
                return smoColumn.DataType.ToString();
            }
        }

        public string DataTypeName
        {
            get
            {
                return smoColumn.DataType.ToString();
            }
        }

        public int CharacterMaxLength
        {
            get
            {
                return smoColumn.DataType.MaximumLength;
            }
        }
    }
}
