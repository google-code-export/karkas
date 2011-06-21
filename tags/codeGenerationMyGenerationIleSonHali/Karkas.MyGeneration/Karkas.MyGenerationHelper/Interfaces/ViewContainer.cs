using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;

namespace Karkas.MyGenerationHelper.Interfaces
{
    public class ViewContainer : IContainer
    {

        private IView view;

        public IView View
        {
            get { return view; }
            set { view = value; }
        }

        public ViewContainer(IView view)
        {
            this.view = view;
        }
        #region IContainer Members

        public string Alias
        {
            get
            {
                return this.view.Alias;
            }
            set
            {
                this.view.Alias = value;
            }
        }

        public IColumns Columns
        {
            get { return this.view.Columns; }
        }

        public IDatabase Database
        {
            get { return this.view.Database; }
        }

        public DateTime DateCreated
        {
            get { return this.view.DateCreated; }
        }

        public DateTime DateModified
        {
            get { return this.view.DateModified; }
        }

        public string Description
        {
            get { return this.view.Description; }
        }

        public string Name
        {
            get { return this.view.Name; }
        }

        public string Schema
        {
            get { return this.view.Schema; }
        }

        #endregion
    }
}
