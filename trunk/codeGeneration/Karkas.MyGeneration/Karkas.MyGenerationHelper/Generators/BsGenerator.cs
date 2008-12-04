using System;
using System.Collections;
using Zeus;
using Zeus.Data;
using Zeus.UserInterface;
using MyMeta;
using Karkas.MyGenerationHelper;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Karkas.MyGenerationHelper.Generators
{
    public class BsGenerator : BaseGenerator
    {
        string classNameTypeLibrary = "";
        string classNameDal = "";
        string classNameBs = "";
        string schemaName = "";
        string classNameSpace = "";
        string memberVariableName = "";
        string propertyVariableName = "";
        string pkAdi = "";
        string pkType = "";



        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";
        string baseNameSpaceDal = "";
        string baseNameSpaceBs = "";


        private static Utils utils = new Utils();
        public void Render(IZeusOutput output, ITable table)
        {
            output.tabLevel = 0;
            IDatabase database = table.Database;
            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, table.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            baseNameSpaceDal = baseNameSpace + ".Dal";
            baseNameSpaceBs = baseNameSpace + ".Bs";

            classNameTypeLibrary = utils.SetPascalCase(table.Name);
            classNameDal = utils.SetPascalCase(table.Name) + "Dal";
            classNameBs = utils.SetPascalCase(table.Name) + "Bs";

            schemaName = utils.SetPascalCase(table.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;
            bool identityVarmi;
            string pkcumlesi = "";

            string baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
            string baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;

            pkType = utils.PrimaryKeyTipiniBul(table);
            pkAdi = utils.PrimaryKeyAdiniBul(table);


            usingNamespaceleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema, baseNameSpaceDalWithSchema);
            BaslangicSusluParentez(output);
            classYaz(output, classNameBs,classNameDal,classNameTypeLibrary);
            BaslangicSusluParentezVeTabArtir(output);

            OverrideDatabaseNameYaz(output, table);

            SilKomutuYazPkIle(output);

            sorgulaPkAdiIleYaz(output, classNameTypeLibrary, pkType, pkAdi);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentez(output);

            string outputFullFileNameGenerated = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\Bs\\" + baseNameSpace + ".Bs\\" + schemaName, classNameTypeLibrary + "Bs.generated.cs");
            string outputFullFileName = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\Bs\\" + baseNameSpace + ".Bs\\" + schemaName, classNameTypeLibrary + "Bs.cs");
            output.saveEnc(outputFullFileNameGenerated, "o", "utf8");
            output.clear();

            if (!File.Exists(outputFullFileName))
            {
                usingNamespaceleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema, baseNameSpaceDalWithSchema);
                BaslangicSusluParentezVeTabArtir(output);
                classYaz(output, classNameBs,classNameDal,classNameTypeLibrary);
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.saveEnc(outputFullFileName, "o", "utf8");
                output.clear();
            }
        }

        private void OverrideDatabaseNameYaz(IZeusOutput output, ITable table)
        {
            output.autoTabLn("public override string DatabaseName");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";", table.Database.Name));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private static void sorgulaPkAdiIleYaz(IZeusOutput output, string classNameTypeLibrary, string pkType, string pkAdi)
        {
            string classSatiri = "public " + classNameTypeLibrary + " Sorgula"
                            + pkAdi + "Ile(" + pkType
                            + " p1)";
            output.autoTabLn(classSatiri);
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("return dal.Sorgula" + pkAdi + "Ile(p1);");
            output.decTab();
            output.autoTabLn("}");

        }







        private void SilKomutuYazPkIle(IZeusOutput output)
        {
            output.autoTabLn(string.Format("public void Sil({0} {1})", pkType, pkAdi));
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("dal.Sil(" + pkAdi + ");");
            BitisSusluParentezVeTabAzalt(output);

        }




        private static void classYaz(IZeusOutput output, string classNameBs,string classNameDal,string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.autoTabLn(string.Format("{0} : BaseBs<{1}, {2}>", classNameBs, classNameTypeLibrary, classNameDal));
            output.incTab();
            //output.autoTabLn("{");
        }

        public void usingNamespaceleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibrary, string baseNameSpaceBsWithSchema, string baseNameSpaceDalWithSchema)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTab("using ");
            output.autoTab(baseNameSpaceTypeLibrary);
            output.autoTabLn(";");
            output.autoTab("using ");
            output.autoTab(baseNameSpaceTypeLibrary);
            output.autoTab(".");
            output.autoTab(schemaName);
            output.autoTabLn(";");
            output.autoTab("using ");
            output.autoTab(baseNameSpaceDalWithSchema);
            output.autoTabLn(";");
            output.autoTabLn("");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceBsWithSchema);
            output.autoTabLn("");
        }




    }




}


