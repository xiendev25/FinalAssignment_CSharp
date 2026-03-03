using Data;
using DTO;
using Service;
using System.Drawing.Drawing2D;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace UI
{
    public partial class F_Position_Action : Form
    {
        private readonly PositionService service;
        private readonly bool isEditMode;
        private int Id;

        public F_Position_Action(bool isEdit)
        {
            isEditMode = isEdit;
            InitializeComponent();

            var db = new MyDBContext();
            service = new PositionService(db);

            SetupForm();
            AddTextBoxBorders();
        }

        private void SetupForm()
        {
            if (isEditMode)
            {
                lblFormTitle.Text = "✏️ CẬP NHẬT CHỨC DANH";
                btnSave.Text = "💾 Cập Nhật";
            }
            else
            {
                lblFormTitle.Text = "➕ THÊM CHỨC DANH MỚI";
                btnSave.Text = "💾 Lưu";
            }
        }

        public void LoadPositionData(int id, string code, string name, bool isActive)
        {
            Id = id;
            txtCode.Text = code;
            txtName.Text = name;
            chkIsActive.Checked = isActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập mã chức danh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập tên chức danh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            ServiceResult res;
            var dto = new PositionDTO
            {
                Id = Id,
                Code = txtCode.Text,
                Name = txtName.Text,
                IsActive = chkIsActive.Checked
            };

            if (isEditMode)
                res = service.Update(dto);
            else
                res = service.Add(dto);

            if (res.Success)
            {
                MessageBox.Show(isEditMode
                        ? "Cập nhật chức danh thành công!"
                        : "Thêm chức danh mới thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(res.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    foreach (Control inner in pnl.Controls)
                    {
                        if (inner is TextBox txt)
                        {
                            pnl.Paint += (s, e) =>
                            {
                                using var path = new GraphicsPath();
                                int radius = 8;
                                Rectangle rect = new Rectangle(txt.Left - 5, txt.Top - 8,
                                    txt.Width + 10, txt.Height + 16);

                                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                                path.CloseFigure();

                                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                using var bg = new SolidBrush(txt.BackColor);
                                using var pen = new Pen(Color.FromArgb(220, 220, 220), 1);
                                e.Graphics.FillPath(bg, path);
                                e.Graphics.DrawPath(pen, path);
                            };
                        }
                    }
                }
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (!txt.ReadOnly)
            {
                txt.BackColor = Color.FromArgb(255, 255, 255);
                txt.Parent.Invalidate();
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
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
