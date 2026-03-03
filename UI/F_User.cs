using ClosedXML.Excel;
using Data;
using DTO;
using Service;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;

namespace UI
{
    public partial class F_User : Form
    {
        private readonly UserService userService;

        public F_User()
        {
            InitializeComponent();
            CustomizeDataGridView();

            var db = new MyDBContext();
            userService = new UserService(db);
        }

        private void F_User_Load(object sender, EventArgs e)
        {
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = userService.GetAll();

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = list;

                dgvUsers.Columns["Id"].HeaderText = "Mã";
                dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
                dgvUsers.Columns["Role"].HeaderText = "Quyền";
                dgvUsers.Columns["IsActive"].HeaderText = "Trạng thái";
                dgvUsers.Columns["CreatedAt"].HeaderText = "Tạo lúc";
                dgvUsers.Columns["UpdatedAt"].HeaderText = "Cập nhật lúc";

                dgvUsers.Columns["Password"].Visible = false;

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataSearch(List<UserDTO> list)
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = list;

            dgvUsers.Columns["Id"].HeaderText = "Mã";
            dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgvUsers.Columns["Role"].HeaderText = "Quyền";
            dgvUsers.Columns["IsActive"].HeaderText = "Trạng thái";
            dgvUsers.Columns["CreatedAt"].HeaderText = "Tạo lúc";
            dgvUsers.Columns["UpdatedAt"].HeaderText = "Cập nhật lúc";

            if (dgvUsers.Columns.Contains("Password"))
                dgvUsers.Columns["Password"].Visible = false;

            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            lblStatus.Text = $"Tổng số: {dgvUsers.Rows.Count} người dùng";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm theo username...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm theo username...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            var q = txtSearch.Text?.Trim();
            if (string.IsNullOrWhiteSpace(q))
            {
                MessageBox.Show("Vui lòng nhập từ khoá tìm kiếm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                e.SuppressKeyPress = true;
                return;
            }

            var items = userService.Search(q);
            if (items.Count == 0)
            {
                MessageBox.Show("Không tìm thấy người dùng nào khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.SuppressKeyPress = true;
                return;
            }

            LoadDataSearch(items);
            e.SuppressKeyPress = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new F_User_Action(false);
            if (f.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvUsers.SelectedRows[0];
            var f = new F_User_Action(true);

            f.LoadUserData(
                id: Convert.ToInt32(row.Cells["Id"].Value),
                username: row.Cells["Username"].Value?.ToString(),
                role: row.Cells["Role"].Value?.ToString(),
                isActive: (bool)row.Cells["IsActive"].Value
            );

            if (f.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xoá!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvUsers.SelectedRows[0];
            string username = row.Cells["Username"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Xoá người dùng [{username}]?\n\nHành động này không thể hoàn tác!",
                "⚠️ Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                var res = userService.Delete(id);

                if (res.Success)
                    MessageBox.Show("Đã xoá người dùng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(res.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportJson_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    FileName = $"NguoiDung_{DateTime.Now:yyyyMMdd_HHmmss}.json",
                    Title = "Xuất File JSON"
                };
                if (dlg.ShowDialog() != DialogResult.OK) return;

                var items = new List<object>();
                foreach (DataGridViewRow r in dgvUsers.Rows)
                {
                    if (r.IsNewRow) continue;
                    items.Add(new
                    {
                        Id = r.Cells["Id"].Value?.ToString(),
                        Username = r.Cells["Username"].Value?.ToString(),
                        Role = r.Cells["Role"].Value?.ToString(),
                        IsActive = r.Cells["IsActive"].Value?.ToString(),
                        CreatedAt = r.Cells["CreatedAt"].FormattedValue?.ToString(),
                        UpdatedAt = r.Cells["UpdatedAt"].FormattedValue?.ToString()
                    });
                }

                var opt = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                File.WriteAllText(dlg.FileName, JsonSerializer.Serialize(items, opt), Encoding.UTF8);

                MessageBox.Show($"✅ Xuất file JSON thành công!\n\nĐường dẫn: {dlg.FileName}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi xuất file JSON:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = $"NguoiDung_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    Title = "Xuất File Excel"
                };
                if (dlg.ShowDialog() != DialogResult.OK) return;

                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Người Dùng");
                    int r = 1;

                    ws.Cell(r, 1).Value = "Mã";
                    ws.Cell(r, 2).Value = "Tên đăng nhập";
                    ws.Cell(r, 3).Value = "Quyền";
                    ws.Cell(r, 4).Value = "Trạng thái";
                    ws.Cell(r, 5).Value = "Tạo lúc";
                    ws.Cell(r, 6).Value = "Cập nhật lúc";
                    ws.Row(r).Style.Font.Bold = true;

                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        if (row.IsNewRow) continue;
                        r++;
                        ws.Cell(r, 1).Value = row.Cells["Id"].Value?.ToString();
                        ws.Cell(r, 2).Value = row.Cells["Username"].Value?.ToString();
                        ws.Cell(r, 3).Value = row.Cells["Role"].Value?.ToString();
                        ws.Cell(r, 4).Value = (bool)row.Cells["IsActive"].Value ? "Đang hoạt động" : "Ngừng hoạt động";
                        ws.Cell(r, 5).Value = row.Cells["CreatedAt"].FormattedValue?.ToString();
                        ws.Cell(r, 6).Value = row.Cells["UpdatedAt"].FormattedValue?.ToString();
                    }

                    ws.Columns().AdjustToContents();
                    wb.SaveAs(dlg.FileName);
                }

                MessageBox.Show("Xuất file Excel thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            e.Graphics.DrawLine(new Pen(Color.FromArgb(230, 230, 230), 1),
                0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            Rectangle rect = pnl.ClientRectangle;
            rect.Inflate(-2, -2);

            using var path = new GraphicsPath();
            int radius = 12;
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(new Pen(Color.FromArgb(220, 220, 220), 1), path);
        }

        private void pnlSearchBox_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            using var path = new GraphicsPath();
            int radius = 20;
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            e.Graphics.DrawLine(new Pen(Color.FromArgb(230, 230, 230), 1),
                0, 0, pnl.Width, 0);
        }

        private void CustomizeDataGridView()
        {
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvUsers.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsers.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);

            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;

            if (btn.BackColor == Color.FromArgb(46, 204, 113))
                btn.BackColor = Color.FromArgb(39, 174, 96);
            else if (btn.BackColor == Color.FromArgb(52, 152, 219))
                btn.BackColor = Color.FromArgb(41, 128, 185);
            else if (btn.BackColor == Color.FromArgb(231, 76, 60))
                btn.BackColor = Color.FromArgb(192, 57, 43);
            else if (btn.BackColor == Color.FromArgb(149, 165, 166))
                btn.BackColor = Color.FromArgb(127, 140, 141);
            else if (btn.BackColor == Color.FromArgb(155, 89, 182))
                btn.BackColor = Color.FromArgb(142, 68, 173);
            else if (btn.BackColor == Color.FromArgb(26, 188, 156))
                btn.BackColor = Color.FromArgb(22, 160, 133);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == btnAdd)
                btn.BackColor = Color.FromArgb(46, 204, 113);
            else if (btn == btnEdit)
                btn.BackColor = Color.FromArgb(52, 152, 219);
            else if (btn == btnDelete)
                btn.BackColor = Color.FromArgb(231, 76, 60);
            else if (btn == btnRefresh)
                btn.BackColor = Color.FromArgb(149, 165, 166);
            else if (btn == btnExportJson)
                btn.BackColor = Color.FromArgb(155, 89, 182);
            else if (btn == btnExportExcel)
                btn.BackColor = Color.FromArgb(26, 188, 156);
        }
    }
}
