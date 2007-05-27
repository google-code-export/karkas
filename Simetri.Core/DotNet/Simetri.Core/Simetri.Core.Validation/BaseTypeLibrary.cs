using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Validation.ForPonos;

namespace Simetri.Core.TypeLibrary
{
    public abstract class BaseTypeLibrary
    {
        private Validator validator;


        public BaseTypeLibrary()
        {
            validator = new Validator(this);
            ValidationListesiniOlusturCodeGeneration();
            ValidationListesiniOlustur();
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
            return validator.Validate();
        }


    }
}
