using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;
using Zeus;
using System.IO;

namespace Karkas.MyGenerationHelper.Generators
{
    public class AspxCsGenerator
    {
        Utils utils = new Utils();
        KarkasXmlParser parser = new KarkasXmlParser();

        public void Render(IZeusOutput output, ITable table)
        {
            IDatabase database = table.Database;

            string baseNameSpace = utils.NamespaceIniAlSchemaIle(database, table.Schema);
            string baseNamespaceWeb = baseNameSpace + ".WebApp";

            string className = utils.GetPascalCase(table.Name);
            string schemaName = utils.GetPascalCase(table.Schema);
            string classNameSpace = baseNamespaceWeb + "." + schemaName;
            string formName = className + "Form";


            string basePage = "KarkasBasePage";

            renderUsing(output, table);

            output.autoTabLn("namespace " + baseNamespaceWeb);
            output.autoTabLn("{");
            output.incTab();


            output.autoTabLn(string.Format("public partial class {0} : {1}", formName, basePage));
            output.autoTabLn("{");


            output.incTab();
            renderPageLoad(output);

            // class tab
            output.decTab();
            output.autoTabLn("}");

            // namespace tab
            output.decTab();
            output.autoTabLn("}");

            string savePath = Path.Combine(utils.ProjeDizininiAl(database), "WebApp\\" + utils.GetPascalCase(table.Schema) + "\\" + formName + ".aspx.cs");
            output.save(savePath, true);
            output.clear();

        }

        private static void renderPageLoad(IZeusOutput output)
        {
            output.autoTabLn("protected void Page_Load(object sender, EventArgs e)");
            output.autoTabLn("{");
            output.incTab();
            // Page Load Code Here
            output.decTab();
            output.autoTabLn("}");
        }

        public void renderUsing(IZeusOutput pOutput, ITable pTable)
        {
            string strUsings = @"
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
";
            pOutput.writeln(strUsings);
        }

    }
}

