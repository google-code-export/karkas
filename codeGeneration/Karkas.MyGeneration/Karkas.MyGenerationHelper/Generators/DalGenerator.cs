using System;
using System.Collections;
using System.Text;
using Zeus;
using Zeus.Data;
using Zeus.UserInterface;
using MyMeta;
using Simetri.MyGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Simetri.MyGenerationHelper.Generators
{
    public class DalGenerator
    {
        private static Utils SimetriUtils = new Utils();
        public void Render(IZeusOutput output, ITable table)
        {
            string classNameTypeLibrary = "";
            string schemaName = "";
            string classNameSpace = "";
            string memberVariableName = "";
            string propertyVariableName = "";
            string baseNameSpace = "";
            string baseNameSpaceTypeLibrary = "";

            IDatabase database = table.Database;

            baseNameSpace = SimetriUtils.NamespaceIniAlSchemaIle(database, table.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string pkAdi = SimetriUtils.PrimaryKeyAdiniBul(table);
            string identityColumnAdi = SimetriUtils.IdentityColumnAdiniBul(table);
            if (pkAdi == "")
            {
                output.writeln("Sectiginiz tablolardan birinde Primary Key yoktur. Code Generation sadace primaryKey'i olan tablolarda duzgun calisir.");
                return;
            }


            classNameTypeLibrary = SimetriUtils.SetPascalCase(table.Name);
            schemaName = SimetriUtils.SetPascalCase(table.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;
            bool identityVarmi = SimetriUtils.IdentityVarMi(table);
            bool pkGuidMi = SimetriUtils.PkGuidMi(table);
            string pkcumlesi = "";

            string baseNameSpaceDal = baseNameSpace + ".Dal." + schemaName;

            string pkType = SimetriUtils.PrimaryKeyTipiniBul(table);
            string identityType = SimetriUtils.IdentityTipiniBul(table);


            UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary);

            ClassYaz(output, classNameTypeLibrary, identityVarmi, baseNameSpaceDal, identityType);

            output.writeln("");

            SelectCountYaz(output, table);

            SelectStringYaz(output, table);

            DeleteStringYaz(output, table);

            UpdateStringYaz(output, table, ref pkcumlesi);

            InsertStringYaz(output, table, ref identityVarmi);


            SorgulaHepsiniGetirYaz(output, classNameTypeLibrary);

            SorgulaPkIleGetirYaz(output, classNameTypeLibrary, pkAdi, pkType);

            IdentityVarMiYaz(output, identityVarmi);

            PkGuidMiYaz(output, table);



            ProcessRowYaz(output, table, classNameTypeLibrary);

            InsertCommandParametersAddYaz(output, table, classNameTypeLibrary);
            UpdateCommandParametersAddYaz(output, table, classNameTypeLibrary);
            DeleteCommandParametersAddYaz(output, table, classNameTypeLibrary);

            output.writeln("");
            output.writeln("");
            output.writeln("");
            output.writeln("    }");
            output.writeln("}");

            //			output.writeln(className);
            output.save(Path.Combine(SimetriUtils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\Dal\\" + baseNameSpace + ".Dal\\" + schemaName, classNameTypeLibrary + "Dal.generated.cs"), false);
            output.clear();


        }

        private static void DeleteCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.write("        protected override void DeleteCommandParametersAdd(SqlCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            output.writeln("        {");
            output.write("\t\t\tParameterBuilder builder = new ParameterBuilder(cmd);");

            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    if (column.CharacterMaxLength == 0)
                    {
                        output.writeln("");
                        output.write("\t\t\tbuilder.parameterEkle(\"@");
                        output.write(column.Name);
                        output.write("\",");
                        output.write(column.DbTargetType);
                        output.write(", row.");
                        output.write(SimetriUtils.SetPascalCase(column.Name));
                        output.write(");");

                    }
                    else
                    {
                        output.writeln("");
                        output.write("\t\t\tbuilder.parameterEkle(\"@");
                        output.write(column.Name);
                        output.write("\",");
                        output.write(column.DbTargetType);
                        output.write(", row.");
                        output.write(SimetriUtils.SetPascalCase(column.Name));
                        output.write(",");
                        output.write(Convert.ToString(column.CharacterMaxLength));
                        output.write(");");

                    }
                }
            }

            output.writeln("");
            output.writeln("        }");
        }

        private static void UpdateCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.write("        protected override void UpdateCommandParametersAdd(SqlCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            output.writeln("        {");
            output.write("\t\t\tParameterBuilder builder = new ParameterBuilder(cmd);");

            foreach (IColumn column in table.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                if (column.CharacterMaxLength == 0)
                {
                    output.writeln("");
                    output.write("\t\t\tbuilder.parameterEkle(\"@");
                    output.write(column.Name);
                    output.write("\",");
                    output.write(column.DbTargetType);
                    output.write(", row.");
                    output.write(SimetriUtils.SetPascalCase(column.Name));
                    output.write(");");

                }
                else
                {
                    output.writeln("");
                    output.write("\t\t\tbuilder.parameterEkle(\"@");
                    output.write(column.Name);
                    output.write("\",");
                    output.write(column.DbTargetType);
                    output.write(", row.");
                    output.write(SimetriUtils.SetPascalCase(column.Name));
                    output.write(",");
                    output.write(Convert.ToString(column.CharacterMaxLength));
                    output.write(");");

                }
            }

            output.writeln("");
            output.writeln("        }");
        }

        private static void InsertCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.write("        protected override void InsertCommandParametersAdd(SqlCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            output.writeln("        {");
            output.writeln("\t\t\tParameterBuilder builder = new ParameterBuilder(cmd);");

            string paramName = "";
            foreach (IColumn column in table.Columns)
            {
                if (!column.IsAutoKey)
                {
                    if (column.IsComputed)
                    {
                        continue;
                    }
                    if (column.CharacterMaxLength == 0)
                    {
                        output.writeln("");
                        output.write("\t\t\tbuilder.parameterEkle(\"@");
                        output.write(column.Name);
                        output.write("\",");
                        output.write(column.DbTargetType);
                        output.write(", row.");
                        output.write(SimetriUtils.SetPascalCase(column.Name));
                        output.write(");");

                    }
                    else
                    {
                        output.writeln("");
                        output.write("\t\t\tbuilder.parameterEkle(\"@");
                        output.write(column.Name);
                        output.write("\",");
                        output.write(column.DbTargetType);
                        output.write(", row.");
                        output.write(SimetriUtils.SetPascalCase(column.Name));
                        output.write(",");
                        output.write(Convert.ToString(column.CharacterMaxLength));
                        output.write(");");

                    }
                }
            }

            output.writeln("");
            output.writeln("        }");
        }

        private static string ProcessRowYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            string propertyVariableName = "";
            output.write("        protected override void ProcessRow(System.Data.IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            output.writeln("        {");
            output.write("\t\t");


            for (int i = 0; i < table.Columns.Count; i++)
            {
                IColumn column = table.Columns[i];
                propertyVariableName = SimetriUtils.SetPascalCase(column.Name);
                if (column.IsNullable)
                {
                    output.writeln("");
                    output.write("\t\t\t\t\tif (!dr.IsDBNull(");
                    output.write("" + i);
                    output.writeln("))");
                    output.writeln("\t\t\t\t\t{");
                    output.write("\t\t\t\t\t\trow.");
                    output.write(propertyVariableName);
                    output.write(" = ");
                    output.write(SimetriUtils.GetDataReaderSyntax(column));
                    output.write("(");
                    output.write(i.ToString());
                    output.writeln(");");
                    output.writeln("\t\t\t\t\t}");
                    output.write("\t\t\t\t\t");
                }
                else
                {

                    output.writeln("");
                    output.write("\t\t\t\t\trow.");
                    output.write(propertyVariableName);
                    output.write(" = ");
                    output.write(SimetriUtils.GetDataReaderSyntax(column));
                    output.write("(");
                    output.write(i.ToString());
                    output.write(");");

                }
            }

            output.writeln("\t\t");
            output.writeln("        }");
            return propertyVariableName;
        }

        private static void PkGuidMiYaz(IZeusOutput output, ITable table)
        {
            string pkGuidMiSonuc = "";
            if (SimetriUtils.PkGuidMi(table))
            {
                pkGuidMiSonuc = "true";
            }
            else
            {
                pkGuidMiSonuc = "false";
            }


            output.writeln(" ");
            output.writeln("        protected override bool PkGuidMi");
            output.writeln("        {");
            output.writeln("            get");
            output.writeln("            {");
            output.write("                return ");
            output.write(pkGuidMiSonuc);
            output.writeln(";");
            output.writeln("            }");
            output.writeln("        }");
            output.writeln("");
            output.writeln("\t\t");
        }

        private static void IdentityVarMiYaz(IZeusOutput output, bool identityVarmi)
        {
            string identitySonuc = "";
            if (identityVarmi)
            {
                identitySonuc = "true";
            }
            else
            {
                identitySonuc = "false";
            }

            output.writeln(" ");
            output.writeln("        protected override bool IdentityVarMi");
            output.writeln("        {");
            output.writeln("            get");
            output.writeln("            {");
            output.write("                return ");
            output.write(identitySonuc);
            output.writeln(";");
            output.writeln("            }");
            output.writeln("        }");
            output.writeln("");
            output.writeln("\t\t");
        }

        private static void SorgulaPkIleGetirYaz(IZeusOutput output, string classNameTypeLibrary, string pkAdi, string pkType)
        {
            output.write("\t\tpublic ");
            output.write(classNameTypeLibrary);
            output.write(" Sorgula");
            output.write(pkAdi);
            output.write("Ile(");
            output.write(pkType);
            output.writeln(" p1)");
            output.writeln("\t\t{");
            output.write("\t\t\tList<");
            output.write(classNameTypeLibrary);
            output.write("> liste = new List<");
            output.write(classNameTypeLibrary);
            output.writeln(">();");
            output.write("\t\t\tSorguCalistir(liste,String.Format(\" ");
            output.write(pkAdi);
            output.writeln(" = '{0}'\", p1));");
            output.writeln("");
            output.writeln("            if (liste.Count > 0)");
            output.writeln("            {");
            output.writeln("                return liste[0];");
            output.writeln("            }");
            output.writeln("            else");
            output.writeln("            {");
            output.writeln("                return null;");
            output.writeln("            }");
            output.writeln("\t\t}");
        }

        private static void SorgulaHepsiniGetirYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.write("\t\tpublic List<");
            output.write(classNameTypeLibrary);
            output.writeln("> SorgulaHepsiniGetir()");
            output.writeln("\t\t{");
            output.write("\t\t\tList<");
            output.write(classNameTypeLibrary);
            output.write("> liste = new List<");
            output.write(classNameTypeLibrary);
            output.writeln(">();");
            output.writeln("\t\t\tSorguCalistir(liste);");
            output.writeln("            return liste;");
            output.writeln("\t\t}");
        }

        private static string DeleteStringYaz(IZeusOutput output, ITable table)
        {
            string cumle = "";
            output.writeln("        protected override string DeleteString");
            output.writeln("        {");
            output.writeln("            get ");
            output.writeln("\t\t\t{ ");
            output.write("\t\t\t\treturn @\"DELETE ");

            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    cumle += column.Name + " = @" + column.Name + " AND";
                }
            }
            cumle = cumle.Remove(cumle.Length - 4);


            output.write("  FROM ");
            output.write(table.Schema);
            output.write(".");
            output.write(table.Name);
            output.write(" WHERE ");
            output.write(cumle);
            output.writeln("\";");
            output.writeln("\t\t\t}");
            output.writeln("        }");
            return cumle;
        }

        private static void SelectStringYaz(IZeusOutput output, ITable table)
        {
            output.writeln("        protected override string SelectString");
            output.writeln("        {");
            output.writeln("            get ");
            output.writeln("\t\t\t{ ");
            output.write("\t\t\t\treturn @\"SELECT ");

            string cumle = "";
            foreach (IColumn column in table.Columns)
            {
                cumle += column.Name + ",";
            }
            cumle = cumle.Remove(cumle.Length - 1);


            output.write(" ");
            output.write(cumle);
            output.write(" FROM ");
            output.write(table.Schema);
            output.write(".");
            output.write(table.Name);
            output.writeln("\";");
            output.writeln("\t\t\t}");
            output.writeln("        }");
            output.writeln("");
        }

        private static void SelectCountYaz(IZeusOutput output, ITable table)
        {
            output.writeln("        protected override string SelectCountString");
            output.writeln("        {");
            output.writeln("            get ");
            output.writeln("\t\t\t{ ");
            output.write("\t\t\t\treturn @\"SELECT COUNT(*) FROM ");
            output.write(table.Schema);
            output.write(".");
            output.write(table.Name);
            output.writeln("\";");
            output.writeln("\t\t\t}");
            output.writeln("\t\t}");
            output.writeln("");
        }

        private static void ClassYaz(IZeusOutput output, string classNameTypeLibrary, bool identityVarmi, string baseNameSpaceDal, string identityType)
        {
            output.write("namespace ");
            output.write(baseNameSpaceDal);
            output.writeln("");
            output.writeln("{");
            output.write("    public partial class ");
            output.write(classNameTypeLibrary);
            if (identityVarmi)
            {
                output.write("Dal : BaseDalForIdentity<");
                output.write(classNameTypeLibrary);
                output.write(",");
                output.write(identityType);
                output.writeln(">");
            }
            else
            {
                output.write("Dal : BaseDal<");
                output.write(classNameTypeLibrary);
                output.writeln(">");
            }
            output.writeln("    {");
        }

        private static void UsingleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibrary)
        {
            output.writeln("using System;");
            output.writeln("using System.Collections.Generic;");
            output.writeln("using System.Data;");
            output.writeln("using System.Data.SqlClient;");
            output.writeln("using System.Text;");
            output.writeln("using Simetri.Core.DataUtil;");
            output.write("using ");
            output.write(baseNameSpaceTypeLibrary);
            output.writeln(";");
            output.write("using ");
            output.write(baseNameSpaceTypeLibrary);
            output.write(".");
            output.write(schemaName);
            output.writeln(";");
            output.writeln("");
            output.writeln("");
        }

        private static void InsertStringYaz(IZeusOutput output, ITable table, ref bool identityVarmi)
        {
            string cumle = "";

            output.writeln("       protected override string InsertString");
            output.writeln("        {");
            output.writeln("            get ");
            output.writeln("\t\t\t{ ");
            output.write("\t\t\t\treturn @\"INSERT INTO ");
            output.write(table.Schema);
            output.write(".");
            output.write(table.Name);
            output.write(" ");

            cumle += " (";
            identityVarmi = false;
            foreach (IColumn column in table.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                if (!column.IsAutoKey)
                {
                    cumle += column.Name + ",";
                }
                else
                {
                    identityVarmi = true;
                }

            }
            cumle = cumle.Remove(cumle.Length - 1);
            cumle += ") VALUES (";

            output.writeln("");
            output.write("\t\t\t\t");

            foreach (IColumn column in table.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                if (!column.IsAutoKey)
                {
                    cumle += "@" + column.Name + ",";
                }
            }
            cumle = cumle.Remove(cumle.Length - 1);
            cumle += ")";
            if (identityVarmi)
            {
                cumle += ";SELECT scope_identity();";
            }

            output.write("  ");
            output.write(cumle);
            output.writeln("\";");
            output.writeln("\t\t\t}");
            output.writeln("        }");
        }

        private static void UpdateStringYaz(IZeusOutput output, ITable table, ref string pkcumlesi)
        {
            string cumle = "";
            output.writeln("        protected override string UpdateString");
            output.writeln("        {");
            output.writeln("            get ");
            output.writeln("\t\t\t{ ");
            output.write("\t\t\t\treturn @\"UPDATE ");
            output.write(table.Schema);
            output.write(".");
            output.write(table.Name);

            foreach (IColumn column in table.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                if (column.IsInPrimaryKey)
                {
                    pkcumlesi += column.Name + " = @" + column.Name + " AND";
                }
                else
                {
                    cumle += column.Name + " = @" + column.Name + ",";
                }
            }
            if (cumle.Length > 0)
            {
                cumle = cumle.Remove(cumle.Length - 1);
            }
            if (pkcumlesi.Length > 0)
            {
                pkcumlesi = pkcumlesi.Remove(pkcumlesi.Length - 3);
            }


            output.writeln(" SET ");
            output.write("\t\t\t\t");
            output.write(cumle);
            output.writeln("");
            output.write("\t\t\t\tWHERE ");
            output.write(pkcumlesi);
            output.writeln("\";");
            output.writeln("\t\t\t}");
            output.writeln("        }");
            output.writeln("");
        }




    }

    //-- Class DotNetScriptTemplate Generated by Zeus
}
