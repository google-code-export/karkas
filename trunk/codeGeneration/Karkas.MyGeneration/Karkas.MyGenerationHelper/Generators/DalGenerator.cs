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
    public class DalGenerator : BaseGenerator
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
        string pkType = "";
        string identityColumnAdi = "";
        bool identityVarmi = false;
        string listeType = "";
        string identityType = "";

        public void Render(IZeusOutput output, ITable table)
        {
            output.tabLevel = 0;
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


            classNameTypeLibrary = utils.GetPascalCase(table.Name);
            schemaName = utils.GetPascalCase(table.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;
            identityVarmi = utils.IdentityVarMi(table);
            bool pkGuidMi = utils.PkGuidMi(table);
            string pkcumlesi = "";

            string baseNameSpaceDal = baseNameSpace + ".Dal." + schemaName;

            pkType = utils.PrimaryKeyTipiniBul(table);
            identityType = utils.IdentityTipiniBul(table);

            listeType = "List<" + classNameTypeLibrary + ">";

            string outputFullFileNameGenerated = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\Dal\\" + baseNameSpace + ".Dal\\" + schemaName, classNameTypeLibrary + "Dal.generated.cs");
            string outputFullFileName = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, table.Schema) + "\\Dal\\" + baseNameSpace + ".Dal\\" + schemaName, classNameTypeLibrary + "Dal.cs");

            UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceDal);

            ClassYaz(output, classNameTypeLibrary, identityVarmi, identityType);

            output.autoTabLn("");

            OverrideDatabaseNameYaz(output, table);

            identityKolonDegeriniSetleYaz(output, table);

            SelectCountYaz(output, table);

            SelectStringYaz(output, table);

            DeleteStringYaz(output, table);

            UpdateStringYaz(output, table, ref pkcumlesi);

            InsertStringYaz(output, table, ref identityVarmi);


            SorgulaPkIleGetirYaz(output, classNameTypeLibrary, pkAdi, pkType);

            IdentityVarMiYaz(output, identityVarmi);

            PkGuidMiYaz(output, table);


            SilKomutuYazPkIle(output, classNameTypeLibrary, table);

            ProcessRowYaz(output, table, classNameTypeLibrary);

            InsertCommandParametersAddYaz(output, table, classNameTypeLibrary);
            UpdateCommandParametersAddYaz(output, table, classNameTypeLibrary);
            DeleteCommandParametersAddYaz(output, table, classNameTypeLibrary);

            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.saveEnc(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
            if (!File.Exists(outputFullFileName))
            {
                UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceDal);
                output.autoTab("public partial class ");
                output.writeln(classNameTypeLibrary + "Dal");

                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.saveEnc(outputFullFileName, "o", "utf8");
                output.clear();

            }


        }

        private void SilKomutuYazPkIle(IZeusOutput output, string classNameTypeLibrary, ITable table)
        {
            string pkPropertyName = utils.getPropertyVariableName(table.Columns[pkAdi]);
            output.autoTabLn(string.Format("public virtual void Sil({0} {1})", pkType, pkPropertyName));
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));
            output.autoTabLn(string.Format("row.{0} = {0};", pkPropertyName));
            output.autoTabLn("base.Sil(row);");
            BitisSusluParentezVeTabAzalt(output);
        }




        private void identityKolonDegeriniSetleYaz(IZeusOutput output, ITable table)
        {
            string methodYazisi = string.Format("protected override void identityKolonDegeriniSetle({0} pTypeLibrary,long pIdentityKolonValue)", classNameTypeLibrary);
            output.autoTabLn(methodYazisi);
            BaslangicSusluParentezVeTabArtir(output);
            if (identityVarmi)
            {
                string propertySetleYazisi = string.Format("pTypeLibrary.{0} = ({1} )pIdentityKolonValue;", utils.GetPascalCase(identityColumnAdi), identityType);
                output.autoTabLn(propertySetleYazisi);
            }
            BitisSusluParentezVeTabAzalt(output);

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


        private void UsingleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibrary, string baseNameSpaceDal)
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
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceDal);
            output.autoTabLn("");
            BaslangicSusluParentezVeTabArtir(output);

        }

        private void ClassYaz(IZeusOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDal<");
            output.write(classNameTypeLibrary);
            output.writeln(">");
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


        private void SelectStringYaz(IZeusOutput output, ITable table)
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
            whereClause = whereClause.Remove(whereClause.Length - 4);


            cumle += "  FROM " + table.Schema + "." + table.Name + " WHERE ";
            output.autoTabLn(cumle + whereClause + "\";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

        private static bool updateWhereSatirindaOlmaliMi(IColumn column)
        {
            return ((column.IsInPrimaryKey) || columnVersiyonZamaniMi(column));
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
                if (updateWhereSatirindaOlmaliMi(column))
                {
                    pkcumlesi += " " + column.Name + " = @" + column.Name + " AND";
                }
                if (!columnParametreOlmaliMi(column))
                {
                    if (!updateWhereSatirindaOlmaliMi(column))
                    {
                        cumle += column.Name + " = @" + column.Name + ",";
                    }
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

        private void IdentityVarMiYaz(IZeusOutput output, bool identityVarmi)
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
        private void PkGuidMiYaz(IZeusOutput output, ITable table)
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

        private void ProcessRowYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            string propertyVariableName = "";
            output.autoTab("protected override void ProcessRow(System.Data.IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                IColumn column = table.Columns[i];
                propertyVariableName = utils.getPropertyVariableName(column);
                string yazi = "row." + propertyVariableName + " = " +
                                utils.GetDataReaderSyntax(column)
                                + "(" + i + ");";
                if (column.IsNullable)
                {
                    output.autoTabLn("if (!dr.IsDBNull(" + i + "))");
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


        private void InsertCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(SqlCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeln(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = new ParameterBuilder(cmd);");

            string paramName = "";
            foreach (IColumn column in table.Columns)
            {
                if (!columnParametreOlmaliMi(column))
                {
                    builderParameterEkle(output, column);
                }
            }

            BitisSusluParentezVeTabAzalt(output);
        }


        private static bool columnParametreOlmaliMi(IColumn column)
        {
            return ((column.IsAutoKey) || (column.IsComputed));
        }

        private static bool columnVersiyonZamaniMi(IColumn column)
        {
            return (column.Name == "VersiyonZamani");
        }

        private void builderParameterEkle(IZeusOutput output, IColumn column)
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

        private void builderParameterEkleString(IZeusOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"@"
                        + column.Name
                        + "\","
                        + column.DbTargetType
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ","
                        + Convert.ToString(column.CharacterMaxLength)
                        + ");";
            output.autoTabLn(s);
        }

        private void builderParameterEkleNormal(IZeusOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"@"
                        + column.Name
                        + "\","
                        + column.DbTargetType
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ");";
            output.autoTabLn(s);
        }

        private void DeleteCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
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

        private void UpdateCommandParametersAddYaz(IZeusOutput output, ITable table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(SqlCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = new ParameterBuilder(cmd);");
            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey || !columnParametreOlmaliMi(column))
                {
                    builderParameterEkle(output, column);
                }
                if (columnVersiyonZamaniMi(column))
                {
                    builderParameterEkle(output, column);
                }
            }
            BitisSusluParentezVeTabAzalt(output);
        }















    }
}

