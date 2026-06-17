using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;

namespace CourseEnrollment.WindowsApp.Forms
{
    public partial class StudentPicker : Form
    {
        private readonly IStudentService _studentService;
        private BindingSource _bindingSource;
        public Student SelectedStudent { get; private set; }

        public StudentPicker(IStudentService service)
        {
            InitializeComponent();
            _studentService = service;
            _bindingSource = new BindingSource();
            lsStudents.DataSource = _bindingSource;
            LoadStudents(string.Empty);
        }

        private void LoadStudents(string query)
        {
            var students = string.IsNullOrWhiteSpace(query)
                ? _studentService.GetAll()
                : _studentService.Search(query);
            _bindingSource.DataSource = students;
            lsStudents.DisplayMember = "Name";
            lsStudents.ValueMember = "Id";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStudents(txtSearch.Text);
        }

        private void SelectStudent()
        {
            if (lsStudents.SelectedItem != null && lsStudents.SelectedItem is Student)
            {
                SelectedStudent = (Student)lsStudents.SelectedItem;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a student", "Student Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) => SelectStudent();
        private void lsStudents_DoubleClick(object sender, EventArgs e) => SelectStudent();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
