using System.Data.Entity.Core.Objects;
using System.Windows.Forms;

namespace BasicWindowsFormsApp
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
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void gridEmployees_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Gọi hàm đếm thứ tự khi một hàng mới được thêm vào DataGridView
            UpdateRowNumbers();
        }

        private void gridEmployees_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Gọi hàm đếm thứ tự khi một hàng được xóa khỏi DataGridView
            UpdateRowNumbers();
        }

        private void NewMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenContactDetailsDialog();
        }
        private void EditMenuItem_Click(object sender, System.EventArgs e)
        {
            //Show form với đối tượng được chỉ định
            _employeeDetail.ShowDialog(this);
        }
        private void gridEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //gọi nhầm sự kiện
        }
        private void gridEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _employeeDetail = new EmployeeDetail();
            userId = gridEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();

            _employeeDetail.LoadEmployee(new Employee
            {
                UserID = userId,
                UserName = gridEmployees.Rows[e.RowIndex].Cells[2].Value.ToString(),
                Password = gridEmployees.Rows[e.RowIndex].Cells[3].Value.ToString(),
                Email = gridEmployees.Rows[e.RowIndex].Cells[4].Value.ToString(),
                Tel = gridEmployees.Rows[e.RowIndex].Cells[5].Value.ToString(),
                Disable = (byte)(gridEmployees.Rows[e.RowIndex].Cells[6].Value as byte?),
            });
        }

        private void DeleteMenuItem_Click(object sender, System.EventArgs e)
        {
            _businessLogicLayer.DeleteEmployee(userId);
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PopulateEmployees();
        }
        #endregion

        #region PRIVATE METHODS
        private void Main_Load(object sender, System.EventArgs e)
        {
            PopulateEmployees();
        }

        private void UpdateRowNumbers()
        {
            // Duyệt qua mỗi hàng trong DataGridView và cập nhật số thứ tự
            for (int i = 0; i < gridEmployees.Rows.Count; i++)
            {
                gridEmployees.Rows[i].Cells["Index"].Value = (i + 1).ToString();
            }
        }

        private void OpenContactDetailsDialog()
        {
            EmployeeDetail contactDetails = new EmployeeDetail();
            contactDetails.ShowDialog(this);
        }
        #endregion


        #region PUBLIC METHODS
        public void PopulateEmployees()
        {
            ObjectResult<spGetAllEmployee_Result> employees = _businessLogicLayer.GetEmployees();
            gridEmployees.DataSource = employees;
            // Gọi hàm đếm thứ tự khi Form được load
            UpdateRowNumbers();
        }
        #endregion

    }
}
