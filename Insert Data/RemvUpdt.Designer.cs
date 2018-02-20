namespace Insert_Data
{
    partial class RemvUpdt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemvUpdt));
            this.SBCloseButton = new System.Windows.Forms.Button();
            this.lBatteriesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lithium = new Insert_Data.Lithium();
            this.lBatteriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.updt_batts = new System.Windows.Forms.Button();
            this.show_records = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCountID = new System.Windows.Forms.Button();
            this.lBatteriesTableAdapter = new Insert_Data.LithiumTableAdapters.LBatteriesTableAdapter();
            this.removeUpdtBatts = new System.Windows.Forms.DataGridView();
            this.gwdTrackerPM1 = new Insert_Data.GWDTrackerPM();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lBatteriesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lithium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBatteriesBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeUpdtBatts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwdTrackerPM1)).BeginInit();
            this.SuspendLayout();
            // 
            // SBCloseButton
            // 
            this.SBCloseButton.Location = new System.Drawing.Point(419, 3);
            this.SBCloseButton.Name = "SBCloseButton";
            this.SBCloseButton.Size = new System.Drawing.Size(75, 23);
            this.SBCloseButton.TabIndex = 0;
            this.SBCloseButton.Text = "Close";
            this.SBCloseButton.UseVisualStyleBackColor = true;
            this.SBCloseButton.Click += new System.EventHandler(this.SBCloseButton_Click);
            // 
            // lBatteriesBindingSource1
            // 
            this.lBatteriesBindingSource1.DataMember = "LBatteries";
            this.lBatteriesBindingSource1.DataSource = this.lithium;
            // 
            // lithium
            // 
            this.lithium.DataSetName = "Lithium";
            this.lithium.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lBatteriesBindingSource
            // 
            this.lBatteriesBindingSource.DataMember = "LBatteries";
            // 
            // updt_batts
            // 
            this.updt_batts.Location = new System.Drawing.Point(84, 3);
            this.updt_batts.Name = "updt_batts";
            this.updt_batts.Size = new System.Drawing.Size(100, 23);
            this.updt_batts.TabIndex = 2;
            this.updt_batts.Text = "Update data";
            this.updt_batts.UseVisualStyleBackColor = true;
            this.updt_batts.Click += new System.EventHandler(this.updt_batts_Click);
            // 
            // show_records
            // 
            this.show_records.Location = new System.Drawing.Point(3, 3);
            this.show_records.Name = "show_records";
            this.show_records.Size = new System.Drawing.Size(75, 23);
            this.show_records.TabIndex = 3;
            this.show_records.Text = "Show all";
            this.show_records.UseVisualStyleBackColor = true;
            this.show_records.Click += new System.EventHandler(this.show_records_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCountID, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.show_records, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.updt_batts, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.SBCloseButton, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 282);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 39);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonCountID
            // 
            this.buttonCountID.Location = new System.Drawing.Point(190, 3);
            this.buttonCountID.Name = "buttonCountID";
            this.buttonCountID.Size = new System.Drawing.Size(75, 23);
            this.buttonCountID.TabIndex = 0;
            this.buttonCountID.Text = "Count ID";
            this.buttonCountID.UseVisualStyleBackColor = true;
            this.buttonCountID.Click += new System.EventHandler(this.buttonCountID_Click);
            // 
            // lBatteriesTableAdapter
            // 
            this.lBatteriesTableAdapter.ClearBeforeFill = true;
            // 
            // removeUpdtBatts
            // 
            this.removeUpdtBatts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeUpdtBatts.AutoGenerateColumns = false;
            this.removeUpdtBatts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.removeUpdtBatts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.removeUpdtBatts.DataSource = this.lBatteriesBindingSource1;
            this.removeUpdtBatts.Location = new System.Drawing.Point(0, 0);
            this.removeUpdtBatts.Name = "removeUpdtBatts";
            this.removeUpdtBatts.Size = new System.Drawing.Size(498, 282);
            this.removeUpdtBatts.TabIndex = 1;
            // 
            // gwdTrackerPM1
            // 
            this.gwdTrackerPM1.DataSetName = "GWDTrackerPM";
            this.gwdTrackerPM1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "boxN";
            this.dataGridViewTextBoxColumn1.HeaderText = "boxN";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "condition";
            this.dataGridViewTextBoxColumn2.HeaderText = "condition";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "serNum1";
            this.dataGridViewTextBoxColumn3.HeaderText = "serNum1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "serNum2";
            this.dataGridViewTextBoxColumn4.HeaderText = "serNum2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "serNum3";
            this.dataGridViewTextBoxColumn5.HeaderText = "serNum3";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn6.HeaderText = "Date";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn7.HeaderText = "Status";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn8.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // RemvUpdt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.removeUpdtBatts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemvUpdt";
            this.Text = "Remove / Update";
            this.Load += new System.EventHandler(this.RemvUpdt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lBatteriesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lithium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBatteriesBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.removeUpdtBatts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwdTrackerPM1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SBCloseButton;
        private System.Windows.Forms.BindingSource lBatteriesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conditionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serNum1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serNum2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serNum3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button updt_batts;
        private System.Windows.Forms.Button show_records;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Lithium lithium;
        private System.Windows.Forms.BindingSource lBatteriesBindingSource1;
        private LithiumTableAdapters.LBatteriesTableAdapter lBatteriesTableAdapter;
        private System.Windows.Forms.Button buttonCountID;
        private System.Windows.Forms.DataGridView removeUpdtBatts;
        private GWDTrackerPM gwdTrackerPM1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}