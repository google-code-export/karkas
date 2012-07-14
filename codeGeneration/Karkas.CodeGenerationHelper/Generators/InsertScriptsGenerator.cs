using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.SmoHelpers;
using System.IO;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class InsertScriptsGenerator
    {
        InsertScriptHelper insertHelper = new InsertScriptHelper();

        public InsertScriptsGenerator(IDatabaseHelper databaseHelper)
        {

            utils = new Utils(databaseHelper);
        }
        Utils utils = null;

        public void Render(IOutput output, ITable table, string connectionString)
        {
            output.writeLine(insertHelper.GetRowsToBeInserted(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\InsertScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Inserts.sql"), false);
            output.clear();

        }
    }
}
