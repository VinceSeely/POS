using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSBackend;


namespace POSBackend
{
    public class AccountManager
    {
        private List<User> userList = new List<User>(); 
        private static AccountManager _acminstance;
        public static  AccountManager  ACMInstance
        {
            get
            {
                _acminstance = _acminstance ?? new AccountManager();
                return _acminstance;
            }
        }

        private AccountManager()
        {

        }


        public bool CreateAccount(string username, string firstName, string lastName, string password, string phoneNumber, Address address)
        {
            User createdUser = new User(firstName, lastName, username, password, phoneNumber, address);
            if (userList.Contains(createdUser))
                return false;
            userList.Add(createdUser);
            return true;
        }
        
        public bool RemoveAccount(string username, string password)
        {
            bool successful = false;
            User removeUser = new User("", "", username, "", "", null);
            int indexOfuser  = userList.IndexOf(removeUser);
            if (userList[indexOfuser].ComparePassword(password))
            {
                userList.RemoveAt(indexOfuser);
                successful = true;
            }
            return successful;
        }

        public bool ChangePassword (string username, string password, string newPassword)
        {
            bool successful = false;
            User tempUser = new User("", "", username, "", "", null);
            int indexofUser = userList.IndexOf(tempUser);
            if (userList[indexofUser].ComparePassword(password))
            {
                userList[indexofUser].Password = newPassword;
            }

            return successful;
        }
        public bool ChangeLastName(string username, string password, string LastName)
        {
            bool successful = false;
            User tempUser = new User("", "", username, "", "", null);
            int indexofUser = userList.IndexOf(tempUser);
            if (userList[indexofUser].ComparePassword(password))
            {
                userList[indexofUser].LastName = LastName;
            }

            return successful;
        }

        public bool ChangeFirstName(string username, string password, string FirstName)
        {
            bool successful = false;
            User tempUser = new User("", "", username, "", "", null);
            int indexofUser = userList.IndexOf(tempUser);
            if (userList[indexofUser].ComparePassword(password))
            {
                userList[indexofUser].FirstName = FirstName;
            }

            return successful;
        }

        public bool ChangePhoneNumber(string username, string password, string PhoneNumber)
        {
            bool successful = false;
            User tempUser = new User("", "", username, "", "", null);
            int indexofUser = userList.IndexOf(tempUser);
            if (userList[indexofUser].ComparePassword(password))
            {
                userList[indexofUser].PhoneNumber = PhoneNumber;
            }

            return successful;
        }

        public bool ChangeAddress(string username, string password, Address Address)
        {
            bool successful = false;
            User tempUser = new User("", "", username, "", "", null);
            int indexofUser = userList.IndexOf(tempUser);
            if (userList[indexofUser].ComparePassword(password))
            {
                userList[indexofUser].UserAddress = Address;
            }

            return successful;
        }

        public bool AddCreditCard(string username, string password, CreditCard newCard)
        {
            bool successful = false;
            User tempUser = new User("", "", username, "", "", null);
            int indexofUser = userList.IndexOf(tempUser);
            if (userList[indexofUser].ComparePassword(password))
            {
                userList[indexofUser].AddCreditCard(newCard);
                successful = true;
            }

            return successful;
        }

        public bool AddWishList(string name)
        {
            bool successful = false;
            return successful;
        }

        public WishList GetWishList(string username)
        {
            User tempUser = new User("", "", username, "", "", null);
            return userList.FirstOrDefault(user => user.Equals(tempUser))?.WishList;            
        }

        public bool AddToWishList(string username, Item newItem)
        {
            bool succesful = false;
            User tempUser = new User("", "", username, "", "", null);
            var wishListUserIndex = userList.IndexOf(tempUser);
            if (wishListUserIndex != -1)
            {
                userList[wishListUserIndex].AddItemWishList(newItem);
                succesful = true;
            }
            return succesful; 

        }

        public bool RemoveFromWishList(string username, Item removedItem)
        {
            bool succesful = false;
            User tempUser = new User("", "", username, "", "", null);
            var wishListUserIndex = userList.IndexOf(tempUser);
            if (wishListUserIndex != -1)
            {
                userList[wishListUserIndex].RemoveItemWishList(removedItem);
                succesful = true;
            }
            return succesful;
        }

        public bool EditPermissions()
        {
            throw new NotImplementedException();
        }

        public bool ProcessPayment(float total)
        {
            throw new NotImplementedException();
        }

        public User Login(string username, string password)
        {
            User tempUser = new User("", "", username, "", "", null);
            int indexofUser = userList.IndexOf(tempUser);
            if (userList[indexofUser].ComparePassword(password))
            {
                return (userList[indexofUser]);
            }
            return null;
        }

        public bool UpdatePersmisions(string username, string newPermsion)
        {
            throw new NotImplementedException();
            var indexofUser = userList.First(user => user.Username.Equals(username));
            if(indexofUser.Permisions.IsSuperUser)
            {

            }
            return false;
        }
    }
}
