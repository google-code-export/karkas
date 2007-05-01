using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Validation.ForPonos;
using Simetri.Core.Validation;

namespace Simetri.Core.Example.TypeLibrary.Ortak
{
    public partial class Kisi
    {
        private Validator validator;

        public Kisi()
        {
            validator = new Validator(this);
            ValidationListesiniOlustur();
        }
        public Validator Validator
        {
            get 
            {
                return validator; 
            }
        }

        private void ValidationListesiniOlustur()
        {
            validator.ValidatorList.Add(new RequiredFieldValidator(this,"Adi"));
            validator.ValidatorList[0].ErrorMessage = "Adý gereklidir";
            validator.ValidatorList.Add(new RequiredFieldValidator(this,"Yasi"));
            validator.ValidatorList.Add(new CompareValidator(this, "Yasi", 1, CompareOperator.GreaterThan));
        }

        public bool Validate()
        {
            return validator.Validate();
        }

    }
}
