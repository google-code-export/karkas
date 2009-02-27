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
using Karkas.MyGenerationHelper.Interfaces;

namespace Karkas.MyGenerationHelper.Generators
{

    public class BsWrapperGenerator : BaseGenerator
    {
        string classNameTypeLibrary = "";
        string classNameDal = "";
        string classNameBs = "";
        string classNameBsWrapper = "";
        string schemaName = "";
        string classNameSpace = "";
        string memberVariableName = "";
        string propertyVariableName = "";

        string baseNameSpace = "";



        string pkAdi = "";
        string pkType = "";

        private static Utils utils = new Utils();
        public void Render(IZeusOutput output, IContainer container)
        {

            output.tabLevel = 0;


            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            string baseNameSpaceDal = baseNameSpace + ".Dal";
            string baseNameSpaceBs = baseNameSpace + ".Bs";

            IDatabase database = container.Database;



            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, container.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            baseNameSpaceDal = baseNameSpace + ".Dal";
            baseNameSpaceBs = baseNameSpace + ".Bs";

            classNameTypeLibrary = utils.GetPascalCase(container.Name);
            classNameDal = utils.GetPascalCase(container.Name) + "Dal";
            classNameBs = utils.GetPascalCase(container.Name) + "Bs";
            classNameBsWrapper = utils.GetPascalCase(container.Name) + "BsWrapper";

            schemaName = utils.GetPascalCase(container.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;


            string baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
            string baseNameSpaceBsWrapperWithSchema = baseNameSpace + ".BsWrapper." + schemaName;
            string baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;

            pkType = utils.PrimaryKeyTipiniBul(container);
            pkAdi = utils.PrimaryKeyAdiniBul(container);


            usingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema);
            output.write("namespace ");
            output.write(baseNameSpaceBsWrapperWithSchema);
            output.writeln("");
            output.writeln("{");
            ClassBaslangicYaz(output, classNameBs, classNameBsWrapper);
            ConstructorYaz(output, classNameBsWrapper);
            EkleYaz(output);
            GuncelleYaz(output, classNameTypeLibrary);
            SilKomutuYaz(output, classNameTypeLibrary);

            if (container is TableContainer)
            {
                SilKomutuYazPkIle(output);

                SorgulaPKAdiIleYaz(output, classNameTypeLibrary, pkType, pkAdi);
            }

            DurumaGoreEkleGuncelleVeyaSil(output, classNameTypeLibrary);
            SorgulaHepsiniGetirYaz(output, classNameTypeLibrary);
            SorgulaHepsiniGetirSiraliYaz(output, classNameTypeLibrary);
            TopluEkleGuncelleVeyaSilYaz(output, classNameTypeLibrary);
            KomutuCalistiranKullaniciyiYaz(output);
            output.writeln("");
            output.writeln("");
            output.writeln("    }");
            output.writeln("}");

            string outputFullFileNameGenerated = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, container.Schema) + "\\BsWrapper\\" + baseNameSpace + ".BsWrapper\\" + schemaName, classNameTypeLibrary + "BsWrapper.generated.cs");
            string outputFullFileName = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, container.Schema) + "\\BsWrapper\\" + baseNameSpace + ".BsWrapper\\" + schemaName, classNameTypeLibrary + "BsWrapper.cs");
            output.saveEnc(outputFullFileNameGenerated, "o", "utf8");
            output.clear();

            if (!File.Exists(outputFullFileName))
            {
                usingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema);
                output.write("namespace ");
                output.write(baseNameSpaceBsWrapperWithSchema);
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTab("    public partial class ");
                output.autoTabLn(classNameBsWrapper);
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.save(outputFullFileName, false);
                output.clear();
            }


        }

        private static void usingleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibrary, string baseNameSpaceBsWithSchema)
        {
            output.writeln("");
            output.writeln("using System;");
            output.writeln("using System.Collections.Generic;");
            output.writeln("using System.Data;");
            output.writeln("using System.Data.SqlClient;");
            output.writeln("using System.Text;");
            output.writeln("using System.ComponentModel;");
            output.writeln("using System.Web;");
            output.writeln("using System.Web.Caching;");
            output.writeln("using Karkas.Web.Helpers.HelperClasses;");
            output.write("using ");
            output.write(baseNameSpaceTypeLibrary);
            output.writeln(";");
            output.write("using ");
            output.write(baseNameSpaceTypeLibrary);
            output.write(".");
            output.write(schemaName);
            output.writeln(";");
            output.write("using ");
            output.write(baseNameSpaceBsWithSchema);
            output.writeln(";");
            output.writeln("");
            output.writeln("");
        }
        private static void ConstructorYaz(IZeusOutput output, string classNameBsWrapper)
        {
            output.write("\t\tpublic ");
            output.write(classNameBsWrapper);
            output.writeln("()");
            output.writeln("\t\t{");
            output.writeln("\t\t\tif ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))");
            output.writeln("\t\t\t{");
            output.writeln("\t\t\t\tbs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];");
            output.writeln("\t\t\t}");
            output.writeln("\t\t}");
        }


        private static void ClassBaslangicYaz(IZeusOutput output, string classNameBs, string classNameBsWrapper)
        {
            output.writeln("    [DataObject]");
            output.write("    public partial class ");
            output.write(classNameBsWrapper);
            output.writeln(" ");
            output.writeln("    {");
            output.write("        ");
            output.write(classNameBs);
            output.write(" bs = new ");
            output.write(classNameBs);
            output.writeln("();");
            output.writeln("\t\t");
            output.writeln("");
        }
        private static void KomutuCalistiranKullaniciyiYaz(IZeusOutput output)
        {
            output.writeln("        public Guid KomutuCalistiranKullaniciKisiKey");
            output.writeln("        {");
            output.writeln("\t\t\tget");
            output.writeln("\t\t\t{");
            output.writeln("\t\t\t\treturn bs.KomutuCalistiranKullaniciKisiKey;");
            output.writeln("\t\t\t}");
            output.writeln("\t\t\tset");
            output.writeln("\t\t\t{");
            output.writeln("\t\t\t\tbs.KomutuCalistiranKullaniciKisiKey = value;");
            output.writeln("\t\t\t}");
            output.writeln("        }");
        }

        private static void TopluEkleGuncelleVeyaSilYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.writeln("        [DataObjectMethod(DataObjectMethodType.Insert)]");
            output.write("        public void TopluEkleGuncelleVeyaSil(List<");
            output.write(classNameTypeLibrary);
            output.writeln("> liste)");
            output.writeln("        {");
            output.writeln("            bs.TopluEkleGuncelleVeyaSil(liste);");
            output.writeln("        }");
        }

        private static void SorgulaPKAdiIleYaz(IZeusOutput output, string classNameTypeLibrary, string pkType, string pkAdi)
        {
            output.writeln("        [DataObjectMethod(DataObjectMethodType.Select)]");
            output.write("\t\tpublic ");
            output.write(classNameTypeLibrary);
            output.write(" Sorgula");
            output.write(pkAdi);
            output.write("Ile(");
            output.write(pkType);
            output.writeln(" p1)");
            output.writeln("\t\t{");
            output.write("\t\t\treturn bs.Sorgula");
            output.write(pkAdi);
            output.writeln("Ile(p1);");
            output.writeln("\t\t}");
            output.writeln("\t\t");
        }

        private static void SorgulaHepsiniGetirYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.writeln("      [DataObjectMethod(DataObjectMethodType.Select, true)]");
            output.write("        public List<");
            output.write(classNameTypeLibrary);
            output.writeln("> SorgulaHepsiniGetir()");
            output.writeln("        {");
            output.writeln("            return bs.SorgulaHepsiniGetir();");
            output.writeln("        }");
            output.writeln("");
        }
        private static void SorgulaHepsiniGetirSiraliYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.writeln("      [DataObjectMethod(DataObjectMethodType.Select, false)]");
            output.write("        public List<");
            output.write(classNameTypeLibrary);
            output.writeln("> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)");
            output.writeln("        {");
            output.writeln("            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);");
            output.writeln("        }");
            output.writeln("");
        }

        private static void DurumaGoreEkleGuncelleVeyaSil(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("        public void DurumaGoreEkleGuncelleVeyaSil(");
            output.write(classNameTypeLibrary);
            output.writeln(" k)");
            output.writeln("        {");
            output.writeln("            bs.DurumaGoreEkleGuncelleVeyaSil(k);");
            output.writeln("        }");
            output.writeln("");
            output.writeln("");
        }

        private static void SilKomutuYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.writeln("        [DataObjectMethod(DataObjectMethodType.Delete)]");
            output.write("        public void Sil(");
            output.write(classNameTypeLibrary);
            output.writeln(" k)");
            output.writeln("        {");
            output.writeln("            bs.Sil(k);");
            output.writeln("        }");
            output.writeln("");
        }
        private void SilKomutuYazPkIle(IZeusOutput output)
        {
            output.incTab();
            output.incTab();
            output.autoTabLn(string.Format("public void Sil({0} {1})", pkType, pkAdi));
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("bs.Sil(" + pkAdi + ");");
            BitisSusluParentezVeTabAzalt(output);
        }

        private static void GuncelleYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.writeln("        [DataObjectMethod(DataObjectMethodType.Update)]");
            output.write("        public void Guncelle(");
            output.write(classNameTypeLibrary);
            output.writeln(" k)");
            output.writeln("        {");
            output.writeln("            bs.Guncelle(k);");
            output.writeln("        }");
        }

        private void EkleYaz(IZeusOutput output)
        {
            if (pkType == "int" 
                || pkType == "long"
                || pkType == "short"
                || pkType == "byte"
                )
            {
                output.writeln("        [DataObjectMethod(DataObjectMethodType.Insert)]");
                output.write(string.Format("        public {0} Ekle({1} p1 )", pkType,classNameTypeLibrary));
                output.writeln("        {");
                output.writeln(string.Format("            return ({0}) bs.Ekle(p1);", pkType));
                output.writeln("        }");
                output.writeln("");
                output.writeln("");
                
            }
            else
            {
                output.writeln("        [DataObjectMethod(DataObjectMethodType.Insert)]");
                output.write(string.Format("        public void Ekle({0} p1 )",classNameTypeLibrary));
                output.writeln("        {");
                output.writeln("            bs.Ekle(p1);");
                output.writeln("            return;");
                output.writeln("        }");
                output.writeln("");
                output.writeln("");

            }
        }

    }




}



