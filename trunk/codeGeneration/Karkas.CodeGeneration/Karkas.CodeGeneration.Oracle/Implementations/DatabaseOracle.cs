using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class DatabaseOracle : IDatabase
    {

        public DatabaseOracle(AdoTemplate pTemplate,String pConnectionString, string pDatabaseName, string pProjectNameSpace, string pProjectFolder)
        {
            template = pTemplate;

            connectionString = pConnectionString;

            _projectNameSpace = pProjectNameSpace;
            _projectFolder = pProjectFolder;
            _DatabaseName = pDatabaseName;

        }
        AdoTemplate template;
        string _projectNameSpace;
        string connectionString;
        string _projectFolder;
        string _DatabaseName;


        public string Name
        {
            get
            {
                return _DatabaseName;
            }
            set
            {
                _DatabaseName = value;
            }
        }

        public string projectNameSpace
        {
            get { return _projectNameSpace; }
        }

        public string projectFolder
        {
            get { return _projectFolder; }
        }

        public List<ITable> Tables
        {
            get { throw new NotImplementedException(); }
        }


        public ITable getTable(string pTableName, string pSchemaName)
        {
            return new TableOracle(this,template, pTableName, pSchemaName);
        }
    }
}
