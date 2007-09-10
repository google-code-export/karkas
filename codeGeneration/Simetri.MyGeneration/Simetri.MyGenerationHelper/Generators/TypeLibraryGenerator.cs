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

            string memberVariableName = "";
            string propertyVariableName = "";
            string baseNameSpace = SimetriUtils.NamespaceIniAlSchemaIle(database, table.Schema);
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = SimetriUtils.SetPascalCase(table.Name);
            string schemaName = SimetriUtils.SetPascalCase(table.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;

            string outputFullFileName = Path.Combine(SimetriUtils.ProjeDizininiAl(database) + "\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");


            output.setPreserveSource(outputFullFileName, "//::", ":://");


            output.writeln("using System;");
            output.writeln("using System.Collections.Generic;");
            output.writeln("using System.Text;");
            output.writeln("using Simetri.Core.TypeLibrary;");
            output.writeln("using Simetri.Core.Validation.ForPonos;");
            output.writeln("using System.Data;");
            output.writeln("");
            output.write("namespace ");
            output.write(classNameSpace);
            output.writeln("");
            output.writeln("{");
            output.writeln("    [Serializable]");
            output.write("    public partial class ");
            output.write(className);
            output.writeln("");

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
                output.write(newBlock);
            }


            output.writeln("  ");
            output.write("\t{");

            foreach (IColumn column in table.Columns)
            {
                memberVariableName = SimetriUtils.SetCamelCase(column.Name);
                propertyVariableName = SimetriUtils.SetPascalCase(column.Name);

                output.writeln("");
                output.write("\t\tprivate ");
                output.write(SimetriUtils.GetLanguageType(column));
                output.write(" ");
                output.write(memberVariableName);
                output.write(";");

            }

            output.writeln("");
            output.write("\t\t");

            foreach (IColumn column in table.Columns)
            {
                memberVariableName = SimetriUtils.SetCamelCase(column.Name);
                propertyVariableName = SimetriUtils.SetPascalCase(column.Name);

                output.writeln("");
                output.write("\t\tpublic ");
                output.write(SimetriUtils.GetLanguageType(column));
                output.write(" ");
                output.write(propertyVariableName);
                output.writeln("");
                output.writeln("\t\t{");
                output.writeln("\t\t\tget");
                output.writeln("\t\t\t{");
                output.write("\t\t\t\treturn ");
                output.write(memberVariableName);
                output.writeln(";");
                output.writeln("\t\t\t}");
                output.writeln("\t\t\tset");
                output.writeln("\t\t\t{");
                output.write("\t\t\t\tif ((this.RowState == DataRowState.Unchanged) && (");
                output.write(memberVariableName);
                output.writeln("  != value))");
                output.writeln("                {");
                output.writeln("                    this.RowState = DataRowState.Modified;");
                output.writeln("                }");
                output.write("\t\t\t\t");
                output.write(memberVariableName);
                output.writeln(" = value;");
                output.writeln("\t\t\t}");
                output.writeln("\t\t}");
                output.write("\t\t");

            }

            output.writeln("");
            output.writeln("\t\tprotected override void ValidationListesiniOlusturCodeGeneration()");
            output.write("\t\t{");
            foreach (IColumn column in table.Columns)
            {
                if ((!column.IsNullable) && (!column.IsInPrimaryKey))
                {
                    output.writeln("");
                    output.write("\t\t\t\tthis.Validator.ValidatorList.Add(new RequiredFieldValidator(this, \"");
                    output.write(SimetriUtils.SetPascalCase(column.Name));
                    output.write("\"));");

                }
            }
            output.writeln("");
            output.writeln("\t\t}");
            output.writeln("    }");
            output.writeln("}");

            //			output.writeln(className);

            output.save(outputFullFileName, false);
            output.clear();
        }

    }




}



