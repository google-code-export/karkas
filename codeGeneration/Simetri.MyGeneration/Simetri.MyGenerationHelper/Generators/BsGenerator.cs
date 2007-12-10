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
    public class BsGenerator
    {

        
        private static Utils SimetriUtils = new Utils();
        public void Render(IZeusOutput output, ITable table)
        {
            string classNameTypeLibrary = "";
            string classNameDal = "";
            string classNameBs = "";
            string schemaName = "";
            string classNameSpace = "";
            string memberVariableName = "";
            string propertyVariableName = "";


            IDatabase database = table.Database;


            string baseNameSpace = "";
            string baseNameSpaceTypeLibrary = "";
            string baseNameSpaceDal = "";
            string baseNameSpaceBs = "";






                baseNameSpace = SimetriUtils.NamespaceIniAlSchemaIle(database, table.Schema);
                baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
                baseNameSpaceDal = baseNameSpace + ".Dal";
                baseNameSpaceBs = baseNameSpace + ".Bs";


                classNameTypeLibrary = SimetriUtils.SetPascalCase(table.Name);
                classNameDal = SimetriUtils.SetPascalCase(table.Name) + "Dal";
                classNameBs = SimetriUtils.SetPascalCase(table.Name) + "Bs";

                schemaName = SimetriUtils.SetPascalCase(table.Schema);
                classNameSpace = baseNameSpace + "." + schemaName;
                bool identityVarmi;
                string pkcumlesi = "";

                string baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
                string baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;

                string pkType = SimetriUtils.PrimaryKeyTipiniBul(table);
                string pkAdi = SimetriUtils.PrimaryKeyAdiniBul(table);


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
                output.writeln("{");
                output.write("    public partial class ");
                output.write(classNameBs);
                output.writeln(" ");
                output.writeln("    {");
                output.write("        ");
                output.write(classNameDal);
                output.write(" dal = new ");
                output.write(classNameDal);
                output.writeln("();");
                output.write("        public void Ekle(");
                output.write(classNameTypeLibrary);
                output.writeln(" k)");
                output.writeln("        {");
                output.writeln("            dal.Ekle(k);");
                output.writeln("        }");
                output.writeln("");
                output.write("        public void Guncelle(");
                output.write(classNameTypeLibrary);
                output.writeln(" k)");
                output.writeln("        {");
                output.writeln("            dal.Guncelle(k);");
                output.writeln("        }");
                output.write("        public void Sil(");
                output.write(classNameTypeLibrary);
                output.writeln(" k)");
                output.writeln("        {");
                output.writeln("            dal.Sil(k);");
                output.writeln("        }");
                output.writeln("");
                output.write("        public void DurumaGoreEkleGuncelleVeyaSil(");
                output.write(classNameTypeLibrary);
                output.writeln(" k)");
                output.writeln("        {");
                output.writeln("            dal.DurumaGoreEkleGuncelleVeyaSil(k);");
                output.writeln("        }");
                output.writeln("");
                output.write("        public List<");
                output.write(classNameTypeLibrary);
                output.writeln("> SorgulaHepsiniGetir()");
                output.writeln("        {");
                output.writeln("            return dal.SorgulaHepsiniGetir();");
                output.writeln("        }");
                output.writeln("");
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
                output.write("        public void TopluEkleGuncelleVeyaSil(List<");
                output.write(classNameTypeLibrary);
                output.writeln("> liste)");
                output.writeln("        {");
                output.writeln("            dal.TopluEkleGuncelleVeyaSil(liste);");
                output.writeln("        }");
                output.writeln("\t\t");
                output.writeln("        public int TablodakiSatirSayisi");
                output.writeln("        {");
                output.writeln("\t\t\tget");
                output.writeln("\t\t\t{");
                output.writeln("\t\t\t\treturn dal.TablodakiSatirSayisi;");
                output.writeln("\t\t\t}");
                output.writeln("        }");
                output.writeln("");
                output.writeln("    }");
                output.writeln("}");

                string savePath = Path.Combine(SimetriUtils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\Bs\\" + baseNameSpace + ".Bs\\" + schemaName, classNameTypeLibrary + "Bs.generated.cs");
                //output.writeln(savePath);
                output.save(savePath, true);
                output.clear();
            }

        }




    }


