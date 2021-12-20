using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET_AddressBook
{
    class AddressBookConfig
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = address_book; Trusted_Connection = true";
            con = new SqlConnection(connectionString);
        }
        public Contact AddContact(Contact contact) 
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddContact", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", contact.FirstName);
                com.Parameters.AddWithValue("@LastName", contact.LastName);
                com.Parameters.AddWithValue("@Address", contact.Address);
                com.Parameters.AddWithValue("@City", contact.City);
                com.Parameters.AddWithValue("@State", contact.State);
                com.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
                com.Parameters.AddWithValue("@Phone", contact.Phone);
                com.Parameters.AddWithValue("@Email", contact.Email);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return contact;
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
        public bool UpdateContact(int id ,string FirstName) 
        {
            try
            { 
                Connection();

                SqlCommand com = new SqlCommand("UpdateContact", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@FirstName", FirstName);                
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int DeleteContact(int id)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("DeleteContact", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return id;
                else
                    return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public DataSet GetAllContacts()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("GetAddressBook", con);
                com.CommandType = CommandType.StoredProcedure;
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("GetAddressBook", this.con);
                adapter.Fill(dataSet, "AddressBook");
                foreach (DataRow dr in dataSet.Tables["AddressBook"].Rows)
                {
                    Console.WriteLine(dr["id"] + " " + dr["FirstName"] + " " + dr["LastName"] + " " + dr["Address"] + " " + dr["City"] + " " + dr["State"] + " "
                     + dr["ZipCode"] + " " + dr["Phone"] + " " + dr["Email"]);
                }
                con.Close();
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
