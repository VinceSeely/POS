using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
   public class User
   {
      //private List<User> allUsers = new List<User>();
      //private string firstName;
      //private string lastName;
      //private string username;
      //private string password;
      // private string phoneNumber;

      public string Password { get; set; }
      public string Username { get; set; }
      public string PhoneNumber { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      //public string  { get; set; }
      public Address UserAddress { get; set; }
      public Cart UserCart { get; set; }

      internal bool AddToCart(int sku)
      {
         return UserCart.addItem(sku, 1);
      }

      public WishList WishList { get; set; }
      public Permissions Permisions { get; internal set; }

      private List<CreditCard> creditCards;

      public User(string first, string last, string theirUsername, string theirPassword, string newPhoneNumber, Address newUserAddress)
      {
         FirstName = first;
         LastName = last;
         Username = theirUsername;
         Password = theirPassword;
         PhoneNumber = newPhoneNumber;
         UserAddress = newUserAddress;
         creditCards = new List<CreditCard>();
         WishList = new WishList();
         UserCart = new Cart();
      }


      internal bool ComparePassword(string submittedPassword)
      {
         return submittedPassword == Password;
      }


      public override bool Equals(object obj)
      {
         var user = obj as User;
         if (user == null)
            return false;
         return (Username.Equals(user.Username) && this.ComparePassword(user.Password));
      }

      public void AddCreditCard(CreditCard newCard)
      {
         creditCards.Add(newCard);
      }

      public void RemoveCreditCard(CreditCard removalCard)
      {
         int index = creditCards.IndexOf(removalCard);
         if (index != -1)
         {
            creditCards.RemoveAt(index);
         }
      }

      public List<CreditCard> GetCreditCards()
      {
         return creditCards;
      }

      internal void RemoveItemWishList(Item newItem)
      {
         WishList.RemoveItem(newItem);
      }

      internal void AddItemWishList(Item removedItem)
      {
         WishList.AddItem(removedItem);
      }

      internal void placeOrder()
      {
         OrderManger.OrderMangerInstance.AddOrder(UserCart.Items, UserCart.Total);
         UserCart = new Cart();
      }
   }
}
