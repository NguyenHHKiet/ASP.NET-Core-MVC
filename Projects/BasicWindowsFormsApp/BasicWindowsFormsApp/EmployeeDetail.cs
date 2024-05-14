using System;
using System.Windows.Forms;

namespace BasicWindowsFormsApp
{
    public partial class EmployeeDetail : Form
    {
        private readonly BusinessLogicLayer _businessLogicLayer = null;
        private Employee _employee = null;
        bool result = false;
        public EmployeeDetail()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
            btnNext.Enabled = false;
        }

        #region EVENTS
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (result)
            {
                ((Main)this.Owner).PopulateEmployees();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            result = SaveContact();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        #endregion

        #region PRIVATE METHODS
        private bool SaveContact()
        {
            string userId = txtUserId.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text;
            string tel = txtTel.Text;
            bool checkSuccess = true;

            // Kiểm tra xem các trường đã nhập đầy đủ chưa
            if (string.IsNullOrWhiteSpace(userId) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(tel))
            {
                checkSuccess = false;
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào tất cả các trường.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Kiểm tra xem email có hợp lệ không
            if (!Employee.IsValidEmail(email))
            {
                checkSuccess = false;
                MessageBox.Show("Vui lòng nhập một địa chỉ email hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Kiểm tra mật khẩu
            if (password != confirmPassword)
            {
                checkSuccess = false;
                MessageBox.Show("Mật khẩu không khớp. Vui lòng nhập lại mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (checkSuccess)
            {
                Employee employee = new Employee
                {
                    UserID = _employee != null ? _employee.UserID : txtUserId.Text,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    Tel = txtTel.Text,
                    Disable = (byte)(ckbDisable.Checked ? 1 : 0),
                };

                _businessLogicLayer.SaveEmployee(employee);
                btnNext.Enabled = txtUserId.Enabled;

                // Nếu không có lỗi, tiến hành đăng ký hoặc xử lý dữ liệu
                // Đăng ký tài khoản, lưu vào cơ sở dữ liệu, v.v.
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return checkSuccess;
            }

            return checkSuccess;
        }
        private void ClearForm()
        {
            txtUserId.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTel.Text = string.Empty;
            ckbDisable.Checked = false;
        }
        #endregion

        #region PUBLIC METHODS
        public void LoadEmployee(Employee employee)
        {
            _employee = employee;
            if (employee != null)
            {
                ClearForm();

                txtUserId.Enabled = false;
                txtUserId.Text = employee.UserID;
                txtUsername.Text = employee.UserName;
                txtPassword.Text = employee.Password;
                txtEmail.Text = employee.Email;
                txtTel.Text = employee.Tel;
                ckbDisable.Checked = employee.Disable == 1;
            }
        }
        #endregion
    }
}
