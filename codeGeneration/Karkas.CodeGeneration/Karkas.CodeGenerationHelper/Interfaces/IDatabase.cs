using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IDatabase
    {
        string Name { get; set; }
        string projectNameSpace { get; }
        string projectFolder { get; }


        List<ITable> Tables { get; }

        ITable getTable(string pTableName, string pSchemaName);

    }
}
