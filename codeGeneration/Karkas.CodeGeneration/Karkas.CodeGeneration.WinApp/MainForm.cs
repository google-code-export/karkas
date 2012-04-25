﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Karkas.Core.DataUtil;
using Karkas.CodeGeneration.WinApp.Properties;
using Karkas.CodeGeneration.SqlServer;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            if (!string.IsNullOrWhiteSpace( Settings.Default.SonConnectionStringDegeri))
            {
                textBoxConnectionString.Text = Settings.Default.SonConnectionStringDegeri;
            }
            if (!string.IsNullOrWhiteSpace( Settings.Default.SonCodeGenerationDizini))
            {
                textBoxCodeGenerationDizini.Text = Settings.Default.SonCodeGenerationDizini;
            }
            if (!string.IsNullOrWhiteSpace(Settings.Default.SonProjectNamespace))
            {
                textBoxProjectNamespace.Text = Settings.Default.SonProjectNamespace;
            }
            


        }
        SqlConnection connection;
        AdoTemplate template;
        private void buttonTestConnectionString_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection = new SqlConnection(textBoxConnectionString.Text);
                connection.Open();
                connection.Close();
                ConnectionSingleton.Instance.ConnectionString = textBoxConnectionString.Text;                
                template = new AdoTemplate(textBoxConnectionString.Text);
                labelConnectionStatus.Text = "Bağlantı Başarılı";
                BilgileriDoldur();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelConnectionStatus.ForeColor = Color.Red;
                labelConnectionStatus.Text = "!!!!Bağlantı BAŞARISIZ!!!!";
            }

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
            Settings.Default.SonCodeGenerationDizini = textBoxCodeGenerationDizini.Text;
            Settings.Default.SonConnectionStringDegeri = textBoxConnectionString.Text;
            Settings.Default.SonProjectNamespace = textBoxProjectNamespace.Text;
            Settings.Default.Save();

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
    }
}
