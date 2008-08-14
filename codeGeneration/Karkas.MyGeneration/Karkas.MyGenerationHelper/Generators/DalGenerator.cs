using System;
using System.Collections;
using System.Text;
using Zeus;
using Zeus.Data;
using Zeus.UserInterface;
using MyMeta;
using Karkas.MyGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Karkas.MyGenerationHelper.Generators
{
    public class DalGenerator
    {
        private static Utils utils = new Utils();

        string classNameTypeLibrary = "";
        string schemaName = "";
        string classNameSpace = "";
        string memberVariableName = "";
        string propertyVariableName = "";
        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";
        string pkAdi = "";
        string identityColumnAdi = "";

        string listeType = "";

        public void Render(IZeusOutput output, ITable table)
        {
            IDatabase database = table.Database;
            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, table.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            pkAdi = utils.PrimaryKeyAdiniBul(table);
            identityColumnAdi = utils.IdentityColumnAdiniBul(table);
            if (pkAdi == "")
            {
                output.autoTabLn("Sectiginiz tablolardan birinde Primary Key yoktur. Code Generation sadace primaryKey'i olan tablolarda duzgun calisir.");
                return;
            }


            classNameTypeLibrary = utils.SetPascalCase(table.Name);
            schemaName = utils.SetPascalCase(table.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;
            bool identityVarmi = utils.IdentityVarMi(table);
            bool pkGuidMi = utils.PkGuidMi(table);
            string pkcumlesi = "";

            string baseNameSpaceDal = baseNameSpace + ".Dal." + schemaName;

            string pkType = utils.PrimaryKeyTipiniBul(table);
            string identityType = utils.IdentityTipiniBul(table);

            listeType = "List<" + classNameTypeLibrary + ">";

            

            UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary);

            ClassYaz(output, classNameTypeLibrary, identityVarmi, baseNameSpaceDal, identityType);

            output.autoTabLn("");

            OverrideDatabaseNameYaz(output, table);

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

            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.save(Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\Dal\\" + baseNameSpace + ".Dal\\" + schemaName, classNameTypeLibrary + "Dal.generated.cs"), false);
            output.clear();


        }


        private void OverrideDatabaseNameYaz(IZeusOutput output, ITable table)
        {
            output.autoTabLn("public override string DatabaseName");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";" , table.Database.Name));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private void UsingleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibrary)
        {
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
            output.autoTabLn("");
            output.autoTabLn("");
        }

        private void ClassYaz(IZeusOutput output, string classNameTypeLibrary, bool identityVarmi, string baseNameSpaceDal, string identityType)
        {
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceDal);
            output.autoTabLn("");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTab("public partial class ");
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
            BaslangicSusluParentezVeTabArtir(output);
        }


        private void SelectCountYaz(IZeusOutput output, ITable table)
        {
            output.autoTabLn("protected override string SelectCountString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            string cumle = "return @\"SELECT COUNT(*) FROM " + table.Schema + "." + table.Name + "\";";
            output.autoTabLn(cumle);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private  void SelectStringYaz(IZeusOutput output, ITable table)
        {
            output.autoTabLn("protected override string SelectString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            string cumle = "return @\"SELECT ";
            foreach (IColumn column in table.Columns)
            {
                cumle += column.Name + ",";
            }
            cumle = cumle.Remove(cumle.Length - 1);
            cumle += " FROM ";
            cumle += table.Schema + "." + table.Name + "\";";
            output.autoTabLn(cumle);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

        private void DeleteStringYaz(IZeusOutput output, ITable table)
        {
            string cumle = "";
            output.autoTabLn("protected override string DeleteString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            cumle += "return @\"DELETE ";

            string whereClause = "";
            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    whereClause += column.Name + " = @" + column.Name + " AND";
                }
            }
            whereClause = whereClause.Remove(cumle.Length - 4);


            cumle += "  FROM " + table.Schema + "." + table.Name + " WHERE ";
            output.autoTabLn(cumle + whereClause + "\";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private void UpdateStringYaz(IZeusOutput output, ITable table, ref string pkcumlesi)
        {
            string cumle = "";
            output.autoTabLn("protected override string UpdateString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("return @\"UPDATE " + table.Schema + "." + table.Name);
            output.autoTabLn(" SET ");
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


            output.autoTab(cumle);
            output.autoTabLn("");
            output.autoTabLn("WHERE ");
            output.autoTabLn(pkcumlesi + "\";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }



        private void InsertStringYaz(IZeusOutput output, ITable table, ref bool identityVarmi)
        {
            string cumle = "";

            output.autoTabLn("protected override string InsertString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("return @\"INSERT INTO " + table.Schema + "." + table.Name + " ");
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
            cumle += ") ";
            output.autoTabLn(cumle);
            output.autoTabLn(" VALUES ");
            cumle = "(";
            output.autoTab("");
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
            output.autoTabLn(cumle + "\";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private  void SorgulaHepsiniGetirYaz(IZeusOutput output, string classNameTypeLibrary)
        {
            output.autoTabLn("public " +  listeType + "SorgulaHepsiniGetir()");
            BaslangicSusluParentezVeTabArtir(output);
            listeTanimla(output);
            output.autoTabLn("SorguCalistir(liste);");
            output.autoTabLn("return liste;");
            BitisSusluParentezVeTabAzalt(output);
        }

        private void listeTanimla(IZeusOutput output)
        {
            output.autoTabLn(listeType + " liste = new " + listeType + "();");
        }

        private void SorgulaPkIleGetirYaz(IZeusOutput output, string classNameTypeLibrary, string pkAdi, string pkType)
        {
            string classSatiri = "public " + classNameTypeLibrary + " Sorgula"
                            + pkAdi + "Ile(" + pkType
                            + " p1)";
            output.autoTabLn(classSatiri);
            BaslangicSusluParentezVeTabArtir(output);
            listeTanimla(output);
            output.autoTab("SorguCalistir(liste,String.Format(\" " + pkAdi + " = '{0}'\", p1));");
            output.autoTabLn("");
            output.autoTabLn("if (liste.Count > 0)");
            output.autoTabLn("{");
            output.autoTabLn("\treturn liste[0];");
            output.autoTabLn("}");
            output.autoTabLn("else");
            output.autoTabLn("{");
            output.autoTabLn("\treturn null;");
            output.autoTabLn("}");
            BitisSusluParentezVeTabAzalt(output);
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

            output.autoTabLn("");
            output.autoTabLn("protected override bool IdentityVarMi");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("return " + identitySonuc + ";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }
        private static void PkGuidMiYaz(IZeusOutput output, ITable table)
        {
            string pkGuidMiSonuc = "";
            if (utils.PkGuidMi(table))
            {
                pkGuidMiSonuc = "true";
            }
            else
            {
                pkGuidMiSonuc = "false";
            }


            output.autoTabLn("");
            output.autoTabLn("protected override bool PkGuidMi");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("return " + pkGuidMiSonuc + ";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
            output.autoTabLn("");
        }

        private static void ProcessRowYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            string propertyVariableName = "";
            output.autoTab("protected override void ProcessRow(System.Data.IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                IColumn column = table.Columns[i];
                propertyVariableName = utils.SetPascalCase(column.Name);
                string yazi = "row." + propertyVariableName + " = " +
                                utils.GetDataReaderSyntax(column)
                                + "(" + i + ");";
                if (column.IsNullable)
                {
                    output.autoTabLn("if (!dr.IsDBNull("  + i + "))");
                    BaslangicSusluParentezVeTabArtir(output);
                    output.autoTabLn(yazi);
                    BitisSusluParentezVeTabAzalt(output);
                }
                else
                {
                    output.autoTabLn(yazi);
                }
            }
            BitisSusluParentezVeTabAzalt(output);
        }

        private static void BaslangicSusluParentezVeTabArtir(IZeusOutput output)
        {
            output.autoTabLn("{");
            output.incTab();
        }
        private static void BitisSusluParentezVeTabAzalt(IZeusOutput output)
        {
            output.decTab();
            output.autoTabLn("}");
        }

        private static void InsertCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(SqlCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = new ParameterBuilder(cmd);");

            string paramName = "";
            foreach (IColumn column in table.Columns)
            {
                if (!column.IsAutoKey)
                {
                    builderParameterEkle(output, column);
                }
            }

            BitisSusluParentezVeTabAzalt(output);
        }

        private static void builderParameterEkle(IZeusOutput output, IColumn column)
        {
            if (column.CharacterMaxLength == 0)
            {
                builderParameterEkleNormal(output, column);

            }
            else
            {
                builderParameterEkleString(output, column);
            }
        }

        private static void builderParameterEkleString(IZeusOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"@"
                        + column.Name
                        + "\","
                        + column.DbTargetType
                        + ", row."
                        + utils.SetPascalCase(column.Name)
                        + ","
                        + Convert.ToString(column.CharacterMaxLength)
                        + ");";
            output.autoTabLn(s);
        }

        private static void builderParameterEkleNormal(IZeusOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"@"
                        + column.Name
                        + "\","
                        + column.DbTargetType
                        + ", row."
                        + utils.SetPascalCase(column.Name)
                        + ");";
            output.autoTabLn(s);
        }

        private static void DeleteCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void DeleteCommandParametersAdd(SqlCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = new ParameterBuilder(cmd);");

            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    builderParameterEkle(output, column);
                }
            }

            BitisSusluParentezVeTabAzalt(output);
        }

        private static void UpdateCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(SqlCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = new ParameterBuilder(cmd);");
            foreach (IColumn column in table.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                builderParameterEkle(output, column);
            }
            BitisSusluParentezVeTabAzalt(output);
        }















    }
}
