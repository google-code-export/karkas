using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;
using Karkas.MyGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Zeus;

namespace Karkas.MyGenerationHelper.Generators
{
    class TypeLibraryGenerator
    {

        Utils utils = new Utils();

        public void Render(IZeusOutput output, ITable table)
        {
            IDatabase database = table.Database;
            output.tabLevel = 0;

            string baseNameSpace = utils.NamespaceIniAlSchemaIle(database, table.Schema);
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = utils.SetPascalCase(table.Name);
            string schemaName = utils.SetPascalCase(table.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;
            string outputFullFileName = Path.Combine(utils.ProjeDizininiAl(database) + "\\TypeLibrary\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");
            output.setPreserveSource(outputFullFileName, "//::", ":://");


            NamespaceleriYaz(output, classNameSpace);

            ClassIsmiYaz(output, className);

            output.autoTabLn("{");

            TypeLibraryHelper.writeMemberVariables(output, table);

            TypeLibraryHelper.writeProperties(output, table);

            TypeLibraryHelper.writeShallowCopy(output, table, className);

            output.writeln("");

            OnaylamaKoduYaz(output, table);
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("}");

            //			output.autoTabLn(className);

            output.save(outputFullFileName, false);
            output.clear();
        }

        public void RenderTypeLibraryCode(IZeusOutput output, IView view)
        {
            IDatabase database = view.Database;
            output.tabLevel = 0;

            string baseNameSpace = utils.NamespaceIniAlSchemaIle(database, view.Schema);
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = utils.SetPascalCase(view.Name);
            string schemaName = utils.SetPascalCase(view.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;
            string outputFullFileName = Path.Combine(utils.ProjeDizininiAl(database) + "\\TypeLibrary\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");
            output.setPreserveSource(outputFullFileName, "//::", ":://");


            NamespaceleriYaz(output, classNameSpace);


            ClassIsmiYaz(output, className);

            output.autoTabLn("{");

            TypeLibraryHelper.MemberVariablesViewYaz(output, view);

            TypeLibraryHelper.PropertiesYaz(output, view);

            output.writeln("");

            OnaylamaKoduYaz(output, view);
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("}");

            //			output.autoTabLn(className);

            output.save(outputFullFileName, false);
            output.clear();
        }

        private static void NamespaceleriYaz(IZeusOutput output, string classNameSpace)
        {
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.TypeLibrary;");
            output.autoTabLn("using Karkas.Core.Validation.ForPonos;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(classNameSpace);
            output.autoTabLn("");
            output.autoTabLn("{");
        }

        private static void ClassIsmiYaz(IZeusOutput output, string className)
        {
            output.incTab();
            output.autoTabLn("[Serializable]");
            output.autoTab("public partial class ");
            output.autoTab(className);
            output.autoTabLn("");

            try
            {
                output.getPreservedData("inheritance");
                output.preserve("inheritance");
            }
            catch (NullReferenceException)
            {
                string preservedBlock = output.getPreserveBlock("inheritance");
                string newBlock = preservedBlock.Replace("////",
                "// " + Environment.NewLine
                + ": BaseTypeLibrary " + Environment.NewLine + "//");
                output.writeln("");
                output.autoTab(newBlock);
            }

            output.writeln("");
        }

        private void OnaylamaKoduYaz(IZeusOutput output, IView view)
        {
            output.autoTabLn("protected override void ValidationListesiniOlusturCodeGeneration(){}");
        }
        

        private void OnaylamaKoduYaz(IZeusOutput output, ITable table)
        {
            output.autoTabLn("protected override void ValidationListesiniOlusturCodeGeneration()");
            output.autoTab("{");
            output.incTab();
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                if ((!column.IsNullable) && (!column.IsInPrimaryKey))
                {
                    output.autoTabLn("");
                    output.autoTab("this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, \"");
                    output.write(utils.SetPascalCase(column.Name));
                    output.write("\"));");

                }
            }
            output.decTab();
            output.write("");
            output.autoTabLn("}");
            output.decTab();
        }


    }




}



