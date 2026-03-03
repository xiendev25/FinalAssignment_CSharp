using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    partial class F_Dashboard
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
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlContainer = new Panel();
            pnlStatsRow = new Panel();
            pnlCardUser = new Panel();
            lblUserTitle = new Label();
            lblUserValue = new Label();
            lblUserIcon = new Label();
            pnlCardAttendance = new Panel();
            lblAttTitle = new Label();
            lblAttValue = new Label();
            lblAttIcon = new Label();
            pnlCardEmployee = new Panel();
            lblEmpTitle = new Label();
            lblEmpValue = new Label();
            lblEmpIcon = new Label();
            pnlCardPosition = new Panel();
            lblPosTitle = new Label();
            lblPosValue = new Label();
            lblPosIcon = new Label();
            pnlCardDepartment = new Panel();
            lblDeptTitle = new Label();
            lblDeptValue = new Label();
            lblDeptIcon = new Label();
            pnlStatus = new Panel();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlContainer.SuspendLayout();
            pnlStatsRow.SuspendLayout();
            pnlCardUser.SuspendLayout();
            pnlCardAttendance.SuspendLayout();
            pnlCardEmployee.SuspendLayout();
            pnlCardPosition.SuspendLayout();
            pnlCardDepartment.SuspendLayout();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1400, 90);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitle.Location = new Point(35, 55);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(800, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Xem thống kê tổng quan về nhân sự, phòng ban và chấm công";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Tổng Quan Hệ Thống";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(248, 249, 250);
            pnlContainer.Controls.Add(pnlStatsRow);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 90);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(25, 20, 25, 20);
            pnlContainer.Size = new Size(1400, 637);
            pnlContainer.TabIndex = 1;
            // 
            // pnlStatsRow
            // 
            pnlStatsRow.BackColor = Color.Transparent;
            pnlStatsRow.Controls.Add(pnlCardUser);
            pnlStatsRow.Controls.Add(pnlCardAttendance);
            pnlStatsRow.Controls.Add(pnlCardEmployee);
            pnlStatsRow.Controls.Add(pnlCardPosition);
            pnlStatsRow.Controls.Add(pnlCardDepartment);
            pnlStatsRow.Dock = DockStyle.Top;
            pnlStatsRow.Location = new Point(25, 20);
            pnlStatsRow.Name = "pnlStatsRow";
            pnlStatsRow.Size = new Size(1350, 160);
            pnlStatsRow.TabIndex = 0;
            // 
            // pnlCardUser
            // 
            pnlCardUser.BackColor = Color.White;
            pnlCardUser.Controls.Add(lblUserTitle);
            pnlCardUser.Controls.Add(lblUserValue);
            pnlCardUser.Controls.Add(lblUserIcon);
            pnlCardUser.Location = new Point(1080, 0);
            pnlCardUser.Name = "pnlCardUser";
            pnlCardUser.Size = new Size(255, 150);
            pnlCardUser.TabIndex = 4;
            pnlCardUser.Paint += pnlCard_Paint;
            // 
            // lblUserTitle
            // 
            lblUserTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserTitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblUserTitle.Location = new Point(20, 100);
            lblUserTitle.Name = "lblUserTitle";
            lblUserTitle.Size = new Size(215, 30);
            lblUserTitle.TabIndex = 2;
            lblUserTitle.Text = "Tổng Người Dùng";
            // 
            // lblUserValue
            // 
            lblUserValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblUserValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblUserValue.Location = new Point(100, 20);
            lblUserValue.Name = "lblUserValue";
            lblUserValue.Size = new Size(135, 60);
            lblUserValue.TabIndex = 1;
            lblUserValue.Text = "8";
            lblUserValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserIcon
            // 
            lblUserIcon.Font = new Font("Segoe UI", 36F);
            lblUserIcon.Location = new Point(20, 20);
            lblUserIcon.Name = "lblUserIcon";
            lblUserIcon.Size = new Size(70, 60);
            lblUserIcon.TabIndex = 0;
            lblUserIcon.Text = "👤";
            // 
            // pnlCardAttendance
            // 
            pnlCardAttendance.BackColor = Color.White;
            pnlCardAttendance.Controls.Add(lblAttTitle);
            pnlCardAttendance.Controls.Add(lblAttValue);
            pnlCardAttendance.Controls.Add(lblAttIcon);
            pnlCardAttendance.Location = new Point(810, 0);
            pnlCardAttendance.Name = "pnlCardAttendance";
            pnlCardAttendance.Size = new Size(255, 150);
            pnlCardAttendance.TabIndex = 3;
            pnlCardAttendance.Paint += pnlCard_Paint;
            // 
            // lblAttTitle
            // 
            lblAttTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAttTitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblAttTitle.Location = new Point(20, 100);
            lblAttTitle.Name = "lblAttTitle";
            lblAttTitle.Size = new Size(215, 30);
            lblAttTitle.TabIndex = 2;
            lblAttTitle.Text = "Điểm Danh Hôm Nay";
            // 
            // lblAttValue
            // 
            lblAttValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblAttValue.ForeColor = Color.FromArgb(230, 126, 34);
            lblAttValue.Location = new Point(100, 20);
            lblAttValue.Name = "lblAttValue";
            lblAttValue.Size = new Size(135, 60);
            lblAttValue.TabIndex = 1;
            lblAttValue.Text = "89";
            lblAttValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAttIcon
            // 
            lblAttIcon.Font = new Font("Segoe UI", 36F);
            lblAttIcon.Location = new Point(20, 20);
            lblAttIcon.Name = "lblAttIcon";
            lblAttIcon.Size = new Size(70, 60);
            lblAttIcon.TabIndex = 0;
            lblAttIcon.Text = "📅";
            // 
            // pnlCardEmployee
            // 
            pnlCardEmployee.BackColor = Color.White;
            pnlCardEmployee.Controls.Add(lblEmpTitle);
            pnlCardEmployee.Controls.Add(lblEmpValue);
            pnlCardEmployee.Controls.Add(lblEmpIcon);
            pnlCardEmployee.Location = new Point(540, 0);
            pnlCardEmployee.Name = "pnlCardEmployee";
            pnlCardEmployee.Size = new Size(255, 150);
            pnlCardEmployee.TabIndex = 2;
            pnlCardEmployee.Paint += pnlCard_Paint;
            // 
            // lblEmpTitle
            // 
            lblEmpTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEmpTitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblEmpTitle.Location = new Point(20, 100);
            lblEmpTitle.Name = "lblEmpTitle";
            lblEmpTitle.Size = new Size(215, 30);
            lblEmpTitle.TabIndex = 2;
            lblEmpTitle.Text = "Tổng Nhân Sự";
            // 
            // lblEmpValue
            // 
            lblEmpValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblEmpValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblEmpValue.Location = new Point(100, 20);
            lblEmpValue.Name = "lblEmpValue";
            lblEmpValue.Size = new Size(135, 60);
            lblEmpValue.TabIndex = 1;
            lblEmpValue.Text = "156";
            lblEmpValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmpIcon
            // 
            lblEmpIcon.Font = new Font("Segoe UI", 36F);
            lblEmpIcon.Location = new Point(20, 20);
            lblEmpIcon.Name = "lblEmpIcon";
            lblEmpIcon.Size = new Size(70, 60);
            lblEmpIcon.TabIndex = 0;
            lblEmpIcon.Text = "👥";
            // 
            // pnlCardPosition
            // 
            pnlCardPosition.BackColor = Color.White;
            pnlCardPosition.Controls.Add(lblPosTitle);
            pnlCardPosition.Controls.Add(lblPosValue);
            pnlCardPosition.Controls.Add(lblPosIcon);
            pnlCardPosition.Location = new Point(270, 0);
            pnlCardPosition.Name = "pnlCardPosition";
            pnlCardPosition.Size = new Size(255, 150);
            pnlCardPosition.TabIndex = 1;
            pnlCardPosition.Paint += pnlCard_Paint;
            // 
            // lblPosTitle
            // 
            lblPosTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPosTitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblPosTitle.Location = new Point(20, 100);
            lblPosTitle.Name = "lblPosTitle";
            lblPosTitle.Size = new Size(215, 30);
            lblPosTitle.TabIndex = 2;
            lblPosTitle.Text = "Tổng Chức Danh";
            // 
            // lblPosValue
            // 
            lblPosValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblPosValue.ForeColor = Color.FromArgb(155, 89, 182);
            lblPosValue.Location = new Point(100, 20);
            lblPosValue.Name = "lblPosValue";
            lblPosValue.Size = new Size(135, 60);
            lblPosValue.TabIndex = 1;
            lblPosValue.Text = "25";
            lblPosValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPosIcon
            // 
            lblPosIcon.Font = new Font("Segoe UI", 36F);
            lblPosIcon.Location = new Point(20, 20);
            lblPosIcon.Name = "lblPosIcon";
            lblPosIcon.Size = new Size(70, 60);
            lblPosIcon.TabIndex = 0;
            lblPosIcon.Text = "💼";
            // 
            // pnlCardDepartment
            // 
            pnlCardDepartment.BackColor = Color.White;
            pnlCardDepartment.Controls.Add(lblDeptTitle);
            pnlCardDepartment.Controls.Add(lblDeptValue);
            pnlCardDepartment.Controls.Add(lblDeptIcon);
            pnlCardDepartment.Location = new Point(0, 0);
            pnlCardDepartment.Name = "pnlCardDepartment";
            pnlCardDepartment.Size = new Size(255, 150);
            pnlCardDepartment.TabIndex = 0;
            pnlCardDepartment.Paint += pnlCard_Paint;
            // 
            // lblDeptTitle
            // 
            lblDeptTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDeptTitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblDeptTitle.Location = new Point(20, 100);
            lblDeptTitle.Name = "lblDeptTitle";
            lblDeptTitle.Size = new Size(215, 30);
            lblDeptTitle.TabIndex = 2;
            lblDeptTitle.Text = "Tổng Phòng Ban";
            // 
            // lblDeptValue
            // 
            lblDeptValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblDeptValue.ForeColor = Color.FromArgb(52, 152, 219);
            lblDeptValue.Location = new Point(100, 20);
            lblDeptValue.Name = "lblDeptValue";
            lblDeptValue.Size = new Size(135, 60);
            lblDeptValue.TabIndex = 1;
            lblDeptValue.Text = "12";
            lblDeptValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDeptIcon
            // 
            lblDeptIcon.Font = new Font("Segoe UI", 36F);
            lblDeptIcon.Location = new Point(20, 20);
            lblDeptIcon.Name = "lblDeptIcon";
            lblDeptIcon.Size = new Size(70, 60);
            lblDeptIcon.TabIndex = 0;
            lblDeptIcon.Text = "🏢";
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.White;
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Dock = DockStyle.Bottom;
            pnlStatus.Location = new Point(0, 727);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(1400, 40);
            pnlStatus.TabIndex = 2;
            pnlStatus.Paint += pnlStatus_Paint;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(127, 140, 141);
            lblStatus.Location = new Point(30, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1000, 40);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "⚡ Cập nhật lúc: 15:30:45 - 03/11/2024";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // F_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1400, 767);
            Controls.Add(pnlContainer);
            Controls.Add(pnlStatus);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1200, 700);
            Name = "F_Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tổng Quan";
            WindowState = FormWindowState.Maximized;
            Load += F_Dashboard_Load;
            pnlHeader.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            pnlStatsRow.ResumeLayout(false);
            pnlCardUser.ResumeLayout(false);
            pnlCardAttendance.ResumeLayout(false);
            pnlCardEmployee.ResumeLayout(false);
            pnlCardPosition.ResumeLayout(false);
            pnlCardDepartment.ResumeLayout(false);
            pnlStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlContainer;
        private Panel pnlStatsRow;

        // Stats Cards
        private Panel pnlCardDepartment;
        private Label lblDeptIcon;
        private Label lblDeptValue;
        private Label lblDeptTitle;

        private Panel pnlCardPosition;
        private Label lblPosIcon;
        private Label lblPosValue;
        private Label lblPosTitle;

        private Panel pnlCardEmployee;
        private Label lblEmpIcon;
        private Label lblEmpValue;
        private Label lblEmpTitle;

        private Panel pnlCardAttendance;
        private Label lblAttIcon;
        private Label lblAttValue;
        private Label lblAttTitle;

        private Panel pnlCardUser;
        private Label lblUserIcon;
        private Label lblUserValue;
        private Label lblUserTitle;
        private Panel pnlAttendanceChart;
        private Label lblAttChartTitle;
        private Panel pnlAttChartContent;

        private Panel pnlStatus;
        private Label lblStatus;
    }
}