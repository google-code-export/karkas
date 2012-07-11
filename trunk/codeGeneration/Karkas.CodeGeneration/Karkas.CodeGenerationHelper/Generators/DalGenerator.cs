using System;
using System.Collections;
using System.Text;
using Karkas.CodeGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper.Generators
{
    public abstract class DalGenerator : BaseGenerator
    {

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

        public DalGenerator(IDatabaseHelper databaseHelper)
        {
            utils = new Utils(databaseHelper);

        }
        Utils utils = null;



        public string Render(IOutput output, IContainer container)
        {
            output.tabLevel = 0;
            IDatabase database = container.Database;
            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, container.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            pkAdi = utils.PrimaryKeyAdiniBul(container);
            identityColumnAdi = utils.IdentityColumnAdiniBul(container);
            
            if (container is ITable && (!((ITable) container).HasPrimaryKey ))
            {
                string uyari = 
                 "Sectiginiz tablolardan " + container.Name  + " icinde Primary Key yoktur. Code Generation (DAL) sadace primaryKey'i olan tablolarda duzgun calisir.";
                throw new Exception(uyari);
            }


            classNameTypeLibrary = utils.GetPascalCase(container.Name);
            schemaName = utils.GetPascalCase(container.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;
            identityVarmi = utils.IdentityVarMi(container);
            bool pkGuidMi = utils.PkGuidMi(container);
            string pkcumlesi = "";

            string baseNameSpaceDal = baseNameSpace + ".Dal." + schemaName;

            pkType = utils.PrimaryKeyTipiniBul(container);
            identityType = utils.IdentityTipiniBul(container);

            listeType = "List<" + classNameTypeLibrary + ">";

            string outputFullFileNameGenerated = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, container.Schema) + "\\Dal\\" + baseNameSpace + ".Dal\\" + schemaName, classNameTypeLibrary + "Dal.generated.cs");
            string outputFullFileName = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, container.Schema) + "\\Dal\\" + baseNameSpace + ".Dal\\" + schemaName, classNameTypeLibrary + "Dal.cs");

            UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceDal);

            ClassYaz(output, classNameTypeLibrary, identityVarmi, identityType);

            output.autoTabLn("");

            OverrideDatabaseNameYaz(output, container);

            identityKolonDegeriniSetleYaz(output, container);

            SelectCountYaz(output, container);

            SelectStringYaz(output, container);

            DeleteStringYaz(output, container);

            UpdateStringYaz(output, container, ref pkcumlesi);

            InsertStringYaz(output, container, ref identityVarmi);


            SorgulaPkIleGetirYaz(output, classNameTypeLibrary, pkAdi, pkType);

            IdentityVarMiYaz(output, identityVarmi);

            PkGuidMiYaz(output, container);

            PrimaryKeyYaz(output, container);

            SilKomutuYazPkIle(output, classNameTypeLibrary, container);

            ProcessRowYaz(output, container, classNameTypeLibrary);

            InsertCommandParametersAddYaz(output, container, classNameTypeLibrary);
            UpdateCommandParametersAddYaz(output, container, classNameTypeLibrary);
            DeleteCommandParametersAddYaz(output, container, classNameTypeLibrary);

            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
            if (!File.Exists(outputFullFileName))
            {
                UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceDal);
                output.autoTab("public partial class ");
                output.writeLine(classNameTypeLibrary + "Dal");
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.saveEncoding(outputFullFileName, "o", "utf8");
                output.clear();

            }
            return "";


        }

        private void PrimaryKeyYaz(IOutput output, IContainer table)
        {
            output.autoTabLn("");
            output.autoTabLn("public override string PrimaryKey");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";", pkAdi));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
            output.autoTabLn("");

        }



        private void SilKomutuYazPkIle(IOutput output, string classNameTypeLibrary, IContainer container)
        {
            ITable table = container as ITable;
            if (table != null )
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.PrimaryKeyColumnTekIseBul(container);
                    string pkPropertyName = utils.getPropertyVariableName(pkColumn);
                    output.autoTabLn(string.Format("public virtual void Sil({0} {1})", pkType, pkPropertyName));
                    BaslangicSusluParentezVeTabArtir(output);
                    output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));
                    output.autoTabLn(string.Format("row.{0} = {0};", pkPropertyName));
                    output.autoTabLn("base.Sil(row);");
                    BitisSusluParentezVeTabAzalt(output);
                }
            }
        }




        private void identityKolonDegeriniSetleYaz(IOutput output, IContainer table)
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


        private void OverrideDatabaseNameYaz(IOutput output, IContainer table)
        {
            output.autoTabLn("public override string DatabaseName");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";", table.Database.Name));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private void UsingleriYaz(IOutput output, string schemaName, string baseNameSpaceTypeLibrary, string baseNameSpaceDal)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.Common;");
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

        private void ClassYaz(IOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDal<");
            output.write(classNameTypeLibrary);
            output.writeLine(">");
            BaslangicSusluParentezVeTabArtir(output);
        }


        private void SelectCountYaz(IOutput output, IContainer table)
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


        private void SelectStringYaz(IOutput output, IContainer table)
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

        private void DeleteStringYaz(IOutput output, IContainer container)
        {
            string cumle = "";
            output.autoTabLn("protected override string DeleteString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            cumle += "return @\"DELETE ";

            string whereClause = "";

            if (container is ITable)
            {
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsInPrimaryKey)
                    {
                        whereClause += column.Name + " = " + parameterSymbol + column.Name + " AND";
                    }
                }
                whereClause = whereClause.Remove(whereClause.Length - 4) + "\"";
                cumle += "  FROM " + container.Schema + "." + container.Name + " WHERE ";
            }
            else
            {

                cumle = "throw new NotSupportedException(\"VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir\")";
            }

            output.autoTabLn(cumle + whereClause + ";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

        private static bool updateWhereSatirindaOlmaliMi(IColumn column)
        {
            return ((column.IsInPrimaryKey) || columnVersiyonZamaniMi(column));
        }


        protected abstract string parameterSymbol
        {
            get;
        }


        private void UpdateStringYaz(IOutput output, IContainer container, ref string pkcumlesi)
        {
            string cumle = "";
            output.autoTabLn("protected override string UpdateString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            if (container is ITable)
            {
                output.autoTabLn("return @\"UPDATE " + container.Schema + "." + container.Name);
                output.autoTabLn(" SET ");

                foreach (IColumn column in container.Columns)
                {
                    if (updateWhereSatirindaOlmaliMi(column))
                    {
                        pkcumlesi += " " + column.Name + " = " + parameterSymbol + column.Name + " AND";
                    }
                    if (!columnParametreOlmaliMi(column))
                    {
                        if (!updateWhereSatirindaOlmaliMi(column))
                        {
                            cumle += column.Name + " = " + parameterSymbol + column.Name + ",";
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
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\"VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir\");");
            }
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }



        private void InsertStringYaz(IOutput output, IContainer container, ref bool identityVarmi)
        {
            string cumle = "";

            output.autoTabLn("protected override string InsertString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            if (container is ITable)
            {
                output.autoTabLn("return @\"INSERT INTO " + container.Schema + "." + container.Name + " ");
                cumle += " (";
                identityVarmi = false;
                foreach (IColumn column in container.Columns)
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
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsComputed)
                    {
                        continue;
                    }
                    if (!column.IsAutoKey)
                    {
                        cumle += parameterSymbol  + column.Name + ",";
                    }
                }
                cumle = cumle.Remove(cumle.Length - 1);
                cumle += ")";
                if (identityVarmi)
                {
                    cumle += ";SELECT scope_identity();";
                }
                output.autoTabLn(cumle + "\";");
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\"VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir\");");
            }
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private void listeTanimla(IOutput output)
        {
            output.autoTabLn(listeType + " liste = new " + listeType + "();");
        }

        private void SorgulaPkIleGetirYaz(IOutput output, string classNameTypeLibrary, string pkAdi, string pkType)
        {
            if (!string.IsNullOrEmpty(pkAdi))
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
        }

        private void IdentityVarMiYaz(IOutput output, bool identityVarmi)
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
        private void PkGuidMiYaz(IOutput output, IContainer table)
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

        private void ProcessRowYaz(IOutput output, IContainer table, string classNameTypeLibrary)
        {
            string propertyVariableName = "";
            output.autoTab("protected override void ProcessRow(IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" row)");
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


        private void InsertCommandParametersAddYaz(IOutput output, IContainer table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" row)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = new ParameterBuilder(cmd);");

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

        private void builderParameterEkle(IOutput output, IColumn column)
        {
            if (!column.isStringTypeWithoutLength && column.isStringType)
            {
                builderParameterEkleString(output, column);

            }
            else
            {
                builderParameterEkleNormal(output, column);
            }
        }

        private void builderParameterEkleString(IOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ","
                        + Convert.ToString(column.CharacterMaxLength)
                        + ");";
            output.autoTabLn(s);
        }

        private string getDbTargetType(IColumn column)
        {
            if (column.DbTargetType == "Unknown")
            {
                return "SqlDbType.VarChar";
            }
            else
            {
                return column.DbTargetType;
            }
        }

        private void builderParameterEkleNormal(IOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ");";
            output.autoTabLn(s);
        }

        private void DeleteCommandParametersAddYaz(IOutput output, IContainer table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void DeleteCommandParametersAdd(DbCommand cmd, ");
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

        private void UpdateCommandParametersAddYaz(IOutput output, IContainer table, string classNameTypeLibrary)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
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

