using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IColumn
    {
        bool IsAutoKey { get;  }

        string Name { get;  }

        bool IsInPrimaryKey { get;  }

        bool IsInForeignKey { get;  }

        bool IsNullable { get;  }

        string LanguageType { get;  }

        ITable Table { get;  }

        bool IsComputed { get;  }

        string DbTargetType { get;  }

        string DataTypeName { get;  }

        int CharacterMaxLength { get;  }

        bool isStringType { get; }
        bool isStringTypeWithoutLength { get; }
        bool isNumericType { get; }

    }
}
