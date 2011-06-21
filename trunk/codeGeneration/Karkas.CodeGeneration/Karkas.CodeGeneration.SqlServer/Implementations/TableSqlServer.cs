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
        private ColumnCollection smoColumnCollection;
        private string name;
        Table smoTable;

        public TableSqlServer(DatabaseSqlServer pDatabase,string pFullName)
        {
            database = pDatabase;
            smoTable = pDatabase.smoDatabase.Tables[pFullName];
            if (smoTable == null)
            {
                throw new ArgumentException("Table can not be found, Tablo bulunamadı");
            }
        }
        public TableSqlServer(DatabaseSqlServer pDatabase, string pTableName,string pSchemaName)
        {
            database = pDatabase;
            smoTable = pDatabase.smoDatabase.Tables[pTableName,pSchemaName];
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

        private List<IColumn> _Columns = null;
        public List<IColumn> Columns
        {
            get
            {
                if (_Columns != null)
                {
                    return _Columns;
                }
                _Columns = new List<IColumn>();

                if (smoColumnCollection == null)
                {
                    smoColumnCollection = smoTable.Columns;
                }
                foreach (Column smoColumn in smoColumnCollection)
                {
                    IColumn column = new ColumnSqlServer(smoColumn,this);
                    _Columns.Add(column);
                }
                return _Columns;
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

        public override string ToString()
        {
            return String.Format("Table : {0}.{1}", Name, Schema);
        }


        int? _primaryKeyColumnCount;
        public int PrimaryKeyColumnCount
        {
            get 
            {
                if (_primaryKeyColumnCount.HasValue)
                {
                    return _primaryKeyColumnCount.Value;
                }
                int count = 0;
                foreach (var item in this.Columns)
                {
                    if (item.IsInPrimaryKey)
                    {
                        count++;
                    }
                }
                _primaryKeyColumnCount = count;
                return count;
            }
        }


        public bool HasPrimaryKey
        {
            get 
            {
                if (PrimaryKeyColumnCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
