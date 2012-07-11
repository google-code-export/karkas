using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    class ColumnOracle : IColumn
    {
        public ColumnOracle(TableOracle pTable,string pName)
        {
            table = pTable;
            name = pName;

        }

        TableOracle table;
        string name;


        public bool IsAutoKey
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return name; }
        }

        public bool IsInPrimaryKey
        {
            get { throw new NotImplementedException(); }
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
