using System;
using System.Collections;
using Zeus;
using Zeus.Data;
using Zeus.UserInterface;
using MyMeta;
using Simetri.MyGenerationHelper;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Simetri.MyGenerationHelper.Generators
{

    public class BsWrapperGenerator
    {


        private static Utils SimetriUtils = new Utils();
        public void Render(IZeusOutput output, ITable table)
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

            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            string baseNameSpaceDal = baseNameSpace + ".Dal";
            string baseNameSpaceBs = baseNameSpace + ".Bs";

            string outputPath = "";


            IDatabase database = table.Database;



            baseNameSpace = SimetriUtils.NamespaceIniAlSchemaIle(database, table.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            baseNameSpaceDal = baseNameSpace + ".Dal";
            baseNameSpaceBs = baseNameSpace + ".Bs";

            classNameTypeLibrary = SimetriUtils.SetPascalCase(table.Name);
            classNameDal = SimetriUtils.SetPascalCase(table.Name) + "Dal";
            classNameBs = SimetriUtils.SetPascalCase(table.Name) + "Bs";
            classNameBsWrapper = SimetriUtils.SetPascalCase(table.Name) + "BsWrapper";

            schemaName = SimetriUtils.SetPascalCase(table.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;
            bool identityVarmi;
            string pkcumlesi = "";

            string baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
            string baseNameSpaceBsWrapperWithSchema = baseNameSpace + ".BsWrapper." + schemaName;
            string baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;

            string pkType = SimetriUtils.PrimaryKeyTipiniBul(table);
            string pkAdi = SimetriUtils.PrimaryKeyAdiniBul(table);


            output.writeln("");
            output.writeln("using System;");
            output.writeln("using System.Collections.Generic;");
            output.writeln("using System.Data;");
            output.writeln("using System.Data.SqlClient;");
            output.writeln("using System.Text;");
            output.writeln("using System.ComponentModel;");
            output.writeln("using System.Web;");
            output.writeln("using System.Web.Caching;");
            output.writeln("using Simetri.Web.Helpers.HelperClasses;");
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
            output.write("namespace ");
            output.write(baseNameSpaceBsWrapperWithSchema);
            output.writeln("");
            output.writeln("{");
            ClassBaslangicYaz(output, classNameBs, classNameBsWrapper);
            ConstructorYaz(output, classNameBsWrapper);
            InsertYaz(output, classNameTypeLibrary);
            GuncelleYaz(output, classNameTypeLibrary);
            SilYaz(output, classNameTypeLibrary);
            DurumaGoreEkleGuncelleVeyaSil(output, classNameTypeLibrary);
            SorgulaHepsiniGetirYaz(output, classNameTypeLibrary);
            SorgulaPKAdiIleYaz(output, classNameTypeLibrary, pkType, pkAdi);
            TopluEkleGuncelleVeyaSilYaz(output, classNameTypeLibrary);
            KomutuCalistiranKullaniciyiYaz(output);
            output.writeln("");
            output.writeln("");
            output.writeln("    }");
            output.writeln("}");

            string savePath = Path.Combine(SimetriUtils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\BsWrapper\\" + baseNameSpace + ".BsWrapper\\" + schemaName, classNameTypeLibrary + "BsWrapper.generated.cs");
            //output.writeln(savePath);
            output.save(savePath, true);
            output.clear();
        }
        private static void ConstructorYaz(IZeusOutput output, string classNameBsWrapper)
        {
            output.write("\t\tpublic ");
            output.write(classNameBsWrapper);
            output.writeln("()");
            output.writeln("\t\t{");
            output.writeln("\t\t\tif (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null)");
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
            output.writeln("        [DataObjectMethod(DataObjectMethodType.Select, true)]");
            output.write("        public List<");
            output.write(classNameTypeLibrary);
            output.writeln("> SorgulaHepsiniGetir()");
            output.writeln("        {");
            output.writeln("            return bs.SorgulaHepsiniGetir();");
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

        private static void SilYaz(IZeusOutput output, string classNameTypeLibrary)
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

        private static void InsertYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.writeln("        [DataObjectMethod(DataObjectMethodType.Insert)]");
            output.write("        public void Ekle(");
            output.write(classNameTypeLibrary);
            output.writeln(" p1)");
            output.writeln("        {");
            output.writeln("            bs.Ekle(p1);");
            output.writeln("        }");
            output.writeln("");
            output.writeln("");
        }

    }




}


