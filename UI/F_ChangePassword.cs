using Data;
using DTO;
using Service;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    public partial class F_ChangePassword : Form
    {
        private readonly UserService userService;
        private readonly string username;

        public F_ChangePassword(string username)
        {
            InitializeComponent();
            this.username = username;

            var db = new MyDBContext();
            userService = new UserService(db);

            AddTextBoxBorders();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string current = txtCurrent.Text.Trim();
            string newPwd = txtNew.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrEmpty(current))
            {
                MessageBox.Show("⚠️ Vui lòng nhập mật khẩu hiện tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrent.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPwd))
            {
                MessageBox.Show("⚠️ Vui lòng nhập mật khẩu mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNew.Focus();
                return;
            }

            if (current == newPwd)
            {
                MessageBox.Show("⚠️ Mật khẩu mới không được trùng mật khẩu hiện tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNew.Focus();
                return;
            }

            if (newPwd != confirm)
            {
                MessageBox.Show("⚠️ Xác nhận mật khẩu không khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Focus();
                return;
            }

            var result = userService.ChangePassword(this.username, current, newPwd);


            if (result.Success)
            {
                MessageBox.Show("Đổi mật khẩu thành công! \nVui lòng đăng nhập lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.BackColor == Color.FromArgb(46, 204, 113))
                    btn.BackColor = Color.FromArgb(39, 174, 96);
                else if (btn.BackColor == Color.FromArgb(149, 165, 166))
                    btn.BackColor = Color.FromArgb(127, 140, 141);
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn == btnSave) btn.BackColor = Color.FromArgb(46, 204, 113);
                else if (btn == btnCancel) btn.BackColor = Color.FromArgb(149, 165, 166);
            }
        }

        private void AddTextBoxBorders()
        {
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    foreach (Control inner in pnl.Controls)
                    {
                        if (inner is TextBox txt)
                        {
                            pnl.Paint += (s, e) =>
                            {
                                var path = new GraphicsPath();
                                int radius = 8;
                                var rect = new Rectangle(txt.Location.X - 5, txt.Location.Y - 8,
                                    txt.Width + 10, txt.Height + 16);

                                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                                path.CloseFigure();

                                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                using (var bg = new SolidBrush(txt.BackColor))
                                using (var pen = new Pen(Color.FromArgb(220, 220, 220), 1))
                                {
                                    e.Graphics.FillPath(bg, path);
                                    e.Graphics.DrawPath(pen, path);
                                }
                            };
                        }
                    }
                }
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox txt && !txt.ReadOnly)
            {
                txt.BackColor = Color.FromArgb(255, 255, 255);
                txt.Parent.Invalidate();
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox txt && !txt.ReadOnly)
            {
                txt.BackColor = Color.FromArgb(248, 249, 250);
                txt.Parent.Invalidate();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShowPassword.Checked;
            txtCurrent.UseSystemPasswordChar = !show;
            txtNew.UseSystemPasswordChar = !show;
            txtConfirm.UseSystemPasswordChar = !show;
        }

    }
}
