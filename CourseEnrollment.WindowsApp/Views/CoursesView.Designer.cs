namespace CourseEnrollment.WindowsApp.Views
{
    partial class CoursesView
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            tsbAdd = new ToolStripButton();
            tsbEdit = new ToolStripButton();
            tsbView = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            tsbRefresh = new ToolStripButton();
            pnlFilter = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            dgvCourses = new DataGridView();
            chartCourses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStrip.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCourses).BeginInit();
            SuspendLayout();
            //
            // toolStrip
            //
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbAdd, tsbEdit, tsbView, tsbDelete, toolStripSeparator1, tsbRefresh });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(700, 27);
            toolStrip.TabIndex = 2;
            //
            // tsbAdd
            //
            tsbAdd.Image = Properties.Resources.add;
            tsbAdd.Name = "tsbAdd";
            tsbAdd.Size = new Size(61, 24);
            tsbAdd.Text = "Add";
            tsbAdd.Click += tsbAdd_Click;
            //
            // tsbEdit
            //
            tsbEdit.Image = Properties.Resources.edit;
            tsbEdit.Name = "tsbEdit";
            tsbEdit.Size = new Size(59, 24);
            tsbEdit.Text = "Edit";
            tsbEdit.Click += tsbEdit_Click;
            //
            // tsbView
            //
            tsbView.Image = Properties.Resources.view;
            tsbView.Name = "tsbView";
            tsbView.Size = new Size(65, 24);
            tsbView.Text = "View";
            tsbView.Click += tsbView_Click;
            //
            // tsbDelete
            //
            tsbDelete.Image = Properties.Resources.delete;
            tsbDelete.Name = "tsbDelete";
            tsbDelete.Size = new Size(77, 24);
            tsbDelete.Text = "Delete";
            tsbDelete.Click += tsbDelete_Click;
            //
            // tsbRefresh
            //
            tsbRefresh.Image = Properties.Resources.refresh;
            tsbRefresh.Name = "tsbRefresh";
            tsbRefresh.Size = new Size(82, 24);
            tsbRefresh.Text = "Refresh";
            tsbRefresh.Click += tsbRefresh_Click;
            //
            // pnlFilter
            //
            pnlFilter.Controls.Add(lblSearch);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(lblDepartment);
            pnlFilter.Controls.Add(cmbDepartment);
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(cmbStatus);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 27);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(5);
            pnlFilter.Size = new Size(700, 45);
            pnlFilter.TabIndex = 1;
            //
            // lblSearch
            //
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 13);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            //
            // txtSearch
            //
            txtSearch.Location = new Point(65, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            //
            // lblDepartment
            //
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(240, 13);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(88, 20);
            lblDepartment.TabIndex = 2;
            lblDepartment.Text = "Department:";
            //
            // cmbDepartment
            //
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Location = new Point(330, 10);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(160, 28);
            cmbDepartment.TabIndex = 3;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(505, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status:";
            //
            // cmbStatus
            //
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(560, 10);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(120, 28);
            cmbStatus.TabIndex = 5;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            //
            // dgvCourses
            //
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.BackgroundColor = Color.White;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(0, 72);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.ReadOnly = true;
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(700, 280);
            dgvCourses.TabIndex = 0;
            //
            // chartCourses
            //
            chartCourses.Location = new Point(0, 355);
            chartCourses.Name = "chartCourses";
            chartCourses.Size = new Size(700, 280);
            chartCourses.TabIndex = 3;
            chartCourses.BackColor = System.Drawing.Color.White;
            //
            // toolStripSeparator1
            //
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            //
            // CoursesView
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(chartCourses);
            Controls.Add(dgvCourses);
            Controls.Add(pnlFilter);
            Controls.Add(toolStrip);
            Font = new Font("Segoe UI", 9F);
            Name = "CoursesView";
            Size = new Size(700, 650);
            Load += CoursesView_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton tsbAdd, tsbEdit, tsbView, tsbDelete, tsbRefresh;
        private Panel pnlFilter;
        private Label lblSearch, lblDepartment, lblStatus;
        private TextBox txtSearch;
        private ComboBox cmbDepartment, cmbStatus;
        private DataGridView dgvCourses;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCourses;
        private ToolStripSeparator toolStripSeparator1;
    }
}
