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
            get { throw new NotImplementedException(); }
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

   WHERE     cols.table_name = :tableName
         AND COLS.OWNER = :schemaName
         AND COLS.COLUMN_NAME =  :columnName
         AND cons.constraint_type = 'P'
         AND cons.owner = cols.owner";


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

        public bool IsInForeignKey
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsNullable
        {
            get { throw new NotImplementedException(); }
        }

        public string LanguageType
        {
            get { throw new NotImplementedException(); }
        }

        public ITable Table
        {
            get { return table; }
        }

        public bool IsComputed
        {
            get { throw new NotImplementedException(); }
        }

        public string DbTargetType
        {
            get { throw new NotImplementedException(); }
        }

        public string DataTypeName
        {
            get { throw new NotImplementedException(); }
        }

        public int CharacterMaxLength
        {
            get { throw new NotImplementedException(); }
        }

        public bool isStringType
        {
            get { throw new NotImplementedException(); }
        }

        public bool isStringTypeWithoutLength
        {
            get { throw new NotImplementedException(); }
        }

        public bool isNumericType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
