using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volante;
using System.Collections;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.WinApp.ConfigurationInformation
{
    public class DatabaseEntry : Persistent
    {
        public DatabaseEntry()
        {
            CreationTimeUtc = DateTime.UtcNow;
            LastAccessTimeUtc = DateTime.UtcNow;
            LastWriteTimeUtc = DateTime.UtcNow;
            AbbrevationsAsString = string.Empty;
        }


        public String ConnectionName;
        public DatabaseType ConnectionDatabaseType;
        public String AbbrevationsAsString;
        public String ConnectionString;
        public String CodeGenerationDirectory;
        public String CodeGenerationNamespace;
        public DateTime CreationTimeUtc;
        public DateTime LastAccessTimeUtc;
        public DateTime LastWriteTimeUtc;





        public override string ToString()
        {
            String str = string.Format("{0}\t{1}\t{2}\t{3}", ConnectionName, ConnectionDatabaseType, CodeGenerationNamespace, ConnectionString);
            return str;

        }


        public void AddAbbreviations(DatabaseAbbreviations abbr)
        {
            AbbrevationsAsString += abbr.ToString();
        }

        public List<DatabaseAbbreviations> getAbbreviationsDataSource()
        {

            List<DatabaseAbbreviations> list = new List<DatabaseAbbreviations>();
            if (string.IsNullOrEmpty(AbbrevationsAsString))
            {
                return list;
            }
            String[] abbrStringList = AbbrevationsAsString.Split('\n');
            foreach (string item in abbrStringList)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                String[] abbrArrr = item.Split('-');
                DatabaseAbbreviations abbr = new DatabaseAbbreviations();
                abbr.Abbravetion = abbrArrr[0];
                abbr.FullNameReplacement = abbrArrr[1];
                list.Add(abbr);

            }
            return list;
        }


    }
}
