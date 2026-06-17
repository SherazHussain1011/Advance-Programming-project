namespace CourseEnrollment.WindowsApp.Forms
{
    partial class StudentForm
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
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDepartment = new Label();
            txtDepartment = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
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
            txtId.ForeColor = SystemColors.WindowText;
            txtId.Location = new Point(140, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(240, 34);
            txtId.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 65);
            lblName.Name = "lblName";
            lblName.Size = new Size(68, 28);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(240, 34);
            txtName.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(30, 105);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(71, 28);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(140, 102);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(240, 34);
            txtPhone.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 145);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 28);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(140, 142);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 34);
            txtEmail.TabIndex = 7;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(13, 188);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(121, 28);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "Department:";
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(140, 182);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(288, 34);
            txtDepartment.TabIndex = 9;
            txtDepartment.TextChanged += txtDepartment_TextChanged;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(22, 33, 62);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.Location = new Point(140, 247);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 46);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(256, 247);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(124, 46);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.Click += btnCancel_Click;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 455);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblDepartment);
            Controls.Add(txtDepartment);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Student Form";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblId, lblName, lblPhone, lblEmail, lblDepartment;
        private TextBox txtId, txtName, txtPhone, txtEmail, txtDepartment;
        private Button btnSave, btnCancel;
    }
}
