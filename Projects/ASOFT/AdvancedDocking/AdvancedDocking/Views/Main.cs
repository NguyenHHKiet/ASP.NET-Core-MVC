using AdvancedDocking.Models;
using AdvancedDocking.Views;
using System;
using System.Windows.Forms;

namespace AdvancedDocking
{
    public partial class Main : Form
    {
        private readonly BusinessLogicLayer _businessLogicLayer = null;
        private EmployeeDetail _employeeDetail = null;
        private string userId = null;

        public Main()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        #region EVENTS
        private void Main_Load(object sender, EventArgs e)
        {
            PopulateEmployees();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            OpenDetailsDialog();
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            //Show form với đối tượng được chỉ định
            _employeeDetail.ShowDialog(this);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            _businessLogicLayer.DeleteEmployee(userId);
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PopulateEmployees();
        }
        private void employeeFlexGrid_Click(object sender, EventArgs e)
        {
            _employeeDetail = new EmployeeDetail();
            // Lấy dòng hiện tại được chọn
            int currentRow = employeeFlexGrid.Row;
            if (currentRow > 0) // Đảm bảo không chọn tiêu đề
            {
                // Lấy dữ liệu từ dòng hiện tại
                userId = employeeFlexGrid[currentRow, 1].ToString(); // Ví dụ: lấy giá trị từ cột 1

                // Hiển thị dữ liệu ra MessageBox hoặc xử lý theo nhu cầu
                _employeeDetail.LoadEmployee(new Employee
                {
                    UserID = userId,
                    UserName = employeeFlexGrid[currentRow, 2].ToString(),
                    Password = employeeFlexGrid[currentRow, 3].ToString(),
                    Email = employeeFlexGrid[currentRow, 4].ToString(),
                    Tel = employeeFlexGrid[currentRow, 5].ToString(),
                    Disable = (byte)employeeFlexGrid[currentRow, 6],
                });
            }
        }
        #endregion
        #region PRIVATE METHODS
        private void OpenDetailsDialog()
        {
            EmployeeDetail details = new EmployeeDetail();
            details.ShowDialog(this);
        }
        #endregion
        #region PUBLIC METHODS
        public void PopulateEmployees()
        {
            // TODO: This line of code loads data into the 'basicTestDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.basicTestDataSet.Employee);
        }
        #endregion

    }
}
