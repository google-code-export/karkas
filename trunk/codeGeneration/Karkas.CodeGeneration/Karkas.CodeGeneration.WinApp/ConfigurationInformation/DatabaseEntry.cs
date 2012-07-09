using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volante;

namespace Karkas.CodeGeneration.WinApp.ConfigurationInformation
{
    public class DatabaseEntry : Persistent
    {
        public String ConnectionName;
        public DatabaseType ConnectionDatabaseType;
        public String ConnectionString;
        public String CodeGenerationDirectory;
        public String CodeGenerationNamespace;
        public DateTime CreationTimeUtc;
        public DateTime LastAccessTimeUtc;
        public DateTime LastWriteTimeUtc;
    }
}
