using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    class CreditCard
    {
        private String CardNumber;
        private enum CardTypes {EXPRESS=3,VISA=4,MASTER=5,DISCOVER=6};
        private CardTypes CardType;
        private int CVV;

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
    }
}
