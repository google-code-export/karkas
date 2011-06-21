using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;

namespace Karkas.MyGenerationHelper.Interfaces
{
    public class TableContainer : IContainer
    {
        private ITable table;

        public ITable Table
        {
            get { return table; }
            set { table = value; }
        }

        public TableContainer(ITable table)
        {
            this.table = table;
        }
        #region IContainer Members

        public string Alias
        {
            get
            {
                return this.table.Alias;
            }
            set
            {
                this.table.Alias = value;
            }
        }

        public IColumns Columns
        {
            get { return this.table.Columns; }
        }

        public IDatabase Database
        {
            get { return this.table.Database; }
        }

        public DateTime DateCreated
        {
            get { return this.table.DateCreated; }
        }

        public DateTime DateModified
        {
            get { return this.table.DateModified; }
        }

        public string Description
        {
            get { return this.table.Description; }
        }

        public string Name
        {
            get { return this.table.Name; }
        }

        public string Schema
        {
            get { return this.table.Schema; }
        }

        #endregion
    }
}
