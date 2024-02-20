namespace CarRentalApp
{
    partial class ManageRentalRecords
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteRentalRecord = new System.Windows.Forms.Button();
            this.btnEditRentalRecord = new System.Windows.Forms.Button();
            this.btnAddRentalRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvRecordList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(890, 559);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(213, 65);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteRentalRecord
            // 
            this.btnDeleteRentalRecord.Location = new System.Drawing.Point(492, 559);
            this.btnDeleteRentalRecord.Name = "btnDeleteRentalRecord";
            this.btnDeleteRentalRecord.Size = new System.Drawing.Size(213, 65);
            this.btnDeleteRentalRecord.TabIndex = 10;
            this.btnDeleteRentalRecord.Text = "Delete Record";
            this.btnDeleteRentalRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRentalRecord.Click += new System.EventHandler(this.btnDeleteRentalRecord_Click);
            // 
            // btnEditRentalRecord
            // 
            this.btnEditRentalRecord.Location = new System.Drawing.Point(256, 559);
            this.btnEditRentalRecord.Name = "btnEditRentalRecord";
            this.btnEditRentalRecord.Size = new System.Drawing.Size(213, 65);
            this.btnEditRentalRecord.TabIndex = 9;
            this.btnEditRentalRecord.Text = "Edit Record";
            this.btnEditRentalRecord.UseVisualStyleBackColor = true;
            this.btnEditRentalRecord.Click += new System.EventHandler(this.btnEditRentalRecord_Click);
            // 
            // btnAddRentalRecord
            // 
            this.btnAddRentalRecord.Location = new System.Drawing.Point(20, 559);
            this.btnAddRentalRecord.Name = "btnAddRentalRecord";
            this.btnAddRentalRecord.Size = new System.Drawing.Size(213, 65);
            this.btnAddRentalRecord.TabIndex = 8;
            this.btnAddRentalRecord.Text = "Add New Record";
            this.btnAddRentalRecord.UseVisualStyleBackColor = true;
            this.btnAddRentalRecord.Click += new System.EventHandler(this.btnAddRentalRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 55);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manage Rental Records";
            // 
            // gvRecordList
            // 
            this.gvRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRecordList.Location = new System.Drawing.Point(20, 129);
            this.gvRecordList.Name = "gvRecordList";
            this.gvRecordList.RowHeadersWidth = 82;
            this.gvRecordList.RowTemplate.Height = 33;
            this.gvRecordList.Size = new System.Drawing.Size(1083, 414);
            this.gvRecordList.TabIndex = 6;
            // 
            // ManageRentalRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 656);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteRentalRecord);
            this.Controls.Add(this.btnEditRentalRecord);
            this.Controls.Add(this.btnAddRentalRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvRecordList);
            this.Name = "ManageRentalRecords";
            this.Text = "Manage Rental Records";
            this.Load += new System.EventHandler(this.ManageRentalRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteRentalRecord;
        private System.Windows.Forms.Button btnEditRentalRecord;
        private System.Windows.Forms.Button btnAddRentalRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvRecordList;
    }
}