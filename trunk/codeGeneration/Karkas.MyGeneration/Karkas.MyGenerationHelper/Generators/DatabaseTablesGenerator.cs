using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Zeus;
using MyMeta;
using Karkas.MyGenerationHelper.SmoHelpers;

namespace Karkas.MyGenerationHelper.Generators
{
    public class DatabaseTablesGenerator
    {
        SmoHelper smoHelper = new SmoHelper();
        InsertScriptHelper insertHelper = new InsertScriptHelper();
        public void Render(IZeusOutput output, ITable table, string connectionString)
        {
            Utils utils = new Utils();

            output.writeln(smoHelper.GetTableDescription(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\CreateScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".CreateTable.sql"), false);
            output.clear();

            output.writeln(smoHelper.GetTableRelationDescriptions(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\CreateRelationScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Relations.sql"), false);
            output.clear();

            if (table.Name.Substring(0,2) == "TT")
            {
                output.writeln(insertHelper.GetRowsToBeInserted(table.Database.Name, table.Schema, table.Name, connectionString));
                output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\InsertScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Inserts.sql"), false);
                output.clear();

            }
        }
    }
}
