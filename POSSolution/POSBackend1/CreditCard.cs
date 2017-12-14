using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
   public class expDate
   {
      public int month { get; set; }
      public int year { get; set; }
      public override string ToString()
      {
         return month.ToString() + year.ToString();
      }
   }
   public class CreditCard
   {
      private string cardNumber;
      public enum CardTypes { EXPRESS = 3, VISA = 4, MASTER = 5, DISCOVER = 6 };
      private CardTypes cardType;
      private int cvv;
      private expDate expDate;
      private string holderName;
      private Address billingAddr;

      public int CardNumber { get { return int.Parse(cardNumber); } }
      public expDate ExpirationDate { get { return expDate; } }
      public string HolderName { get { return holderName; } }
      public Address BillingAddress { get { return billingAddr; } }


      /// <summary>
      /// 
      /// </summary>
      /// <param name="num">creditcard number</param>
      /// <param name="code">security Code</param>
      /// <param name="exp">expiration date</param>
      /// <param name="name"></param>
      /// <param name="addr"></param>
      public CreditCard(string num, int code, expDate exp, string name, Address addr)
      {
         cardNumber = num;
         cvv = code;
         expDate = exp;
         holderName = name;
         billingAddr = addr;

         getCardType();
      }

      public string GetDisplayCardNumber()
      {
         string displayString = "";
         for(int i = 0; i < cardNumber.Length; i++)
         {
            if (i >= cardNumber.Length - 4)
               displayString += cardNumber[i];
            else
               displayString += '*';
         }
         return displayString;
      }

      public string GetDisplayCardType()
      {
         string display = "Unknown";
         switch (cardType)
         {
            case CardTypes.EXPRESS:
               display = "EXPRESS";
               break;
            case CardTypes.VISA:
               display = "VISA";
               break;
            case CardTypes.MASTER:
               display = "MASTER";
               break;
            case CardTypes.DISCOVER:
               display = "DISCOVER";
               break;
         }
         return display;
      }
      /**
       * Sets the card searchTerm based on the card number
       * American Express starts with 3
       * Visa starts with 4
       * MasterCard starts with 5
       * Discover starts with 6
       */
      private void getCardType()
      {
         int firstNum = int.Parse(cardNumber[0].ToString());
         switch (firstNum)
         {
            case (int)CardTypes.EXPRESS:
               cardType = CardTypes.EXPRESS;
               break;
            case (int)CardTypes.VISA:
               cardType = CardTypes.VISA;
               break;
            case (int)CardTypes.MASTER:
               cardType = CardTypes.MASTER;
               break;
            case (int)CardTypes.DISCOVER:
               cardType = CardTypes.DISCOVER;
               break;
         }
      }

      /**
       * Validates that the card is not expired and the user entered the correct security code
       * code: user's submitted security code
       */
      public bool validate(int code)
      {
         bool expired = true;

         // Check if the card is not expired
         if (expDate.year > DateTime.Now.Date.Year ||
             (expDate.year == DateTime.Now.Date.Year && expDate.month > DateTime.Now.Date.Month))
            expired = false;

         // If the security code matches and the card is not expired then the transaction is valid
         if (code == cvv && !expired)
            return true;

         return false;
      }

      public bool charge(int code)
      {
         return validate(code);
      }

      public override bool Equals(object obj)
      {
         var creditCard = obj as CreditCard;
         if (creditCard == null)
            return false;
         return (creditCard.cardNumber.Equals(cardNumber) && creditCard.cvv == cvv);
      }
   }
}
