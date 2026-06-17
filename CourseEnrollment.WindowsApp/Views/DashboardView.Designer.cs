namespace CourseEnrollment.WindowsApp.Views
{
    partial class DashboardView
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnRefresh = new Button();
            flpCards = new FlowLayoutPanel();
            pnlCourses = new Panel();
            pnlStudents = new Panel();
            pnlActive = new Panel();
            pnlCompleted = new Panel();
            pnlDropped = new Panel();
            pnlOpenCourses = new Panel();
            lblCoursesLabel = new Label();
            lblTotalCourses = new Label();
            lblStudentsLabel = new Label();
            lblTotalStudents = new Label();
            lblActiveLabel = new Label();
            lblActiveEnrollments = new Label();
            lblCompletedLabel = new Label();
            lblCompleted = new Label();
            lblDroppedLabel = new Label();
            lblDropped = new Label();
            lblOpenCoursesLabel = new Label();
            lblOpenCourses = new Label();
            pnlAnnouncements = new Panel();
            lblAnnouncementsHeader = new Label();
            lstAnnouncements = new ListBox();
            flpCards.SuspendLayout();
            SuspendLayout();
            //
            // lblWelcome
            //
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 15);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Dashboard";
            //
            // btnRefresh
            //
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(588, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(92, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.Click += btnRefresh_Click;
            //
            // flpCards
            //
            flpCards.AutoScroll = true;
            flpCards.Controls.Add(pnlCourses);
            flpCards.Controls.Add(pnlStudents);
            flpCards.Controls.Add(pnlActive);
            flpCards.Controls.Add(pnlCompleted);
            flpCards.Controls.Add(pnlDropped);
            flpCards.Controls.Add(pnlOpenCourses);
            flpCards.Location = new Point(20, 60);
            flpCards.Name = "flpCards";
            flpCards.Size = new Size(660, 300);
            flpCards.TabIndex = 2;
            flpCards.WrapContents = true;
            //
            // pnlCourses
            //
            pnlCourses.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            pnlCourses.Controls.Add(lblCoursesLabel);
            pnlCourses.Controls.Add(lblTotalCourses);
            pnlCourses.Margin = new Padding(10);
            pnlCourses.Name = "pnlCourses";
            pnlCourses.Padding = new Padding(15);
            pnlCourses.Size = new Size(185, 120);
            pnlCourses.TabIndex = 0;
            //
            // lblCoursesLabel
            //
            lblCoursesLabel.AutoSize = true;
            lblCoursesLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblCoursesLabel.ForeColor = System.Drawing.Color.White;
            lblCoursesLabel.Location = new System.Drawing.Point(15, 15);
            lblCoursesLabel.Name = "lblCoursesLabel";
            lblCoursesLabel.Text = "Total Courses";
            //
            // lblTotalCourses
            //
            lblTotalCourses.AutoSize = true;
            lblTotalCourses.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalCourses.ForeColor = System.Drawing.Color.White;
            lblTotalCourses.Location = new System.Drawing.Point(15, 50);
            lblTotalCourses.Name = "lblTotalCourses";
            lblTotalCourses.Text = "0";
            //
            // pnlStudents
            //
            pnlStudents.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            pnlStudents.Controls.Add(lblStudentsLabel);
            pnlStudents.Controls.Add(lblTotalStudents);
            pnlStudents.Margin = new Padding(10);
            pnlStudents.Name = "pnlStudents";
            pnlStudents.Padding = new Padding(15);
            pnlStudents.Size = new Size(185, 120);
            pnlStudents.TabIndex = 1;
            //
            // lblStudentsLabel
            //
            lblStudentsLabel.AutoSize = true;
            lblStudentsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblStudentsLabel.ForeColor = System.Drawing.Color.White;
            lblStudentsLabel.Location = new System.Drawing.Point(15, 15);
            lblStudentsLabel.Name = "lblStudentsLabel";
            lblStudentsLabel.Text = "Total Students";
            //
            // lblTotalStudents
            //
            lblTotalStudents.AutoSize = true;
            lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalStudents.ForeColor = System.Drawing.Color.White;
            lblTotalStudents.Location = new System.Drawing.Point(15, 50);
            lblTotalStudents.Name = "lblTotalStudents";
            lblTotalStudents.Text = "0";
            //
            // pnlActive
            //
            pnlActive.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            pnlActive.Controls.Add(lblActiveLabel);
            pnlActive.Controls.Add(lblActiveEnrollments);
            pnlActive.Margin = new Padding(10);
            pnlActive.Name = "pnlActive";
            pnlActive.Padding = new Padding(15);
            pnlActive.Size = new Size(185, 120);
            pnlActive.TabIndex = 2;
            //
            // lblActiveLabel
            //
            lblActiveLabel.AutoSize = true;
            lblActiveLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblActiveLabel.ForeColor = System.Drawing.Color.White;
            lblActiveLabel.Location = new System.Drawing.Point(15, 15);
            lblActiveLabel.Name = "lblActiveLabel";
            lblActiveLabel.Text = "Active Enrollments";
            //
            // lblActiveEnrollments
            //
            lblActiveEnrollments.AutoSize = true;
            lblActiveEnrollments.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblActiveEnrollments.ForeColor = System.Drawing.Color.White;
            lblActiveEnrollments.Location = new System.Drawing.Point(15, 50);
            lblActiveEnrollments.Name = "lblActiveEnrollments";
            lblActiveEnrollments.Text = "0";
            //
            // pnlCompleted
            //
            pnlCompleted.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            pnlCompleted.Controls.Add(lblCompletedLabel);
            pnlCompleted.Controls.Add(lblCompleted);
            pnlCompleted.Margin = new Padding(10);
            pnlCompleted.Name = "pnlCompleted";
            pnlCompleted.Padding = new Padding(15);
            pnlCompleted.Size = new Size(185, 120);
            pnlCompleted.TabIndex = 3;
            //
            // lblCompletedLabel
            //
            lblCompletedLabel.AutoSize = true;
            lblCompletedLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblCompletedLabel.ForeColor = System.Drawing.Color.White;
            lblCompletedLabel.Location = new System.Drawing.Point(15, 15);
            lblCompletedLabel.Name = "lblCompletedLabel";
            lblCompletedLabel.Text = "Completed";
            //
            // lblCompleted
            //
            lblCompleted.AutoSize = true;
            lblCompleted.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblCompleted.ForeColor = System.Drawing.Color.White;
            lblCompleted.Location = new System.Drawing.Point(15, 50);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Text = "0";
            //
            // pnlDropped
            //
            pnlDropped.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            pnlDropped.Controls.Add(lblDroppedLabel);
            pnlDropped.Controls.Add(lblDropped);
            pnlDropped.Margin = new Padding(10);
            pnlDropped.Name = "pnlDropped";
            pnlDropped.Padding = new Padding(15);
            pnlDropped.Size = new Size(185, 120);
            pnlDropped.TabIndex = 4;
            //
            // lblDroppedLabel
            //
            lblDroppedLabel.AutoSize = true;
            lblDroppedLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblDroppedLabel.ForeColor = System.Drawing.Color.White;
            lblDroppedLabel.Location = new System.Drawing.Point(15, 15);
            lblDroppedLabel.Name = "lblDroppedLabel";
            lblDroppedLabel.Text = "Dropped";
            //
            // lblDropped
            //
            lblDropped.AutoSize = true;
            lblDropped.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblDropped.ForeColor = System.Drawing.Color.White;
            lblDropped.Location = new System.Drawing.Point(15, 50);
            lblDropped.Name = "lblDropped";
            lblDropped.Text = "0";
            //
            // pnlOpenCourses
            //
            pnlOpenCourses.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            pnlOpenCourses.Controls.Add(lblOpenCoursesLabel);
            pnlOpenCourses.Controls.Add(lblOpenCourses);
            pnlOpenCourses.Margin = new Padding(10);
            pnlOpenCourses.Name = "pnlOpenCourses";
            pnlOpenCourses.Padding = new Padding(15);
            pnlOpenCourses.Size = new Size(185, 120);
            pnlOpenCourses.TabIndex = 5;
            //
            // lblOpenCoursesLabel
            //
            lblOpenCoursesLabel.AutoSize = true;
            lblOpenCoursesLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblOpenCoursesLabel.ForeColor = System.Drawing.Color.White;
            lblOpenCoursesLabel.Location = new System.Drawing.Point(15, 15);
            lblOpenCoursesLabel.Name = "lblOpenCoursesLabel";
            lblOpenCoursesLabel.Text = "Open Courses";
            //
            // lblOpenCourses
            //
            lblOpenCourses.AutoSize = true;
            lblOpenCourses.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblOpenCourses.ForeColor = System.Drawing.Color.White;
            lblOpenCourses.Location = new System.Drawing.Point(15, 50);
            lblOpenCourses.Name = "lblOpenCourses";
            lblOpenCourses.Text = "0";
            //
            // pnlAnnouncements
            //
            pnlAnnouncements.Location = new Point(20, 375);
            pnlAnnouncements.Name = "pnlAnnouncements";
            pnlAnnouncements.Size = new Size(660, 220);
            pnlAnnouncements.TabIndex = 3;
            pnlAnnouncements.BorderStyle = BorderStyle.FixedSingle;
            pnlAnnouncements.BackColor = System.Drawing.Color.White;
            pnlAnnouncements.Controls.Add(lblAnnouncementsHeader);
            pnlAnnouncements.Controls.Add(lstAnnouncements);
            //
            // lblAnnouncementsHeader
            //
            lblAnnouncementsHeader.AutoSize = true;
            lblAnnouncementsHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAnnouncementsHeader.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            lblAnnouncementsHeader.Location = new Point(10, 10);
            lblAnnouncementsHeader.Name = "lblAnnouncementsHeader";
            lblAnnouncementsHeader.Text = "📢  Active Announcements";
            //
            // lstAnnouncements
            //
            lstAnnouncements.BorderStyle = BorderStyle.None;
            lstAnnouncements.Font = new Font("Segoe UI", 9.5F);
            lstAnnouncements.Location = new Point(10, 45);
            lstAnnouncements.Name = "lstAnnouncements";
            lstAnnouncements.Size = new Size(636, 165);
            lstAnnouncements.TabIndex = 0;
            lstAnnouncements.ItemHeight = 22;
            //
            // DashboardView
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(lblWelcome);
            Controls.Add(btnRefresh);
            Controls.Add(flpCards);
            Controls.Add(pnlAnnouncements);
            Font = new Font("Segoe UI", 9F);
            Name = "DashboardView";
            Size = new Size(700, 620);
            Load += DashboardView_Load;
            flpCards.ResumeLayout(true);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblWelcome;
        private Button btnRefresh;
        private FlowLayoutPanel flpCards;
        private Panel pnlCourses, pnlStudents, pnlActive, pnlCompleted, pnlDropped, pnlOpenCourses;
        private Label lblCoursesLabel, lblTotalCourses;
        private Label lblStudentsLabel, lblTotalStudents;
        private Label lblActiveLabel, lblActiveEnrollments;
        private Label lblCompletedLabel, lblCompleted;
        private Label lblDroppedLabel, lblDropped;
        private Label lblOpenCoursesLabel, lblOpenCourses;
        private Panel pnlAnnouncements;
        private Label lblAnnouncementsHeader;
        private ListBox lstAnnouncements;
    }
}
