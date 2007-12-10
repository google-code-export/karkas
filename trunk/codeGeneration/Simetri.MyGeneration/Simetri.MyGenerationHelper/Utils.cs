using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MyMeta;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Simetri.MyGenerationHelper.Generators;
using Zeus;
using System.IO;

namespace Simetri.MyGenerationHelper
{
    public class Utils
    {
        #region Generator Helper Fonksiyonlari

		public void RenderDatabaseTablesCode(IZeusOutput output,ITable table,string connectionString)
        {
            output.writeln(GetTableDescription(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\CreateScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".CreateTable.sql"), false);
            output.clear();
            output.writeln(GetTableRelationDescriptions(table.Database.Name, table.Schema, table.Name, connectionString));
            output.save(Path.Combine(DizininiAlDatabaseVeSchemaIle(table.Database, table.Schema) + "\\Database\\CreateRelationScripts\\" + table.Schema, table.Schema + "_" + table.Name + ".Relations.sql"), false);
            output.clear();
            
        }

        public void RenderTypeLibraryCode(IZeusOutput output, ITable table)
        {
            TypeLibraryGenerator gen = new TypeLibraryGenerator();
            gen.Render(output, table);
        }
        public void RenderTypeLibraryCode(IZeusOutput output, IView view)
        {
            TypeLibraryGenerator gen = new TypeLibraryGenerator();
            gen.RenderTypeLibraryCode(output, view);
        }
        public void RenderDalCode(IZeusOutput output, ITable table)
        {
            DalGenerator gen = new DalGenerator();
            gen.Render(output, table);
        }
        public void RenderBsCode(IZeusOutput output, ITable table)
        {
            BsGenerator gen = new BsGenerator();
            gen.Render(output, table);
        }
        public void RenderBsWrapperCode(IZeusOutput output, ITable table)
        {
            BsWrapperGenerator gen = new BsWrapperGenerator();
            gen.Render(output, table);
        }



        #endregion


        #region "Parser Helper Fonksiyonlari"
        SimetriXmlParser parser = new SimetriXmlParser();

        public string ProjeNamespaceIsminiAl(IDatabase database)
        {
            return parser.ProjeNamespaceIsminiAl(database);
        }
        public string ProjeDizininiAl(IDatabase database)
        {
            return parser.ProjeDizininiAl(database);
        }



        public string DizininiAlDatabaseVeSchemaIle(IDatabase database, string schemaName)
        {
            return parser.DizininiAlDatabaseVeSchemaIle(database, schemaName);
        }
        public string NamespaceIniAlSchemaIle(IDatabase database, string schemaName)
        {
            return parser.NamespaceIniAlSchemaIle(database, schemaName);
        }


#endregion


        #region "SMO Helper Fonksiyonlari"
        SimetriSmoHelper smoHelper = new SimetriSmoHelper();
        public string GetTableRelationDescriptions(string pDatabaseName, string pSchemaName, string pTableName,string pConnectionString)
        {
            return smoHelper.GetTableRelationDescriptions(pDatabaseName, pSchemaName, pTableName, pConnectionString);
        }
        public string GetTableDescription(string pDatabaseName, string pSchemaName, string pTableName,string pConnectionString)
        {
            return smoHelper.GetTableDescription(pDatabaseName, pSchemaName, pTableName, pConnectionString);
        }

        #endregion


        public void deneme()
        {
            SqlDataReader reader;
            //reader.GetInt16();
            //reader.GetInt64
        }
        public string IdentityColumnAdiniBul(ITable table)
        {
            string adi = "";
            foreach (IColumn column in table.Columns)
            {
                if (column.IsAutoKey)
                {
                    adi = column.Name;
                }
            }
            return adi;
        }

        public string PrimaryKeyAdiniBul(ITable table)
        {
            string adi = "";
            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    adi = column.Name;
                }
            }
            return adi;
        }

        public string PrimaryKeyTipiniBul(ITable table)
        {
            string tip = "";
            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    tip = column.LanguageType;
                }
            }
            return tip;
        }
        public string IdentityTipiniBul(ITable table)
        {
            string tip = "";
            foreach (IColumn column in table.Columns)
            {
                if (column.IsAutoKey)
                {
                    tip = column.LanguageType;
                }
            }
            return tip;
        }
        public bool IdentityVarMi(ITable table)
        {
            bool sonuc = false;
            foreach (IColumn column in table.Columns)
            {
                if (column.IsAutoKey)
                {
                    sonuc = true;
                }
            }
            return sonuc;
        }

        public string IdentityVarMiAsString(ITable table)
        {
            string sonuc = "false";
            foreach (IColumn column in table.Columns)
            {
                if (column.IsAutoKey)
                {
                    sonuc = "true";
                }
            }
            return sonuc;
        }

        public string GetCSharpTypeFromDotNetType(string pDotNetType)
        {
            string sonuc = "";
            switch (pDotNetType)
            {
                case "System.Int16":
                    sonuc = "short";
                    break;

                case "System.Int32":
                    sonuc = "int";
                    break;
                case "System.Int64":
                    sonuc = "long";
                    break;
                case "System.Byte":
                    sonuc = "byte";
                    break;
            }
            return sonuc;
        }

        public string GetDataReaderSyntax(IColumn column)
        {
            //            return column.LanguageType;
            if (column.LanguageType == "Guid")
            {
                return "dr.GetGuid";
            }
            else if (column.LanguageType == "int")
            {
                return "dr.GetInt32";
            }
            else if (column.LanguageType == "byte")
            {
                return "dr.GetByte";
            }
            else if (column.LanguageType == "bool")
            {
                return "dr.GetBoolean";
            }
            else if (column.LanguageType == "DateTime")
            {
                return "dr.GetDateTime";
            }
            else if (column.LanguageType == "string")
            {
                return "dr.GetString";
            }
            else if (column.LanguageType == "short")
            {
                return "dr.GetInt16";
            }
            else if (column.LanguageType == "long")
            {
                return "dr.GetInt64";
            }
            else if (column.LanguageType == "decimal")
            {
                return "dr.GetDecimal";
            }
            else if (column.LanguageType == "byte[]")
            {
                return "(Byte[])dr.GetValue";
            }



            return column.LanguageType;
        }


        
        public ITables filterListAccordingToSchemaName(ITables tableList, string schemaName)
        {
            ITables newList = new MyMeta.Sql.SqlTables();

            foreach (ITable t in tableList)
            {
                if (t.Schema.Equals(schemaName, StringComparison.InvariantCultureIgnoreCase))
                {
                    newList.Add(t);
                }
            }

            return newList;

        }

        public string SetCamelCase(string name)
        {
            string text = "";
            bool flag = false;
            bool flag2 = true;
            bool flag3 = true;
            foreach (char ch in name)
            {
                if (char.IsLower(ch))
                {
                    flag3 = false;
                    break;
                }
            }
            foreach (char ch2 in name)
            {
                switch (ch2)
                {
                    case ' ':
                        if (!flag2)
                        {
                            flag = true;
                        }
                        break;

                    case '.':
                        if (!flag2)
                        {
                            flag = true;
                        }
                        break;

                    case '_':
                        if (!flag2)
                        {
                            flag = true;
                        }
                        break;

                    default:
                        if (flag)
                        {
                            text = text + ch2.ToString().ToUpperInvariant();
                            flag = false;
                        }
                        else if (flag2)
                        {
                            text = text + ch2.ToString().ToLowerInvariant();
                            flag2 = false;
                        }
                        else if (flag3)
                        {
                            text = text + ch2.ToString().ToLowerInvariant();
                        }
                        else
                        {
                            text = text + ch2.ToString();
                        }
                        break;
                }
            }
            return text;
        }

        public const char degisicekChar = '_';
        private string kotuKarakterlerdenAyir(string name)
        {
            name = name.Replace('-',degisicekChar );
            name = name.Replace('(', degisicekChar);
            name = name.Replace(')', degisicekChar);
            name = name.Replace('/',degisicekChar);
            return name;
        }

        public string SetPascalCase(string name)
        {
            name = kotuKarakterlerdenAyir(name);
            string text = "";
            bool flag = true;
            bool flag2 = true;
            foreach (char ch in name)
            {
                if (char.IsLower(ch))
                {
                    flag2 = false;
                    break;
                }
            }
            foreach (char ch2 in name)
            {
                switch (ch2)
                {
                    case ' ':
                        flag = true;
                        break;

                    case '.':
                        flag = true;
                        break;

                    case '_':
                        flag = true;
                        break;

                    default:
                        if (flag)
                        {
                            text = text + ch2.ToString().ToUpperInvariant();
                            flag = false;
                        }
                        else if (flag2)
                        {
                            text = text + ch2.ToString().ToLowerInvariant();
                        }
                        else
                        {
                            text = text + ch2.ToString();
                        }
                        break;
                }
            }
            return text;
        }

        public string GetLanguageType(IColumn column)
        {
            if (IsValueType(column) && column.IsNullable)
                return "Nullable<" + column.LanguageType + ">";
            else
                return column.LanguageType;
        }

        public bool IsValueType(IColumn column)
        {
            // Array is always reference type
            if (column.LanguageType.IndexOf("[]") > -1)
                return false;

            // scan value types
            switch (column.LanguageType)
            {
                case "DateTime":
                case "decimal":
                case "bool":
                case "byte":
                case "double":
                case "Guid":
                case "int":
                case "float":
                case "short":
                case "TimeSpan":
                case "long":
                    return true;
                    break;

                default:
                    return false;
            }
        }

        public string GetEnumDescription(string dbName, string schemaName, string tableName, string connectionString)
        {
            EnumHelper eHelper = new EnumHelper();
            return eHelper.GetEnumDescription(dbName, schemaName, tableName, connectionString);
        }



        public bool PkGuidMi(ITable table)
        {
            bool sonuc = false;
            foreach (IColumn column in table.Columns)
            {
                if ((column.IsInPrimaryKey) && (column.LanguageType == "Guid"))
                {
                    sonuc = true;
                }
            }
            return sonuc;
        }
    }
}
