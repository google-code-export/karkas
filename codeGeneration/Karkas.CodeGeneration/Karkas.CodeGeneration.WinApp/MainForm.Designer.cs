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
            this.checkBoxSysTablolariniAtla = new System.Windows.Forms.CheckBox();
            this.checkBoxDboSemasiniAtla = new System.Windows.Forms.CheckBox();
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
            this.textBoxDatabaseName = new System.Windows.Forms.TextBox();
            this.buttonOtherConnections = new System.Windows.Forms.Button();
            this.comboBoxDatabaseType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKisaltmalar = new System.Windows.Forms.Button();
            this.panelListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(16, 28);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(91, 13);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection String";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(154, 28);
            this.textBoxConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(469, 20);
            this.textBoxConnectionString.TabIndex = 2;
            // 
            // buttonTestConnectionString
            // 
            this.buttonTestConnectionString.Location = new System.Drawing.Point(634, 26);
            this.buttonTestConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestConnectionString.Name = "buttonTestConnectionString";
            this.buttonTestConnectionString.Size = new System.Drawing.Size(77, 20);
            this.buttonTestConnectionString.TabIndex = 3;
            this.buttonTestConnectionString.Text = "test";
            this.buttonTestConnectionString.UseVisualStyleBackColor = true;
            this.buttonTestConnectionString.Click += new System.EventHandler(this.buttonTestConnectionString_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(16, 209);
            this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(102, 13);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Bağlantı Denenmedi";
            // 
            // panelListe
            // 
            this.panelListe.Controls.Add(this.checkBoxSysTablolariniAtla);
            this.panelListe.Controls.Add(this.checkBoxDboSemasiniAtla);
            this.panelListe.Controls.Add(this.buttonSeciliTablolariUret);
            this.panelListe.Controls.Add(this.buttonTumTablolariUret);
            this.panelListe.Controls.Add(this.listBoxTableListesi);
            this.panelListe.Controls.Add(this.labelTabloListesi);
            this.panelListe.Controls.Add(this.labelSchemaList);
            this.panelListe.Controls.Add(this.comboBoxSchemaList);
            this.panelListe.Location = new System.Drawing.Point(9, 288);
            this.panelListe.Margin = new System.Windows.Forms.Padding(2);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(693, 346);
            this.panelListe.TabIndex = 5;
            // 
            // checkBoxSysTablolariniAtla
            // 
            this.checkBoxSysTablolariniAtla.AutoSize = true;
            this.checkBoxSysTablolariniAtla.Checked = true;
            this.checkBoxSysTablolariniAtla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSysTablolariniAtla.Location = new System.Drawing.Point(560, 114);
            this.checkBoxSysTablolariniAtla.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSysTablolariniAtla.Name = "checkBoxSysTablolariniAtla";
            this.checkBoxSysTablolariniAtla.Size = new System.Drawing.Size(113, 17);
            this.checkBoxSysTablolariniAtla.TabIndex = 7;
            this.checkBoxSysTablolariniAtla.Text = "sys Tablolarını Atla";
            this.checkBoxSysTablolariniAtla.UseVisualStyleBackColor = true;
            // 
            // checkBoxDboSemasiniAtla
            // 
            this.checkBoxDboSemasiniAtla.AutoSize = true;
            this.checkBoxDboSemasiniAtla.Checked = true;
            this.checkBoxDboSemasiniAtla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDboSemasiniAtla.Location = new System.Drawing.Point(560, 83);
            this.checkBoxDboSemasiniAtla.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxDboSemasiniAtla.Name = "checkBoxDboSemasiniAtla";
            this.checkBoxDboSemasiniAtla.Size = new System.Drawing.Size(108, 17);
            this.checkBoxDboSemasiniAtla.TabIndex = 6;
            this.checkBoxDboSemasiniAtla.Text = "dbo şemasını Atla";
            this.checkBoxDboSemasiniAtla.UseVisualStyleBackColor = true;
            // 
            // buttonSeciliTablolariUret
            // 
            this.buttonSeciliTablolariUret.Location = new System.Drawing.Point(227, 313);
            this.buttonSeciliTablolariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeciliTablolariUret.Name = "buttonSeciliTablolariUret";
            this.buttonSeciliTablolariUret.Size = new System.Drawing.Size(121, 31);
            this.buttonSeciliTablolariUret.TabIndex = 5;
            this.buttonSeciliTablolariUret.Text = "Seçili Tablolari Üret";
            this.buttonSeciliTablolariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliTablolariUret.Click += new System.EventHandler(this.buttonSeciliTablolariUret_Click);
            // 
            // buttonTumTablolariUret
            // 
            this.buttonTumTablolariUret.Location = new System.Drawing.Point(560, 153);
            this.buttonTumTablolariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTumTablolariUret.Name = "buttonTumTablolariUret";
            this.buttonTumTablolariUret.Size = new System.Drawing.Size(121, 23);
            this.buttonTumTablolariUret.TabIndex = 4;
            this.buttonTumTablolariUret.Text = "Tüm Tabloları Üret";
            this.buttonTumTablolariUret.UseVisualStyleBackColor = true;
            this.buttonTumTablolariUret.Click += new System.EventHandler(this.buttonTumTablolariUret_Click);
            // 
            // listBoxTableListesi
            // 
            this.listBoxTableListesi.DisplayMember = "FULL_TABLE_NAME";
            this.listBoxTableListesi.FormattingEnabled = true;
            this.listBoxTableListesi.Location = new System.Drawing.Point(145, 55);
            this.listBoxTableListesi.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTableListesi.Name = "listBoxTableListesi";
            this.listBoxTableListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTableListesi.Size = new System.Drawing.Size(204, 251);
            this.listBoxTableListesi.TabIndex = 3;
            // 
            // labelTabloListesi
            // 
            this.labelTabloListesi.AutoSize = true;
            this.labelTabloListesi.Location = new System.Drawing.Point(15, 53);
            this.labelTabloListesi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTabloListesi.Name = "labelTabloListesi";
            this.labelTabloListesi.Size = new System.Drawing.Size(66, 13);
            this.labelTabloListesi.TabIndex = 2;
            this.labelTabloListesi.Text = "Tablo Listesi";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(15, 13);
            this.labelSchemaList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(78, 13);
            this.labelSchemaList.TabIndex = 1;
            this.labelSchemaList.Text = "Schema Listesi";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "TABLE_SCHEMA";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(148, 15);
            this.comboBoxSchemaList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(182, 21);
            this.comboBoxSchemaList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code Generation Dizini";
            // 
            // textBoxCodeGenerationDizini
            // 
            this.textBoxCodeGenerationDizini.Location = new System.Drawing.Point(154, 56);
            this.textBoxCodeGenerationDizini.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCodeGenerationDizini.Name = "textBoxCodeGenerationDizini";
            this.textBoxCodeGenerationDizini.Size = new System.Drawing.Size(468, 20);
            this.textBoxCodeGenerationDizini.TabIndex = 7;
            // 
            // buttonFolderDialog
            // 
            this.buttonFolderDialog.Location = new System.Drawing.Point(634, 52);
            this.buttonFolderDialog.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFolderDialog.Name = "buttonFolderDialog";
            this.buttonFolderDialog.Size = new System.Drawing.Size(38, 24);
            this.buttonFolderDialog.TabIndex = 8;
            this.buttonFolderDialog.Text = "...";
            this.buttonFolderDialog.UseVisualStyleBackColor = true;
            this.buttonFolderDialog.Click += new System.EventHandler(this.buttonFolderDialog_Click);
            // 
            // labelProjectNamespace
            // 
            this.labelProjectNamespace.AutoSize = true;
            this.labelProjectNamespace.Location = new System.Drawing.Point(16, 84);
            this.labelProjectNamespace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProjectNamespace.Name = "labelProjectNamespace";
            this.labelProjectNamespace.Size = new System.Drawing.Size(100, 13);
            this.labelProjectNamespace.TabIndex = 9;
            this.labelProjectNamespace.Text = "Project Namespace";
            // 
            // textBoxProjectNamespace
            // 
            this.textBoxProjectNamespace.Location = new System.Drawing.Point(154, 84);
            this.textBoxProjectNamespace.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProjectNamespace.Name = "textBoxProjectNamespace";
            this.textBoxProjectNamespace.Size = new System.Drawing.Size(466, 20);
            this.textBoxProjectNamespace.TabIndex = 10;
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.AutoSize = true;
            this.labelDatabaseName.Location = new System.Drawing.Point(16, 111);
            this.labelDatabaseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(103, 13);
            this.labelDatabaseName.TabIndex = 11;
            this.labelDatabaseName.Text = "labelDatabaseName";
            // 
            // labelDatabaseNameSonuc
            // 
            this.labelDatabaseNameSonuc.AutoSize = true;
            this.labelDatabaseNameSonuc.Location = new System.Drawing.Point(154, 111);
            this.labelDatabaseNameSonuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatabaseNameSonuc.Name = "labelDatabaseNameSonuc";
            this.labelDatabaseNameSonuc.Size = new System.Drawing.Size(0, 13);
            this.labelDatabaseNameSonuc.TabIndex = 12;
            // 
            // buttonGecerliDegerleriKaydet
            // 
            this.buttonGecerliDegerleriKaydet.Location = new System.Drawing.Point(556, 209);
            this.buttonGecerliDegerleriKaydet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGecerliDegerleriKaydet.Name = "buttonGecerliDegerleriKaydet";
            this.buttonGecerliDegerleriKaydet.Size = new System.Drawing.Size(146, 55);
            this.buttonGecerliDegerleriKaydet.TabIndex = 13;
            this.buttonGecerliDegerleriKaydet.Text = "Geçerli Değerleri Kaydet";
            this.buttonGecerliDegerleriKaydet.UseVisualStyleBackColor = true;
            this.buttonGecerliDegerleriKaydet.Click += new System.EventHandler(this.buttonGecerliDegerleriKaydet_Click);
            // 
            // textBoxDatabaseName
            // 
            this.textBoxDatabaseName.Location = new System.Drawing.Point(154, 111);
            this.textBoxDatabaseName.Name = "textBoxDatabaseName";
            this.textBoxDatabaseName.Size = new System.Drawing.Size(127, 20);
            this.textBoxDatabaseName.TabIndex = 14;
            // 
            // buttonOtherConnections
            // 
            this.buttonOtherConnections.Location = new System.Drawing.Point(556, 107);
            this.buttonOtherConnections.Name = "buttonOtherConnections";
            this.buttonOtherConnections.Size = new System.Drawing.Size(146, 23);
            this.buttonOtherConnections.TabIndex = 15;
            this.buttonOtherConnections.Text = "Diğer Bağlantılar";
            this.buttonOtherConnections.UseVisualStyleBackColor = true;
            this.buttonOtherConnections.Click += new System.EventHandler(this.buttonOtherConnections_Click);
            // 
            // comboBoxDatabaseType
            // 
            this.comboBoxDatabaseType.FormattingEnabled = true;
            this.comboBoxDatabaseType.Location = new System.Drawing.Point(154, 150);
            this.comboBoxDatabaseType.Name = "comboBoxDatabaseType";
            this.comboBoxDatabaseType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDatabaseType.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Veritabanı Tipi";
            // 
            // buttonKisaltmalar
            // 
            this.buttonKisaltmalar.Location = new System.Drawing.Point(556, 155);
            this.buttonKisaltmalar.Name = "buttonKisaltmalar";
            this.buttonKisaltmalar.Size = new System.Drawing.Size(146, 23);
            this.buttonKisaltmalar.TabIndex = 18;
            this.buttonKisaltmalar.Text = "Kısaltmalar";
            this.buttonKisaltmalar.UseVisualStyleBackColor = true;
            this.buttonKisaltmalar.Click += new System.EventHandler(this.buttonKisaltmalar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 679);
            this.Controls.Add(this.buttonKisaltmalar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDatabaseType);
            this.Controls.Add(this.buttonOtherConnections);
            this.Controls.Add(this.textBoxDatabaseName);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.CheckBox checkBoxSysTablolariniAtla;
        private System.Windows.Forms.CheckBox checkBoxDboSemasiniAtla;
        private System.Windows.Forms.TextBox textBoxDatabaseName;
        private System.Windows.Forms.Button buttonOtherConnections;
        private System.Windows.Forms.ComboBox comboBoxDatabaseType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKisaltmalar;
    }
}

