using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class F_MDI : Form
    {
        private readonly string username;
        private readonly string role;

        private Form currentChildForm;
        public F_MDI(string username, string role)
        {
            InitializeComponent();

            this.username = username;
            this.role = role;

            sbUser.Text = $"Người dùng: {username}";
            sbRole.Text = $"Vai trò: {role}";

            if (role != "Admin")
            {
                mnuDepartment.Visible = false;
                mnuPosition.Visible = false;
                mnuEmployee.Visible = false;
                mnuUser.Visible = false;
                mnuAttendance.Visible = false;
            }

            if (role == "Admin")
                OpenChildForm(new F_Department(), "Admin");
            else
                OpenChildForm(new F_Dashboard(), "All");
        }

        private void OpenChildForm(Form childForm, string roleOpen)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

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

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string path = "user.json";
                if (File.Exists(path))
                    File.Delete(path);

                using (var login = new F_Login())
                {
                    Hide();
                    login.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuDepartment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Department(), "Admin");
        }

        private void mnuPosition_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Position(), "Admin");
        }

        private void mnuEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Employee(), "Admin");
        }

        private void mnuUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_User(), "Admin");
        }

        private void mnuAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Attendance(), "Admin");
        }

        private void mnuAttendance1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Attendance_1(), "All");
        }

        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Dashboard(), "All");
        }
    }
}
