using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.Oracle
{
    public class OracleHelper : IDatabaseHelper
    {
        public string getDatabaseName(Core.DataUtil.AdoTemplate template)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable getTableListFromSchema(Core.DataUtil.AdoTemplate template, string schemaName)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable getSchemaList(Core.DataUtil.AdoTemplate template)
        {
            throw new NotImplementedException();
        }
    }
}
