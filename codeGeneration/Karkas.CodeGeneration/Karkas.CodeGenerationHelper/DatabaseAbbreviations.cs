using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper
{
    public class DatabaseAbbreviations
    {
        public string Abbravetion;
        public string FullNameReplacement;
        public string useAsModuleName = "N";

        public DatabaseAbbreviations()
        {

        }

        public DatabaseAbbreviations(string pAbbravetion, string pFullNameReplacement)
        {
            Abbravetion = pAbbravetion;
            FullNameReplacement = pFullNameReplacement;


        }
        public override string ToString()
        {
            return string.Format("{0}{1}{2}\n", 
                Abbravetion, "-",
                FullNameReplacement);
        }
    }
}
