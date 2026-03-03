using DocumentFormat.OpenXml.Bibliography;
using System.Drawing.Drawing2D;


namespace UI
{
    public partial class F_App : Form
    {
        private Form currentChildForm;
        private MenuButton currentActiveButton;

        private string username;
        private string role;

        public F_App(string username, string role)
        {
            InitializeComponent();
            this.username = username;
            this.role = role;

            lblUserName.Text = username;
            lblUserRole.Text = $"👤 {role}";
            currentActiveButton = btnDepartment;
        }

        private void F_App_Load(object sender, EventArgs e)
        {
            LoadMenu();
            if (this.role == "Admin")
            {
                OpenChildForm(new F_Department(), btnDepartment, "Admin");
            }
            else
            {
                btnDepartment.Visible = false;
                btnAttendance.Visible = false;
                btnPosition.Visible = false;
                btnUser.Visible = false;
                btnEmployee.Visible = false;

                OpenChildForm(new F_Dashboard(), btnDashboard, "All");
            }

        }

        private void LoadMenu()
        {
            var menuSystem = new ToolStripMenuItem { Text = "Hệ thống" };
            var menuAction = new ToolStripMenuItem { Text = "Chức năng" };
            menuStrip.Items.Add(menuSystem);
            menuStrip.Items.Add(menuAction);

            var menuChangePassword = new ToolStripMenuItem { Text = "Đổi mật khẩu" };
            var menuLogout = new ToolStripMenuItem { Text = "Đăng xuất" };
            var menuExit = new ToolStripMenuItem { Text = "Thoát" };

            menuChangePassword.Click += (s, e) => menuChangePassword_Click(s,e);
            menuLogout.Click += (s, e) => btnLogout_Click(s, e);
            menuExit.Click += (s, e) => Application.Exit();

            menuSystem.DropDownItems.Add(menuChangePassword);
            menuSystem.DropDownItems.Add(menuLogout);
            menuSystem.DropDownItems.Add(menuExit);

            var menuDepartment = new ToolStripMenuItem { Text = "Quản lý Phòng ban" }; 
            var menuPosition = new ToolStripMenuItem { Text = "Quản lý Chức danh" };
            var menuEmployee = new ToolStripMenuItem { Text = "Quản lý Nhân sự" };
            var menuAttendance = new ToolStripMenuItem { Text = "Quản lý Chấm công" };
            var menuUser = new ToolStripMenuItem { Text = "Quản lý Người dùng" };
            var menuBreak = new ToolStripSeparator();
            var menuAttendance1 = new ToolStripMenuItem { Text = "Chấm công" };
            var menuDashboard = new ToolStripMenuItem { Text = "Thống kê" };


            menuDepartment.Click += (s, e) => OpenChildForm(new F_Department(), btnDepartment, "Admin");
            menuPosition.Click += (s, e) => OpenChildForm(new F_Position(), btnPosition, "Admin");
            menuEmployee.Click += (s, e) => OpenChildForm(new F_Employee(), btnEmployee, "Admin");
            menuAttendance.Click += (s, e) => OpenChildForm(new F_Attendance(), btnAttendance, "Admin");
            menuUser.Click += (s, e) => OpenChildForm(new F_User(), btnUser, "Admin");
            menuAttendance1.Click += (s, e) => OpenChildForm(new F_Attendance_1(), btnAttendance_1, "All");
            menuDashboard.Click += (s, e) => OpenChildForm(new F_Dashboard(), btnDashboard, "All");

            menuAction.DropDownItems.Add(menuDepartment);
            menuAction.DropDownItems.Add(menuPosition);
            menuAction.DropDownItems.Add(menuEmployee);
            menuAction.DropDownItems.Add(menuAttendance);
            menuAction.DropDownItems.Add(menuUser);
            menuAction.DropDownItems.Add(menuBreak);
            menuAction.DropDownItems.Add(menuAttendance1);
            menuAction.DropDownItems.Add(menuDashboard);

            if (this.role != "Admin")
            {
                menuDepartment.Visible = false;
                menuPosition.Visible = false;
                menuEmployee.Visible = false;
                menuAttendance.Visible = false;
                menuUser.Visible = false;

                menuAttendance1.Visible = true;
                menuDashboard.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm, MenuButton button, string roleOpen)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            if (currentActiveButton != null && currentActiveButton != button)
            {
                currentActiveButton.BackColor = Color.Transparent;
                currentActiveButton.ForeColor = Color.FromArgb(189, 195, 199);
            }

            currentActiveButton = button;
            button.BackColor = Color.FromArgb(52, 152, 219);
            button.ForeColor = Color.White;

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);


            if (roleOpen == "All" || roleOpen == role)
            {
                childForm.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuChangePassword_Click(object sender, EventArgs e)
        {
            F_ChangePassword changePassword = new F_ChangePassword(this.username);
            if(changePassword.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = "user.json";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    F_Login fLogin = new F_Login();
                    this.Hide();
                    fLogin.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ;
        }
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Department(), btnDepartment, "Admin");
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Position(), btnPosition, "Admin");
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Employee(), btnEmployee, "Admin");
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_User(), btnUser, "Admin");
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Attendance(), btnAttendance, "Admin");
        }
        private void btnAttendance_1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Attendance_1(), btnAttendance_1, "All");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Dashboard(), btnDashboard, "All");
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string path = "user.json";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    F_Login fLogin = new F_Login();
                    this.Hide();
                    fLogin.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void picAvatar_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pic.Width, pic.Height);
            pic.Region = new Region(path);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(52, 152, 219)),
                0, 0, pic.Width, pic.Height);

            using (Font font = new Font("Segoe UI", 18F, FontStyle.Bold))
            {
                string initial = lblUserName.Text.Substring(0, 1).ToUpper();
                SizeF textSize = e.Graphics.MeasureString(initial, font);
                float x = (pic.Width - textSize.Width) / 2;
                float y = (pic.Height - textSize.Height) / 2;

                e.Graphics.DrawString(initial, font, Brushes.White, x, y);
            }
        }

        
    }
}