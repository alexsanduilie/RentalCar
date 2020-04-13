namespace RentalCarDesktop
{
    partial class List_Customers
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
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academy_netDataSet = new RentalCarDesktop.academy_netDataSet();
            this.customersTableAdapter = new RentalCarDesktop.academy_netDataSetTableAdapters.CustomersTableAdapter();
            this.academynetDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reservationsCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reservationsTableAdapter = new RentalCarDesktop.academy_netDataSetTableAdapters.ReservationsTableAdapter();
            this.customersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.customersBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.customersBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.academynetDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.customersBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.costumerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zIPCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customersBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            //this.academy_netDataSet1 = new RentalCarDesktop.academy_netDataSet();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academy_netDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academynetDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationsCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academynetDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource5)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.academy_netDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "Customers";
            this.customersBindingSource.DataSource = this.academy_netDataSet;
            // 
            // academy_netDataSet
            // 
            this.academy_netDataSet.DataSetName = "academy_netDataSet";
            this.academy_netDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // academynetDataSetBindingSource
            // 
            this.academynetDataSetBindingSource.DataSource = this.academy_netDataSet;
            this.academynetDataSetBindingSource.Position = 0;
            // 
            // reservationsCustomersBindingSource
            // 
            this.reservationsCustomersBindingSource.DataMember = "Reservations_Customers";
            this.reservationsCustomersBindingSource.DataSource = this.customersBindingSource;
            // 
            // reservationsTableAdapter
            // 
            this.reservationsTableAdapter.ClearBeforeFill = true;
            // 
            // customersBindingSource1
            // 
            this.customersBindingSource1.DataMember = "Customers";
            this.customersBindingSource1.DataSource = this.academy_netDataSet;
            // 
            // customersBindingSource2
            // 
            this.customersBindingSource2.DataMember = "Customers";
            this.customersBindingSource2.DataSource = this.academy_netDataSet;
            // 
            // customersBindingSource3
            // 
            this.customersBindingSource3.DataMember = "Customers";
            this.customersBindingSource3.DataSource = this.academynetDataSetBindingSource;
            // 
            // academynetDataSetBindingSource1
            // 
            this.academynetDataSetBindingSource1.DataSource = this.academy_netDataSet;
            this.academynetDataSetBindingSource1.Position = 0;
            // 
            // customersBindingSource4
            // 
            this.customersBindingSource4.DataMember = "Customers";
            this.customersBindingSource4.DataSource = this.academy_netDataSet;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.costumerIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.birthDateDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.zIPCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.customersBindingSource5;
            this.dataGridView1.Location = new System.Drawing.Point(2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(519, 489);
            this.dataGridView1.TabIndex = 0;
            // 
            // costumerIDDataGridViewTextBoxColumn
            // 
            this.costumerIDDataGridViewTextBoxColumn.DataPropertyName = "CostumerID";
            this.costumerIDDataGridViewTextBoxColumn.HeaderText = "CostumerID";
            this.costumerIDDataGridViewTextBoxColumn.Name = "costumerIDDataGridViewTextBoxColumn";
            this.costumerIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // birthDateDataGridViewTextBoxColumn
            // 
            this.birthDateDataGridViewTextBoxColumn.DataPropertyName = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.HeaderText = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.Name = "birthDateDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // zIPCodeDataGridViewTextBoxColumn
            // 
            this.zIPCodeDataGridViewTextBoxColumn.DataPropertyName = "ZIPCode";
            this.zIPCodeDataGridViewTextBoxColumn.HeaderText = "ZIPCode";
            this.zIPCodeDataGridViewTextBoxColumn.Name = "zIPCodeDataGridViewTextBoxColumn";
            // 
            // customersBindingSource5
            // 
            this.customersBindingSource5.DataMember = "Customers";
            this.customersBindingSource5.DataSource = this.academy_netDataSet;
            // 
            // academy_netDataSet
            // 
            this.academy_netDataSet.DataSetName = "academy_netDataSet";
            this.academy_netDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(427, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // List_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 533);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "List_Customers";
            this.Text = "List_Customers";
            this.Load += new System.EventHandler(this.List_Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academy_netDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academynetDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationsCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academynetDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource5)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.academy_netDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private academy_netDataSet academy_netDataSet;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private academy_netDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private System.Windows.Forms.BindingSource academynetDataSetBindingSource;
        private System.Windows.Forms.BindingSource reservationsCustomersBindingSource;
        private academy_netDataSetTableAdapters.ReservationsTableAdapter reservationsTableAdapter;
        private System.Windows.Forms.BindingSource customersBindingSource1;
        private System.Windows.Forms.BindingSource customersBindingSource2;
        private System.Windows.Forms.BindingSource customersBindingSource3;
        private System.Windows.Forms.BindingSource academynetDataSetBindingSource1;
        private System.Windows.Forms.BindingSource customersBindingSource4;
        private System.Windows.Forms.DataGridView dataGridView1;
        //private academy_netDataSet academy_netDataSet1;
        private System.Windows.Forms.BindingSource customersBindingSource5;
        private System.Windows.Forms.DataGridViewTextBoxColumn costumerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zIPCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}