using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class F_Employee_Action
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
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            pnlRow2 = new Panel();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblDOB = new Label();
            dtpDOB = new DateTimePicker();
            pnlRow3 = new Panel();
            lblDepartment = new Label();
            cboDepartment = new ComboBox();
            lblPosition = new Label();
            cboPosition = new ComboBox();
            pnlRow4 = new Panel();
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
            pnlRow4.SuspendLayout();
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
            pnlHeader.Size = new Size(720, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(30, 20);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(650, 40);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "➕ THÊM NHÂN SỰ MỚI";
            lblFormTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(pnlRow4);
            pnlContent.Controls.Add(pnlRow3);
            pnlContent.Controls.Add(pnlRow2);
            pnlContent.Controls.Add(pnlRow1);
            pnlContent.Location = new Point(30, 95);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(660, 300);
            pnlContent.TabIndex = 1;
            // 
            // pnlRow1
            // 
            pnlRow1.Controls.Add(txtName);
            pnlRow1.Controls.Add(lblName);
            pnlRow1.Controls.Add(txtCode);
            pnlRow1.Controls.Add(lblCode);
            pnlRow1.Location = new Point(0, 5);
            pnlRow1.Name = "pnlRow1";
            pnlRow1.Size = new Size(660, 60);
            pnlRow1.TabIndex = 0;
            // 
            // lblCode
            // 
            lblCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCode.ForeColor = Color.FromArgb(44, 62, 80);
            lblCode.Location = new Point(0, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(140, 23);
            lblCode.TabIndex = 0;
            lblCode.Text = "Mã Nhân Sự *";
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(248, 249, 250);
            txtCode.BorderStyle = BorderStyle.None;
            txtCode.Font = new Font("Segoe UI", 11F);
            txtCode.Location = new Point(10, 28);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(260, 20);
            txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(330, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(140, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Tên Nhân Sự *";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(248, 249, 250);
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.Location = new Point(340, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 20);
            txtName.TabIndex = 3;
            // 
            // pnlRow2
            // 
            pnlRow2.Controls.Add(dtpDOB);
            pnlRow2.Controls.Add(lblDOB);
            pnlRow2.Controls.Add(cboGender);
            pnlRow2.Controls.Add(lblGender);
            pnlRow2.Location = new Point(0, 75);
            pnlRow2.Name = "pnlRow2";
            pnlRow2.Size = new Size(660, 60);
            pnlRow2.TabIndex = 1;
            // 
            // lblGender
            // 
            lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(44, 62, 80);
            lblGender.Location = new Point(0, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(140, 23);
            lblGender.TabIndex = 0;
            lblGender.Text = "Giới Tính";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.Location = new Point(10, 26);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(260, 25);
            cboGender.TabIndex = 1;
            // 
            // lblDOB
            // 
            lblDOB.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDOB.ForeColor = Color.FromArgb(44, 62, 80);
            lblDOB.Location = new Point(330, 0);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(160, 23);
            lblDOB.TabIndex = 2;
            lblDOB.Text = "Ngày Sinh";
            // 
            // dtpDOB
            // 
            dtpDOB.CalendarMonthBackground = Color.White;
            dtpDOB.Font = new Font("Segoe UI", 10F);
            dtpDOB.Location = new Point(340, 24);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(300, 25);
            dtpDOB.TabIndex = 3;
            // 
            // pnlRow3
            // 
            pnlRow3.Controls.Add(cboPosition);
            pnlRow3.Controls.Add(lblPosition);
            pnlRow3.Controls.Add(cboDepartment);
            pnlRow3.Controls.Add(lblDepartment);
            pnlRow3.Location = new Point(0, 145);
            pnlRow3.Name = "pnlRow3";
            pnlRow3.Size = new Size(660, 60);
            pnlRow3.TabIndex = 2;
            // 
            // lblDepartment
            // 
            lblDepartment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDepartment.ForeColor = Color.FromArgb(44, 62, 80);
            lblDepartment.Location = new Point(0, 0);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(140, 23);
            lblDepartment.TabIndex = 0;
            lblDepartment.Text = "Phòng Ban *";
            // 
            // cboDepartment
            // 
            cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartment.Font = new Font("Segoe UI", 10F);
            cboDepartment.Location = new Point(10, 26);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(260, 25);
            cboDepartment.TabIndex = 1;
            // 
            // lblPosition
            // 
            lblPosition.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPosition.ForeColor = Color.FromArgb(44, 62, 80);
            lblPosition.Location = new Point(330, 0);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(160, 23);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "Chức Danh *";
            // 
            // cboPosition
            // 
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPosition.Font = new Font("Segoe UI", 10F);
            cboPosition.Location = new Point(340, 26);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(300, 25);
            cboPosition.TabIndex = 3;
            // 
            // pnlRow4
            // 
            pnlRow4.Controls.Add(chkIsActive);
            pnlRow4.Controls.Add(lblIsActive);
            pnlRow4.Location = new Point(0, 215);
            pnlRow4.Name = "pnlRow4";
            pnlRow4.Size = new Size(660, 55);
            pnlRow4.TabIndex = 3;
            // 
            // lblIsActive
            // 
            lblIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIsActive.ForeColor = Color.FromArgb(44, 62, 80);
            lblIsActive.Location = new Point(0, 0);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(140, 23);
            lblIsActive.TabIndex = 0;
            lblIsActive.Text = "Trạng Thái";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = false;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 10F);
            chkIsActive.ForeColor = Color.FromArgb(44, 62, 80);
            chkIsActive.Location = new Point(10, 22);
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
            pnlButtons.Location = new Point(30, 410);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(660, 60);
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
            btnSave.Location = new Point(360, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
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
            btnCancel.Location = new Point(520, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btn_MouseEnter;
            btnCancel.MouseLeave += btn_MouseLeave;
            // 
            // F_Employee_Action
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(720, 490);
            Controls.Add(pnlButtons);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "F_Employee_Action";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản Lý Nhân Sự";
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlRow1.ResumeLayout(false);
            pnlRow1.PerformLayout();
            pnlRow2.ResumeLayout(false);
            pnlRow3.ResumeLayout(false);
            pnlRow4.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Panel pnlContent;
        private Panel pnlRow1;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private TextBox txtName;
        private Panel pnlRow2;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblDOB;
        private DateTimePicker dtpDOB;
        private Panel pnlRow3;
        private Label lblDepartment;
        private ComboBox cboDepartment;
        private Label lblPosition;
        private ComboBox cboPosition;
        private Panel pnlRow4;
        private Label lblIsActive;
        private CheckBox chkIsActive;
        private Panel pnlButtons;
        private UI.RoundedButton btnCancel;
        private UI.RoundedButton btnSave;
    }
}
