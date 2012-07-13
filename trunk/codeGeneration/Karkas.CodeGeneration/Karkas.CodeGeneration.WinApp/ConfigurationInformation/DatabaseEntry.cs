using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volante;
using System.Collections;

namespace Karkas.CodeGeneration.WinApp.ConfigurationInformation
{
    public class DatabaseEntry : Persistent
    {
        public DatabaseEntry()
        {
            CreationTimeUtc = DateTime.UtcNow;
            LastAccessTimeUtc = DateTime.UtcNow;
            LastWriteTimeUtc = DateTime.UtcNow;
        }


        public String ConnectionName;
        public DatabaseType ConnectionDatabaseType;
        public String ConnectionString;
        public String CodeGenerationDirectory;
        public String CodeGenerationNamespace;
        public DateTime CreationTimeUtc;
        public DateTime LastAccessTimeUtc;
        public DateTime LastWriteTimeUtc;


        ILink<DatabaseAbbreviations> abbreviations= null;

        public IList<DatabaseAbbreviations> AbbreviationsDataSource
        {
            get
            {
                return Abbreviations.ToList();
            }
        }

        public ILink<DatabaseAbbreviations> Abbreviations
        {
            get
            {
                if (abbreviations == null)
                {
                    abbreviations = this.db.CreateLink<DatabaseAbbreviations>();
                }
                return abbreviations;
            }
            set
            {
                abbreviations = value;
            }
        }

        public void AddAbbreviations(DatabaseAbbreviations abbr)
        {
            Abbreviations.Add(abbr);
        }



        public override string ToString()
        {
            String str = string.Format("{0}\t{1}\t{2}\t{3}", ConnectionName, ConnectionDatabaseType, CodeGenerationNamespace, ConnectionString);
            return str;

        }

    }
}
