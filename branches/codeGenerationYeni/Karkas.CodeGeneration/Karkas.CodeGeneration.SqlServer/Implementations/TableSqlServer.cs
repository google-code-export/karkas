using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Microsoft.SqlServer.Management.Smo;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class TableSqlServer : ITable
    {
        private IDatabase database;
        private string name;
        Table smoTable;

        public TableSqlServer(DatabaseSqlServer pDatabase,string pFullName)
        {
            database = pDatabase;
            smoTable = pDatabase.database.Tables[pFullName];
            if (smoTable == null)
            {
                throw new ArgumentException("Table can not be found, Tablo bulunamadı");
            }
        }
        public TableSqlServer(DatabaseSqlServer pDatabase, string pTableName,string pSchemaName)
        {
            database = pDatabase;
            smoTable = pDatabase.database.Tables[pTableName,pSchemaName];
            if (smoTable == null)
            {
                throw new ArgumentException("Table can not be found, Tablo bulunamadı");
            }
        }



        public int findIndexFromName(string name)
        {
            throw new NotImplementedException();
        }

        public IDatabase Database
        {
            get
            {
                return database;
            }
            set
            {
                if (value is TableSqlServer)
                {
                    database = value;
                }
                throw new ArgumentException("Beklenmedik Tip, TableSqlServer bekleniyordu");

            }
        }

        public string Schema
        {
            get
            {
                return smoTable.Schema;
            }
        }

        public string Name
        {
            get
            {
                return smoTable.Name;
            }
        }

        public List<IColumn> Columns
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateCreated
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateModified
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Alias
        {
            get
            {
                return Name;
            }
        }
    }
}
