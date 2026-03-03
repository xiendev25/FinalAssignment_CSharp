using Data;
using DTO;
using Service;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;
using ClosedXML.Excel;
using System.IO;

namespace UI
{
    public partial class F_Department : Form
    {
        private readonly DepartmentService service;
        public F_Department()
        {
            InitializeComponent();
            CustomizeDataGridView();
            var db = new MyDBContext();
            service = new DepartmentService(db);
        }

        private void F_Department_Load(object sender, EventArgs e)
        {
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartments.MultiSelect = false;
            dgvDepartments.ReadOnly = true;
            dgvDepartments.AllowUserToAddRows = false;
            dgvDepartments.AllowUserToDeleteRows = false;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = service.GetAll();

                dgvDepartments.DataSource = null;
                dgvDepartments.DataSource = list;

                dgvDepartments.Columns["Id"].HeaderText = "Mã";
                dgvDepartments.Columns["Code"].HeaderText = "Mã phòng ban";
                dgvDepartments.Columns["Name"].HeaderText = "Tên phòng ban";
                dgvDepartments.Columns["IsActive"].HeaderText = "Trạng thái";
                dgvDepartments.Columns["CreatedAt"].HeaderText = "Thời gian tạo";
                dgvDepartments.Columns["UpdatedAt"].HeaderText = "Thời gian cập nhật";

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataSearch(List<DepartmentDTO> list)
        {
            try
            {
                dgvDepartments.DataSource = null;
                dgvDepartments.DataSource = list;

                dgvDepartments.Columns["Id"].HeaderText = "Mã";
                dgvDepartments.Columns["Code"].HeaderText = "Mã phòng ban";
                dgvDepartments.Columns["Name"].HeaderText = "Tên phòng ban";
                dgvDepartments.Columns["IsActive"].HeaderText = "Trạng thái";
                dgvDepartments.Columns["CreatedAt"].HeaderText = "Thời gian tạo";
                dgvDepartments.Columns["UpdatedAt"].HeaderText = "Thời gian cập nhật";

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusBar()
        {
            lblStatus.Text = $"Tổng số: {dgvDepartments.Rows.Count} phòng ban";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm phòng ban...")
            {

                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm phòng ban...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            F_Department_Action editForm = new F_Department_Action(false);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                F_Department_Action editForm = new F_Department_Action(true);

                DataGridViewRow row = dgvDepartments.SelectedRows[0];
                editForm.LoadDepartmentData(
                    Convert.ToInt32(row.Cells["Id"].Value),
                    row.Cells["Code"].Value?.ToString(),
                    row.Cells["Name"].Value?.ToString(),
                    (bool)row.Cells["IsActive"].Value
                );

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDepartments.SelectedRows[0];
                string departmentName = row.Cells["Name"].Value?.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa phòng ban '{departmentName}'?\n\nHành động này không thể hoàn tác!",
                    "⚠️ Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    ServiceResult res = service.Delete(Convert.ToInt32(row.Cells["Id"].Value));
                    if (res.Success)
                    {
                        MessageBox.Show("Đã xóa phòng ban thành công!", "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(res.Message, "Thông báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    FileName = $"DanhSachPhongBan_{DateTime.Now:yyyyMMdd_HHmmss}.json",
                    Title = "Xuất File JSON"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var departments = new List<object>();

                    foreach (DataGridViewRow row in dgvDepartments.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            departments.Add(new
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

                    string jsonString = JsonSerializer.Serialize(departments, options);
                    File.WriteAllText(saveDialog.FileName, jsonString, Encoding.UTF8);

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
                    FileName = $"DanhSachPhongBan_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    Title = "Xuất File Excel"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Danh Sách Phòng Ban");
                        int currentRow = 1;

                        worksheet.Cell(currentRow, 1).Value = "Mã";
                        worksheet.Cell(currentRow, 2).Value = "Mã Phòng Ban";
                        worksheet.Cell(currentRow, 3).Value = "Tên Phòng Ban";
                        worksheet.Cell(currentRow, 4).Value = "Trạng Thái";
                        worksheet.Cell(currentRow, 5).Value = "Ngày Tạo";
                        worksheet.Cell(currentRow, 6).Value = "Ngày cập nhật";

                        worksheet.Row(currentRow).Style.Font.Bold = true;

                        foreach (DataGridViewRow row in dgvDepartments.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                currentRow++;
                                worksheet.Cell(currentRow, 1).Value = row.Cells["Id"].Value?.ToString();
                                worksheet.Cell(currentRow, 2).Value = row.Cells["Code"].Value?.ToString();
                                worksheet.Cell(currentRow, 3).Value = row.Cells["Name"].Value?.ToString();
                                worksheet.Cell(currentRow, 4).Value = row.Cells["IsActive"].Value?.ToString();
                                worksheet.Cell(currentRow, 5).Value = row.Cells["CreatedAt"].Value?.ToString();
                                worksheet.Cell(currentRow, 6).Value = row.Cells["UpdatedAt"].Value?.ToString();


                            }
                        }

                        worksheet.Columns().AdjustToContents();

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

            GraphicsPath path = new GraphicsPath();
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
            dgvDepartments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvDepartments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDepartments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDepartments.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvDepartments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvDepartments.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvDepartments.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvDepartments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvDepartments.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDepartments.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);

            dgvDepartments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
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
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string query = txtSearch.Text;
                if (string.IsNullOrWhiteSpace(query))
                {
                    MessageBox.Show("Vui lòng nhập từ khoá cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadData();
                    return;
                }

                List<DepartmentDTO> departments = service.Search(query);

                if (departments.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phòng ban nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                LoadDataSearch(departments);

                e.SuppressKeyPress = true;
            }
        }
    }
}