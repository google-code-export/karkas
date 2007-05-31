using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Validation.ForPonos;
using System.Data;

namespace Simetri.Core.TypeLibrary
{
    [Serializable]
    public abstract class BaseTypeLibrary
    {
        private Validator validator;


        public BaseTypeLibrary()
        {
            rowState = DataRowState.Added;
        }
        public Validator Validator
        {
            get
            {
                return validator;
            }
        }
        protected abstract void ValidationListesiniOlusturCodeGeneration();

        protected virtual void ValidationListesiniOlustur()
        {
        }

        public bool Validate()
        {
            validator = new Validator(this);
            ValidationListesiniOlusturCodeGeneration();
            ValidationListesiniOlustur();
            return validator.Validate();
        }

        private DataRowState rowState;

        public DataRowState RowState
        {
            get 
            {
                return rowState; 
            }
            set { rowState = value; }
        }

        public void SilinmesiIcinIsaretle()
        {
            rowState = DataRowState.Deleted;
        }
        public void EklenmesiIcinIsaretle()
        {
            rowState = DataRowState.Added;
        }
        public void GuncellenmesiIcinIsaretle()
        {
            rowState = DataRowState.Modified;
        }


    }
}
