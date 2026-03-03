using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class F_Position_Action
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
            lblFormTitle = new Label();
            pnlContent = new Panel();
            pnlFieldIsActive = new Panel();
            chkIsActive = new CheckBox();
            lblIsActive = new Label();
            pnlFieldName = new Panel();
            txtName = new TextBox();
            lblName = new Label();
            pnlFieldCode = new Panel();
            txtCode = new TextBox();
            lblCode = new Label();
            pnlButtons = new Panel();
            btnCancel = new UI.RoundedButton();
            btnSave = new UI.RoundedButton();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlFieldIsActive.SuspendLayout();
            pnlFieldName.SuspendLayout();
            pnlFieldCode.SuspendLayout();
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
            pnlHeader.Size = new Size(550, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(30, 20);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(490, 40);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "➕ THÊM CHỨC DANH MỚI";
            lblFormTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(pnlFieldIsActive);
            pnlContent.Controls.Add(pnlFieldName);
            pnlContent.Controls.Add(pnlFieldCode);
            pnlContent.Location = new Point(40, 100);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(470, 280);
            pnlContent.TabIndex = 1;
            // 
            // pnlFieldCode
            // 
            pnlFieldCode.Controls.Add(txtCode);
            pnlFieldCode.Controls.Add(lblCode);
            pnlFieldCode.Location = new Point(0, 10);
            pnlFieldCode.Name = "pnlFieldCode";
            pnlFieldCode.Size = new Size(470, 70);
            pnlFieldCode.TabIndex = 0;
            // 
            // lblCode
            // 
            lblCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCode.ForeColor = Color.FromArgb(44, 62, 80);
            lblCode.Location = new Point(0, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(200, 25);
            lblCode.TabIndex = 0;
            lblCode.Text = "Mã Chức Danh *";
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(248, 249, 250);
            txtCode.BorderStyle = BorderStyle.None;
            txtCode.Font = new Font("Segoe UI", 11F);
            txtCode.Location = new Point(10, 35);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(450, 20);
            txtCode.TabIndex = 1;
            txtCode.Enter += txt_Enter;
            txtCode.Leave += txt_Leave;
            // 
            // pnlFieldName
            // 
            pnlFieldName.Controls.Add(txtName);
            pnlFieldName.Controls.Add(lblName);
            pnlFieldName.Location = new Point(0, 90);
            pnlFieldName.Name = "pnlFieldName";
            pnlFieldName.Size = new Size(470, 70);
            pnlFieldName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(200, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Tên Chức Danh *";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(248, 249, 250);
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.Location = new Point(10, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(450, 20);
            txtName.TabIndex = 1;
            txtName.Enter += txt_Enter;
            txtName.Leave += txt_Leave;
            // 
            // pnlFieldIsActive
            // 
            pnlFieldIsActive.Controls.Add(chkIsActive);
            pnlFieldIsActive.Controls.Add(lblIsActive);
            pnlFieldIsActive.Location = new Point(0, 170);
            pnlFieldIsActive.Name = "pnlFieldIsActive";
            pnlFieldIsActive.Size = new Size(470, 70);
            pnlFieldIsActive.TabIndex = 2;
            // 
            // lblIsActive
            // 
            lblIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIsActive.ForeColor = Color.FromArgb(44, 62, 80);
            lblIsActive.Location = new Point(0, 0);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(200, 25);
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
            chkIsActive.Location = new Point(10, 35);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(450, 25);
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
            pnlButtons.Location = new Point(40, 395);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(470, 60);
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
            btnSave.Location = new Point(150, 10);
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
            btnCancel.Location = new Point(310, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            btnCancel.MouseEnter += btn_MouseEnter;
            btnCancel.MouseLeave += btn_MouseLeave;
            // 
            // F_Position_Action
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 480);
            Controls.Add(pnlButtons);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "F_Position_Action";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản Lý Chức Danh";
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlFieldIsActive.ResumeLayout(false);
            pnlFieldName.ResumeLayout(false);
            pnlFieldName.PerformLayout();
            pnlFieldCode.ResumeLayout(false);
            pnlFieldCode.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblFormTitle;
        private Panel pnlContent;
        private Panel pnlFieldIsActive;
        private CheckBox chkIsActive;
        private Label lblIsActive;
        private Panel pnlFieldName;
        private TextBox txtName;
        private Label lblName;
        private Panel pnlFieldCode;
        private TextBox txtCode;
        private Label lblCode;
        private Panel pnlButtons;
        private UI.RoundedButton btnCancel;
        private UI.RoundedButton btnSave;
    }
}
