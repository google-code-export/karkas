using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;
using System.Xml;
using System.Xml.XPath;

namespace Simetri.MyGenerationHelper
{
    public class SimetriXmlParser
    {
        string xmlFilePath = @"C:\Program Files\MyGeneration\Settings\simetri.xml";

        public string ProjeNamespaceIsminiAl(IDatabase database)
        {
            string dbName = getDbName(database);
            XmlNode databaseNode = getDatabaseNode(dbName);
            return databaseNode.SelectSingleNode("ProjectNamespace").InnerText;
        }



        public string ProjeDizininiAl(IDatabase database)
        {
            string dbName = getDbName(database);
            XmlNode databaseNode = getDatabaseNode(dbName);
            return databaseNode.SelectSingleNode("ProjectFolder").InnerText;
        }
        private XmlNode getDatabaseNode(string dbName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

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
                dbName = "ITO_MTK";
            }
            return dbName;
        }


        public string ProjeDizininiAlSchemaIle(IDatabase database,string schemaName)
        {
            string dbName = getDbName(database);
            //employee[@employeeid='1']
            XPathDocument doc = new XPathDocument(xmlFilePath);
            XPathNavigator navigator = doc.CreateNavigator();
            navigator = navigator.SelectSingleNode(String.Format("//database[@name='{0}']/schema[@name='{1}']/SchemaFolder", database));
            return navigator.Value;
        }
        public string ProjeNamespaceIniAlSchemaIle(IDatabase database, string schemaName)
        {
            string dbName = getDbName(database);
            //employee[@employeeid='1']
            XPathDocument doc = new XPathDocument(xmlFilePath);
            XPathNavigator navigator = doc.CreateNavigator();
            navigator = navigator.SelectSingleNode(String.Format("//database[@name='{0}']/schema[@name='{1}']/SchemaNamespace", database));
            return navigator.Value;
        }
    }
}
