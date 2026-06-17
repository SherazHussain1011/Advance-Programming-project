using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;
using CourseEnrollment.WindowsApp.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CourseEnrollment.WindowsApp.Views
{
    public partial class CoursesView : UserControl
    {
        private readonly ICourseService _courseService;
        private readonly IEnrollmentService _enrollmentService;
        private BindingSource _bindingSource = new BindingSource();

        public CoursesView(ICourseService service, IEnrollmentService enrollmentService)
        {
            _courseService = service;
            _enrollmentService = enrollmentService;
            InitializeComponent();
            dgvCourses.DataSource = _bindingSource;
        }

        private void CoursesView_Load(object sender, EventArgs e)
        {
            cmbDepartment.Items.Clear();
            var departments = new List<object> { "--ALL--" };
            departments.AddRange(Enum.GetValues(typeof(DepartmentEnum)).Cast<object>());
            cmbDepartment.DataSource = departments;
            cmbDepartment.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            var statuses = new List<object> { "--ALL--" };
            statuses.AddRange(Enum.GetValues(typeof(CourseStatusEnum)).Cast<object>());
            cmbStatus.DataSource = statuses;
            cmbStatus.SelectedIndex = 0;

            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                var courses = _courseService.GetAll();
                _bindingSource.DataSource = courses;
                RefreshChart(courses);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            try
            {
                string searchText = txtSearch.Text;

                DepartmentEnum? selectedDepartment = null;
                if (cmbDepartment.SelectedItem != null && !cmbDepartment.SelectedItem.ToString().Equals("--ALL--"))
                    selectedDepartment = (DepartmentEnum)cmbDepartment.SelectedItem;

                CourseStatusEnum? selectedStatus = null;
                if (cmbStatus.SelectedItem != null && !cmbStatus.SelectedItem.ToString().Equals("--ALL--"))
                    selectedStatus = (CourseStatusEnum)cmbStatus.SelectedItem;

                var courses = _courseService.Search(searchText, selectedDepartment, selectedStatus);
                _bindingSource.DataSource = courses;
                RefreshChart(courses);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching courses: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshChart(List<Course> courses)
        {
            chartCourses.Series.Clear();
            chartCourses.ChartAreas.Clear();
            chartCourses.Titles.Clear();
            chartCourses.Legends.Clear();

            var chartArea = new ChartArea("MainArea");
            chartArea.BackColor = System.Drawing.Color.White;
            chartArea.InnerPlotPosition = new ElementPosition(5, 5, 70, 80);
            chartCourses.ChartAreas.Add(chartArea);

            chartCourses.Titles.Add(new Title(
                "Course Status Distribution",
                Docking.Top,
                new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                System.Drawing.Color.FromArgb(52, 73, 94)));

            var legend = new Legend("MainLegend");
            legend.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend.Docking = Docking.Bottom;
            chartCourses.Legends.Add(legend);

            var series = new Series("CourseStatus");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "MainLegend";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0} ({P0})";
            series.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            int open = courses.Count(c => c.Status == CourseStatusEnum.Open);
            int full = courses.Count(c => c.Status == CourseStatusEnum.Full);
            int cancelled = courses.Count(c => c.Status == CourseStatusEnum.Cancelled);

            if (open > 0) { var pt = series.Points.Add(open); pt.LegendText = $"Open ({open})"; pt.Color = System.Drawing.Color.FromArgb(46, 204, 113); }
            if (full > 0) { var pt = series.Points.Add(full); pt.LegendText = $"Full ({full})"; pt.Color = System.Drawing.Color.FromArgb(155, 89, 182); }
            if (cancelled > 0) { var pt = series.Points.Add(cancelled); pt.LegendText = $"Cancelled ({cancelled})"; pt.Color = System.Drawing.Color.FromArgb(231, 76, 60); }

            if (open == 0 && full == 0 && cancelled == 0)
            {
                var pt = series.Points.Add(1);
                pt.LegendText = "No Data";
                pt.Color = System.Drawing.Color.LightGray;
                pt.Label = "No courses yet";
            }

            chartCourses.Series.Add(series);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new CourseForm(CourseFormModeEnum.Add, null, _courseService);
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Course selected = _bindingSource.Current as Course;
                if (selected != null)
                {
                    var form = new CourseForm(CourseFormModeEnum.Edit, selected, _courseService);
                    if (form.ShowDialog() == DialogResult.OK)
                        RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                Course selected = _bindingSource.Current as Course;
                if (selected != null)
                {
                    var form = new CourseForm(CourseFormModeEnum.View, selected, _courseService);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            Course selected = _bindingSource.Current as Course;
            if (selected == null) return;

            try
            {
                var activeEnrollments = _enrollmentService.GetAll()
                    .Where(en => en.CourseId == selected.Id && en.Status == EnrollmentStatusEnum.Enrolled)
                    .ToList();

                if (activeEnrollments.Count > 0)
                {
                    MessageBox.Show(
                        $"Cannot delete \"{selected.Title}\" — it has {activeEnrollments.Count} active enrollment(s).\n" +
                        "Please complete or drop those enrollments first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this course?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _courseService.Delete(selected.Id);
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e) => LoadCourses();
        private void txtSearch_TextChanged(object sender, EventArgs e) => RefreshGrid();
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e) => RefreshGrid();
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) => RefreshGrid();
    }
}
