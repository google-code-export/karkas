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

namespace Karkas.CodeGeneration.WinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
                template = new AdoTemplate(connection);
                labelConnectionStatus.Text = "Bağlantı Başarılı";
                BilgileriDoldur();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelConnectionStatus.Text = "!!!!Bağlantı BAŞARISIZ!!!!";
            }

        }
        private const string SQL_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
UNION
SELECT DISTINCT TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES
";


        private const string SQL_TABLE_LIST = @"
SELECT TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
AND
TABLE_TYPE = 'BASE TABLE'
ORDER BY FULL_TABLE_NAME
";


        private void BilgileriDoldur( )
        {
            comboBoxSchemaListDoldur();
            listBoxTableListDoldur();
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
        }

        private void listBoxTableListDoldur()
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@TABLE_SCHEMA", SqlDbType.VarChar, comboBoxSchemaList.Text);
            DataTable dtTableList = template.DataTableOlustur(SQL_TABLE_LIST, builder.GetParameterArray());
            listBoxTableListesi.DataSource = dtTableList;
        }

        private void comboBoxSchemaListDoldur( )
        {
            DataTable dtSchemaList = template.DataTableOlustur(SQL_SCHEMA_LIST);
            comboBoxSchemaList.DataSource = dtSchemaList;
            comboBoxSchemaList.Text = "__TUM_SCHEMALAR__";
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTableListDoldur();
        }
    }
}
