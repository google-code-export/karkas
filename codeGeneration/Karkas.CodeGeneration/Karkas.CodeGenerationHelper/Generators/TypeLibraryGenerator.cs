using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class TypeLibraryGenerator : BaseGenerator
    {
        public TypeLibraryGenerator(IDatabaseHelper databaseHelper)
        {
            utils = new Utils(databaseHelper);

        }
        Utils utils = null;

        public void Render(IOutput output, IContainer table, List<DatabaseAbbreviations> listDatabaseAbbreviations)
        {

            IDatabase database = table.Database;
            output.tabLevel = 0;

            string baseNameSpace = database.projectNameSpace;
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = getClassNameForTypeLibrary(table,listDatabaseAbbreviations);
            string schemaName = utils.GetPascalCase(table.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;
            string outputFullFileName = Path.Combine(database.projectFolder + "\\TypeLibrary\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".cs");
            string outputFullFileNameGenerated = Path.Combine(database.projectFolder + "\\TypeLibrary\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");
            //output.setPreserveSource(outputFullFileNameGenerated, "//::", ":://");


            usingNamespaceleriYaz(output, classNameSpace);

            ClassIsmiYaz(output, className, table);

            output.autoTabLn("{");

            MemberVariablesYaz(output, table);

            PropertiesYaz(output, table);

            PropertiesAsStringYaz(output, table);

            PropertyIsimleriYaz(output, table, className);
            ShallowCopyYaz(output, table, className);


            output.writeLine("");

            OnaylamaKoduYaz(output, table);
            EtiketIsimleriYaz(output, table, classNameSpace);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
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

        public string getClassNameForTypeLibrary(IContainer table, List<DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            string tableName = table.Name;
            foreach (DatabaseAbbreviations abbr in listDatabaseAbbreviations)
            {
                if (tableName.Contains(abbr.Abbravetion)
                    && abbr.useAsModuleName == "N"
                    )
                {
                    tableName = tableName.Replace(abbr.Abbravetion, abbr.FullNameReplacement);   
                }
            }

            return utils.GetPascalCase(tableName);
        }


        private void usingNamespaceleriYaz(IOutput output, string classNameSpace)
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
            output.writeLine("");
            BaslangicSusluParentezVeTabArtir(output);
        }

        private void ClassIsmiYaz(IOutput output, string className, IContainer table)
        {
            output.increaseTab();
            output.autoTabLn("[Serializable]");
            DebuggerDisplayYaz(output, table);
            output.autoTab("public partial class ");
            output.autoTab(className + ": BaseTypeLibrary");
            output.writeLine("");


        }

        private void DebuggerDisplayYaz(IOutput output, IContainer table)
        {
            string yazi = "";
            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey || column.IsAutoKey || column.IsInForeignKey)
                {
                    yazi += utils.getPropertyVariableName(column) + " = {" + utils.getPropertyVariableName(column) + "}";
                }

            }
            output.autoTabLn(string.Format("[DebuggerDisplay(\"{0}\")]", yazi));
        }
        private void ClassIsmiYaz(IOutput output, string className)
        {
            output.increaseTab();
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
                output.writeLine("");
                output.autoTab(newBlock);
            }

            output.writeLine("");
        }



        private void OnaylamaKoduYaz(IOutput output, IContainer table)
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

        private void PropertyIsimleriYaz(IOutput output, IContainer table, string className)
        {
            output.autoTabLn("public class PropertyIsimleri");
            BaslangicSusluParentezVeTabArtir(output);
            string propertyName = "";
            foreach (IColumn column in table.Columns)
            {
                propertyName = utils.getPropertyVariableName(column);
                string yazi = string.Format("public const string {0} = \"{1}\";", propertyName, column.Name);
                output.autoTabLn(yazi);
            }
            BitisSusluParentezVeTabAzalt(output);

        }

        private void PropertiesYaz(IOutput output, IContainer table)
        {
            output.increaseTab();
            foreach (IColumn column in table.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);

                output.autoTabLn("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.autoTabLn(string.Format("public {0} {1}", utils.GetLanguageType(column), propertyVariableName));
                output.autoTabLn("{");
                output.increaseTab();
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("get");
                output.autoTabLn("{");
                output.autoTabLn(string.Format("\treturn {0};", memberVariableName));
                output.autoTabLn("}");
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.increaseTab();
                output.autoTabLn(string.Format("if ((this.RowState == DataRowState.Unchanged) && ({0}!= value))", memberVariableName));
                output.autoTabLn("{");
                output.autoTabLn("\tthis.RowState = DataRowState.Modified;");
                output.autoTabLn("}");
                output.autoTabLn(string.Format("{0} = value;", memberVariableName));
                output.decreaseTab();
                output.autoTabLn("}");
                output.decreaseTab();
                output.autoTabLn("}");
                output.writeLine("");
            }
            output.decreaseTab();
        }

        private void PropertiesAsStringYaz(IOutput output, IContainer table)
        {
            output.increaseTab();
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
                output.increaseTab();
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("get");
                output.autoTabLn("{");
                ToStringDegeriDondur(column, output, memberVariableName);
                output.autoTabLn("}");
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.increaseTab();
                string[] yaziListesi = utils.GetConvertToSyntax(column, propertyVariableName);
                foreach (string str in yaziListesi)
                {
                    output.autoTabLn(str);
                }
                output.decreaseTab();
                output.autoTabLn("}");
                output.decreaseTab();
                output.autoTabLn("}");
                output.writeLine("");
            }
            output.decreaseTab();
        }

        private void ToStringDegeriDondur(IColumn column, IOutput output, string memberVariableName)
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



        private void ShallowCopyYaz(IOutput output, IContainer table, string pTypeName)
        {
            output.increaseTab();
            output.autoTabLn(string.Format("public {0} ShallowCopy()", pTypeName));
            output.autoTabLn("{");
            output.increaseTab();
            output.autoTabLn(string.Format("{0} obj = new {0}();", pTypeName));
            foreach (IColumn column in table.Columns)
            {
                output.autoTabLn(string.Format("obj.{0} = {0};", utils.GetCamelCase(column.Name)));
            }
            output.autoTabLn("return obj;");
            output.decreaseTab();
            output.autoTabLn("}");
            output.decreaseTab();
            output.autoTabLn("");

        }


        private void MemberVariablesYaz(IOutput output, IContainer table)
        {
            output.increaseTab();
            foreach (IColumn column in table.Columns)
            {
                output.autoTabLn(String.Format("private {0} {1};", utils.GetLanguageType(column), utils.GetCamelCase(column.Name)));
            }
            output.decreaseTab();
            output.writeLine("");
        }


        private void EtiketIsimleriYaz(IOutput output, IContainer pTable, string pNamespace)
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




