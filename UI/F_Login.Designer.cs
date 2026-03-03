using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    partial class F_Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            lblVersion = new Label();
            lblDescription = new Label();
            lblWelcome = new Label();
            pnlRight = new Panel();
            pnlFooter = new Panel();
            lblFooter = new Label();
            pnlLoginCard = new Panel();
            lblForgot = new Label();
            btnLogin = new RoundedButton();
            chkRemember = new CheckBox();
            pnlPassword = new Panel();
            txtPassword = new TextBox();
            lblPassword = new Label();
            pnlUsername = new Panel();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            btnClose = new Button();
            btnMinimize = new Button();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlUsername.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(41, 128, 185);
            pnlLeft.Controls.Add(lblVersion);
            pnlLeft.Controls.Add(lblDescription);
            pnlLeft.Controls.Add(lblWelcome);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(500, 700);
            pnlLeft.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.Font = new Font("Segoe UI", 9F);
            lblVersion.ForeColor = Color.FromArgb(189, 195, 199);
            lblVersion.Location = new Point(50, 650);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(400, 30);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "HR Management System v1.0.0";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 12F);
            lblDescription.ForeColor = Color.FromArgb(236, 240, 241);
            lblDescription.Location = new Point(50, 345);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(400, 60);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Hệ thống quản lý nhân sự toàn diện\ncho doanh nghiệp hiện đại";
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(50, 280);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(400, 55);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Chào Mừng Trở Lại!";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(pnlFooter);
            pnlRight.Controls.Add(pnlLoginCard);
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(btnMinimize);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(500, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(500, 700);
            pnlRight.TabIndex = 1;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.Transparent;
            pnlFooter.Controls.Add(lblFooter);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 660);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(500, 40);
            pnlFooter.TabIndex = 3;
            // 
            // lblFooter
            // 
            lblFooter.Font = new Font("Segoe UI", 8F);
            lblFooter.ForeColor = Color.FromArgb(189, 195, 199);
            lblFooter.Location = new Point(0, 10);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(500, 20);
            lblFooter.TabIndex = 0;
            lblFooter.Text = "© 2025 HR Management System. All rights reserved.";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.BackColor = Color.White;
            pnlLoginCard.Controls.Add(lblForgot);
            pnlLoginCard.Controls.Add(btnLogin);
            pnlLoginCard.Controls.Add(chkRemember);
            pnlLoginCard.Controls.Add(pnlPassword);
            pnlLoginCard.Controls.Add(pnlUsername);
            pnlLoginCard.Controls.Add(lblSubtitle);
            pnlLoginCard.Controls.Add(lblTitle);
            pnlLoginCard.Location = new Point(50, 150);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(400, 450);
            pnlLoginCard.TabIndex = 2;
            // 
            // lblForgot
            // 
            lblForgot.Cursor = Cursors.Hand;
            lblForgot.Font = new Font("Segoe UI", 9F);
            lblForgot.ForeColor = Color.FromArgb(52, 152, 219);
            lblForgot.Location = new Point(50, 405);
            lblForgot.Name = "lblForgot";
            lblForgot.Size = new Size(300, 20);
            lblForgot.TabIndex = 6;
            lblForgot.Text = "Quên mật khẩu?";
            lblForgot.TextAlign = ContentAlignment.MiddleCenter;
            lblForgot.Click += lblForgot_Click;
            lblForgot.MouseEnter += lblForgot_MouseEnter;
            lblForgot.MouseLeave += lblForgot_MouseLeave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 50);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "🔐 Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Font = new Font("Segoe UI", 9F);
            chkRemember.ForeColor = Color.FromArgb(127, 140, 141);
            chkRemember.Location = new Point(50, 300);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(128, 19);
            chkRemember.TabIndex = 4;
            chkRemember.Text = "Ghi nhớ đăng nhập";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.FromArgb(248, 249, 250);
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Controls.Add(lblPassword);
            pnlPassword.Location = new Point(50, 210);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(300, 70);
            pnlPassword.TabIndex = 3;
            pnlPassword.Paint += pnlInput_Paint;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(248, 249, 250);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.FromArgb(44, 62, 80);
            txtPassword.Location = new Point(15, 35);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(270, 22);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "Mật khẩu";
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.KeyDown += txtPassword_KeyDown;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(127, 140, 141);
            lblPassword.Location = new Point(15, 8);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(270, 20);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "🔒 Mật Khẩu";
            // 
            // pnlUsername
            // 
            pnlUsername.BackColor = Color.FromArgb(248, 249, 250);
            pnlUsername.Controls.Add(txtUsername);
            pnlUsername.Controls.Add(lblUsername);
            pnlUsername.Location = new Point(50, 120);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Size = new Size(300, 70);
            pnlUsername.TabIndex = 2;
            pnlUsername.Paint += pnlInput_Paint;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(248, 249, 250);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.FromArgb(44, 62, 80);
            txtUsername.Location = new Point(15, 35);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(270, 22);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "Tên người dùng";
            txtUsername.Enter += txtUsername_Enter;
            txtUsername.Leave += txtUsername_Leave;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(127, 140, 141);
            lblUsername.Location = new Point(15, 8);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(270, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "👤 Tên Đăng Nhập";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitle.Location = new Point(0, 70);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Vui lòng đăng nhập để tiếp tục";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(0, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đăng Nhập";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(231, 76, 60);
            btnClose.Location = new Point(445, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(45, 45);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.FromArgb(127, 140, 141);
            btnMinimize.Location = new Point(395, 10);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(45, 45);
            btnMinimize.TabIndex = 0;
            btnMinimize.Text = "─";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            btnMinimize.MouseEnter += btnControl_MouseEnter;
            btnMinimize.MouseLeave += btnControl_MouseLeave;
            // 
            // F_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 700);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "F_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            Load += F_Login_Load;
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            pnlUsername.ResumeLayout(false);
            pnlUsername.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Label lblWelcome;
        private Label lblDescription;
        private Label lblVersion;

        private Panel pnlRight;
        private Button btnMinimize;
        private Button btnClose;
        private Panel pnlLoginCard;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlUsername;
        private Label lblUsername;
        private TextBox txtUsername;
        private Panel pnlPassword;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkRemember;
        private RoundedButton btnLogin;
        private Label lblForgot;
        private Panel pnlFooter;
        private Label lblFooter;
    }
}