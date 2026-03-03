using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    partial class F_ChangePassword
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblFormTitle;
        private Panel pnlContent;
        private Panel pnlFieldCurrent;
        private Label lblCurrent;
        private TextBox txtCurrent;
        private Panel pnlFieldNew;
        private Label lblNew;
        private TextBox txtNew;
        private Panel pnlFieldConfirm;
        private Label lblConfirm;
        private TextBox txtConfirm;
        private CheckBox chkShowPassword;
        private Panel pnlButtons;
        private UI.RoundedButton btnSave;
        private UI.RoundedButton btnCancel;

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
            pnlFieldCurrent = new Panel();
            txtCurrent = new TextBox();
            lblCurrent = new Label();
            pnlFieldNew = new Panel();
            txtNew = new TextBox();
            lblNew = new Label();
            pnlFieldConfirm = new Panel();
            txtConfirm = new TextBox();
            lblConfirm = new Label();
            chkShowPassword = new CheckBox();
            pnlButtons = new Panel();
            btnCancel = new RoundedButton();
            btnSave = new RoundedButton();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlFieldCurrent.SuspendLayout();
            pnlFieldNew.SuspendLayout();
            pnlFieldConfirm.SuspendLayout();
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
            lblFormTitle.Text = "🔒 ĐỔI MẬT KHẨU";
            lblFormTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(pnlFieldCurrent);
            pnlContent.Controls.Add(pnlFieldNew);
            pnlContent.Controls.Add(pnlFieldConfirm);
            pnlContent.Controls.Add(chkShowPassword);
            pnlContent.Location = new Point(40, 100);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(470, 302);
            pnlContent.TabIndex = 1;
            // 
            // pnlFieldCurrent
            // 
            pnlFieldCurrent.Controls.Add(txtCurrent);
            pnlFieldCurrent.Controls.Add(lblCurrent);
            pnlFieldCurrent.Location = new Point(0, 10);
            pnlFieldCurrent.Name = "pnlFieldCurrent";
            pnlFieldCurrent.Size = new Size(470, 70);
            pnlFieldCurrent.TabIndex = 0;
            // 
            // txtCurrent
            // 
            txtCurrent.BackColor = Color.FromArgb(248, 249, 250);
            txtCurrent.BorderStyle = BorderStyle.None;
            txtCurrent.Font = new Font("Segoe UI", 11F);
            txtCurrent.Location = new Point(10, 35);
            txtCurrent.Name = "txtCurrent";
            txtCurrent.Size = new Size(450, 20);
            txtCurrent.TabIndex = 1;
            txtCurrent.UseSystemPasswordChar = true;
            txtCurrent.Enter += txt_Enter;
            txtCurrent.Leave += txt_Leave;
            // 
            // lblCurrent
            // 
            lblCurrent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCurrent.ForeColor = Color.FromArgb(44, 62, 80);
            lblCurrent.Location = new Point(0, 0);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(200, 25);
            lblCurrent.TabIndex = 0;
            lblCurrent.Text = "Mật khẩu hiện tại *";
            // 
            // pnlFieldNew
            // 
            pnlFieldNew.Controls.Add(txtNew);
            pnlFieldNew.Controls.Add(lblNew);
            pnlFieldNew.Location = new Point(0, 90);
            pnlFieldNew.Name = "pnlFieldNew";
            pnlFieldNew.Size = new Size(470, 70);
            pnlFieldNew.TabIndex = 1;
            // 
            // txtNew
            // 
            txtNew.BackColor = Color.FromArgb(248, 249, 250);
            txtNew.BorderStyle = BorderStyle.None;
            txtNew.Font = new Font("Segoe UI", 11F);
            txtNew.Location = new Point(10, 35);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(450, 20);
            txtNew.TabIndex = 1;
            txtNew.UseSystemPasswordChar = true;
            txtNew.Enter += txt_Enter;
            txtNew.Leave += txt_Leave;
            // 
            // lblNew
            // 
            lblNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNew.ForeColor = Color.FromArgb(44, 62, 80);
            lblNew.Location = new Point(0, 0);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(250, 25);
            lblNew.TabIndex = 0;
            lblNew.Text = "Mật khẩu mới *";
            // 
            // pnlFieldConfirm
            // 
            pnlFieldConfirm.Controls.Add(txtConfirm);
            pnlFieldConfirm.Controls.Add(lblConfirm);
            pnlFieldConfirm.Location = new Point(0, 170);
            pnlFieldConfirm.Name = "pnlFieldConfirm";
            pnlFieldConfirm.Size = new Size(470, 70);
            pnlFieldConfirm.TabIndex = 2;
            // 
            // txtConfirm
            // 
            txtConfirm.BackColor = Color.FromArgb(248, 249, 250);
            txtConfirm.BorderStyle = BorderStyle.None;
            txtConfirm.Font = new Font("Segoe UI", 11F);
            txtConfirm.Location = new Point(10, 35);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(450, 20);
            txtConfirm.TabIndex = 1;
            txtConfirm.UseSystemPasswordChar = true;
            txtConfirm.Enter += txt_Enter;
            txtConfirm.Leave += txt_Leave;
            // 
            // lblConfirm
            // 
            lblConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirm.ForeColor = Color.FromArgb(44, 62, 80);
            lblConfirm.Location = new Point(0, 0);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(250, 25);
            lblConfirm.TabIndex = 0;
            lblConfirm.Text = "Xác nhận mật khẩu mới *";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(44, 62, 80);
            chkShowPassword.Location = new Point(3, 246);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(119, 19);
            chkShowPassword.TabIndex = 3;
            chkShowPassword.Text = "👁 Hiện mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.White;
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Location = new Point(40, 422);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(470, 60);
            pnlButtons.TabIndex = 2;
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
            // F_ChangePassword
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(550, 494);
            Controls.Add(pnlButtons);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "F_ChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlFieldCurrent.ResumeLayout(false);
            pnlFieldCurrent.PerformLayout();
            pnlFieldNew.ResumeLayout(false);
            pnlFieldNew.PerformLayout();
            pnlFieldConfirm.ResumeLayout(false);
            pnlFieldConfirm.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
    }
}
