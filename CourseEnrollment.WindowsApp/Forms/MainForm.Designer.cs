namespace CourseEnrollment.WindowsApp.Forms
{
    partial class MainForm
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
            pnlHeader = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblUser = new Label();
            pictureBox1 = new PictureBox();
            flpLeft = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            lblTitle = new Label();
            pnlSidebar = new Panel();
            flpNav = new FlowLayoutPanel();
            btnDashboard = new Button();
            btnCourses = new Button();
            btnStudents = new Button();
            btnEnrollments = new Button();
            btnAnnouncements = new Button();
            statusStrip = new StatusStrip();
            tsLabelStatus = new ToolStripStatusLabel();
            pnlContent = new Panel();
            pnlHeader.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlSidebar.SuspendLayout();
            flpNav.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(192, 0, 192);
            pnlHeader.Controls.Add(flowLayoutPanel1);
            pnlHeader.Controls.Add(flpLeft);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1121, 62);
            pnlHeader.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(lblUser);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Location = new Point(942, 0);
            flowLayoutPanel1.Margin = new Padding(4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(179, 62);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Cursor = Cursors.Cross;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.White;
            lblUser.ImageAlign = ContentAlignment.TopLeft;
            lblUser.Location = new Point(4, 0);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(70, 28);
            lblUser.TabIndex = 0;
            lblUser.Text = "Admin";
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            lblUser.Click += lblUser_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(82, 4);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 20);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // flpLeft
            // 
            flpLeft.Controls.Add(pictureBox2);
            flpLeft.Controls.Add(lblTitle);
            flpLeft.Dock = DockStyle.Left;
            flpLeft.Location = new Point(0, 0);
            flpLeft.Margin = new Padding(4);
            flpLeft.Name = "flpLeft";
            flpLeft.Size = new Size(545, 62);
            flpLeft.TabIndex = 2;
            flpLeft.Paint += flpLeft_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.graduation_cap;
            pictureBox2.Location = new Point(4, 4);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 51);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Right;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTitle.Location = new Point(54, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(361, 59);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Course Enrollment System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 45, 80);
            pnlSidebar.Controls.Add(flpNav);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 62);
            pnlSidebar.Margin = new Padding(4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(225, 638);
            pnlSidebar.TabIndex = 1;
            // 
            // flpNav
            // 
            flpNav.BackColor = Color.FromArgb(192, 0, 192);
            flpNav.Controls.Add(btnDashboard);
            flpNav.Controls.Add(btnCourses);
            flpNav.Controls.Add(btnStudents);
            flpNav.Controls.Add(btnEnrollments);
            flpNav.Controls.Add(btnAnnouncements);
            flpNav.Dock = DockStyle.Fill;
            flpNav.FlowDirection = FlowDirection.TopDown;
            flpNav.Location = new Point(0, 0);
            flpNav.Margin = new Padding(4);
            flpNav.Name = "flpNav";
            flpNav.Padding = new Padding(6, 12, 6, 0);
            flpNav.Size = new Size(225, 638);
            flpNav.TabIndex = 0;
            flpNav.Paint += flpNav_Paint;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Image = Properties.Resources.dashboard2;
            btnDashboard.Location = new Point(10, 16);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(206, 52);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnCourses
            // 
            btnCourses.FlatAppearance.BorderSize = 0;
            btnCourses.FlatStyle = FlatStyle.Flat;
            btnCourses.Font = new Font("Segoe UI", 10F);
            btnCourses.ForeColor = Color.White;
            btnCourses.Image = Properties.Resources.open_book;
            btnCourses.Location = new Point(10, 76);
            btnCourses.Margin = new Padding(4);
            btnCourses.Name = "btnCourses";
            btnCourses.Size = new Size(206, 52);
            btnCourses.TabIndex = 1;
            btnCourses.Text = "  Courses";
            btnCourses.TextAlign = ContentAlignment.MiddleLeft;
            btnCourses.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCourses.UseVisualStyleBackColor = true;
            btnCourses.Click += btnCourses_Click;
            // 
            // btnStudents
            // 
            btnStudents.FlatAppearance.BorderSize = 0;
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font("Segoe UI", 10F);
            btnStudents.ForeColor = Color.White;
            btnStudents.Image = Properties.Resources.group_users;
            btnStudents.Location = new Point(10, 136);
            btnStudents.Margin = new Padding(4);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(206, 52);
            btnStudents.TabIndex = 2;
            btnStudents.Text = "  Students";
            btnStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnStudents.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnStudents.UseVisualStyleBackColor = true;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnEnrollments
            // 
            btnEnrollments.FlatAppearance.BorderSize = 0;
            btnEnrollments.FlatStyle = FlatStyle.Flat;
            btnEnrollments.Font = new Font("Segoe UI", 10F);
            btnEnrollments.ForeColor = Color.White;
            btnEnrollments.Image = Properties.Resources.clipboard_check;
            btnEnrollments.Location = new Point(10, 196);
            btnEnrollments.Margin = new Padding(4);
            btnEnrollments.Name = "btnEnrollments";
            btnEnrollments.Size = new Size(224, 52);
            btnEnrollments.TabIndex = 3;
            btnEnrollments.Text = "  Enrollments";
            btnEnrollments.TextAlign = ContentAlignment.MiddleLeft;
            btnEnrollments.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEnrollments.UseVisualStyleBackColor = true;
            btnEnrollments.Click += btnEnrollments_Click;
            // 
            // btnAnnouncements
            // 
            btnAnnouncements.FlatAppearance.BorderSize = 0;
            btnAnnouncements.FlatStyle = FlatStyle.Flat;
            btnAnnouncements.Font = new Font("Segoe UI", 10F);
            btnAnnouncements.ForeColor = Color.White;
            btnAnnouncements.Image = Properties.Resources.announcement;
            btnAnnouncements.Location = new Point(10, 256);
            btnAnnouncements.Margin = new Padding(4);
            btnAnnouncements.Name = "btnAnnouncements";
            btnAnnouncements.Size = new Size(224, 52);
            btnAnnouncements.TabIndex = 4;
            btnAnnouncements.Text = "  Announcements";
            btnAnnouncements.TextAlign = ContentAlignment.MiddleLeft;
            btnAnnouncements.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAnnouncements.UseVisualStyleBackColor = true;
            btnAnnouncements.Click += btnAnnouncements_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { tsLabelStatus });
            statusStrip.Location = new Point(0, 700);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 18, 0);
            statusStrip.Size = new Size(1121, 32);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "Ready";
            // 
            // tsLabelStatus
            // 
            tsLabelStatus.Name = "tsLabelStatus";
            tsLabelStatus.Size = new Size(60, 25);
            tsLabelStatus.Text = "Ready";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(225, 62);
            pnlContent.Margin = new Padding(4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(896, 638);
            pnlContent.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 732);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(statusStrip);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Course Enrollment System";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flpLeft.ResumeLayout(false);
            flpLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlSidebar.ResumeLayout(false);
            flpNav.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlSidebar;
        private FlowLayoutPanel flpNav;
        private Button btnDashboard;
        private Button btnCourses;
        private Button btnStudents;
        private Button btnEnrollments;
        private Button btnAnnouncements;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel tsLabelStatus;
        private Panel pnlContent;
        private FlowLayoutPanel flpLeft;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox2;
        private Label lblUser;
        private PictureBox pictureBox1;
    }
}
