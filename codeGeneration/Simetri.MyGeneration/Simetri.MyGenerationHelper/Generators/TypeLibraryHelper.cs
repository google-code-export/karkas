using System;
using System.Collections.Generic;
using System.Text;
using Zeus;
using MyMeta;

namespace Simetri.MyGenerationHelper.Generators
{
    public class TypeLibraryHelper
    {
        private static Utils SimetriUtils = new Utils();
        public static void writePropertiesTable(IZeusOutput output, ITable table)
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


        public static void writeMemberVariablesTable(IZeusOutput output, ITable table)
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
