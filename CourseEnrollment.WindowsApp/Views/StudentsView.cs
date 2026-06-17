using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;
using CourseEnrollment.WindowsApp.Forms;

namespace CourseEnrollment.WindowsApp.Views
{
    public partial class StudentsView : UserControl
    {
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;
        private BindingSource _bindingSource = new BindingSource();

        public StudentsView(IStudentService service, IEnrollmentService enrollmentService)
        {
            _studentService = service;
            _enrollmentService = enrollmentService;
            InitializeComponent();
            dgvStudents.DataSource = _bindingSource;
        }

        private void StudentsView_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                _bindingSource.DataSource = _studentService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new StudentForm(_studentService, StudentFormModeEnum.Add);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Student selected = _bindingSource.Current as Student;
                if (selected != null)
                {
                    var form = new StudentForm(_studentService, StudentFormModeEnum.Edit, selected);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                Student selected = _bindingSource.Current as Student;
                if (selected != null)
                {
                    var form = new StudentForm(_studentService, StudentFormModeEnum.View, selected);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            Student selected = _bindingSource.Current as Student;
            if (selected == null) return;

            try
            {
                var activeEnrollments = _enrollmentService.GetByStudentId(selected.Id)
                    .Where(en => en.Status == EnrollmentStatusEnum.Enrolled)
                    .ToList();

                if (activeEnrollments.Count > 0)
                {
                    MessageBox.Show(
                        $"Cannot delete \"{selected.Name}\" — they have {activeEnrollments.Count} active enrollment(s).\n" +
                        "Please complete or drop those enrollments first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this student?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _studentService.Delete(selected.Id);
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e) => LoadStudents();

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = txtSearch.Text;
                if (string.IsNullOrWhiteSpace(query))
                    LoadStudents();
                else
                    _bindingSource.DataSource = _studentService.Search(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching students: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
