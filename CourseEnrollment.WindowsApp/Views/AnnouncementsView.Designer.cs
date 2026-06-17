namespace CourseEnrollment.WindowsApp.Views
{
    partial class AnnouncementsView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            tsbAdd = new ToolStripButton();
            tsbEdit = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbRefresh = new ToolStripButton();
            pnlFilter = new Panel();
            lblFilter = new Label();
            cmbFilter = new ComboBox();
            lblCount = new Label();
            dgvAnnouncements = new DataGridView();
            pnlForm = new Panel();
            lblFormTitle = new Label();
            txtId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblMsg = new Label();
            txtMessage = new RichTextBox();
            chkIsActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            toolStrip.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnnouncements).BeginInit();
            pnlForm.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbAdd, tsbEdit, tsbDelete, toolStripSeparator1, tsbRefresh });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(875, 34);
            toolStrip.TabIndex = 0;
            // 
            // tsbAdd
            // 
            tsbAdd.Image = Properties.Resources.add;
            tsbAdd.Name = "tsbAdd";
            tsbAdd.Size = new Size(110, 29);
            tsbAdd.Text = "Add New";
            tsbAdd.Click += btnAdd_Click;
            // 
            // tsbEdit
            // 
            tsbEdit.Image = Properties.Resources.edit;
            tsbEdit.Name = "tsbEdit";
            tsbEdit.Size = new Size(66, 29);
            tsbEdit.Text = "Edit";
            tsbEdit.Click += btnEdit_Click;
            // 
            // tsbDelete
            // 
            tsbDelete.Image = Properties.Resources.delete;
            tsbDelete.Name = "tsbDelete";
            tsbDelete.Size = new Size(86, 29);
            tsbDelete.Text = "Delete";
            tsbDelete.Click += btnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 34);
            // 
            // tsbRefresh
            // 
            tsbRefresh.Image = Properties.Resources.refresh;
            tsbRefresh.Name = "tsbRefresh";
            tsbRefresh.Size = new Size(94, 29);
            tsbRefresh.Text = "Refresh";
            tsbRefresh.Click += btnRefresh_Click;
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(lblFilter);
            pnlFilter.Controls.Add(cmbFilter);
            pnlFilter.Controls.Add(lblCount);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 34);
            pnlFilter.Margin = new Padding(4, 4, 4, 4);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(6, 6, 6, 6);
            pnlFilter.Size = new Size(875, 56);
            pnlFilter.TabIndex = 1;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(12, 16);
            lblFilter.Margin = new Padding(4, 0, 4, 0);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(60, 25);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Show:";
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(75, 12);
            cmbFilter.Margin = new Padding(4, 4, 4, 4);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(186, 33);
            cmbFilter.TabIndex = 1;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(281, 16);
            lblCount.Margin = new Padding(4, 0, 4, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(68, 25);
            lblCount.TabIndex = 2;
            lblCount.Text = "Total: 0";
            // 
            // dgvAnnouncements
            // 
            dgvAnnouncements.AllowUserToAddRows = false;
            dgvAnnouncements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnnouncements.BackgroundColor = Color.White;
            dgvAnnouncements.ColumnHeadersHeight = 29;
            dgvAnnouncements.Dock = DockStyle.Fill;
            dgvAnnouncements.Location = new Point(0, 90);
            dgvAnnouncements.Margin = new Padding(4, 4, 4, 4);
            dgvAnnouncements.MultiSelect = false;
            dgvAnnouncements.Name = "dgvAnnouncements";
            dgvAnnouncements.ReadOnly = true;
            dgvAnnouncements.RowHeadersVisible = false;
            dgvAnnouncements.RowHeadersWidth = 51;
            dgvAnnouncements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnnouncements.Size = new Size(487, 500);
            dgvAnnouncements.TabIndex = 2;
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.FromArgb(245, 245, 250);
            pnlForm.Controls.Add(lblFormTitle);
            pnlForm.Controls.Add(txtId);
            pnlForm.Controls.Add(lblTitle);
            pnlForm.Controls.Add(txtTitle);
            pnlForm.Controls.Add(lblMsg);
            pnlForm.Controls.Add(txtMessage);
            pnlForm.Controls.Add(chkIsActive);
            pnlForm.Controls.Add(btnSave);
            pnlForm.Controls.Add(btnCancel);
            pnlForm.Dock = DockStyle.Right;
            pnlForm.Location = new Point(487, 90);
            pnlForm.Margin = new Padding(4, 4, 4, 4);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(15, 15, 15, 15);
            pnlForm.Size = new Size(388, 500);
            pnlForm.TabIndex = 3;
            pnlForm.Visible = false;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFormTitle.Location = new Point(15, 15);
            lblFormTitle.Margin = new Padding(4, 0, 4, 0);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(247, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Announcement Details";
            // 
            // txtId
            // 
            txtId.Location = new Point(15, 88);
            txtId.Margin = new Padding(4, 4, 4, 4);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(336, 31);
            txtId.TabIndex = 2;
            txtId.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(15, 61);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(48, 25);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(15, 88);
            txtTitle.Margin = new Padding(4, 4, 4, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(336, 31);
            txtTitle.TabIndex = 4;
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.Location = new Point(15, 131);
            lblMsg.Margin = new Padding(4, 0, 4, 0);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(86, 25);
            lblMsg.TabIndex = 5;
            lblMsg.Text = "Message:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(15, 156);
            txtMessage.Margin = new Padding(4, 4, 4, 4);
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtMessage.Size = new Size(336, 149);
            txtMessage.TabIndex = 6;
            txtMessage.Text = "";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Location = new Point(15, 322);
            chkIsActive.Margin = new Padding(4, 4, 4, 4);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(150, 29);
            chkIsActive.TabIndex = 7;
            chkIsActive.Text = "Active (visible)";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(15, 362);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(162, 42);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(190, 362);
            btnCancel.Margin = new Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(156, 42);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // AnnouncementsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvAnnouncements);
            Controls.Add(pnlForm);
            Controls.Add(pnlFilter);
            Controls.Add(toolStrip);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "AnnouncementsView";
            Size = new Size(875, 590);
            Load += AnnouncementsView_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnnouncements).EndInit();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton tsbAdd, tsbEdit, tsbDelete, tsbRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private Panel pnlFilter;
        private Label lblFilter;
        private ComboBox cmbFilter;
        private Label lblCount;
        private DataGridView dgvAnnouncements;
        private Panel pnlForm;
        private Label lblFormTitle;
        private TextBox txtId;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblMsg;
        private RichTextBox txtMessage;
        private CheckBox chkIsActive;
        private Button btnSave;
        private Button btnCancel;
    }
}
