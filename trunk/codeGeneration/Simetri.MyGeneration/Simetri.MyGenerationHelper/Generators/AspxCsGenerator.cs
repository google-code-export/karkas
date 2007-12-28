using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;
using Zeus;
using System.IO;

namespace Simetri.MyGenerationHelper.Generators
{
    public class AspxCsGenerator
    {
        Utils SimetriUtils = new Utils();
        SimetriXmlParser parser = new SimetriXmlParser();

        public void Render(IZeusOutput output, ITable table)
        {
            IDatabase database = table.Database;
            string baseNamespace = parser.ProjeNamespaceIsminiAl(database);
            string baseNamespaceWeb = baseNamespace + ".WebApp";
            string tableName = SimetriUtils.SetPascalCase(table.Name);
            string formName = tableName + "Form";


            string savePath = Path.Combine(SimetriUtils.ProjeDizininiAl(database), "WebApp\\" + SimetriUtils.SetPascalCase(table.Schema) + "\\" + formName + ".aspx.cs");
            output.save(savePath, true);
            output.clear();

        }
    }
}
