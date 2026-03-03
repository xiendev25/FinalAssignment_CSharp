using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    partial class F_User
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
            pnlCard = new Panel();
            dgvUsers = new DataGridView();
            pnlToolbar = new Panel();
            flpActions = new FlowLayoutPanel();
            btnAdd = new RoundedButton();
            btnEdit = new RoundedButton();
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
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
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
            lblSubtitle.Text = "Quản lý tài khoản người dùng, tìm kiếm theo username";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(700, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👥 Quản Lý Người Dùng";
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
            pnlCard.Controls.Add(dgvUsers);
            pnlCard.Controls.Add(pnlToolbar);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(25, 20);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(1050, 597);
            pnlCard.TabIndex = 0;
            pnlCard.Paint += pnlCard_Paint;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 45;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(230, 230, 230);
            dgvUsers.Location = new Point(0, 116);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1050, 481);
            dgvUsers.TabIndex = 1;
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
            flpActions.Controls.Add(btnAdd);
            flpActions.Controls.Add(btnEdit);
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
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Margin = new Padding(0, 0, 8, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 42);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "➕ Thêm Mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += btn_MouseEnter;
            btnAdd.MouseLeave += btn_MouseLeave;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(148, 0);
            btnEdit.Margin = new Padding(0, 0, 8, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 42);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Chỉnh Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            btnEdit.MouseEnter += btn_MouseEnter;
            btnEdit.MouseLeave += btn_MouseLeave;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(276, 0);
            btnDelete.Margin = new Padding(0, 0, 8, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 42);
            btnDelete.TabIndex = 3;
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
            btnRefresh.Location = new Point(384, 0);
            btnRefresh.Margin = new Padding(0, 0, 8, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 42);
            btnRefresh.TabIndex = 4;
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
            btnExportJson.Location = new Point(512, 0);
            btnExportJson.Margin = new Padding(0, 0, 8, 0);
            btnExportJson.Name = "btnExportJson";
            btnExportJson.Size = new Size(130, 42);
            btnExportJson.TabIndex = 5;
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
            btnExportExcel.Location = new Point(650, 0);
            btnExportExcel.Margin = new Padding(0);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(150, 42);
            btnExportExcel.TabIndex = 6;
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
            txtSearch.Text = "Tìm kiếm theo username...";
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
            lblStatus.Size = new Size(900, 40);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "⚡ Sẵn sàng | Tổng số: 0 người dùng";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // F_User
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
            Name = "F_User";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Người Dùng";
            WindowState = FormWindowState.Maximized;
            Load += F_User_Load;
            pnlHeader.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
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
        private RoundedButton btnAdd;
        private RoundedButton btnEdit;
        private RoundedButton btnDelete;
        private RoundedButton btnRefresh;
        private RoundedButton btnExportJson;
        private RoundedButton btnExportExcel;
        private DataGridView dgvUsers;
        private Panel pnlStatus;
        private Label lblStatus;
        private FlowLayoutPanel flpActions;
    }
}
