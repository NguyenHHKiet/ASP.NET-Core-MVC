namespace AdvancedDocking
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basicTestDataSet = new AdvancedDocking.basicTestDataSet();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSupport = new System.Windows.Forms.Button();
            this.btnActions = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.employeeTableAdapter = new AdvancedDocking.basicTestDataSetTableAdapters.EmployeeTableAdapter();
            this.employeeFlexGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicTestDataSet)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeFlexGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.basicTestDataSet;
            // 
            // basicTestDataSet
            // 
            this.basicTestDataSet.DataSetName = "basicTestDataSet";
            this.basicTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.EditMenuItem,
            this.xemToolStripMenuItem,
            this.DeleteMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 128);
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewMenuItem.Size = new System.Drawing.Size(168, 24);
            this.NewMenuItem.Text = "Thêm";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditMenuItem.Size = new System.Drawing.Size(168, 24);
            this.EditMenuItem.Text = "Sửa";
            this.EditMenuItem.Click += new System.EventHandler(this.EditMenuItem_Click);
            // 
            // xemToolStripMenuItem
            // 
            this.xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            this.xemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.xemToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.xemToolStripMenuItem.Text = "Xem";
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DeleteMenuItem.Size = new System.Drawing.Size(210, 24);
            this.DeleteMenuItem.Text = "Xóa";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // btnSupport
            // 
            this.btnSupport.Location = new System.Drawing.Point(12, 418);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Size = new System.Drawing.Size(90, 41);
            this.btnSupport.TabIndex = 2;
            this.btnSupport.Text = "Hỗ trợ";
            this.btnSupport.UseVisualStyleBackColor = true;
            // 
            // btnActions
            // 
            this.btnActions.ContextMenuStrip = this.contextMenuStrip1;
            this.btnActions.Location = new System.Drawing.Point(675, 418);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(90, 41);
            this.btnActions.TabIndex = 3;
            this.btnActions.Text = "Thực hiện";
            this.btnActions.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(771, 418);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 41);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // employeeFlexGrid
            // 
            this.employeeFlexGrid.AllowDelete = true;
            this.employeeFlexGrid.ColumnInfo = resources.GetString("employeeFlexGrid.ColumnInfo");
            this.employeeFlexGrid.DataSource = this.employeeBindingSource;
            this.employeeFlexGrid.Location = new System.Drawing.Point(12, 12);
            this.employeeFlexGrid.Name = "employeeFlexGrid";
            this.employeeFlexGrid.Rows.Count = 1;
            this.employeeFlexGrid.Size = new System.Drawing.Size(849, 400);
            this.employeeFlexGrid.StyleInfo = resources.GetString("employeeFlexGrid.StyleInfo");
            this.employeeFlexGrid.TabIndex = 0;
            this.employeeFlexGrid.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            this.employeeFlexGrid.Click += new System.EventHandler(this.employeeFlexGrid_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 471);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActions);
            this.Controls.Add(this.btnSupport);
            this.Controls.Add(this.employeeFlexGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Danh sách ";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicTestDataSet)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeFlexGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnSupport;
        private System.Windows.Forms.Button btnActions;
        private System.Windows.Forms.Button btnClose;
        private basicTestDataSet basicTestDataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private basicTestDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private C1.Win.C1FlexGrid.C1FlexGrid employeeFlexGrid;
    }
}

