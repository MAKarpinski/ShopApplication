namespace ShopApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDBConnect = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnChangeSettings = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnEditRow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txbEan = new System.Windows.Forms.TextBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbVal = new System.Windows.Forms.TextBox();
            this.txbTax = new System.Windows.Forms.TextBox();
            this.txbId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDBConnect
            // 
            this.btnDBConnect.Enabled = false;
            this.btnDBConnect.Location = new System.Drawing.Point(209, 26);
            this.btnDBConnect.Name = "btnDBConnect";
            this.btnDBConnect.Size = new System.Drawing.Size(181, 68);
            this.btnDBConnect.TabIndex = 0;
            this.btnDBConnect.Text = "Połącz z Bazą";
            this.btnDBConnect.UseVisualStyleBackColor = true;
            this.btnDBConnect.Visible = false;
            this.btnDBConnect.Click += new System.EventHandler(this.btnDBConnect_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Enabled = false;
            this.btnAddTable.Location = new System.Drawing.Point(396, 26);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(181, 68);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "Dodaj Bazę";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Visible = false;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(758, 255);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // btnChangeSettings
            // 
            this.btnChangeSettings.Location = new System.Drawing.Point(22, 26);
            this.btnChangeSettings.Name = "btnChangeSettings";
            this.btnChangeSettings.Size = new System.Drawing.Size(181, 68);
            this.btnChangeSettings.TabIndex = 3;
            this.btnChangeSettings.Text = "Ustawienia";
            this.btnChangeSettings.UseVisualStyleBackColor = true;
            this.btnChangeSettings.Click += new System.EventHandler(this.btnChangeSettings_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(650, 411);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(130, 37);
            this.btnDeleteRow.TabIndex = 4;
            this.btnDeleteRow.Text = "Usuń";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(514, 411);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(130, 37);
            this.btnAddRow.TabIndex = 5;
            this.btnAddRow.Text = "Dodaj";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnEditRow
            // 
            this.btnEditRow.Location = new System.Drawing.Point(378, 411);
            this.btnEditRow.Name = "btnEditRow";
            this.btnEditRow.Size = new System.Drawing.Size(130, 37);
            this.btnEditRow.TabIndex = 6;
            this.btnEditRow.Text = "Edytuj";
            this.btnEditRow.UseVisualStyleBackColor = true;
            this.btnEditRow.Click += new System.EventHandler(this.btnEditRow_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(583, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(181, 68);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txbEan
            // 
            this.txbEan.Location = new System.Drawing.Point(290, 373);
            this.txbEan.Name = "txbEan";
            this.txbEan.Size = new System.Drawing.Size(100, 20);
            this.txbEan.TabIndex = 8;
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(170, 373);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(100, 20);
            this.txbName.TabIndex = 9;
            // 
            // txbVal
            // 
            this.txbVal.Location = new System.Drawing.Point(477, 373);
            this.txbVal.Name = "txbVal";
            this.txbVal.Size = new System.Drawing.Size(100, 20);
            this.txbVal.TabIndex = 10;
            // 
            // txbTax
            // 
            this.txbTax.Location = new System.Drawing.Point(595, 373);
            this.txbTax.Name = "txbTax";
            this.txbTax.Size = new System.Drawing.Size(100, 20);
            this.txbTax.TabIndex = 11;
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(62, 373);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(62, 20);
            this.txbId.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 450);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.txbTax);
            this.Controls.Add(this.txbVal);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.txbEan);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEditRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.btnChangeSettings);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.btnDBConnect);
            this.Name = "MainForm";
            this.Text = "Główna";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDBConnect;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnChangeSettings;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnEditRow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txbEan;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.TextBox txbVal;
        private System.Windows.Forms.TextBox txbTax;
        private System.Windows.Forms.TextBox txbId;
    }
}

