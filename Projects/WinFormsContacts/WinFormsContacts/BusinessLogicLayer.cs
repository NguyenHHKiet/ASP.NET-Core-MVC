using System.Collections.Generic;

namespace WinFormsContacts
{
    internal class BusinessLogicLayer
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public BusinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        public Contacts SaveContact(Contacts contacts)
        {
            if (contacts.Id == 0)
            {
                _dataAccessLayer.InsertContact(contacts);
            }
            else
            {
                _dataAccessLayer.UpdateContact(contacts);
            }
            return contacts;
        }

        public List<Contacts> GetContacts(string searchText = null)
        {
            return _dataAccessLayer.GetContacts(searchText);
        }

        internal void DeleteContacts(int id)
        {
            _dataAccessLayer.DeleteContacts(id);
        }
    }
}
