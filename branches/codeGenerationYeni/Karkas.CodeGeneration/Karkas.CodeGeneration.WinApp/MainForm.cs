using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonTestConnectionString_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(textBoxConnectionString.Text);
                connection.Open();
                labelConnectionStatus.Text = "Bağlantı Başarılı";
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelConnectionStatus.Text = "!!!!Bağlantı BAŞARISIZ!!!!";
            }

        }
    }
}
