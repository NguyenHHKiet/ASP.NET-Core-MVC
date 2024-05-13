using System;
using System.Windows.Forms;

namespace WinFormsContacts
{
    public partial class ContactDetails : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        private Contacts _contact = null;
        public ContactDetails()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        #region EVENTS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();
            this.Close();
            ((Main)this.Owner).PopulateContacts();
        }

        #endregion

        #region PRIVATE METHODS
        private void SaveContact()
        {
            Contacts contact = new Contacts
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                Id = _contact != null ? _contact.Id : 0
            };

            _businessLogicLayer.SaveContact(contact);
        }

        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void ContactDetails_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region PUBLIC METHODS
        public void LoadContact(Contacts contacts)
        {
            _contact = contacts;
            if (contacts != null)
            {
                ClearForm();

                txtFirstName.Text = contacts.FirstName;
                txtLastName.Text = contacts.LastName;
                txtPhone.Text = contacts.Phone;
                txtAddress.Text = contacts.Address;
            }
        }
        #endregion
    }
}
