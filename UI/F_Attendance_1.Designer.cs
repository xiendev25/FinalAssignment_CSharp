using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    partial class F_Attendance_1
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
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlContainer = new Panel();
            pnlRightSection = new Panel();
            pnlHistoryCard = new Panel();
            dgvToday = new DataGridView();
            Attendance = new DataGridViewTextBoxColumn();
            lblHistoryTitle = new Label();
            pnlLeftSection = new Panel();
            pnlInputCard = new Panel();
            pnlButtons = new Panel();
            btnCheckOut = new RoundedButton();
            btnCheckIn = new RoundedButton();
            pnlCodeBox = new Panel();
            txtCode = new TextBox();
            lblInputTitle = new Label();
            pnlClockCard = new Panel();
            lblNow = new Label();
            lblToday = new Label();
            lblClockTitle = new Label();
            pnlStatus = new Panel();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlContainer.SuspendLayout();
            pnlRightSection.SuspendLayout();
            pnlHistoryCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvToday).BeginInit();
            pnlLeftSection.SuspendLayout();
            pnlInputCard.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlCodeBox.SuspendLayout();
            pnlClockCard.SuspendLayout();
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
            lblSubtitle.Text = "Quét mã hoặc nhập mã nhân viên để ghi nhận thời gian làm việc";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🕒 Hệ Thống Chấm Công";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(248, 249, 250);
            pnlContainer.Controls.Add(pnlRightSection);
            pnlContainer.Controls.Add(pnlLeftSection);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 90);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(25, 20, 25, 20);
            pnlContainer.Size = new Size(1400, 637);
            pnlContainer.TabIndex = 1;
            // 
            // pnlRightSection
            // 
            pnlRightSection.BackColor = Color.Transparent;
            pnlRightSection.Controls.Add(pnlHistoryCard);
            pnlRightSection.Dock = DockStyle.Fill;
            pnlRightSection.Location = new Point(575, 20);
            pnlRightSection.Name = "pnlRightSection";
            pnlRightSection.Size = new Size(800, 597);
            pnlRightSection.TabIndex = 1;
            // 
            // pnlHistoryCard
            // 
            pnlHistoryCard.BackColor = Color.White;
            pnlHistoryCard.Controls.Add(dgvToday);
            pnlHistoryCard.Controls.Add(lblHistoryTitle);
            pnlHistoryCard.Dock = DockStyle.Fill;
            pnlHistoryCard.Location = new Point(0, 0);
            pnlHistoryCard.Name = "pnlHistoryCard";
            pnlHistoryCard.Padding = new Padding(25, 20, 25, 20);
            pnlHistoryCard.Size = new Size(800, 597);
            pnlHistoryCard.TabIndex = 0;
            pnlHistoryCard.Paint += pnlCard_Paint;
            // 
            // dgvToday
            // 
            dgvToday.AllowUserToAddRows = false;
            dgvToday.AllowUserToDeleteRows = false;
            dgvToday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvToday.BackgroundColor = Color.White;
            dgvToday.BorderStyle = BorderStyle.None;
            dgvToday.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvToday.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvToday.ColumnHeadersHeight = 45;
            dgvToday.Columns.AddRange(new DataGridViewColumn[] { Attendance });
            dgvToday.Dock = DockStyle.Fill;
            dgvToday.EnableHeadersVisualStyles = false;
            dgvToday.GridColor = Color.FromArgb(230, 230, 230);
            dgvToday.Location = new Point(25, 20);
            dgvToday.MultiSelect = false;
            dgvToday.Name = "dgvToday";
            dgvToday.ReadOnly = true;
            dgvToday.RowHeadersVisible = false;
            dgvToday.RowTemplate.Height = 45;
            dgvToday.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvToday.Size = new Size(750, 557);
            dgvToday.TabIndex = 1;
            // 
            // Attendance
            // 
            Attendance.HeaderText = "Điểm danh";
            Attendance.Name = "Attendance";
            Attendance.ReadOnly = true;
            // 
            // lblHistoryTitle
            // 
            lblHistoryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHistoryTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblHistoryTitle.Location = new Point(25, 20);
            lblHistoryTitle.Name = "lblHistoryTitle";
            lblHistoryTitle.Size = new Size(750, 25);
            lblHistoryTitle.TabIndex = 2;
            lblHistoryTitle.Text = "📊 Lịch Sử Chấm Công Hôm Nay";
            // 
            // pnlLeftSection
            // 
            pnlLeftSection.BackColor = Color.Transparent;
            pnlLeftSection.Controls.Add(pnlInputCard);
            pnlLeftSection.Controls.Add(pnlClockCard);
            pnlLeftSection.Dock = DockStyle.Left;
            pnlLeftSection.Location = new Point(25, 20);
            pnlLeftSection.Name = "pnlLeftSection";
            pnlLeftSection.Padding = new Padding(0, 0, 15, 0);
            pnlLeftSection.Size = new Size(550, 597);
            pnlLeftSection.TabIndex = 0;
            // 
            // pnlInputCard
            // 
            pnlInputCard.BackColor = Color.White;
            pnlInputCard.Controls.Add(pnlButtons);
            pnlInputCard.Controls.Add(pnlCodeBox);
            pnlInputCard.Controls.Add(lblInputTitle);
            pnlInputCard.Dock = DockStyle.Top;
            pnlInputCard.Location = new Point(0, 160);
            pnlInputCard.Margin = new Padding(0, 15, 0, 0);
            pnlInputCard.Name = "pnlInputCard";
            pnlInputCard.Padding = new Padding(25, 20, 25, 20);
            pnlInputCard.Size = new Size(535, 437);
            pnlInputCard.TabIndex = 1;
            pnlInputCard.Paint += pnlCard_Paint;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.Add(btnCheckOut);
            pnlButtons.Controls.Add(btnCheckIn);
            pnlButtons.Location = new Point(25, 120);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(485, 100);
            pnlButtons.TabIndex = 1;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.FromArgb(52, 152, 219);
            btnCheckOut.Cursor = Cursors.Hand;
            btnCheckOut.FlatAppearance.BorderSize = 0;
            btnCheckOut.FlatStyle = FlatStyle.Flat;
            btnCheckOut.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(250, 0);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(235, 90);
            btnCheckOut.TabIndex = 1;
            btnCheckOut.Text = "🏠 CHECK OUT\n\nRa Về";
            btnCheckOut.UseVisualStyleBackColor = false;
            btnCheckOut.Click += btnCheckOut_Click;
            btnCheckOut.MouseEnter += btn_MouseEnter;
            btnCheckOut.MouseLeave += btn_MouseLeave;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.FromArgb(46, 204, 113);
            btnCheckIn.Cursor = Cursors.Hand;
            btnCheckIn.FlatAppearance.BorderSize = 0;
            btnCheckIn.FlatStyle = FlatStyle.Flat;
            btnCheckIn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(0, 0);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(235, 90);
            btnCheckIn.TabIndex = 0;
            btnCheckIn.Text = "✅ CHECK IN\n\nVào Làm";
            btnCheckIn.UseVisualStyleBackColor = false;
            btnCheckIn.Click += btnCheckIn_Click;
            btnCheckIn.MouseEnter += btn_MouseEnter;
            btnCheckIn.MouseLeave += btn_MouseLeave;
            // 
            // pnlCodeBox
            // 
            pnlCodeBox.BackColor = Color.FromArgb(248, 249, 250);
            pnlCodeBox.Controls.Add(txtCode);
            pnlCodeBox.Location = new Point(25, 55);
            pnlCodeBox.Name = "pnlCodeBox";
            pnlCodeBox.Size = new Size(485, 50);
            pnlCodeBox.TabIndex = 0;
            pnlCodeBox.Paint += pnlCodeBox_Paint;
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(248, 249, 250);
            txtCode.BorderStyle = BorderStyle.None;
            txtCode.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtCode.ForeColor = Color.FromArgb(44, 62, 80);
            txtCode.Location = new Point(55, 12);
            txtCode.Name = "txtCode";
            txtCode.PlaceholderText = "NV...";
            txtCode.Size = new Size(415, 29);
            txtCode.TabIndex = 0;
            txtCode.TextAlign = HorizontalAlignment.Center;
            txtCode.KeyDown += txtCode_KeyDown;
            // 
            // lblInputTitle
            // 
            lblInputTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInputTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblInputTitle.Location = new Point(25, 20);
            lblInputTitle.Name = "lblInputTitle";
            lblInputTitle.Size = new Size(300, 25);
            lblInputTitle.TabIndex = 2;
            lblInputTitle.Text = "🔖 Nhập Mã Nhân Viên";
            // 
            // pnlClockCard
            // 
            pnlClockCard.BackColor = Color.White;
            pnlClockCard.Controls.Add(lblNow);
            pnlClockCard.Controls.Add(lblToday);
            pnlClockCard.Controls.Add(lblClockTitle);
            pnlClockCard.Dock = DockStyle.Top;
            pnlClockCard.Location = new Point(0, 0);
            pnlClockCard.Name = "pnlClockCard";
            pnlClockCard.Padding = new Padding(25, 20, 25, 20);
            pnlClockCard.Size = new Size(535, 160);
            pnlClockCard.TabIndex = 0;
            pnlClockCard.Paint += pnlCard_Paint;
            // 
            // lblNow
            // 
            lblNow.Font = new Font("Segoe UI", 38F, FontStyle.Bold);
            lblNow.ForeColor = Color.FromArgb(41, 128, 185);
            lblNow.Location = new Point(18, 75);
            lblNow.Name = "lblNow";
            lblNow.Size = new Size(490, 60);
            lblNow.TabIndex = 0;
            lblNow.Text = "12:34:56";
            lblNow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblToday
            // 
            lblToday.Font = new Font("Segoe UI", 11F);
            lblToday.ForeColor = Color.FromArgb(127, 140, 141);
            lblToday.Location = new Point(25, 50);
            lblToday.Name = "lblToday";
            lblToday.Size = new Size(485, 25);
            lblToday.TabIndex = 1;
            lblToday.Text = "Thứ Hai, 01 Tháng 01 Năm 2025";
            // 
            // lblClockTitle
            // 
            lblClockTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblClockTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblClockTitle.Location = new Point(25, 20);
            lblClockTitle.Name = "lblClockTitle";
            lblClockTitle.Size = new Size(300, 25);
            lblClockTitle.TabIndex = 2;
            lblClockTitle.Text = "⏰ Thời Gian Hiện Tại";
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
            lblStatus.Size = new Size(900, 40);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "⚡ Sẵn sàng | Hôm nay: 0 lượt chấm công";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // F_Attendance_1
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
            Name = "F_Attendance_1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chấm Công";
            WindowState = FormWindowState.Maximized;
            Load += F_Attendance_1_Load;
            pnlHeader.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            pnlRightSection.ResumeLayout(false);
            pnlHistoryCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvToday).EndInit();
            pnlLeftSection.ResumeLayout(false);
            pnlInputCard.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlCodeBox.ResumeLayout(false);
            pnlCodeBox.PerformLayout();
            pnlClockCard.ResumeLayout(false);
            pnlStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlContainer;
        private Panel pnlLeftSection;
        private Panel pnlClockCard;
        private Label lblClockTitle;
        private Label lblToday;
        private Label lblNow;

        private Panel pnlInputCard;
        private Label lblInputTitle;
        private Panel pnlCodeBox;
        private TextBox txtCode;
        private Panel pnlButtons;
        private RoundedButton btnCheckIn;
        private RoundedButton btnCheckOut;

        private Panel pnlRightSection;
        private Panel pnlHistoryCard;
        private Label lblHistoryTitle;
        private DataGridView dgvToday;

        private Panel pnlStatus;
        private Label lblStatus;
        private DataGridViewTextBoxColumn Attendance;
    }

}