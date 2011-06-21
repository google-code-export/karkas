using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;

namespace Karkas.MyGenerationHelper
{
    public interface IContainer
    {
        string Alias { get; set; }
        IColumns Columns { get; }
        IDatabase Database { get; }
        DateTime DateCreated { get; }
        DateTime DateModified { get; }
        string Description { get; }
        string Name { get; }
        string Schema { get; }
    }
}
