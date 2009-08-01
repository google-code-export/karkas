using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;
using Karkas.MyGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Zeus;
using Karkas.MyGenerationHelper.Interfaces;

namespace Karkas.MyGenerationHelper.Generators
{
    public class TypeLibraryGenerator : BaseGenerator
    {

        static readonly Utils utils = new Utils();

        public void Render(IZeusOutput output, IContainer table)
        {
            IDatabase database = table.Database;
            output.tabLevel = 0;

            string baseNameSpace = utils.NamespaceIniAlSchemaIle(database, table.Schema);
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = utils.GetPascalCase(table.Name);
            string schemaName = utils.GetPascalCase(table.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;
            string outputFullFileName = Path.Combine(utils.ProjeDizininiAl(database) + "\\TypeLibrary\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".cs");
            string outputFullFileNameGenerated = Path.Combine(utils.ProjeDizininiAl(database) + "\\TypeLibrary\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");
            output.setPreserveSource(outputFullFileNameGenerated, "//::", ":://");


            usingNamespaceleriYaz(output, classNameSpace);

            ClassIsmiYaz(output, className,table);

            output.autoTabLn("{");

            MemberVariablesYaz(output, table);

            PropertiesYaz(output, table);

            PropertiesAsStringYaz(output, table);

            PropertyIsimleriYaz(output, table, className);
            ShallowCopyYaz(output, table, className);


            output.writeln("");

            OnaylamaKoduYaz(output, table);
            EtiketIsimleriYaz(output, table, classNameSpace);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.saveEnc(outputFullFileNameGenerated, "o","utf8");
            output.clear();




            if (!File.Exists(outputFullFileName))
            {
                usingNamespaceleriYaz(output, classNameSpace);
                output.autoTab("public partial class ");
                output.autoTabLn(className);
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.save(outputFullFileName, false);
                output.clear();
            }


        }


        public void usingNamespaceleriYaz(IZeusOutput output, string classNameSpace)
        {
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using System.Configuration;");
            output.autoTabLn("using System.Diagnostics;");
            output.autoTabLn("using System.Xml.Serialization;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using Karkas.Core.TypeLibrary;");
            output.autoTabLn("using Karkas.Core.Onaylama;");
            output.autoTabLn("using Karkas.Core.Onaylama.ForPonos;");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTabLn(classNameSpace);
            output.writeln("");
            BaslangicSusluParentezVeTabArtir(output);
        }

        private static void ClassIsmiYaz(IZeusOutput output, string className, IContainer table)
        {
            output.incTab();
            output.autoTabLn("[Serializable]");
            DebuggerDisplayYaz(output, table);
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

        private static void DebuggerDisplayYaz(IZeusOutput output, IContainer table)
        {
            string yazi = "";
            foreach (IColumn  column in table.Columns)
            {
                if (column.IsInPrimaryKey || column.IsAutoKey || column.IsInForeignKey)
                {
                    yazi += utils.getPropertyVariableName(column) + " = {" + utils.getPropertyVariableName(column)  + "}";
                }

            }
            output.autoTabLn(string.Format("[DebuggerDisplay(\"{0}\")]", yazi));
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

        

        private void OnaylamaKoduYaz(IZeusOutput output, IContainer table)
        {
            output.autoTabLn("protected override void OnaylamaListesiniOlusturCodeGeneration()");
            BaslangicSusluParentezVeTabArtir(output);
            foreach (IColumn column in table.Columns)
            {
                if ((!column.IsNullable) && (!column.IsInPrimaryKey))
                {
                    output.autoTabLn("");
                    output.autoTab("this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, \"");
                    output.write(utils.getPropertyVariableName(column));
                    output.write("\"));");

                }
            }
            BitisSusluParentezVeTabAzalt(output);
        }

        public void PropertyIsimleriYaz(IZeusOutput output, IContainer table, string className)
        {
            output.autoTabLn("public class PropertyIsimleri");
            BaslangicSusluParentezVeTabArtir(output);
            string propertyName = "";
            foreach (IColumn column in table.Columns)
            {
                propertyName = utils.getPropertyVariableName(column);
                string yazi = string.Format("public const string {0} = \"{1}\";",propertyName,column.Name);
                output.autoTabLn(yazi);
            }
            BitisSusluParentezVeTabAzalt(output);

        }

        public void PropertiesYaz(IZeusOutput output, IContainer table)
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

        public void PropertiesAsStringYaz(IZeusOutput output, IContainer table)
        {
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                string tipi = utils.GetLanguageType(column);
                if (tipi == "string")
                {
                    continue;
                }
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
                ToStringDegeriDondur(column, output, memberVariableName);
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

        private void ToStringDegeriDondur(IColumn column, IZeusOutput output, string memberVariableName)
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



        public void ShallowCopyYaz(IZeusOutput output, IContainer table, string pTypeName)
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


        public void MemberVariablesYaz(IZeusOutput output, IContainer table)
        {
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                output.autoTabLn(String.Format("private {0} {1};", utils.GetLanguageType(column), utils.GetCamelCase(column.Name)));
            }
            output.decTab();
            output.writeln("");
        }


        public void EtiketIsimleriYaz(IZeusOutput output, IContainer pTable, string pNamespace)
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




