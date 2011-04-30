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
        internal Server server;
        internal Database database;
        internal string connectionString;

        public DatabaseSqlServer(String pConnectionString,string pDatabaseName,string pProjectNameSpace,string pProjectFolder)
        {
            connectionString = ConnectionHelper.RemoveProviderFromConnectionString(pConnectionString);

            server = new Server(new ServerConnection(new SqlConnection(connectionString)));
            database = server.Databases[pDatabaseName];
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
                return database.Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
