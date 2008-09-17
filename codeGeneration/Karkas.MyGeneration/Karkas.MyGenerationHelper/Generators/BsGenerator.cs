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
            output.writeln(" ");
            output.writeln("    {");
            output.write("        ");
            output.write(classNameDal);
            output.write(" dal = new ");
            output.write(classNameDal);
            output.writeln("();");
        }

        private static void TopluEkleGuncelleVeyaSilYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public void TopluEkleGuncelleVeyaSil(List<");
            output.write(classNameTypeLibrary);
            output.writeln("> liste)");
            output.writeln("        {");
            output.writeln("            dal.TopluEkleGuncelleVeyaSil(liste);");
            output.writeln("        }");
            output.writeln("\t\t");
        }

        private static void sorgulaPkAdiIleYaz(IZeusOutput output, string classNameTypeLibrary, string pkType, string pkAdi)
        {
            output.write("\t\tpublic ");
            output.write(classNameTypeLibrary);
            output.write(" Sorgula");
            output.write(pkAdi);
            output.write("Ile(");
            output.write(pkType);
            output.writeln(" p1)");
            output.writeln("\t\t{");
            output.write("\t\t\treturn dal.Sorgula");
            output.write(pkAdi);
            output.writeln("Ile(p1);");
            output.writeln("\t\t}");
            output.writeln("");
        }

        private static void SorgulaHepsiniGetirYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public List<");
            output.write(classNameTypeLibrary);
            output.writeln("> SorgulaHepsiniGetir()");
            output.writeln("        {");
            output.writeln("            return dal.SorgulaHepsiniGetir();");
            output.writeln("        }");
            output.writeln("");
        }
        private static void SorgulaHepsiniGetirSiraliYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public List<");
            output.write(classNameTypeLibrary);
            output.writeln("> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)");
            output.writeln("        {");
            output.writeln("            return dal.SorgulaHepsiniGetirSirali(pSiraListesi);");
            output.writeln("        }");
            output.writeln("");
        }

        private static void DurumaGoreEkleGuncelleVeyaSilYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public void DurumaGoreEkleGuncelleVeyaSil(");
            output.write(classNameTypeLibrary);
            output.writeln(" k)");
            output.writeln("        {");
            output.writeln("            dal.DurumaGoreEkleGuncelleVeyaSil(k);");
            output.writeln("        }");
            output.writeln("");
        }

        private static void SilKomutuYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public void Sil(");
            output.write(classNameTypeLibrary);
            output.writeln(" k)");
            output.writeln("        {");
            output.writeln("            dal.Sil(k);");
            output.writeln("        }");
            output.writeln("");
        }

        private void SilKomutuYazPkIle(IZeusOutput output)
        {
            output.incTab();
            output.autoTabLn(string.Format("public void Sil({0} {1})", pkType, pkAdi));
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("dal.Sil(" + pkAdi +");");
            BitisSusluParentezVeTabAzalt(output);
        }

        private static void GuncelleYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public void Guncelle(");
            output.write(classNameTypeLibrary);
            output.writeln(" k)");
            output.writeln("        {");
            output.writeln("            dal.Guncelle(k);");
            output.writeln("        }");
        }

        private static void EkleYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public void Ekle(");
            output.write(classNameTypeLibrary);
            output.writeln(" k)");
            output.writeln("        {");
            output.writeln("            dal.Ekle(k);");
            output.writeln("        }");
            output.writeln("");
        }

        private static void classYaz(IZeusOutput output, string classNameBs)
        {
            output.autoTab("public partial class ");
            output.autoTabLn(classNameBs);
        }

        public void usingNamespaceleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibrary, string baseNameSpaceBsWithSchema, string baseNameSpaceDalWithSchema)
        {
            output.writeln("");
            output.writeln("using System;");
            output.writeln("using System.Collections.Generic;");
            output.writeln("using System.Data;");
            output.writeln("using System.Data.SqlClient;");
            output.writeln("using System.Text;");
            output.write("using ");
            output.write(baseNameSpaceTypeLibrary);
            output.writeln(";");
            output.write("using ");
            output.write(baseNameSpaceTypeLibrary);
            output.write(".");
            output.write(schemaName);
            output.writeln(";");
            output.write("using ");
            output.write(baseNameSpaceDalWithSchema);
            output.writeln(";");
            output.writeln("");
            output.writeln("");
            output.write("namespace ");
            output.write(baseNameSpaceBsWithSchema);
            output.writeln("");
        }

        private static void tablodakiSatirSayisiniYaz(IZeusOutput output)
        {
            output.writeln("        public int TablodakiSatirSayisi");
            output.writeln("        {");
            output.writeln("\t\t\tget");
            output.writeln("\t\t\t{");
            output.writeln("\t\t\t\treturn dal.TablodakiSatirSayisi;");
            output.writeln("\t\t\t}");
            output.writeln("        }");
        }

        private static void KomutuCalistiranKullaniciyiYaz(IZeusOutput output)
        {
            output.writeln("        public Guid KomutuCalistiranKullaniciKisiKey");
            output.writeln("        {");
            output.writeln("\t\t\tget");
            output.writeln("\t\t\t{");
            output.writeln("\t\t\t\treturn dal.KomutuCalistiranKullaniciKisiKey;");
            output.writeln("\t\t\t}");
            output.writeln("\t\t\tset");
            output.writeln("\t\t\t{");
            output.writeln("\t\t\t\tdal.KomutuCalistiranKullaniciKisiKey = value;");
            output.writeln("\t\t\t}");
            output.writeln("        }");
        }

    }




}


