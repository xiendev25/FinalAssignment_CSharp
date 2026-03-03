using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    partial class F_Attendance
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlContainer = new Panel();
            pnlCard = new Panel();
            dgvAttendances = new DataGridView();
            pnlToolbar = new Panel();
            flpActions = new FlowLayoutPanel();
            btnDelete = new RoundedButton();
            btnRefresh = new RoundedButton();
            btnExportJson = new RoundedButton();
            btnExportExcel = new RoundedButton();
            pnlSearchBox = new Panel();
            txtSearch = new TextBox();
            pnlStatus = new Panel();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlContainer.SuspendLayout();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendances).BeginInit();
            pnlToolbar.SuspendLayout();
            flpActions.SuspendLayout();
            pnlSearchBox.SuspendLayout();
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
            pnlHeader.Size = new Size(1100, 90);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitle.Location = new Point(35, 55);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(700, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Danh sách chấm công theo ngày làm việc, tìm kiếm theo mã nhân sự";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(700, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🕒 Quản Lý Chấm Công";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(248, 249, 250);
            pnlContainer.Controls.Add(pnlCard);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 90);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(25, 20, 25, 20);
            pnlContainer.Size = new Size(1100, 637);
            pnlContainer.TabIndex = 1;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(dgvAttendances);
            pnlCard.Controls.Add(pnlToolbar);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(25, 20);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(1050, 597);
            pnlCard.TabIndex = 0;
            pnlCard.Paint += pnlCard_Paint;
            // 
            // dgvAttendances
            // 
            dgvAttendances.AllowUserToAddRows = false;
            dgvAttendances.AllowUserToDeleteRows = false;
            dgvAttendances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendances.BackgroundColor = Color.White;
            dgvAttendances.BorderStyle = BorderStyle.None;
            dgvAttendances.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAttendances.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAttendances.ColumnHeadersHeight = 45;
            dgvAttendances.Dock = DockStyle.Fill;
            dgvAttendances.EnableHeadersVisualStyles = false;
            dgvAttendances.GridColor = Color.FromArgb(230, 230, 230);
            dgvAttendances.Location = new Point(0, 116);
            dgvAttendances.MultiSelect = false;
            dgvAttendances.Name = "dgvAttendances";
            dgvAttendances.ReadOnly = true;
            dgvAttendances.RowHeadersVisible = false;
            dgvAttendances.RowTemplate.Height = 40;
            dgvAttendances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendances.Size = new Size(1050, 481);
            dgvAttendances.TabIndex = 1;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(flpActions);
            pnlToolbar.Controls.Add(pnlSearchBox);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(20, 15, 20, 15);
            pnlToolbar.Size = new Size(1050, 116);
            pnlToolbar.TabIndex = 0;
            // 
            // flpActions
            // 
            flpActions.BackColor = Color.White;
            flpActions.Controls.Add(btnDelete);
            flpActions.Controls.Add(btnRefresh);
            flpActions.Controls.Add(btnExportJson);
            flpActions.Controls.Add(btnExportExcel);
            flpActions.Dock = DockStyle.Fill;
            flpActions.Location = new Point(20, 57);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(1010, 44);
            flpActions.TabIndex = 1;
            flpActions.WrapContents = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 0);
            btnDelete.Margin = new Padding(0, 0, 8, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 42);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑️ Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseEnter += btn_MouseEnter;
            btnDelete.MouseLeave += btn_MouseLeave;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(128, 0);
            btnRefresh.Margin = new Padding(0, 0, 8, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 42);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Làm Mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            btnRefresh.MouseEnter += btn_MouseEnter;
            btnRefresh.MouseLeave += btn_MouseLeave;
            // 
            // btnExportJson
            // 
            btnExportJson.BackColor = Color.FromArgb(155, 89, 182);
            btnExportJson.Cursor = Cursors.Hand;
            btnExportJson.FlatAppearance.BorderSize = 0;
            btnExportJson.FlatStyle = FlatStyle.Flat;
            btnExportJson.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportJson.ForeColor = Color.White;
            btnExportJson.Location = new Point(256, 0);
            btnExportJson.Margin = new Padding(0, 0, 8, 0);
            btnExportJson.Name = "btnExportJson";
            btnExportJson.Size = new Size(140, 42);
            btnExportJson.TabIndex = 3;
            btnExportJson.Text = "📤 Xuất JSON";
            btnExportJson.UseVisualStyleBackColor = false;
            btnExportJson.Click += btnExportJson_Click;
            btnExportJson.MouseEnter += btn_MouseEnter;
            btnExportJson.MouseLeave += btn_MouseLeave;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.FromArgb(26, 188, 156);
            btnExportExcel.Cursor = Cursors.Hand;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(404, 0);
            btnExportExcel.Margin = new Padding(0);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(170, 42);
            btnExportExcel.TabIndex = 4;
            btnExportExcel.Text = "📊 Xuất Excel (CSV)";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            btnExportExcel.MouseEnter += btn_MouseEnter;
            btnExportExcel.MouseLeave += btn_MouseLeave;
            // 
            // pnlSearchBox
            // 
            pnlSearchBox.BackColor = Color.FromArgb(248, 249, 250);
            pnlSearchBox.Controls.Add(txtSearch);
            pnlSearchBox.Dock = DockStyle.Top;
            pnlSearchBox.Location = new Point(20, 15);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Size = new Size(1010, 42);
            pnlSearchBox.TabIndex = 0;
            pnlSearchBox.Paint += pnlSearchBox_Paint;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(248, 249, 250);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(45, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(950, 20);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Tìm kiếm theo mã nhân sự...";
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.White;
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Dock = DockStyle.Bottom;
            pnlStatus.Location = new Point(0, 727);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(1100, 40);
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
            lblStatus.Size = new Size(800, 40);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "⚡ Sẵn sàng | Tổng số: 0 bản ghi chấm công";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // F_Attendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 767);
            Controls.Add(pnlContainer);
            Controls.Add(pnlStatus);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1000, 600);
            Name = "F_Attendance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Chấm Công";
            WindowState = FormWindowState.Maximized;
            Load += F_Attendance_Load;
            pnlHeader.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendances).EndInit();
            pnlToolbar.ResumeLayout(false);
            flpActions.ResumeLayout(false);
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            pnlStatus.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlContainer;
        private Panel pnlCard;
        private Panel pnlToolbar;
        private Panel pnlSearchBox;
        private TextBox txtSearch;
        private RoundedButton btnDelete;
        private RoundedButton btnRefresh;
        private RoundedButton btnExportJson;
        private RoundedButton btnExportExcel;
        private DataGridView dgvAttendances;
        private Panel pnlStatus;
        private Label lblStatus;
        private FlowLayoutPanel flpActions;
    }
}
