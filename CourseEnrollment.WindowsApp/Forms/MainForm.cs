using CourseEnrollment.Core.Contracts;
using CourseEnrollment.Core.Services;
using CourseEnrollment.WindowsApp.Views;
using System.Configuration;

namespace CourseEnrollment.WindowsApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly string _connStr;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IAnnouncementService _announcementService;

        public MainForm()
        {
            InitializeComponent();

            // Validate connection string before use
            var connEntry = ConfigurationManager.ConnectionStrings["CourseEnrollmentDB"];
            if (connEntry == null || string.IsNullOrWhiteSpace(connEntry.ConnectionString))
            {
                MessageBox.Show(
                    "The 'CourseEnrollmentDB' connection string is missing or empty in App.config.\n" +
                    "Please add it and restart the application.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Load += (_, _) => Close();
                return;
            }

            _connStr = connEntry.ConnectionString;
            _courseService = new DBCourseService(_connStr);
            _studentService = new DBStudentService(_connStr);
            _enrollmentService = new DBEnrollmentService(_connStr);
            _announcementService = new DBAnnouncementService(_connStr);

            tsLabelStatus.Text = "Ready  |  " + DateTime.Now.ToString("dd MMM yyyy  hh:mm tt");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowView(() => new DashboardView(_courseService, _studentService, _enrollmentService, _announcementService));
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            ShowView(() => new CoursesView(_courseService, _enrollmentService));
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ShowView(() => new StudentsView(_studentService, _enrollmentService));
        }

        private void btnEnrollments_Click(object sender, EventArgs e)
        {
            ShowView(() => new EnrollmentsView(_enrollmentService, _courseService, _studentService));
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            ShowView(() => new AnnouncementsView(_announcementService));
        }

        private void flpNav_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void flpLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowView<T>(Func<T> factory) where T : UserControl
        {
            pnlContent.Controls.Clear();

            var view = factory();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
            view.BringToFront();

            tsLabelStatus.Text = $"Viewing: {typeof(T).Name.Replace("View", "")}  |  {DateTime.Now:dd MMM yyyy  hh:mm tt}";
        }
    }
}
