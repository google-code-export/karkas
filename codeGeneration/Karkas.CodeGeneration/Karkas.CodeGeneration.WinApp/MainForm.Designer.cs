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
            this.buttonSeciliTablolariUret = new System.Windows.Forms.Button();
            this.buttonTumTablolariUret = new System.Windows.Forms.Button();
            this.listBoxTableListesi = new System.Windows.Forms.ListBox();
            this.labelTabloListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCodeGenerationDizini = new System.Windows.Forms.TextBox();
            this.buttonFolderDialog = new System.Windows.Forms.Button();
            this.labelProjectNamespace = new System.Windows.Forms.Label();
            this.textBoxProjectNamespace = new System.Windows.Forms.TextBox();
            this.labelDatabaseName = new System.Windows.Forms.Label();
            this.labelDatabaseNameSonuc = new System.Windows.Forms.Label();
            this.buttonGecerliDegerleriKaydet = new System.Windows.Forms.Button();
            this.panelListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(21, 35);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(120, 17);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection String";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(206, 35);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(624, 22);
            this.textBoxConnectionString.TabIndex = 2;
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
            this.labelConnectionStatus.Location = new System.Drawing.Point(21, 171);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(135, 17);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Bağlantı Denenmedi";
            // 
            // panelListe
            // 
            this.panelListe.Controls.Add(this.buttonSeciliTablolariUret);
            this.panelListe.Controls.Add(this.buttonTumTablolariUret);
            this.panelListe.Controls.Add(this.listBoxTableListesi);
            this.panelListe.Controls.Add(this.labelTabloListesi);
            this.panelListe.Controls.Add(this.labelSchemaList);
            this.panelListe.Controls.Add(this.comboBoxSchemaList);
            this.panelListe.Location = new System.Drawing.Point(12, 218);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(924, 426);
            this.panelListe.TabIndex = 5;
            // 
            // buttonSeciliTablolariUret
            // 
            this.buttonSeciliTablolariUret.Location = new System.Drawing.Point(571, 127);
            this.buttonSeciliTablolariUret.Name = "buttonSeciliTablolariUret";
            this.buttonSeciliTablolariUret.Size = new System.Drawing.Size(161, 38);
            this.buttonSeciliTablolariUret.TabIndex = 5;
            this.buttonSeciliTablolariUret.Text = "Seçili Tablolari Üret";
            this.buttonSeciliTablolariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliTablolariUret.Click += new System.EventHandler(this.buttonSeciliTablolariUret_Click);
            // 
            // buttonTumTablolariUret
            // 
            this.buttonTumTablolariUret.Location = new System.Drawing.Point(572, 79);
            this.buttonTumTablolariUret.Name = "buttonTumTablolariUret";
            this.buttonTumTablolariUret.Size = new System.Drawing.Size(161, 28);
            this.buttonTumTablolariUret.TabIndex = 4;
            this.buttonTumTablolariUret.Text = "Tüm Tabloları Üret";
            this.buttonTumTablolariUret.UseVisualStyleBackColor = true;
            this.buttonTumTablolariUret.Click += new System.EventHandler(this.buttonTumTablolariUret_Click);
            // 
            // listBoxTableListesi
            // 
            this.listBoxTableListesi.DisplayMember = "FULL_TABLE_NAME";
            this.listBoxTableListesi.FormattingEnabled = true;
            this.listBoxTableListesi.ItemHeight = 16;
            this.listBoxTableListesi.Location = new System.Drawing.Point(193, 68);
            this.listBoxTableListesi.Name = "listBoxTableListesi";
            this.listBoxTableListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code Generation Dizini";
            // 
            // textBoxCodeGenerationDizini
            // 
            this.textBoxCodeGenerationDizini.Location = new System.Drawing.Point(206, 69);
            this.textBoxCodeGenerationDizini.Name = "textBoxCodeGenerationDizini";
            this.textBoxCodeGenerationDizini.Size = new System.Drawing.Size(623, 22);
            this.textBoxCodeGenerationDizini.TabIndex = 7;
            // 
            // buttonFolderDialog
            // 
            this.buttonFolderDialog.Location = new System.Drawing.Point(846, 64);
            this.buttonFolderDialog.Name = "buttonFolderDialog";
            this.buttonFolderDialog.Size = new System.Drawing.Size(50, 29);
            this.buttonFolderDialog.TabIndex = 8;
            this.buttonFolderDialog.Text = "...";
            this.buttonFolderDialog.UseVisualStyleBackColor = true;
            this.buttonFolderDialog.Click += new System.EventHandler(this.buttonFolderDialog_Click);
            // 
            // labelProjectNamespace
            // 
            this.labelProjectNamespace.AutoSize = true;
            this.labelProjectNamespace.Location = new System.Drawing.Point(21, 103);
            this.labelProjectNamespace.Name = "labelProjectNamespace";
            this.labelProjectNamespace.Size = new System.Drawing.Size(131, 17);
            this.labelProjectNamespace.TabIndex = 9;
            this.labelProjectNamespace.Text = "Project Namespace";
            // 
            // textBoxProjectNamespace
            // 
            this.textBoxProjectNamespace.Location = new System.Drawing.Point(206, 103);
            this.textBoxProjectNamespace.Name = "textBoxProjectNamespace";
            this.textBoxProjectNamespace.Size = new System.Drawing.Size(620, 22);
            this.textBoxProjectNamespace.TabIndex = 10;
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.AutoSize = true;
            this.labelDatabaseName.Location = new System.Drawing.Point(21, 137);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(136, 17);
            this.labelDatabaseName.TabIndex = 11;
            this.labelDatabaseName.Text = "labelDatabaseName";
            // 
            // labelDatabaseNameSonuc
            // 
            this.labelDatabaseNameSonuc.AutoSize = true;
            this.labelDatabaseNameSonuc.Location = new System.Drawing.Point(206, 137);
            this.labelDatabaseNameSonuc.Name = "labelDatabaseNameSonuc";
            this.labelDatabaseNameSonuc.Size = new System.Drawing.Size(0, 17);
            this.labelDatabaseNameSonuc.TabIndex = 12;
            // 
            // buttonGecerliDegerleriKaydet
            // 
            this.buttonGecerliDegerleriKaydet.Location = new System.Drawing.Point(741, 184);
            this.buttonGecerliDegerleriKaydet.Name = "buttonGecerliDegerleriKaydet";
            this.buttonGecerliDegerleriKaydet.Size = new System.Drawing.Size(195, 28);
            this.buttonGecerliDegerleriKaydet.TabIndex = 13;
            this.buttonGecerliDegerleriKaydet.Text = "Geçerli Değerleri Kaydet";
            this.buttonGecerliDegerleriKaydet.UseVisualStyleBackColor = true;
            this.buttonGecerliDegerleriKaydet.Click += new System.EventHandler(this.buttonGecerliDegerleriKaydet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 656);
            this.Controls.Add(this.buttonGecerliDegerleriKaydet);
            this.Controls.Add(this.labelDatabaseNameSonuc);
            this.Controls.Add(this.labelDatabaseName);
            this.Controls.Add(this.textBoxProjectNamespace);
            this.Controls.Add(this.labelProjectNamespace);
            this.Controls.Add(this.buttonFolderDialog);
            this.Controls.Add(this.textBoxCodeGenerationDizini);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCodeGenerationDizini;
        private System.Windows.Forms.Button buttonFolderDialog;
        private System.Windows.Forms.Button buttonSeciliTablolariUret;
        private System.Windows.Forms.Button buttonTumTablolariUret;
        private System.Windows.Forms.Label labelProjectNamespace;
        private System.Windows.Forms.TextBox textBoxProjectNamespace;
        private System.Windows.Forms.Label labelDatabaseName;
        private System.Windows.Forms.Label labelDatabaseNameSonuc;
        private System.Windows.Forms.Button buttonGecerliDegerleriKaydet;
    }
}

