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
    }
    class CreditCard
    {
        private String CardNumber;
        private enum CardTypes {EXPRESS=3,VISA=4,MASTER=5,DISCOVER=6};
        private CardTypes CardType;
        private int CVV;
        private expDate expDate;
        private String holderName;
        private Address billingAddr;

     


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
            CardNumber = num;
            CVV = code;
            expDate = exp;
            holderName = name;
            billingAddr = addr;

            getCardType();
        }

        /**
         * Sets the card type based on the card number
         * American Express starts with 3
         * Visa starts with 4
         * MasterCard starts with 5
         * Discover starts with 6
         */
        private void getCardType()
        {
            int firstNum = Convert.ToInt32(CardNumber[0]);
            switch (firstNum)
            {
                case (int)CardTypes.EXPRESS:
                    CardType = CardTypes.EXPRESS;
                    break;

                case (int)CardTypes.VISA:
                    CardType = CardTypes.VISA;
                    break;

                case (int)CardTypes.MASTER:
                    CardType = CardTypes.MASTER;
                    break;
                case (int)CardTypes.DISCOVER:
                    CardType = CardTypes.DISCOVER;
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
            if (code == CVV && !expired)
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
            return (creditCard.CardNumber.Equals(CardNumber) && creditCard.CVV == CVV);
        }
    }
}
