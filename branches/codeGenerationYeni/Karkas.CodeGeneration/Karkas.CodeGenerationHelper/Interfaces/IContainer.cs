using System;
using System.Collections.Generic;
using System.Text;
using Karkas.MyGenerationHelper.Interfaces;

namespace Karkas.MyGenerationHelper
{
    public interface IContainer
    {
        string Alias { get; set; }
        List<IColumn> Columns { get; }
        IDatabase Database { get; }
        DateTime DateCreated { get; }
        DateTime DateModified { get; }
        string Description { get; }
        string Name { get; }
        string Schema { get; }
    }
}
