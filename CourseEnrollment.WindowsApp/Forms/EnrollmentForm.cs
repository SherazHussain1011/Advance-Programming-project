using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;

namespace CourseEnrollment.WindowsApp.Forms
{
    public partial class EnrollmentForm : Form
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private Enrollment _enrollment;
        private bool _isEdit;
        private bool _isViewOnly;

        public EnrollmentForm(IEnrollmentService enrollmentService, ICourseService courseService,
            IStudentService studentService, Enrollment? enrollment = null, bool isViewOnly = false)
        {
            InitializeComponent();
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _studentService = studentService;

            cmbStatus.Items.Clear();

            if (enrollment != null)
            {
                _enrollment = enrollment;
                _isEdit = true;
                this.Text = "Edit Enrollment";
                btnSave.Text = "Update";

                txtCourseId.Text = enrollment.CourseId;
                txtCourseTitle.Text = enrollment.CourseTitle;
                txtStudentId.Text = enrollment.StudentId;
                txtStudentName.Text = enrollment.StudentName;
                dtpEnrollDate.Value = enrollment.EnrollDate;
                txtGrade.Text = enrollment.Grade ?? "";

                if (enrollment.EndDate.HasValue)
                    dtpEndDate.Value = enrollment.EndDate.Value;
                else
                    dtpEndDate.Value = DateTime.Now;

                if (enrollment.Status == EnrollmentStatusEnum.Completed)
                {
                    cmbStatus.DataSource = new[] { EnrollmentStatusEnum.Completed };
                    cmbStatus.Enabled = false;
                }
                else if (enrollment.Status == EnrollmentStatusEnum.Dropped)
                {
                    cmbStatus.DataSource = new[] { EnrollmentStatusEnum.Dropped };
                    cmbStatus.Enabled = false;
                }
                else
                {
                    cmbStatus.DataSource = Enum.GetValues(typeof(EnrollmentStatusEnum));
                }

                cmbStatus.SelectedItem = enrollment.Status;

                btnPickCourse.Enabled = false;
                btnPickStudent.Enabled = false;

                // View-only mode — lock everything down
                _isViewOnly = isViewOnly;
                if (isViewOnly)
                {
                    this.Text = "View Enrollment Record";
                    btnSave.Visible = false;
                    dtpEnrollDate.Enabled = false;
                    dtpEndDate.Enabled = false;
                    cmbStatus.Enabled = false;
                    txtGrade.ReadOnly = true;
                }
            }
            else
            {
                cmbStatus.DataSource = new[] { EnrollmentStatusEnum.Enrolled };
                cmbStatus.SelectedIndex = 0;
                cmbStatus.Enabled = false;

                _enrollment = new Enrollment();
                _isEdit = false;
                this.Text = "Enroll Student";
                dtpEnrollDate.Value = DateTime.Now;
                dtpEndDate.Value = DateTime.Now;
            }

            // Grey out EndDate when status is still Enrolled
            UpdateEndDateState();
            cmbStatus.SelectedIndexChanged += (_, _) => UpdateEndDateState();
        }

        private void UpdateEndDateState()
        {
            bool isFinalized = cmbStatus.SelectedItem is EnrollmentStatusEnum s &&
                                (s == EnrollmentStatusEnum.Completed || s == EnrollmentStatusEnum.Dropped);
            dtpEndDate.Enabled = isFinalized && !_isViewOnly;
        }

        private void btnPickCourse_Click(object sender, EventArgs e)
        {
            using var picker = new CoursePicker(_courseService);
            if (picker.ShowDialog() == DialogResult.OK && picker.SelectedCourse != null)
            {
                txtCourseId.Text = picker.SelectedCourse.Id;
                txtCourseTitle.Text = picker.SelectedCourse.Title;
            }
        }

        private void btnPickStudent_Click(object sender, EventArgs e)
        {
            using var picker = new StudentPicker(_studentService);
            if (picker.ShowDialog() == DialogResult.OK && picker.SelectedStudent != null)
            {
                txtStudentId.Text = picker.SelectedStudent.Id;
                txtStudentName.Text = picker.SelectedStudent.Name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseId.Text))
            {
                MessageBox.Show("Please select a course.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Please select a student.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_isEdit && (EnrollmentStatusEnum)cmbStatus.SelectedItem != EnrollmentStatusEnum.Enrolled)
            {
                MessageBox.Show("A new enrollment can only have the status 'Enrolled'.\n" +
                                "It cannot be Completed or Dropped before it has even started.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _enrollment.CourseId = txtCourseId.Text;
                _enrollment.CourseTitle = txtCourseTitle.Text;
                _enrollment.StudentId = txtStudentId.Text;
                _enrollment.StudentName = txtStudentName.Text;
                _enrollment.EnrollDate = dtpEnrollDate.Value;
                _enrollment.Status = (EnrollmentStatusEnum)cmbStatus.SelectedItem;
                _enrollment.Grade = string.IsNullOrWhiteSpace(txtGrade.Text) ? null : txtGrade.Text.Trim();

                _enrollment.EndDate = (_enrollment.Status == EnrollmentStatusEnum.Completed ||
                                       _enrollment.Status == EnrollmentStatusEnum.Dropped)
                    ? dtpEndDate.Value
                    : null;

                if (_isEdit)
                {
                    _enrollmentService.Update(_enrollment);
                    MessageBox.Show("Enrollment record updated!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _enrollmentService.Add(_enrollment);
                    MessageBox.Show("Student enrolled successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblEndDateNA_Click(object sender, EventArgs e)
        {

        }

        private void lblEnrollDate_Click(object sender, EventArgs e)
        {

        }
    }
}
