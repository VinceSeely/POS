using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    class User
    {
        private List<User> allUsers = new List<User>();
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string phoneNumber;
        public struct Address
        {
            string streetAddress;
            string state;
            string country;
            string city;
            int zipCode; 
        }
        Address userAddress;

        public User(string first, string last, string theirUsername, string theirPassword, string newPhoneNumber, Address newUserAddress)
        {
            firstName = first;
            lastName = last;
            username = theirUsername;
            password = theirPassword;
            phoneNumber = newPhoneNumber;
            userAddress = newUserAddress;

        }

        public void EditPhoneNumber(string newNumber, string currentUsername, string currentPassword)
        {
            
        }

        public void EditAddress (Address newAdress)
        {

        }

    }
}
