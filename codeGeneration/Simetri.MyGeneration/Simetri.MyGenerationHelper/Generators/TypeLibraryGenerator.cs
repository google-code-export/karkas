using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;
using Simetri.MyGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Zeus;

namespace Simetri.MyGenerationHelper.Generators
{
    class TypeLibraryGenerator
    {

        Utils SimetriUtils = new Utils();

        public void RenderTypeLibraryCodeTable(IZeusOutput output, ITable table)
        {
            IDatabase database = table.Database;
            output.tabLevel = 0;

            string baseNameSpace = SimetriUtils.NamespaceIniAlSchemaIle(database, table.Schema);
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = SimetriUtils.SetPascalCase(table.Name);
            string schemaName = SimetriUtils.SetPascalCase(table.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;
            string outputFullFileName = Path.Combine(SimetriUtils.ProjeDizininiAl(database) + "\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");
            output.setPreserveSource(outputFullFileName, "//::", ":://");


            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Simetri.Core.TypeLibrary;");
            output.autoTabLn("using Simetri.Core.Validation.ForPonos;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(classNameSpace);
            output.autoTabLn("");
            output.autoTabLn("{");


            writeClassName(output, className);

            output.autoTabLn("{");

            TypeLibraryHelper.writeMemberVariables(output, table);

            TypeLibraryHelper.writeProperties(output, table);

            output.writeln("");

            //            writeValidationCode(output, table);
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("}");

            //			output.autoTabLn(className);

            output.save(outputFullFileName, false);
            output.clear();
        }

        public void RenderTypeLibraryCodeView(IZeusOutput output, IView table)
        {
            IDatabase database = table.Database;
            output.tabLevel = 0;

            string baseNameSpace = SimetriUtils.NamespaceIniAlSchemaIle(database, table.Schema);
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = SimetriUtils.SetPascalCase(table.Name);
            string schemaName = SimetriUtils.SetPascalCase(table.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;
            string outputFullFileName = Path.Combine(SimetriUtils.ProjeDizininiAl(database) + "\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");
            output.setPreserveSource(outputFullFileName, "//::", ":://");


            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Simetri.Core.TypeLibrary;");
            output.autoTabLn("using Simetri.Core.Validation.ForPonos;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(classNameSpace);
            output.autoTabLn("");
            output.autoTabLn("{");


            writeClassName(output, className);

            output.autoTabLn("{");

            TypeLibraryHelper.writeMemberVariablesView(output, table);

            TypeLibraryHelper.writeProperties(output, table);

            output.writeln("");

            //            writeValidationCode(output, table);
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("}");

            //			output.autoTabLn(className);

            output.save(outputFullFileName, false);
            output.clear();
        }

        private static void writeClassName(IZeusOutput output, string className)
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

        private void writeValidationCode(IZeusOutput output, ITable table)
        {
            output.autoTabLn("protected override void ValidationListesiniOlusturCodeGeneration()");
            output.autoTab("{");
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                if ((!column.IsNullable) && (!column.IsInPrimaryKey))
                {
                    output.autoTabLn("");
                    output.autoTab("this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, \"");
                    output.autoTab(SimetriUtils.SetPascalCase(column.Name));
                    output.autoTab("\"));");

                }
            }
            output.decTab();
            output.autoTabLn("");
            output.autoTabLn("}");
        }


    }




}



