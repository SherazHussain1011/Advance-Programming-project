using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;
using CourseEnrollment.WindowsApp.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CourseEnrollment.WindowsApp.Views
{
    public partial class EnrollmentsView : UserControl
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private BindingSource _bindingSource = new BindingSource();

        public EnrollmentsView(IEnrollmentService enrollmentService, ICourseService courseService,
            IStudentService studentService)
        {
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _studentService = studentService;
            InitializeComponent();
            dgvEnrollments.DataSource = _bindingSource;

            dgvEnrollments.DataBindingComplete += (s, e) =>
            {
                if (dgvEnrollments.Columns.Contains("EndDate"))
                    dgvEnrollments.Columns["EndDate"].DefaultCellStyle.NullValue = "N/A";
                if (dgvEnrollments.Columns.Contains("Grade"))
                    dgvEnrollments.Columns["Grade"].DefaultCellStyle.NullValue = "N/A";
            };

            cmbStatusFilter.Items.Clear();
            var statuses = new List<object> { "--ALL--" };
            statuses.AddRange(Enum.GetValues(typeof(EnrollmentStatusEnum)).Cast<object>());
            cmbStatusFilter.DataSource = statuses;
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void EnrollmentsView_Load(object sender, EventArgs e)
        {
            LoadEnrollments();
        }

        private void LoadEnrollments()
        {
            try
            {
                var enrollments = _enrollmentService.GetAll();
                _bindingSource.DataSource = enrollments;
                RefreshChart(enrollments);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading enrollments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshChart(List<Enrollment> enrollments)
        {
            chartEnrollments.Series.Clear();
            chartEnrollments.ChartAreas.Clear();
            chartEnrollments.Titles.Clear();
            chartEnrollments.Legends.Clear();

            var chartArea = new ChartArea("MainArea");
            chartArea.BackColor = System.Drawing.Color.White;
            chartArea.InnerPlotPosition = new ElementPosition(5, 5, 70, 80);
            chartEnrollments.ChartAreas.Add(chartArea);

            chartEnrollments.Titles.Add(new Title(
                "Enrollment Status Distribution",
                Docking.Top,
                new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                System.Drawing.Color.FromArgb(52, 73, 94)));

            var legend = new Legend("MainLegend");
            legend.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend.Docking = Docking.Bottom;
            chartEnrollments.Legends.Add(legend);

            var series = new Series("EnrollmentStatus");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "MainLegend";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0} ({P0})";
            series.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            int enrolled = enrollments.Count(en => en.Status == EnrollmentStatusEnum.Enrolled);
            int completed = enrollments.Count(en => en.Status == EnrollmentStatusEnum.Completed);
            int dropped = enrollments.Count(en => en.Status == EnrollmentStatusEnum.Dropped);

            if (enrolled > 0) { var pt = series.Points.Add(enrolled); pt.LegendText = $"Enrolled ({enrolled})"; pt.Color = System.Drawing.Color.FromArgb(155, 89, 182); }
            if (completed > 0) { var pt = series.Points.Add(completed); pt.LegendText = $"Completed ({completed})"; pt.Color = System.Drawing.Color.FromArgb(46, 204, 113); }
            if (dropped > 0) { var pt = series.Points.Add(dropped); pt.LegendText = $"Dropped ({dropped})"; pt.Color = System.Drawing.Color.FromArgb(231, 76, 60); }

            if (enrolled == 0 && completed == 0 && dropped == 0)
            {
                var pt = series.Points.Add(1);
                pt.LegendText = "No Data";
                pt.Color = System.Drawing.Color.LightGray;
                pt.Label = "No enrollment records yet";
            }

            chartEnrollments.Series.Add(series);
        }

        private void tsbEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new EnrollmentForm(_enrollmentService, _courseService, _studentService);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadEnrollments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error enrolling student: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbComplete_Click(object sender, EventArgs e)
        {
            Enrollment selected = _bindingSource.Current as Enrollment;
            if (selected == null)
            {
                MessageBox.Show("Please select an enrollment record.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selected.Status != EnrollmentStatusEnum.Enrolled)
            {
                MessageBox.Show("This enrollment has already been finalized.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var confirm = MessageBox.Show(
                    $"Mark \"{selected.CourseTitle}\" as Completed for {selected.StudentName}?",
                    "Confirm Completion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    selected.Status = EnrollmentStatusEnum.Completed;
                    selected.EndDate = DateTime.Now;
                    _enrollmentService.Update(selected);
                    MessageBox.Show("Enrollment marked as completed!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEnrollments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDrop_Click(object sender, EventArgs e)
        {
            Enrollment selected = _bindingSource.Current as Enrollment;
            if (selected == null)
            {
                MessageBox.Show("Please select an enrollment record.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selected.Status != EnrollmentStatusEnum.Enrolled)
            {
                MessageBox.Show("This enrollment has already been finalized.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var confirm = MessageBox.Show(
                    $"Drop {selected.StudentName} from \"{selected.CourseTitle}\"?",
                    "Confirm Drop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    selected.Status = EnrollmentStatusEnum.Dropped;
                    selected.EndDate = DateTime.Now;
                    _enrollmentService.Update(selected);
                    MessageBox.Show("Student dropped from course.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEnrollments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error dropping enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Enrollment selected = _bindingSource.Current as Enrollment;
                if (selected != null)
                {
                    var form = new EnrollmentForm(_enrollmentService, _courseService, _studentService, selected);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadEnrollments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                Enrollment selected = _bindingSource.Current as Enrollment;
                if (selected == null)
                {
                    MessageBox.Show("Please select an enrollment record.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var form = new EnrollmentForm(_enrollmentService, _courseService, _studentService, selected, isViewOnly: true);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            Enrollment selected = _bindingSource.Current as Enrollment;
            if (selected == null) return;

            try
            {
                if (selected.Status == EnrollmentStatusEnum.Enrolled)
                {
                    MessageBox.Show(
                        $"Cannot delete this record — {selected.StudentName} is currently Enrolled in \"{selected.CourseTitle}\".\n" +
                        "Please complete or drop the enrollment first before deleting the record.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Delete this enrollment record?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _enrollmentService.Delete(selected.Id);
                    LoadEnrollments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting enrollment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e) => LoadEnrollments();

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbStatusFilter.SelectedItem == null || cmbStatusFilter.SelectedItem.ToString() == "--ALL--")
                {
                    LoadEnrollments();
                }
                else
                {
                    var enrollments = _enrollmentService.GetByStatus((EnrollmentStatusEnum)cmbStatusFilter.SelectedItem);
                    _bindingSource.DataSource = enrollments;
                    RefreshChart(enrollments);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering enrollments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
