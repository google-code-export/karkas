using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class AspxCsGenerator
    {
        Utils utils = new Utils();

        public void Render(IOutput output, ITable table)
        {
            IDatabase database = table.Database;

            string baseNameSpace = database.projectNameSpace;
            string baseNamespaceWeb = baseNameSpace + ".WebApp";

            string className = utils.GetPascalCase(table.Name);
            string schemaName = utils.GetPascalCase(table.Schema);
            string classNameSpace = baseNamespaceWeb + "." + schemaName;
            string formName = className + "Form";


            string basePage = "KarkasBasePage";

            renderUsing(output, table);

            output.autoTabLn("namespace " + baseNamespaceWeb);
            output.autoTabLn("{");
            output.increaseTab();


            output.autoTabLn(string.Format("public partial class {0} : {1}", formName, basePage));
            output.autoTabLn("{");


            output.increaseTab();
            renderPageLoad(output);

            // class tab
            output.decreaseTab();
            output.autoTabLn("}");

            // namespace tab
            output.decreaseTab();
            output.autoTabLn("}");

            string savePath = Path.Combine(utils.ProjeDizininiAl(database), "WebApp\\" + utils.GetPascalCase(table.Schema) + "\\" + formName + ".aspx.cs");
            output.save(savePath, true);
            output.clear();

        }

        private static void renderPageLoad(IOutput output)
        {
            output.autoTabLn("protected void Page_Load(object sender, EventArgs e)");
            output.autoTabLn("{");
            output.increaseTab();
            // Page Load Code Here
            output.decreaseTab();
            output.autoTabLn("}");
        }

        public void renderUsing(IOutput pOutput, ITable pTable)
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
            pOutput.writeLine(strUsings);
        }

    }
}

