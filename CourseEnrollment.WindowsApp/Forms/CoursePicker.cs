using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;

namespace CourseEnrollment.WindowsApp.Forms
{
    public partial class CoursePicker : Form
    {
        private readonly ICourseService _courseService;
        private BindingSource _bindingSource;
        public Course SelectedCourse { get; private set; }

        public CoursePicker(ICourseService service)
        {
            InitializeComponent();
            _courseService = service;
            _bindingSource = new BindingSource();
            lsCourses.DataSource = _bindingSource;
            LoadCourses(string.Empty);
        }

        private void LoadCourses(string query)
        {
            var courses = string.IsNullOrWhiteSpace(query)
                ? _courseService.GetAll()
                : _courseService.Search(query, null, null);

            // Only show Open courses with available seats
            _bindingSource.DataSource = courses
                .Where(c => c.Status == CourseStatusEnum.Open && c.AvailableSeats > 0)
                .ToList();

            lsCourses.DisplayMember = "Title";
            lsCourses.ValueMember = "Id";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCourses(txtSearch.Text);
        }

        private void SelectCourse()
        {
            if (lsCourses.SelectedItem != null && lsCourses.SelectedItem is Course)
            {
                SelectedCourse = (Course)lsCourses.SelectedItem;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a course", "Course Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) => SelectCourse();
        private void lsCourses_DoubleClick(object sender, EventArgs e) => SelectCourse();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lsCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
