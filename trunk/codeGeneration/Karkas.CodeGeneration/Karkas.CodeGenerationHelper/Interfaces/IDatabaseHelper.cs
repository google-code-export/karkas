using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IDatabaseHelper
    {
        string getDatabaseName(AdoTemplate template);

        string getDefaultSchema(AdoTemplate template);

        DataTable getTableListFromSchema(AdoTemplate template, string schemaName);
        DataTable getSchemaList(AdoTemplate template);

        void CodeGenerateAllTables(AdoTemplate template,string pConnectionString, string pDatabaseName, string pProjectNamespace
    , string pProjectFolder
    , bool dboSemaTablolariniAtla
    , bool sysTablolariniAtla);

        void CodeGenerateOneTable(AdoTemplate template,string pConnectionString, string pTableName, string pSchemaName, string pDatabaseName, string pProjectNamespace, string pProjectFolder);


        DalGenerator DalGenerator
        {
            get;
        }


    }


}
