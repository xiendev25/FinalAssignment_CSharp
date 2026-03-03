using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class F_User_Action
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblFormTitle = new Label();
            pnlContent = new Panel();
            pnlRow1 = new Panel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            pnlRow2 = new Panel();
            chkChangePassword = new CheckBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordConfirm = new Label();
            txtPasswordConfirm = new TextBox();
            pnlRow3 = new Panel();
            lblIsActive = new Label();
            chkIsActive = new CheckBox();
            pnlButtons = new Panel();
            btnCancel = new UI.RoundedButton();
            btnSave = new UI.RoundedButton();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlRow1.SuspendLayout();
            pnlRow2.SuspendLayout();
            pnlRow3.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(lblFormTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(640, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(25, 20);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(590, 40);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "➕ THÊM NGƯỜI DÙNG MỚI";
            lblFormTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(pnlRow3);
            pnlContent.Controls.Add(pnlRow2);
            pnlContent.Controls.Add(pnlRow1);
            pnlContent.Location = new Point(25, 95);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(590, 240);
            pnlContent.TabIndex = 1;
            // 
            // pnlRow1
            // 
            pnlRow1.Controls.Add(cboRole);
            pnlRow1.Controls.Add(lblRole);
            pnlRow1.Controls.Add(txtUsername);
            pnlRow1.Controls.Add(lblUsername);
            pnlRow1.Location = new Point(0, 5);
            pnlRow1.Name = "pnlRow1";
            pnlRow1.Size = new Size(590, 60);
            pnlRow1.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(44, 62, 80);
            lblUsername.Location = new Point(0, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(160, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username *";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(248, 249, 250);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(10, 28);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(260, 20);
            txtUsername.TabIndex = 1;
            // 
            // lblRole
            // 
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(44, 62, 80);
            lblRole.Location = new Point(300, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(160, 23);
            lblRole.TabIndex = 2;
            lblRole.Text = "Quyền *";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.Location = new Point(310, 26);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(260, 25);
            cboRole.TabIndex = 3;
            // 
            // pnlRow2
            // 
            pnlRow2.Controls.Add(txtPasswordConfirm);
            pnlRow2.Controls.Add(lblPasswordConfirm);
            pnlRow2.Controls.Add(txtPassword);
            pnlRow2.Controls.Add(lblPassword);
            pnlRow2.Controls.Add(chkChangePassword);
            pnlRow2.Location = new Point(0, 75);
            pnlRow2.Name = "pnlRow2";
            pnlRow2.Size = new Size(590, 90);
            pnlRow2.TabIndex = 1;
            // 
            // chkChangePassword
            // 
            chkChangePassword.AutoSize = true;
            chkChangePassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkChangePassword.Location = new Point(10, 0);
            chkChangePassword.Name = "chkChangePassword";
            chkChangePassword.Size = new Size(122, 21);
            chkChangePassword.TabIndex = 0;
            chkChangePassword.Text = "Đổi mật khẩu";
            chkChangePassword.UseVisualStyleBackColor = true;
            chkChangePassword.CheckedChanged += chkChangePassword_CheckedChanged;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(44, 62, 80);
            lblPassword.Location = new Point(0, 25);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(160, 23);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Mật khẩu *";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(248, 249, 250);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(10, 51);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(260, 20);
            txtPassword.TabIndex = 2;
            // 
            // lblPasswordConfirm
            // 
            lblPasswordConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPasswordConfirm.ForeColor = Color.FromArgb(44, 62, 80);
            lblPasswordConfirm.Location = new Point(300, 25);
            lblPasswordConfirm.Name = "lblPasswordConfirm";
            lblPasswordConfirm.Size = new Size(200, 23);
            lblPasswordConfirm.TabIndex = 3;
            lblPasswordConfirm.Text = "Xác nhận mật khẩu *";
            // 
            // txtPasswordConfirm
            // 
            txtPasswordConfirm.BackColor = Color.FromArgb(248, 249, 250);
            txtPasswordConfirm.BorderStyle = BorderStyle.None;
            txtPasswordConfirm.Font = new Font("Segoe UI", 11F);
            txtPasswordConfirm.Location = new Point(310, 51);
            txtPasswordConfirm.Name = "txtPasswordConfirm";
            txtPasswordConfirm.PasswordChar = '●';
            txtPasswordConfirm.Size = new Size(260, 20);
            txtPasswordConfirm.TabIndex = 4;
            // 
            // pnlRow3
            // 
            pnlRow3.Controls.Add(chkIsActive);
            pnlRow3.Controls.Add(lblIsActive);
            pnlRow3.Location = new Point(0, 175);
            pnlRow3.Name = "pnlRow3";
            pnlRow3.Size = new Size(590, 50);
            pnlRow3.TabIndex = 2;
            // 
            // lblIsActive
            // 
            lblIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIsActive.ForeColor = Color.FromArgb(44, 62, 80);
            lblIsActive.Location = new Point(0, 0);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(160, 23);
            lblIsActive.TabIndex = 0;
            lblIsActive.Text = "Trạng thái";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = false;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 10F);
            chkIsActive.ForeColor = Color.FromArgb(44, 62, 80);
            chkIsActive.Location = new Point(10, 20);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(300, 25);
            chkIsActive.TabIndex = 1;
            chkIsActive.Text = "✓ Đang hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.White;
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Location = new Point(25, 350);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(590, 60);
            pnlButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(330, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 45);
            btnSave.TabIndex = 0;
            btnSave.Text = "💾 Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += btn_MouseEnter;
            btnSave.MouseLeave += btn_MouseLeave;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(470, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btn_MouseEnter;
            btnCancel.MouseLeave += btn_MouseLeave;
            // 
            // F_User_Action
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(640, 430);
            Controls.Add(pnlButtons);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "F_User_Action";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản Lý Người Dùng";
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlRow1.ResumeLayout(false);
            pnlRow1.PerformLayout();
            pnlRow2.ResumeLayout(false);
            pnlRow2.PerformLayout();
            pnlRow3.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Panel pnlContent;
        private Panel pnlRow1;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblRole;
        private ComboBox cboRole;
        private Panel pnlRow2;
        private CheckBox chkChangePassword;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblPasswordConfirm;
        private TextBox txtPasswordConfirm;
        private Panel pnlRow3;
        private Label lblIsActive;
        private CheckBox chkIsActive;
        private Panel pnlButtons;
        private UI.RoundedButton btnCancel;
        private UI.RoundedButton btnSave;
    }
}
