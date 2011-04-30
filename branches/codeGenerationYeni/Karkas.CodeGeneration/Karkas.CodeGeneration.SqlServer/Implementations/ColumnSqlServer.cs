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

            if (DataTypeName.Equals("uniqueidentifier"))
            {
                return "System.Guid";
            }
            return "Unknown";
        }

        public string LanguageType
        {
            get
            {
                return getLanguageTypeFromDataType();
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
