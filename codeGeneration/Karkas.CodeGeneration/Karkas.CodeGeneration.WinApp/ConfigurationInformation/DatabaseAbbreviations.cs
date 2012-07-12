using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volante;

namespace Karkas.CodeGeneration.WinApp.ConfigurationInformation
{
    public class DatabaseAbbreviations : Persistent
    {
        public string Abbravetion { get; set; }
        public string FullNameReplacement { get; set; }

        public override string ToString()
        {
            return string.Format("Kısaltma : {0} Yerine Geçen Tam İsim : {1}", Abbravetion, FullNameReplacement);
        }
    }
}
