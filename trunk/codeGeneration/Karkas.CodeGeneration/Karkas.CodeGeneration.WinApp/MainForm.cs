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

            DatabaseEntry entry = null;
            foreach (var item in DatabaseRoot.DbRootInstance.IndexLastWriteTime)
            {
                entry = item;
                break;
            }

            

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
                }
                else if (type == DatabaseType.Oracle)
                {

                    object objConnection = Activator.CreateInstance("System.Data.OracleClient", "System.Data.OracleClient.OracleConnection");

                    if (objConnection != null)
                    {
                        connection = (DbConnection)objConnection;

                        connection.Open();
                        connection.Close();
                    }

                }


                ConnectionSingleton.Instance.ConnectionString = connectionString;                
                template = new AdoTemplate(connectionString);
                labelConnectionStatus.Text = "Bağlantı Başarılı";
                BilgileriDoldur();
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



        private const string SQL__SQLSERCER_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
UNION
SELECT DISTINCT TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
";

        private const string SQL_SQLSERVER_DATABASE_NAME = @"
SELECT DISTINCT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES
";

        private const string SQL_SQLSERVER_TABLE_LIST = @"
SELECT TABLE_SCHEMA,TABLE_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
AND
TABLE_TYPE = 'BASE TABLE'
ORDER BY FULL_TABLE_NAME
";


        private void BilgileriDoldur( )
        {
            databaseNameLabelDoldur();
            comboBoxSchemaListDoldur();
            listBoxTableListDoldur();
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
        }

        private void databaseNameLabelDoldur()
        {
            labelDatabaseNameSonuc.Text = (string)template.TekDegerGetir(SQL_SQLSERVER_DATABASE_NAME);
        }

        private void listBoxTableListDoldur()
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", SqlDbType.VarChar, comboBoxSchemaList.Text);
            DataTable dtTableList = template.DataTableOlustur(SQL_SQLSERVER_TABLE_LIST, builder.GetParameterArray());
            listBoxTableListesi.DataSource = dtTableList;
        }

        private void comboBoxSchemaListDoldur( )
        {
            DataTable dtSchemaList = template.DataTableOlustur(SQL__SQLSERCER_SCHEMA_LIST);
            comboBoxSchemaList.DataSource = dtSchemaList;
            comboBoxSchemaList.Text = "__TUM_SCHEMALAR__";
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
            SqlServerHelper.codeGenerateAllTables(textBoxConnectionString.Text
                , labelDatabaseNameSonuc.Text
                , textBoxProjectNamespace.Text
            , textBoxCodeGenerationDizini.Text
            ,checkBoxDboSemasiniAtla.Checked
            ,checkBoxSysTablolariniAtla.Checked
            );
            MessageBox.Show("TÜM TABLOLAR İÇİN KOD ÜRETİLDİ");

        }

        private void buttonGecerliDegerleriKaydet_Click(object sender, EventArgs e)
        {
            DatabaseEntry entry = new DatabaseEntry();
            entry.CodeGenerationDirectory = textBoxCodeGenerationDizini.Text;
            entry.ConnectionName = textBoxDatabaseName.Text;
            entry.CodeGenerationNamespace = textBoxProjectNamespace.Text;
            entry.ConnectionString  = textBoxConnectionString.Text;
            entry.ConnectionDatabaseType = (DatabaseType) comboBoxDatabaseType.SelectedValue;

            DatabaseRoot.addToIndexesAndCommit(entry);

        }

        private void buttonSeciliTablolariUret_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxTableListesi.SelectedItems)
            {
                DataRowView view = (DataRowView)item;
                string tableSchema = view["TABLE_SCHEMA"].ToString();
                string tableName = view["TABLE_NAME"].ToString();
                SqlServerHelper.codeGenerateOneTable(textBoxConnectionString.Text
                    , tableName
                    , tableSchema
                    , labelDatabaseNameSonuc.Text
                    , textBoxProjectNamespace.Text
                    , textBoxCodeGenerationDizini.Text
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
                databaseEntryToForm(frm.SelectedDatabaseEntry);
            }
        }
    }
}
