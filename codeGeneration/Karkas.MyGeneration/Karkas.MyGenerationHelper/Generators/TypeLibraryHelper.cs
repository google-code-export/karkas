using System;
using System.Collections.Generic;
using System.Text;
using Zeus;
using MyMeta;

namespace Karkas.MyGenerationHelper.Generators
{


    public class TypeLibraryHelper : BaseGenerator
    {



        private Utils utils = new Utils();

        public void PropertiesYaz(IZeusOutput output, ITable table)
        {
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);

                output.autoTabLn("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.autoTabLn(string.Format("public {0} {1}", utils.GetLanguageType(column), propertyVariableName));
                output.autoTabLn("{");
                output.incTab();
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("get");
                output.autoTabLn("{");
                output.autoTabLn(string.Format("\treturn {0};", memberVariableName));
                output.autoTabLn("}");
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.incTab();
                output.autoTabLn(string.Format("if ((this.RowState == DataRowState.Unchanged) && ({0}!= value))", memberVariableName));
                output.autoTabLn("{");
                output.autoTabLn("\tthis.RowState = DataRowState.Modified;");
                output.autoTabLn("}");
                output.autoTabLn(string.Format("{0} = value;", memberVariableName));
                output.decTab();
                output.autoTabLn("}");
                output.decTab();
                output.autoTabLn("}");
                output.writeln("");
            }
            output.decTab();
        }

        public void PropertiesAsStringYaz(IZeusOutput output, ITable table)
        {
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);
                output.autoTabLn("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.autoTabLn("[XmlIgnore, SoapIgnore]");
                output.autoTabLn(string.Format("public string {0}AsString", propertyVariableName));
                output.autoTabLn("{");
                output.incTab();
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("get");
                output.autoTabLn("{");
                ToStringDegeriDondur(column,output, memberVariableName);
                output.autoTabLn("}");
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.incTab();
                string[] yaziListesi = utils.GetConvertToSyntax(column, propertyVariableName);
                foreach (string str in yaziListesi)
                {
                    output.autoTabLn(str);
                }
                output.decTab();
                output.autoTabLn("}");
                output.decTab();
                output.autoTabLn("}");
                output.writeln("");
            }
            output.decTab();
        }

        private void ToStringDegeriDondur(IColumn column,IZeusOutput output, string memberVariableName)
        {
            if (utils.ColumnNullDegeriAlabilirMi(column))
            {
                output.autoTabLn(string.Format("\t return {0} != null ? {0}.ToString() : \"\"; ", memberVariableName));
            }
            else
            {
                output.autoTabLn(string.Format("\t return {0}.ToString(); ", memberVariableName));
            }
        }

        public void PropertiesYaz(IZeusOutput output, IView view)
        {
            output.incTab();
            foreach (IColumn column in view.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.GetPascalCase(column.Name);
                output.autoTabLn("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.autoTabLn(string.Format("public {0} {1}", utils.GetLanguageType(column), propertyVariableName));
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
                output.autoTabLn(string.Format("{0} = value;", memberVariableName));
                output.decTab();
                output.autoTabLn("}");
                output.decTab();
                output.autoTabLn("}");
                output.writeln("");
            }
            output.decTab();
        }


        public void ShallowCopyYaz(IZeusOutput output, ITable table, string pTypeName)
        {
            output.incTab();
            output.autoTabLn(string.Format("public {0} ShallowCopy()", pTypeName));
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn(string.Format("{0} obj = new {0}();", pTypeName));
            foreach (IColumn column in table.Columns)
            {
                output.autoTabLn(string.Format("obj.{0} = {0};", utils.GetCamelCase(column.Name)));
            }
            output.autoTabLn("return obj;");
            output.decTab();
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("");

        }


        public void MemberVariablesYaz(IZeusOutput output, ITable table)
        {
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                output.autoTabLn(String.Format("private {0} {1};", utils.GetLanguageType(column), utils.GetCamelCase(column.Name)));
            }
            output.decTab();
            output.writeln("");
        }
        public void MemberVariablesViewYaz(IZeusOutput output, IView view)
        {
            output.incTab();
            foreach (IColumn column in view.Columns)
            {
                output.autoTabLn(String.Format("private {0} {1};", utils.GetLanguageType(column), utils.GetCamelCase(column.Name)));
            }
            output.decTab();
            output.writeln("");
        }


        public void EtiketIsimleriYaz(IZeusOutput output, ITable pTable, string pNamespace)
        {
            output.autoTabLn("public static class EtiketIsimleri");
            BaslangicSusluParentezVeTabArtir(output);

            output.autoTabLn(string.Format("const string namespaceVeClass = \"{0}\";", pNamespace));
            foreach (IColumn column in pTable.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.GetPascalCase(column.Name);
                output.autoTabLn("public static string " + propertyVariableName);
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("get");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn(string.Format("string s = ConfigurationManager.AppSettings[namespaceVeClass + \".{0}\"];", propertyVariableName));
                output.autoTabLn("if (s != null)");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("return s;");
                BitisSusluParentezVeTabAzalt(output);
                output.autoTabLn("else");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn(string.Format("return \"{0}\";", propertyVariableName));
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
            }
            BitisSusluParentezVeTabAzalt(output);
        }




    }
}
