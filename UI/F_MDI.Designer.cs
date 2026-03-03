using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class F_MDI
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuLogout;
        private ToolStripMenuItem mnuExit;

        private ToolStripMenuItem mnuModules;
        private ToolStripMenuItem mnuDepartment;
        private ToolStripMenuItem mnuPosition;
        private ToolStripMenuItem mnuEmployee;
        private ToolStripMenuItem mnuUser;
        private ToolStripMenuItem mnuAttendance;
        private ToolStripMenuItem mnuAttendance1;
        private ToolStripMenuItem mnuDashboard;

        private StatusStrip statusStrip;
        private ToolStripStatusLabel sbUser;
        private ToolStripStatusLabel sbRole;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            mnuLogout = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuModules = new ToolStripMenuItem();
            mnuDepartment = new ToolStripMenuItem();
            mnuPosition = new ToolStripMenuItem();
            mnuEmployee = new ToolStripMenuItem();
            mnuUser = new ToolStripMenuItem();
            mnuAttendance = new ToolStripMenuItem();
            mnuAttendance1 = new ToolStripMenuItem();
            mnuDashboard = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            sbUser = new ToolStripStatusLabel();
            sbRole = new ToolStripStatusLabel();
            pnlContent = new Panel();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuModules });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1200, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Dock = DockStyle.Top;
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuLogout, mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(69, 20);
            mnuSystem.Text = "&Hệ thống";
            // 
            // mnuLogout
            // 
            mnuLogout.Name = "mnuLogout";
            mnuLogout.ShortcutKeys = Keys.Control | Keys.L;
            mnuLogout.Size = new Size(167, 22);
            mnuLogout.Text = "Đăng &xuất";
            mnuLogout.Click += mnuLogout_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuExit.Size = new Size(167, 22);
            mnuExit.Text = "Thoát";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuModules
            // 
            mnuModules.DropDownItems.AddRange(new ToolStripItem[] { mnuDepartment, mnuPosition, mnuEmployee, mnuUser, mnuAttendance, mnuAttendance1, mnuDashboard });
            mnuModules.Name = "mnuModules";
            mnuModules.Size = new Size(77, 20);
            mnuModules.Text = "&Chức năng";
            // 
            // mnuDepartment
            // 
            mnuDepartment.Name = "mnuDepartment";
            mnuDepartment.ShortcutKeys = Keys.Control | Keys.D;
            mnuDepartment.Size = new Size(262, 22);
            mnuDepartment.Text = "🏢 Quản lý Phòng ban";
            mnuDepartment.Click += mnuDepartment_Click;
            // 
            // mnuPosition
            // 
            mnuPosition.Name = "mnuPosition";
            mnuPosition.ShortcutKeys = Keys.Control | Keys.P;
            mnuPosition.Size = new Size(262, 22);
            mnuPosition.Text = "💼 Quản lý Chức danh";
            mnuPosition.Click += mnuPosition_Click;
            // 
            // mnuEmployee
            // 
            mnuEmployee.Name = "mnuEmployee";
            mnuEmployee.ShortcutKeys = Keys.Control | Keys.E;
            mnuEmployee.Size = new Size(262, 22);
            mnuEmployee.Text = "👥 Quản lý Nhân sự";
            mnuEmployee.Click += mnuEmployee_Click;
            // 
            // mnuUser
            // 
            mnuUser.Name = "mnuUser";
            mnuUser.ShortcutKeys = Keys.Control | Keys.U;
            mnuUser.Size = new Size(262, 22);
            mnuUser.Text = "👤 Quản lý Người dùng";
            mnuUser.Click += mnuUser_Click;
            // 
            // mnuAttendance
            // 
            mnuAttendance.Name = "mnuAttendance";
            mnuAttendance.ShortcutKeys = Keys.Control | Keys.A;
            mnuAttendance.Size = new Size(262, 22);
            mnuAttendance.Text = "📅 Quản lý Chấm công";
            mnuAttendance.Click += mnuAttendance_Click;
            // 
            // mnuAttendance1
            // 
            mnuAttendance1.Name = "mnuAttendance1";
            mnuAttendance1.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            mnuAttendance1.Size = new Size(262, 22);
            mnuAttendance1.Text = "✔ Chấm công nhanh";
            mnuAttendance1.Click += mnuAttendance1_Click;
            // 
            // mnuDashboard
            // 
            mnuDashboard.Name = "mnuDashboard";
            mnuDashboard.ShortcutKeys = Keys.Control | Keys.T;
            mnuDashboard.Size = new Size(262, 22);
            mnuDashboard.Text = "📈 Thống kê";
            mnuDashboard.Click += mnuDashboard_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { sbUser, sbRole });
            statusStrip.Location = new Point(0, 678);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1200, 22);
            statusStrip.TabIndex = 2;
            // 
            // sbUser
            // 
            sbUser.Name = "sbUser";
            sbUser.Size = new Size(0, 17);
            // 
            // sbRole
            // 
            sbRole.Name = "sbRole";
            sbRole.Size = new Size(0, 17);
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(248, 249, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 24);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1200, 654);
            pnlContent.TabIndex = 3;
            // 
            // F_MDI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlContent);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            MinimumSize = new Size(1200, 700);
            Name = "F_MDI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HR Management System (MDI)";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlContent;
    }
    
}
