namespace CourseEnrollment.WindowsApp.Forms
{
    partial class CoursePicker
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSearch = new Label();
            txtSearch = new TextBox();
            lsCourses = new ListBox();
            btnSelect = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(15, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(74, 28);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(95, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(270, 34);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lsCourses
            // 
            lsCourses.Location = new Point(15, 50);
            lsCourses.Name = "lsCourses";
            lsCourses.Size = new Size(350, 228);
            lsCourses.TabIndex = 2;
            lsCourses.SelectedIndexChanged += lsCourses_SelectedIndexChanged;
            lsCourses.DoubleClick += lsCourses_DoubleClick;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.FromArgb(22, 33, 62);
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.ForeColor = Color.White;
            btnSelect.Image = Properties.Resources.add;
            btnSelect.Location = new Point(87, 310);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(107, 51);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "Select";
            btnSelect.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(200, 310);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 51);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.Click += btnCancel_Click;
            // 
            // CoursePicker
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 502);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(lsCourses);
            Controls.Add(btnSelect);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CoursePicker";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Course";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblSearch;
        private TextBox txtSearch;
        private ListBox lsCourses;
        private Button btnSelect, btnCancel;
    }
}
