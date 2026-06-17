using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using System.Text.RegularExpressions;

namespace CourseEnrollment.WindowsApp.Forms
{
    public partial class StudentForm : Form
    {
        private IStudentService _studentService;
        private StudentFormModeEnum _mode;
        private Student _student;

        public StudentForm(IStudentService service, StudentFormModeEnum mode, Student? student = null)
        {
            InitializeComponent();
            _studentService = service;
            _mode = mode;
            _student = student ?? new Student();
            PopulateFields();
            SetupMode();
        }

        private void PopulateFields()
        {
            txtId.Text = _student.Id;
            txtName.Text = _student.Name;
            txtPhone.Text = _student.Phone;
            txtEmail.Text = _student.Email;
            txtDepartment.Text = _student.Department;
        }

        private void SetupMode()
        {
            switch (_mode)
            {
                case StudentFormModeEnum.Add:
                    this.Text = "Add Student";
                    lblId.Visible = false;
                    txtId.Visible = false;
                    break;
                case StudentFormModeEnum.Edit:
                    this.Text = "Edit Student";
                    btnSave.Text = "Update";
                    break;
                case StudentFormModeEnum.View:
                    this.Text = "View Student";
                    txtName.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtDepartment.ReadOnly = true;
                    btnSave.Visible = false;
                    break;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Name must be at least 2 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\+?[0-9]{7,15}$"))
            {
                MessageBox.Show("Phone must be 7-15 digits only.\nExample: 03001234567",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email format is invalid.\nExample: student@example.com",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    _student.Name = txtName.Text.Trim();
                    _student.Phone = txtPhone.Text.Trim();
                    _student.Email = txtEmail.Text.Trim();
                    _student.Department = txtDepartment.Text.Trim();

                    if (_mode == StudentFormModeEnum.Add)
                    {
                        _studentService.Add(_student);
                        MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _studentService.Update(_student);
                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
