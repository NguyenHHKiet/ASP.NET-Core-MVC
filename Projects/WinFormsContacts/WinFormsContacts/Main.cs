using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsContacts
{
    public partial class Main : Form
    {
        private readonly BusinessLogicLayer _businessLogicLayer = null;
        public Main()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        #region EVENTS
        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateContacts(txtSearch.Text);
            txtSearch.Text = string.Empty;
        }
        private void gridContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)gridContacts.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value.ToString() == "Edit")
            {
                ContactDetails contactDetails = new ContactDetails();
                contactDetails.LoadContact(new Contacts
                {
                    Id = int.Parse((gridContacts.Rows[e.RowIndex].Cells[0]).Value.ToString()),
                    FirstName = gridContacts.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    LastName = gridContacts.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Phone = gridContacts.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Address = gridContacts.Rows[e.RowIndex].Cells[4].Value.ToString(),
                });
                contactDetails.ShowDialog(this);
            }
            if (cell.Value.ToString() == "Delete")
            {
                DeleteContacts(int.Parse((gridContacts.Rows[e.RowIndex].Cells[0]).Value.ToString()));
                PopulateContacts();
            }
        }


        #endregion

        #region PRIVATE METHODS

        private void OpenContactDetailsDialog()
        {
            ContactDetails contactDetails = new ContactDetails();
            contactDetails.ShowDialog(this);
        }

        private void DeleteContacts(int id)
        {
            _businessLogicLayer.DeleteContacts(id);
        }

        #endregion

        #region PUBLIC METHODS
        public void PopulateContacts(string searchText = null)
        {
            List<Contacts> contacts = _businessLogicLayer.GetContacts(searchText);
            gridContacts.DataSource = contacts;
        }

        #endregion
    }
}
