namespace CourseEnrollment.WindowsApp.Forms
{
    partial class EnrollmentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCourse = new Label();
            txtCourseId = new TextBox();
            txtCourseTitle = new TextBox();
            btnPickCourse = new Button();
            lblStudent = new Label();
            txtStudentId = new TextBox();
            txtStudentName = new TextBox();
            btnPickStudent = new Button();
            lblEnrollDate = new Label();
            dtpEnrollDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            lblGrade = new Label();
            txtGrade = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(20, 25);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(76, 28);
            lblCourse.TabIndex = 0;
            lblCourse.Text = "Course:";
            // 
            // txtCourseId
            // 
            txtCourseId.Location = new Point(110, 22);
            txtCourseId.Name = "txtCourseId";
            txtCourseId.ReadOnly = true;
            txtCourseId.Size = new Size(163, 34);
            txtCourseId.TabIndex = 1;
            // 
            // txtCourseTitle
            // 
            txtCourseTitle.Location = new Point(290, 22);
            txtCourseTitle.Name = "txtCourseTitle";
            txtCourseTitle.ReadOnly = true;
            txtCourseTitle.Size = new Size(170, 34);
            txtCourseTitle.TabIndex = 2;
            // 
            // btnPickCourse
            // 
            btnPickCourse.Location = new Point(472, 20);
            btnPickCourse.Name = "btnPickCourse";
            btnPickCourse.Size = new Size(132, 36);
            btnPickCourse.TabIndex = 3;
            btnPickCourse.Text = "Pick";
            btnPickCourse.Click += btnPickCourse_Click;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(20, 65);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(84, 28);
            lblStudent.TabIndex = 4;
            lblStudent.Text = "Student:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(110, 62);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.ReadOnly = true;
            txtStudentId.Size = new Size(163, 34);
            txtStudentId.TabIndex = 5;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(290, 62);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.ReadOnly = true;
            txtStudentName.Size = new Size(176, 34);
            txtStudentName.TabIndex = 6;
            // 
            // btnPickStudent
            // 
            btnPickStudent.Location = new Point(472, 62);
            btnPickStudent.Name = "btnPickStudent";
            btnPickStudent.Size = new Size(132, 39);
            btnPickStudent.TabIndex = 7;
            btnPickStudent.Text = "Pick";
            btnPickStudent.Click += btnPickStudent_Click;
            // 
            // lblEnrollDate
            // 
            lblEnrollDate.AutoSize = true;
            lblEnrollDate.Location = new Point(20, 105);
            lblEnrollDate.Name = "lblEnrollDate";
            lblEnrollDate.Size = new Size(112, 28);
            lblEnrollDate.TabIndex = 8;
            lblEnrollDate.Text = "Enroll Date:";
            lblEnrollDate.Click += lblEnrollDate_Click;
            // 
            // dtpEnrollDate
            // 
            dtpEnrollDate.Location = new Point(195, 105);
            dtpEnrollDate.Name = "dtpEnrollDate";
            dtpEnrollDate.Size = new Size(345, 34);
            dtpEnrollDate.TabIndex = 9;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(20, 145);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(95, 28);
            lblEndDate.TabIndex = 10;
            lblEndDate.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(195, 142);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(345, 34);
            dtpEndDate.TabIndex = 11;
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(20, 185);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(69, 28);
            lblGrade.TabIndex = 12;
            lblGrade.Text = "Grade:";
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(123, 182);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(213, 34);
            txtGrade.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 225);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 28);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(123, 222);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(337, 36);
            cmbStatus.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(22, 33, 62);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.Location = new Point(123, 278);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 43);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(256, 278);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(124, 43);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.Click += btnCancel_Click;
            // 
            // EnrollmentForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 460);
            Controls.Add(lblCourse);
            Controls.Add(txtCourseId);
            Controls.Add(txtCourseTitle);
            Controls.Add(btnPickCourse);
            Controls.Add(lblStudent);
            Controls.Add(txtStudentId);
            Controls.Add(txtStudentName);
            Controls.Add(btnPickStudent);
            Controls.Add(lblEnrollDate);
            Controls.Add(dtpEnrollDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpEndDate);
            Controls.Add(lblGrade);
            Controls.Add(txtGrade);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EnrollmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enroll Student";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblCourse, lblStudent, lblEnrollDate, lblEndDate, lblGrade, lblStatus;
        private TextBox txtCourseId, txtCourseTitle, txtStudentId, txtStudentName, txtGrade;
        private Button btnPickCourse, btnPickStudent, btnSave, btnCancel;
        private DateTimePicker dtpEnrollDate, dtpEndDate;
        private ComboBox cmbStatus;
    }
}
