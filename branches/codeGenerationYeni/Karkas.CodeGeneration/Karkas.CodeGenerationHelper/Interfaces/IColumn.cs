using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IColumn
    {
        bool IsAutoKey { get; set; }

        string Name { get; set; }

        bool IsInPrimaryKey { get; set; }

        bool IsInForeignKey { get; set; }

        bool IsNullable { get; set; }

        string LanguageType { get; set; }

        ITable Table { get; set; }

        bool IsComputed { get; set; }

        string DbTargetType { get; set; }

        string DataTypeName { get; set; }

        int CharacterMaxLength { get; set; }
    }
}
