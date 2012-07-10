using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    class ColumnOracle : IColumn
    {
        public bool IsAutoKey
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
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
            get { throw new NotImplementedException(); }
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
