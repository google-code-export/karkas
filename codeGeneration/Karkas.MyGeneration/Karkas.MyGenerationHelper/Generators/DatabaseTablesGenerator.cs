using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Zeus;
using MyMeta;

namespace Karkas.MyGenerationHelper.Generators
{
    public class DatabaseTablesGenerator
    {
        public void Render(IZeusOutput output, ITable table, string connectionString)
        {
            Utils utils = new Utils();
            output.writeln(GetTableDescription(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\CreateScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".CreateTable.sql"), false);
            output.clear();
            output.writeln(GetTableRelationDescriptions(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\CreateRelationScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Relations.sql"), false);
            output.clear();
        }

        #region "SMO Helper Fonksiyonlari"

        SmoHelper smoHelper = new SmoHelper();

        public string GetTableRelationDescriptions(string pDatabaseName, string pSchemaName, string pTableName, string pConnectionString)
        {
            return smoHelper.GetTableRelationDescriptions(pDatabaseName, pSchemaName, pTableName, pConnectionString);
        }
        public string GetTableDescription(string pDatabaseName, string pSchemaName, string pTableName, string pConnectionString)
        {
            return smoHelper.GetTableDescription(pDatabaseName, pSchemaName, pTableName, pConnectionString);
        }


        #endregion

    }
}
