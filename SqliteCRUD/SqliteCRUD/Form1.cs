using SqliteDataAccess;
using SqliteDataAccess.DTO;
using System;

using System.Windows.Forms;

namespace SqliteCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var contact =
              new Contact
              {
                  City = textBoxCity.Text,
                  Name = textBoxName.Text,
                  Country = textBoxCountry.Text
              };

            var status = AddressRepository.InsertContacts(contact);
        }

        private void buttonDisplayContacts_Click(object sender, EventArgs e)
        {
            var contacts = AddressRepository.GetContacts();

            dataGridView1.DataSource = contacts;
        }
    }
}
