using Data;
using Service;
using System.Drawing.Drawing2D;

namespace UI
{
    public partial class F_Attendance_1 : Form
    {
        private System.Windows.Forms.Timer clockTimer;

        private readonly AttendanceService service;
        public F_Attendance_1()
        {
            InitializeComponent();
            InitializeTimer();
            CustomizeDataGridView();
            var db = new MyDBContext();
            service = new AttendanceService(db);
        }

        private void F_Attendance_1_Load(object sender, EventArgs e)
        {
            UpdateClock();
            LoadTodayData();
        }

        private void InitializeTimer()
        {
            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            lblNow.Text = now.ToString("HH:mm:ss");
            lblToday.Text = $"{GetDayOfWeek(now.DayOfWeek)}, {now:dd} Tháng {now:MM} Năm {now:yyyy}";
        }

        private string GetDayOfWeek(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday => "Thứ Hai",
                DayOfWeek.Tuesday => "Thứ Ba",
                DayOfWeek.Wednesday => "Thứ Tư",
                DayOfWeek.Thursday => "Thứ Năm",
                DayOfWeek.Friday => "Thứ Sáu",
                DayOfWeek.Saturday => "Thứ Bảy",
                DayOfWeek.Sunday => "Chủ Nhật",
                _ => ""
            };
        }

        private void LoadTodayData()
        {

            var list = service.GetAttendanceToday(DateOnly.FromDateTime(DateTime.Now));

            dgvToday.DataSource = null;

            if (list.Count == 0) {
                dgvToday.Rows.Add("Chưa có lượt điểm danh trong ngày!");
            }
            else {
                dgvToday.DataSource = list;

                dgvToday.Columns["Id"].HeaderText = "Mã";
                dgvToday.Columns["EmployeeCode"].HeaderText = "Mã Nhân Sự";
                dgvToday.Columns["WorkDate"].HeaderText = "Ngày Làm";
                dgvToday.Columns["CheckIn"].HeaderText = "Check In";
                dgvToday.Columns["CheckOut"].HeaderText = "Check Out";

                dgvToday.Columns["CreatedAt"].Visible = false;
                dgvToday.Columns["UpdatedAt"].Visible = false;
                dgvToday.Columns["Attendance"].Visible = false;
                dgvToday.Columns["Employee"].Visible = false;
                dgvToday.Columns["EmployeeId"].Visible = false;

                UpdateStatusBar();
            }
                
        }

        private void UpdateStatusBar()
        {
            lblStatus.Text = $"Hôm nay: {dgvToday.Rows.Count} lượt chấm công";
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = service.CheckIn(code);

            if (result.Success == false)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCode.Clear();
            txtCode.Focus();

            LoadTodayData();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = service.CheckOut(code);

            if (result.Success == false)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCode.Clear();
            txtCode.Focus();

            LoadTodayData();
        }


        private void CustomizeDataGridView()
        {
            dgvToday.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvToday.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvToday.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvToday.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvToday.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvToday.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvToday.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvToday.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvToday.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvToday.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);

            dgvToday.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
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

        private void pnlCodeBox_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            GraphicsPath path = new GraphicsPath();
            int radius = 25;
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            e.Graphics.DrawLine(new Pen(Color.FromArgb(230, 230, 230), 1),
                0, 0, pnl.Width, 0);
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnCheckIn_Click(sender, e);
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.FromArgb(46, 204, 113))
                btn.BackColor = Color.FromArgb(39, 174, 96);
            else if (btn.BackColor == Color.FromArgb(52, 152, 219))
                btn.BackColor = Color.FromArgb(41, 128, 185);
            else if (btn.BackColor == Color.FromArgb(149, 165, 166))
                btn.BackColor = Color.FromArgb(127, 140, 141);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnCheckIn)
                btn.BackColor = Color.FromArgb(46, 204, 113);
            else if (btn == btnCheckOut)
                btn.BackColor = Color.FromArgb(52, 152, 219);
        }

    }
}