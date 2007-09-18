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

        public void RenderTypeLibraryCode(IZeusOutput output, ITable table)
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

            writeMemberVariables(output, table);

            writeProperties(output, table);

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

        private void writeProperties(IZeusOutput output, ITable table)
        {
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                string memberVariableName = SimetriUtils.SetCamelCase(column.Name);
                string propertyVariableName = SimetriUtils.SetPascalCase(column.Name);

                output.autoTabLn(string.Format("public {0} {1}", SimetriUtils.GetLanguageType(column), propertyVariableName));
                output.autoTabLn("{");
                output.incTab();
                output.autoTabLn("get");
                output.autoTabLn("{");
                output.autoTabLn(string.Format("\treturn {0};", memberVariableName));
                output.autoTabLn("}");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.incTab();
                output.autoTabLn(string.Format("if ((this.RowState == DataRowState.Unchanged) && ({0}!= value))", memberVariableName));
                output.autoTabLn("{");
                output.autoTabLn("\tthis.RowState = DataRowState.Modified;");
                output.autoTabLn("}");
                output.decTab();
                output.autoTabLn(string.Format("{0} = value;", memberVariableName));
                output.autoTabLn("}");
                output.decTab();
                output.autoTabLn("}");
                output.writeln("");
            }
            output.decTab();
        }

        private void writeMemberVariables(IZeusOutput output, ITable table)
        {
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                output.autoTabLn(String.Format("private {0} {1};", SimetriUtils.GetLanguageType(column), SimetriUtils.SetCamelCase(column.Name)));
            }
            output.decTab();
            output.writeln("");
        }

    }




}



