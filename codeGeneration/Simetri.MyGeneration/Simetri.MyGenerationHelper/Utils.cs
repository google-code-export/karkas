using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MyMeta;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Simetri.MyGenerationHelper
{
    public class Utils
    {
        string xmlFilePath = @"C:\Program Files\MyGeneration\Settings\simetri.xml";

        public string ProjeDizininiAl(IDatabase database)
        {
            string dbName = database.Name;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            foreach (XmlNode node in xmlDoc.GetElementsByTagName("database"))
            {
                if (node.Attributes["name"].Value == dbName)
                {
                    XmlNode dizinNode = node.SelectSingleNode("ProjectFolder");
                    return dizinNode.InnerText;
                }
            }
            return "";
        }
        public string ProjeNamespaceIsminiAl(IDatabase database)
        {
            string dbName = database.Name;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            foreach (XmlNode node in xmlDoc.GetElementsByTagName("database"))
            {
                if (node.Attributes["name"].Value == dbName)
                {
                    XmlNode dizinNode = node.SelectSingleNode("ProjectNamespace");
                    return dizinNode.InnerText;
                }
            }
            return "";
        }

        public void deneme()
        {
            SqlDataReader reader;
            //reader.GetInt16();
            //reader.GetInt64
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


        public string GetDataReaderSyntax(IColumn column)
        {
            //            return column.LanguageType;
            if (column.LanguageType == "Guid")
            {
                return "Guid";
            }
            else if (column.LanguageType == "int")
            {
                return "Int32";
            }
            else if (column.LanguageType == "byte")
            {
                return "Byte";
            }
            else if (column.LanguageType == "bool")
            {
                return "Boolean";
            }
            else if (column.LanguageType == "DateTime")
            {
                return "DateTime";
            }
            else if (column.LanguageType == "string")
            {
                return "String";
            }
            else if (column.LanguageType == "short")
            {
                return "Int16";
            }
            else if (column.LanguageType == "long")
            {
                return "Int64";
            }
            else if (column.LanguageType == "decimal")
            {
                return "Decimal";
            }
            else if (column.LanguageType == "byte[]")
            {
                return "Byte[]";
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


        public string SetPascalCase(string name)
        {
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



    }
}
