using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Karkas.CodeGeneration.WinApp.ConfigurationInformation;
using System.Collections;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class FormAbbravetions : Form
    {



        public FormAbbravetions(DatabaseEntry pDatabaseEntry)
        {
            this.DatabaseEntry = pDatabaseEntry;
            InitializeComponent();

            this.listBoxKisaltmalar.DataSource = this.DatabaseEntry.AbbreviationsDataSource;
        }


        public DatabaseEntry DatabaseEntry { get; set; }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            DatabaseAbbreviations abbr = new DatabaseAbbreviations();
            abbr.FullNameReplacement = textBoxYerineGecenYazi.Text;
            abbr.Abbravetion = textBoxKisaltma.Text;



            this.DatabaseEntry.AddAbbreviations(abbr);


            this.listBoxKisaltmalar.DataSource = this.DatabaseEntry.AbbreviationsDataSource;

        }
    }
}
