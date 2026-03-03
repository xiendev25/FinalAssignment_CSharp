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
    public partial class F_Employee : Form
    {
        private readonly EmployeeService employeeService;

        public F_Employee()
        {
            InitializeComponent();
            CustomizeDataGridView();

            var db = new MyDBContext();
            employeeService = new EmployeeService(db);
        }

        private void F_Employee_Load(object sender, EventArgs e)
        {
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.MultiSelect = false;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = employeeService.GetAll();

                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = list;

                dgvEmployees.Columns["Id"].HeaderText = "Mã";
                dgvEmployees.Columns["Code"].HeaderText = "Mã Nhân Sự";
                dgvEmployees.Columns["Name"].HeaderText = "Tên Nhân Sự";
                dgvEmployees.Columns["GenderName"].HeaderText = "Giới Tính";
                dgvEmployees.Columns["DOB"].HeaderText = "Ngày Sinh";
                dgvEmployees.Columns["DepartmentName"].HeaderText = "Phòng Ban";
                dgvEmployees.Columns["PositionName"].HeaderText = "Chức Danh";
                dgvEmployees.Columns["IsActive"].HeaderText = "Trạng Thái";
                dgvEmployees.Columns["CreatedAt"].HeaderText = "Tạo Lúc";
                dgvEmployees.Columns["UpdatedAt"].HeaderText = "Cập Nhật Lúc";

                dgvEmployees.Columns["Gender"].Visible = false;
                dgvEmployees.Columns["DepartmentId"].Visible = false;
                dgvEmployees.Columns["PositionId"].Visible = false;

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataSearch(List<EmployeeDTO> list)
        {
            try
            {
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = list;

                dgvEmployees.Columns["Id"].HeaderText = "Mã";
                dgvEmployees.Columns["Code"].HeaderText = "Mã Nhân Sự";
                dgvEmployees.Columns["Name"].HeaderText = "Tên Nhân Sự";
                dgvEmployees.Columns["GenderName"].HeaderText = "Giới Tính";
                dgvEmployees.Columns["DOB"].HeaderText = "Ngày Sinh";
                dgvEmployees.Columns["DepartmentName"].HeaderText = "Phòng Ban";
                dgvEmployees.Columns["PositionName"].HeaderText = "Chức Danh";
                dgvEmployees.Columns["IsActive"].HeaderText = "Trạng Thái";
                dgvEmployees.Columns["CreatedAt"].HeaderText = "Tạo Lúc";
                dgvEmployees.Columns["UpdatedAt"].HeaderText = "Cập Nhật Lúc";

                dgvEmployees.Columns["Gender"].Visible = false;
                dgvEmployees.Columns["DepartmentId"].Visible = false;
                dgvEmployees.Columns["PositionId"].Visible = false;

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
            lblStatus.Text = $"Tổng số: {dgvEmployees.Rows.Count} nhân sự";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm theo mã hoặc tên...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm theo mã hoặc tên...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string query = txtSearch.Text;
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Vui lòng nhập từ khoá cần tìm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                e.SuppressKeyPress = true;
                return;
            }

            var items = employeeService.Search(query);
            if (items.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân sự nào khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.SuppressKeyPress = true;
                return;
            }

            LoadDataSearch(items);
            e.SuppressKeyPress = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new F_Employee_Action(false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân sự cần chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvEmployees.SelectedRows[0];
            var form = new F_Employee_Action(true);

            form.LoadEmployeeData(
                id: Convert.ToInt32(row.Cells["Id"].Value),
                code: row.Cells["Code"].Value?.ToString(),
                name: row.Cells["Name"].Value?.ToString(),
                gender: row.Cells["Gender"].Value?.ToString(),
                dob: (row.Cells["DOB"].Value is DateOnly d ? d : DateOnly.FromDateTime(DateTime.Now)),
                isActive: (bool)row.Cells["IsActive"].Value,
                departmentId: Convert.ToInt32(row.Cells["DepartmentId"].Value),
                positionId: Convert.ToInt32(row.Cells["PositionId"].Value)
            );

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân sự cần xoá!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvEmployees.SelectedRows[0];
            string code = row.Cells["Code"].Value?.ToString();
            string name = row.Cells["Name"].Value?.ToString();

            var confirm = MessageBox.Show(
                $"Xoá nhân sự [{code}] - [{name}]?\n\nHành động này không thể hoàn tác!",
                "⚠️ Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                var res = employeeService.Delete(id);
                if (res.Success)
                {
                    MessageBox.Show("Đã xoá nhân sự!", "Thông báo",
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
                var dlg = new SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    FileName = $"NhanSu_{DateTime.Now:yyyyMMdd_HHmmss}.json",
                    Title = "Xuất File JSON"
                };
                if (dlg.ShowDialog() != DialogResult.OK) return;

                var items = new List<object>();
                foreach (DataGridViewRow row in dgvEmployees.Rows)
                {
                    if (row.IsNewRow) continue;
                    items.Add(new
                    {
                        Id = row.Cells["Id"].Value?.ToString(),
                        Code = row.Cells["Code"].Value?.ToString(),
                        Name = row.Cells["Name"].Value?.ToString(),
                        Gender = row.Cells["Gender"].Value?.ToString(),
                        DOB = row.Cells["DOB"].FormattedValue?.ToString(),
                        Department = row.Cells["DepartmentName"].Value?.ToString(),
                        Position = row.Cells["PositionName"].Value?.ToString(),
                        IsActive = row.Cells["IsActive"].Value?.ToString(),
                        CreatedAt = row.Cells["CreatedAt"].FormattedValue?.ToString(),
                        UpdatedAt = row.Cells["UpdatedAt"].FormattedValue?.ToString()
                    });
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string json = JsonSerializer.Serialize(items, options);
                File.WriteAllText(dlg.FileName, json, Encoding.UTF8);

                MessageBox.Show($"Xuất file JSON thành công!\n\nĐường dẫn: {dlg.FileName}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file JSON:\n{ex.Message}",
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
                    FileName = $"NhanSu_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    Title = "Xuất File Excel"
                };
                if (dlg.ShowDialog() != DialogResult.OK) return;

                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Nhân Sự");
                    int r = 1;

                    ws.Cell(r, 1).Value = "Mã";
                    ws.Cell(r, 2).Value = "Mã Nhân Sự";
                    ws.Cell(r, 3).Value = "Tên Nhân Sự";
                    ws.Cell(r, 4).Value = "Giới Tính";
                    ws.Cell(r, 5).Value = "Ngày Sinh";
                    ws.Cell(r, 6).Value = "Phòng Ban";
                    ws.Cell(r, 7).Value = "Chức Danh";
                    ws.Cell(r, 8).Value = "Trạng Thái";
                    ws.Cell(r, 9).Value = "Tạo Lúc";
                    ws.Cell(r, 10).Value = "Cập Nhật Lúc";
                    ws.Row(r).Style.Font.Bold = true;

                    foreach (DataGridViewRow row in dgvEmployees.Rows)
                    {
                        if (row.IsNewRow) continue;
                        r++;
                        ws.Cell(r, 1).Value = row.Cells["Id"].Value?.ToString();
                        ws.Cell(r, 2).Value = row.Cells["Code"].Value?.ToString();
                        ws.Cell(r, 3).Value = row.Cells["Name"].Value?.ToString();
                        ws.Cell(r, 4).Value = row.Cells["GenderName"].Value?.ToString();
                        ws.Cell(r, 5).Value = row.Cells["DOB"].FormattedValue?.ToString();
                        ws.Cell(r, 6).Value = row.Cells["DepartmentName"].Value?.ToString();
                        ws.Cell(r, 7).Value = row.Cells["PositionName"].Value?.ToString();
                        ws.Cell(r, 8).Value = (bool)row.Cells["IsActive"].Value == true ? "Đang hoạt động" : "Ngừng hoạt động";
                        ws.Cell(r, 9).Value = row.Cells["CreatedAt"].FormattedValue?.ToString();
                        ws.Cell(r, 10).Value = row.Cells["UpdatedAt"].FormattedValue?.ToString();
                    }

                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(dlg.FileName);
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
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvEmployees.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvEmployees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvEmployees.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvEmployees.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvEmployees.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);

            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
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
