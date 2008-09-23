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
            classYaz(output, classNameBs);
            dalDegiskeniYaz(output, classNameDal);
            EkleYaz(output, classNameTypeLibrary);
            GuncelleYaz(output, classNameTypeLibrary);
            SilKomutuYaz(output, classNameTypeLibrary);
            SilKomutuYazPkIle(output);
            DurumaGoreEkleGuncelleVeyaSilYaz(output, classNameTypeLibrary);
            SorgulaHepsiniGetirYaz(output, classNameTypeLibrary);
            SorgulaHepsiniGetirSiraliYaz(output, classNameTypeLibrary);

            sorgulaPkAdiIleYaz(output, classNameTypeLibrary, pkType, pkAdi);
            TopluEkleGuncelleVeyaSilYaz(output, classNameTypeLibrary);
            tablodakiSatirSayisiniYaz(output);
            KomutuCalistiranKullaniciyiYaz(output);
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
                classYaz(output, classNameBs);
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.saveEnc(outputFullFileName, "o", "utf8");
                output.clear();
            }
        }

        private static void dalDegiskeniYaz(IZeusOutput output, string classNameDal)
        {
            output.incTab();
            output.autoTab(classNameDal + " dal = new " + classNameDal + "();");
            output.autoTabLn("");
        }

        private static void TopluEkleGuncelleVeyaSilYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            string classSatiri = "public void TopluEkleGuncelleVeyaSil(List<" + classNameTypeLibrary + "> liste)";
            output.autoTabLn(classSatiri);
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("dal.TopluEkleGuncelleVeyaSil(liste);");
            output.decTab();
            output.autoTabLn("}");

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

        private static void SorgulaHepsiniGetirYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            string classSatiri = "public List< " + classNameTypeLibrary + " > SorgulaHepsiniGetir()";
            output.autoTabLn(classSatiri);
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("return dal.SorgulaHepsiniGetir();");
            output.decTab();
            output.autoTabLn("}");

        }
        private static void SorgulaHepsiniGetirSiraliYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            string classSatiri = "public List< " + classNameTypeLibrary + " > SorgulaHepsiniGetirSirali(params string[] pSiraListesi)";
            output.autoTabLn(classSatiri);
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("return dal.SorgulaHepsiniGetirSirali(pSiraListesi);");
            output.decTab();
            output.autoTabLn("}");
        }

        private static void DurumaGoreEkleGuncelleVeyaSilYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            string classSatiri = "public void DurumaGoreEkleGuncelleVeyaSil(" + classNameTypeLibrary + " k)";
            output.autoTabLn(classSatiri);
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("dal.DurumaGoreEkleGuncelleVeyaSil(k);");
            output.decTab();
            output.autoTabLn("}");
        }

        private static void SilKomutuYaz(IZeusOutput output, string classNameTypeLibrary)
        {

            output.autoTabLn("public void Sil(" + classNameTypeLibrary + " k)");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("dal.Sil(k);");
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

        private static void GuncelleYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.autoTabLn("public void Guncelle(" + classNameTypeLibrary + " k)");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("dal.Guncelle(k);");
            output.decTab();
            output.autoTabLn("}");
        }

        private static void EkleYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.autoTabLn("public void Ekle(" + classNameTypeLibrary + " k)");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("dal.Ekle(k);");
            output.decTab();
            output.autoTabLn("}");

        }

        private static void classYaz(IZeusOutput output, string classNameBs)
        {
            output.autoTab("public partial class ");
            output.autoTabLn(classNameBs);
            output.incTab();
            output.autoTabLn("{");
        }

        public void usingNamespaceleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibrary, string baseNameSpaceBsWithSchema, string baseNameSpaceDalWithSchema)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
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

        private static void tablodakiSatirSayisiniYaz(IZeusOutput output)
        {
            output.autoTabLn("public int TablodakiSatirSayisi");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("get");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("return dal.TablodakiSatirSayisi;");
            output.decTab();
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("}");
        }

        private static void KomutuCalistiranKullaniciyiYaz(IZeusOutput output)
        {
            output.autoTabLn("public Guid KomutuCalistiranKullaniciKisiKey");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("get");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("return dal.KomutuCalistiranKullaniciKisiKey;");
            output.decTab();
            output.autoTabLn("}");
            output.autoTabLn("set");
            output.autoTabLn("{");
            output.incTab();
            output.autoTabLn("dal.KomutuCalistiranKullaniciKisiKey = value;");
            output.decTab();
            output.autoTabLn("}");
            output.decTab();
            output.autoTabLn("}");
        }

    }




}


