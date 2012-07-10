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
        public TableOracle(AdoTemplate template,String pTableName,String pSchemaName)
        {

        }


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

        public List<IColumn> Columns
        {
            get { throw new NotImplementedException(); }
        }

        public IDatabase Database
        {
            get { throw new NotImplementedException(); }
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
            get { throw new NotImplementedException(); }
        }

        public string Schema
        {
            get { throw new NotImplementedException(); }
        }
    }
}
