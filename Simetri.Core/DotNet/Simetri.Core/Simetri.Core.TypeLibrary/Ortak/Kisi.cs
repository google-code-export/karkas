using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.Validation.ForPonos;
using Simetri.Core.Validation;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class Kisi
    {
        protected override void ValidationListesiniOlustur()
        {
            this.Validator.ValidatorList.Add(new RequiredFieldValidator(this,"Adi","Adý deðerinini girmeniz gereklidir"));
            this.Validator.ValidatorList.Add(new OnlyCharacterValidator(this, "Adi", "Ad olarak sadace türkçe karakter kullanabilirsiniz"));
            this.Validator.ValidatorList.Add(new CompareValidator(this,"Adi",3,CompareOperator.Equal,"Adý 3 karakterden oluþmalýdýr"));
            base.ValidationListesiniOlustur();
        }
    }
}
