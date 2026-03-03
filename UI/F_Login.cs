using Data;
using DTO;
using Service;
using System.Drawing.Drawing2D;
using System.Text.Json;

namespace UI
{
    public partial class F_Login : Form
    {
        private readonly UserService service;
        public F_Login()
        {
            InitializeComponent();
            var db = new MyDBContext();
            service = new UserService(db);
        }

        private void F_Login_Load(object sender, EventArgs e)
        {
            string path = "user.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var user = JsonSerializer.Deserialize<UserDTO>(json);

                F_App f_App = new F_App(user.Username, user.Role);
                f_App.ShowDialog();
                this.Close();


            }
            txtUsername.Select();
            chkRemember.Checked = true;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, e);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            var result = service.Login(username, password);

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = service.GetByUserName(username);

            if (chkRemember.Checked)
            {
                string json = JsonSerializer.Serialize(user);
                File.WriteAllText("user.json", json);
            }

            MessageBox.Show(result.Message, "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);


            F_App f_App = new F_App(user.Username, user.Role);
            f_App.ShowDialog();
            this.Close();

        }


        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            GraphicsPath path = new GraphicsPath();
            int radius = 10;
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);
        }


        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để được hỗ trợ!", "Quên mật khẩu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblForgot_MouseEnter(object sender, EventArgs e)
        {
            lblForgot.ForeColor = Color.FromArgb(41, 128, 185);
            lblForgot.Font = new Font(lblForgot.Font, FontStyle.Underline);
        }

        private void lblForgot_MouseLeave(object sender, EventArgs e)
        {
            lblForgot.ForeColor = Color.FromArgb(52, 152, 219);
            lblForgot.Font = new Font(lblForgot.Font, FontStyle.Regular);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnControl_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(236, 240, 241);
        }

        private void btnControl_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Transparent;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(231, 76, 60);
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Tên người dùng")
            {
                txtUsername.Text = "";
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Tên người dùng";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Mật khẩu";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu")
            {
                txtPassword.Text = "";
            }
        }
    }
}