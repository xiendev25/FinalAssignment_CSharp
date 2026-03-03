using Data;
using DTO;
using Service;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace UI
{
    public partial class F_Employee_Action : Form
    {
        private readonly EmployeeService employeeService;
        private readonly DepartmentService departmentService;
        private readonly PositionService positionService;

        private readonly bool isEditMode;
        private int _id;

        public F_Employee_Action(bool isEdit)
        {
            isEditMode = isEdit;
            InitializeComponent();

            var db = new MyDBContext();
            employeeService = new EmployeeService(db);
            departmentService = new DepartmentService(db);
            positionService = new PositionService(db);

            SetupForm();
            LoadCombos();
        }

        private void SetupForm()
        {
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.CustomFormat = "dd/MM/yyyy";

            cboGender.Items.Clear();
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;

            if (isEditMode)
            {
                lblFormTitle.Text = "✏️ CẬP NHẬT NHÂN SỰ";
                btnSave.Text = "💾 Cập Nhật";
            }
            else
            {
                lblFormTitle.Text = "➕ THÊM NHÂN SỰ MỚI";
                btnSave.Text = "💾 Lưu";
            }
        }

        private void LoadCombos()
        {
            var depts = departmentService.GetAll();
            cboDepartment.DisplayMember = "Name";
            cboDepartment.ValueMember = "Id";
            cboDepartment.DataSource = depts;

            var positions = positionService.GetAll();
            cboPosition.DisplayMember = "Name";
            cboPosition.ValueMember = "Id";
            cboPosition.DataSource = positions;
        }

        public void LoadEmployeeData(int id, string code, string name, string gender, DateOnly dob,
                                     bool isActive, int departmentId, int positionId)
        {
            _id = id;
            txtCode.Text = code;
            txtName.Text = name;

            int idx = cboGender.Items.IndexOf(gender ?? "Nam");
            cboGender.SelectedIndex = idx >= 0 ? idx : 0;

            dtpDOB.Value = dob.ToDateTime(TimeOnly.MinValue);

            chkIsActive.Checked = isActive;

            cboDepartment.SelectedValue = departmentId;
            cboPosition.SelectedValue = positionId;
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập Mã nhân sự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập Tên nhân sự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (cboDepartment.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Vui lòng chọn Phòng ban!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboPosition.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Vui lòng chọn Chức danh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new EmployeeDTO
            {
                Id = _id,
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Gender = cboGender.SelectedIndex,
                DOB = DateOnly.FromDateTime(dtpDOB.Value),
                IsActive = chkIsActive.Checked,
                DepartmentId = Convert.ToInt32(cboDepartment.SelectedValue),
                PositionId = Convert.ToInt32(cboPosition.SelectedValue)
            };

            ServiceResult res = isEditMode ? employeeService.Update(dto) : employeeService.Add(dto);

            if (res.Success)
            {
                MessageBox.Show(isEditMode ? "Cập nhật nhân sự thành công!" : "Thêm nhân sự thành công!",
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

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
