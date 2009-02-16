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
    public class TypeLibraryGenerator : BaseGenerator
    {

        static readonly Utils utils = new Utils();
        TypeLibraryHelper tHelper = new TypeLibraryHelper();

        public void Render(IZeusOutput output, ITable table)
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

            tHelper.MemberVariablesYaz(output, table);

            tHelper.PropertiesYaz(output, table);

            tHelper.PropertiesAsStringYaz(output, table);

            PropertyIsimleriYaz(output, table, className);
            tHelper.ShallowCopyYaz(output, table, className);


            output.writeln("");

            OnaylamaKoduYaz(output, table);
            tHelper.EtiketIsimleriYaz(output, table, classNameSpace);
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

        public void RenderTypeLibraryCode(IZeusOutput output, IView view)
        {
            IDatabase database = view.Database;
            output.tabLevel = 0;

            string baseNameSpace = utils.NamespaceIniAlSchemaIle(database, view.Schema);
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = utils.GetPascalCase(view.Name);
            string schemaName = utils.GetPascalCase(view.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary + "." + schemaName;
            string outputFullFileNameGenerated = Path.Combine(utils.ProjeDizininiAl(database) + "\\TypeLibrary\\" + baseNameSpaceTypeLibrary + "\\" + schemaName, className + ".generated.cs");
            output.setPreserveSource(outputFullFileNameGenerated, "//::", ":://");


            usingNamespaceleriYaz(output, classNameSpace);


            ClassIsmiYaz(output, className);

            output.autoTabLn("{");

            tHelper.MemberVariablesViewYaz(output, view);

            tHelper.PropertiesYaz(output, view);

            output.writeln("");

            OnaylamaKoduYaz(output, view);
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("}");

            //			output.autoTabLn(className);

            output.saveEnc(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
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

        private static void ClassIsmiYaz(IZeusOutput output, string className, ITable table)
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

        private static void DebuggerDisplayYaz(IZeusOutput output, ITable table)
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

        private void OnaylamaKoduYaz(IZeusOutput output, IView view)
        {
            output.autoTabLn("protected override void OnaylamaListesiniOlusturCodeGeneration(){}");
        }
        

        private void OnaylamaKoduYaz(IZeusOutput output, ITable table)
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

        public void PropertyIsimleriYaz(IZeusOutput output, ITable table, string className)
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



    }




}




