using Data;
using Service;
using DTO;
using System.Drawing.Drawing2D;

namespace UI
{
    public partial class F_Department_Action : Form
    {
        private readonly DepartmentService service;
        private bool isEditMode;

        private int Id;

        public F_Department_Action(bool isEdit)
        {
            this.isEditMode = isEdit;
            InitializeComponent();
            var db = new MyDBContext();
            service = new DepartmentService(db);
            SetupForm();
            AddTextBoxBorders();
        }

        private void SetupForm()
        {
            if (isEditMode)
            {
                lblFormTitle.Text = "✏️ CẬP NHẬT PHÒNG BAN";
                btnSave.Text = "💾 Cập Nhật";
            }
            else
            {
                lblFormTitle.Text = "➕ THÊM PHÒNG BAN MỚI";
                btnSave.Text = "💾 Lưu";
            }
        }

        public void LoadDepartmentData(int id, string code, string name, bool isActive)
        {
            this.Id = id;
            txtCode.Text = code;
            txtName.Text = name;
            chkIsActive.Checked = isActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập mã phòng ban!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập tên phòng ban!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            ServiceResult res;

            if (!isEditMode)
            {
                res = service.Add(new DepartmentDTO
                {
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    IsActive = chkIsActive.Checked ? true : false,
                });
            }
            else
            {
                res = service.Update(new DepartmentDTO
                {
                    Id = this.Id,
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    IsActive = chkIsActive.Checked ? true : false,
                });
            }
            if (res.Success)
            {
                MessageBox.Show(
                isEditMode ? "Cập nhật phòng ban thành công!" : "Thêm phòng ban mới thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(res.Message
                ,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddTextBoxBorders()
        {
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is Panel pnl)
                {
                    foreach (Control innerCtrl in pnl.Controls)
                    {
                        if (innerCtrl is TextBox txt)
                        {
                            pnl.Paint += (s, e) =>
                            {
                                GraphicsPath path = new GraphicsPath();
                                int radius = 8;
                                Rectangle rect = new Rectangle(txt.Location.X - 5, txt.Location.Y - 8,
                                    txt.Width + 10, txt.Height + 16);

                                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                                path.CloseFigure();

                                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                e.Graphics.FillPath(new SolidBrush(txt.BackColor), path);
                                e.Graphics.DrawPath(new Pen(Color.FromArgb(220, 220, 220), 1), path);
                            };
                        }
                    }
                }
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (!txt.ReadOnly)
            {
                txt.BackColor = Color.FromArgb(255, 255, 255);
                txt.Parent.Invalidate();
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (!txt.ReadOnly)
            {
                txt.BackColor = Color.FromArgb(248, 249, 250);
                txt.Parent.Invalidate();
            }
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked)
            {
                chkIsActive.Text = "✓ Đang hoạt động";
                chkIsActive.ForeColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                chkIsActive.Text = "✗ Ngừng hoạt động";
                chkIsActive.ForeColor = Color.FromArgb(231, 76, 60);
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.FromArgb(46, 204, 113))
                btn.BackColor = Color.FromArgb(39, 174, 96);
            else if (btn.BackColor == Color.FromArgb(149, 165, 166))
                btn.BackColor = Color.FromArgb(127, 140, 141);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnSave)
                btn.BackColor = Color.FromArgb(46, 204, 113);
            else if (btn == btnCancel)
                btn.BackColor = Color.FromArgb(149, 165, 166);
        }
    }
}