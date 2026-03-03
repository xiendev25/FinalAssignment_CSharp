using Data;
using DTO;
using Service;
using System.Text;
using System.Text.Json;
using ClosedXML.Excel;
using System.IO;
using System.Drawing.Drawing2D;

namespace UI
{
    public partial class F_Position : Form
    {
        private readonly PositionService service;

        public F_Position()
        {
            InitializeComponent();
            CustomizeDataGridView();

            var db = new MyDBContext();
            service = new PositionService(db);
        }

        private void F_Position_Load(object sender, EventArgs e)
        {
            dgvPositions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPositions.MultiSelect = false;
            dgvPositions.ReadOnly = true;
            dgvPositions.AllowUserToAddRows = false;
            dgvPositions.AllowUserToDeleteRows = false;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = service.GetAll();

                dgvPositions.DataSource = null;
                dgvPositions.DataSource = list;

                dgvPositions.Columns["Id"].HeaderText = "Mã";
                dgvPositions.Columns["Code"].HeaderText = "Mã chức danh";
                dgvPositions.Columns["Name"].HeaderText = "Tên chức danh";
                dgvPositions.Columns["IsActive"].HeaderText = "Trạng thái";
                dgvPositions.Columns["CreatedAt"].HeaderText = "Thời gian tạo";
                dgvPositions.Columns["UpdatedAt"].HeaderText = "Thời gian cập nhật";

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataSearch(List<PositionDTO> list)
        {
            try
            {
                dgvPositions.DataSource = null;
                dgvPositions.DataSource = list;

                dgvPositions.Columns["Id"].HeaderText = "Mã";
                dgvPositions.Columns["Code"].HeaderText = "Mã chức danh";
                dgvPositions.Columns["Name"].HeaderText = "Tên chức danh";
                dgvPositions.Columns["IsActive"].HeaderText = "Trạng thái";
                dgvPositions.Columns["CreatedAt"].HeaderText = "Thời gian tạo";
                dgvPositions.Columns["UpdatedAt"].HeaderText = "Thời gian cập nhật";

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusBar()
        {
            lblStatus.Text = $"Tổng số: {dgvPositions.Rows.Count} chức danh";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm chức danh...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm chức danh...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new F_Position_Action(isEdit: false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chức danh cần chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvPositions.SelectedRows[0];
            var form = new F_Position_Action(isEdit: true);

            form.LoadPositionData(
                Convert.ToInt32(row.Cells["Id"].Value),
                row.Cells["Code"].Value?.ToString(),
                row.Cells["Name"].Value?.ToString(),
                (bool)row.Cells["IsActive"].Value
            );

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chức danh cần xoá!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvPositions.SelectedRows[0];
            string positionName = row.Cells["Name"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xoá chức danh '{positionName}'?\n\nHành động này không thể hoàn tác!",
                "⚠️ Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                var res = service.Delete(Convert.ToInt32(row.Cells["Id"].Value));
                if (res.Success)
                {
                    MessageBox.Show("Đã xoá chức danh thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(res.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    FileName = $"DanhSachChucDanh_{DateTime.Now:yyyyMMdd_HHmmss}.json",
                    Title = "Xuất File JSON"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var items = new List<object>();

                    foreach (DataGridViewRow row in dgvPositions.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            items.Add(new
                            {
                                Id = row.Cells["Id"].Value?.ToString(),
                                Code = row.Cells["Code"].Value?.ToString(),
                                Name = row.Cells["Name"].Value?.ToString(),
                                IsActive = row.Cells["IsActive"].Value?.ToString(),
                                CreatedAt = row.Cells["CreatedAt"].Value?.ToString(),
                                UpdatedAt = row.Cells["UpdatedAt"].Value?.ToString()
                            });
                        }
                    }

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };

                    string json = JsonSerializer.Serialize(items, options);
                    File.WriteAllText(saveDialog.FileName, json, Encoding.UTF8);

                    MessageBox.Show($"✅ Xuất file JSON thành công!\n\nĐường dẫn: {saveDialog.FileName}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    FileName = $"DanhSachChucDanh_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    Title = "Xuất File Excel"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("Danh Sách Chức Danh");
                        int r = 1;

                        // Header
                        ws.Cell(r, 1).Value = "Mã";
                        ws.Cell(r, 2).Value = "Mã Chức Danh";
                        ws.Cell(r, 3).Value = "Tên Chức Danh";
                        ws.Cell(r, 4).Value = "Trạng Thái";
                        ws.Cell(r, 5).Value = "Ngày Tạo";
                        ws.Cell(r, 6).Value = "Ngày Cập Nhật";
                        ws.Row(r).Style.Font.Bold = true;

                        foreach (DataGridViewRow row in dgvPositions.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                r++;
                                ws.Cell(r, 1).Value = row.Cells["Id"].Value?.ToString();
                                ws.Cell(r, 2).Value = row.Cells["Code"].Value?.ToString();
                                ws.Cell(r, 3).Value = row.Cells["Name"].Value?.ToString();
                                ws.Cell(r, 4).Value = row.Cells["IsActive"].Value?.ToString();
                                ws.Cell(r, 5).Value = row.Cells["CreatedAt"].Value?.ToString();
                                ws.Cell(r, 6).Value = row.Cells["UpdatedAt"].Value?.ToString();
                            }
                        }

                        ws.Columns().AdjustToContents();
                        workbook.SaveAs(saveDialog.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            GraphicsPath path = new GraphicsPath();
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
            dgvPositions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvPositions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPositions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPositions.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvPositions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvPositions.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvPositions.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvPositions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvPositions.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPositions.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);

            dgvPositions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string query = txtSearch.Text;
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Vui lòng nhập từ khoá cần tìm kiếm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                e.SuppressKeyPress = true;
                return;
            }

            var items = service.Search(query);

            if (items.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chức danh nào khớp với từ khóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.SuppressKeyPress = true;
                return;
            }

            LoadDataSearch(items);
            e.SuppressKeyPress = true;
        }
    }
}
