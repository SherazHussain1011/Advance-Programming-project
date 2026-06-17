namespace CourseEnrollment.WindowsApp.Forms
{
    partial class CourseForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblId = new Label();
            txtId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblInstructor = new Label();
            txtInstructor = new TextBox();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            lblCredits = new Label();
            numCredits = new NumericUpDown();
            lblAvailableSeats = new Label();
            numAvailableSeats = new NumericUpDown();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numCredits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableSeats).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(30, 25);
            lblId.Name = "lblId";
            lblId.Size = new Size(35, 28);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(181, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(250, 34);
            txtId.TabIndex = 1;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(53, 28);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(181, 62);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 34);
            txtTitle.TabIndex = 3;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(30, 105);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(127, 28);
            lblCode.TabIndex = 4;
            lblCode.Text = "Course Code:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(181, 99);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(250, 34);
            txtCode.TabIndex = 5;
            // 
            // lblInstructor
            // 
            lblInstructor.AutoSize = true;
            lblInstructor.Location = new Point(30, 145);
            lblInstructor.Name = "lblInstructor";
            lblInstructor.Size = new Size(100, 28);
            lblInstructor.TabIndex = 6;
            lblInstructor.Text = "Instructor:";
            // 
            // txtInstructor
            // 
            txtInstructor.Location = new Point(181, 142);
            txtInstructor.Name = "txtInstructor";
            txtInstructor.Size = new Size(250, 34);
            txtInstructor.TabIndex = 7;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(30, 185);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(121, 28);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "Department:";
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Location = new Point(181, 182);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(250, 36);
            cmbDepartment.TabIndex = 9;
            // 
            // lblCredits
            // 
            lblCredits.AutoSize = true;
            lblCredits.Location = new Point(30, 225);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(77, 28);
            lblCredits.TabIndex = 10;
            lblCredits.Text = "Credits:";
            // 
            // numCredits
            // 
            numCredits.Location = new Point(181, 222);
            numCredits.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numCredits.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCredits.Name = "numCredits";
            numCredits.Size = new Size(250, 34);
            numCredits.TabIndex = 11;
            numCredits.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblAvailableSeats
            // 
            lblAvailableSeats.AutoSize = true;
            lblAvailableSeats.Location = new Point(30, 265);
            lblAvailableSeats.Name = "lblAvailableSeats";
            lblAvailableSeats.Size = new Size(147, 28);
            lblAvailableSeats.TabIndex = 12;
            lblAvailableSeats.Text = "Available Seats:";
            // 
            // numAvailableSeats
            // 
            numAvailableSeats.Location = new Point(181, 262);
            numAvailableSeats.Name = "numAvailableSeats";
            numAvailableSeats.Size = new Size(250, 34);
            numAvailableSeats.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 305);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 28);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(181, 302);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(250, 36);
            cmbStatus.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(22, 33, 62);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.Location = new Point(150, 350);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 53);
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
            btnCancel.Location = new Point(270, 350);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 53);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.Click += btnCancel_Click;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 520);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblCode);
            Controls.Add(txtCode);
            Controls.Add(lblInstructor);
            Controls.Add(txtInstructor);
            Controls.Add(lblDepartment);
            Controls.Add(cmbDepartment);
            Controls.Add(lblCredits);
            Controls.Add(numCredits);
            Controls.Add(lblAvailableSeats);
            Controls.Add(numAvailableSeats);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CourseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Course Form";
            ((System.ComponentModel.ISupportInitialize)numCredits).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableSeats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblId, lblTitle, lblCode, lblInstructor, lblDepartment, lblCredits, lblAvailableSeats, lblStatus;
        private TextBox txtId, txtTitle, txtCode, txtInstructor;
        private ComboBox cmbDepartment, cmbStatus;
        private NumericUpDown numCredits, numAvailableSeats;
        private Button btnSave, btnCancel;
    }
}
