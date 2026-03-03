using Data;
using Service;
using System.Drawing.Drawing2D;

namespace UI
{
    public partial class F_Dashboard : Form
    {
        private System.Windows.Forms.Timer refreshTimer;

        private readonly AttendanceService serviceAttendance;
        private readonly DepartmentService serviceDepartment;
        private readonly EmployeeService serviceEmployee;
        private readonly PositionService servicePosition;
        private readonly UserService serviceUser;
        public F_Dashboard()
        {
            InitializeComponent();
            InitializeTimer();
            var db = new MyDBContext();
            serviceAttendance = new AttendanceService(db);
            serviceDepartment = new DepartmentService(db);
            serviceEmployee = new EmployeeService(db);
            servicePosition = new PositionService(db);
            serviceUser = new UserService(db);
        }

        private void F_Dashboard_Load(object sender, EventArgs e)
        {
            LoadStatistics();
            UpdateStatusBar();
        }

        private void InitializeTimer()
        {
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 60000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void LoadStatistics()
        {
            lblDeptValue.Text = serviceDepartment.GetAll().Count().ToString();
            lblPosValue.Text = servicePosition.GetAll().Count().ToString();
            lblEmpValue.Text = serviceEmployee.GetAll().Count().ToString();
            lblAttValue.Text = serviceAttendance.GetAttendanceToday(DateOnly.FromDateTime(DateTime.Now)).Count().ToString();
            lblUserValue.Text = serviceUser.GetAll().Count().ToString();
        }

        private void UpdateStatusBar()
        {
            lblStatus.Text = $"⚡ Cập nhật lúc: {DateTime.Now:HH:mm:ss - dd/MM/yyyy}";
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            e.Graphics.DrawLine(new Pen(Color.FromArgb(230, 230, 230), 1),
                0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            Rectangle rect = pnl.ClientRectangle;
            rect.Inflate(-2, -2);

            GraphicsPath path = new GraphicsPath();
            int radius = 12;
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(new Pen(Color.FromArgb(220, 220, 220), 1), path);
        }

        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            e.Graphics.DrawLine(new Pen(Color.FromArgb(230, 230, 230), 1),
                0, 0, pnl.Width, 0);
        }
    }
}