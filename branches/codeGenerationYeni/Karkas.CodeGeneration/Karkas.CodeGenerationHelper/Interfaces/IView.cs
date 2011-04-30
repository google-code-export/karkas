using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IView : ITable
    {

        List<IColumn> Columns { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }

        string Description { get; set; }
    }
}
