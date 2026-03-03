using Data;
using DTO;
using Service;

namespace UI
{
    public partial class F_User_Action : Form
    {
        private readonly UserService userService;
        private readonly bool isEditMode;
        private int _id;

        public F_User_Action(bool isEdit)
        {
            isEditMode = isEdit;
            InitializeComponent();

            var db = new MyDBContext();
            userService = new UserService(db);

            SetupForm();
        }

        private void SetupForm()
        {
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new object[] { "Admin", "Staff" });
            cboRole.SelectedIndex = 1;

            if (isEditMode)
            {
                lblFormTitle.Text = "✏️ CẬP NHẬT NGƯỜI DÙNG";
                btnSave.Text = "💾 Cập Nhật";
                chkChangePassword.Checked = false;
                TogglePasswordInputs(false);
            }
            else
            {
                lblFormTitle.Text = "➕ THÊM NGƯỜI DÙNG MỚI";
                btnSave.Text = "💾 Lưu";
                chkChangePassword.Visible = false;
                chkChangePassword.Checked = true;
                TogglePasswordInputs(true);
            }
        }

        public void LoadUserData(int id, string username, string role, bool isActive)
        {
            _id = id;
            txtUsername.Text = username ?? "";
            txtPassword.Text = "";
            txtPasswordConfirm.Text = "";

            var idx = cboRole.Items.IndexOf(role ?? "Staff");
            cboRole.SelectedIndex = idx >= 0 ? idx : 1;

            chkIsActive.Checked = isActive;
        }

        private void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordInputs(chkChangePassword.Checked);
        }

        private void TogglePasswordInputs(bool enable)
        {
            txtPassword.Enabled = enable;
            txtPasswordConfirm.Enabled = enable;
            lblPassword.Enabled = enable;
            lblPasswordConfirm.Enabled = enable;

            if (!enable)
            {
                txtPassword.Text = "";
                txtPasswordConfirm.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập Username!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (!isEditMode || chkChangePassword.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPasswordConfirm.Focus();
                    return;
                }
            }

            var dto = new UserDTO
            {
                Id = _id,
                Username = txtUsername.Text.Trim(),
                Password = chkChangePassword.Checked ? txtPassword.Text.Trim() : null,
                Role = cboRole.SelectedItem?.ToString(),
                IsActive = chkIsActive.Checked
            };

            ServiceResult res = isEditMode ? userService.Update(dto) : userService.Add(dto);

            if (res.Success)
            {
                MessageBox.Show(isEditMode ? "Cập nhật người dùng thành công!" : "Thêm người dùng thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(res.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked)
            {
                chkIsActive.Text = "✓ Đang hoạt động";
                chkIsActive.ForeColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                chkIsActive.Text = "✗ Ngừng hoạt động";
                chkIsActive.ForeColor = Color.FromArgb(231, 76, 60);
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.FromArgb(46, 204, 113))
                btn.BackColor = Color.FromArgb(39, 174, 96);
            else if (btn.BackColor == Color.FromArgb(149, 165, 166))
                btn.BackColor = Color.FromArgb(127, 140, 141);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnSave)
                btn.BackColor = Color.FromArgb(46, 204, 113);
            else if (btn == btnCancel)
                btn.BackColor = Color.FromArgb(149, 165, 166);
        }
    }
}
