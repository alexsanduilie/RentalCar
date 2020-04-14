namespace RentalCarDesktop
{
    partial class List_Cars
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.academy_netDataSet = new RentalCarDesktop.academy_netDataSet();
            this.carsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carsTableAdapter = new RentalCarDesktop.academy_netDataSetTableAdapters.CarsTableAdapter();
            this.carIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricePerDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academy_netDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carIDDataGridViewTextBoxColumn,
            this.plateDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.pricePerDayDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.carsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 489);
            this.dataGridView1.TabIndex = 0;
            // 
            // academy_netDataSet
            // 
            this.academy_netDataSet.DataSetName = "academy_netDataSet";
            this.academy_netDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // carsBindingSource
            // 
            this.carsBindingSource.DataMember = "Cars";
            this.carsBindingSource.DataSource = this.academy_netDataSet;
            // 
            // carsTableAdapter
            // 
            this.carsTableAdapter.ClearBeforeFill = true;
            // 
            // carIDDataGridViewTextBoxColumn
            // 
            this.carIDDataGridViewTextBoxColumn.DataPropertyName = "CarID";
            this.carIDDataGridViewTextBoxColumn.HeaderText = "CarID";
            this.carIDDataGridViewTextBoxColumn.Name = "carIDDataGridViewTextBoxColumn";
            this.carIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plateDataGridViewTextBoxColumn
            // 
            this.plateDataGridViewTextBoxColumn.DataPropertyName = "Plate";
            this.plateDataGridViewTextBoxColumn.HeaderText = "Plate";
            this.plateDataGridViewTextBoxColumn.Name = "plateDataGridViewTextBoxColumn";
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            // 
            // pricePerDayDataGridViewTextBoxColumn
            // 
            this.pricePerDayDataGridViewTextBoxColumn.DataPropertyName = "PricePerDay";
            this.pricePerDayDataGridViewTextBoxColumn.HeaderText = "PricePerDay";
            this.pricePerDayDataGridViewTextBoxColumn.Name = "pricePerDayDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(558, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // List_Cars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 533);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "List_Cars";
            this.Text = "List_Cars";
            this.Load += new System.EventHandler(this.List_Cars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academy_netDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private academy_netDataSet academy_netDataSet;
        private System.Windows.Forms.BindingSource carsBindingSource;
        private academy_netDataSetTableAdapters.CarsTableAdapter carsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn carIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricePerDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}