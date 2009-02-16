using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.MyGenerationHelper.Interfaces
{
    public interface INameChecker
    {
        string SetPascalCase(string name);
        string SetCamelCase(string name);
    }
}

