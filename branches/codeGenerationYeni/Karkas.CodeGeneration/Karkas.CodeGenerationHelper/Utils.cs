﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Karkas.CodeGenerationHelper.Generators;
using System.IO;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGenerationHelper.SmoHelpers;

namespace Karkas.CodeGenerationHelper
{
    public class Utils
    {
        #region Generator Helper Fonksiyonlari

        public void RenderDatabaseTablesCode(IOutput output, ITable table, string connectionString)
        {
            DatabaseTablesGenerator gen = new DatabaseTablesGenerator();
            gen.Render(output, table, connectionString);

        }

        public void RenderInsertScriptsCode(IOutput output, ITable table, string connectionString)
        {
            InsertScriptsGenerator gen = new InsertScriptsGenerator();
            gen.Render(output, table, connectionString);
        }

        public void RenderTypeLibraryCode(IOutput output, ITable table)
        {
            TypeLibraryGenerator gen = new TypeLibraryGenerator();
            gen.Render(output, new TableContainer(table));
        }
        public void RenderTypeLibraryCode(IOutput output, IView view)
        {
            TypeLibraryGenerator gen = new TypeLibraryGenerator();
            gen.Render(output, new ViewContainer(view));
        }
        public void RenderStoredProcedureCode(IOutput output, IProcedure proc)
        {
            SpGenerator gen = new SpGenerator();
            gen.Render(output, proc);
        }

        public string RenderDalCode(IOutput output, ITable table)
        {
            DalGenerator gen = new DalGenerator();
            return gen.Render(output, new TableContainer(table));
        }
        public void RenderDalCode(IOutput output, IView view)
        {
            DalGenerator gen = new DalGenerator();
            gen.Render(output, new ViewContainer(view));
        }
        public void RenderBsCode(IOutput output, ITable table)
        {
            BsGenerator gen = new BsGenerator();
            gen.Render(output, new TableContainer(table));
        }
        public void RenderBsCode(IOutput output, IView view)
        {
            BsGenerator gen = new BsGenerator();
            gen.Render(output, new ViewContainer(view));
        }
        public void RenderBsWrapperCode(IOutput output, ITable table)
        {
            BsWrapperGenerator gen = new BsWrapperGenerator();
            gen.Render(output, new TableContainer(table));
        }
        public void RenderBsWrapperCode(IOutput output, IView view)
        {
            BsWrapperGenerator gen = new BsWrapperGenerator();
            gen.Render(output, new ViewContainer(view));
        }
        public void RenderAspxCode(IOutput output, ITable table, string pMasterName)
        {
            AspxGenerator genA = new AspxGenerator();
            genA.Render(output, table, pMasterName);
            AspxCsGenerator genCs = new AspxCsGenerator();
            genCs.Render(output, table);
        }



        #endregion


        #region "Parser Helper Fonksiyonlari"
        KarkasXmlParser parser = new KarkasXmlParser();

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

        public string[] GetSchemaList(string pDatabaseName, string pConnectionString)
        {
            SmoHelper smoHelper = new SmoHelper();
            return smoHelper.GetSchemaList(pDatabaseName, pConnectionString);
        }

        public string IdentityColumnAdiniBul(IContainer table)
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

        public string PrimaryKeyAdiniBul(IContainer table)
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

        public string PrimaryKeyTipiniBul(IContainer table)
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
        public string IdentityTipiniBul(IContainer table)
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
        public bool IdentityVarMi(IContainer table)
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

        public string IdentityVarMiAsString(IContainer table)
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

        public bool ColumnNullDegeriAlabilirMi(IColumn pColumn)
        {
            if (pColumn.IsNullable)
            {
                return true;
            }
            else if (ColumnValueTypeMi(pColumn))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool ArgumentValueTypeMi(string pLanguageType)
        {
            if (
                    pLanguageType == "Guid"
                    || pLanguageType == "int"
                    || pLanguageType == "byte"
                    || pLanguageType == "bool"
                    || pLanguageType == "DateTime"
                    || pLanguageType == "short"
                    || pLanguageType == "long"
                    || pLanguageType == "decimal"
                    || pLanguageType == "double"
                    || pLanguageType == "float"
                    )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ColumnValueTypeMi(IColumn column)
        {
            return ArgumentValueTypeMi(column.LanguageType);
        }

        public string GetConvertToSyntax(string tipi, string degiskenDegeri)
        {
            string sonuc = string.Format("({0}) {1}", tipi, degiskenDegeri);
            switch (tipi)
            {
                case "byte":
                    sonuc = string.Format("Convert.ToByte({0});", degiskenDegeri);
                    break;
                case "int":
                    sonuc = string.Format("Convert.ToInt32({0});", degiskenDegeri);
                    break;
                case "long":
                    sonuc = string.Format("Convert.ToInt64({0});", degiskenDegeri);
                    break;
                case "decimal":
                    sonuc = string.Format("Convert.ToDecimal({0});", degiskenDegeri);
                    break;
            }
            return sonuc;
        }


        public string[] GetConvertToSyntax(IColumn column, string propertyName)
        {
            string degerDegiskenAdi = "value";
            string araDegiskenAdi = "_a";
            int araDegiskenYeri = 2;
            string[] sonucListesi = new string[]{
                    "try"
                    ,"{"
                    ,""
                    ,string.Format("{0} = {1};", propertyName,araDegiskenAdi)
                    ,"}"
                    ,"catch(Exception)"
                    ,"{"
                    ,string.Format("\tthis.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,\"{0}\",string.Format(CEVIRI_YAZISI,\"{0}\",\"{1}\")));"
                                ,propertyName
                                ,column.LanguageType)
                    ,"}"
                    };
            if (column.LanguageType == "Guid")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tGuid {0} = new Guid({1});", araDegiskenAdi, degerDegiskenAdi); ;
                return sonucListesi;
            }
            else if (column.LanguageType == "int")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tint {0} = Convert.ToInt32({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "byte")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tbyte {0} = Convert.ToByte({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "bool")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tbool {0} = Convert.ToBoolean({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "DateTime")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tDateTime {0} = Convert.ToDateTime({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "string")
            {
                return new string[] { String.Format("{0} = {1};", propertyName, degerDegiskenAdi) };
            }
            else if (column.LanguageType == "short")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tshort {0} = Convert.ToInt16({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "long")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tlong {0} = Convert.ToInt64({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "decimal")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tdecimal {0} = Convert.ToDecimal({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "byte[]")
            {
                return new string[] { "throw new ArgumentException(\"String'ten byte[] array'e cevirim desteklenmemektedir\");" };
            }
            else if (column.LanguageType == "double")
            {

                sonucListesi[araDegiskenYeri] = string.Format("\tdouble {0} = Convert.ToDouble({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "float")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tfloat {0} = Convert.ToSingle({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "object")
            {
                sonucListesi[araDegiskenYeri] = string.Format("object {0} =(object) {1};", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            return new string[] { "throw new ArgumentException(\"string'ten degisken tipine cevirim desteklenmemektedir\");" };

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
            else if (column.LanguageType == "double")
            {
                return "dr.GetDouble";
            }
            else if (column.LanguageType == "float")
            {
                return "dr.GetFloat";
            }
            else if (column.LanguageType == "object")
            {
                return "dr.GetValue";
            }
            else if (column.LanguageType == "Unknown")
            {
                return "dr.GetString";
            }



            return column.LanguageType;
        }



        public List<ITable> filterListAccordingToSchemaName(List<ITable> tableList, string schemaName)
        {
            // TODO burada tablo listesi alan kodu yaz.
            List<ITable> newList = null; //= new MyMeta.Sql.SqlTables();

            foreach (ITable t in tableList)
            {
                if (t.Schema.Equals(schemaName, StringComparison.InvariantCultureIgnoreCase))
                {
                    newList.Add(t);
                }
            }

            return newList;

        }

        public string GetCamelCase(string name)
        {
            return new NameChecker().SetCamelCase(name);
        }

        public string GetPascalCase(string name)
        {
            return new NameChecker().SetPascalCase(name);
        }

        public string getPropertyVariableName(IColumn pColumn)
        {

            if (pColumn.Table != null)
            {
                if (

                    (pColumn.Name.Equals(pColumn.Table.Name, StringComparison.CurrentCultureIgnoreCase))
                ||
                    (pColumn.Name.Equals(pColumn.Table.Name, StringComparison.InvariantCultureIgnoreCase))
                ||
                    (pColumn.Name.Equals(pColumn.Table.Name, StringComparison.OrdinalIgnoreCase))
                    )
                {
                    return GetPascalCase(pColumn.Name) + "Property";
                }
            }
            return GetPascalCase(pColumn.Name);
        }

        public string GetLanguageType(IColumn column)
        {
            if (IsValueType(column) && column.IsNullable)
            {
                return "Nullable<" + column.LanguageType + ">";
            }
            else if (column.LanguageType == "Unknown" && column.DataTypeName == "sysname")
            {
                return "string";
            }
            else
            {
                return column.LanguageType;
            }
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



        public bool PkGuidMi(IContainer table)
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

