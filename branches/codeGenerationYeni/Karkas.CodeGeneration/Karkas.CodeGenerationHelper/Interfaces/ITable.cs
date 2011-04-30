using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface ITable
    {
        int findIndexFromName(string name);


        IDatabase Database { get; set; }

        string Schema { get; set; }

        string Name { get; set; }

        List<IColumn> Columns { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }

        string Description { get; set; }

        string Alias { get; set; }
    }
}
