

using Dapper;
using SqliteDataAccess.DTO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace SqliteDataAccess
{
    public class AddressRepository
    {

        public static int InsertContacts(Contact contact)
        {

            using (var connection = GetConnection())
            {
                connection.Open();

                var status = connection.Query<int>(
                    @"INSERT INTO Contact(Name, City, Country)
                     VALUES 
                     (@Name, @City, @Country)
                     ", contact);
            }

            return 1;

        }





        public static List<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            using (var connection = GetConnection())
            {

                var contactsList = connection.Query<Contact>(
                    @"SELECT * FROM Contact;"
                    );

                contacts = contactsList.ToList();
            }


            return contacts;

        }



        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=Address.db");
        }
    }
}
