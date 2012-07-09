using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGenerationHelper
{
    public interface IDatabaseHelper
    {
        string getDatabaseName(AdoTemplate template);

        DataTable getTableListFromSchema(AdoTemplate template, string schemaName);
        DataTable getSchemaList(AdoTemplate template);

        void codeGenerateAllTables(string pConnectionString, string pDatabaseName, string pProjectNamespace
    , string pProjectFolder
    , bool dboSemaTablolariniAtla
    , bool sysTablolariniAtla);
        void codeGenerateOneTable(string pConnectionString, string pTableName, string pSchemaName, string pDatabaseName, string pProjectNamespace, string pProjectFolder);

    }


}
