using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.MyGenerationHelper.SmoHelpers;
using System.IO;
using MyMeta;
using Zeus;

namespace Karkas.MyGenerationHelper.Generators
{
    public class InsertScriptsGenerator
    {
        InsertScriptHelper insertHelper = new InsertScriptHelper();

        public void Render(IZeusOutput output, ITable table, string connectionString)
        {
            Utils utils = new Utils();
            output.writeln(insertHelper.GetRowsToBeInserted(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\InsertScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Inserts.sql"), false);
            output.clear();

        }
    }
}
