using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    partial class F_App
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
            pnlSidebar = new Panel();
            pnlMenu = new Panel();
            btnDashboard = new MenuButton();
            btnAttendance_1 = new MenuButton();
            btnLogout = new MenuButton();
            btnAttendance = new MenuButton();
            btnUser = new MenuButton();
            btnEmployee = new MenuButton();
            btnPosition = new MenuButton();
            btnDepartment = new MenuButton();
            pnlUserInfo = new Panel();
            lblUserRole = new Label();
            lblUserName = new Label();
            picAvatar = new PictureBox();
            pnlLogo = new Panel();
            lblAppName = new Label();
            lblAppIcon = new Label();
            pnlContent = new Panel();
            menuStrip = new MenuStrip();
            pnlSidebar.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlLogo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(44, 62, 80);
            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(pnlUserInfo);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 24);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(280, 776);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(44, 62, 80);
            pnlMenu.Controls.Add(btnDashboard);
            pnlMenu.Controls.Add(btnAttendance_1);
            pnlMenu.Controls.Add(btnLogout);
            pnlMenu.Controls.Add(btnAttendance);
            pnlMenu.Controls.Add(btnUser);
            pnlMenu.Controls.Add(btnEmployee);
            pnlMenu.Controls.Add(btnPosition);
            pnlMenu.Controls.Add(btnDepartment);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 180);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(15, 20, 15, 20);
            pnlMenu.Size = new Size(280, 596);
            pnlMenu.TabIndex = 2;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(189, 195, 199);
            btnDashboard.Location = new Point(15, 320);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(15, 0, 0, 0);
            btnDashboard.Size = new Size(250, 50);
            btnDashboard.TabIndex = 7;
            btnDashboard.Text = "📈 Thống kê";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnAttendance_1
            // 
            btnAttendance_1.BackColor = Color.Transparent;
            btnAttendance_1.Cursor = Cursors.Hand;
            btnAttendance_1.Dock = DockStyle.Top;
            btnAttendance_1.FlatAppearance.BorderSize = 0;
            btnAttendance_1.FlatStyle = FlatStyle.Flat;
            btnAttendance_1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAttendance_1.ForeColor = Color.FromArgb(189, 195, 199);
            btnAttendance_1.Location = new Point(15, 270);
            btnAttendance_1.Name = "btnAttendance_1";
            btnAttendance_1.Padding = new Padding(15, 0, 0, 0);
            btnAttendance_1.Size = new Size(250, 50);
            btnAttendance_1.TabIndex = 6;
            btnAttendance_1.Text = "✔ Chấm Công";
            btnAttendance_1.TextAlign = ContentAlignment.MiddleLeft;
            btnAttendance_1.UseVisualStyleBackColor = false;
            btnAttendance_1.Click += btnAttendance_1_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(231, 76, 60);
            btnLogout.Location = new Point(15, 526);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(250, 50);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "🚪 Đăng Xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAttendance
            // 
            btnAttendance.BackColor = Color.Transparent;
            btnAttendance.Cursor = Cursors.Hand;
            btnAttendance.Dock = DockStyle.Top;
            btnAttendance.FlatAppearance.BorderSize = 0;
            btnAttendance.FlatStyle = FlatStyle.Flat;
            btnAttendance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAttendance.ForeColor = Color.FromArgb(189, 195, 199);
            btnAttendance.Location = new Point(15, 220);
            btnAttendance.Name = "btnAttendance";
            btnAttendance.Padding = new Padding(15, 0, 0, 0);
            btnAttendance.Size = new Size(250, 50);
            btnAttendance.TabIndex = 4;
            btnAttendance.Text = "📅 Quản Lý Chấm Công";
            btnAttendance.TextAlign = ContentAlignment.MiddleLeft;
            btnAttendance.UseVisualStyleBackColor = false;
            btnAttendance.Click += btnAttendance_Click;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.Transparent;
            btnUser.Cursor = Cursors.Hand;
            btnUser.Dock = DockStyle.Top;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUser.ForeColor = Color.FromArgb(189, 195, 199);
            btnUser.Location = new Point(15, 170);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(15, 0, 0, 0);
            btnUser.Size = new Size(250, 50);
            btnUser.TabIndex = 3;
            btnUser.Text = "👤 Quản Lý Người Dùng";
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.BackColor = Color.Transparent;
            btnEmployee.Cursor = Cursors.Hand;
            btnEmployee.Dock = DockStyle.Top;
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEmployee.ForeColor = Color.FromArgb(189, 195, 199);
            btnEmployee.Location = new Point(15, 120);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Padding = new Padding(15, 0, 0, 0);
            btnEmployee.Size = new Size(250, 50);
            btnEmployee.TabIndex = 2;
            btnEmployee.Text = "👥 Quản Lý Nhân Sự";
            btnEmployee.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployee.UseVisualStyleBackColor = false;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnPosition
            // 
            btnPosition.BackColor = Color.Transparent;
            btnPosition.Cursor = Cursors.Hand;
            btnPosition.Dock = DockStyle.Top;
            btnPosition.FlatAppearance.BorderSize = 0;
            btnPosition.FlatStyle = FlatStyle.Flat;
            btnPosition.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPosition.ForeColor = Color.FromArgb(189, 195, 199);
            btnPosition.Location = new Point(15, 70);
            btnPosition.Name = "btnPosition";
            btnPosition.Padding = new Padding(15, 0, 0, 0);
            btnPosition.Size = new Size(250, 50);
            btnPosition.TabIndex = 1;
            btnPosition.Text = "💼 Quản Lý Chức Danh";
            btnPosition.TextAlign = ContentAlignment.MiddleLeft;
            btnPosition.UseVisualStyleBackColor = false;
            btnPosition.Click += btnPosition_Click;
            // 
            // btnDepartment
            // 
            btnDepartment.BackColor = Color.FromArgb(52, 152, 219);
            btnDepartment.Cursor = Cursors.Hand;
            btnDepartment.Dock = DockStyle.Top;
            btnDepartment.FlatAppearance.BorderSize = 0;
            btnDepartment.FlatStyle = FlatStyle.Flat;
            btnDepartment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDepartment.ForeColor = Color.White;
            btnDepartment.Location = new Point(15, 20);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Padding = new Padding(15, 0, 0, 0);
            btnDepartment.Size = new Size(250, 50);
            btnDepartment.TabIndex = 0;
            btnDepartment.Text = "🏢 Quản Lý Phòng Ban";
            btnDepartment.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartment.UseVisualStyleBackColor = false;
            btnDepartment.Click += btnDepartment_Click;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.BackColor = Color.FromArgb(52, 73, 94);
            pnlUserInfo.Controls.Add(lblUserRole);
            pnlUserInfo.Controls.Add(lblUserName);
            pnlUserInfo.Controls.Add(picAvatar);
            pnlUserInfo.Dock = DockStyle.Top;
            pnlUserInfo.Location = new Point(0, 80);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Padding = new Padding(20);
            pnlUserInfo.Size = new Size(280, 100);
            pnlUserInfo.TabIndex = 1;
            // 
            // lblUserRole
            // 
            lblUserRole.Font = new Font("Segoe UI", 9F);
            lblUserRole.ForeColor = Color.FromArgb(189, 195, 199);
            lblUserRole.Location = new Point(80, 50);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(180, 20);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "👤 Quản trị viên";
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(80, 25);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(180, 25);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Nguyễn Văn A";
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(52, 152, 219);
            picAvatar.Location = new Point(20, 25);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(50, 50);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            picAvatar.Paint += picAvatar_Paint;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(52, 73, 94);
            pnlLogo.Controls.Add(lblAppName);
            pnlLogo.Controls.Add(lblAppIcon);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(280, 80);
            pnlLogo.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(80, 15);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(180, 50);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "HR Manager";
            lblAppName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAppIcon
            // 
            lblAppIcon.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAppIcon.ForeColor = Color.White;
            lblAppIcon.Location = new Point(20, 15);
            lblAppIcon.Name = "lblAppIcon";
            lblAppIcon.Size = new Size(60, 50);
            lblAppIcon.TabIndex = 0;
            lblAppIcon.Text = "🏢";
            lblAppIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(248, 249, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(280, 24);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1120, 776);
            pnlContent.TabIndex = 2;
            // 
            // menuStrip
            // 
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1400, 24);
            menuStrip.TabIndex = 2;
            // 
            // F_App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1400, 800);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1200, 700);
            Name = "F_App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HR Management System";
            WindowState = FormWindowState.Maximized;
            Load += F_App_Load;
            pnlSidebar.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlLogo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlLogo;
        private Label lblAppIcon;
        private Label lblAppName;
        private Panel pnlUserInfo;
        private PictureBox picAvatar;
        private Label lblUserName;
        private Label lblUserRole;
        private Panel pnlMenu;
        private MenuButton btnDepartment;
        private MenuButton btnPosition;
        private MenuButton btnEmployee;
        private MenuButton btnUser;
        private MenuButton btnAttendance;
        private MenuButton btnLogout;
        private Panel pnlContent;
        private MenuButton btnDashboard;
        private MenuButton btnAttendance_1;
        private MenuStrip menuStrip;
    }

    public class MenuButton : Button
    {
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            if (BackColor == Color.Transparent)
                BackColor = Color.FromArgb(52, 73, 94);
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (BackColor == Color.FromArgb(52, 73, 94))
                BackColor = Color.Transparent;
        }
    }

    public class RoundedButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddArc(0, 0, 10, 10, 180, 90);
            grPath.AddArc(this.Width - 11, 0, 10, 10, 270, 90);
            grPath.AddArc(this.Width - 11, this.Height - 11, 10, 10, 0, 90);
            grPath.AddArc(0, this.Height - 11, 10, 10, 90, 90);
            this.Region = new Region(grPath);
            base.OnPaint(e);
        }
    }
}