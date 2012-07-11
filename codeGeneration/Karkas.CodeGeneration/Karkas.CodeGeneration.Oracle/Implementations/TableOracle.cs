using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class TableOracle : ITable
    {

        public TableOracle(DatabaseOracle pDatabase, AdoTemplate template, String pTableName, String pSchemaName)
        {
            this.database = pDatabase;
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        DatabaseOracle database;

        AdoTemplate template;
        String tableName;
        String schemaName;

        public int findIndexFromName(string name)
        {
            throw new NotImplementedException();
        }

        public int PrimaryKeyColumnCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasPrimaryKey
        {
            get { throw new NotImplementedException(); }
        }

        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public List<IColumn> columns = null;

        public List<IColumn> Columns
        {
            get 
            {
                if (columns != null)
                {
                    return columns;
                }
                else
                {
                    throw new NotImplementedException(); 
                }
            }
        }

        public IDatabase Database
        {
            get 
            {
                return database;
            
            }
        }

        public DateTime DateCreated
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime DateModified
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return tableName; }
        }

        public string Schema
        {
            get { return schemaName; }
        }
    }
}
