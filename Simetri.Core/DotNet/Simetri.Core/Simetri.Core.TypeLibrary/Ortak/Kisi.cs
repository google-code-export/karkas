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
            this.Validator.ValidatorList.Add(new RequiredFieldValidator(this,"Adi","Ad� de�erinini girmeniz gereklidir"));
            this.Validator.ValidatorList.Add(new OnlyCharacterValidator(this, "Adi", "Ad olarak sadace t�rk�e karakter kullanabilirsiniz"));
            this.Validator.ValidatorList.Add(new CompareValidator(this,"Adi",3,CompareOperator.Equal,"Ad� 3 karakterden olu�mal�d�r"));
            base.ValidationListesiniOlustur();
        }
    }
}
