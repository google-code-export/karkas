using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGenerationHelper;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;


namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class DatabaseSqlServer : IDatabase
    {
        internal Server smoServer;
        internal Database smoDatabase;
        internal string connectionString;

        public DatabaseSqlServer(String pConnectionString,string pDatabaseName,string pProjectNameSpace,string pProjectFolder)
        {
            connectionString = ConnectionHelper.RemoveProviderFromConnectionString(pConnectionString);

            smoServer = new Server(new ServerConnection(new SqlConnection(connectionString)));
            smoDatabase = smoServer.Databases[pDatabaseName];
            _projectNameSpace = pProjectNameSpace;
            _projectFolder = pProjectFolder;

        }
        string _projectNameSpace;
        string _projectFolder;
        public string projectNameSpace
        {
            get
            {
                return _projectNameSpace;
            }
        }
        public string projectFolder
        {
            get
            {
                return _projectFolder;
            }
        }



        public string Name
        {
            get
            {
                return smoDatabase.Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        List<ITable> _tableList;
        public List<ITable> Tables
        {
           
            get 
            {
                if (_tableList == null)
                {
                    _tableList = new List<ITable>();
                    foreach (Table smoTable in smoDatabase.Tables)
                    {
                        ITable t = new TableSqlServer(this, smoTable.Name, smoTable.Schema);
                        _tableList.Add(t);
                    }
                }
                return _tableList;
            
            }
        }

        public override string ToString()
        {
            return Name;
        }


        public ITable getTable(string pTableName, string pSchemaName)
        {
             ITable t = new TableSqlServer(this, pTableName, pSchemaName);
             return t;
        }
    }
}
