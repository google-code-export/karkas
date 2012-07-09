namespace Karkas.CodeGeneration.WinApp
{
    partial class FormConnectionList
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
            this.listBoxConnectionList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxConnectionList
            // 
            this.listBoxConnectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxConnectionList.FormattingEnabled = true;
            this.listBoxConnectionList.Location = new System.Drawing.Point(0, 0);
            this.listBoxConnectionList.Name = "listBoxConnectionList";
            this.listBoxConnectionList.Size = new System.Drawing.Size(639, 509);
            this.listBoxConnectionList.TabIndex = 0;
            this.listBoxConnectionList.DoubleClick += new System.EventHandler(this.listBoxConnectionList_DoubleClick);
            // 
            // FormConnectionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 509);
            this.Controls.Add(this.listBoxConnectionList);
            this.Name = "FormConnectionList";
            this.Text = "FormConnectionList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConnectionList;

    }
}