using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Karkas.Core.DataUtil;
using Karkas.CodeGeneration.SqlServer;
using Volante;
using Karkas.CodeGeneration.WinApp.ConfigurationInformation;
using System.Reflection;
using System.Data.Common;
using System.Runtime.Remoting;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.Oracle;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            comboBoxDatabaseType.DataSource = Enum.GetValues(typeof(DatabaseType));

            panelListeDisable();

            setLastAccessedConnection();
            


        }

        private DatabaseEntry currentDatabaseEntry = null;

        private void setLastAccessedConnection()
        {
            DatabaseRoot.openDatabase();

            DatabaseEntry entry = DatabaseRoot.getLastAccessedDatabaseEntry();

            

            if (entry != null)
            {
                databaseEntryToForm(entry);

            }

        }

        private void databaseEntryToForm(DatabaseEntry entry)
        {
            currentDatabaseEntry = entry;

            if (!string.IsNullOrWhiteSpace(entry.ConnectionString))
            {
                textBoxConnectionString.Text = entry.ConnectionString;
            }
            if (!string.IsNullOrWhiteSpace(entry.CodeGenerationDirectory))
            {
                textBoxCodeGenerationDizini.Text = entry.CodeGenerationDirectory;
            }
            if (!string.IsNullOrWhiteSpace(entry.CodeGenerationNamespace))
            {
                textBoxProjectNamespace.Text = entry.CodeGenerationNamespace;
            }
            textBoxDatabaseName.Text = entry.ConnectionName;
            comboBoxDatabaseType.SelectedItem = entry.ConnectionDatabaseType;
        }


        DbConnection connection;
        AdoTemplate template;
        private void buttonTestConnectionString_Click(object sender, EventArgs e)
        {
            string connectionString = textBoxConnectionString.Text;

            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                DatabaseType type = (DatabaseType)comboBoxDatabaseType.SelectedItem;
                if (type == null || type == DatabaseType.SqlServer)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    connection.Close();
                    ConnectionSingleton.Instance.ConnectionString = connectionString;
                    template = new AdoTemplate();
                    template.Connection = connection;

                    labelConnectionStatus.Text = "Bağlantı Başarılı";
                    databaseHelper = new SqlServerHelper();

                    BilgileriDoldur();
                }
                else if (type == DatabaseType.Oracle)
                {
                    Assembly oracleAssembly = Assembly.LoadWithPartialName("System.Data.OracleClient");
                    Object objReflection = Activator.CreateInstance(oracleAssembly.FullName, "System.Data.OracleClient.OracleConnection");

                    if (objReflection != null && objReflection is ObjectHandle)
                    {
                        ObjectHandle handle = (ObjectHandle)objReflection;

                        Object objConnection = handle.Unwrap();
                        connection = (DbConnection)objConnection;
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        connection.Close();
                        ConnectionSingleton.Instance.ConnectionString = connectionString;
                        ConnectionSingleton.Instance.ProviderName = "System.Data.OracleClient";
                        template = new AdoTemplate();
                        template.Connection = connection;
                        databaseHelper = new OracleHelper();


                        labelConnectionStatus.Text = "Bağlantı Başarılı";
                        BilgileriDoldur();
                    }

                }

                panelListe.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelConnectionStatus.ForeColor = Color.Red;
                labelConnectionStatus.Text = "!!!!Bağlantı BAŞARISIZ!!!!";
            }

        }


        private void panelListeEnable()
        {
            panelListe.Enabled = true;
        }
        private void panelListeDisable()
        {
            panelListe.Enabled = false;
        }





        private IDatabaseHelper databaseHelper;


        private void BilgileriDoldur( )
        {
            databaseNameLabelDoldur();
            comboBoxSchemaListDoldur();
            listBoxTableListDoldur();
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
        }

        private void databaseNameLabelDoldur()
        {
            labelDatabaseNameSonuc.Text = databaseHelper.getDatabaseName(template);
        }


        private void listBoxTableListDoldur()
        {
            DataTable dtTableList = databaseHelper.getTableListFromSchema(template, comboBoxSchemaList.Text);
            listBoxTableListesi.DataSource = dtTableList;
        }



        private void comboBoxSchemaListDoldur( )
        {
            DataTable dtSchemaList = databaseHelper.getSchemaList(template);
            comboBoxSchemaList.DataSource = dtSchemaList;
            comboBoxSchemaList.Text = databaseHelper.getDefaultSchema(template);
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTableListDoldur();
        }

        private void buttonFolderDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBoxCodeGenerationDizini.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void buttonTumTablolariUret_Click(object sender, EventArgs e)
        {
            databaseHelper.CodeGenerateAllTables(template, textBoxConnectionString.Text
                , labelDatabaseNameSonuc.Text
                , textBoxProjectNamespace.Text
            , textBoxCodeGenerationDizini.Text
            ,checkBoxDboSemasiniAtla.Checked
            ,checkBoxSysTablolariniAtla.Checked
            ,currentDatabaseEntry.getAbbreviationsDataSource()
            );
            MessageBox.Show("TÜM TABLOLAR İÇİN KOD ÜRETİLDİ");

        }

        private void buttonGecerliDegerleriKaydet_Click(object sender, EventArgs e)
        {
            DatabaseRoot.removeFromIndexes(currentDatabaseEntry);

            currentDatabaseEntry.CodeGenerationDirectory = textBoxCodeGenerationDizini.Text;
            currentDatabaseEntry.ConnectionName = textBoxDatabaseName.Text;
            currentDatabaseEntry.CodeGenerationNamespace = textBoxProjectNamespace.Text;
            currentDatabaseEntry.ConnectionString  = textBoxConnectionString.Text;
            currentDatabaseEntry.ConnectionDatabaseType = (DatabaseType) comboBoxDatabaseType.SelectedValue;
            currentDatabaseEntry.LastWriteTimeUtc = DateTime.UtcNow;
            currentDatabaseEntry.LastAccessTimeUtc = DateTime.UtcNow;

            DatabaseRoot.addToIndexesAndCommit(currentDatabaseEntry);

        }


        public List<DatabaseAbbreviations> getSampleAbbreviations()
        {

            List<DatabaseAbbreviations> list = new List<DatabaseAbbreviations>();
            DatabaseAbbreviations abbr = new DatabaseAbbreviations();
            abbr.Abbravetion = "BO_";
            abbr.FullNameReplacement = "";
            list.Add(abbr);
            return list;
        }


        private void buttonSeciliTablolariUret_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxTableListesi.SelectedItems)
            {
                DataRowView view = (DataRowView)item;
                string tableSchema = view["TABLE_SCHEMA"].ToString();
                string tableName = view["TABLE_NAME"].ToString();
                databaseHelper.CodeGenerateOneTable(template,textBoxConnectionString.Text
                    , tableName
                    , tableSchema
                    , labelDatabaseNameSonuc.Text
                    , textBoxProjectNamespace.Text
                    , textBoxCodeGenerationDizini.Text
                    , getSampleAbbreviations()
                    );

            }

            MessageBox.Show("SEÇİLEN TABLOLAR İÇİN KOD ÜRETİLDİ");

        }

        private void buttonOtherConnections_Click(object sender, EventArgs e)
        {
            FormConnectionList frm = new FormConnectionList();
            frm.ShowDialog();

            if (frm.SelectedDatabaseEntry != null)
            {
                frm.SelectedDatabaseEntry.LastAccessTimeUtc = DateTime.UtcNow;
                frm.SelectedDatabaseEntry.Modify();
                DatabaseRoot.Commit();
                databaseEntryToForm(frm.SelectedDatabaseEntry);
            }
        }

        private void buttonKisaltmalar_Click(object sender, EventArgs e)
        {
            Form frm = new FormAbbravetions(currentDatabaseEntry);
            frm.ShowDialog();
        }

        private void buttonNewConnection_Click(object sender, EventArgs e)
        {
            currentDatabaseEntry = new DatabaseEntry();
            textBoxCodeGenerationDizini.Text = "";
            textBoxDatabaseName.Text = "";
            textBoxProjectNamespace.Text = "";
            textBoxConnectionString.Text = "";

        }
    }
}
