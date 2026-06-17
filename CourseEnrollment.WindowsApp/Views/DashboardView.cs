using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Utilities;

namespace CourseEnrollment.WindowsApp.Views
{
    public partial class DashboardView : UserControl
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IAnnouncementService _announcementService;

        public DashboardView(ICourseService courseService, IStudentService studentService, IEnrollmentService enrollmentService, IAnnouncementService announcementService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _enrollmentService = enrollmentService;
            _announcementService = announcementService;
            InitializeComponent();
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            RefreshStats();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshStats();
        }

        private void RefreshStats()
        {
            try
            {
                var allCourses = _courseService.GetAll();
                var allStudents = _studentService.GetAll();
                var allEnrollments = _enrollmentService.GetAll();

                lblTotalCourses.Text = allCourses.Count.ToString();
                lblTotalStudents.Text = allStudents.Count.ToString();
                lblActiveEnrollments.Text = allEnrollments.Count(en => en.Status == EnrollmentStatusEnum.Enrolled).ToString();
                lblCompleted.Text = allEnrollments.Count(en => en.Status == EnrollmentStatusEnum.Completed).ToString();
                lblDropped.Text = allEnrollments.Count(en => en.Status == EnrollmentStatusEnum.Dropped).ToString();
                lblOpenCourses.Text = allCourses.Count(c => c.Status == CourseStatusEnum.Open).ToString();

                lstAnnouncements.Items.Clear();
                var announcements = _announcementService.GetActive();

                if (announcements.Count == 0)
                {
                    lstAnnouncements.Items.Add("No active announcements at this time.");
                }
                else
                {
                    foreach (var a in announcements.OrderByDescending(x => x.PostedDate))
                        lstAnnouncements.Items.Add($"[{a.PostedDate:dd MMM yyyy}]  {a.Title} — {a.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
