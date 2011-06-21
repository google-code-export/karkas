namespace Karkas.CodeGeneration.WinApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.buttonTestConnectionString = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.panelListe = new System.Windows.Forms.Panel();
            this.listBoxTableListesi = new System.Windows.Forms.ListBox();
            this.labelTabloListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.panelListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(43, 35);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(120, 17);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection String";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(203, 35);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(624, 22);
            this.textBoxConnectionString.TabIndex = 2;
            this.textBoxConnectionString.Text = "Data Source=localhost;Initial Catalog=KARKAS_ORNEK;Integrated Security=True";
            // 
            // buttonTestConnectionString
            // 
            this.buttonTestConnectionString.Location = new System.Drawing.Point(846, 32);
            this.buttonTestConnectionString.Name = "buttonTestConnectionString";
            this.buttonTestConnectionString.Size = new System.Drawing.Size(103, 24);
            this.buttonTestConnectionString.TabIndex = 3;
            this.buttonTestConnectionString.Text = "test";
            this.buttonTestConnectionString.UseVisualStyleBackColor = true;
            this.buttonTestConnectionString.Click += new System.EventHandler(this.buttonTestConnectionString_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(52, 72);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(135, 17);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Bağlantı Denenmedi";
            // 
            // panelListe
            // 
            this.panelListe.Controls.Add(this.listBoxTableListesi);
            this.panelListe.Controls.Add(this.labelTabloListesi);
            this.panelListe.Controls.Add(this.labelSchemaList);
            this.panelListe.Controls.Add(this.comboBoxSchemaList);
            this.panelListe.Location = new System.Drawing.Point(24, 113);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(924, 496);
            this.panelListe.TabIndex = 5;
            // 
            // listBoxTableListesi
            // 
            this.listBoxTableListesi.DisplayMember = "FULL_TABLE_NAME";
            this.listBoxTableListesi.FormattingEnabled = true;
            this.listBoxTableListesi.ItemHeight = 16;
            this.listBoxTableListesi.Location = new System.Drawing.Point(193, 68);
            this.listBoxTableListesi.Name = "listBoxTableListesi";
            this.listBoxTableListesi.Size = new System.Drawing.Size(271, 308);
            this.listBoxTableListesi.TabIndex = 3;
            // 
            // labelTabloListesi
            // 
            this.labelTabloListesi.AutoSize = true;
            this.labelTabloListesi.Location = new System.Drawing.Point(20, 65);
            this.labelTabloListesi.Name = "labelTabloListesi";
            this.labelTabloListesi.Size = new System.Drawing.Size(88, 17);
            this.labelTabloListesi.TabIndex = 2;
            this.labelTabloListesi.Text = "Tablo Listesi";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(20, 16);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(103, 17);
            this.labelSchemaList.TabIndex = 1;
            this.labelSchemaList.Text = "Schema Listesi";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "TABLE_SCHEMA";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(197, 18);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(242, 24);
            this.comboBoxSchemaList.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 656);
            this.Controls.Add(this.panelListe);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonTestConnectionString);
            this.Controls.Add(this.textBoxConnectionString);
            this.Controls.Add(this.labelConnectionString);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelListe.ResumeLayout(false);
            this.panelListe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Button buttonTestConnectionString;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Panel panelListe;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Label labelTabloListesi;
        private System.Windows.Forms.ListBox listBoxTableListesi;
    }
}

