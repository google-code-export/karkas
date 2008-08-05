using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;
using System.Xml;
using System.Xml.XPath;
using System.Reflection;

namespace Simetri.MyGenerationHelper
{
    public class SimetriXmlParser
    {
        string xmlDosyaninYeri = @"{0}\Settings\simetri.xml";

        public SimetriXmlParser()
        {
            calistigiYereGoreDosyaYeriniDegistir();
        }

        private void calistigiYereGoreDosyaYeriniDegistir()
        {
            string location = Assembly.GetEntryAssembly().Location;
            int sonSlashYeri = location.LastIndexOf('\\');
            location = location.Substring(0, sonSlashYeri);
            this.xmlDosyaninYeri = string.Format(xmlDosyaninYeri, location);
        }

        public string ProjeNamespaceIsminiAl(IDatabase database)
        {
            try
            {
                string dbName = getDbName(database);
                XmlNode databaseNode = getDatabaseNode(dbName);
                return databaseNode.SelectSingleNode("ProjectNamespace").InnerText;

            }
            catch (Exception)
            {
                
                return "";
            }
        }



        public string ProjeDizininiAl(IDatabase database)
        {

            try
            {
                string dbName = getDbName(database);
                XmlNode databaseNode = getDatabaseNode(dbName);
                return databaseNode.SelectSingleNode("ProjectFolder").InnerText;

            }
            catch (Exception)
            {
                return "";
            }
        }
        private XmlNode getDatabaseNode(string dbName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlDosyaninYeri);

            foreach (XmlNode node in xmlDoc.GetElementsByTagName("database"))
            {
                if (node.Attributes["name"].Value == dbName)
                {
                    return node;
                }
            }
            return null;
        }

        private string getDbName(IDatabase database)
        {
            string dbName = "";
            if (database != null)
            {
                dbName = database.Name;
            }
            else
            {
                dbName = "STB_MTK";
            }
            return dbName;
        }


        public string DizininiAlDatabaseVeSchemaIle(IDatabase database,string schemaName)
        {
            string dbName = getDbName(database);
            string sonuc = "";
            XPathDocument doc = new XPathDocument(xmlDosyaninYeri);
            XPathNavigator navigator = doc.CreateNavigator();
            navigator = navigator.SelectSingleNode(String.Format("//database[@name='{0}']/schema[@name='{1}']/SchemaFolder", dbName, schemaName));
            if (navigator == null)
            {
                sonuc = ProjeDizininiAl(database);
            }
            else
            {
                sonuc = navigator.Value;
            }
            return sonuc;
        }
        public string NamespaceIniAlSchemaIle(IDatabase database, string schemaName)
        {
            string sonuc = "";
            try
            {
                string dbName = getDbName(database);
                XPathDocument doc = new XPathDocument(xmlDosyaninYeri);
                XPathNavigator navigator = doc.CreateNavigator();
                navigator = navigator.SelectSingleNode(String.Format("//database[@name='{0}']/schema[@name='{1}']/SchemaNamespace", dbName, schemaName));
                if (navigator == null)
                {
                    sonuc = ProjeNamespaceIsminiAl(database);
                }
                else
                {
                    sonuc = navigator.Value;
                }
                return sonuc;
            }
            catch
            {
                return sonuc;
            }
        }
    }
}
