using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;

namespace CourseEnrollment.WindowsApp.Forms
{
    public partial class CourseForm : Form
    {
        private CourseFormModeEnum _mode;
        private Course _course;
        private ICourseService _service;

        public CourseForm(CourseFormModeEnum mode, Course? course, ICourseService service)
        {
            InitializeComponent();

            numAvailableSeats.Maximum = int.MaxValue;

            cmbDepartment.Items.Clear();
            cmbDepartment.DataSource = Enum.GetValues(typeof(DepartmentEnum));
            cmbDepartment.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.DataSource = Enum.GetValues(typeof(CourseStatusEnum));
            cmbStatus.SelectedIndex = 0;

            _mode = mode;
            _course = course;
            _service = service;

            if (mode == CourseFormModeEnum.Edit)
            {
                btnSave.Text = "Update";
                this.Text = "Edit Course";
            }
            else if (mode == CourseFormModeEnum.View)
            {
                btnSave.Visible = false;
                this.Text = "View Course";
            }
            else
            {
                this.Text = "Add Course";
                lblId.Visible = false;
                txtId.Visible = false;
            }

            if (mode == CourseFormModeEnum.Edit || mode == CourseFormModeEnum.View)
            {
                txtId.Text = course.Id;
                txtTitle.Text = course.Title;
                txtCode.Text = course.Code;
                txtInstructor.Text = course.Instructor;
                cmbDepartment.SelectedItem = course.Department;
                numCredits.Value = course.Credits;
                numAvailableSeats.Value = course.AvailableSeats;
                cmbStatus.SelectedItem = course.Status;
            }

            if (mode == CourseFormModeEnum.View)
            {
                txtTitle.ReadOnly = true;
                txtCode.ReadOnly = true;
                txtInstructor.ReadOnly = true;
                cmbDepartment.Enabled = false;
                cmbStatus.Enabled = false;
                numCredits.Enabled = false;
                numAvailableSeats.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtInstructor.Text))
            {
                MessageBox.Show("Instructor cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstructor.Focus();
                return false;
            }
            if (numAvailableSeats.Value < 0)
            {
                MessageBox.Show("Available seats cannot be negative.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAvailableSeats.Focus();
                return false;
            }

            var status = (CourseStatusEnum)cmbStatus.SelectedItem;
            int seats = (int)numAvailableSeats.Value;

            // ── Add mode validations ──────────────────────────────────────────
            if (_mode == CourseFormModeEnum.Add)
            {
                if (seats == 0)
                {
                    MessageBox.Show("Available seats must be at least 1 when adding a new course.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numAvailableSeats.Focus();
                    return false;
                }
                if (status != CourseStatusEnum.Open)
                {
                    MessageBox.Show("A newly added course must have status Open.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return false;
                }
            }

            // ── Edit mode validations ─────────────────────────────────────────
            if (_mode == CourseFormModeEnum.Edit)
            {
                if (seats == 0 && status == CourseStatusEnum.Open)
                {
                    MessageBox.Show("There are no available seats left — status cannot be Open.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return false;
                }
                if (seats > 0 && status == CourseStatusEnum.Full)
                {
                    MessageBox.Show("Seats are still available — status cannot be Full.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            try
            {
                if (_mode == CourseFormModeEnum.Add)
                {
                    Course newCourse = new Course();
                    newCourse.Title = txtTitle.Text.Trim();
                    newCourse.Code = txtCode.Text.Trim();
                    newCourse.Instructor = txtInstructor.Text.Trim();
                    newCourse.Department = (DepartmentEnum)cmbDepartment.SelectedItem;
                    newCourse.Credits = (int)numCredits.Value;
                    newCourse.AvailableSeats = (int)numAvailableSeats.Value;
                    newCourse.Status = (CourseStatusEnum)cmbStatus.SelectedItem;

                    Course temp = _service.Add(newCourse);
                    txtId.Text = temp?.Id ?? "";
                    MessageBox.Show("Course added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_mode == CourseFormModeEnum.Edit)
                {
                    _course.Title = txtTitle.Text.Trim();
                    _course.Code = txtCode.Text.Trim();
                    _course.Instructor = txtInstructor.Text.Trim();
                    _course.Department = (DepartmentEnum)cmbDepartment.SelectedItem;
                    _course.Credits = (int)numCredits.Value;
                    _course.AvailableSeats = (int)numAvailableSeats.Value;
                    _course.Status = (CourseStatusEnum)cmbStatus.SelectedItem;

                    _service.Update(_course);
                    MessageBox.Show("Course updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
