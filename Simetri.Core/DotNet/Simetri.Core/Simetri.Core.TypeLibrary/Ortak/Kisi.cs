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
            this.Validator.ValidatorList.Add(new CompareValidator(this, "Adi",3,CompareOperator.GreatThanEqual, "Adýn 3 karakter veya daha büyük olmasý gerekir"));
            
            this.Validator.ValidatorList.Add(new RequiredFieldValidator(this, "Soyadi", "Soyadý deðerinini girmeniz gereklidir"));
            this.Validator.ValidatorList.Add(new OnlyCharacterValidator(this, "Soyadi", "Soyadý olarak sadace türkçe karakter kullanabilirsiniz"));
            base.ValidationListesiniOlustur();
        }
    }
}
