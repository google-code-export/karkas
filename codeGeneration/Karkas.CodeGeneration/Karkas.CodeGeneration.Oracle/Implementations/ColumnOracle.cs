using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    class ColumnOracle : IColumn
    {
        public ColumnOracle(AdoTemplate pTemplate, TableOracle pTable, string pName)
        {

            template = pTemplate;
            table = pTable;
            name = pName;

        }

        private AdoTemplate template;

        private TableOracle table;
        private string name;


        public bool IsAutoKey
        {
            get 
            {
                // TODO Bunua daha sonra yap
                return false;
            }
        }

        public string Name
        {
            get { return name; }
        }

        private bool? isInPrimaryKey;

        private const string SQL_PRIMARY_KEY = @" SELECT
  COUNT(*)
    FROM all_constraints cons
    INNER JOIN 
    all_cons_columns cols
ON
   cons.constraint_name = cols.constraint_name
AND cons.owner = cols.owner
   WHERE     cols.table_name = :tableName
         AND COLS.OWNER = :schemaName
         AND COLS.COLUMN_NAME =  :columnName
         AND cons.constraint_type = 'P'
         ";


        public bool IsInPrimaryKey
        {
            get
            {
                if (!isInPrimaryKey.HasValue)
                {
                    ParameterBuilder builder = new ParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, Table.Name);
                    builder.parameterEkle("schemaName", DbType.String, Table.Schema);
                    builder.parameterEkle("columnName", DbType.String, Name);
                    Object objSonuc = template.TekDegerGetir(SQL_PRIMARY_KEY, builder.GetParameterArray());
                    Decimal sonuc = (Decimal)objSonuc;
                    if (sonuc > 0)
                    {
                        isInPrimaryKey = true;
                    }
                    else
                    {
                        isInPrimaryKey = false;
                    }

                }
                return isInPrimaryKey.Value;

            }
        }
        private const string SQL_FOREIGN_KEY = @" SELECT
  COUNT(*)
    FROM all_constraints cons
    INNER JOIN 
    all_cons_columns cols
ON
   cons.constraint_name = cols.constraint_name
 AND cons.owner = cols.owner
   WHERE     cols.table_name = :tableName
         AND COLS.OWNER = :schemaName
         AND COLS.COLUMN_NAME =  :columnName
         AND cons.constraint_type = 'R'
        ";

        private bool? isInForeignKey;
        public bool IsInForeignKey
        {
            get
            {
                if (!isInForeignKey.HasValue)
                {
                    ParameterBuilder builder = new ParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, Table.Name);
                    builder.parameterEkle("schemaName", DbType.String, Table.Schema);
                    builder.parameterEkle("columnName", DbType.String, Name);
                    Object objSonuc = template.TekDegerGetir(SQL_FOREIGN_KEY, builder.GetParameterArray());
                    Decimal sonuc = (Decimal)objSonuc;
                    if (sonuc > 0)
                    {
                        isInForeignKey = true;
                    }
                    else
                    {
                        isInForeignKey = false;
                    }

                }
                return isInForeignKey.Value;

            }
        }

        private bool? isNullable = null;
        public bool IsNullable
        {
            get 
            {
                if (!isNullable.HasValue)
                {
                    String NullableValueInDatabase = ColumnValuesInDatabase["NULLABLE"].ToString();
                    if (NullableValueInDatabase == "N")
                    {
                        isNullable = false;
                    }
                    if (NullableValueInDatabase == "Y")
                    {
                        isNullable = true;
                    }

                }
                return isNullable.Value;
            }
        }

        private string languageType = null;
        private string dataTypeInDatabase = null;




        private const string SQL_COLUMN_VALUES = @"select * from ALL_TAB_COLS  C 
   WHERE
   1 = 1
AND
        C.table_name = :tableName
         AND C.OWNER = :schemaName
         AND C.COLUMN_NAME =  :columnName
";




        private DataRow columnValuesInDatabase = null;


        private DataRow ColumnValuesInDatabase
        {
            get
            {
                if (columnValuesInDatabase == null)
                {
                    ParameterBuilder builder = new ParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, Table.Name);
                    builder.parameterEkle("schemaName", DbType.String, Table.Schema);
                    builder.parameterEkle("columnName", DbType.String, Name);
                    DataTable dtColumnValues = template.DataTableOlustur(SQL_COLUMN_VALUES, builder.GetParameterArray());
                    if (dtColumnValues.Rows.Count > 0)
                    {
                        columnValuesInDatabase = dtColumnValues.Rows[0];
                    }
                }
                return columnValuesInDatabase;
            }
        }


        public string LanguageType
        {
            get 
            {
                if (languageType == null)
                {

                    dataTypeInDatabase = ColumnValuesInDatabase["DATA_TYPE"].ToString();
                    languageType = sqlTypeToDotnetCSharpType(dataTypeInDatabase);
                }
                return languageType;
            }
        }

        public ITable Table
        {
            get { return table; }
        }

        private bool? isComputed = null;
        public bool IsComputed
        {
            get 
            {
                if (!isComputed.HasValue)
                {
                    String computeVal = ColumnValuesInDatabase["VIRTUAL_COLUMN"].ToString();
                    if (computeVal == "YES")
                    {
                        isComputed = true;
                    }
                    else
                    {
                        isComputed = false;
                    }
                }
                return isComputed.Value; 
            }
        }

        public string DbTargetType
        {

            get
            {
                string lowerDataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
                if (dataTypeInDatabase == "Numeric")
                {

                    return "DbType.Decimal";
                }
                if (
                    dataTypeInDatabase == "nchar"
                    ||
                    dataTypeInDatabase == "nvarchar"
                    ||
                    dataTypeInDatabase == "char"
                    ||
                    dataTypeInDatabase == "varchar"
                    )
                {
                    return "DbType.String";
                }
                return "Unknown";

            }
        
        }

        public string DataTypeName
        {
            get 
            {
                return sqlTypeToDotnetCommonDbType(dataTypeInDatabase);
            }
        }


        private int? characterMaxLenth = null;
        public int CharacterMaxLength
        {
            get 
            { 
                if (!characterMaxLenth.HasValue)
                {
                    if (ColumnValuesInDatabase["DATA_LENGTH"] == DBNull.Value)
                    {
                        characterMaxLenth = 0;
                    }
                    else
                    {
                        characterMaxLenth = Convert.ToInt32(ColumnValuesInDatabase["DATA_LENGTH"]);
                    }

                    
                }

                return characterMaxLenth.Value; 
            }
        }

        public bool isStringType
        {
            get 
            {
                if (LanguageType == "string")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isStringTypeWithoutLength
        {
            get 
            {
                if (
                    dataTypeInDatabase == "CLOB"
                    ||
                    dataTypeInDatabase == "LONG"
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isNumericType
        {
            get { throw new NotImplementedException(); }
        }

        // Helper functions

        public string sqlTypeToDotnetCSharpType(string pSqlTypeName)
        {
            pSqlTypeName = pSqlTypeName.ToLowerInvariant();
            if (
                    pSqlTypeName.Equals("varchar") ||
                    pSqlTypeName.Equals("nvarchar") ||
                    pSqlTypeName.Equals("char") ||
                    pSqlTypeName.Equals("nchar") ||
                    pSqlTypeName.Equals("ntext") ||
                    pSqlTypeName.Equals("Xml") ||
                    pSqlTypeName.Equals("text")

                )
            {

                return "string";
            }
            if (pSqlTypeName.Equals("uniqueidentifier"))
            {
                return "Guid";
            }
            if (pSqlTypeName.Equals("int"))
            {
                return "int";
            }
            if (pSqlTypeName.Equals("tinyint"))
            {
                return "byte";
            }
            if (pSqlTypeName.Equals("smallint"))
            {
                return "short";
            }
            if (pSqlTypeName.Equals("bigint"))
            {
                return "long";
            }
            if (
                pSqlTypeName.Equals("datetime") ||
                pSqlTypeName.Equals("smalldatetime")
                )
            {
                return "DateTime";
            }
            if (pSqlTypeName.Equals("bit"))
            {
                return "bool";
            }
            if (pSqlTypeName.Equals("bit"))
            {
                return "bool";
            }



            if (
                pSqlTypeName.Equals("numeric") ||
                pSqlTypeName.Equals("decimal") ||
                pSqlTypeName.Equals("money") ||
                pSqlTypeName.Equals("smallmoney")
                )
            {
                return "decimal";
            }
            if (pSqlTypeName.Equals("float"))
            {
                return "double";
            }
            if (pSqlTypeName.Equals("real"))
            {
                return "float";
            }
            if (
                pSqlTypeName.Equals("image") ||
                pSqlTypeName.Equals("binary") ||
                pSqlTypeName.Equals("varbinary") ||
                pSqlTypeName.Equals("timestamp")
                )
            {
                return "byte[]";
            }
            if (pSqlTypeName.Equals("sql_variant"))
            {
                return "object";
            }
            return "Unknown";
        }

        private string sqlTypeToDotnetCommonDbType(string dataTypeInDatabase)
        {
            dataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
            if (
                    dataTypeInDatabase.Equals("varchar") ||
                    dataTypeInDatabase.Equals("varchar2") ||
                    dataTypeInDatabase.Equals("nvarchar") ||
                    dataTypeInDatabase.Equals("char") ||
                    dataTypeInDatabase.Equals("nchar") ||
                    dataTypeInDatabase.Equals("ntext") ||
                    dataTypeInDatabase.Equals("text")

                )
            {

                return "DbType.String";
            }
            if (dataTypeInDatabase.Equals("uniqueidentifier"))
            {
                return "Guid";
            }
            if (dataTypeInDatabase.Equals("int"))
            {
                return "int";
            }
            if (dataTypeInDatabase.Equals("tinyint"))
            {
                return "byte";
            }
            if (dataTypeInDatabase.Equals("smallint"))
            {
                return "short";
            }
            if (dataTypeInDatabase.Equals("bigint"))
            {
                return "long";
            }
            if (
                dataTypeInDatabase.Equals("datetime") ||
                dataTypeInDatabase.Equals("smalldatetime")
                )
            {
                return "DateTime";
            }
            if (dataTypeInDatabase.Equals("bit"))
            {
                return "bool";
            }
            if (dataTypeInDatabase.Equals("bit"))
            {
                return "bool";
            }



            if (
                dataTypeInDatabase.Equals("numeric") ||
                dataTypeInDatabase.Equals("decimal") ||
                dataTypeInDatabase.Equals("money") ||
                dataTypeInDatabase.Equals("smallmoney")
                )
            {
                return "decimal";
            }
            if (dataTypeInDatabase.Equals("float"))
            {
                return "double";
            }
            if (dataTypeInDatabase.Equals("real"))
            {
                return "float";
            }
            if (
                dataTypeInDatabase.Equals("image") ||
                dataTypeInDatabase.Equals("binary") ||
                dataTypeInDatabase.Equals("varbinary") ||
                dataTypeInDatabase.Equals("timestamp")
                )
            {
                return "byte[]";
            }
            if (dataTypeInDatabase.Equals("sql_variant"))
            {
                return "object";
            }
            return "Unknown";
        }


    }
}
