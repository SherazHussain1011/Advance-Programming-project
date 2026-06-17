namespace CourseEnrollment.WindowsApp.Views
{
    partial class EnrollmentsView
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
            tsbEnroll = new ToolStripButton();
            tsbComplete = new ToolStripButton();
            tsbDrop = new ToolStripButton();
            tsbEdit = new ToolStripButton();
            tsbView = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbRefresh = new ToolStripButton();
            pnlFilter = new Panel();
            lblStatus = new Label();
            cmbStatusFilter = new ComboBox();
            dgvEnrollments = new DataGridView();
            chartEnrollments = new System.Windows.Forms.DataVisualization.Charting.Chart();
            toolStrip.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnrollments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartEnrollments).BeginInit();
            SuspendLayout();
            //
            // toolStrip
            //
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbEnroll, tsbComplete, tsbDrop, tsbEdit, tsbView, tsbDelete, toolStripSeparator2, tsbRefresh });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(700, 27);
            toolStrip.TabIndex = 2;
            //
            // tsbEnroll
            //
            tsbEnroll.Image = Properties.Resources.enroll;
            tsbEnroll.Name = "tsbEnroll";
            tsbEnroll.Size = new Size(75, 24);
            tsbEnroll.Text = "Enroll";
            tsbEnroll.Click += tsbEnroll_Click;
            //
            // tsbComplete
            //
            tsbComplete.Image = Properties.Resources.complete_check;
            tsbComplete.Name = "tsbComplete";
            tsbComplete.Size = new Size(105, 24);
            tsbComplete.Text = "Mark Completed";
            tsbComplete.Click += tsbComplete_Click;
            //
            // tsbDrop
            //
            tsbDrop.Image = Properties.Resources.drop;
            tsbDrop.Name = "tsbDrop";
            tsbDrop.Size = new Size(70, 24);
            tsbDrop.Text = "Drop";
            tsbDrop.Click += tsbDrop_Click;
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
            // toolStripSeparator2
            //
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
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
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(cmbStatusFilter);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 27);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(700, 45);
            pnlFilter.TabIndex = 1;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(89, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Filter Status:";
            //
            // cmbStatusFilter
            //
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Location = new Point(100, 10);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(180, 28);
            cmbStatusFilter.TabIndex = 1;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            //
            // dgvEnrollments
            //
            dgvEnrollments.AllowUserToAddRows = false;
            dgvEnrollments.AllowUserToDeleteRows = false;
            dgvEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnrollments.BackgroundColor = Color.White;
            dgvEnrollments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnrollments.Location = new Point(0, 72);
            dgvEnrollments.Name = "dgvEnrollments";
            dgvEnrollments.ReadOnly = true;
            dgvEnrollments.RowHeadersVisible = false;
            dgvEnrollments.RowHeadersWidth = 51;
            dgvEnrollments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnrollments.Size = new Size(700, 280);
            dgvEnrollments.TabIndex = 0;
            //
            // chartEnrollments
            //
            chartEnrollments.Location = new Point(0, 355);
            chartEnrollments.Name = "chartEnrollments";
            chartEnrollments.Size = new Size(700, 280);
            chartEnrollments.TabIndex = 3;
            chartEnrollments.BackColor = System.Drawing.Color.White;
            //
            // EnrollmentsView
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(chartEnrollments);
            Controls.Add(dgvEnrollments);
            Controls.Add(pnlFilter);
            Controls.Add(toolStrip);
            Font = new Font("Segoe UI", 9F);
            Name = "EnrollmentsView";
            Size = new Size(700, 650);
            this.Load += new System.EventHandler(this.EnrollmentsView_Load);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnrollments).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartEnrollments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton tsbEnroll, tsbComplete, tsbDrop, tsbEdit, tsbView, tsbDelete, tsbRefresh;
        private Panel pnlFilter;
        private Label lblStatus;
        private ComboBox cmbStatusFilter;
        private DataGridView dgvEnrollments;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEnrollments;
        private ToolStripSeparator toolStripSeparator2;
    }
}
